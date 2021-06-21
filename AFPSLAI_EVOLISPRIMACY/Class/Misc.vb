
Public Class Misc

    Public Sub New(Optional ByVal strReaderName As String = "", Optional ByRef lstBoxLog As ListBox = Nothing)
        Me.lstBoxLog = lstBoxLog
        Me.strReaderName = strReaderName
    End Sub

    Private lstBoxLog As ListBox
    Private strReaderName As String = ""

    'Public Enum SectorID
    '    IDRefNo = 1
    '    BOSPayjur
    '    FirstName1
    '    MiddleName1
    '    LastName1
    '    Suffix
    '    BirthDate
    '    Gender
    '    Address1
    '    Address2
    '    Address3
    '    Address4
    '    Address5
    '    Address6
    '    'Address6

    '    'IDRefNo = 1
    '    'BOSPayjur
    '    'FirstName1
    '    'FirstName2
    '    'MiddleName1
    '    'MiddleName2
    '    'LastName1
    '    'LastName2
    '    'Suffix
    '    'BirthDate
    '    'Gender
    '    'Address1
    '    'Address2
    '    'Address3
    '    'Address4
    '    'Address5
    '    ''Address6
    'End Enum


#Region " PC/SC Card Initialization Process "

    Public Sub DisconnectCard()

        If connActive Then
            retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD)
        End If

        connActive = False

    End Sub

    Public Sub ConnectToCard()

        If connActive Then
            retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD)
        End If

        ' Shared Connection
        'OMNIKEY CardMan 5x21-CL 0
        'SpringCard CrazyWriter Contactless 0
        retCode = ModWinsCard.SCardConnect(hContext, strReaderName, ModWinsCard.SCARD_SHARE_SHARED, ModWinsCard.SCARD_PROTOCOL_T0 Or ModWinsCard.SCARD_PROTOCOL_T1, hCard, Protocol)

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then

            ' check if ACR128 SAM is used and use Direct Mode if SAM is not detected

        Else

            'displayOut(0, 0, "Successful connection to " & cmbReader.Text, lstBoxLog)

        End If

        connActive = True

    End Sub

    Public Function GetCardType(ByRef ATRVal() As Byte, ByRef ATRLen As Integer) As String
        Dim cardName As String = ""
        GetCardType = ""

        Dim RIDVal, sATRStr, lATRStr, tmpVal As String
        Dim indx, indx2 As Integer

        ' 4. Interpret ATR and guess card
        ' 4.1. Mifare cards using ISO 14443 Part 3 Supplemental Document
        If CInt(ATRLen) > 14 Then

            RIDVal = ""
            sATRStr = ""
            lATRStr = ""

            For indx = 7 To 11

                RIDVal = RIDVal & Format(Hex(ATRVal(indx)))

            Next indx


            For indx = 0 To 4

                'shift bit to right
                tmpVal = ATRVal(indx)
                For indx2 = 1 To 4

                    tmpVal = tmpVal / 2

                Next indx2

                If ((indx = 1) And (tmpVal = 8)) Then

                    lATRStr = lATRStr + "8X"
                    sATRStr = sATRStr + "8X"

                Else

                    If indx = 4 Then

                        lATRStr = lATRStr + Format(Hex(ATRVal(indx)))

                    Else

                        lATRStr = lATRStr + Format(Hex(ATRVal(indx)))
                        sATRStr = sATRStr + Format(Hex(ATRVal(indx)))

                    End If

                End If

            Next indx

            If RIDVal = "A00036" Then

                cardName = ""

                Select Case ATRVal(12)

                    Case 0 : cardName = "No card information"
                    Case 1 : cardName = "ISO 14443 A, Part1 Card Type"
                    Case 2 : cardName = "ISO 14443 A, Part2 Card Type"
                    Case 3 : cardName = "ISO 14443 A, Part3 Card Type"
                    Case 5 : cardName = "ISO 14443 B, Part1 Card Type"
                    Case 6 : cardName = "ISO 14443 B, Part2 Card Type"
                    Case 7 : cardName = "ISO 14443 B, Part3 Card Type"
                    Case 9 : cardName = "ISO 15693, Part1 Card Type"
                    Case 10 : cardName = "ISO 15693, Part2 Card Type"
                    Case 11 : cardName = "ISO 15693, Part3 Card Type"
                    Case 12 : cardName = "ISO 15693, Part4 Card Type"
                    Case 13 : cardName = "Contact Card (7816-10) IIC Card Type"
                    Case 14 : cardName = "Contact Card (7816-10) Extended IIC Card Type"
                    Case 15 : cardName = "0Contact Card (7816-10) 2WBP Card Type"
                    Case 16 : cardName = "Contact Card (7816-10) 3WBP Card Type"


                End Select

            End If

            If ATRVal(12) = &H3 Then

                If ATRVal(13) = &H0 Then

                    Select Case ATRVal(14)

                        Case &H1 : cardName = cardName + ": Mifare Standard 1K"
                        Case &H2 : cardName = cardName + ": Mifare Standard 4K"
                        Case &H3 : cardName = cardName + ": Mifare Ultra light"
                        Case &H4 : cardName = cardName + ": SLE55R_XXXX"
                        Case &H6 : cardName = cardName + ": SR176"
                        Case &H7 : cardName = cardName + ": SRI X4K"
                        Case &H8 : cardName = cardName + ": AT88RF020"
                        Case &H9 : cardName = cardName + ": AT88SC0204CRF"
                        Case &HA : cardName = cardName + ": AT88SC0808CRF"
                        Case &HB : cardName = cardName + ": AT88SC1616CRF"
                        Case &HC : cardName = cardName + ": AT88SC3216CRF"
                        Case &HD : cardName = cardName + ": AT88SC6416CRF"
                        Case &HE : cardName = cardName + ": SRF55V10P"
                        Case &HF : cardName = cardName + ": SRF55V02P"
                        Case &H10 : cardName = cardName + ": SRF55V10S"
                        Case &H11 : cardName = cardName + ": SRF55V02S"
                        Case &H12 : cardName = cardName + ": TAG IT"
                        Case &H13 : cardName = cardName + ": LRI512"
                        Case &H14 : cardName = cardName + ": ICODESLI"
                        Case &H15 : cardName = cardName + ": TEMPSENS"
                        Case &H16 : cardName = cardName + ": I.CODE1"
                        Case &H17 : cardName = cardName + ": PicoPass 2K"
                        Case &H18 : cardName = cardName + ": PicoPass 2KS"
                        Case &H19 : cardName = cardName + ": PicoPass 16K"
                        Case &H1A : cardName = cardName + ": PicoPass 16KS"
                        Case &H1B : cardName = cardName + ": PicoPass 16K(8x2)"
                        Case &H1C : cardName = cardName + ": PicoPass 16KS(8x2)"

                        Case &H1D : cardName = cardName + ": PicoPass 32KS(16+16)"
                        Case &H1E : cardName = cardName + ": PicoPass 32KS(16+8x2)"
                        Case &H1F : cardName = cardName + ": PicoPass 32KS(8x2+16)"
                        Case &H20 : cardName = cardName + ": PicoPass 32KS(8x2+8x2)"
                        Case &H21 : cardName = cardName + ": LRI64"
                        Case &H22 : cardName = cardName + ": I.CODE UID"
                        Case &H23 : cardName = cardName + ": I.CODE EPC"
                        Case &H24 : cardName = cardName + ": LRI12"
                        Case &H25 : cardName = cardName + ": LRI128"
                        Case &H26 : cardName = cardName + ": Mifare Mini"

                    End Select

                Else
                    If ATRVal(13) = &HFF Then
                        Select Case ATRVal(14)
                            Case &H9
                                cardName = cardName & ": Mifare Mini"
                        End Select
                    End If
                End If

                displayOut(3, 0, cardName & " is detected.", lstBoxLog)

                Return cardName

            End If

        End If

        '4.2. Mifare DESFire card using ISO 14443 Part 4
        If CInt(ATRLen) = 6 Then

            RIDVal = ""

            For indx = 4 To 9
                RIDVal = RIDVal & Format(Hex(RecvBuff(indx)), "00")
            Next indx

            displayOut(3, 0, "Mifare DESFire is detected.", lstBoxLog)

            Return "Mifare DESFire"

        End If

        ''4.3. Other cards using ISO 14443 Part 4
        'If CInt(ATRLen) = 17 Then

        '    RIDVal = ""

        '    For indx = 4 To 15
        '        RIDVal = RIDVal & Format(Hex(RecvBuff(indx)), "00")
        '    Next indx

        '    If RIDVal = "50122345561253544E3381C3" Then
        '        displayOut(3, 0, "ST19XRC8E is detected.", lstBoxLog)
        '    End If

        'End If

        ''4.4. other cards using ISO 14443 Type A or B
        'If lATRStr = "3B8X800150" Then
        '    displayOut(3, 0, "ISO 14443B is detected.", lstBoxLog)
        'Else

        '    If sATRStr = "3B8X8001" Then
        '        displayOut(3, 0, "ISO 14443A is detected.", lstBoxLog)
        '    End If

        'End If

    End Function

    Public Function GetATR(ByRef CardType As String) As String

        Dim ReaderLen, ATRLen As Integer
        Dim dwState, dwActProtocol As Long
        Dim ATRVal(256) As Byte

        Dim tmpWord As Long
        Dim tmpStr As String
        Dim indx As Integer

        displayOut(0, 0, "Invoke Card Status", lstBoxLog)
        tmpWord = 32
        ATRLen = tmpWord

        retCode = ModWinsCard.SCardStatus(hCard, My.Settings.PCSCReader, ReaderLen, dwState, dwActProtocol, ATRVal(0), ATRLen)

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then

            displayOut(1, retCode, "", lstBoxLog)

            End

        Else

            tmpStr = "ATR Length : " + ATRLen.ToString
            displayOut(3, 0, tmpStr, lstBoxLog)

            tmpStr = ""

            For indx = 0 To ATRLen - 1

                tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(ATRVal(indx)), 2) + " "

            Next indx

            GetATR = tmpStr

            displayOut(3, 0, "ATR Value : " + tmpStr, lstBoxLog)

        End If

        tmpStr = "Active Protocol"

        Select Case dwActProtocol

            Case 1
                tmpStr = tmpStr + "T=0"
            Case 2
                tmpStr = tmpStr + "T=1"

            Case Else
                tmpStr = "No protocol is defined."
        End Select

        displayOut(3, 0, tmpStr, lstBoxLog)

        CardType = GetCardType(ATRVal, ATRLen)

    End Function

    Public Function GetUID() As String

        Dim tmpStr As String = ""
        Dim indx As Integer


        validATS = False

        Call ClearBuffers()

        SendBuff(0) = &HFF                              ' CLA
        SendBuff(1) = &HCA                              ' INS
        SendBuff(2) = &H0                               ' P1 : Other cards
        SendBuff(3) = &H0                               ' P2
        SendBuff(4) = &H0                               ' Le : Full Length

        SendLen = SendBuff(4) + 5
        RecvLen = &HFF

        retCode = SendAPDUandDisplay(3, lstBoxLog)

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
            Return "FAILED"
        End If

        If validATS Then

            For indx = 0 To (RecvLen - 3)
                tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "
            Next indx

            displayOut(3, 0, "UID:" + tmpStr.Trim, lstBoxLog)

        End If

        Return tmpStr

    End Function

#End Region

    Public Sub InitializeReaderList()

        Dim sReaderList As String = ""
        Dim ReaderCount As Integer
        Dim ctr As Integer

        For ctr = 0 To 255
            sReaderList = sReaderList + vbNullChar
        Next

        ReaderCount = 255

        retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, hContext)

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
            displayOut(1, retCode, "", lstBoxLog)
            Exit Sub
        End If

        retCode = ModWinsCard.SCardListReaders(hContext, "", sReaderList, ReaderCount)

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
            displayOut(1, retCode, "", lstBoxLog)
            Exit Sub

        End If

        'LoadListToControl(cmbReader, sReaderList)
        'cmbReader.SelectedIndex = 0

    End Sub

    Private Function ExcelConStr(ByVal strExcelPath As String) As String
        Return "Provider=Microsoft.Jet.OLEDB.4.0;Excel 8.0; Extended Properties=HDR=Yes; IMEX=1;Data Source=" + strExcelPath + ""
    End Function

    Public Sub LoadSheets(ByVal strExcelPath As String, ByVal cboSheet As ComboBox, Optional ByRef arrList As ArrayList = Nothing)
        Try
            Dim con As New System.Data.OleDb.OleDbConnection(ExcelConStr(strExcelPath))
            con.Open()

            Dim dtSheets As DataTable = con.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, Nothing)
            'Dim dtRowHeader As DataTable = con.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Columns, Nothing)
            con.Close()

            For Each rw As DataRow In dtSheets.Rows
                cboSheet.Items.Add(rw("TABLE_NAME"))
            Next

            'If Not arrList Is Nothing Then
            '    For Each rw2 As DataRow In dtRowHeader.Rows
            '        arrList.Add(rw2("COLUMN_NAME"))
            '    Next
            'End If

            If cboSheet.Items.Count > 0 Then cboSheet.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed to load sheets...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Public Sub LoadExcelFile(ByVal strExcelPath As String, ByVal strExcelSheet As String, ByRef dt As DataTable)
        Try
            Dim ds As New DataSet()
            Dim con As New System.Data.OleDb.OleDbConnection(ExcelConStr(strExcelPath))
            Dim cmd As System.Data.OleDb.OleDbCommand
            'cmd = New System.Data.OleDb.OleDbCommand("SELECT * FROM [" + strExcelSheet + "$] WHERE [last name] <> ''", con)
            cmd = New System.Data.OleDb.OleDbCommand("SELECT * FROM [" + strExcelSheet + "]", con)
            cmd.CommandType = CommandType.Text

            con.Open()

            Dim da As New System.Data.OleDb.OleDbDataAdapter(cmd)
            da.Fill(ds, "Result")

            dt = ds.Tables(0)
            con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed to load excel file...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LoadFile(ByRef txtFile As TextBox, Optional ByVal intFileType As Short = 0)
        Dim openDLG As New OpenFileDialog

        openDLG.InitialDirectory = Application.StartupPath
        If intFileType = 0 Then 'excel
            openDLG.Filter = "Microsoft Excel 2003 | *.xls; *.xlsx"
        ElseIf intFileType = 1 Then 'notepad
            openDLG.Filter = "Text Files | *.txt"
        End If


        If openDLG.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFile.Text = openDLG.FileName
        End If

        openDLG.Dispose()
    End Sub

End Class
