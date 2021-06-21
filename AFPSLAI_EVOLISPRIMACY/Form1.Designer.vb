<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.cmdChipEncode = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtFirst = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMiddle = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLast = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSuffix = New System.Windows.Forms.TextBox()
        Me.txtDOB = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtGender = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pbPhoto = New System.Windows.Forms.PictureBox()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.cmdReadCard = New System.Windows.Forms.Button()
        Me.Label_Status = New System.Windows.Forms.Label()
        Me.lstBoxLog = New System.Windows.Forms.ListBox()
        Me.txtFirst1 = New System.Windows.Forms.TextBox()
        Me.txtFirst2 = New System.Windows.Forms.TextBox()
        Me.txtMiddle1 = New System.Windows.Forms.TextBox()
        Me.txtMiddle2 = New System.Windows.Forms.TextBox()
        Me.txtLast1 = New System.Windows.Forms.TextBox()
        Me.txtLast2 = New System.Windows.Forms.TextBox()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.txtAddress3 = New System.Windows.Forms.TextBox()
        Me.txtAddress4 = New System.Windows.Forms.TextBox()
        Me.txtAddress5 = New System.Windows.Forms.TextBox()
        Me.txtAddress6 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDOB_Card = New System.Windows.Forms.Label()
        Me.lblGender_Card = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblIDRefNo = New System.Windows.Forms.Label()
        Me.lblBOSPayjur_Card = New System.Windows.Forms.Label()
        Me.txtBOSPayjur = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdChipEncode
        '
        Me.cmdChipEncode.Location = New System.Drawing.Point(99, 347)
        Me.cmdChipEncode.Name = "cmdChipEncode"
        Me.cmdChipEncode.Size = New System.Drawing.Size(80, 46)
        Me.cmdChipEncode.TabIndex = 0
        Me.cmdChipEncode.Text = "ChipEncode"
        Me.cmdChipEncode.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "MEMBER NO"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(121, 46)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(244, 20)
        Me.txtID.TabIndex = 2
        '
        'txtFirst
        '
        Me.txtFirst.Location = New System.Drawing.Point(121, 99)
        Me.txtFirst.Name = "txtFirst"
        Me.txtFirst.Size = New System.Drawing.Size(244, 20)
        Me.txtFirst.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "FIRST"
        '
        'txtMiddle
        '
        Me.txtMiddle.Location = New System.Drawing.Point(121, 125)
        Me.txtMiddle.Name = "txtMiddle"
        Me.txtMiddle.Size = New System.Drawing.Size(244, 20)
        Me.txtMiddle.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "MIDDLE"
        '
        'txtLast
        '
        Me.txtLast.Location = New System.Drawing.Point(121, 151)
        Me.txtLast.Name = "txtLast"
        Me.txtLast.Size = New System.Drawing.Size(244, 20)
        Me.txtLast.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "LAST"
        '
        'txtSuffix
        '
        Me.txtSuffix.Location = New System.Drawing.Point(500, 411)
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.Size = New System.Drawing.Size(72, 20)
        Me.txtSuffix.TabIndex = 10
        '
        'txtDOB
        '
        Me.txtDOB.Location = New System.Drawing.Point(121, 177)
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.Size = New System.Drawing.Size(244, 20)
        Me.txtDOB.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "DATE OF BIRTH"
        '
        'txtGender
        '
        Me.txtGender.Location = New System.Drawing.Point(121, 203)
        Me.txtGender.Name = "txtGender"
        Me.txtGender.Size = New System.Drawing.Size(244, 20)
        Me.txtGender.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "GENDER"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(121, 229)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(244, 79)
        Me.txtAddress.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 232)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "ADDRESS"
        '
        'pbPhoto
        '
        Me.pbPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbPhoto.Location = New System.Drawing.Point(415, 117)
        Me.pbPhoto.Name = "pbPhoto"
        Me.pbPhoto.Size = New System.Drawing.Size(129, 142)
        Me.pbPhoto.TabIndex = 17
        Me.pbPhoto.TabStop = False
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(12, 9)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(59, 23)
        Me.cmdBrowse.TabIndex = 19
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'cmdReadCard
        '
        Me.cmdReadCard.Location = New System.Drawing.Point(271, 347)
        Me.cmdReadCard.Name = "cmdReadCard"
        Me.cmdReadCard.Size = New System.Drawing.Size(80, 46)
        Me.cmdReadCard.TabIndex = 20
        Me.cmdReadCard.Text = "Read Card"
        Me.cmdReadCard.UseVisualStyleBackColor = True
        '
        'Label_Status
        '
        Me.Label_Status.AutoSize = True
        Me.Label_Status.Location = New System.Drawing.Point(12, 320)
        Me.Label_Status.Name = "Label_Status"
        Me.Label_Status.Size = New System.Drawing.Size(38, 13)
        Me.Label_Status.TabIndex = 23
        Me.Label_Status.Text = "Ready"
        '
        'lstBoxLog
        '
        Me.lstBoxLog.FormattingEnabled = True
        Me.lstBoxLog.Location = New System.Drawing.Point(384, 411)
        Me.lstBoxLog.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lstBoxLog.Name = "lstBoxLog"
        Me.lstBoxLog.Size = New System.Drawing.Size(93, 43)
        Me.lstBoxLog.TabIndex = 22
        Me.lstBoxLog.Visible = False
        '
        'txtFirst1
        '
        Me.txtFirst1.Location = New System.Drawing.Point(12, 411)
        Me.txtFirst1.Name = "txtFirst1"
        Me.txtFirst1.Size = New System.Drawing.Size(56, 20)
        Me.txtFirst1.TabIndex = 24
        '
        'txtFirst2
        '
        Me.txtFirst2.Location = New System.Drawing.Point(74, 411)
        Me.txtFirst2.Name = "txtFirst2"
        Me.txtFirst2.Size = New System.Drawing.Size(56, 20)
        Me.txtFirst2.TabIndex = 25
        '
        'txtMiddle1
        '
        Me.txtMiddle1.Location = New System.Drawing.Point(136, 411)
        Me.txtMiddle1.Name = "txtMiddle1"
        Me.txtMiddle1.Size = New System.Drawing.Size(56, 20)
        Me.txtMiddle1.TabIndex = 26
        '
        'txtMiddle2
        '
        Me.txtMiddle2.Location = New System.Drawing.Point(198, 411)
        Me.txtMiddle2.Name = "txtMiddle2"
        Me.txtMiddle2.Size = New System.Drawing.Size(56, 20)
        Me.txtMiddle2.TabIndex = 27
        '
        'txtLast1
        '
        Me.txtLast1.Location = New System.Drawing.Point(260, 411)
        Me.txtLast1.Name = "txtLast1"
        Me.txtLast1.Size = New System.Drawing.Size(56, 20)
        Me.txtLast1.TabIndex = 28
        '
        'txtLast2
        '
        Me.txtLast2.Location = New System.Drawing.Point(322, 411)
        Me.txtLast2.Name = "txtLast2"
        Me.txtLast2.Size = New System.Drawing.Size(56, 20)
        Me.txtLast2.TabIndex = 29
        '
        'txtAddress1
        '
        Me.txtAddress1.Location = New System.Drawing.Point(12, 437)
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(56, 20)
        Me.txtAddress1.TabIndex = 30
        '
        'txtAddress2
        '
        Me.txtAddress2.Location = New System.Drawing.Point(74, 437)
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(56, 20)
        Me.txtAddress2.TabIndex = 31
        '
        'txtAddress3
        '
        Me.txtAddress3.Location = New System.Drawing.Point(136, 437)
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.Size = New System.Drawing.Size(56, 20)
        Me.txtAddress3.TabIndex = 32
        '
        'txtAddress4
        '
        Me.txtAddress4.Location = New System.Drawing.Point(198, 437)
        Me.txtAddress4.Name = "txtAddress4"
        Me.txtAddress4.Size = New System.Drawing.Size(56, 20)
        Me.txtAddress4.TabIndex = 33
        '
        'txtAddress5
        '
        Me.txtAddress5.Location = New System.Drawing.Point(260, 437)
        Me.txtAddress5.Name = "txtAddress5"
        Me.txtAddress5.Size = New System.Drawing.Size(56, 20)
        Me.txtAddress5.TabIndex = 34
        '
        'txtAddress6
        '
        Me.txtAddress6.Location = New System.Drawing.Point(322, 437)
        Me.txtAddress6.Name = "txtAddress6"
        Me.txtAddress6.Size = New System.Drawing.Size(56, 20)
        Me.txtAddress6.TabIndex = 35
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 347)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 46)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Reset"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(380, 46)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(450, 240)
        Me.PictureBox1.TabIndex = 37
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(377, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Card Preview"
        '
        'lblDOB_Card
        '
        Me.lblDOB_Card.AutoSize = True
        Me.lblDOB_Card.Location = New System.Drawing.Point(670, 137)
        Me.lblDOB_Card.Name = "lblDOB_Card"
        Me.lblDOB_Card.Size = New System.Drawing.Size(36, 13)
        Me.lblDOB_Card.TabIndex = 39
        Me.lblDOB_Card.Text = "[DOB]"
        '
        'lblGender_Card
        '
        Me.lblGender_Card.AutoSize = True
        Me.lblGender_Card.Location = New System.Drawing.Point(670, 124)
        Me.lblGender_Card.Name = "lblGender_Card"
        Me.lblGender_Card.Size = New System.Drawing.Size(59, 13)
        Me.lblGender_Card.TabIndex = 40
        Me.lblGender_Card.Text = "[GENDER]"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(185, 347)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 46)
        Me.Button2.TabIndex = 42
        Me.Button2.Text = "Print Card"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblIDRefNo
        '
        Me.lblIDRefNo.AutoSize = True
        Me.lblIDRefNo.BackColor = System.Drawing.Color.Transparent
        Me.lblIDRefNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDRefNo.Location = New System.Drawing.Point(670, 150)
        Me.lblIDRefNo.Name = "lblIDRefNo"
        Me.lblIDRefNo.Size = New System.Drawing.Size(69, 13)
        Me.lblIDRefNo.TabIndex = 43
        Me.lblIDRefNo.Text = "[ID/REF NO]"
        '
        'lblBOSPayjur_Card
        '
        Me.lblBOSPayjur_Card.AutoSize = True
        Me.lblBOSPayjur_Card.BackColor = System.Drawing.Color.Transparent
        Me.lblBOSPayjur_Card.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBOSPayjur_Card.Location = New System.Drawing.Point(670, 163)
        Me.lblBOSPayjur_Card.Name = "lblBOSPayjur_Card"
        Me.lblBOSPayjur_Card.Size = New System.Drawing.Size(64, 13)
        Me.lblBOSPayjur_Card.TabIndex = 44
        Me.lblBOSPayjur_Card.Text = "[BOSPayjur]"
        '
        'txtBOSPayjur
        '
        Me.txtBOSPayjur.Location = New System.Drawing.Point(121, 72)
        Me.txtBOSPayjur.Name = "txtBOSPayjur"
        Me.txtBOSPayjur.Size = New System.Drawing.Size(244, 20)
        Me.txtBOSPayjur.TabIndex = 46
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "BOS PAYJUR"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(849, 405)
        Me.Controls.Add(Me.txtBOSPayjur)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblBOSPayjur_Card)
        Me.Controls.Add(Me.lblIDRefNo)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.pbPhoto)
        Me.Controls.Add(Me.lblGender_Card)
        Me.Controls.Add(Me.lblDOB_Card)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtAddress6)
        Me.Controls.Add(Me.txtAddress5)
        Me.Controls.Add(Me.txtAddress4)
        Me.Controls.Add(Me.txtAddress3)
        Me.Controls.Add(Me.txtAddress2)
        Me.Controls.Add(Me.txtAddress1)
        Me.Controls.Add(Me.txtLast2)
        Me.Controls.Add(Me.txtLast1)
        Me.Controls.Add(Me.txtMiddle2)
        Me.Controls.Add(Me.txtMiddle1)
        Me.Controls.Add(Me.txtFirst2)
        Me.Controls.Add(Me.txtFirst1)
        Me.Controls.Add(Me.Label_Status)
        Me.Controls.Add(Me.cmdReadCard)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtGender)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDOB)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSuffix)
        Me.Controls.Add(Me.txtLast)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMiddle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFirst)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdChipEncode)
        Me.Controls.Add(Me.lstBoxLog)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AFPSLAI - CONTACTLESS"
        CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdChipEncode As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtFirst As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMiddle As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLast As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSuffix As System.Windows.Forms.TextBox
    Friend WithEvents txtDOB As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGender As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pbPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents cmdReadCard As System.Windows.Forms.Button
    Friend WithEvents Label_Status As System.Windows.Forms.Label
    Friend WithEvents lstBoxLog As System.Windows.Forms.ListBox
    Friend WithEvents txtFirst1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFirst2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMiddle1 As System.Windows.Forms.TextBox
    Friend WithEvents txtMiddle2 As System.Windows.Forms.TextBox
    Friend WithEvents txtLast1 As System.Windows.Forms.TextBox
    Friend WithEvents txtLast2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress4 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress5 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress6 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDOB_Card As System.Windows.Forms.Label
    Friend WithEvents lblGender_Card As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblIDRefNo As System.Windows.Forms.Label
    Friend WithEvents lblBOSPayjur_Card As System.Windows.Forms.Label
    Friend WithEvents txtBOSPayjur As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
