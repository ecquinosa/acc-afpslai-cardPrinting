
Imports accAfpslaiEmvObjct

Public Class Main

    Private DataID As Integer = 0

    Private IsNotIdle As Boolean = False
    Private IdleCounter As Integer = 0

    Public dcsUser As user = Nothing
    Public cfp As cardForPrint = Nothing
    Public msa As MiddleServerApi
    Public cardElements As CardElements

    Public Shared logger As NLog.Logger = NLog.LogManager.GetCurrentClassLogger()

    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text &= GetAppVersion()

        msa = New MiddleServerApi(My.Settings.MiddleServerUrl, My.Settings.ApiKey, My.Settings.BranchIssue, MiddleServerApi.afpslaiEmvSystem.cps)
        Dim li As New LogIN
        li.ShowDialog()

        If li.IsSuccess Then
            SessionIsAlive()

            logger.Info(String.Format("{0} login", dcsUser.userName))

            lblHeader.Text = String.Format("USER: {0}   |   ROLE: {1}   |   {2}", dcsUser.fullName, dcsUser.roleDesc, Date.Now.ToString("MMMM dd, yyyy"))
            If dcsUser.roleId = 2 Then pbSetting.Visible = True Else pbSetting.Visible = False

            cardElements = New CardElements

            CheckForIllegalCrossThreadCalls = False
            StartThread()

            PopulatePrintingType()
            PopulateReplaceReason()

            If cboReport.Items.Count > 0 Then cboReport.SelectedIndex = 0

            txtCIF.SelectAll()
            txtCIF.Focus()
            grid.AutoGenerateColumns = True
        Else
            Close()
            Environment.Exit(0)
        End If
    End Sub

    Private Function CompleteName() As String
        'Return txtFirst_Write.Text

        Dim middlename As String = ""
        Dim suffix As String = ""
        If txtMiddle.Text.Trim <> "" Then middlename = " " & txtMiddle.Text.Substring(0, 1) & "."
        If txtSuffix.Text.Trim <> "" Then suffix = " " & txtSuffix.Text
        Return String.Format("{0}{1}{2}{3}", txtFirst.Text, middlename, " " & txtLast.Text, suffix)
    End Function

    Private Sub PrintCard()
        Try
            Dim pc As New PrintCard
            If chkPreview.Checked Then
                pc.Preview()
            Else
                pc.Print()
            End If
            pc = Nothing
            logger.Info(String.Format("CIF {0} - successfully sent to printer", cfp.cif))
        Catch ex As Exception
            Main.logger.Error(String.Format("CIF {0} - {1}", cfp.cif, ex.Message))
        End Try

    End Sub

    Private Sub btnProcessCard_Click(sender As System.Object, e As System.EventArgs) Handles btnProcessCard.Click
        SessionIsAlive()

        If txtCIF.Text = "" Then Return

        If MessageBox.Show("Are you sure you want to proceed?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            ControlDispo(True)
            Exit Sub
        End If

        ControlDispo(False)

        logger.Info(String.Format("CIF {0} - start of perso process", cfp.cif))

        'FeedCard()

        'cfp.cardNo =txt
        cfp.card_valid_thru = "2405"
        PrintCard()
        Return

        Dim meap As New MagEncoding
        Try
            If meap.ReadTracks() Then
                Dim track2 As String = meap.TrackRead(1)

                If track2.Contains("=") Then

                    cfp.cardNo = track2.Split("=")(0)
                    cfp.card_valid_thru = track2.Split("=")(1).Substring(0, 4)
                    ShowPreview = True
                    pic1.Refresh()

                    logger.Info(String.Format("CIF {0} - printer read card track " & Microsoft.VisualBasic.Right(cfp.cardNo, 4), cfp.cif))

                    System.Threading.Thread.Sleep(1000)
                    Application.DoEvents()

                    If AddCard() Then
                        If PushToCMS() Then
                            If txtDatePrinted.Text <> "" Then
                                If MessageBox.Show("Card has been issued to this record before. Continue?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return
                                Dim cc As New cancelCapture
                                cc.cardId = cfp.cardId
                                Dim responseCancelCapture = msa.cancelCapture(cc)
                                logger.Info(String.Format("{0} proceeded to recard cif {1}. cancelCapture response for cardId {2} is {3}", dcsUser.userName, cfp.cif, cfp.cardId, responseCancelCapture))
                            End If

                            PrintCard()
                        End If
                    End If

                Else
                    logger.Error(String.Format("CIF {0} - Card's mag data is invalid {1}", cfp.cif, track2))
                    Utilities.ShowWarningMessage("Card's mag data is invalid '" & track2 & "'.")
                    EjectCard()
                End If
            Else
                logger.Error(String.Format("CIF {0} - Failed to read card's mag data", cfp.cif))
                Utilities.ShowWarningMessage("Failed to read card's mag data.")
                EjectCard()
            End If
        Catch ex As Exception
            Main.logger.Error(String.Format("CIF {0} - {1}", cfp.cif, ex.Message))
            Utilities.ShowErrorMessage(ex.Message)
            EjectCard()
        Finally
            meap = Nothing
            ControlDispo(True)
        End Try
    End Sub

    Private Sub SystemStatus(ByVal status As String, Optional intType As Short = 0)
        Select Case intType
            Case 0
                TextBox1.ForeColor = Color.Black
            Case 1
                TextBox1.ForeColor = Color.Green
            Case 2
                TextBox1.ForeColor = Color.OrangeRed
        End Select

        TextBox1.Text = status.ToUpper
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        SessionIsAlive()
        txtCIF.Clear()
        ResetForm()
    End Sub

    Private Sub btnInsertCard_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertCard.Click
        SessionIsAlive()
        FeedCard()
    End Sub

    Private Sub FeedCard()
        Dim meap As New MagEncoding
        meap.FeedCard()
        meap = Nothing
    End Sub

    Private Sub EjectCard()
        Dim meap As New MagEncoding
        meap.EjectCard()
        meap = Nothing
    End Sub

    Private Sub ReadCardMags()
        Dim meap As New MagEncoding
        If meap.ReadTracks() Then
            'read cardNo and validThru from card
            'cfp.cardNo = "1234567890123456"
            'cfp.card_valid_thru = "2501"
            Dim track2 As String = meap.TrackRead(1)

            If track2.Contains("=") Then
                cfp.cardNo = track2.Split("=")(0)
                cfp.card_valid_thru = track2.Split("=")(1).Substring(0, 4)
                ShowPreview = True
                pic1.Refresh()
            Else
                Utilities.ShowWarningMessage("Card's mag data is invalid '" & track2 & "'.")
            End If
        Else
            Utilities.ShowWarningMessage("Failed to read card's mag data.")
        End If
        meap = Nothing
    End Sub

    Private Sub btnEjectCard_Click(sender As System.Object, e As System.EventArgs) Handles btnEjectCard.Click
        SessionIsAlive()
        EjectCard()
    End Sub

    Private Function GetPrinterCounter() As Integer
        Try
            Dim meap As New MagEncoding
            Dim intCntr As String = meap.GetPrinterCounter()
            meap = Nothing
            If IsNumeric(intCntr) Then
                Return intCntr
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub pbSetting_Click(sender As System.Object, e As System.EventArgs) Handles pbSetting.Click
        Dim frm As New Setting
        frm.ShowDialog()
    End Sub

    Private Sub ControlDispo(ByVal bln As Boolean)
        btnProcessCard.Enabled = bln
        btnInsertCard.Enabled = bln
        btnEjectCard.Enabled = bln
        btnReset.Enabled = bln

        If bln Then
            Cursor = Cursors.Default
        Else
            Cursor = Cursors.WaitCursor
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        SessionIsAlive()

        Dim branch As String = My.Settings.BranchIssue
        If dcsUser.roleId = 2 Then branch = ""
        Dim obj As Object
        Select Case cboReport.SelectedIndex
            Case 0
            Case 1
                If msa.GetMembersPrintingTypeSummary(branch, dtpStart.Value.Date, dtpEnd.Value.Date, obj) Then
                    Dim data = obj
                    grid.DataSource = data
                End If
            Case 2
                If msa.GetMembersRecardReasonSummary(branch, dtpStart.Value.Date, dtpEnd.Value.Date, obj) Then
                    Dim data = obj
                    grid.DataSource = data
                End If
            Case 3
                If msa.GetMember(0, "", branch, obj) Then
                    Dim data = obj
                    grid.DataSource = data
                End If
        End Select

        If grid.Rows.Count = 0 Then
            btnExtract.Visible = False
        Else
            btnExtract.Visible = True
        End If
    End Sub

    Private Sub btnExtract_Click(sender As System.Object, e As System.EventArgs) Handles btnExtract.Click
        SessionIsAlive()

        Dim sb As New System.Text.StringBuilder
        Dim sbHeader As New System.Text.StringBuilder
        Dim IsHeaderComplete As Boolean = False

        Dim strRange As String = String.Format("{0} to {1}", dtpStart.Value.ToString("MMM dd, yyyy"), dtpEnd.Value.ToString("MMM dd, yyyy"))

        Dim strReportHeader As String = "AFPSLAI - CAPTURED DATA REPORT" & vbNewLine & strRange & vbNewLine & "TOTAL: " & grid.Rows.Count.ToString("N0") & vbNewLine & vbNewLine

        Select Case cboReport.SelectedIndex
            Case 0
            Case 1
                strReportHeader = "AFPSLAI - CAPTURED DATA SUMMARY REPORT - PRINT TYPE"
            Case 2
                strReportHeader = "AFPSLAI - CAPTURED DATA SUMMARY REPORT - REPLACE CARDS"
            Case Else
                strReportHeader = "AFPSLAI - CAPTURED DATA REPORT"
        End Select

        Report.GenerateReport(grid, strReportHeader, strRange)

        MessageBox.Show("Done", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private ShowPreview As Boolean = False

    Private Sub pic1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pic1.Paint
        If ShowPreview Then
            If cfp.memberId > 0 Then
                Dim imgPhoto As Image = Nothing

                'If System.IO.File.Exists(PhotoPath) Then
                imgPhoto = Image.FromStream(New System.IO.MemoryStream(Convert.FromBase64String(cfp.base64Photo)))
                e.Graphics.DrawImage(imgPhoto, 357, 25, 92, 85)
                'e.Graphics.DrawImage(imgPhoto, Convert.ToInt32(txtX.Text), Convert.ToInt32(txtY.Text), Convert.ToInt32(txtWidth.Text), Convert.ToInt32(txtHeight.Text))
                'End If

                Dim fontCard As New Font("OCRB", 20, FontStyle.Bold)
                Dim fontHightlight As New Font("OCRB", 15, FontStyle.Bold)
                Dim fontGeneric As New Font("OCRB", 13)
                Dim dBlack As New SolidBrush(Color.Black)

                Dim intLeft As Integer = Convert.ToInt32(txtX.Text)
                Dim intTop As Integer = Convert.ToInt32(txtY.Text)

                Dim cardNo As String = cfp.cardNo
                If cardNo <> "" Then e.Graphics.DrawString(String.Format("{0} {1} {2} {3}", cardNo.Substring(0, 4), cardNo.Substring(4, 4), cardNo.Substring(8, 4), cardNo.Substring(12, 4)), fontCard, New SolidBrush(Color.White), intLeft + 17, intTop - 70)
                e.Graphics.DrawString(Convert.ToDateTime(txtMembershipDate.Text).ToString("MM/yy"), fontGeneric, dBlack, intLeft + 40, intTop - 27)
                If cfp.card_valid_thru <> "" Then e.Graphics.DrawString(String.Format("{0}/{1}", cfp.card_valid_thru.Substring(2, 2), cfp.card_valid_thru.Substring(0, 2)), fontGeneric, dBlack, intLeft + 150, intTop - 27)

                e.Graphics.DrawString(txtCardName.Text, fontHightlight, dBlack, intLeft, intTop)
                e.Graphics.DrawString(txtCIF.Text, fontGeneric, dBlack, intLeft, intTop + 25)
                ShowPreview = False
            End If
        End If
    End Sub

    Private Sub txtCIF_Write_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIF.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Button3.PerformClick()
        End If
    End Sub

    Private Sub SessionIsAlive()
        IsNotIdle = True
        IdleCounter = 1
    End Sub

    Private _thread As System.Threading.Thread

    Private Sub StartThread()
        Dim objNewThread As New System.Threading.Thread(AddressOf SessionChecker)
        objNewThread.IsBackground = True
        objNewThread.Start()
        _thread = objNewThread
    End Sub

    Private Sub SessionChecker()
        Do While True
            If IdleCounter = 180 Then
                If IsNotIdle Then
                    IsNotIdle = False
                    MessageBox.Show("No activities detected. System will be closed", "SESSION EXPIRED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Application.Exit()
                    Close()
                End If
            Else
                IdleCounter += 1
                System.Threading.Thread.Sleep(1000)
            End If
        Loop
    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        ''PrintCard()
        'GenerateBarcode(txtCIF_Write.Text)
        'Dim pc As New PrintCard(fingerprints, txtCIF_Write.Text, CompleteName, txtAddress.Text, txtContactNos.Text, txtDOB_Write.Text, txtIDNumber_Write.Text, txtDateIssued_Write.Text, txtContactName.Text, txtContactContactNos.Text, txtBranchIssued_Write.Text, PhotoPath, SignaturePath, BarcodeJPG, chkIncludeIdTemplate.Checked.ToString)
        'pc.X = txtX.Text
        'pc.Y = txtY.Text
        'pc.imgWidth = txtWidth.Text
        'pc.imgHeight = txtHeight.Text
        'If chkPreview.Checked Then
        '    pc.Preview()
        'Else
        '    pc.Print()
        'End If
    End Sub

    Private Sub cboReport_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboReport.SelectedIndexChanged
        SessionIsAlive()

        Try
            Select Case cboReport.SelectedIndex
                Case 0
                    cboPrintingType.Enabled = False
                    cboReason.Enabled = False
                    dtpStart.Enabled = False
                    dtpEnd.Enabled = False
                Case 1, 2
                    cboPrintingType.Enabled = False
                    cboReason.Enabled = False
                    dtpStart.Enabled = True
                    dtpEnd.Enabled = True
                Case Else
                    cboPrintingType.Enabled = True
                    dtpStart.Enabled = True
                    dtpEnd.Enabled = True
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboPrintingType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPrintingType.SelectedIndexChanged
        Try
            If cboPrintingType.SelectedValue = 2 Then
                cboReason.Enabled = True
            Else
                cboReason.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Main_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        Invoke(New Action(AddressOf SessionIsAlive))
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        SessionIsAlive()
        ResetForm()

        If txtCIF.Text = "" Then
            MessageBox.Show("Please enter CIF to search...", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        BindData()
    End Sub

    Private Sub PopulatePrintingType()
        Dim obj As Object
        If msa.GetTable(MiddleServerApi.msApi.getPrintType, obj) Then
            Dim printTypes = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of print_type))(obj.ToString())
            printTypes.Insert(0, New print_type With {
        .id = 0,
        .printType = "-Select-"
    })
            cboPrintingType.DataSource = printTypes
            cboPrintingType.DisplayMember = "printType"
            cboPrintingType.ValueMember = "id"
            cboPrintingType.SelectedIndex = 0
        End If
    End Sub

    Private Sub PopulateReplaceReason()
        Dim obj As Object
        If msa.GetTable(MiddleServerApi.msApi.getRecardReason, obj) Then
            Dim replaceReasons = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of recard_reason))(obj.ToString())
            replaceReasons.Insert(0, New recard_reason With {
        .id = 0,
        .recardReason = "-Select-"
    })
            cboReason.DataSource = replaceReasons
            cboReason.DisplayMember = "recardReason"
            cboReason.ValueMember = "id"
            cboReason.SelectedIndex = 0
        End If
    End Sub

    Private Function PushToCMS() As Boolean
        Dim cbsCms As New cbsCms
        cbsCms.cardId = cfp.cardId
        cbsCms.memberId = cfp.memberId
        cbsCms.cardNo = cfp.cardNo
        cbsCms.cif = cfp.cif
        cbsCms.mobileNo = cfp.mobileNo
        cbsCms.branchId = cfp.branch_issued
        cbsCms.terminalId = cfp.terminalId
        cbsCms.timeStamp = Date.Now
        Dim response As Boolean = msa.PushCMSData(cbsCms)
        cbsCms = Nothing
        If response Then
            logger.Info(String.Format("CIF {0} - pushToCMS response {1}", cfp.cif, response))
        Else
            logger.Error(String.Format("CIF {0} - pushToCMS response {1}", cfp.cif, response))
        End If
        Return response
    End Function

    Private Function AddCard() As Boolean
        Dim card As New card
        card.member_id = cfp.memberId
        card.cardNo = cfp.cardNo
        Dim response As Boolean = msa.addCard(card, cfp.cardId)
        card = Nothing
        If response Then
            logger.Info(String.Format("CIF {0} - addCard response {1}", cfp.cif, response))
        Else
            logger.Error(String.Format("CIF {0} - addCard response {1}", cfp.cif, response))
        End If
        Return response
    End Function

    Private Sub BindData()
        cfp = New cardForPrint
        Dim obj As Object
        If msa.GetCardForPrint(txtCIF.Text, obj) Then
            cfp = Newtonsoft.Json.JsonConvert.DeserializeObject(Of cardForPrint)(obj.ToString)
            txtFirst.Text = cfp.first_name
            txtMiddle.Text = cfp.middle_name
            txtLast.Text = cfp.last_name
            txtSuffix.Text = cfp.suffix
            txtCardName.Text = cfp.cardName
            txtGender.Text = cfp.gender
            txtMembershipDate.Text = cfp.membership_date
            txtBranchIssued.Text = cfp.branch_issued
            txtDateCaptured.Text = cfp.dateCaptured
            txtDatePrinted.Text = cfp.datePrinted

            If String.IsNullOrEmpty(cfp.cardNo) Then
                cfp.cardNo = "0000000000000000"
                cfp.card_valid_thru = "0000"
            Else
                cfp.cardNo = cfp.cardNo
                cfp.card_valid_thru = ""
            End If

            If txtBranchIssued.Text = "" Then txtBranchIssued.Text = "AGUINALDO"
            logger.Info(String.Format("{0} searched cif {1}", dcsUser.userName, cfp.cif))
        End If

        ShowPreview = True
        pic1.Refresh()
    End Sub

    Private Sub ResetForm()
        DataID = 0
        txtFirst.Clear()
        txtMiddle.Clear()
        txtLast.Clear()
        txtSuffix.Clear()
        txtMembershipDate.Clear()
        txtGender.Clear()
        txtBranchIssued.Clear()
        txtDateCaptured.Clear()
        txtDatePrinted.Clear()

        ShowPreview = False
        pic1.Refresh()
    End Sub

    Private Function GetAppVersion() As String
        Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim fvi As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location)
        Return String.Format(" v{0}", fvi.FileVersion)
    End Function

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        logger.Info(String.Format("{0} logout", dcsUser.userName))
    End Sub

End Class
