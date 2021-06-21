
Public Structure WriteToCard

    Public Shared ReadOnly CARD_KEY As String = "AFEFBFFFDFBF"
    Public Shared ReadOnly DATA_KEY As String = "aCCAfpsL@iE"

    Public Enum AFPSLAI_Sector
        CIF = 1
        FIRSTNAME
        MIDDLENAME
        LASTNAME
        SUFFIX
        DOB
        MEMBERSHIPDATE
        MEMBERSHIPSTATUS
        GENDER
        MEMBERSHIPTYPE
        IDNUMBER
        DATEISSUED
        BRANCHISSUED
        ASSOCIATETYPE
        CIF_PRINCIPAL
    End Enum


    Public Sub New(ByRef lstBoxLog As ListBox, ByRef Label_Status As TextBox, ByVal strData() As String)
        Me.lstBoxLog = lstBoxLog
        Me.Label_Status = Label_Status

        Dim ed As New AllcardEncryptDecrypt.EncryptDecrypt(DATA_KEY)
        CIF = ed.TripleDesEncryptText(strData(0).ToUpper.Trim)
        FIRSTNAME = ed.TripleDesEncryptText(strData(1).ToUpper.Trim)
        MIDDLENAME = ed.TripleDesEncryptText(strData(2).ToUpper.Trim)
        LASTNAME = ed.TripleDesEncryptText(strData(3).ToUpper.Trim)
        SUFFIX = ed.TripleDesEncryptText(strData(4).ToUpper.Trim)
        DOB = ed.TripleDesEncryptText(strData(5).ToUpper.Trim)
        MEMBERSHIPDATE = ed.TripleDesEncryptText(strData(6).ToUpper.Trim)
        MEMBERSHIPSTATUS = ed.TripleDesEncryptText(strData(7).ToUpper.Trim)
        GENDER = ed.TripleDesEncryptText(strData(8).ToUpper.Trim)
        MEMBERSHIPTYPE = ed.TripleDesEncryptText(strData(9).ToUpper.Trim)
        IDNUMBER_PlainText = strData(10).ToUpper.Trim
        DATEISSUED = ed.TripleDesEncryptText(strData(11).ToUpper.Trim)
        BRANCHISSUED = ed.TripleDesEncryptText(strData(12).ToUpper.Trim)
        ASSOCIATETYPE = ed.TripleDesEncryptText(strData(13).ToUpper.Trim)
        CIF_PRINCIPAL = ed.TripleDesEncryptText(strData(14).ToUpper.Trim)
        ed = Nothing

        Write()
        'Writev2()
    End Sub

    Private Function EncryptValue(ByVal data As String) As String
        Dim ed As New AllcardEncryptDecrypt.EncryptDecrypt(DATA_KEY)
        Dim encryptedData As String = ed.TripleDesEncryptText(data)
        ed = Nothing
        Return encryptedData
    End Function

#Region " Private Variable "

    Private lstBoxLog As ListBox
    Private Label_Status As TextBox

    Private CIF As String
    Private FIRSTNAME As String
    Private MIDDLENAME As String
    Private LASTNAME As String
    Private SUFFIX As String
    Private DOB As String
    Private MEMBERSHIPDATE As String
    Private MEMBERSHIPSTATUS As String
    Private GENDER As String
    Private MEMBERSHIPTYPE As String
    Private IDNUMBER As String
    Public IDNUMBER_PlainText As String
    Private DATEISSUED As String
    Private BRANCHISSUED As String
    Private ASSOCIATETYPE As String
    Private CIF_PRINCIPAL As String

    Private IsSuccessWrite As Boolean
    Private strErrorMsg As String

    Private LoadKeyCommand As String
    Private AuthenticateKeyCommand As String
    Private WriteCommand As String

    Private _UID As String

#End Region

#Region " Public Properties "

    Public ReadOnly Property UID() As String
        Get
            Return _UID
        End Get
    End Property

    Public ReadOnly Property SuccessWrite() As Boolean
        Get
            Return IsSuccessWrite
        End Get
    End Property

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return strErrorMsg
        End Get
    End Property

#End Region

#Region " Methods "

    Private Function Write() As Boolean
        Try
            Dim strStartTime As String = Now.ToLongTimeString
            Dim strEndTime As String = ""

            Label_Status.Text = "Connecting to reader.."
            Application.DoEvents()

            Dim _clssMisc As New Misc(My.Settings.PCSCReader, lstBoxLog)

            _clssMisc.InitializeReaderList()

            _clssMisc.ConnectToCard()

            Label_Status.Text = "Writing data.."
            Application.DoEvents() '

            '_UID = GetUID_WithOpenConnection.Replace(" ", "")
            'MessageBox.Show("idnumber is " & IDNUMBER_PlainText)

            Try
                Dim intCharsLength As Short = 16

                If Not WriteSectorData(AFPSLAI_Sector.CIF, CIF, "CIF", , 1) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.CIF, CIF, "CIF", (intCharsLength * 1), 2) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.FIRSTNAME, FIRSTNAME, "FIRST NAME") Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.FIRSTNAME, FIRSTNAME, "FIRST NAME", (intCharsLength * 1), 1) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.FIRSTNAME, FIRSTNAME, "FIRST NAME", (intCharsLength * 2), 2) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.MIDDLENAME, MIDDLENAME, "MIDDLE NAME") Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.MIDDLENAME, MIDDLENAME, "MIDDLE NAME", (intCharsLength * 1), 1) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.MIDDLENAME, MIDDLENAME, "MIDDLE NAME", (intCharsLength * 2), 2) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.LASTNAME, LASTNAME, "LAST NAME") Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.LASTNAME, LASTNAME, "LAST NAME", (intCharsLength * 1), 1) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.LASTNAME, LASTNAME, "LAST NAME", (intCharsLength * 2), 2) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.SUFFIX, SUFFIX, "SUFFIX", , 1) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.DOB, DOB, "DOB") Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.DOB, DOB, "DOB", (intCharsLength * 1), 1) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.MEMBERSHIPDATE, MEMBERSHIPDATE, "MEMBERSHIP DATE", , 1) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.MEMBERSHIPDATE, MEMBERSHIPDATE, "MEMBERSHIP DATE", (intCharsLength * 1), 2) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.MEMBERSHIPSTATUS, MEMBERSHIPSTATUS, "MEMBERSHIP STATUS", , 2) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.GENDER, GENDER, "GENDER", , 1) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.MEMBERSHIPTYPE, MEMBERSHIPTYPE, "MEMBERSHIP TYPE", , 1) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.MEMBERSHIPTYPE, MEMBERSHIPTYPE, "MEMBERSHIP TYPE", (intCharsLength * 1), 2) Then Return False
                '_UID = GetUID_WithOpenConnection.Replace(" ", "")
                'IDNUMBER_PlainText = String.Format("{0}_{1}", _UID, IDNUMBER_PlainText).Replace("__", "_")

                Dim idnumberUid As String = IDNUMBER_PlainText
                If idnumberUid.Split("_").Length = 3 Then If idnumberUid.Split("_")(0) <> "FAILED" Then _UID = idnumberUid.Split("_")(0)

                'MessageBox.Show("UID is " & _UID)

                IDNUMBER = EncryptValue(IDNUMBER_PlainText)
                If Not WriteSectorData(AFPSLAI_Sector.IDNUMBER, IDNUMBER, "ID NUMBER") Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.IDNUMBER, IDNUMBER, "ID NUMBER", (intCharsLength * 1), 1) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.DATEISSUED, DATEISSUED, "DATE ISSUED", , 1) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.DATEISSUED, DATEISSUED, "DATE ISSUED", (intCharsLength * 1), 2) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.BRANCHISSUED, BRANCHISSUED, "BRANCH") Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.BRANCHISSUED, BRANCHISSUED, "BRANCH", (intCharsLength * 1), 1) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.ASSOCIATETYPE, ASSOCIATETYPE, "ASSOCIATE TYPE") Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.ASSOCIATETYPE, ASSOCIATETYPE, "ASSOCIATE TYPE", (intCharsLength * 1), 2) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.CIF_PRINCIPAL, CIF_PRINCIPAL, "PRINCIPAL CIF", , 1) Then Return False
                If Not WriteSectorData(AFPSLAI_Sector.CIF_PRINCIPAL, CIF_PRINCIPAL, "PRINCIPAL CIF", (intCharsLength * 1), 2) Then Return False

                _clssMisc.DisconnectCard()

                Label_Status.Text = "Ready"
                Label_Status.ForeColor = Color.Black

                strEndTime = Now.ToLongTimeString

                IsSuccessWrite = True

                Return True
            Catch ex As Exception
                Label_Status.Text = ex.Message
                Label_Status.ForeColor = Color.Red

                strErrorMsg = "Failed to write." & Environment.NewLine & ex.Message

                IsSuccessWrite = False

                Return False
            End Try
        Catch ex As Exception
            strErrorMsg = "Failed to write." & Environment.NewLine & ex.Message

            IsSuccessWrite = False

            Return False
        End Try
    End Function

    Private Function Writev2() As Boolean
        Try

            Dim strStartTime As String = Now.ToLongTimeString
            Dim strEndTime As String = ""

            Label_Status.Text = "Connecting to reader.."
            Application.DoEvents()

            Dim _clssMisc As New Misc(My.Settings.PCSCReader, lstBoxLog)

            _clssMisc.InitializeReaderList()

            _clssMisc.ConnectToCard()

            Label_Status.Text = "Writing data.."
            Application.DoEvents()

            Try
                Dim intCharsLength As Short = 16

                Dim jk As String = ""
                Do While jk = ""
                    jk = GetUID_WithOpenConnection.Replace(" ", "")
                Loop

                _UID = jk
                IDNUMBER_PlainText = String.Format("{0}_{1}", _UID, IDNUMBER_PlainText).Replace("__", "_")
                IDNUMBER_PlainText = String.Format("{0}_{1}", _UID, IDNUMBER_PlainText).Replace("__", "_")
                IDNUMBER = EncryptValue(IDNUMBER_PlainText)

                _clssMisc.DisconnectCard()

                Label_Status.Text = "Ready"
                Label_Status.ForeColor = Color.Black

                strEndTime = Now.ToLongTimeString

                IsSuccessWrite = True

                Return True
            Catch ex As Exception
                Label_Status.Text = ex.Message
                Label_Status.ForeColor = Color.Red

                strErrorMsg = "Failed to write." & Environment.NewLine & ex.Message

                IsSuccessWrite = False

                Return False
            End Try
        Catch ex As Exception
            strErrorMsg = "Failed to write." & Environment.NewLine & ex.Message

            IsSuccessWrite = False

            Return False
        End Try
    End Function

    Public Shared Sub Init()
        Dim _clssMisc As New Misc(My.Settings.PCSCReader, New ListBox)
        _clssMisc.InitializeReaderList()
        _clssMisc.ConnectToCard()
    End Sub

    Public Shared Function GetUID() As String
        Dim _clssMisc As New Misc(My.Settings.PCSCReader, New ListBox)
        Try
            _clssMisc.InitializeReaderList()

            _clssMisc.ConnectToCard()

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

            retCode = SendAPDUandDisplay(3, New ListBox)

            If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
                Return "FAILED"
            End If

            If validATS Then

                For indx = 0 To (RecvLen - 3)
                    tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "
                Next indx

                'displayOut(3, 0, "UID:" + tmpStr.Trim, lstBoxLog)

            End If

            Return tmpStr
        Catch ex As Exception
            Return "FAILED"
        Finally
            _clssMisc.DisconnectCard()
        End Try
    End Function

    Public Function GetUID_WithOpenConnection() As String
        Try
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
            End If

            Return tmpStr
        Catch ex As Exception
        Finally
        End Try
    End Function

    Private Function WriteSectorData(ByVal intSectorID As Integer, ByVal strData As String, ByVal strField As String, Optional ByVal intStartIndex As Short = 0, Optional ByVal intBlock As Integer = 0) As Boolean
        Try
            Dim _data As String = FormatField(strData.Trim, intStartIndex)
            'If _data.Trim = "" Then Return True

            'Dim intBlock As Integer = 0
            Dim KeyTypeCommand As String = "60"
            Dim KeyString As String = WriteToCard.CARD_KEY

            LoadKeyCommand = "FF82200006" + KeyString

            If My.Settings.PCSCReader.Contains("OMNIKEY") Then
                If My.Settings.PCSCReader.Contains("5422") Then
                    AuthenticateKeyCommand = "FF860000050100" + ExactBlock(intSectorID, intBlock, False).ToString("X2") + KeyTypeCommand + "00"
                Else
                    AuthenticateKeyCommand = "FF8800" + ExactBlock(intSectorID, intBlock, False).ToString("X2") + KeyTypeCommand + "00"
                End If
            Else
                AuthenticateKeyCommand = "FF860000050100" + ExactBlock(intSectorID, intBlock, False).ToString("X2") + "2000"
            End If

            WriteCommand = "FFD600" + ExactBlock(intSectorID, intBlock, False).ToString("X2") + "10" + Str2Hex(_data).Replace(" ", "")
            Label_Status.Text = "Writing " & strField & "..."
            Application.DoEvents()

            If Not SendAPDUCommands() Then Return False

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function SendAPDUCommands() As Boolean
        If LoadKeyCommand = "" Then
            'MessageBox.Show("Invalid LoadKeyCommand", "Unable to process", MessageBoxButtons.OK, MessageBoxIcon.Error)
            IsSuccessWrite = False
            strErrorMsg = "Invalid LoadKeyCommand"
            Return False
        Else
            If AuthenticateKeyCommand = "" Then
                'MessageBox.Show("Invalid AuthenticateKeyCommand", "Unable to process", MessageBoxButtons.OK, MessageBoxIcon.Error)
                IsSuccessWrite = False
                strErrorMsg = "Invalid AuthenticateKeyCommand"
                Return False
            Else
                If WriteCommand = "" Then
                    'MessageBox.Show("Invalid WriteCommand", "Unable to process", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    IsSuccessWrite = False
                    strErrorMsg = "Invalid WriteCommand"
                    Return False
                End If
            End If
        End If

        SendAPDU(LoadKeyCommand, lstBoxLog)
        SendAPDU(AuthenticateKeyCommand, lstBoxLog)
        SendAPDU(WriteCommand, lstBoxLog)
        'LoadKeyCommand = ""
        AuthenticateKeyCommand = ""
        WriteCommand = ""

        Return True
    End Function

#End Region

End Structure
