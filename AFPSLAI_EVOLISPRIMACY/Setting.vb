
Public Class Setting

    Private Sub Setting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetInstalledPrinters()

        PopulateBranch()

        BindElementType(cboPhoto_Type)
        BindElementType(cboMemberSince_Type)
        BindElementType(cboValidThru_Type)
        BindElementType(cboName_Type)
        BindElementType(cboCIF_Type)

        cboPhoto_Type.SelectedIndex = 2
        cboMemberSince_Type.SelectedIndex = 1
        cboValidThru_Type.SelectedIndex = 1
        cboName_Type.SelectedIndex = 1
        cboCIF_Type.SelectedIndex = 1

        cboMemberSince_Style.SelectedIndex = 1
        cboValidThru_Style.SelectedIndex = 1
        cboName_Style.SelectedIndex = 1
        cboCIF_Style.SelectedIndex = 1

        BindSettings()

        cboMemberSince_Style.SelectedIndex = 0
        cboValidThru_Style.SelectedIndex = 0
        cboName_Style.SelectedIndex = 0
        cboCIF_Style.SelectedIndex = 0
    End Sub

    Private Sub PopulateBranch()
        Dim obj As Object
        If Main.msa.GetTable(accAfpslaiEmvObjct.MiddleServerApi.msApi.getBranch, obj) Then
            Dim printTypes = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of accAfpslaiEmvObjct.branch))(obj.ToString())
            printTypes.Insert(0, New accAfpslaiEmvObjct.branch With {
        .id = 0,
        .branchName = "-Select-"
    })
            cboBranch.DataSource = printTypes
            cboBranch.DisplayMember = "branchName"
            cboBranch.ValueMember = "id"
            cboBranch.SelectedIndex = 0
        End If
    End Sub

    Private Sub BindElementType(ByVal cbo As ComboBox)
        cbo.Items.Add("-Select-")
        cbo.Items.Add("String")
        cbo.Items.Add("Image")
        cbo.SelectedIndex = 0
    End Sub

    Private Sub BindSettings()
        cboPrinter.SelectedIndex = cboPrinter.FindStringExact(My.Settings.CardPrinter)
        txtServer.Text = My.Settings.MiddleServerUrl
        cboBranch.SelectedValue = cboBranch.FindString(My.Settings.BranchIssue)
        txtApiKey.Text = My.Settings.ApiKey

        Main.logger.Info(String.Concat(Main.dcsUser.userName, " load settings. ", "Middle server Url: ", My.Settings.MiddleServerUrl, ", Branch: ", My.Settings.BranchIssue, ", Printer: ", My.Settings.CardPrinter))
        Main.logger.Info("Load Key: ", My.Settings.ApiKey)

        Dim objPhoto = Main.cardElements.Photo
        Dim objMemberSince = Main.cardElements.MemberSince
        Dim objValidThru = Main.cardElements.ValidThru
        Dim objName = Main.cardElements.Name
        Dim objCIF = Main.cardElements.CIF

        If Not objPhoto Is Nothing Then
            txtPhoto_X.Text = objPhoto.x
            txtPhoto_Y.Text = objPhoto.y
            txtPhoto_Width.Text = objPhoto.width
            txtPhoto_Height.Text = objPhoto.height
            cboPhoto_Type.SelectedIndex = cboPhoto_Type.FindString(objPhoto.element_type)
        End If

        If Not objMemberSince Is Nothing Then
            txtMemberSince_X.Text = objMemberSince.x
            txtMemberSince_Y.Text = objMemberSince.y
            txtMemberSince_Width.Text = objMemberSince.width
            txtMemberSince_Height.Text = objMemberSince.height
            txtMemberSince_Font.Text = objMemberSince.font_name
            txtMemberSince_Size.Text = objMemberSince.font_size
            cboMemberSince_Style.SelectedIndex = cboMemberSince_Style.FindString(objMemberSince.font_style)
            cboMemberSince_Type.SelectedIndex = cboMemberSince_Type.FindString(objMemberSince.element_type)
        End If

        If Not objValidThru Is Nothing Then
            txtValidThru_X.Text = objValidThru.x
            txtValidThru_Y.Text = objValidThru.y
            txtValidThru_Width.Text = objValidThru.width
            txtValidThru_Height.Text = objValidThru.height
            txtValidThru_Font.Text = objValidThru.font_name
            txtValidThru_Size.Text = objValidThru.font_size
            cboValidThru_Style.SelectedIndex = cboValidThru_Style.FindString(objValidThru.font_style)
            cboValidThru_Type.SelectedIndex = cboValidThru_Type.FindString(objValidThru.element_type)
        End If

        If Not objName Is Nothing Then
            txtName_X.Text = objName.x
            txtName_Y.Text = objName.y
            txtName_Width.Text = objName.width
            txtName_Height.Text = objName.height
            txtName_Font.Text = objName.font_name
            txtName_Size.Text = objName.font_size
            cboName_Style.SelectedIndex = cboName_Style.FindString(objName.font_style)
            cboName_Type.SelectedIndex = cboName_Type.FindString(objName.element_type)
        End If

        If Not objCIF Is Nothing Then
            txtCIF_X.Text = objCIF.x
            txtCIF_Y.Text = objCIF.y
            txtCIF_Width.Text = objCIF.width
            txtCIF_Height.Text = objCIF.height
            txtCIF_Font.Text = objCIF.font_name
            txtCIF_Size.Text = objCIF.font_size
            cboCIF_Style.SelectedIndex = cboCIF_Style.FindString(objCIF.font_style)
            cboCIF_Style.SelectedIndex = cboCIF_Style.FindString(objCIF.element_type)
        End If


    End Sub

    Private Sub SaveSettings()
        Dim middleServerUrl As String = txtServer.Text.Trim
        Dim lastChar As String = middleServerUrl.Substring(middleServerUrl.Length - 1, 1)
        If lastChar = "/" Then middleServerUrl = middleServerUrl.Substring(0, middleServerUrl.Length - 1)

        Dim sbSettings As New System.Text.StringBuilder
        If cboBranch.Text <> My.Settings.BranchIssue Then sbSettings.Append(". Changed branch to " & cboBranch.Text)
        If cboPrinter.Text <> My.Settings.CardPrinter Then sbSettings.Append(". Changed printer to " & cboPrinter.Text)
        If middleServerUrl <> My.Settings.MiddleServerUrl Then sbSettings.Append(". Changed url to " & middleServerUrl)
        If txtApiKey.Text <> My.Settings.ApiKey Then sbSettings.Append(". Changed api key to " & txtApiKey.Text)

        Dim logDesc As String = ""
        If sbSettings.ToString <> "" Then _
            logDesc = String.Concat(Main.dcsUser.userName, " clicked save button settings", sbSettings.ToString, ".")

        'If TabControl1.SelectedTab.Text = "MAIN" Then
        If cboPrinter.Text <> "" Then My.Settings.CardPrinter = cboPrinter.Text

        My.Settings.MiddleServerUrl = middleServerUrl
        My.Settings.BranchIssue = cboBranch.Text
        My.Settings.ApiKey = txtApiKey.Text

        Main.logger.Info(String.Concat(logDesc))

        My.Settings.Save()
        My.Settings.Reload()


        Main.MiddleServerUrlDisplay()
        'ElseIf TabControl1.SelectedTab.Text = "CARD" Then
        Dim cces As New List(Of accAfpslaiEmvObjct.cps_card_elements)
        Dim ccePhoto As New accAfpslaiEmvObjct.cps_card_elements
        Dim cceMemberSince As New accAfpslaiEmvObjct.cps_card_elements
        Dim cceValidThru As New accAfpslaiEmvObjct.cps_card_elements
        Dim cceName As New accAfpslaiEmvObjct.cps_card_elements
        Dim cceCIF As New accAfpslaiEmvObjct.cps_card_elements

        CreateCardElement(cboPhoto_Type.Text,
                          [Enum].GetName(GetType(accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement), accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement.photo),
                          CInt(txtPhoto_X.Text), CInt(txtPhoto_Y.Text), CInt(txtPhoto_Width.Text), CInt(txtPhoto_Height.Text),
                          ccePhoto)

        CreateCardElement(cboMemberSince_Type.Text,
                          [Enum].GetName(GetType(accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement), accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement.memberSince),
                          CInt(txtMemberSince_X.Text), CInt(txtMemberSince_Y.Text), CInt(txtMemberSince_Width.Text), CInt(txtMemberSince_Height.Text),
                          cceMemberSince,
                          txtMemberSince_Font.Text, CInt(txtMemberSince_Size.Text), CInt(cboMemberSince_Style.SelectedValue))


        CreateCardElement(cboValidThru_Type.Text,
                          [Enum].GetName(GetType(accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement), accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement.validThru),
                          CInt(txtValidThru_X.Text), CInt(txtValidThru_Y.Text), CInt(txtValidThru_Width.Text), CInt(txtValidThru_Height.Text),
                          cceValidThru,
                          txtValidThru_Font.Text, CInt(txtValidThru_Size.Text), CInt(cboValidThru_Style.SelectedValue))

        CreateCardElement(cboName_Type.Text,
                          [Enum].GetName(GetType(accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement), accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement.name),
                          CInt(txtName_X.Text), CInt(txtName_Y.Text), CInt(txtName_Width.Text), CInt(txtName_Height.Text),
                          cceName,
                          txtName_Font.Text, CInt(txtName_Size.Text), CInt(cboName_Style.SelectedValue))

        CreateCardElement(cboCIF_Type.Text,
                          [Enum].GetName(GetType(accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement), accAfpslaiEmvObjct.MiddleServerApi.cpsCardElement.cif),
                          CInt(txtCIF_X.Text), CInt(txtCIF_Y.Text), CInt(txtCIF_Width.Text), CInt(txtCIF_Height.Text),
                          cceCIF,
                          txtCIF_Font.Text, CInt(txtCIF_Size.Text), CInt(cboCIF_Style.SelectedValue))

        cces.Add(ccePhoto)
        cces.Add(cceMemberSince)
        cces.Add(cceValidThru)
        cces.Add(cceName)
        cces.Add(cceCIF)

        For Each cce In cces
            Main.msa.AddCPSCardElements(cce)
        Next

        If logDesc <> "" Then
            Dim sl As New accAfpslaiEmvObjct.system_log
            If logDesc.Length <= 500 Then
                sl.log_desc = String.Concat("Branch ", My.Settings.BranchIssue, ". ", logDesc)
            Else
                sl.log_desc = String.Concat("Branch ", My.Settings.BranchIssue, ". ", logDesc.Substring(0, 500))
            End If
            Main.msa.saveSystemLog(sl)
        End If

        Main.cardElements.Populate()
        'End If
    End Sub

    Private Sub CreateCardElement(ByVal elementType As String, ByVal element As String, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer,
                                  ByRef cce As accAfpslaiEmvObjct.cps_card_elements, Optional ByVal fontName As String = "", Optional ByVal fontSize As Integer = 0, Optional ByVal fontStyle As Integer = 0)
        cce.element_type = elementType
        cce.element = element
        cce.x = x
        cce.y = y
        cce.width = width
        cce.height = height
        If elementType = "String" Then
            cce.font_name = fontName
            cce.font_size = fontSize
            cce.font_style = fontStyle
        End If
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

            MessageBox.Show("Changes has been saved", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhoto_X.KeyPress, txtPhoto_Y.KeyPress,
                                                                                    txtPhoto_Width.KeyPress, txtPhoto_Height.KeyPress,
                                                                                    txtMemberSince_X.KeyPress, txtMemberSince_Y.KeyPress,
                                                                                    txtMemberSince_Width.KeyPress, txtMemberSince_Height.KeyPress,
                                                                                    txtName_X.KeyPress, txtName_Y.KeyPress,
                                                                                    txtCIF_X.KeyPress, txtCIF_Y.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
        End If
    End Sub

    Private Sub btnTestCon_Click(sender As Object, e As EventArgs) Handles btnTestCon.Click
        If Main.msa.checkServerDBStatus(txtServer.Text) Then
            SharedFunction.ShowInfoMessage("Connection success.")
        Else
            SharedFunction.ShowWarningMessage("Connection failed.")
        End If
    End Sub

    Private Sub cboMemberSince_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMemberSince_Type.SelectedIndexChanged
        If cboMemberSince_Type.Text = "String" Then
            txtMemberSince_Font.Enabled = True
            txtMemberSince_Size.Enabled = True
            cboMemberSince_Style.Enabled = True
        Else
            txtMemberSince_Font.Enabled = False
            txtMemberSince_Size.Enabled = False
            cboMemberSince_Style.Enabled = False
        End If

    End Sub

    Private Sub cboValidThru_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboValidThru_Type.SelectedIndexChanged
        If cboValidThru_Type.Text = "String" Then
            txtValidThru_Font.Enabled = True
            txtValidThru_Size.Enabled = True
            cboValidThru_Style.Enabled = True
        Else
            txtValidThru_Font.Enabled = False
            txtValidThru_Size.Enabled = False
            cboValidThru_Style.Enabled = False
        End If
    End Sub

    Private Sub cboName_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboName_Type.SelectedIndexChanged
        If cboName_Type.Text = "String" Then
            txtName_Font.Enabled = True
            txtName_Size.Enabled = True
            cboName_Style.Enabled = True
        Else
            txtName_Font.Enabled = False
            txtName_Size.Enabled = False
            cboName_Style.Enabled = False
        End If
    End Sub

    Private Sub cboCIF_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCIF_Type.SelectedIndexChanged
        If cboCIF_Type.Text = "String" Then
            txtCIF_Font.Enabled = True
            txtCIF_Size.Enabled = True
            cboCIF_Style.Enabled = True
        Else
            txtCIF_Font.Enabled = False
            txtCIF_Size.Enabled = False
            cboCIF_Style.Enabled = False
        End If
    End Sub
End Class