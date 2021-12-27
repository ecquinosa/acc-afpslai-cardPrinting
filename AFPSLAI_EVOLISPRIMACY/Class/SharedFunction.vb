Public Class SharedFunction

    Public Shared MsgHeader As String = "Card Printing Software"

    Public Shared Sub ShowInfoMessage(ByVal msg As String)
        MessageBox.Show(msg, MsgHeader, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Shared Sub ShowErrorMessage(ByVal msg As String)
        MessageBox.Show(msg, MsgHeader, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Shared Sub ShowWarningMessage(ByVal msg As String)
        MessageBox.Show(msg, MsgHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Shared Function ShowWarningMessage(ByVal msg As String, Optional ByVal msgBoxBtn As MessageBoxButtons = vbYesNo) As DialogResult
        Return MessageBox.Show(msg, MsgHeader, msgBoxBtn, MessageBoxIcon.Question)
    End Function

End Class
