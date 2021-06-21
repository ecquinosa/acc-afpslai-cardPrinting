Public Class FormatCard

    Public Sub New(ByVal strReaderName As String, ByRef lstBoxLog As ListBox, ByRef Label_Status As TextBox)
        Me.lstBoxLog = lstBoxLog
        Me.strReaderName = strReaderName
        Me.Label_Status = Label_Status

        InitializeReaderList()

        'connect reader
        cmdConnect.Text = "Connect"
        Connect_Disconnect()
        InitializeSettings()
    End Sub

#Region " Private Declaration "

    Private strCardATR As String = ""
    Private strCardType As String = ""
    Private strCardUID As String = ""
    Private lstBoxLog As ListBox
    Private Label_Status As TextBox
    Private strReaderName As String = ""

    Private cmdConnect As New Button
    Private cboSectorRead As New ComboBox
    Private cboSectorWrite As New ComboBox
    Private cboSectorTrailer As New ComboBox
    Private cboBlockRead As New ComboBox
    Private cboBlockWrite As New ComboBox
    Private checkDefaultAB As New CheckBox

    Private KeyTypeWriteSector As String = ""
    Private KeyTypeWriteSector_DefaultKeyTypeAA As String = "Default Key Type AA"
    Private KeyTypeWriteSector_DefaultKeyTypeBB As String = "Default Key Type BB"
    Private KeyTypeWriteSector_DefaultKeyTypeFF As String = "Default Key Type FF"
    Private KeyTypeWriteSector_KeyA As String = "Key A"
    Private KeyTypeWriteSector_KeyB As String = "Key B"

    Private k1R As New TextBox
    Private k2R As New TextBox
    Private k3R As New TextBox
    Private k4R As New TextBox
    Private k5R As New TextBox
    Private k6R As New TextBox

    Private k1W As New TextBox
    Private k2W As New TextBox
    Private k3W As New TextBox
    Private k4W As New TextBox
    Private k5W As New TextBox
    Private k6W As New TextBox

    Private k1WS As New TextBox
    Private k2WS As New TextBox
    Private k3WS As New TextBox
    Private k4WS As New TextBox
    Private k5WS As New TextBox
    Private k6WS As New TextBox

    Private a1 As New TextBox
    Private a2 As New TextBox
    Private a3 As New TextBox
    Private a4 As New TextBox
    Private a5 As New TextBox
    Private a6 As New TextBox

    Private ab1 As New TextBox
    Private ab2 As New TextBox
    Private ab3 As New TextBox
    Private ab4 As New TextBox
    Private ab5 As New TextBox
    Private ab6 As New TextBox

    Private b1 As New TextBox
    Private b2 As New TextBox
    Private b3 As New TextBox
    Private b4 As New TextBox
    Private b5 As New TextBox
    Private b6 As New TextBox

#End Region

#Region " PC/SC Card Initialization Process "

    Public ReadOnly Property CardATR() As String
        Get
            Return strCardATR
        End Get
    End Property

    Public ReadOnly Property CardType() As String
        Get
            Return strCardType
        End Get
    End Property

    Public ReadOnly Property CardUID() As String
        Get
            Return strCardUID
        End Get
    End Property

    Sub ClearCardInfo()
        strCardATR = ""
        strCardType = ""
        strCardUID = ""
    End Sub

    Sub InitializeReaderList()

        Dim sReaderList As String = ""
        Dim ReaderCount As Integer
        Dim ctr As Integer

        If cmdConnect.Text = "Disconnect" Then cmdConnect.PerformClick()

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

    Sub DisconnectCard(ByVal ReaderName As String)

        If connActive Then
            retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD)
        End If

        connActive = False

    End Sub

    Sub ConnectToCard(ByVal ReaderName As String)

        If connActive Then
            retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD)
        End If

        ' Shared Connection
        retCode = ModWinsCard.SCardConnect(hContext, strReaderName, ModWinsCard.SCARD_SHARE_SHARED, ModWinsCard.SCARD_PROTOCOL_T0 Or ModWinsCard.SCARD_PROTOCOL_T1, hCard, Protocol)

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then

            ' check if ACR128 SAM is used and use Direct Mode if SAM is not detected
            If InStr(strReaderName, "ACR128U SAM") > 0 Then

                '1. Direct Connection
                retCode = ModWinsCard.SCardConnect(hContext, strReaderName, ModWinsCard.SCARD_SHARE_DIRECT, 0, hCard, Protocol)

                If retCode <> ModWinsCard.SCARD_S_SUCCESS Then

                    displayOut(1, retCode, "", lstBoxLog)
                    connActive = False

                    Exit Sub

                Else

                    displayOut(0, 0, "Successful connection to " & strReaderName, lstBoxLog)

                End If

            Else

                displayOut(1, retCode, "", lstBoxLog)
                connActive = False
                Exit Sub

            End If

        Else

            displayOut(0, 0, "Successful connection to " & strReaderName, lstBoxLog)

        End If

        connActive = True

    End Sub

    Private Function GetCardType(ByRef ATRVal() As Byte, ByRef ATRLen As Integer) As String

        GetCardType = ""

        Dim RIDVal, cardName, sATRStr, lATRStr, tmpVal As String
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

    'Function GetATR(ByRef CardType As String) As String
    Private Function GetATR(ByRef CardType As String) As String

        Dim ReaderLen, ATRLen As Integer
        Dim dwState, dwActProtocol As Long
        Dim ATRVal(256) As Byte

        Dim tmpWord As Long
        Dim tmpStr As String
        Dim indx As Integer

        displayOut(0, 0, "Invoke Card Status", lstBoxLog)
        tmpWord = 32
        ATRLen = tmpWord

        retCode = ModWinsCard.SCardStatus(hCard, strReaderName, ReaderLen, dwState, dwActProtocol, ATRVal(0), ATRLen)

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

    Function GetUID() As String

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

#Region " Functions and Sub Routines "

    Enum KeyType
        DefaultKeyAA
        DefaultKeyBB
        DefaultKeyFF
        KeyA
        KeyB
    End Enum

    Private Enum MifareTransaction
        mRead
        mWrite
        mSectorTrailer
    End Enum

    Private Function CheckKeyIfValid(ByVal TransType As MifareTransaction) As Boolean

        Select Case TransType

            Case MifareTransaction.mRead

                If k1R.Text.Trim = "" Then Return False
                If k2R.Text.Trim = "" Then Return False
                If k3R.Text.Trim = "" Then Return False
                If k4R.Text.Trim = "" Then Return False
                If k5R.Text.Trim = "" Then Return False
                If k6R.Text.Trim = "" Then Return False

            Case MifareTransaction.mWrite

                If k1W.Text.Trim = "" Then Return False
                If k2W.Text.Trim = "" Then Return False
                If k3W.Text.Trim = "" Then Return False
                If k4W.Text.Trim = "" Then Return False
                If k5W.Text.Trim = "" Then Return False
                If k6W.Text.Trim = "" Then Return False

            Case MifareTransaction.mSectorTrailer

                If k1WS.Text.Trim = "" Then Return False
                If k2WS.Text.Trim = "" Then Return False
                If k3WS.Text.Trim = "" Then Return False
                If k4WS.Text.Trim = "" Then Return False
                If k5WS.Text.Trim = "" Then Return False
                If k6WS.Text.Trim = "" Then Return False

        End Select

        Return True

    End Function

    Function VerifySectorTrailer() As Boolean

        If a1.Text.Trim = "" Then Return False
        If a2.Text.Trim = "" Then Return False
        If a3.Text.Trim = "" Then Return False
        If a4.Text.Trim = "" Then Return False
        If a5.Text.Trim = "" Then Return False
        If a6.Text.Trim = "" Then Return False

        If ab1.Text.Trim = "" Then Return False
        If ab2.Text.Trim = "" Then Return False
        If ab3.Text.Trim = "" Then Return False
        If ab4.Text.Trim = "" Then Return False

        If b1.Text.Trim = "" Then Return False
        If b2.Text.Trim = "" Then Return False
        If b3.Text.Trim = "" Then Return False
        If b4.Text.Trim = "" Then Return False
        If b5.Text.Trim = "" Then Return False
        If b6.Text.Trim = "" Then Return False

        Return True

    End Function

    Function DetermineKeyType(ByVal kType As String) As FormatCard.KeyType
        Select Case kType
            Case "Default Key Type AA" : Return KeyType.DefaultKeyAA
            Case "Default Key Type BB" : Return KeyType.DefaultKeyBB
            Case "Default Key Type FF" : Return KeyType.DefaultKeyFF
            Case "Key A" : Return KeyType.KeyA
            Case "Key B" : Return KeyType.KeyB
            Case Else : Return KeyType.DefaultKeyFF
        End Select
    End Function

    Sub ClearAll()

        cboSectorRead.Items.Clear()
        cboSectorWrite.Items.Clear()
        cboBlockRead.Items.Clear()
        cboBlockWrite.Items.Clear()

        'groupMifareDESFire.Enabled = False
        'groupMifareStandard.Enabled = False

    End Sub

    Sub DetermineTransaction(ByVal CardType As String)

        If CardType = "Mifare DESFire" Then
            'groupMifareDESFire.Enabled = True
            'groupMifareStandard.Enabled = False
        Else
            If Not CardType = "" Then
                Try
                    Dim tempStr() As String = CardType.Replace(" ", "").Split(":")

                    cboSectorRead.Items.Clear()
                    cboSectorWrite.Items.Clear()
                    cboSectorTrailer.Items.Clear()

                    Dim ctr As Integer = 0

                    If tempStr(1) = "MifareStandard1K" Then
                        ctr = 15
                    ElseIf tempStr(1) = "MifareStandard4K" Then
                        ctr = 39
                    Else
                        ctr = 0
                    End If

                    For i As Integer = 0 To ctr
                        cboSectorRead.Items.Add(i.ToString)
                        cboSectorWrite.Items.Add(i.ToString)
                        cboSectorTrailer.Items.Add(i.ToString)
                    Next

                    cboSectorRead.Text = "0"
                    cboSectorWrite.Text = "0"
                    cboSectorTrailer.Text = "0"

                    'groupMifareStandard.Enabled = True
                    'groupMifareDESFire.Enabled = False

                Catch ex As Exception

                    'groupMifareStandard.Enabled = False
                    ' groupMifareDESFire.Enabled = False

                End Try
            End If
        End If

    End Sub

    Private Sub ControlBlocks(ByVal SectorValue As Integer, ByRef ComboBoxBlocks As ComboBox)

        Dim ctr As Integer = 0

        ComboBoxBlocks.Items.Clear()

        If SectorValue >= 32 Then
            ctr = 14
        Else
            ctr = 2
        End If

        For i As Integer = 0 To ctr
            ComboBoxBlocks.Items.Add(i.ToString)
        Next

        ComboBoxBlocks.Text = "0"

    End Sub

    Private Sub WriteSectorBlock(ByVal Sector As Integer, ByVal Block As Integer, ByVal Data As String, ByVal CheckHex As Boolean, ByVal KeyType As String, ByVal NoMessage As Boolean)

        Dim KeyTypeCommand As String = ""
        Dim LoadKeyCommand As String = ""
        Dim AuthenticateKeyCommand As String = ""
        Dim WriteCommand As String = ""

        If Not CheckHex Then
            Data = Str2Hex(Spacer(Data, 16)).Replace(" ", "")
        End If

        Dim KeyString As String = k1WS.Text.Trim + k2WS.Text.Trim + k3WS.Text.Trim + _
                                  k4WS.Text.Trim + k5WS.Text.Trim + k6WS.Text.Trim

        Select Case DetermineKeyType(KeyType)

            Case FormatCard.KeyType.DefaultKeyAA

                KeyTypeCommand = "60"
                KeyString = "A0A1A2A3A4A5"

            Case FormatCard.KeyType.DefaultKeyBB

                KeyTypeCommand = "61"
                KeyString = "B0B1B2B3B4B5"

            Case FormatCard.KeyType.DefaultKeyFF

                KeyTypeCommand = "60"
                KeyString = "FFFFFFFFFFFF"

            Case FormatCard.KeyType.KeyA

                KeyTypeCommand = "60"

            Case FormatCard.KeyType.KeyB

                KeyTypeCommand = "61"

        End Select

        LoadKeyCommand = "FF82200006" + KeyString

        AuthenticateKeyCommand = "FF8800" + ExactBlock(Sector, Block, False).ToString("X2") + KeyTypeCommand + "00"

        WriteCommand = "FFD600" + ExactBlock(Sector, Block, False).ToString("X2") + "10" + Data

        SendAPDU(LoadKeyCommand, lstBoxLog)

        SendAPDU(AuthenticateKeyCommand, lstBoxLog)

        If Not NoMessage Then
            If SmartCardErrorCode() <> "Success" Then

                MessageBox.Show("Sector " + cboSectorRead.Text.Trim + ", Block " + cboBlockRead.Text.Trim + _
                                " " + SmartCardErrorCode() + ".", "PC/SC Demo", _
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Exit Sub

            End If
        End If

        SendAPDU(WriteCommand, lstBoxLog)

        If CheckHex Then
            Data = GetSmartCardResponse4.Replace(" ", "")
        Else
            Data = Hex2Str(GetSmartCardResponse4.Replace(" ", ""))
        End If

        If Not NoMessage Then
            If SmartCardErrorCode() = "Success" Then
                MessageBox.Show("Sector " + cboSectorRead.Text.Trim + ", Block " + cboBlockRead.Text.Trim + _
                    " was successfully written.", "PC/SC Demo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Sector " + cboSectorRead.Text.Trim + ", Block " + cboBlockRead.Text.Trim + _
                    " " + SmartCardErrorCode() + ".", "PC/SC Demo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

    End Sub

    Private Sub WriteBlock(ByVal Sector As Integer, ByVal Block As Integer, ByVal Data As String, ByVal CheckHex As Boolean, ByVal KeyType As String)

        Dim KeyTypeCommand As String = ""
        Dim LoadKeyCommand As String = ""
        Dim AuthenticateKeyCommand As String = ""
        Dim WriteCommand As String = ""

        If Not CheckHex Then
            Data = Str2Hex(Spacer(Data, 16)).Replace(" ", "")
        End If

        Dim KeyString As String = k1W.Text.Trim + k2W.Text.Trim + k3W.Text.Trim + _
                                  k4W.Text.Trim + k5W.Text.Trim + k6W.Text.Trim

        Select Case DetermineKeyType(KeyType)

            Case FormatCard.KeyType.DefaultKeyAA

                KeyTypeCommand = "60"
                KeyString = "A0A1A2A3A4A5"

            Case FormatCard.KeyType.DefaultKeyBB

                KeyTypeCommand = "61"
                KeyString = "B0B1B2B3B4B5"

            Case FormatCard.KeyType.DefaultKeyFF

                KeyTypeCommand = "60"
                KeyString = "FFFFFFFFFFFF"

            Case FormatCard.KeyType.KeyA

                KeyTypeCommand = "60"

            Case FormatCard.KeyType.KeyB

                KeyTypeCommand = "61"

        End Select

        LoadKeyCommand = "FF82200006" + KeyString

        AuthenticateKeyCommand = "FF8800" + ExactBlock(Sector, Block, False).ToString("X2") + KeyTypeCommand + "00"

        WriteCommand = "FFD600" + ExactBlock(Sector, Block, False).ToString("X2") + "10" + Data

        SendAPDU(LoadKeyCommand, lstBoxLog)

        SendAPDU(AuthenticateKeyCommand, lstBoxLog)

        If SmartCardErrorCode() <> "Success" Then

            MessageBox.Show("Sector " + cboSectorRead.Text.Trim + ", Block " + cboBlockRead.Text.Trim + _
                            " " + SmartCardErrorCode() + ".", "PC/SC Demo", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Exit Sub

        End If

        SendAPDU(WriteCommand, lstBoxLog)

        If CheckHex Then
            Data = GetSmartCardResponse4.Replace(" ", "")
        Else
            Data = Hex2Str(GetSmartCardResponse4.Replace(" ", ""))
        End If


        If SmartCardErrorCode() = "Success" Then
            MessageBox.Show("Sector " + cboSectorRead.Text.Trim + ", Block " + cboBlockRead.Text.Trim + _
                " was successfully written.", "PC/SC Demo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Sector " + cboSectorRead.Text.Trim + ", Block " + cboBlockRead.Text.Trim + _
                " " + SmartCardErrorCode() + ".", "PC/SC Demo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub ReadBlock(ByVal Sector As Integer, ByVal Block As Integer, ByRef Data As String, ByVal CheckHex As Boolean, ByVal KeyType As String)

        Dim KeyTypeCommand As String = ""
        Dim LoadKeyCommand As String = ""
        Dim AuthenticateKeyCommand As String = ""
        Dim ReadCommand As String = ""

        Dim KeyString As String = k1R.Text.Trim + k2R.Text.Trim + k3R.Text.Trim + _
                                    k4R.Text.Trim + k5R.Text.Trim + k6R.Text.Trim

        Select Case DetermineKeyType(KeyType)

            Case FormatCard.KeyType.DefaultKeyAA

                KeyTypeCommand = "60"
                KeyString = "A0A1A2A3A4A5"

            Case FormatCard.KeyType.DefaultKeyBB

                KeyTypeCommand = "61"
                KeyString = "B0B1B2B3B4B5"

            Case FormatCard.KeyType.DefaultKeyFF

                KeyTypeCommand = "60"
                KeyString = "FFFFFFFFFFFF"

            Case FormatCard.KeyType.KeyA

                KeyTypeCommand = "60"

            Case FormatCard.KeyType.KeyB

                KeyTypeCommand = "61"

        End Select

        LoadKeyCommand = "FF82200006" + KeyString

        AuthenticateKeyCommand = "FF8800" + ExactBlock(Sector, Block, False).ToString("X2") + KeyTypeCommand + "00"

        ReadCommand = "FFB000" + ExactBlock(Sector, Block, False).ToString("X2") + "10"

        Console.WriteLine(LoadKeyCommand)
        Console.WriteLine(AuthenticateKeyCommand)
        Console.WriteLine(ReadCommand)

        SendAPDU(LoadKeyCommand, lstBoxLog)

        SendAPDU(AuthenticateKeyCommand, lstBoxLog)

        If SmartCardErrorCode() <> "Success" Then

            MessageBox.Show("Sector " + cboSectorRead.Text.Trim + ", Block " + cboBlockRead.Text.Trim + _
                            " " + SmartCardErrorCode() + ".", "PC/SC Demo", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Exit Sub

        End If

        SendAPDU(ReadCommand, lstBoxLog)

        If CheckHex Then
            Data = GetSmartCardResponse4.Replace(" ", "")
        Else
            Data = Hex2Str(GetSmartCardResponse4.Replace(" ", ""))
        End If


        If SmartCardErrorCode() = "Success" Then
            MessageBox.Show("Sector " + cboSectorRead.Text.Trim + ", Block " + cboBlockRead.Text.Trim + _
                " was successfully read.", "PC/SC Demo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Sector " + cboSectorRead.Text.Trim + ", Block " + cboBlockRead.Text.Trim + _
                " " + SmartCardErrorCode() + ".", "PC/SC Demo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    'Private Sub KeyHexOnly_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    'Handles k1R.KeyDown, k2R.KeyDown, k3R.KeyDown, k4R.KeyDown, k5R.KeyDown, k6R.KeyDown, _
    '        k1W.KeyDown, k2W.KeyDown, k3W.KeyDown, k4W.KeyDown, k5W.KeyDown, k6W.KeyDown, _
    '        k1WS.KeyDown, k2WS.KeyDown, k3WS.KeyDown, k4WS.KeyDown, k5WS.KeyDown, k6WS.KeyDown, _
    '        a1.KeyDown, a2.KeyDown, a3.KeyDown, a4.KeyDown, a5.KeyDown, a6.KeyDown, _
    '        ab1.KeyDown, ab2.KeyDown, ab3.KeyDown, ab4.KeyDown, _
    '        b1.KeyDown, b2.KeyDown, b3.KeyDown, b4.KeyDown, b5.KeyDown, b6.KeyDown

    '    Dim kSuppress As Boolean = True

    '    If e.KeyCode = Keys.A Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.B Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.C Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.D Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.E Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.F Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.Back Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.Delete Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.D0 Or e.KeyCode = Keys.NumPad0 Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1 Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2 Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.D3 Or e.KeyCode = Keys.NumPad3 Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.D4 Or e.KeyCode = Keys.NumPad4 Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.D5 Or e.KeyCode = Keys.NumPad5 Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.D6 Or e.KeyCode = Keys.NumPad6 Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.D7 Or e.KeyCode = Keys.NumPad7 Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.D8 Or e.KeyCode = Keys.NumPad8 Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.D9 Or e.KeyCode = Keys.NumPad9 Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
    '        kSuppress = False
    '    ElseIf e.KeyCode = Keys.Tab Then
    '        kSuppress = False
    '    Else
    '        e.SuppressKeyPress = True
    '        Beep()
    '    End If

    'End Sub


#End Region

    Private Sub Connect_Disconnect()

        ClearCardInfo()

        'If MessageBox.Show(cmdConnect.Text + " now?", "PC/SC Demo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        If cmdConnect.Text = "Connect" Then

            If strReaderName = "" Then
                MessageBox.Show("No Readers Found!", "PCSC", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ConnectToCard(strReaderName)

            If connActive Then
                strCardATR = GetATR(strCardType)
                strCardUID = GetUID()
                'cmbReader.Enabled = False
            End If

            cmdConnect.Text = "Disconnect"

            DetermineTransaction(strCardType)

        Else

            DisconnectCard(strReaderName)

            'cmbReader.Enabled = True

            cmdConnect.Text = "Connect"

            ClearAll()

        End If
    End Sub

    Private Sub DefaultAccessBits()

        If checkDefaultAB.Checked Then
            ab1.Text = "FF"
            ab2.Text = "07"
            ab3.Text = "80"
            ab4.Text = "69"
        Else
            ab1.Text = ""
            ab2.Text = ""
            ab3.Text = ""
            ab4.Text = ""
        End If

    End Sub

    Private Sub InitializeSettings()
        'set settings for lbp taguig
        Label_Status.Text = "Initializing settings..."
        Application.DoEvents()

        Dim DefaultKey As String = "FFFFFFFFFFFF"
        checkDefaultAB.Checked = True
        DefaultAccessBits()
        KeyTypeWriteSector = KeyTypeWriteSector_DefaultKeyTypeFF

        'enter default key
        k1WS.Text = DefaultKey.Substring(0, 2)
        k2WS.Text = DefaultKey.Substring(2, 2)
        k3WS.Text = DefaultKey.Substring(4, 2)
        k4WS.Text = DefaultKey.Substring(6, 2)
        k5WS.Text = DefaultKey.Substring(8, 2)
        k6WS.Text = DefaultKey.Substring(10, 2)

        'set new key
        a1.Text = WriteToCard.CARD_KEY.Substring(0, 2)
        a2.Text = WriteToCard.CARD_KEY.Substring(2, 2)
        a3.Text = WriteToCard.CARD_KEY.Substring(4, 2)
        a4.Text = WriteToCard.CARD_KEY.Substring(6, 2)
        a5.Text = WriteToCard.CARD_KEY.Substring(8, 2)
        a6.Text = WriteToCard.CARD_KEY.Substring(10, 2)
        b1.Text = WriteToCard.CARD_KEY.Substring(0, 2)
        b2.Text = WriteToCard.CARD_KEY.Substring(2, 2)
        b3.Text = WriteToCard.CARD_KEY.Substring(4, 2)
        b4.Text = WriteToCard.CARD_KEY.Substring(6, 2)
        b5.Text = WriteToCard.CARD_KEY.Substring(8, 2)
        b6.Text = WriteToCard.CARD_KEY.Substring(10, 2)
    End Sub

    Public Function FormatAllSectors() As Boolean
        Try
            'If MessageBox.Show("Proceed Formating All Sectors Trailers?", "PC/SC Demo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

            If KeyTypeWriteSector = "" Then
                MessageBox.Show("Please select a key type!", "PC/SC Demo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            If KeyTypeWriteSector = "Key A" Or KeyTypeWriteSector = "Key B" Then
                If Not CheckKeyIfValid(MifareTransaction.mSectorTrailer) Then
                    MessageBox.Show("Please enter a valid key!", "PC/SC Demo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If

            If Not VerifySectorTrailer() Then
                MessageBox.Show("Please complete Sector Trailer Data!", "PC/SC Demo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            Dim sData As String = a1.Text.Trim + a2.Text.Trim + a3.Text.Trim + a4.Text.Trim + a5.Text.Trim + a6.Text.Trim + _
                                  ab1.Text.Trim + ab2.Text.Trim + ab3.Text.Trim + ab4.Text.Trim + _
                                  b1.Text.Trim + b2.Text.Trim + b3.Text.Trim + b4.Text.Trim + b5.Text.Trim + b6.Text.Trim

            For i As Integer = 0 To cboSectorTrailer.Items.Count - 1
                WriteSectorBlock(i, IIf(CInt(i) >= 32, 15, 3), sData, True, KeyTypeWriteSector, True)

                Label_Status.Text = "Initializing Sector " & i.ToString & " Block " & IIf(CInt(i) >= 32, 15, 3).ToString
                Application.DoEvents()
                'WriteSectorBlock(i, 0, sData, True, KeyTypeWriteSector, True)
            Next

            Label_Status.Text = "Initialization complete"
            Application.DoEvents()

            Return True
        Catch ex As Exception
            MessageBox.Show("Failed to format card" & Environment.NewLine & ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

End Class
