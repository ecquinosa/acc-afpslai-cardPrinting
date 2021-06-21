'options
Option Strict On
Option Explicit On

Imports System
Imports System.Text
Imports System.Runtime.InteropServices

Public Class CIomem

    Private _answer As String
    Private _answerError As String
    Private _cde As String
    Private _DwdCde As IntPtr
    Private PrinterName As String

    Private _cdeLen As Int32
    Private _hPrinter As Int32
    Private _nbBytesRead As Integer
    Private _ribbon As Boolean
    ' <summary>
    ' To open and grant access to the local port attached to the printer driver
    ' </summary>
    ' <returns>Handle on the port</returns>
    Public Function OpenEvoPrinter() As Int32
        _hPrinter = OpenPebble(PrinterName)
        OpenEvoPrinter = _hPrinter
    End Function

    ' <summary>
    ' To close and free access to the local port.
    ' </summary>
    '<returns>True if correct</returns>
    ' <returns>False otherwise</returns>
    Public Function CloseEvoPrinter() As Boolean
        CloseEvoPrinter = ClosePebble(_hPrinter)
    End Function
    ' <summary>
    ' To read answer from the printer
    '</summary>
    ' <returns>True: if answer available</returns>
    ' <returns>False otherwise</returns>
    Public Function ReadPrinterAnswer() As Boolean
        Dim bRead As Boolean = False
        Dim lpBuffer As IntPtr = Marshal.AllocHGlobal(1024)
        If Not lpBuffer.Equals(IntPtr.Zero) Then
            bRead = ReadPebble(_hPrinter, lpBuffer, 1024, _nbBytesRead)
            If bRead Then
                _answer = Marshal.PtrToStringAnsi(lpBuffer, _nbBytesRead)
            End If
        End If
        Marshal.FreeHGlobal(lpBuffer)
        ReadPrinterAnswer = bRead
    End Function
    ' <summary>
    ' To write a short command to the printer.
    ' </summary>
    ' <returns>True: if it correct</returns>
    ' <returns>False otherwise</returns>
    Public Function WritePrinterCde() As Boolean
        Dim iPrtStatus As Integer
        WritePrinterCde = False
        GetStatusEvo(_hPrinter, iPrtStatus)
        If ((iPrtStatus And &HFF) = &H18) Then
            WritePrinterCde = WritePebble(_hPrinter, _cde, _cdeLen)
        Else
            _answerError = "Printer is not ready or detected"
        End If
    End Function


    '<summary>
    'Sequence to synchronize writing and reading.
    '</summary>
    '<returns>True: if writing and readin are correct</returns>
    '<returns>False otherwise</returns>
    Public Function WRPrinter(<InAttribute()> ByRef bDo As Boolean) As Boolean
        Dim iPrtStatus As Integer
        Dim lpBuffer As IntPtr = IntPtr.Zero
        WRPrinter = False
        If (bDo) Then
            GetStatusEvo(_hPrinter, iPrtStatus)
            If ((iPrtStatus And &H18) = &H18) Then
                lpBuffer = Marshal.AllocHGlobal(1024)
                If Not lpBuffer.Equals(IntPtr.Zero) Then
                    WRPrinter = WritePebble(_hPrinter, _cde, _cdeLen)
                    If WRPrinter Then
                        WRPrinter = ReadPebble(_hPrinter, lpBuffer, 1024, _nbBytesRead)
                        If WRPrinter Then
                            _answer = Marshal.PtrToStringAnsi(lpBuffer, CInt(_nbBytesRead))
                            If _answer <> "OK" Then
                                _answerError = Marshal.PtrToStringAnsi(lpBuffer, CInt(_nbBytesRead))
                            End If
                        Else
                            bDo = False
                            _answerError = "Fails to read"
                        End If
                    Else
                        bDo = False
                        _answerError = "Fails to write"
                    End If
                    Marshal.FreeHGlobal(lpBuffer)
                End If
            Else
                bDo = False
                _answerError = "Printer is not ready or detected"
            End If
        End If
    End Function

    ' <summary>
    ' Sequence to synchronize writing and reading and checks taht answer is "OK"
    ' </summary>
    ' <returns>True: if writing and reading are correct and the answer is "OK"</returns>
    ' <returns>False otherwise</returns>
    Public Function WRPrinterOK(<InAttribute()> ByRef bDo As Boolean) As Boolean
        Dim iPrtStatus As Integer
        Dim lpBuffer As IntPtr = Marshal.AllocHGlobal(1024)
        WRPrinterOK = False

        If (bDo) Then
            GetStatusEvo(_hPrinter, iPrtStatus)
            If ((iPrtStatus And &H18) = &H18) Then
                lpBuffer = Marshal.AllocHGlobal(1024)
                If Not lpBuffer.Equals(IntPtr.Zero) Then
                    WRPrinterOK = WritePebble(_hPrinter, _cde, _cdeLen)
                    If WRPrinterOK Then
                        WRPrinterOK = ReadPebble(_hPrinter, lpBuffer, 1024, _nbBytesRead)
                        If WRPrinterOK Then
                            _answer = Marshal.PtrToStringAnsi(lpBuffer, CInt(_nbBytesRead))
                            If _answer = "OK" Then
                                WRPrinterOK = True
                            Else
                                WRPrinterOK = False
                                bDo = False
                                _answerError = Marshal.PtrToStringAnsi(lpBuffer, CInt(_nbBytesRead))
                            End If
                        Else
                            _answerError = "Fails to read"
                            bDo = False
                        End If
                    Else
                        _answerError = "Fails to write"
                        bDo = False
                    End If
                    Marshal.FreeHGlobal(lpBuffer)
                End If
            Else
                _answerError = "Printer is not ready or detected"
                bDo = False
            End If
        End If
    End Function
    ' <summary>
    ' Sequence to synchronize writing and reading and checks taht answer is "OK"
    ' Used for huge escape command especially downloading command
    ' </summary>
    ' <returns>True: if writing and reading are correct and the answer is "OK"</returns>
    ' <returns>False otherwise</returns>
    Public Function DownloadOK(<InAttribute()> ByRef bDo As Boolean) As Boolean
        Dim lpBuffer As IntPtr
        Dim iPrtStatus As Integer
        DownloadOK = False
        If (bDo) Then
            lpBuffer = Marshal.AllocHGlobal(1024)
            If Not lpBuffer.Equals(IntPtr.Zero) Then
                GetStatusEvo(_hPrinter, iPrtStatus)
                If ((iPrtStatus And &H18) = &H18) Then
                    DownloadOK = WritePebble(_hPrinter, (Marshal.PtrToStringAnsi(_DwdCde, _cdeLen)), _cdeLen)
                    If DownloadOK Then
                        DownloadOK = ReadPebble(_hPrinter, lpBuffer, 1024, _nbBytesRead)
                        If DownloadOK Then
                            _answer = Marshal.PtrToStringAnsi(lpBuffer, CInt(_nbBytesRead))
                            If _answer = "OK" Then
                                DownloadOK = True
                            Else
                                DownloadOK = False
                                bDo = False
                                _answerError = Marshal.PtrToStringAnsi(lpBuffer, CInt(_nbBytesRead))
                            End If
                        Else
                            _answerError = "Fails to read"
                            bDo = False
                        End If
                    Else
                        _answerError = "Fails to write"
                        bDo = False
                    End If
                    Marshal.FreeHGlobal(lpBuffer)
                Else
                    _answerError = "Printer is not ready or detected"
                    bDo = False
                End If
            End If
        End If
    End Function
    ' <summary>
    ' To get the currect timeout value
    ' </summary>
    ' <returns>Timeout value in milliseconds</returns>
    ' <summary>
    ' To set the timeout value
    ' </summary>
    ' <param name="value">value defined in milliseconds</param>
    Public Property gsTimeout() As Int32
        Get
            Return (GetTimeout())
        End Get
        Set(ByVal value As Int32)
            SetTimeout(value)
        End Set
    End Property
    ' <summary>
    ' Read last answer from printer
    ' </summary>
    ' <returns> a pointer to the string buffer</returns>
    Public ReadOnly Property getLastAnswer() As String
        Get
            getLastAnswer = _answer
        End Get
    End Property
    ' <summary>
    '  read the answer error returned by the printer
    ' </summary>
    ' <returns>a pointer to the string buffer</returns>
    Public ReadOnly Property getLastAnswerError() As String
        Get
            getLastAnswerError = _answerError
        End Get
    End Property
    ' <summary>
    ' To set the escape command to send to the printer
    ' </summary>
    ' <param name="newCde">escape command</param>
    Public WriteOnly Property setCde() As String
        Set(ByVal value As String)
            _cde = value
            _cdeLen = value.Length
        End Set
    End Property
    '<summary>
    'To set the download escape command.
    '</summary>
    '<param name="newCde">downloading escape command</param>
    '<param name="size">size of the buffer that contains escape command.</param>
    '<returns></returns>
    Sub SetDwdCde(<InAttribute()> ByVal newCde As IntPtr, <InAttribute()> ByVal size As Integer)
        _cdeLen = size
        _DwdCde = newCde
    End Sub
    ' <summary>
    ' It return the printer name we are using.
    '</summary>
    ' <returns>string that contains the information</returns>
    ' <summary>
    ' To set the printer/driver name to open for communication;
    ' </summary>
    ' <param name="newName">string that contains driver name.</param>
    ' <returns></returns>
    Public Property gsPrinterName() As String
        Get
            gsPrinterName = PrinterName
        End Get
        Set(ByVal value As String)
            PrinterName = value
        End Set
    End Property

End Class
