
#Region " Imports "

Imports System.Runtime.InteropServices
Imports AFPSLAI_EVOLISPRIMACY.EnumPrinters
Imports AFPSLAI_EVOLISPRIMACY.Spooler
Imports System.Threading
Imports System.Reflection
Imports System.IO

#End Region

Public Class MagEncoding

#Region " Variables "

    'Private TrackWrite(0 To 2) As String
    Public TrackRead(0 To 2) As String
    Private Answers As String = ""

    Public Printer As New CPrinter '= New CPrinter
    Public AnswerCol As New Collection
    Private start As Boolean = False
    Private _drvPrt As New Hashtable
    Private _coer As Char = "h"
    Private ListViewInfo As New ListView
    Private ListViewStat As New ListView

    'Private strTracks() As String

    Private cmbPrinters As New ComboBox

    Private strErrorMsg As String
    Private IsSuccess As Boolean
    Private IsMagEncode_Success As Boolean
    Private IsPrint_Success As Boolean

    Private strSequence As String

#End Region

    'Public Sub New(ByVal strTracks() As String)
    '    Me.strTracks = strTracks

    '    cmbPrinters.Items.Clear()

    '    For Each strPrinter As [String] In System.Drawing.Printing.PrinterSettings.InstalledPrinters
    '        If strPrinter.StartsWith("Evolis") Then
    '            cmbPrinters.Items.Add(strPrinter)
    '        End If
    '    Next

    '    If InitPrinterList() Then
    '        RefreshListStat()
    '    End If

    '    InitializePrinters()
    'End Sub

    Public Sub New()
        Try
            cmbPrinters.Items.Clear()

            For Each strPrinter As [String] In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                If strPrinter.StartsWith("Evolis") Then
                    cmbPrinters.Items.Add(strPrinter)
                End If
            Next

            If InitPrinterList() Then
                RefreshListStat()
            End If

            InitializePrinters()
        Catch ex As Exception
            SharedFunction.ShowErrorMessage("New(): " & ex.Message)
        End Try
    End Sub

    Public Shared Function CheckEvolisPrinter() As Boolean
        For Each strPrinter As [String] In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            If strPrinter.StartsWith("Evolis") Then Return True
        Next

        Return False
    End Function

    Public Sub CheckSlotForCard()
        ThrowCommand("Sic")
    End Sub

    Public Sub FeedCard()
        'ThrowCommand("Si")
        ThrowCommand("Sic")
    End Sub

    Public Function GetPrinterCounter() As Integer
        ThrowCommand("Rco;c")
        Return Answers
    End Function

    Public Sub EjectCard()
        ThrowCommand("Se")
    End Sub

    Public ReadOnly Property Success() As Boolean
        Get
            Return IsSuccess
        End Get
    End Property

    Public ReadOnly Property MagEncode_Success() As Boolean
        Get
            Return IsMagEncode_Success
        End Get
    End Property

    Public ReadOnly Property Print_Success() As Boolean
        Get
            Return IsPrint_Success
        End Get
    End Property

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return strErrorMsg
        End Get
    End Property

#Region "Printer Related Functions"

    Public Sub ThrowCommand(ByVal command As String, Optional ByRef Answers_PUBLIC As String = "")
        Dim bDo As Boolean = True
        If (Me.Printer.OpenEvoPrinter()) Then
            Me.Printer.doAction(Chr(27) & "Pem;2" & Chr(13), 4000, bDo)
            Me.Printer.setCde = Chr(27) & command & Chr(13)
            If (Me.Printer.WRPrinter(bDo)) Then
                Answers = Me.Printer.getLastAnswerError
                'Me.Text = "Employee Lookup - " + Answers
            Else
                Answers = Me.Printer.analyzeAnswer
                'Me.Text = "Employee Lookup - " + Answers
            End If

            Answers_PUBLIC = Answers

            Me.Printer.doAction(Chr(27) & "Pem;0" & Chr(13), 4000, bDo)
            Me.Printer.CloseEvoPrinter()
        End If
    End Sub

    Private Sub w8(ByVal multiplier As Integer)
        Dim x As Integer = 1000 * multiplier
        System.Threading.Thread.Sleep(x)
    End Sub

    'Private Function WriteMags() As Boolean
    '    Me.Printer.mag.gsCoer = Me._coer
    '    Me.Printer.mag.SetDownloadData(TrackWrite(0), 1)
    '    Me.Printer.mag.SetDownloadData(TrackWrite(1), 2)
    '    Me.Printer.mag.SetDownloadData(TrackWrite(2), 3)
    '    If (Me.Printer.WriteTracks() = True) Then
    '        TrackRead(0) = Me.Printer.mag.gDataReadFromTrack(1)
    '        TrackRead(1) = Me.Printer.mag.gDataReadFromTrack(2)
    '        TrackRead(2) = Me.Printer.mag.gDataReadFromTrack(3)
    '        Return True
    '    Else
    '        TrackRead(0) = Me.Printer.mag.gDataReadFromTrack(1)
    '        TrackRead(1) = Me.Printer.mag.gDataReadFromTrack(2)
    '        TrackRead(2) = Me.Printer.mag.gDataReadFromTrack(3)
    '        Return False
    '        'MessageBox.Show(Me.Printer.analyzeAnswer() & Chr(13) & Chr(10) & Me.Printer.getLastAnswerError, "Fails to write magnetic tracks.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End If
    'End Function

    Private Function ReadMags() As Short
        Me.Printer.mag.gsCoer = Me._coer

        Dim response = Me.Printer.ReadTracks()

        Select Case response
            Case 0
                TrackRead(1) = Me.Printer.mag.gDataReadFromTrack(2)

                Return response
            Case Else
                Return response
        End Select
    End Function

    Private Function InitPrinterList() As Boolean
        Dim pcbNeeded As Int32 '\\ Holds the requires size of the output buffer (in bytes)
        Dim pcReturned As Int32 '\\ Holds the returned size of the output buffer 
        Dim pPrinters As IntPtr
        Dim pcbProvided As Int32 = 0
        Dim zz As Integer

        If Not EnumPrinters2(EnumPrinterFlags.PRINTER_ENUM_LOCAL, String.Empty, 2, pPrinters, 0, pcbNeeded, pcReturned) Then
            If pcbNeeded > 0 Then
                pPrinters = Marshal.AllocHGlobal(pcbNeeded)
                pcbProvided = pcbNeeded
                If Not EnumPrinters2(EnumPrinterFlags.PRINTER_ENUM_LOCAL, String.Empty, 2, pPrinters, pcbProvided, pcbNeeded, pcReturned) Then
                    'Throw New Win32Exception
                End If
            End If
        End If

        Dim ptNext As IntPtr = pPrinters

        If pcReturned > 0 Then
            While pcReturned > 0
                Dim pi2 As New PRINTER_INFO_2
                Marshal.PtrToStructure(ptNext, pi2)
                If (pi2.pDriverName.StartsWith("Evolis") = True) Then
                    Me._drvPrt.Add(pi2.pPrinterName, pi2.pDriverName)
                    cmbPrinters.Items.Add(pi2.pPrinterName)
                End If
                zz = Marshal.SizeOf(pi2)
                ptNext = New IntPtr(ptNext.ToInt32 + 84)
                pcReturned -= 1
            End While
        End If

        ''\\ Free the allocated buffer memory
        'If pPrinters.ToInt32 > 0 Then
        '    Marshal.FreeHGlobal(pPrinters)
        'End If

        'Dim piz As New PRINTER_INFO_2
        'Marshal.PtrToStructure(pPrinters, piz)

        'cmbPrinters.SelectedIndex = 0
        'Me.Printer.gsDriverName = piz.pDriverName
        'Me.Printer.gsPrinterName = piz.pPrinterName
    End Function

    Private Sub InitListStat()
        With Me.ListViewInfo
            .Clear()
            .Columns.Add("Info", CType(((Me.ListViewInfo.Width - 10) / 2), Integer), HorizontalAlignment.Left)
            .Columns.Add("Value", CType(((Me.ListViewInfo.Width - 10) / 2), Integer), HorizontalAlignment.Left)
        End With

        With Me.ListViewStat
            .Clear()
            .Columns.Add("Status", CType(((Me.ListViewStat.Width - 10) / 2), Integer), HorizontalAlignment.Left)
            .Columns.Add("Value", CType(((Me.ListViewStat.Width - 10) / 2), Integer), HorizontalAlignment.Left)
        End With
    End Sub

    Private Sub RefreshListStat()

        'Dim i As Integer, 
        Dim max As Integer
        'Dim lvi As ListViewItem
        'Dim enuId As IDictionaryEnumerator


        'InitListStat()
        If (Me.Printer.IDPrt() = True) Then
            max = Me.Printer.prtId.Count
            'If (max <> 0 And Me.Printer.csaValue.Count = max) Then
            'ListViewInfo.Items.Clear()
            'enuId = Me.Printer.prtId.GetEnumerator()
            'i = 1
            'While enuId.MoveNext
            'lvi = New ListViewItem
            'lvi.Text = enuId.Key
            'lvi.SubItems.Add(Me.Printer.csaValue(i - 1).ToString)
            'ListViewInfo.Items.Add(lvi)
            'i = i + 1
            'End While
            'End If
            If (Me.Printer.GetStatusPrt() = True) Then
                'max = Me.Printer.prtId.Count
                'If (max <> 0 And Me.Printer.csaValue.Count = max) Then
                'ListViewStat.Items.Clear()
                'enuId = Me.Printer.prtId.GetEnumerator()
                'i = 1
                'While enuId.MoveNext
                'lvi = New ListViewItem
                'lvi.Text = enuId.Key
                'lvi.SubItems.Add(Me.Printer.csaValue(i - 1).ToString)
                'ListViewStat.Items.Add(lvi)
                'i = i + 1
                'End While
                'End If
            End If
        End If
    End Sub

    Sub InitializePrinters()
        Try
            If Me.cmbPrinters.Items.Count <> 0 Then

                cmbPrinters.SelectedIndex = cmbPrinters.Items.IndexOf(My.Settings.CardPrinter)

                'Me.cmbPrinters.SelectedIndex = 0

                Dim enuId As IDictionaryEnumerator
                'Cursor = Cursors.WaitCursor
                enuId = Me._drvPrt.GetEnumerator()
                While enuId.MoveNext
                    If (enuId.Key = cmbPrinters.SelectedItem()) Then
                        If ((Me.Printer Is Nothing) = False) Then
                            Me.Printer.Dispose()
                        End If
                        'Me.Printer.Dispose()

                        If (enuId.Value.EndsWith("Dualys")) Then
                            Me.Printer = New CDualys
                        ElseIf (enuId.Value.EndsWith("Pebble")) Then
                            Me.Printer = New CPebble
                        ElseIf (enuId.Value.EndsWith("Tattoo")) Then
                            Me.Printer = New CTattoo
                        ElseIf (enuId.Value.EndsWith("Quantum")) Then
                            Me.Printer = New CQuantum
                        Else
                            Me.Printer = New CPrinter
                        End If

                        Me.Printer.gsDriverName = enuId.Value
                        Me.Printer.gsPrinterName = enuId.Key
                        'Me.Printer = New CPrinter
                        RefreshListStat()
                        Exit While
                    End If
                End While
                'Cursor = Cursors.Arrow
            End If
        Catch ex As Exception
            SharedFunction.ShowErrorMessage("InitializePrinters(): " & ex.Message)
        End Try

    End Sub

    Private Function GetResource(ByVal FileName As String, ByVal Resource As String) As Boolean

        Try

            Dim loadedAssembly As Assembly = Assembly.GetAssembly(Me.[GetType]())

            Dim outFile As New FileStream((Application.StartupPath & "\") + FileName, FileMode.OpenOrCreate)
            Dim inFile As Stream = loadedAssembly.GetManifestResourceStream("LT_Card_Encoder." + Resource)

            Dim length As Long = inFile.Length

            If length > Integer.MaxValue Then
                MessageBox.Show("Unable to write file in this version, sorry")
                outFile.Close()
                inFile.Close()
            End If

            Dim bytes As Byte() = New Byte(length - 1) {}

            inFile.Read(bytes, 0, CInt(length))
            outFile.Write(bytes, 0, CInt(length))

            inFile.Close()
            outFile.Close()

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function

    'Public Function MagEncode() As Boolean
    '    Try
    '        TrackWrite(0) = strTracks(0)
    '        TrackWrite(1) = strTracks(1)
    '        TrackWrite(2) = strTracks(2)

    '        'ThrowCommand("Si") 'Insert Card

    '        If WriteMags() = False Then 'Write Tracks
    '            ThrowCommand("Ser")

    '        Else
    '            IsMagEncode_Success = True
    '        End If
    '        'ThrowCommand("Se")

    '        Return True
    '    Catch ex As Exception

    '        ThrowCommand("Ser")
    '        Return False
    '    End Try
    'End Function

    Public Function ReadTracks() As Short
        Try
            Me.Printer.mag.gsCoer = Me._coer

            Dim response = Me.Printer.ReadTracks()

            Select Case response
                Case 0
                    TrackRead(1) = Me.Printer.mag.gDataReadFromTrack(2)

                    Return response
                Case Else
                    ThrowCommand("Ser")
                    Return response
            End Select
        Catch ex As Exception
            Main.logger.Error(String.Format("CIF {0} - {1}", Main.cfp.cif, ex.Message))
            ThrowCommand("Ser")
            Return False
        End Try
    End Function

#End Region

End Class
