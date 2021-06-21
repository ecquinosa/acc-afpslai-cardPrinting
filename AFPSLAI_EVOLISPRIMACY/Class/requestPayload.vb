

Public Class requestPayload

    Private systemValue As String
    Public Property system() As String
        Get
            Return systemValue
        End Get
        Set(ByVal value As String)
            systemValue = value
        End Set
    End Property

    Private authenticationValue As String
    Public Property authentication() As String
        Get
            Return authenticationValue
        End Get
        Set(ByVal value As String)
            authenticationValue = value
        End Set
    End Property

    Private payloadValue As String
    Public Property payload() As String
        Get
            Return payloadValue
        End Get
        Set(ByVal value As String)
            payloadValue = value
        End Set
    End Property

    Public Sub New()
        system = "CPS"
    End Sub


End Class

