﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.chkPreview = New System.Windows.Forms.CheckBox()
        Me.chkIncludeIdTemplate = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkMagEncode = New System.Windows.Forms.CheckBox()
        Me.lblMagTimestamp = New System.Windows.Forms.Label()
        Me.lblPrintTimestamp = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.txtY = New System.Windows.Forms.TextBox()
        Me.txtX = New System.Windows.Forms.TextBox()
        Me.pic1 = New System.Windows.Forms.PictureBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnEjectCard = New System.Windows.Forms.Button()
        Me.btnInsertCard = New System.Windows.Forms.Button()
        Me.chkPrint = New System.Windows.Forms.CheckBox()
        Me.btnProcessCard = New System.Windows.Forms.Button()
        Me.btnGetLastRecord = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtCIF_Write = New System.Windows.Forms.TextBox()
        Me.txtMiddle_Write = New System.Windows.Forms.TextBox()
        Me.txtLast_Write = New System.Windows.Forms.TextBox()
        Me.txtSuffix_Write = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtMembershipDate_Write = New System.Windows.Forms.TextBox()
        Me.txtBranchIssued_Write = New System.Windows.Forms.TextBox()
        Me.txtFirst_Write = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtGender_Write = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cboReason = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cboPrintingType = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboReport = New System.Windows.Forms.ComboBox()
        Me.grid2 = New System.Windows.Forms.DataGridView()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cboFilter = New System.Windows.Forms.ComboBox()
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.CIF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Suffix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperatorID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MembershipType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrintingType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatePosted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Branch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TERMINAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbSetting = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 41)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1408, 649)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.chkPreview)
        Me.TabPage1.Controls.Add(Me.chkIncludeIdTemplate)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.chkMagEncode)
        Me.TabPage1.Controls.Add(Me.lblMagTimestamp)
        Me.TabPage1.Controls.Add(Me.lblPrintTimestamp)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.txtHeight)
        Me.TabPage1.Controls.Add(Me.txtWidth)
        Me.TabPage1.Controls.Add(Me.txtY)
        Me.TabPage1.Controls.Add(Me.txtX)
        Me.TabPage1.Controls.Add(Me.pic1)
        Me.TabPage1.Controls.Add(Me.btnReset)
        Me.TabPage1.Controls.Add(Me.btnEjectCard)
        Me.TabPage1.Controls.Add(Me.btnInsertCard)
        Me.TabPage1.Controls.Add(Me.chkPrint)
        Me.TabPage1.Controls.Add(Me.btnProcessCard)
        Me.TabPage1.Controls.Add(Me.btnGetLastRecord)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.txtCIF_Write)
        Me.TabPage1.Controls.Add(Me.txtMiddle_Write)
        Me.TabPage1.Controls.Add(Me.txtLast_Write)
        Me.TabPage1.Controls.Add(Me.txtSuffix_Write)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtMembershipDate_Write)
        Me.TabPage1.Controls.Add(Me.txtBranchIssued_Write)
        Me.TabPage1.Controls.Add(Me.txtFirst_Write)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtGender_Write)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1400, 620)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "CARD PERSO"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.SeaGreen
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(1161, 518)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(191, 39)
        Me.Button2.TabIndex = 113
        Me.Button2.Text = "PERSO CARD (TEST ONLY)"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'chkPreview
        '
        Me.chkPreview.AutoSize = True
        Me.chkPreview.Location = New System.Drawing.Point(1161, 483)
        Me.chkPreview.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPreview.Name = "chkPreview"
        Me.chkPreview.Size = New System.Drawing.Size(109, 20)
        Me.chkPreview.TabIndex = 112
        Me.chkPreview.Text = "Preview only"
        Me.chkPreview.UseVisualStyleBackColor = True
        '
        'chkIncludeIdTemplate
        '
        Me.chkIncludeIdTemplate.AutoSize = True
        Me.chkIncludeIdTemplate.Location = New System.Drawing.Point(1161, 454)
        Me.chkIncludeIdTemplate.Margin = New System.Windows.Forms.Padding(4)
        Me.chkIncludeIdTemplate.Name = "chkIncludeIdTemplate"
        Me.chkIncludeIdTemplate.Size = New System.Drawing.Size(148, 20)
        Me.chkIncludeIdTemplate.TabIndex = 111
        Me.chkIncludeIdTemplate.Text = "Include id template"
        Me.chkIncludeIdTemplate.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.SeaGreen
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(1161, 565)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(191, 39)
        Me.Button1.TabIndex = 110
        Me.Button1.Text = "FEED CARD"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'chkMagEncode
        '
        Me.chkMagEncode.AutoSize = True
        Me.chkMagEncode.Checked = True
        Me.chkMagEncode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMagEncode.Location = New System.Drawing.Point(1023, 585)
        Me.chkMagEncode.Margin = New System.Windows.Forms.Padding(4)
        Me.chkMagEncode.Name = "chkMagEncode"
        Me.chkMagEncode.Size = New System.Drawing.Size(109, 20)
        Me.chkMagEncode.TabIndex = 109
        Me.chkMagEncode.Text = "Mag Encode"
        Me.chkMagEncode.UseVisualStyleBackColor = True
        '
        'lblMagTimestamp
        '
        Me.lblMagTimestamp.AutoSize = True
        Me.lblMagTimestamp.ForeColor = System.Drawing.Color.Gray
        Me.lblMagTimestamp.Location = New System.Drawing.Point(27, 432)
        Me.lblMagTimestamp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMagTimestamp.Name = "lblMagTimestamp"
        Me.lblMagTimestamp.Size = New System.Drawing.Size(155, 16)
        Me.lblMagTimestamp.TabIndex = 108
        Me.lblMagTimestamp.Text = "DATE MAG ENCODED:"
        '
        'lblPrintTimestamp
        '
        Me.lblPrintTimestamp.AutoSize = True
        Me.lblPrintTimestamp.ForeColor = System.Drawing.Color.Gray
        Me.lblPrintTimestamp.Location = New System.Drawing.Point(27, 407)
        Me.lblPrintTimestamp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPrintTimestamp.Name = "lblPrintTimestamp"
        Me.lblPrintTimestamp.Size = New System.Drawing.Size(111, 16)
        Me.lblPrintTimestamp.TabIndex = 106
        Me.lblPrintTimestamp.Text = "DATE PRINTED:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.Gray
        Me.Label23.Location = New System.Drawing.Point(461, 490)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(58, 16)
        Me.Label23.TabIndex = 105
        Me.Label23.Text = "HEIGHT"
        Me.Label23.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.Gray
        Me.Label22.Location = New System.Drawing.Point(467, 458)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(52, 16)
        Me.Label22.TabIndex = 104
        Me.Label22.Text = "WIDTH"
        Me.Label22.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.Gray
        Me.Label21.Location = New System.Drawing.Point(460, 422)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 16)
        Me.Label21.TabIndex = 103
        Me.Label21.Text = "TOP (Y)"
        Me.Label21.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Gray
        Me.Label20.Location = New System.Drawing.Point(460, 386)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 16)
        Me.Label20.TabIndex = 102
        Me.Label20.Text = "LEFT (X)"
        Me.Label20.Visible = False
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(533, 486)
        Me.txtHeight.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(133, 23)
        Me.txtHeight.TabIndex = 101
        Me.txtHeight.Visible = False
        '
        'txtWidth
        '
        Me.txtWidth.Location = New System.Drawing.Point(533, 454)
        Me.txtWidth.Margin = New System.Windows.Forms.Padding(4)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(133, 23)
        Me.txtWidth.TabIndex = 100
        Me.txtWidth.Visible = False
        '
        'txtY
        '
        Me.txtY.Location = New System.Drawing.Point(533, 422)
        Me.txtY.Margin = New System.Windows.Forms.Padding(4)
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(133, 23)
        Me.txtY.TabIndex = 99
        Me.txtY.Visible = False
        '
        'txtX
        '
        Me.txtX.Location = New System.Drawing.Point(533, 383)
        Me.txtX.Margin = New System.Windows.Forms.Padding(4)
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(133, 23)
        Me.txtX.TabIndex = 98
        Me.txtX.Visible = False
        '
        'pic1
        '
        Me.pic1.BackgroundImage = CType(resources.GetObject("pic1.BackgroundImage"), System.Drawing.Image)
        Me.pic1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic1.Location = New System.Drawing.Point(31, 25)
        Me.pic1.Margin = New System.Windows.Forms.Padding(4)
        Me.pic1.Name = "pic1"
        Me.pic1.Size = New System.Drawing.Size(637, 351)
        Me.pic1.TabIndex = 89
        Me.pic1.TabStop = False
        '
        'btnReset
        '
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(231, 566)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(157, 39)
        Me.btnReset.TabIndex = 88
        Me.btnReset.Text = "RESET FORM"
        Me.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnEjectCard
        '
        Me.btnEjectCard.BackColor = System.Drawing.Color.White
        Me.btnEjectCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEjectCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjectCard.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnEjectCard.Image = CType(resources.GetObject("btnEjectCard.Image"), System.Drawing.Image)
        Me.btnEjectCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjectCard.Location = New System.Drawing.Point(1161, 176)
        Me.btnEjectCard.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEjectCard.Name = "btnEjectCard"
        Me.btnEjectCard.Size = New System.Drawing.Size(191, 39)
        Me.btnEjectCard.TabIndex = 86
        Me.btnEjectCard.Text = "EJECT CARD"
        Me.btnEjectCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEjectCard.UseVisualStyleBackColor = False
        '
        'btnInsertCard
        '
        Me.btnInsertCard.BackColor = System.Drawing.Color.White
        Me.btnInsertCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnInsertCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInsertCard.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnInsertCard.Image = CType(resources.GetObject("btnInsertCard.Image"), System.Drawing.Image)
        Me.btnInsertCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInsertCard.Location = New System.Drawing.Point(1161, 128)
        Me.btnInsertCard.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInsertCard.Name = "btnInsertCard"
        Me.btnInsertCard.Size = New System.Drawing.Size(191, 39)
        Me.btnInsertCard.TabIndex = 85
        Me.btnInsertCard.Text = "FEED CARD"
        Me.btnInsertCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInsertCard.UseVisualStyleBackColor = False
        '
        'chkPrint
        '
        Me.chkPrint.AutoSize = True
        Me.chkPrint.Checked = True
        Me.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrint.Location = New System.Drawing.Point(1161, 58)
        Me.chkPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPrint.Name = "chkPrint"
        Me.chkPrint.Size = New System.Drawing.Size(59, 20)
        Me.chkPrint.TabIndex = 83
        Me.chkPrint.Text = "Print"
        Me.chkPrint.UseVisualStyleBackColor = True
        '
        'btnProcessCard
        '
        Me.btnProcessCard.BackColor = System.Drawing.Color.White
        Me.btnProcessCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProcessCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcessCard.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnProcessCard.Image = CType(resources.GetObject("btnProcessCard.Image"), System.Drawing.Image)
        Me.btnProcessCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcessCard.Location = New System.Drawing.Point(1161, 11)
        Me.btnProcessCard.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProcessCard.Name = "btnProcessCard"
        Me.btnProcessCard.Size = New System.Drawing.Size(191, 39)
        Me.btnProcessCard.TabIndex = 82
        Me.btnProcessCard.Text = "PERSO CARD"
        Me.btnProcessCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcessCard.UseVisualStyleBackColor = False
        '
        'btnGetLastRecord
        '
        Me.btnGetLastRecord.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGetLastRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetLastRecord.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnGetLastRecord.Image = CType(resources.GetObject("btnGetLastRecord.Image"), System.Drawing.Image)
        Me.btnGetLastRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGetLastRecord.Location = New System.Drawing.Point(15, 566)
        Me.btnGetLastRecord.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGetLastRecord.Name = "btnGetLastRecord"
        Me.btnGetLastRecord.Size = New System.Drawing.Size(208, 39)
        Me.btnGetLastRecord.TabIndex = 81
        Me.btnGetLastRecord.Text = "GET LAST RECORD"
        Me.btnGetLastRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGetLastRecord.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(1083, 11)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(51, 25)
        Me.Button3.TabIndex = 80
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtCIF_Write
        '
        Me.txtCIF_Write.Location = New System.Drawing.Point(851, 11)
        Me.txtCIF_Write.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCIF_Write.MaxLength = 13
        Me.txtCIF_Write.Name = "txtCIF_Write"
        Me.txtCIF_Write.Size = New System.Drawing.Size(228, 23)
        Me.txtCIF_Write.TabIndex = 1
        '
        'txtMiddle_Write
        '
        Me.txtMiddle_Write.BackColor = System.Drawing.Color.White
        Me.txtMiddle_Write.Location = New System.Drawing.Point(851, 68)
        Me.txtMiddle_Write.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMiddle_Write.Name = "txtMiddle_Write"
        Me.txtMiddle_Write.ReadOnly = True
        Me.txtMiddle_Write.Size = New System.Drawing.Size(281, 23)
        Me.txtMiddle_Write.TabIndex = 50
        '
        'txtLast_Write
        '
        Me.txtLast_Write.BackColor = System.Drawing.Color.White
        Me.txtLast_Write.Location = New System.Drawing.Point(851, 96)
        Me.txtLast_Write.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLast_Write.Name = "txtLast_Write"
        Me.txtLast_Write.ReadOnly = True
        Me.txtLast_Write.Size = New System.Drawing.Size(281, 23)
        Me.txtLast_Write.TabIndex = 52
        '
        'txtSuffix_Write
        '
        Me.txtSuffix_Write.BackColor = System.Drawing.Color.White
        Me.txtSuffix_Write.Location = New System.Drawing.Point(851, 124)
        Me.txtSuffix_Write.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSuffix_Write.Name = "txtSuffix_Write"
        Me.txtSuffix_Write.ReadOnly = True
        Me.txtSuffix_Write.Size = New System.Drawing.Size(281, 23)
        Me.txtSuffix_Write.TabIndex = 54
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(716, 220)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 16)
        Me.Label13.TabIndex = 73
        Me.Label13.Text = "BRANCH ISSUED"
        '
        'txtMembershipDate_Write
        '
        Me.txtMembershipDate_Write.BackColor = System.Drawing.Color.White
        Me.txtMembershipDate_Write.Location = New System.Drawing.Point(851, 155)
        Me.txtMembershipDate_Write.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMembershipDate_Write.Name = "txtMembershipDate_Write"
        Me.txtMembershipDate_Write.ReadOnly = True
        Me.txtMembershipDate_Write.Size = New System.Drawing.Size(281, 23)
        Me.txtMembershipDate_Write.TabIndex = 58
        '
        'txtBranchIssued_Write
        '
        Me.txtBranchIssued_Write.BackColor = System.Drawing.Color.White
        Me.txtBranchIssued_Write.Location = New System.Drawing.Point(851, 217)
        Me.txtBranchIssued_Write.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBranchIssued_Write.Name = "txtBranchIssued_Write"
        Me.txtBranchIssued_Write.ReadOnly = True
        Me.txtBranchIssued_Write.Size = New System.Drawing.Size(281, 23)
        Me.txtBranchIssued_Write.TabIndex = 74
        '
        'txtFirst_Write
        '
        Me.txtFirst_Write.BackColor = System.Drawing.Color.White
        Me.txtFirst_Write.Location = New System.Drawing.Point(851, 39)
        Me.txtFirst_Write.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFirst_Write.Name = "txtFirst_Write"
        Me.txtFirst_Write.Size = New System.Drawing.Size(281, 23)
        Me.txtFirst_Write.TabIndex = 62
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(772, 190)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 16)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "GENDER"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(747, 42)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 16)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "FIRST NAME"
        '
        'txtGender_Write
        '
        Me.txtGender_Write.BackColor = System.Drawing.Color.White
        Me.txtGender_Write.Location = New System.Drawing.Point(851, 186)
        Me.txtGender_Write.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGender_Write.Name = "txtGender_Write"
        Me.txtGender_Write.ReadOnly = True
        Me.txtGender_Write.Size = New System.Drawing.Size(281, 23)
        Me.txtGender_Write.TabIndex = 66
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(695, 159)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 16)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "MEMBERSHIP DATE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(784, 128)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "SUFFIX"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(752, 100)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 16)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "LAST NAME"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(733, 71)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 16)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "MIDDLE NAME"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(804, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 18)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "CIF"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label29)
        Me.TabPage2.Controls.Add(Me.cboReason)
        Me.TabPage2.Controls.Add(Me.Label28)
        Me.TabPage2.Controls.Add(Me.cboPrintingType)
        Me.TabPage2.Controls.Add(Me.Label27)
        Me.TabPage2.Controls.Add(Me.cboReport)
        Me.TabPage2.Controls.Add(Me.grid2)
        Me.TabPage2.Controls.Add(Me.lblTotal)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.cboFilter)
        Me.TabPage2.Controls.Add(Me.btnExtract)
        Me.TabPage2.Controls.Add(Me.btnSubmit)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.dtpEnd)
        Me.TabPage2.Controls.Add(Me.grid)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.dtpStart)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1400, 620)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "DATA"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.Color.Gray
        Me.Label29.Location = New System.Drawing.Point(27, 140)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(65, 16)
        Me.Label29.TabIndex = 94
        Me.Label29.Text = "REASON"
        '
        'cboReason
        '
        Me.cboReason.Enabled = False
        Me.cboReason.FormattingEnabled = True
        Me.cboReason.Location = New System.Drawing.Point(151, 135)
        Me.cboReason.Margin = New System.Windows.Forms.Padding(4)
        Me.cboReason.Name = "cboReason"
        Me.cboReason.Size = New System.Drawing.Size(197, 24)
        Me.cboReason.TabIndex = 93
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.Gray
        Me.Label28.Location = New System.Drawing.Point(27, 110)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(115, 16)
        Me.Label28.TabIndex = 92
        Me.Label28.Text = "PRINTING TYPE:"
        '
        'cboPrintingType
        '
        Me.cboPrintingType.FormattingEnabled = True
        Me.cboPrintingType.Location = New System.Drawing.Point(151, 105)
        Me.cboPrintingType.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPrintingType.Name = "cboPrintingType"
        Me.cboPrintingType.Size = New System.Drawing.Size(197, 24)
        Me.cboPrintingType.TabIndex = 91
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.Gray
        Me.Label27.Location = New System.Drawing.Point(27, 22)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(68, 16)
        Me.Label27.TabIndex = 90
        Me.Label27.Text = "REPORT:"
        '
        'cboReport
        '
        Me.cboReport.FormattingEnabled = True
        Me.cboReport.Items.AddRange(New Object() {"-SELECT REPORT-", "DAILY CAPTURED", "DAILY CAPTURED (ALL DETAILS)", "SUMMARY"})
        Me.cboReport.Location = New System.Drawing.Point(151, 17)
        Me.cboReport.Margin = New System.Windows.Forms.Padding(4)
        Me.cboReport.Name = "cboReport"
        Me.cboReport.Size = New System.Drawing.Size(265, 24)
        Me.cboReport.TabIndex = 89
        '
        'grid2
        '
        Me.grid2.AllowUserToAddRows = False
        Me.grid2.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grid2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grid2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid2.Location = New System.Drawing.Point(4, 251)
        Me.grid2.Margin = New System.Windows.Forms.Padding(4)
        Me.grid2.Name = "grid2"
        Me.grid2.ReadOnly = True
        Me.grid2.RowHeadersWidth = 51
        Me.grid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid2.Size = New System.Drawing.Size(1389, 361)
        Me.grid2.TabIndex = 88
        Me.grid2.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Gray
        Me.lblTotal.Location = New System.Drawing.Point(188, 213)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(96, 23)
        Me.lblTotal.TabIndex = 87
        Me.lblTotal.Text = "TOTAL: 0"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.Gray
        Me.Label26.Location = New System.Drawing.Point(27, 170)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(59, 16)
        Me.Label26.TabIndex = 86
        Me.Label26.Text = "FILTER:"
        '
        'cboFilter
        '
        Me.cboFilter.FormattingEnabled = True
        Me.cboFilter.Items.AddRange(New Object() {"-NO FILTER-", "NOT VOID", "VOID ONLY"})
        Me.cboFilter.Location = New System.Drawing.Point(151, 166)
        Me.cboFilter.Margin = New System.Windows.Forms.Padding(4)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(197, 24)
        Me.cboFilter.TabIndex = 85
        '
        'btnExtract
        '
        Me.btnExtract.BackColor = System.Drawing.Color.White
        Me.btnExtract.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExtract.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtract.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnExtract.Image = CType(resources.GetObject("btnExtract.Image"), System.Drawing.Image)
        Me.btnExtract.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtract.Location = New System.Drawing.Point(1189, 204)
        Me.btnExtract.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(204, 39)
        Me.btnExtract.TabIndex = 84
        Me.btnExtract.Text = "EXTRACT TO CSV"
        Me.btnExtract.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExtract.UseVisualStyleBackColor = False
        Me.btnExtract.Visible = False
        '
        'btnSubmit
        '
        Me.btnSubmit.BackColor = System.Drawing.Color.White
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnSubmit.Image = CType(resources.GetObject("btnSubmit.Image"), System.Drawing.Image)
        Me.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSubmit.Location = New System.Drawing.Point(16, 204)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(151, 39)
        Me.btnSubmit.TabIndex = 83
        Me.btnSubmit.Text = "SUBMIT"
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.Gray
        Me.Label25.Location = New System.Drawing.Point(27, 80)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(80, 16)
        Me.Label25.TabIndex = 65
        Me.Label25.Text = "END DATE:"
        '
        'dtpEnd
        '
        Me.dtpEnd.Location = New System.Drawing.Point(151, 76)
        Me.dtpEnd.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(265, 23)
        Me.dtpEnd.TabIndex = 64
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CIF, Me.FName, Me.MName, Me.LName, Me.Suffix, Me.Gender, Me.OperatorID, Me.MembershipType, Me.IDNumber, Me.PrintingType, Me.DatePosted, Me.Branch, Me.TERMINAL})
        Me.grid.Location = New System.Drawing.Point(4, 251)
        Me.grid.Margin = New System.Windows.Forms.Padding(4)
        Me.grid.Name = "grid"
        Me.grid.ReadOnly = True
        Me.grid.RowHeadersWidth = 51
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid.Size = New System.Drawing.Size(1389, 361)
        Me.grid.TabIndex = 63
        '
        'CIF
        '
        Me.CIF.DataPropertyName = "CIF"
        Me.CIF.HeaderText = "CIF"
        Me.CIF.MinimumWidth = 6
        Me.CIF.Name = "CIF"
        Me.CIF.ReadOnly = True
        Me.CIF.Width = 59
        '
        'FName
        '
        Me.FName.DataPropertyName = "FName"
        Me.FName.HeaderText = "FIRST"
        Me.FName.MinimumWidth = 6
        Me.FName.Name = "FName"
        Me.FName.ReadOnly = True
        Me.FName.Width = 77
        '
        'MName
        '
        Me.MName.DataPropertyName = "MName"
        Me.MName.HeaderText = "MIDDLE"
        Me.MName.MinimumWidth = 6
        Me.MName.Name = "MName"
        Me.MName.ReadOnly = True
        Me.MName.Width = 88
        '
        'LName
        '
        Me.LName.DataPropertyName = "LName"
        Me.LName.HeaderText = "LAST"
        Me.LName.MinimumWidth = 6
        Me.LName.Name = "LName"
        Me.LName.ReadOnly = True
        Me.LName.Width = 72
        '
        'Suffix
        '
        Me.Suffix.DataPropertyName = "Suffix"
        Me.Suffix.HeaderText = "SUFFIX"
        Me.Suffix.MinimumWidth = 6
        Me.Suffix.Name = "Suffix"
        Me.Suffix.ReadOnly = True
        Me.Suffix.Width = 84
        '
        'Gender
        '
        Me.Gender.DataPropertyName = "Gender"
        Me.Gender.HeaderText = "GENDER"
        Me.Gender.MinimumWidth = 6
        Me.Gender.Name = "Gender"
        Me.Gender.ReadOnly = True
        Me.Gender.Width = 95
        '
        'OperatorID
        '
        Me.OperatorID.DataPropertyName = "OperatorID"
        Me.OperatorID.HeaderText = "OPERATOR"
        Me.OperatorID.MinimumWidth = 6
        Me.OperatorID.Name = "OperatorID"
        Me.OperatorID.ReadOnly = True
        Me.OperatorID.Width = 114
        '
        'MembershipType
        '
        Me.MembershipType.DataPropertyName = "MembershipType"
        Me.MembershipType.HeaderText = "MEMBER TYPE"
        Me.MembershipType.MinimumWidth = 6
        Me.MembershipType.Name = "MembershipType"
        Me.MembershipType.ReadOnly = True
        Me.MembershipType.Width = 125
        '
        'IDNumber
        '
        Me.IDNumber.DataPropertyName = "IDNumber"
        Me.IDNumber.HeaderText = "IDNUMBER"
        Me.IDNumber.MinimumWidth = 6
        Me.IDNumber.Name = "IDNumber"
        Me.IDNumber.ReadOnly = True
        Me.IDNumber.Width = 107
        '
        'PrintingType
        '
        Me.PrintingType.DataPropertyName = "PrintingType"
        Me.PrintingType.HeaderText = "TYPE"
        Me.PrintingType.MinimumWidth = 6
        Me.PrintingType.Name = "PrintingType"
        Me.PrintingType.ReadOnly = True
        Me.PrintingType.Width = 73
        '
        'DatePosted
        '
        Me.DatePosted.DataPropertyName = "DatePosted"
        DataGridViewCellStyle3.Format = "MM/dd/yyyy"
        Me.DatePosted.DefaultCellStyle = DataGridViewCellStyle3
        Me.DatePosted.HeaderText = "DATE CAPTURED"
        Me.DatePosted.MinimumWidth = 6
        Me.DatePosted.Name = "DatePosted"
        Me.DatePosted.ReadOnly = True
        Me.DatePosted.Width = 139
        '
        'Branch
        '
        Me.Branch.DataPropertyName = "Branch"
        Me.Branch.HeaderText = "BRANCH"
        Me.Branch.MinimumWidth = 6
        Me.Branch.Name = "Branch"
        Me.Branch.ReadOnly = True
        Me.Branch.Width = 93
        '
        'TERMINAL
        '
        Me.TERMINAL.DataPropertyName = "TerminalName"
        Me.TERMINAL.HeaderText = "TERMINAL"
        Me.TERMINAL.MinimumWidth = 6
        Me.TERMINAL.Name = "TERMINAL"
        Me.TERMINAL.ReadOnly = True
        Me.TERMINAL.Width = 105
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.Gray
        Me.Label24.Location = New System.Drawing.Point(27, 53)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(97, 16)
        Me.Label24.TabIndex = 62
        Me.Label24.Text = "START DATE:"
        '
        'dtpStart
        '
        Me.dtpStart.Location = New System.Drawing.Point(151, 48)
        Me.dtpStart.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(265, 23)
        Me.dtpStart.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(12, 689)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(1405, 22)
        Me.TextBox1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Panel1.Controls.Add(Me.pbSetting)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1429, 33)
        Me.Panel1.TabIndex = 3
        '
        'pbSetting
        '
        Me.pbSetting.Image = CType(resources.GetObject("pbSetting.Image"), System.Drawing.Image)
        Me.pbSetting.Location = New System.Drawing.Point(4, 4)
        Me.pbSetting.Margin = New System.Windows.Forms.Padding(4)
        Me.pbSetting.Name = "pbSetting"
        Me.pbSetting.Size = New System.Drawing.Size(37, 30)
        Me.pbSetting.TabIndex = 112
        Me.pbSetting.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1429, 716)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AFPSLAI - CARD PERSO AND REPORTING"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.grid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtBranchIssued_Write As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtGender_Write As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFirst_Write As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMembershipDate_Write As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSuffix_Write As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLast_Write As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMiddle_Write As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCIF_Write As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnEjectCard As System.Windows.Forms.Button
    Friend WithEvents btnInsertCard As System.Windows.Forms.Button
    Friend WithEvents chkPrint As System.Windows.Forms.CheckBox
    Friend WithEvents btnProcessCard As System.Windows.Forms.Button
    Friend WithEvents btnGetLastRecord As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents pic1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtY As System.Windows.Forms.TextBox
    Friend WithEvents txtX As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblPrintTimestamp As System.Windows.Forms.Label
    Friend WithEvents lblMagTimestamp As System.Windows.Forms.Label
    Friend WithEvents chkMagEncode As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pbSetting As System.Windows.Forms.PictureBox
    Friend WithEvents btnExtract As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cboFilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents CIF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Suffix As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperatorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MembershipType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintingType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatePosted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Branch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TERMINAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkIncludeIdTemplate As System.Windows.Forms.CheckBox
    Friend WithEvents chkPreview As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents grid2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cboReason As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cboPrintingType As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboReport As System.Windows.Forms.ComboBox
End Class
