'options
'Option Strict On
'Option Explicit On

'espace de noms
Imports System
Imports System.Text
Imports System.Runtime.InteropServices
Imports AFPSLAI_EVOLISPRIMACY.EnumPrinters
Imports AFPSLAI_EVOLISPRIMACY.Spooler

'-----------------------------------------------------'
Public Class CPrinter
    Inherits CIomem
    Implements IDisposable

    'properties
    Protected printerID As String
    Protected serialNumber As String
    Protected kitHead As String
    Protected firmware As String
    Protected cover As Boolean
    Protected card As Boolean
    Protected nbCardsImp As String
    Protected nbCardsIns As String
    Protected nbCardsBeforeCleaning As String
    Protected needCleaning As Boolean
    Protected insMode As String
    Protected mode As String
    Protected driveName As String

    Public mag As CMag = New CMag
    Public bmp As CBmp = New CBmp
    Public printerErrorCol As New Collection

    Public prtId As New Hashtable
    Public csaValue As ArrayList = New ArrayList

    'Public Sub Initialize()
    
    'End Sub
    Public Sub New()
        printerErrorCol.Add("The escape command was successfully executed", "OK")
        printerErrorCol.Add("It is produced an error", "ERROR")
        printerErrorCol.Add("The escape command is incorrect", "ERROR CDE")
        printerErrorCol.Add("The parameter of the escape command is incorrect", "ERROR PARAMETRES")
        printerErrorCol.Add("The printer needs cleaning", "NEED CLEANING")
        printerErrorCol.Add("Error timeout", "ERROR TIME OUT")
        printerErrorCol.Add("Error mechanics hopper", "ERROR HOPPER")
        printerErrorCol.Add("The hopper is full", "HOPPER FULL")
        printerErrorCol.Add("The hopper door is open", "HOPPER DOOR")
        printerErrorCol.Add("Error on print head", "ERROR HEAD")
        printerErrorCol.Add("The cover is open", "COVER OPEN")
        printerErrorCol.Add("The feeder is empty", "FEEDER EMPTY")
        printerErrorCol.Add("The card is blocked", "CARD JAM")
        printerErrorCol.Add("No ribbon or bad ribbon", "ERROR RIBBON")
        printerErrorCol.Add("Option not present on the printer", "OPT NOT AVAILABLE")
        printerErrorCol.Add("Error magnetic check", "ERROR MAG CHECKSUM")
        printerErrorCol.Add("Data magnetic is invalidate", "ERROR MAG DATA")
        printerErrorCol.Add("Error on magnetic writing", "ERROR MAG")
        printerErrorCol.Add("Unknow error", "ERROR UNKNOW")
    End Sub
    ' Implement IDisposable.
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
        While printerErrorCol.Count
            printerErrorCol.Remove(1)
        End While
    End Sub
    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub


    ' <summary>
    ' To send an escape command and get its answer
    ' </summary>
    ' <param name="command"></param>
    ' <param name="answer"></param>
    ' <returns></returns>
    Public Sub CommendSend(ByVal command As String, ByRef answer As String)
        If (Me.OpenEvoPrinter() <> vbNull) Then
            Me.setCde = command
            If (Me.WRPrinter(True)) Then
                answer = Me.getLastAnswer
            End If
            Me.CloseEvoPrinter()
        End If
    End Sub
    ' <summary>
    ' To send an escape command and get its answer Port is Opened
    ' </summary>
    ' <param name="escCde"></param>
    ' <param name="Timeout"></param>
    ' <returns>True if execution correct and answer OK</returns>
    Public Function doAction(ByVal command As String, ByVal timeout As Integer, ByRef bDo As Boolean) As Boolean
        doAction = False
        Me.setCde = command
        Me.gsTimeout = timeout
        If (bDo) Then
            doAction = Me.WRPrinterOK(bDo)
            bDo = doAction
        End If
    End Function

    ' <summary>
    ' Analyze printer answer and fill mdetailedAnswer with a more detailed explanation
    ' </summary>
    ' <returns>detailed string answer</returns>
    Public Function analyzeAnswer() As String
        Dim answer As String
        answer = Me.getLastAnswerError()

        Select Case Mid(answer, 1)
            Case "OK"
                analyzeAnswer = CStr(printerErrorCol.Item("OK"))
            Case "ERROR"
                analyzeAnswer = CStr(printerErrorCol.Item("ERROR"))
            Case "ERROR CDE"
                analyzeAnswer = CStr(printerErrorCol.Item("ERROR CDE"))
            Case "ERROR PARAMETRES"
                analyzeAnswer = CStr(printerErrorCol.Item("ERROR PARAMETRES"))
            Case "NEED CLEANING"
                analyzeAnswer = CStr(printerErrorCol.Item("NEED CLEANING"))
            Case "ERROR TIME OUT"
                analyzeAnswer = CStr(printerErrorCol.Item("ERROR TIME OUT"))
            Case "ERROR HOPPER"
                analyzeAnswer = CStr(printerErrorCol.Item("ERROR HOPPER"))
            Case "HOPPER FULL"
                analyzeAnswer = CStr(printerErrorCol.Item("HOPPER FULL"))
            Case "HOPPER DOOR"
                analyzeAnswer = CStr(printerErrorCol.Item("HOPPER DOOR"))
            Case "ERROR HEAD"
                analyzeAnswer = CStr(printerErrorCol.Item("ERROR HEAD"))
            Case "COVER OPEN"
                analyzeAnswer = CStr(printerErrorCol.Item("COVER OPEN"))
            Case "FEEDER EMPTY"
                analyzeAnswer = CStr(printerErrorCol.Item("FEEDER EMPTY"))
            Case "CARD JAM"
                analyzeAnswer = CStr(printerErrorCol.Item("CARD JAM"))
            Case "ERROR RIBBON"
                analyzeAnswer = CStr(printerErrorCol.Item("ERROR RIBBON"))
            Case "ERROR FLASH UNKNOW"
                analyzeAnswer = CStr(printerErrorCol.Item("ERROR FLASH UNKNOW"))
            Case "ERROR CHECKSUM"
                analyzeAnswer = CStr(printerErrorCol.Item("ERROR CHECKSUM"))
            Case "OPT NOT AVAILABLE"
                analyzeAnswer = CStr(printerErrorCol.Item("OPT NOT AVAILABLE"))
            Case "ERROR MAG CHECKSUM"
                analyzeAnswer = CStr(printerErrorCol.Item("ERROR MAG CHECKSUM"))
            Case "ERROR MAG DATA"
                analyzeAnswer = CStr(printerErrorCol.Item("ERROR MAG DATA"))
            Case "ERROR MAG"
                analyzeAnswer = CStr(printerErrorCol.Item("ERROR MAG"))
            Case "ERROR UNKNOW"
                analyzeAnswer = CStr(printerErrorCol.Item("ERROR UNKNOW"))
            Case Else
                analyzeAnswer = answer
        End Select
    End Function
    '<summary>
    'Write the three magnetic tracks.
    'Magnetic tracks data has to be set through CMag class
    '</summary>
    '<returns> True: error</returns>
    '<returns> False: done</returns>
    Public Function WriteTracks() As Boolean
        Dim i As Integer
        Dim command As String

        WriteTracks = True

        If (Me.OpenEvoPrinter()) Then
            WriteTracks = doAction(Chr(27) & "Pem;2" & Chr(13), 2000, WriteTracks)
            WriteTracks = doAction(Chr(27) & "Ss" & Chr(13), 2000, WriteTracks)
            WriteTracks = doAction(mag.gsCoer, 2000, WriteTracks)
            Me.gsTimeout = 30000
            If (WriteTracks = True) Then
                For i = 1 To 3
                    command = mag.gDownloadData(i)
                    If (command.Length <> 0) Then
                        Me.setCde() = command
                        If (Me.WRPrinterOK(WriteTracks) = False) Then
                            WriteTracks = False
                            mag.SetStatusCdeTrack(getLastAnswer(), i)
                        Else
                            mag.SetStatusCdeTrack("Done", i)
                        End If
                    End If
                Next i
            End If

            If (WriteTracks = True) Then
                command = mag.WriteMagTracks()
                If (command.Length <> 0) Then
                    Me.setCde() = command
                    If (Me.WRPrinterOK(WriteTracks) = False) Then
                        WriteTracks = False
                    End If
                End If
            End If

            WriteTracks = doAction(Chr(27) & "Pem;0" & Chr(13), 2000, WriteTracks)
            Me.CloseEvoPrinter()
        End If

    End Function
    '<summary>
    'Read the three magnetic tracks.
    'Magnetic tracks data returned are accessibles through CMag class
    '</summary>
    '<returns> True: done</returns>
    '<returns> False: </returns>
    Public Function ReadTracks() As Boolean
        Dim i As Integer
        ReadTracks = True

        If (Me.OpenEvoPrinter()) Then
            ReadTracks = doAction(Chr(27) & "Pem;2" & Chr(13), 2000, ReadTracks)
            ReadTracks = doAction(Chr(27) & "Ss" & Chr(13), 2000, ReadTracks)

            Me.gsTimeout() = 30000
            Me.setCde() = mag.ReadMagTracks()
            If (Me.WRPrinterOK(ReadTracks) = True) Then
                'For i = 1 To 3
                '    If (ReadTracks) Then
                '        Me.setCde() = mag.ReadMagTracksBuffer(i)
                '        If (Me.WRPrinter(ReadTracks) = False) Then
                '            ReadTracks = False
                '        End If

                '        mag.SetStatusCdeTrack(getLastAnswer(), i)
                '    End If
                'Next i

                For i = 1 To 1
                    If (ReadTracks) Then
                        Me.setCde() = mag.ReadMagTracksBuffer(i + 1)
                        If (Me.WRPrinter(ReadTracks) = False) Then
                            ReadTracks = False
                        End If

                        mag.SetStatusCdeTrack(getLastAnswer(), i + 1)
                    End If
                Next i
            End If
            ReadTracks = doAction(Chr(27) & "Pem;0" & Chr(13), 2000, ReadTracks)

            Me.CloseEvoPrinter()
        End If

    End Function
    '<summary>
    'To print YMCKO card by downloading data with uncompressed format.
    '</summary>
    '<returns>True if done properly</returns>
    '<returns>False otherwise</returns>
    Public Function ColorPrintingNC() As Boolean

        Dim command As IntPtr
        Dim lCommandSize As Int32
        Dim numberOfByteToWrite As Int32 = 0
        Dim bStatus As Boolean = True
        Dim i As Integer = 0

        ColorPrintingNC = True

        If (Me.OpenEvoPrinter()) Then
            If (Me.bmp.BlackOption() = True) Then
                Me.bmp.BlackInYMC()
            End If
            lCommandSize = CInt((1016 * 648))
            command = Marshal.AllocHGlobal(lCommandSize)
            If (command.Equals(IntPtr.Zero)) Then
                ColorPrintingNC = False
            Else
                'Download Y, M and C panels
                ColorPrintingNC = doAction(Chr(27) & "Pem;2" & Chr(13), 2000, ColorPrintingNC)
                ColorPrintingNC = doAction(Chr(27) & "Pr;ymcko" & Chr(13), 2000, ColorPrintingNC)
                ColorPrintingNC = doAction(Chr(27) & "Ss" & Chr(13), 2000, ColorPrintingNC)
                If (ColorPrintingNC) Then
                    Me.gsTimeout = 30000
                    For i = 0 To 2
                        If (Me.bmp.ColorSmooth = 0) Then
                            numberOfByteToWrite = Me.bmp.DlBitmap32NC(i, command, lCommandSize)
                        ElseIf (Me.bmp.ColorSmooth = 1) Then
                            numberOfByteToWrite = Me.bmp.DlBitmap64NC(i, command, lCommandSize)
                        ElseIf (Me.bmp.ColorSmooth = 2) Then
                            numberOfByteToWrite = Me.bmp.DlBitmap128NC(i, command, lCommandSize)
                        End If

                        Me.SetDwdCde(command, numberOfByteToWrite)
                        If (DownloadOK(ColorPrintingNC) = False) Then
                            ColorPrintingNC = False
                            Exit For
                        End If
                    Next i
                    Marshal.FreeHGlobal(command)
                    If (ColorPrintingNC) Then
                        lCommandSize = CInt((1016 * 648) / 8)
                        command = Marshal.AllocHGlobal(lCommandSize + 9)
                        If (command.Equals(IntPtr.Zero)) Then
                            ColorPrintingNC = False
                        Else
                            'Download K and O panels
                            If (Me.bmp.BlackOption) Then
                                numberOfByteToWrite = Me.bmp.DlBitmap2NC(i, command, lCommandSize)
                                Me.SetDwdCde(command, numberOfByteToWrite)
                                Me.DownloadOK(ColorPrintingNC)
                            End If
                            i = i + 1
                            lCommandSize = CInt((1016 * 648) / 8)

                            numberOfByteToWrite = Me.bmp.DlBitmap2NC(i, command, lCommandSize)
                            Me.SetDwdCde(command, numberOfByteToWrite)
                            Me.DownloadOK(ColorPrintingNC)
                            Marshal.FreeHGlobal(command)
                        End If
                        bStatus = doAction(Chr(27) & "Se" & Chr(13), 10000, True)
                        bStatus = doAction(Chr(27) & "Pem;0" & Chr(13), 2000, ColorPrintingNC)

                    End If
                End If
            End If

            Me.CloseEvoPrinter()
        End If
    End Function
    '<summary>
    'To print YMCKO card by downloading data with compressed format.
    '</summary>
    '<returns>True if done properly</returns>
    '<returns>False otherwise</returns>
    Public Function ColorPrintingC() As Boolean

        Dim command As IntPtr
        Dim lCommandSize As Int32
        Dim numberOfByteToWrite As Int32 = 0
        Dim bStatus As Boolean = True
        Dim i As Integer = 0

        ColorPrintingC = True

        If (Me.OpenEvoPrinter()) Then
            If (Me.bmp.BlackOption() = True) Then
                Me.bmp.BlackInYMC()
            End If
            lCommandSize = CInt((1016 * 648))
            command = Marshal.AllocHGlobal(lCommandSize)
            If (command.Equals(IntPtr.Zero)) Then
                ColorPrintingC = False
            Else
                'Download Y, M and C panels
                ColorPrintingC = doAction(Chr(27) & "Pem;2" & Chr(13), 2000, ColorPrintingC)
                ColorPrintingC = doAction(Chr(27) & "Pr;ymcko" & Chr(13), 2000, ColorPrintingC)
                ColorPrintingC = doAction(Chr(27) & "Ss" & Chr(13), 2000, ColorPrintingC)
                If (ColorPrintingC) Then
                    Me.gsTimeout = 30000
                    For i = 0 To 2
                        If (Me.bmp.ColorSmooth = 0) Then
                            numberOfByteToWrite = Me.bmp.DlBitmap32C(i, command, lCommandSize)
                        ElseIf (Me.bmp.ColorSmooth = 1) Then
                            numberOfByteToWrite = Me.bmp.DlBitmap64C(i, command, lCommandSize)
                        ElseIf (Me.bmp.ColorSmooth = 2) Then
                            numberOfByteToWrite = Me.bmp.DlBitmap128C(i, command, lCommandSize)
                        End If

                        Me.SetDwdCde(command, numberOfByteToWrite)
                        If (DownloadOK(ColorPrintingC) = False) Then
                            ColorPrintingC = False
                            Exit For
                        End If
                    Next i
                    Marshal.FreeHGlobal(command)
                    If (ColorPrintingC) Then
                        lCommandSize = CInt((1016 * 648) / 8)
                        command = Marshal.AllocHGlobal(lCommandSize + 9)
                        If (command.Equals(IntPtr.Zero)) Then
                            ColorPrintingC = False
                        Else
                            'Download K and O panels
                            If (Me.bmp.BlackOption) Then
                                numberOfByteToWrite = Me.bmp.DlBitmap2C(i, command, lCommandSize)
                                Me.SetDwdCde(command, numberOfByteToWrite)
                                Me.DownloadOK(ColorPrintingC)
                            End If
                            i = i + 1
                            lCommandSize = CInt((1016 * 648) / 8)
                            numberOfByteToWrite = Me.bmp.DlBitmap2C(i, command, lCommandSize)
                            Me.SetDwdCde(command, numberOfByteToWrite)
                            Me.DownloadOK(ColorPrintingC)
                            Marshal.FreeHGlobal(command)
                        End If

                    End If
                    bStatus = doAction(Chr(27) & "Se" & Chr(13), 10000, True)
                    bStatus = doAction(Chr(27) & "Pem;0" & Chr(13), 2000, True)
                End If
            End If

            Me.CloseEvoPrinter()
        End If
    End Function

    '<summary>
    'To print YMCKO card 
    '</summary>
    '<returns>True if done properly</returns>
    '<returns>False otherwise</returns>
    Public Function YMCKOPrinting() As Boolean
        If ((Me.bmp.lPartialStart() + Me.bmp.lPartialTotal) >= 1016) Then
            Me.bmp.lPartialTotal = 1015 - Me.bmp.lPartialStart
        End If

        If (Me.bmp.Comp) Then
            YMCKOPrinting = ColorPrintingC()
        Else
            YMCKOPrinting = ColorPrintingNC()
        End If
    End Function

    '---------------------------------------------------------//
    ' PRINT MONOCHROME 
    '---------------------------------------------------------//
    '<summary>
    'To print monochrome card
    '</summary>
    '<returns></returns>
    Public Function KPrinting() As Boolean
        Dim command As IntPtr
        Dim lCommandSize As Int32
        Dim numberOfByteToWrite As Int32 = 0

        KPrinting = True
        Me.bmp.BlackInYMC()
        Select Case Me.bmp.BlackMode
            Case 0 'Threshold
                Me.bmp.RVBtoK("t")
            Case 1 'Floyd
                Me.bmp.RVBtoK("f")
            Case 2 'Dither
                Me.bmp.RVBtoK("d")
        End Select


        If (Me.OpenEvoPrinter()) Then

            KPrinting = doAction(Chr(27) & "Pem;2" & Chr(13), 2000, KPrinting)
            KPrinting = doAction(Chr(27) & "Pr;k" & Chr(13), 2000, KPrinting)
            KPrinting = doAction(Chr(27) & "Ss" & Chr(13), 2000, KPrinting)
            If (KPrinting) Then

                lCommandSize = CInt((1016 * 648))
                command = Marshal.AllocHGlobal(lCommandSize + 20)

                If (command.Equals(IntPtr.Zero)) Then
                    KPrinting = False
                Else
                    Me.gsTimeout = 30000
                    If (Me.bmp.Comp = 0) Then
                        numberOfByteToWrite = Me.bmp.DlBitmap2NC(3, command, lCommandSize)
                    Else
                        numberOfByteToWrite = Me.bmp.DlBitmap2C(3, command, lCommandSize)
                    End If

                    SetDwdCde(command, numberOfByteToWrite)
                    If (DownloadOK(KPrinting) = False) Then
                        KPrinting = False
                    End If
                    Marshal.FreeHGlobal(command)
                End If

                KPrinting = doAction(Chr(27) & "Se" & Chr(13), 10000, True)
                KPrinting = doAction(Chr(27) & "Pem;0" & Chr(13), 2000, True)
            End If

            Me.CloseEvoPrinter()
        End If
    End Function


    '<summary>
    '
    '</summary>
    Public Property gsDriverName() As String
        Get
            gsDriverName = driveName
        End Get
        Set(ByVal value As String)
            driveName = value
        End Set
    End Property

    '<summary>
    'Standard printer Identificaion
    'Has to be defined for child class
    '</summary>Overridable 
    Public Overridable Function IDPrt() As Boolean
        Dim bStatus As Boolean = True
        Dim enuId As IDictionaryEnumerator

        IDPrt = False

        prtId.Clear()
        csaValue.Clear()

        If (Me.OpenEvoPrinter()) Then
            prtId.Add("Printer ID", Chr(27) & "Rtp" & Chr(13))
            prtId.Add("Serial Number", Chr(27) & "Rsn" & Chr(13))
            prtId.Add("Kit Head", Chr(27) & "Rkn" & Chr(13))
            prtId.Add("Firmware", Chr(27) & "Rfv" & Chr(13))
            enuId = prtId.GetEnumerator()
            doAction(Chr(27) & "Pem;2" & Chr(13), 2000, bStatus)
            While enuId.MoveNext
                Me.setCde = enuId.Value
                If (Me.WRPrinter(bStatus)) Then
                    csaValue.Add(Me.getLastAnswer)
                    IDPrt = True
                Else
                    Exit While
                End If
            End While
            doAction(Chr(27) & "Pem;0" & Chr(13), 2000, bStatus)
            Me.CloseEvoPrinter()
        End If

    End Function

    '<summary>
    'Standard printer status
    'Has to be defined for child class
    '</summary>Overridable
    Public Overridable Function GetStatusPrt() As Boolean

        Dim bStatus As Boolean = True
        Dim enuId As IDictionaryEnumerator

        GetStatusPrt = False
        prtId.Clear()

        csaValue.Clear()

        If (Me.OpenEvoPrinter()) Then
            prtId.Add("Card present", Chr(27) & "Rlr;p" & Chr(13))
            prtId.Add("Nbr of printed cards", Chr(27) & "Rco;p" & Chr(13))
            prtId.Add("Nbr of inserted cards", Chr(27) & "Rco;c" & Chr(13))
            prtId.Add("Next cleaning in", Chr(27) & "Rco;r" & Chr(13))
            prtId.Add("Need cleaning", Chr(27) & "Rlr;c" & Chr(13))
            prtId.Add("Discussion mode", Chr(27) & "Rem" & Chr(13))
            enuId = prtId.GetEnumerator()
            doAction(Chr(27) & "Pem;2" & Chr(13), 2000, bStatus)
            While enuId.MoveNext
                Me.setCde = enuId.Value
                If (Me.WRPrinter(bStatus)) Then
                    csaValue.Add(Me.getLastAnswer)
                    GetStatusPrt = True
                Else
                    Exit While
                End If
            End While
            doAction(Chr(27) & "Pem;0" & Chr(13), 2000, bStatus)
            Me.CloseEvoPrinter()
        End If
    End Function


    '<summary>
    'To wait spooler queeue is empty
    'Useful to manage exclusive access to the port
    'Direct port access control has to be closed
    '</summary>
    '<returns>Number of jobs</returns>
    Public Function WaitSpoolerEmpty() As Integer
        Dim hPrinter As IntPtr
        WaitSpoolerEmpty = 0
        'Me.gsPrinterName = "USB_TATTOO"
        If OpenPrinter(Me.gsPrinterName, hPrinter, New PRINTER_DEFAULTS(PrinterAccessRights.PRINTER_ALL_ACCESS)) Then
            Dim lpdi2 As New PRINTER_INFO_2(hPrinter)
            WaitSpoolerEmpty = lpdi2.JobCount
            ClosePrinter(hPrinter)
        End If
    End Function

End Class
