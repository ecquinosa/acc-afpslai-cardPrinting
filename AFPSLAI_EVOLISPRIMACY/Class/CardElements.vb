Public Class CardElements

    Private PhotoElementParam As String = "105,213,257,345"
    Private SignatureElementParam As String = "490,235,365,170"
    Private BiometricElementParam As String = "630,205,170,170"
    Private BarcodeElementParam As String = "457,537,540,70"
    Private NameElementParam As String = "450,305"
    Private CIFElementParam As String = "0,0"

    Private AddressElementParam As String = "80,250"
    Private ContactNosElementParam As String = "80,340"
    Private DOBElementParam As String = "295,340"
    Private IDNumberElementParam As String = "525,340"
    Private IssueDateElementParam As String = "725,340"
    Private ContactNameElementParam As String = "80,410"
    Private ContactContactNosElementParam As String = "80,435"
    Private BranchElementParam As String = "525,410"

    Private SignaturePresidentElementParam As String = "680,475,150,100"

    Public TableElements As DataTable

    Public Function PhotoElement() As String
        Return "PHOTO"
    End Function

    Public Function SignatureElement() As String
        Return "SIGNATURE"
    End Function

    Public Function BiometricElement() As String
        Return "BIOMETRIC"
    End Function

    Public Function BarcodeElement() As String
        Return "BARCODE"
    End Function

    Public Function NameElement() As String
        Return "NAME"
    End Function

    Public Function CIFElement() As String
        Return "CIF"
    End Function

    Public Function AddressElement() As String
        Return "ADDRESS"
    End Function

    Public Function ContactNosElement() As String
        Return "CONTACTNOS"
    End Function

    Public Function DOBElement() As String
        Return "DOB"
    End Function

    Public Function IDNumberElement() As String
        Return "IDNUMBER"
    End Function

    Public Function IssueDateElement() As String
        Return "ISSUEDATE"
    End Function

    Public Function ContactNameElement() As String
        Return "CONTACTNAME"
    End Function

    Public Function ContactContactNosElement() As String
        Return "CONTACT_CONTACTNOS"
    End Function

    Public Function BranchElement() As String
        Return "BRANCH"
    End Function

    Public Function SignaturePresidentElement() As String
        Return "SIGNATURE_PRESIDENT"
    End Function

    'Private Function IsElementExist(ByVal element As String) As Boolean
    '    If TableElements.Select(String.Format("CardElement='{0}'", element)).Length > 0 Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    Private Sub AddElement(ByVal element As String, ByVal value As String)
        Dim rw As DataRow = TableElements.NewRow
        rw(0) = element
        rw(1) = value
        TableElements.Rows.Add(rw)
    End Sub

    Private Sub BindElementValue(ByVal element As String, ByRef elementParam As String)
        If TableElements.Select(String.Format("CardElement='{0}'", element)).Length > 0 Then
            elementParam = TableElements.Select(String.Format("CardElement='{0}'", element))(0)("Parameter")
        Else
            AddElement(element, elementParam)
        End If
    End Sub

    Public Sub New()
        'Dim DAL As New DAL
        'If DAL.SelectQuery("SELECT * FROM tblCardElementParameters") Then
        '    TableElements = DAL.TableResult
        '    'If IsElementExist(PhotoElement) Then PhotoElementParam = TableElements.Select(String.Format("CardElement='{0}'", PhotoElement))(0)("Parameter") Else AddElement(PhotoElement, PhotoElementParam)

        '    BindElementValue(PhotoElement, PhotoElementParam)
        '    BindElementValue(SignatureElement, SignatureElementParam)
        '    BindElementValue(BarcodeElement, BarcodeElementParam)
        '    BindElementValue(NameElement, NameElementParam)
        '    BindElementValue(CIFElement, CIFElementParam)
        '    BindElementValue(AddressElement, AddressElementParam)
        '    BindElementValue(ContactNosElement, ContactNosElementParam)
        '    BindElementValue(DOBElement, DOBElementParam)
        '    BindElementValue(IDNumberElement, IDNumberElementParam)
        '    BindElementValue(IssueDateElement, IssueDateElementParam)
        '    BindElementValue(ContactNameElement, ContactNameElementParam)
        '    BindElementValue(ContactContactNosElement, ContactContactNosElementParam)
        '    BindElementValue(BranchElement, BranchElementParam)
        '    BindElementValue(SignaturePresidentElement, SignaturePresidentElementParam)
        '    BindElementValue(BiometricElement, BiometricElementParam)
        'End If
        'DAL.Dispose()
        'DAL = Nothing
    End Sub

    Public ReadOnly Property Photo_X As Integer
        Get
            Return PhotoElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property Photo_Y As Integer
        Get
            Return PhotoElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property Photo_Width As Integer
        Get
            Return PhotoElementParam.Split(",")(2)
        End Get
    End Property

    Public ReadOnly Property Photo_Height As Integer
        Get
            Return PhotoElementParam.Split(",")(3)
        End Get
    End Property

    Public ReadOnly Property Signature_X As Integer
        Get
            Return SignatureElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property Signature_Y As Integer
        Get
            Return SignatureElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property Signature_Width As Integer
        Get
            Return SignatureElementParam.Split(",")(2)
        End Get
    End Property

    Public ReadOnly Property Signature_Height As Integer
        Get
            Return SignatureElementParam.Split(",")(3)
        End Get
    End Property

    Public ReadOnly Property Barcode_X As Integer
        Get
            Return BarcodeElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property Barcode_Y As Integer
        Get
            Return BarcodeElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property Barcode_Width As Integer
        Get
            Return BarcodeElementParam.Split(",")(2)
        End Get
    End Property

    Public ReadOnly Property Barcode_Height As Integer
        Get
            Return BarcodeElementParam.Split(",")(3)
        End Get
    End Property

    Public ReadOnly Property Name_X As Integer
        Get
            Return NameElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property Name_Y As Integer
        Get
            Return NameElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property CIF_X As Integer
        Get
            Return CIFElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property CIF_Y As Integer
        Get
            Return CIFElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property Address_X As Integer
        Get
            Return AddressElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property Address_Y As Integer
        Get
            Return AddressElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property ContactNos_X As Integer
        Get
            Return ContactNosElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property ContactNos_Y As Integer
        Get
            Return ContactNosElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property DOB_X As Integer
        Get
            Return DOBElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property DOB_Y As Integer
        Get
            Return DOBElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property IDNumber_X As Integer
        Get
            Return IDNumberElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property IDNumber_Y As Integer
        Get
            Return IDNumberElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property IssueDate_X As Integer
        Get
            Return IssueDateElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property IssueDate_Y As Integer
        Get
            Return IssueDateElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property ContactName_X As Integer
        Get
            Return ContactNameElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property ContactName_Y As Integer
        Get
            Return ContactNameElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property ContactContactNos_X As Integer
        Get
            Return ContactContactNosElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property ContactContactNos_Y As Integer
        Get
            Return ContactContactNosElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property Branch_X As Integer
        Get
            Return BranchElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property Branch_Y As Integer
        Get
            Return BranchElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property Signature_President_X As Integer
        Get
            Return SignaturePresidentElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property Signature_President_Y As Integer
        Get
            Return SignaturePresidentElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property Signature_President_Width As Integer
        Get
            Return SignaturePresidentElementParam.Split(",")(2)
        End Get
    End Property

    Public ReadOnly Property Signature_President_Height As Integer
        Get
            Return SignaturePresidentElementParam.Split(",")(3)
        End Get
    End Property

    Public ReadOnly Property Biometric_X As Integer
        Get
            Return BiometricElementParam.Split(",")(0)
        End Get
    End Property

    Public ReadOnly Property Biometric_Y As Integer
        Get
            Return BiometricElementParam.Split(",")(1)
        End Get
    End Property

    Public ReadOnly Property Biometric_Width As Integer
        Get
            Return BiometricElementParam.Split(",")(2)
        End Get
    End Property

    Public ReadOnly Property Biometric_Height As Integer
        Get
            Return BiometricElementParam.Split(",")(3)
        End Get
    End Property

    Public Sub SaveTable()
        'Dim DAL As New DAL
        ''If IsElementExist(BranchElement) Then BranchElementParam = TableElements.Select(String.Format("CardElement='{0}'", BranchElement))(0)("Parameter")
        'For Each rw As DataRow In TableElements.Rows
        '    If DAL.SelectQuery(String.Format("SELECT * FROM tblCardElementParameters WHERE CardElement='{0}'", rw("CardElement").ToString.Trim)) Then
        '        If DAL.TableResult.DefaultView.Count > 0 Then
        '            DAL.ExecuteQuery(String.Format("UPDATE tblCardElementParameters SET Parameter='{0}' WHERE CardElement='{1}'", rw("Parameter").ToString, rw("CardElement").ToString))
        '        Else
        '            DAL.ExecuteQuery(String.Format("INSERT INTO tblCardElementParameters (CardElement, Parameter) VALUES ('{0}','{1}')", rw("CardElement").ToString, rw("Parameter").ToString))
        '        End If
        '    End If
        'Next
        'DAL.Dispose()
        'DAL = Nothing
    End Sub


End Class
