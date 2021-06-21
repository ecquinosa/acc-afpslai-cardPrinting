
Public Class Setting

    Private Sub Setting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitializeReaderList()
        GetInstalledPrinters()

        BindSettings()
        BindCardElements()

        'lblSignaturePresident.Text = PrintCard.presidentSignatureFile
        'If System.IO.File.Exists(PrintCard.presidentSignatureFile) Then picSignaturePresident.Image = Image.FromStream(New System.IO.MemoryStream(System.IO.File.ReadAllBytes(PrintCard.presidentSignatureFile)))
    End Sub

    Private Sub BindSettings()
        cboCardReader.SelectedIndex = cboCardReader.FindStringExact(My.Settings.PCSCReader)
        cboPrinter.SelectedIndex = cboPrinter.FindStringExact(My.Settings.CardPrinter)
        txtServer.Text = My.Settings.MiddleServerUrl
        txtDatabase.Text = My.Settings.Database
        txtUser.Text = My.Settings.User
        txtPassword.Text = My.Settings.Password
        txtCapturedData.Text = My.Settings.CapturedData
    End Sub

    Private Sub BindCardElements()
        Dim ce As New CardElements
        txtPhoto_X.Text = ce.Photo_X
        txtPhoto_Y.Text = ce.Photo_Y
        txtPhoto_Width.Text = ce.Photo_Width
        txtPhoto_Height.Text = ce.Photo_Height
        txtSign_X.Text = ce.Signature_X
        txtSign_Y.Text = ce.Signature_Y
        txtSign_Width.Text = ce.Signature_Width
        txtSign_Height.Text = ce.Signature_Height
        txtName_X.Text = ce.Name_X
        txtName_Y.Text = ce.Name_Y
        txtCIF_X.Text = ce.CIF_X
        txtCIF_Y.Text = ce.CIF_Y
        txtBio_X.Text = ce.Biometric_X
        txtBio_Y.Text = ce.Biometric_Y
        txtBio_Width.Text = ce.Biometric_Width
        txtBio_Height.Text = ce.Biometric_Height
        ce = Nothing
    End Sub

    Private Sub SaveSettings()
        If cboCardReader.Text <> "" Then My.Settings.PCSCReader = cboCardReader.Text
        If cboPrinter.Text <> "" Then My.Settings.CardPrinter = cboPrinter.Text
        My.Settings.MiddleServerUrl = txtServer.Text
        My.Settings.Database = txtDatabase.Text
        My.Settings.User = txtUser.Text
        My.Settings.Password = txtPassword.Text
        My.Settings.CapturedData = txtCapturedData.Text
        My.Settings.Save()
    End Sub

    Private Sub SaveElements()
        Try
            Dim ce As New CardElements
            ce.TableElements.Select(String.Format("CardElement='{0}'", ce.PhotoElement))(0)("Parameter") = String.Format("{0},{1},{2},{3}", txtPhoto_X.Text, txtPhoto_Y.Text, txtPhoto_Width.Text, txtPhoto_Height.Text)
            ce.TableElements.Select(String.Format("CardElement='{0}'", ce.SignatureElement))(0)("Parameter") = String.Format("{0},{1},{2},{3}", txtSign_X.Text, txtSign_Y.Text, txtSign_Width.Text, txtSign_Height.Text)
            ce.TableElements.Select(String.Format("CardElement='{0}'", ce.BiometricElement))(0)("Parameter") = String.Format("{0},{1},{2},{3}", txtBio_X.Text, txtBio_Y.Text, txtBio_Width.Text, txtBio_Height.Text)
            'ce.TableElements.Select(String.Format("CardElement='{0}'", ce.BarcodeElement))(0)("Parameter") = String.Format("{0},{1},{2},{3}", txtBarcode_X.Text, txtBarcode_Y.Text, txtBarcode_Width.Text, txtBarcode_Height.Text)
            ce.TableElements.Select(String.Format("CardElement='{0}'", ce.NameElement))(0)("Parameter") = String.Format("{0},{1}", txtName_X.Text, txtName_Y.Text)
            ce.TableElements.Select(String.Format("CardElement='{0}'", ce.CIFElement))(0)("Parameter") = String.Format("{0},{1}", txtCIF_X.Text, txtCIF_Y.Text)
            ce.SaveTable()
            ce = Nothing
        Catch ex As Exception
            MessageBox.Show("Failed to save card elements..." & vbNewLine & vbNewLine & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Public Sub InitializeReaderList()

        Dim sReaderList As String = ""
        Dim ReaderCount As Integer
        Dim ctr As Integer

        For ctr = 0 To 255
            sReaderList = sReaderList + vbNullChar
        Next

        ReaderCount = 255

        retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, hContext)

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
            displayOut(1, retCode, "", New ListBox)
            Exit Sub
        End If

        retCode = ModWinsCard.SCardListReaders(hContext, "", sReaderList, ReaderCount)

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
            displayOut(1, retCode, "", New ListBox)
            Exit Sub

        End If

        Dim SmartCardReaders(9) As String
        LoadListToControl(SmartCardReaders, sReaderList)

        For Each strReader As String In SmartCardReaders
            If Not strReader Is Nothing Then
                cboCardReader.Items.Add(strReader)
            End If
        Next
    End Sub

    Public Sub LoadListToControl(ByVal Readers As String(), ByVal ReaderList As String)

        Dim sTemp As String
        Dim indx As Integer
        Dim ctr As String = 0

        indx = 1
        sTemp = ""

        While (Mid(ReaderList, indx, 1) <> vbNullChar)

            While (Mid(ReaderList, indx, 1) <> vbNullChar)
                sTemp = sTemp + Mid(ReaderList, indx, 1)
                indx = indx + 1
            End While
            Readers(ctr) = sTemp
            indx = indx + 1
            sTemp = ""
            ctr += 1
        End While

    End Sub

    Private Sub GetInstalledPrinters()
        cboPrinter.Items.Clear()
        For Each strPrinter As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            If strPrinter.ToUpper.Contains("EVOLIS") Then
                cboPrinter.Items.Add(strPrinter)
            End If
        Next
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If MessageBox.Show("Are you sure you want to save changes?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SaveSettings()
            SaveElements()

            MessageBox.Show("Changes has been saved", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhoto_X.KeyPress, txtPhoto_Y.KeyPress,
                                                                                    txtPhoto_Width.KeyPress, txtPhoto_Height.KeyPress,
                                                                                    txtSign_X.KeyPress, txtSign_Y.KeyPress,
                                                                                    txtSign_Width.KeyPress, txtSign_Height.KeyPress,
                                                                                    txtName_X.KeyPress, txtName_Y.KeyPress,
                                                                                    txtCIF_X.KeyPress, txtCIF_Y.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        Dim fbd As New FolderBrowserDialog
        If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtCapturedData.Text = fbd.SelectedPath
        End If
        fbd.Dispose()
        fbd = Nothing
    End Sub

    Private Sub btnBrowseSignature_Click(sender As Object, e As EventArgs)
        System.Diagnostics.Process.Start("Explorer", Application.StartupPath & "\Images")

        'Dim ofd As New OpenFileDialog
        'ofd.InitialDirectory = Application.StartupPath & "\Images"
        'If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    If System.IO.File.Exists(ofd.FileName) Then picSignaturePresident.Image = Image.FromStream(New System.IO.MemoryStream(System.IO.File.ReadAllBytes(ofd.FileName)))
        'End If
        'ofd.Dispose()
        'ofd = Nothing
    End Sub

    Private Sub btnTestCon_Click(sender As Object, e As EventArgs) Handles btnTestCon.Click
        'Dim ConStr As String = "Server=" & txtServer.Text & ";Database=" & txtDatabase.Text & ";User=" & txtUser.Text & ";Password=" & txtPassword.Text & ";"
        'Dim DAL As New DAL
        'If DAL.IsConnectionOK(ConStr) Then
        '    MessageBox.Show("Connection is success...", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    MessageBox.Show("Connection is failed...", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        'DAL.Dispose()
        'DAL = Nothing
    End Sub
End Class