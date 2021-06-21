
Public Class LogIN

    Public IsSuccess As Boolean = False

    Private Sub LogIN_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" And txtPassword.Text = "" Then
            lblResult.Text = "Please enter valid credential"
            txtUsername.Focus()
        ElseIf txtUsername.Text <> "" And txtPassword.Text = "" Then
            lblResult.Text = "Please enter valid credential"
            txtPassword.Focus()
        ElseIf txtUsername.Text = "" And txtPassword.Text <> "" Then
            lblResult.Text = "Please enter valid credential"
            txtUsername.Focus()
        Else
            If ValidateLogIN_Offline() Then LogIn()
        End If
    End Sub

    Private Function ValidateLogIN_Offline() As Boolean
        Dim ola As New DCS_OfflineUsers.OfflineLogInAuth()
        If ola.ErrorMessage <> "" Then
            lblResult.Text = ola.ErrorMessage
            txtUsername.Focus()
            Return False
        Else
            If ola.UserAndRoleTable.Select(String.Format("Username='{0}' AND Password='{1}'", txtUsername.Text, txtPassword.Text)).Length > 0 Then
                My.Settings.OperatorID = ola.UserAndRoleTable.Select(String.Format("Username='{0}' AND Password='{1}'", txtUsername.Text, txtPassword.Text))(0)("Name").ToString().Trim()
                My.Settings.Save()
                Return True
            Else
                lblResult.Text = "Invalid credential"
                txtUsername.Focus()
                Return False
            End If
        End If
    End Function

    Private Sub LogIn()
        IsSuccess = True
        Close()
    End Sub

    Private Sub txtPassword_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            btnLogin.PerformClick()
        End If
    End Sub
End Class