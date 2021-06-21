
Public Structure ReadCardData

    Public Sub New(ByRef lstBoxLog As ListBox, ByRef Label_Status As TextBox, Optional ByVal ReadAcctNoOnly As Boolean = False)
        Me.lstBoxLog = lstBoxLog
        Me.Label_Status = Label_Status

        ReadCardData(ReadAcctNoOnly)
    End Sub

#Region " Private Variable "

    Private lstBoxLog As ListBox
    Private Label_Status As TextBox

    Private _CIF1 As String
    Private _CIF2 As String
    Private _FName1 As String
    Private _FName2 As String
    Private _FName3 As String
    Private _MName1 As String
    Private _MName2 As String
    Private _MName3 As String
    Private _LName1 As String
    Private _LName2 As String
    Private _LName3 As String
    Private _Suffix As String
    Private _DOB1 As String
    Private _DOB2 As String
    Private _MembershipDate1 As String
    Private _MembershipDate2 As String
    Private _MembershipStatus As String
    Private _Gender As String
    Private _MembershipType1 As String
    Private _MembershipType2 As String
    Private _IDNumber1 As String
    Private _IDNumber2 As String
    Private _DateIssued1 As String
    Private _DateIssued2 As String
    Private _BranchIssued1 As String
    Private _BranchIssued2 As String
    Private _AssociateType1 As String
    Private _AssociateType2 As String
    Private _CIF_Principal1 As String
    Private _CIF_Principal2 As String

    Private strErrorMsg As String
    Private IsSuccessRead As Boolean

#End Region

#Region " Public Properties "

    Public ReadOnly Property CIF() As String
        Get
            Return DecryptValue(String.Format("{0}{1}", _CIF1.Trim, _CIF2.Trim).Trim)
        End Get
    End Property

    Public ReadOnly Property FirstName() As String
        Get
            Return DecryptValue(String.Format("{0}{1}{2}", _FName1.Trim, _FName2.Trim, _FName3.Trim).Trim)
        End Get
    End Property

    Public ReadOnly Property MiddleName() As String
        Get
            Return DecryptValue(String.Format("{0}{1}{2}", _MName1.Trim, _MName2.Trim, _MName3.Trim).Trim)
        End Get
    End Property

    Public ReadOnly Property LastName() As String
        Get
            Return DecryptValue(String.Format("{0}{1}{2}", _LName1.Trim, _LName2.Trim, _LName3.Trim).Trim)
        End Get
    End Property

    Public ReadOnly Property Suffix() As String
        Get
            Return DecryptValue(_Suffix.Trim)
        End Get
    End Property

    Public ReadOnly Property BirthDate() As String
        Get
            Return DecryptValue(String.Format("{0}{1}", _DOB1.Trim, _DOB2.Trim).Trim)
        End Get
    End Property

    Public ReadOnly Property Gender() As String
        Get
            Return DecryptValue(_Gender.Trim)
        End Get
    End Property

    Public ReadOnly Property MembershipDate() As String
        Get
            Return DecryptValue(String.Format("{0}{1}", _MembershipDate1.Trim, _MembershipDate2.Trim).Trim)
        End Get
    End Property

    Public ReadOnly Property MembershipStatus() As String
        Get
            Return DecryptValue(_MembershipStatus.Trim)
        End Get
    End Property

    Public ReadOnly Property MembershipType() As String
        Get
            Return DecryptValue(String.Format("{0}{1}", _MembershipType1.Trim, _MembershipType2.Trim).Trim)
        End Get
    End Property

    Public ReadOnly Property IDNumber() As String
        Get
            Return DecryptValue(String.Format("{0}{1}", _IDNumber1.Trim, _IDNumber2.Trim).Trim)
        End Get
    End Property

    Public ReadOnly Property DateIssued() As String
        Get
            Return DecryptValue(String.Format("{0}{1}", _DateIssued1.Trim, _DateIssued2.Trim).Trim)
        End Get
    End Property

    Public ReadOnly Property BranchIssued() As String
        Get
            Return DecryptValue(String.Format("{0}{1}", _BranchIssued1.Trim, _BranchIssued2.Trim).Trim)
        End Get
    End Property

    Public ReadOnly Property AssociateType() As String
        Get
            Return DecryptValue(String.Format("{0}{1}", _AssociateType1.Trim, _AssociateType2.Trim).Trim)
        End Get
    End Property

    Public ReadOnly Property CIF_Principal() As String
        Get
            Return DecryptValue(String.Format("{0}{1}", _CIF_Principal1.Trim, _CIF_Principal2.Trim).Trim)
        End Get
    End Property

    Public ReadOnly Property SuccessRead() As Boolean
        Get
            Return IsSuccessRead
        End Get
    End Property

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return strErrorMsg
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub ReadCardData(ByVal ReadAcctNoOnly As Boolean)
        Try
            Dim _clssMisc As New Misc(My.Settings.PCSCReader, lstBoxLog)

            _clssMisc.InitializeReaderList()

            _clssMisc.ConnectToCard()

            ReadSectorData(_CIF1, WriteToCard.AFPSLAI_Sector.CIF, 1)
            ReadSectorData(_CIF2, WriteToCard.AFPSLAI_Sector.CIF, 2)
            ReadSectorData(_FName1, WriteToCard.AFPSLAI_Sector.FIRSTNAME)
            ReadSectorData(_FName2, WriteToCard.AFPSLAI_Sector.FIRSTNAME, 1)
            ReadSectorData(_FName3, WriteToCard.AFPSLAI_Sector.FIRSTNAME, 2)
            ReadSectorData(_MName1, WriteToCard.AFPSLAI_Sector.MIDDLENAME)
            ReadSectorData(_MName2, WriteToCard.AFPSLAI_Sector.MIDDLENAME, 1)
            ReadSectorData(_MName3, WriteToCard.AFPSLAI_Sector.MIDDLENAME, 2)
            ReadSectorData(_LName1, WriteToCard.AFPSLAI_Sector.LASTNAME)
            ReadSectorData(_LName2, WriteToCard.AFPSLAI_Sector.LASTNAME, 1)
            ReadSectorData(_LName3, WriteToCard.AFPSLAI_Sector.LASTNAME, 2)
            ReadSectorData(_Suffix, WriteToCard.AFPSLAI_Sector.SUFFIX, 1)
            ReadSectorData(_DOB1, WriteToCard.AFPSLAI_Sector.DOB)
            ReadSectorData(_DOB2, WriteToCard.AFPSLAI_Sector.DOB, 1)
            ReadSectorData(_MembershipDate1, WriteToCard.AFPSLAI_Sector.MEMBERSHIPDATE, 1)
            ReadSectorData(_MembershipDate2, WriteToCard.AFPSLAI_Sector.MEMBERSHIPDATE, 2)
            ReadSectorData(_MembershipStatus, WriteToCard.AFPSLAI_Sector.MEMBERSHIPSTATUS, 2)
            ReadSectorData(_Gender, WriteToCard.AFPSLAI_Sector.GENDER, 1)
            ReadSectorData(_MembershipType1, WriteToCard.AFPSLAI_Sector.MEMBERSHIPTYPE, 1)
            ReadSectorData(_MembershipType2, WriteToCard.AFPSLAI_Sector.MEMBERSHIPTYPE, 2)
            ReadSectorData(_IDNumber1, WriteToCard.AFPSLAI_Sector.IDNUMBER)
            ReadSectorData(_IDNumber2, WriteToCard.AFPSLAI_Sector.IDNUMBER, 1)
            ReadSectorData(_DateIssued1, WriteToCard.AFPSLAI_Sector.DATEISSUED, 1)
            ReadSectorData(_DateIssued2, WriteToCard.AFPSLAI_Sector.DATEISSUED, 2)
            ReadSectorData(_BranchIssued1, WriteToCard.AFPSLAI_Sector.BRANCHISSUED)
            ReadSectorData(_BranchIssued2, WriteToCard.AFPSLAI_Sector.BRANCHISSUED, 1)
            ReadSectorData(_AssociateType1, WriteToCard.AFPSLAI_Sector.ASSOCIATETYPE)
            ReadSectorData(_AssociateType2, WriteToCard.AFPSLAI_Sector.ASSOCIATETYPE, 2)
            ReadSectorData(_CIF_Principal1, WriteToCard.AFPSLAI_Sector.CIF_PRINCIPAL, 1)
            ReadSectorData(_CIF_Principal2, WriteToCard.AFPSLAI_Sector.CIF_PRINCIPAL, 2)

            _clssMisc.DisconnectCard()

            Label_Status.Text = "Ready"

            If strErrorMsg = "" Then
                IsSuccessRead = True
            Else
                strErrorMsg = "Failed to read card. " & Environment.NewLine & strErrorMsg
                IsSuccessRead = False
            End If

        Catch ex As Exception
            strErrorMsg = "Failed to read card. " & Environment.NewLine & ex.Message
            IsSuccessRead = False
        End Try
    End Sub

    Private Sub ReadSectorData(ByRef str As String, ByVal intSectorID As Integer, Optional ByVal intBlock As Integer = 0)
        Try
            'Dim intBlock As Integer = 0
            Dim KeyTypeCommand As String = ""
            Dim LoadKeyCommand As String = ""
            Dim AuthenticateKeyCommand As String = ""
            Dim ReadCommand As String = ""
            Dim KeyString As String

            If intSectorID > 38 Then
                intSectorID -= 38
                intBlock += 1
            End If

            KeyTypeCommand = "60"
            KeyString = WriteToCard.CARD_KEY

            Label_Status.Text = "Reading Block " + CStr(intBlock) + ", Sector " + CStr(intSectorID) + "."
            Application.DoEvents()

            LoadKeyCommand = "FF82200006" + KeyString

            If My.Settings.PCSCReader.Contains("OMNIKEY") Then
                If My.Settings.PCSCReader.Contains("5422") Then
                    AuthenticateKeyCommand = "FF860000050100" + ExactBlock(intSectorID, intBlock, False).ToString("X2") + KeyTypeCommand + "00"
                Else
                    AuthenticateKeyCommand = "FF8800" + ExactBlock(intSectorID, intBlock, False).ToString("X2") + KeyTypeCommand + "00"
                End If
            Else
                AuthenticateKeyCommand = "FF860000050100" & ExactBlock(intSectorID, intBlock, False).ToString("X2") & "2000"
            End If

            ReadCommand = "FFB000" + ExactBlock(intSectorID, intBlock, False).ToString("X2") + "10"

            SendAPDU(LoadKeyCommand, lstBoxLog)

            SendAPDU(AuthenticateKeyCommand, lstBoxLog)

            If SmartCardErrorCode() <> "Success" Then

                If strErrorMsg = "" Then
                    strErrorMsg = "Sector " + CStr(intSectorID) + ", Block " + CStr(intBlock) + _
                                " " + SmartCardErrorCode() + "."
                Else
                    strErrorMsg = Environment.NewLine & "Sector " + CStr(intSectorID) + ", Block " + CStr(intBlock) + _
                                " " + SmartCardErrorCode() + "."
                End If
            End If

            SendAPDU(ReadCommand, lstBoxLog)

            str = Hex2Str(GetSmartCardResponse4.Replace(" ", "")).Replace("ÿ", " ").Substring(0, 16)
        Catch ex As Exception
            strErrorMsg = "Failed to read card. " & Environment.NewLine & ex.Message
        End Try

    End Sub

    Private Function DecryptValue(ByVal data As String) As String
        Dim ed As New AllcardEncryptDecrypt.EncryptDecrypt(WriteToCard.DATA_KEY)
        Dim decryptedData As String = ed.TripleDesDecryptText(data)
        ed = Nothing
        Return decryptedData
    End Function

#End Region

End Structure
