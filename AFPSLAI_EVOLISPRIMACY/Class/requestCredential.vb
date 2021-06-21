

Public Class requestCredential

    Private keyValue As String
    Public Property key() As String
        Get
            Return keyValue
        End Get
        Set(ByVal value As String)
            keyValue = value
        End Set
    End Property

    Private userIdValue As Integer
    Public Property userId() As Integer
        Get
            Return userIdValue
        End Get
        Set(ByVal value As Integer)
            userIdValue = value
        End Set
    End Property

    Private userNameValue As String
    Public Property userName() As String
        Get
            Return userNameValue
        End Get
        Set(ByVal value As String)
            userNameValue = value
        End Set
    End Property

    Private userPassValue As String
    Public Property userPass() As String
        Get
            Return userPassValue
        End Get
        Set(ByVal value As String)
            userPassValue = value
        End Set
    End Property

    Private branchValue As String
    Public Property branch() As String
        Get
            Return branchValue
        End Get
        Set(ByVal value As String)
            branchValue = value
        End Set
    End Property

    Private dateRequestValue As String
    Public Property dateRequest() As String
        Get
            Return dateRequestValue
        End Get
        Set(ByVal value As String)
            dateRequestValue = value
        End Set
    End Property


End Class

