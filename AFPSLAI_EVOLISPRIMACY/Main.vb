Public Class Main

    Private DataID As Integer = 0
    Private CompleteAddress As String = ""
    Private Address1 As String = ""
    Private Address2 As String = ""
    Private Address3 As String = ""
    Private AddressCity As String = ""
    Private AddressProvince As String = ""
    Private AddressCountry As String = ""
    Private AddressZipCode As String = ""

    Private ContactNos As String = ""
    Private Contact_Name As String = ""
    Private Contact_ContactNos As String = ""

    Private PhotoPath As String = "" '"E:\Projects\DCS2015\DCS2015\bin\Debug\Captured Data\05052017\3333322222222\3333322222222_Photo.jpg"
    Private SignaturePath As String = "" '"E:\Projects\DCS2015\DCS2015\bin\Debug\Captured Data\05052017\3333322222222\3333322222222_Signature4.tiff"

    Private BarcodeJPG As String = "tempBarcode.jpg"
    Private lPrimaryJpg As String = ""
    Private rPrimaryJpg As String = ""
    Private lBackupJpg As String = ""
    Private rBackupJpg As String = ""

    Private IsNotIdle As Boolean = False
    Private IdleCounter As Integer = 0

    Dim TerminalID As String = ""
    Dim BranchCode As String = ""
    Dim fingerprints As New List(Of String)

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        SessionIsAlive()
        ResetForm()

        If txtCIF_Write.Text = "" Then
            MessageBox.Show("Please enter CIF to search...", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'Dim DAL As New DAL
        'If DAL.SelectDataByCIF(txtCIF_Write.Text) Then
        '    If DAL.TableResult.DefaultView.Count > 0 Then
        '        BindData(DAL.TableResult.Rows(0))
        '    Else
        '        MessageBox.Show("No record found", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        ResetForm()
        '    End If
        'End If
        'DAL.Dispose()
        'DAL = Nothing
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

    Private Sub BindData(ByVal rw As DataRow)
        TerminalID = ""
        BranchCode = ""
        'fingerprints.Clear()

        'DataID = rw("DataID")
        'If Not IsDBNull(rw("CIF")) Then txtCIF_Write.Text = rw("CIF").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("FName")) Then txtFirst_Write.Text = rw("FName").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("MName")) Then txtMiddle_Write.Text = rw("MName").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("LName")) Then txtLast_Write.Text = rw("LName").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("Suffix")) Then txtSuffix_Write.Text = rw("Suffix").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("DateOfBirth")) Then txtDOB_Write.Text = CDate(rw("DateOfBirth")).ToString("MM/dd/yyyy")
        'If Not IsDBNull(rw("MembershipDate")) Then txtMembershipDate_Write.Text = CDate(rw("MembershipDate")).ToString("MM/dd/yyyy")
        'If Not IsDBNull(rw("MembershipStatus")) Then txtMembershipStatus_Write.Text = rw("MembershipStatus").ToString.Trim
        'If Not IsDBNull(rw("Gender")) Then txtGender_Write.Text = rw("Gender").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("MembershipType")) Then txtMembershipType_Write.Text = rw("MembershipType").ToString.ToUpper.Trim
        ''If Not IsDBNull(rw("TerminalName")) Then txtIDNumber_Write.Text = String.Format("{0}_{1}", rw("TerminalName").ToString.Trim, rw("BranchCode").ToString.ToUpper.Trim)

        'Dim UID As String = ""
        ''Dim TerminalID As String = ""
        ''Dim BranchCode As String = ""
        'If Not IsDBNull(rw("UID")) Then UID = rw("UID").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("TerminalName")) Then TerminalID = rw("TerminalName").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("BranchCode")) Then BranchCode = rw("BranchCode").ToString.ToUpper.Trim
        'If UID = "" Then
        '    txtIDNumber_Write.Text = String.Format("{0}_{1}", TerminalID, BranchCode)
        'Else
        '    If UID = "FAILED" Then
        '        txtIDNumber_Write.Text = String.Format("{0}_{1}", TerminalID, BranchCode)
        '    Else
        '        txtIDNumber_Write.Text = String.Format("{0}_{1}_{2}", UID, TerminalID, BranchCode)
        '    End If
        'End If

        'If Not IsDBNull(rw("DatePosted")) Then txtDateIssued_Write.Text = CDate(rw("DatePosted")).ToString("MM/dd/yyyy")
        'If Not IsDBNull(rw("Branch")) Then txtBranchIssued_Write.Text = rw("Branch").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("AssociateType")) Then txtAssociateType_Write.Text = rw("AssociateType").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("CIF_PrincipalMember")) Then txtCIF_Principal_Write.Text = rw("CIF_PrincipalMember").ToString.ToUpper.Trim

        'If Not IsDBNull(rw("Address1")) Then Address1 = rw("Address1").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("Address2")) Then Address2 = rw("Address2").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("Address3")) Then Address3 = rw("Address3").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("City")) Then AddressCity = rw("City").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("Province")) Then AddressProvince = rw("Province").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("Country")) Then AddressCountry = rw("Country").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("ZipCode")) Then AddressZipCode = rw("ZipCode").ToString.ToUpper.Trim
        'CompleteAddress = String.Format("{0}{1}{2}{3}{4}{5}{6}",
        '                                Address1,
        '                                IIf(Address2 = "", "", " " & Address2),
        '                                IIf(Address3 = "", "", " " & Address3),
        '                                IIf(AddressCity = "", "", " " & AddressCity),
        '                                IIf(AddressProvince = "", "", " " & AddressProvince),
        '                                IIf(AddressCountry = "", "", " " & AddressCountry),
        '                                IIf(AddressZipCode = "", "", " " & AddressZipCode))

        ''If Not IsDBNull(rw("MobileNos")) Then ContactNos = rw("MobileNos").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("ContactNos")) Then ContactNos = rw("ContactNos").ToString.ToUpper.Trim

        'If ContactNos = "" Then _
        '    If Not IsDBNull(rw("MobileNos")) Then ContactNos = rw("MobileNos").ToString.ToUpper.Trim

        'If Not IsDBNull(rw("FullName_Contact")) Then Contact_Name = rw("FullName_Contact").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("ContactNos_Contact")) Then Contact_ContactNos = rw("ContactNos_Contact").ToString.ToUpper.Trim

        'If Not IsDBNull(rw("Printed_Timestamp")) Then lblPrintTimestamp.Text = "DATE PRINTED: " & rw("Printed_Timestamp").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("Magencode_Timestamp")) Then lblMagTimestamp.Text = "DATE MAG ENCODED: " & rw("Magencode_Timestamp").ToString.ToUpper.Trim
        'If Not IsDBNull(rw("Chipencode_Timestamp")) Then lblChipEncodeTimestamp.Text = "DATE CHIP ENCODED: " & rw("Chipencode_Timestamp").ToString.ToUpper.Trim

        'txtContactNos.Text = ContactNos
        'txtContactName.Text = Contact_Name
        'txtContactContactNos.Text = Contact_ContactNos
        'txtAddress.Text = CompleteAddress

        ''PhotoPath = String.Format("{0}\{1}\{2}\{2}_Photo.jpg", My.Settings.CapturedData, CDate(rw("DatePosted")).ToString("MMddyyyy"), txtCIF_Write.Text)
        'PhotoPath = String.Format("{0}\{1}\{2}\{2}_photo_{3}.jpg", My.Settings.CapturedData, CDate(rw("DatePosted")).ToString("MMddyyyy"), txtCIF_Write.Text, CDate(rw("DatePosted")).ToString("ddMMyyyy"))
        'SignaturePath = String.Format("{0}\{1}\{2}\{2}_signature_{3}.tiff", My.Settings.CapturedData, CDate(rw("DatePosted")).ToString("MMddyyyy"), txtCIF_Write.Text, CDate(rw("DatePosted")).ToString("ddMMyyyy"))

        'Dim fingerprintsSource As String = String.Format("{0}\{1}\{2}", My.Settings.CapturedData, CDate(rw("DatePosted")).ToString("MMddyyyy"), txtCIF_Write.Text)
        'If System.IO.Directory.Exists(fingerprintsSource) Then
        '    For Each fingerprint As String In System.IO.Directory.GetFiles(fingerprintsSource)
        '        If System.IO.Path.GetExtension(fingerprint).ToUpper = ".JPG" Then
        '            If System.IO.Path.GetFileNameWithoutExtension(fingerprint).Contains("_Lprimary") Then
        '                lPrimaryJpg = fingerprint
        '                'fingerprints.Add(fingerprint)
        '            ElseIf System.IO.Path.GetFileNameWithoutExtension(fingerprint).Contains("_Rprimary") Then
        '                rPrimaryJpg = fingerprint
        '                'fingerprints.Add(fingerprint)
        '            ElseIf System.IO.Path.GetFileNameWithoutExtension(fingerprint).Contains("_Lbackup") Then
        '                lBackupJpg = fingerprint
        '                'fingerprints.Add(fingerprint)
        '            ElseIf System.IO.Path.GetFileNameWithoutExtension(fingerprint).Contains("_Rbackup") Then
        '                rBackupJpg = fingerprint
        '                'fingerprints.Add(fingerprint)
        '            End If
        '        End If
        '    Next


        '    If IO.File.Exists(rPrimaryJpg) Then
        '        fingerprints.Add(rPrimaryJpg)
        '    ElseIf IO.File.Exists(rBackupJpg) Then
        '        fingerprints.Add(rBackupJpg)
        '    ElseIf IO.File.Exists(lPrimaryJpg) Then
        '        fingerprints.Add(lPrimaryJpg)
        '    ElseIf IO.File.Exists(lBackupJpg) Then
        '        fingerprints.Add(lBackupJpg)
        '    End If
        'End If

        'If Not System.IO.File.Exists(PhotoPath) Then Return
        'If Not System.IO.File.Exists(SignaturePath) Then Return

        ShowPreview = True
        pic1.Refresh()
    End Sub

    Private Sub ResetForm()
        DataID = 0
        txtFirst_Write.Clear()
        txtMiddle_Write.Clear()
        txtLast_Write.Clear()
        txtSuffix_Write.Clear()
        txtMembershipDate_Write.Clear()
        txtGender_Write.Clear()
        txtBranchIssued_Write.Clear()

        lblPrintTimestamp.Text = "DATE PRINTED:"
        lblMagTimestamp.Text = "DATE MAG ENCODED:"

        CompleteAddress = ""
        Address1 = ""
        Address2 = ""
        Address3 = ""
        AddressCity = ""
        AddressProvince = ""
        AddressCountry = ""
        AddressZipCode = ""
        ContactNos = ""
        Contact_Name = ""
        Contact_ContactNos = ""
    End Sub

    Private Function GetAppVersion() As String
        Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim fvi As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location)
        Return String.Format(" v{0}", fvi.FileVersion)
    End Function

    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text &= GetAppVersion()
        grid2.AutoGenerateColumns = True

        Dim li As New LogIN
        li.ShowDialog()

        If li.IsSuccess Then
            SessionIsAlive()

            CheckForIllegalCrossThreadCalls = False
            StartThread()
            'Timer1.Start()

            '   btnGetLastRecord.PerformClick()
            'txtFirst_Write.Text = "ANACLETO JOSEFINO P. BUENCAMINO"

            PopulatePrintingType()
            PopulateReplaceReason()

            If cboReport.Items.Count > 0 Then cboReport.SelectedIndex = 0

            txtCIF_Write.SelectAll()
            txtCIF_Write.Focus()
            grid.AutoGenerateColumns = False
            cboFilter.SelectedIndex = 0

            BindCardElements()
        Else
            Close()
            Application.Exit()
        End If
    End Sub

    Private Sub btnGetLastRecord_Click(sender As System.Object, e As System.EventArgs) Handles btnGetLastRecord.Click
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
        If txtMiddle_Write.Text.Trim <> "" Then middlename = " " & txtMiddle_Write.Text.Substring(0, 1) & "."
        If txtSuffix_Write.Text.Trim <> "" Then suffix = " " & txtSuffix_Write.Text
        Return String.Format("{0}{1}{2}{3}", txtFirst_Write.Text, middlename, " " & txtLast_Write.Text, suffix)
    End Function

    Private Sub PrintCard()
        Dim chipEncodeFailed As Boolean = True

        If Not chipEncodeFailed Then
            If MessageBox.Show("Card is not yet chip encoded, Abort?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If
        End If

        'Dim intPrinterCounterBefore As Integer = GetPrinterCounter()
        'If GenerateBarcode(txtCIF_Write.Text) Then
        '    Dim pc As New PrintCard(fingerprints, txtCIF_Write.Text, CompleteName, txtAddress.Text, txtContactNos.Text, txtDOB_Write.Text, txtIDNumber_Write.Text, txtDateIssued_Write.Text, txtContactName.Text, txtContactContactNos.Text, txtBranchIssued_Write.Text, PhotoPath, SignaturePath, BarcodeJPG, chkIncludeIdTemplate.Checked.ToString)
        '    pc.X = txtX.Text
        '    pc.Y = txtY.Text
        '    pc.imgWidth = txtWidth.Text
        '    pc.imgHeight = txtHeight.Text
        '    If chkPreview.Checked Then
        '        pc.Preview()
        '    Else
        '        pc.Print()
        '    End If

        '    Dim intPrinterCounterAfter As Integer = GetPrinterCounter()
        '    'Dim DAL As New DAL
        '    'DAL.ExecuteQuery("UPDATE tblData SET Printed_Timestamp=GETDATE() WHERE DataID=" & DataID.ToString)
        '    'DAL.InsertRelDataCardActivity(txtCIF_Write.Text, "Card printing")
        '    'DAL.AddPrinterCounter(txtCIF_Write.Text, intPrinterCounterBefore, intPrinterCounterAfter)
        '    'DAL.Dispose()
        '    'DAL = Nothing
        'End If
    End Sub

    Private Sub ChipEncode()
        FormatCard()

        Dim strData(14) As String
        strData(0) = txtCIF_Write.Text
        strData(1) = txtFirst_Write.Text
        strData(2) = txtMiddle_Write.Text
        strData(3) = txtLast_Write.Text
        strData(4) = txtSuffix_Write.Text
        'strData(5) = txtDOB_Write.Text
        strData(6) = txtMembershipDate_Write.Text
        'strData(7) = txtMembershipStatus_Write.Text
        strData(8) = txtGender_Write.Text
        'strData(9) = txtMembershipType_Write.Text
        'strData(10) = txtIDNumber_Write.Text
        'strData(11) = txtDateIssued_Write.Text
        strData(12) = txtBranchIssued_Write.Text
        'strData(13) = txtAssociateType_Write.Text
        'strData(14) = txtCIF_Principal_Write.Text

        Dim WriteToCard As New WriteToCard(New ListBox, TextBox1, strData)
        If Not WriteToCard.SuccessWrite Then
            SystemStatus(WriteToCard.ErrorMessage, 2)
        Else
            SystemStatus("Process is complete", 1)

            'Dim DAL As New DAL
            'DAL.ExecuteQuery("UPDATE tblData SET IDNUMBER='" & WriteToCard.IDNUMBER_PlainText & "', UID='" & WriteToCard.UID & "', Chipencode_Timestamp=GETDATE() WHERE DataID=" & DataID.ToString)
            'DAL.InsertRelDataCardActivity(txtCIF_Write.Text, "Chip encoding")
            'If DAL.SelectDataByCIF(txtCIF_Write.Text) Then
            '    If DAL.TableResult.DefaultView.Count > 0 Then
            '        BindData(DAL.TableResult.Rows(0))
            '    Else
            '        MessageBox.Show("No record found", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If
            'End If
            'DAL.Dispose()
            'DAL = Nothing
        End If

        WriteToCard = Nothing
    End Sub

    Private Sub MagEncode()
        Dim strTracks(2) As String
        Dim middleName As String = ""
        If txtMiddle_Write.Text <> "" Then middleName = txtMiddle_Write.Text.Substring(0, 1).ToUpper
        'strTracks(0) = String.Format("{0}^{1}/{2}{3}^{4}", txtCIF_Write.Text.Trim, txtLast_Write.Text, txtFirst_Write.Text, middleName, CDate(txtDOB_Write.Text).ToString("yyyyMMdd"))
        'strTracks(1) = String.Format("{0}={1}", txtCIF_Write.Text.Trim, CDate(txtDOB_Write.Text).ToString("yyyyMMdd"))
        strTracks(2) = ""

        Dim magEnc As New MagEncoding(strTracks)
        If magEnc.MagEncode() Then
            'Dim DAL As New DAL
            'DAL.ExecuteQuery("UPDATE tblData SET Magencode_Timestamp=GETDATE() WHERE DataID=" & DataID.ToString)
            'DAL.InsertRelDataCardActivity(txtCIF_Write.Text, "Mag encoding")
            'DAL.Dispose()
            'DAL = Nothing
        End If
    End Sub

    Private Sub btnProcessCard_Click(sender As System.Object, e As System.EventArgs) Handles btnProcessCard.Click
        'txtIDNumber_Write.Clear()
        ''WriteToCard.Init()
        ''Dim s As String = WriteToCard.GetUID 'GETUID()
        'Dim s As String
        'Dim cntr As Integer = 0
        'Do While True
        '    s = WriteToCard.GetUID 'GETUID()
        '    cntr += 1
        '    txtIDNumber_Write.Text = s & "," & cntr
        '    Application.DoEvents()
        '    System.Threading.Thread.Sleep(1000)
        'Loop
        'txtIDNumber_Write.Text = s
        'Return

        SessionIsAlive()

        If txtCIF_Write.Text = "" Then Return

        If MessageBox.Show("Are you sure you want to proceed?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            ControlDispo(True)
            Exit Sub
        End If

        ControlDispo(False)

        If chkMagEncode.Checked Then MagEncode()

        'If Not chkChipEncode.Checked Then EjectCard()
        If chkMagEncode.Checked Then
            FeedCard()
        Else
            FeedCard()
        End If

        If chkPrint.Checked Then
            FeedCard()

            If lblPrintTimestamp.Text <> "DATE PRINTED:" Then
                If MessageBox.Show("Card has been issued to this record. Continue?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    PrintCard()
                End If
            Else
                PrintCard()
            End If
        Else
            If Not My.Settings.PCSCReader.Contains("OMNIKEY") Then EjectCard()
        End If

        ControlDispo(True)
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

    Private Sub FormatCard()
        Dim FormatCard As New FormatCard(My.Settings.PCSCReader, New ListBox, TextBox1)
        FormatCard.FormatAllSectors()
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
        txtCIF_Write.Clear()
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
        btnGetLastRecord.Enabled = bln
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
            Dim imgPhoto As Image = Nothing

            If System.IO.File.Exists(PhotoPath) Then
                imgPhoto = Image.FromStream(New System.IO.MemoryStream(System.IO.File.ReadAllBytes(PhotoPath)))
                e.Graphics.DrawImage(imgPhoto, 48, 92, 122, 152)
            End If

            'If System.IO.File.Exists(SignaturePath) Then
            '    Dim myBitmap As New Bitmap(SignaturePath)
            '    myBitmap.MakeTransparent()
            '    e.Graphics.DrawImage(myBitmap, 210, 100, 200, 70)
            'Else
            '    Dim myBitmap As New Bitmap(SignaturePath)
            '    myBitmap.MakeTransparent()
            '    e.Graphics.DrawImage(myBitmap, 210, 100, 200, 70)
            'End If

            If System.IO.File.Exists(SignaturePath) Then
                Dim myBitmap As New Bitmap(SignaturePath)
                myBitmap.MakeTransparent()
                e.Graphics.DrawImage(myBitmap, 210, 100, 200, 70)
            Else
                If fingerprints.Count > 0 Then
                    Dim myBitmap As New Bitmap(fingerprints(0))
                    myBitmap.MakeTransparent()
                    'e.Graphics.DrawImage(myBitmap, 210, 100, 200, 70)
                    e.Graphics.DrawImage(myBitmap, 250, 120, 50, 50)
                End If
            End If

            Dim fontHightlight As New Font("Arial", 10, FontStyle.Bold)
            Dim fontGeneric As New Font("Arial", 8)
            Dim dBlack As New SolidBrush(Color.Black)

            Dim intLeft As Integer = 210
            Dim intTop As Integer = 170

            e.Graphics.DrawString(CompleteName, fontHightlight, dBlack, intLeft, intTop)
            e.Graphics.DrawString(txtCIF_Write.Text, fontGeneric, dBlack, intLeft + 20, intTop + 20)
            ShowPreview = False
        End If
    End Sub

    Private Sub txtCIF_Write_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIF_Write.KeyPress
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

    
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
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
                    cboFilter.Enabled = False
                Case 1
                    grid.Visible = True
                    grid2.Visible = False
                    cboPrintingType.Enabled = True
                    'cboReason.Enabled = True
                    cboFilter.Enabled = True
                Case Else
                    grid.Visible = False
                    grid2.Visible = True
                    cboPrintingType.Enabled = False
                    'cboReason.Enabled = False
                    cboFilter.Enabled = False
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
        Dim ce As New CardElements
        txtX.Text = ce.Signature_President_X
        txtY.Text = ce.Signature_President_Y
        txtWidth.Text = ce.Signature_President_Width
        txtHeight.Text = ce.Signature_President_Height
        ce = Nothing
    End Sub

    Public Function GETUID() As String
        Dim bln As Boolean = False

        Dim ReaderName As String = "HID Global OMNIKEY 5422 Smartcard Reader 0"

        retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, hContext)
        Try
            If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
                Console.WriteLine("ModWinsCard.SCardEstablishContext failed")
                Return ""
            End If

            ' Shared Connection
            retCode = ModWinsCard.SCardConnect(hContext, ReaderName, ModWinsCard.SCARD_SHARE_SHARED, ModWinsCard.SCARD_PROTOCOL_T0 Or ModWinsCard.SCARD_PROTOCOL_T1, hCard, Protocol)

            If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
                Console.WriteLine("ModWinsCard.SCardConnect failed")
                Return ""
            End If

            Dim tmpStr As String = ""
            Dim indx As Integer


            validATS = False

            Call ClearBuffers()

            SendBuff(0) = &HFF                              ' CLA
            SendBuff(1) = &HCA                              ' INS
            SendBuff(2) = &H0                               ' P1 : Other cards
            SendBuff(3) = &H0                               ' P2
            SendBuff(4) = &H0                               ' Le : Full Length

            SendLen = SendBuff(4) + 5
            RecvLen = &HFF

            Dim lstBoxLog As New ListBox
            retCode = SendAPDUandDisplay(3, lstBoxLog)

            If retCode <> ModWinsCard.SCARD_S_SUCCESS Then Return False

            If validATS Then

                For indx = 0 To (RecvLen - 3)
                    tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "
                Next indx

                'displayOut(3, 0, "UID:" + tmpStr.Trim, lstBoxLog)

                Return tmpStr

            End If

            Return bln
        Catch ex As Exception
        Finally
            retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD)
        End Try
    End Function

End Class
