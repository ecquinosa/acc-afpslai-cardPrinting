﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LogIN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LogIN))
        Me.lblResult = New System.Windows.Forms.Label()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblResult.Location = New System.Drawing.Point(245, 69)
        Me.lblResult.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(0, 16)
        Me.lblResult.TabIndex = 21
        '
        'panel2
        '
        Me.panel2.BackgroundImage = CType(resources.GetObject("panel2.BackgroundImage"), System.Drawing.Image)
        Me.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panel2.Location = New System.Drawing.Point(15, 62)
        Me.panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(133, 127)
        Me.panel2.TabIndex = 20
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(247, 124)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(64)
        Me.txtPassword.Size = New System.Drawing.Size(240, 25)
        Me.txtPassword.TabIndex = 15
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.DimGray
        Me.label1.Location = New System.Drawing.Point(153, 127)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(77, 18)
        Me.label1.TabIndex = 18
        Me.label1.Text = "Password"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(247, 91)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(240, 25)
        Me.txtUsername.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(153, 94)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 18)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Username"
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(389, 158)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(100, 38)
        Me.btnLogin.TabIndex = 16
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'panel1
        '
        Me.panel1.BackgroundImage = CType(resources.GetObject("panel1.BackgroundImage"), System.Drawing.Image)
        Me.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.panel1.Location = New System.Drawing.Point(15, 1)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(355, 64)
        Me.panel1.TabIndex = 22
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 183)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(88, 16)
        Me.LinkLabel1.TabIndex = 23
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "API SOURCE"
        Me.LinkLabel1.Visible = False
        '
        'LogIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(504, 202)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "LogIN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CARD PRINTING AND MERGING SOFTWARE"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents btnLogin As System.Windows.Forms.Button
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
