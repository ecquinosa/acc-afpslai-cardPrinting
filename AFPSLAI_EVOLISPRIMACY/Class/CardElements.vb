Public Class CardElements

    Private photoValue As accAfpslaiEmvObjct.cps_card_elements = Nothing
    Public Property Photo() As accAfpslaiEmvObjct.cps_card_elements
        Get
            Return photoValue
        End Get
        Set(ByVal value As accAfpslaiEmvObjct.cps_card_elements)
            photoValue = value
        End Set
    End Property

    Private memberSinceValue As accAfpslaiEmvObjct.cps_card_elements = Nothing
    Public Property MemberSince() As accAfpslaiEmvObjct.cps_card_elements
        Get
            Return memberSinceValue
        End Get
        Set(ByVal value As accAfpslaiEmvObjct.cps_card_elements)
            memberSinceValue = value
        End Set
    End Property

    Private validThruValue As accAfpslaiEmvObjct.cps_card_elements = Nothing
    Public Property ValidThru() As accAfpslaiEmvObjct.cps_card_elements
        Get
            Return validThruValue
        End Get
        Set(ByVal value As accAfpslaiEmvObjct.cps_card_elements)
            validThruValue = value
        End Set
    End Property

    Private nameValue As accAfpslaiEmvObjct.cps_card_elements = Nothing
    Public Property Name() As accAfpslaiEmvObjct.cps_card_elements
        Get
            Return nameValue
        End Get
        Set(ByVal value As accAfpslaiEmvObjct.cps_card_elements)
            nameValue = value
        End Set
    End Property

    Private cifValue As accAfpslaiEmvObjct.cps_card_elements = Nothing
    Public Property CIF() As accAfpslaiEmvObjct.cps_card_elements
        Get
            Return cifValue
        End Get
        Set(ByVal value As accAfpslaiEmvObjct.cps_card_elements)
            cifValue = value
        End Set
    End Property


    Public Sub New()
        Populate()
    End Sub

    Public Sub Populate()
        Dim cces As New List(Of accAfpslaiEmvObjct.cps_card_elements)
        Dim obj As Object
        If Main.msa.GetTable(accAfpslaiEmvObjct.MiddleServerApi.msApi.getCpsCardElements, obj) Then
            cces = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of accAfpslaiEmvObjct.cps_card_elements))(obj.ToString)
            photoValue = cces.Where(Function(o) o.element.Equals([Enum].GetName(GetType(accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement), accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement.photo))).FirstOrDefault
            memberSinceValue = cces.Where(Function(o) o.element.Equals([Enum].GetName(GetType(accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement), accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement.memberSince))).FirstOrDefault
            validThruValue = cces.Where(Function(o) o.element.Equals([Enum].GetName(GetType(accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement), accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement.validThru))).FirstOrDefault
            nameValue = cces.Where(Function(o) o.element.Equals([Enum].GetName(GetType(accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement), accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement.name))).FirstOrDefault
            cifValue = cces.Where(Function(o) o.element.Equals([Enum].GetName(GetType(accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement), accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement.cif))).FirstOrDefault
        End If
    End Sub

End Class
