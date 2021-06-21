

Public Class card

    Private idValue As Integer
    Public Property id() As Integer
        Get
            Return idValue
        End Get
        Set(ByVal value As Integer)
            idValue = value
        End Set
    End Property

    Private member_idValue As Integer
    Public Property member_id() As Integer
        Get
            Return member_idValue
        End Get
        Set(ByVal value As Integer)
            member_idValue = value
        End Set
    End Property

    Private cardNoValue As String
    Public Property cardNo() As String
        Get
            Return cardNoValue
        End Get
        Set(ByVal value As String)
            cardNoValue = value
        End Set
    End Property

    Private date_postValue As Date
    Public Property date_post() As Date
        Get
            Return date_postValue
        End Get
        Set(ByVal value As Date)
            date_postValue = value
        End Set
    End Property

    Private time_postValue As Date
    Public Property time_post() As Date
        Get
            Return time_postValue
        End Get
        Set(ByVal value As Date)
            time_postValue = value
        End Set
    End Property


End Class

