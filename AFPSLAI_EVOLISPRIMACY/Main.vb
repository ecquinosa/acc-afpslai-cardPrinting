
Imports accAfpslaiEmvObjct

Public Class Main

    Private DataID As Integer = 0

    Private PhotoPath As String = "" '"E:\Projects\DCS2015\DCS2015\bin\Debug\Captured Data\05052017\3333322222222\3333322222222_Photo.jpg"

    Private BarcodeJPG As String = "tempBarcode.jpg"
    Private lPrimaryJpg As String = ""
    Private rPrimaryJpg As String = ""
    Private lBackupJpg As String = ""
    Private rBackupJpg As String = ""

    Private IsNotIdle As Boolean = False
    Private IdleCounter As Integer = 0

    Private TerminalID As String = ""
    Private BranchCode As String = ""
    Private fingerprints As New List(Of String)

    Public dcsUser As user = Nothing
    Public cfp As cardForPrint = Nothing
    Public msa As MiddleServerApi
    Public cardElements As CardElements


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
        'Dim DAL As New DAL
        'If DAL.SelectQuery("SELECT 0 As PrintingTypeID, '-SELECT-' As PrintingType UNION SELECT PrintingTypeID, PrintingType FROM tblPrintingType WHERE ISNULL(IsDeleted,0)=0") Then
        '    cboPrintingType.DataSource = DAL.TableResult
        '    cboPrintingType.ValueMember = "PrintingTypeID"
        '    cboPrintingType.DisplayMember = "PrintingType"
        'End If
        'DAL.Dispose()
        'DAL = Nothing
    End Sub

    Private Sub PopulateReplaceReason()
        'Dim DAL As New DAL
        'If DAL.SelectQuery("SELECT 0 As ReasonID, '-SELECT-' As Reason UNION SELECT ReasonID, Reason FROM tblReplaceReason WHERE ISNULL(IsDeleted,0)=0") Then
        '    cboReason.DataSource = DAL.TableResult
        '    cboReason.ValueMember = "ReasonID"
        '    cboReason.DisplayMember = "Reason"
        'End If
        'DAL.Dispose()
        'DAL = Nothing
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
        Return response
    End Function

    Private Function AddCard() As Boolean
        Dim card As New card
        card.member_id = cfp.memberId
        card.cardNo = cfp.cardNo
        Dim response As Boolean = msa.addCard(card, cfp.cardId)
        card = Nothing
        Return response
    End Function

    Private Sub BindData()
        TerminalID = ""
        BranchCode = ""

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

    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text &= GetAppVersion()
        grid2.AutoGenerateColumns = True

        msa = New MiddleServerApi(My.Settings.MiddleServerUrl, My.Settings.ApiKey, My.Settings.BranchIssue, MiddleServerApi.afpslaiEmvSystem.cps)

        Dim li As New LogIN
        li.ShowDialog()

        If li.IsSuccess Then
            SessionIsAlive()

            cardElements = New CardElements

            CheckForIllegalCrossThreadCalls = False
            StartThread()
            'Timer1.Start()

            '   btnGetLastRecord.PerformClick()
            'txtFirst_Write.Text = "ANACLETO JOSEFINO P. BUENCAMINO"

            PopulatePrintingType()
            PopulateReplaceReason()

            If cboReport.Items.Count > 0 Then cboReport.SelectedIndex = 0

            txtCIF.SelectAll()
            txtCIF.Focus()
            grid.AutoGenerateColumns = False

            BindCardElements()
        Else
            Close()
            Environment.Exit(0)
        End If
    End Sub

    Private Sub btnGetLastRecord_Click(sender As System.Object, e As System.EventArgs)
        SessionIsAlive()

        ControlDispo(False)

        ResetForm()

        'Dim DAL As New DAL
        'If DAL.SelectDataByMaxDataID() Then
        '    If DAL.TableResult.DefaultView.Count > 0 Then
        '        BindData(DAL.TableResult.Rows(0))
        '    Else
        '        MessageBox.Show("No record found", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        ResetForm()
        '    End If
        'End If
        'DAL.Dispose()
        'DAL = Nothing

        ControlDispo(True)
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
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub ReadTracks()
    '    Dim magEnc As New MagEncoding()
    '    If magEnc.ReadTracks() Then
    '        'Dim DAL As New DAL
    '        'DAL.ExecuteQuery("UPDATE tblData SET Magencode_Timestamp=GETDATE() WHERE DataID=" & DataID.ToString)
    '        'DAL.InsertRelDataCardActivity(txtCIF_Write.Text, "Mag encoding")
    '        'DAL.Dispose()
    '        'DAL = Nothing
    '    End If
    'End Sub

    Private Sub btnProcessCard_Click(sender As System.Object, e As System.EventArgs) Handles btnProcessCard.Click
        SessionIsAlive()

        If txtCIF.Text = "" Then Return

        If MessageBox.Show("Are you sure you want to proceed?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            ControlDispo(True)
            Exit Sub
        End If

        ControlDispo(False)

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

                    System.Threading.Thread.Sleep(1000)
                    Application.DoEvents()

                    If AddCard() Then
                        If PushToCMS() Then
                            If txtDatePrinted.Text <> "" Then _
                                If MessageBox.Show("Card has been issued to this record before. Continue?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return

                            PrintCard()
                        End If
                    End If

                Else
                    Utilities.ShowWarningMessage("Card's mag data is invalid '" & track2 & "'.")
                    EjectCard()
                End If
            Else
                Utilities.ShowWarningMessage("Failed to read card's mag data.")
                EjectCard()
            End If
        Catch ex As Exception
            Utilities.ShowErrorMessage(ex.Message)
            EjectCard()
        Finally
            meap = Nothing
            ControlDispo(True)
        End Try
    End Sub

    Public Function GenerateBarcode(ByVal strBarcode As String) As Boolean
        Try
            Dim _image As System.Drawing.Image = GenCode128.Code128Rendering.MakeBarcodeImage(strBarcode, 2, True)
            _image.Save(BarcodeJPG, System.Drawing.Imaging.ImageFormat.Jpeg)
            _image.Dispose()
            _image = Nothing

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

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
        BindCardElements()
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

    Private dtData As DataTable

    Private Function GetDTTotal() As Integer
        Dim intCnt As Integer = CInt(dtData.Rows(dtData.DefaultView.Count - 1)("Total"))
        'For Each rw As DataRow In dtData.Rows
        '    intCnt += rw("Total")
        'Next

        Return intCnt
    End Function

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        SessionIsAlive()

        'Dim DAL As New DAL
        'Select Case cboReport.SelectedIndex
        '    Case 0
        '    Case 3
        '        If DAL.SelectPrintingTypeSummary(CDate(dtpStart.Value).ToString("yyyy-MM-dd"), CDate(dtpEnd.Value).ToString("yyyy-MM-dd")) Then
        '            If DAL.TableResult.DefaultView.Count > 0 Then
        '                btnExtract.Visible = True
        '            Else
        '                btnExtract.Visible = False
        '            End If

        '            dtData = DAL.TableResult

        '            Dim intCnt As Integer = 0
        '            For Each rw As DataRow In dtData.Rows
        '                intCnt += rw("Total")
        '            Next

        '            lblTotal.Text = "TOTAL: " & GetDTTotal.ToString("N0") 'dtData.DefaultView.Count.ToString("N0")
        '        End If
        '    Case Else
        '        If DAL.SelectDataByDataTypeIDAndRange(2, dtpStart.Value, dtpEnd.Value) Then
        '            Dim sbFilter As New System.Text.StringBuilder

        '            If DAL.TableResult.DefaultView.Count > 0 Then
        '                btnExtract.Visible = True
        '            Else
        '                btnExtract.Visible = False
        '            End If

        '            If cboPrintingType.SelectedIndex > 0 Then _
        '                sbFilter.Append("PrintingTypeID=" & cboPrintingType.SelectedValue)

        '            If cboPrintingType.SelectedIndex = 2 Then
        '                If sbFilter.ToString <> "" Then sbFilter.Append(" AND ")
        '                sbFilter.Append("ReplaceReason='" & cboReason.Text & "'")
        '            End If


        '            If cboFilter.SelectedIndex = 0 Then
        '                dtData = DAL.TableResult
        '            ElseIf cboFilter.SelectedIndex = 1 Then
        '                'dtData = DAL.TableResult.Select("ISNULL(IsVoid,0)=0").CopyToDataTable
        '                If sbFilter.ToString <> "" Then sbFilter.Append(" AND ")
        '                sbFilter.Append("ISNULL(IsVoid,0)=0")
        '            ElseIf cboFilter.SelectedIndex = 2 Then
        '                'dtData = DAL.TableResult.Select("ISNULL(IsVoid,0)=1").CopyToDataTable
        '                If sbFilter.ToString <> "" Then sbFilter.Append(" AND ")
        '                sbFilter.Append("ISNULL(IsVoid,0)=1")
        '            End If

        '            Try
        '                dtData = DAL.TableResult.Select(sbFilter.ToString).CopyToDataTable
        '            Catch ex As Exception
        '                'dtData = DAL.TableResult.Select(sbFilter.ToString).CopyToDataTable
        '            End Try

        '            lblTotal.Text = "TOTAL: " & dtData.DefaultView.Count.ToString("N0")
        '        End If
        'End Select

        'Select Case cboReport.SelectedIndex
        '    Case 0
        '    Case 1
        '        grid.DataSource = dtData
        '    Case Else
        '        grid2.DataSource = dtData
        'End Select

        'DAL.Dispose()
        'DAL = Nothing
    End Sub

    Private Sub btnExtract_Click(sender As System.Object, e As System.EventArgs) Handles btnExtract.Click
        SessionIsAlive()

        Dim sb As New System.Text.StringBuilder
        Dim sbHeader As New System.Text.StringBuilder
        Dim IsHeaderComplete As Boolean = False

        Dim strRange As String = String.Format("{0} to {1}", dtpStart.Value.ToString("MMM dd, yy"), dtpEnd.Value.ToString("MMM dd, yy"))
        Dim strReportHeader As String = "AFPSLAI - CAPTURED DATA REPORT" & vbNewLine & strRange & vbNewLine & "TOTAL: " & grid.Rows.Count.ToString("N0") & vbNewLine & vbNewLine

        Select Case cboReport.SelectedIndex
            Case 0
            Case 3
                strReportHeader = "AFPSLAI - CAPTURED SUMMARY REPORT" & vbNewLine & strRange & vbNewLine & "TOTAL: " & "TOTAL: " & GetDTTotal.ToString("N0") & vbNewLine & vbNewLine
            Case Else
                strReportHeader = "AFPSLAI - CAPTURED DATA REPORT" & vbNewLine & strRange & vbNewLine & "TOTAL: " & grid.Rows.Count.ToString("N0") & vbNewLine & vbNewLine
        End Select

        Select Case cboReport.SelectedIndex
            Case 0
            Case 1
                For Each gridRow As DataGridViewRow In grid.Rows
                    Dim sbLine As New System.Text.StringBuilder
                    For Each col As DataGridViewColumn In grid.Columns
                        If sbLine.ToString = "" Then
                            If Not IsHeaderComplete Then sbHeader.Append(col.Name)
                            sbLine.Append(gridRow.Cells(col.Name).Value.ToString)
                        Else
                            If Not IsHeaderComplete Then sbHeader.Append(vbTab & col.Name)
                            sbLine.Append(vbTab & gridRow.Cells(col.Name).Value.ToString)
                        End If
                    Next

                    sb.AppendLine(sbLine.ToString)
                    IsHeaderComplete = True
                Next
            Case Else
                For Each rw As DataRow In dtData.Rows
                    Dim sbLine As New System.Text.StringBuilder
                    For Each col As DataColumn In dtData.Columns
                        If sbLine.ToString = "" Then
                            If Not IsHeaderComplete Then sbHeader.Append(col.ColumnName)
                            sbLine.Append(rw(col.ColumnName))
                        Else
                            If Not IsHeaderComplete Then sbHeader.Append(vbTab & col.ColumnName)
                            sbLine.Append(vbTab & rw(col.ColumnName))
                        End If
                    Next

                    sb.AppendLine(sbLine.ToString)
                    IsHeaderComplete = True
                Next
        End Select


        Dim sfd As New SaveFileDialog
        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim _file As String = sfd.FileName.Replace(".txt", "") & ".csv"
            Try
                IO.File.WriteAllText(_file, strReportHeader & sbHeader.ToString & vbNewLine & sb.ToString)
                Process.Start(_file.Substring(0, _file.LastIndexOf("\")))
            Catch ex As Exception
                sfd.Dispose()
                sfd = Nothing
                MessageBox.Show("Unable to save data. Please check if file wih same name is open.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        End If
        sfd.Dispose()
        sfd = Nothing

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
            'SessionIsAlive()
            'If txtCIF_Write.Text.Length = 13 Then
            '    Dim DAL As New DAL
            '    If DAL.SelectDataByCIF(txtCIF_Write.Text) Then
            '        If DAL.TableResult.DefaultView.Count > 0 Then
            '            BindData(DAL.TableResult.Rows(0))
            '        Else
            '            MessageBox.Show("No record found", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '            ResetForm()
            '        End If
            '    End If
            '    DAL.Dispose()
            '    DAL = Nothing
            'End If
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

    Private Sub AddSystemLog()
        'Dim DAL As New DAL

        'DAL.Dispose()
        'DAL = Nothing
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
                    grid.Visible = False
                    grid2.Visible = False
                    cboPrintingType.Enabled = False
                    cboReason.Enabled = False
                Case 1
                    grid.Visible = True
                    grid2.Visible = False
                    cboPrintingType.Enabled = True
                    'cboReason.Enabled = True
                Case Else
                    grid.Visible = False
                    grid2.Visible = True
                    cboPrintingType.Enabled = False
                    'cboReason.Enabled = False
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

    Private Sub BindCardElements()
        'Dim ce As New CardElements
        'txtX.Text = ce.Signature_President_X
        'txtY.Text = ce.Signature_President_Y
        'txtWidth.Text = ce.Signature_President_Width
        'txtHeight.Text = ce.Signature_President_Height
        'ce = Nothing
    End Sub

End Class
