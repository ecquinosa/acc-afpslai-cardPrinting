Public Class Form1

    Private PhotoPath As String = ""

    Private Sub cmdChipEncode_Click(sender As System.Object, e As System.EventArgs) Handles cmdChipEncode.Click
        'Try
        '    Dim result As String = CheckPrinter()
        '    If result <> "" Then
        '        MessageBox.Show(result, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        EjectCard()
        '        Exit Sub
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    EjectCard()
        '    Exit Sub
        'End Try

        FeedCard()

        System.Threading.Thread.Sleep(3000)
        Application.DoEvents()

        FormatCard()

        Dim strData(8) As String
        strData(0) = txtID.Text
        strData(1) = txtBOSPayjur.Text
        strData(2) = txtFirst.Text
        strData(3) = txtMiddle.Text
        strData(4) = txtLast.Text
        strData(5) = txtSuffix.Text
        strData(6) = txtDOB.Text
        strData(7) = txtGender.Text
        strData(8) = txtAddress.Text

        Dim WriteToCard As New WriteToCard(lstBoxLog, Label_Status, strData)
        If Not WriteToCard.SuccessWrite Then
            MessageBox.Show(WriteToCard.ErrorMessage, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        EjectCard()
    End Sub

    Private Sub cmdReadCard_Click(sender As System.Object, e As System.EventArgs) Handles cmdReadCard.Click
        'Try
        '    Dim result As String = CheckPrinter()
        '    If result <> "" Then
        '        MessageBox.Show(result, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        EjectCard()
        '        Exit Sub
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    EjectCard()
        '    Exit Sub
        'End Try

        FeedCard()

        Dim ReadCard As New ReadCardData(lstBoxLog, Label_Status)
        If ReadCard.SuccessRead Then

            txtID.Text = ReadCard.IDRefNo
            txtBOSPayjur.Text = ReadCard.BOSPayjur.Trim
            txtFirst1.Text = ReadCard.FirstName1.Trim
            txtFirst2.Text = ReadCard.FirstName2.Trim
            txtFirst.Text = txtFirst1.Text.Trim & txtFirst2.Text.Trim
            txtMiddle1.Text = ReadCard.MiddleName1.Trim
            txtMiddle2.Text = ReadCard.MiddleName2.Trim
            txtMiddle.Text = txtMiddle1.Text.Trim & txtMiddle2.Text.Trim
            txtLast1.Text = ReadCard.LastName1.Trim
            txtLast2.Text = ReadCard.LastName2.Trim
            txtLast.Text = txtLast1.Text.Trim & txtLast2.Text.Trim
            txtDOB.Text = ReadCard.BirthDate
            txtGender.Text = ReadCard.Gender
            txtAddress1.Text = ReadCard.Address1
            txtAddress2.Text = ReadCard.Address2
            txtAddress3.Text = ReadCard.Address3
            txtAddress4.Text = ReadCard.Address4
            txtAddress5.Text = ReadCard.Address5
            txtAddress6.Text = ReadCard.Address6
            txtAddress.Text = txtAddress1.Text.Trim & txtAddress2.Text.Trim & txtAddress3.Text.Trim & txtAddress4.Text.Trim & txtAddress5.Text.Trim ' & txtAddress6.Text

            lblIDRefNo.Text = txtID.Text
            'lblName_Card.Text = IIf(txtFirst.Text.Trim = "", "", txtFirst.Text.Trim & " ") & _
            '                  IIf(txtMiddle.Text.Trim = "", " ", txtMiddle.Text.Trim & " ") & _
            '                  txtLast.Text.Trim
            lblDOB_Card.Text = txtDOB.Text.Trim
            lblGender_Card.Text = txtGender.Text.Trim
            'lblAddress_Card.Text = txtAddress.Text.Trim
        Else
            MessageBox.Show(ReadCard.ErrorMessage, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        EjectCard()
    End Sub

    Private Function CheckPrinter() As String
        Dim m As New MagEncodingAndPrinting
        Try
            Dim result As String
            m.ThrowCommand("Sic", result)
            m = Nothing

            Return result
        Catch ex As Exception
            Return "Error"
        Finally
            m = Nothing
        End Try
    End Function

    Private Sub FeedCard()
        Dim m As New MagEncodingAndPrinting
        m.FeedCard()
        m = Nothing
    End Sub

    Private Sub EjectCard()
        Dim m As New MagEncodingAndPrinting
        m.EjectCard()
        m = Nothing
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub FormatCard()
        Dim FormatCard As New FormatCard(My.Settings.PCSCReader, lstBoxLog, Label_Status)
        FormatCard.FormatAllSectors()
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ResetForm()
    End Sub

    Private Sub ResetForm()
        txtID.Clear()
        txtBOSPayjur.Clear()
        txtFirst.Clear()
        txtFirst1.Clear()
        txtFirst2.Clear()
        txtMiddle.Clear()
        txtMiddle1.Clear()
        txtMiddle2.Clear()
        txtLast.Clear()
        txtLast1.Clear()
        txtLast2.Clear()
        txtSuffix.Clear()
        txtDOB.Clear()
        txtGender.Clear()
        txtAddress.Clear()
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtAddress3.Clear()
        txtAddress4.Clear()
        txtAddress5.Clear()
        pbPhoto.BackgroundImage = Nothing
        'pbSign.BackgroundImage = Nothing

        lblBOSPayjur_Card.Text = ""
        lblIDRefNo.Text = ""
        lblDOB_Card.Text = ""
        lblGender_Card.Text = ""
    End Sub

    Private Sub cmdBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse.Click
        Dim ofd As New OpenFileDialog
        ofd.DefaultExt = ".xml"
        ofd.InitialDirectory = "D:\EDEL\ACC\Projects\DCS2015\DCS2015\bin\Debug\Captured Data\FINAL"
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            ReadXML(ofd.FileName)

            'Dim sr As New IO.StreamReader(path & "\" & id)
            'Dim strData As String = sr.ReadToEnd
            'sr.Dispose()
            'sr.Close()

            'txtID.Text = strData.Split("|")(1)
            'txtFirst.Text = strData.Split("|")(3)
            'txtMiddle.Text = strData.Split("|")(4)
            'txtLast.Text = strData.Split("|")(5)
            'lblName_Card.Text = IIf(txtFirst.Text.Trim = "", "", txtFirst.Text.Trim & " ") & _
            '                  IIf(txtMiddle.Text.Trim = "", " ", txtMiddle.Text.Trim & " ") & _
            '                  txtLast.Text.Trim

            'txtDOB.Text = strData.Split("|")(8)
            'lblDOB_Card.Text = txtDOB.Text.Trim

            'txtGender.Text = strData.Split("|")(6)
            'lblGender_Card.Text = txtGender.Text

            'lblIDRefNo.Text = txtID.Text

            'txtAddress.Text = IIf(strData.Split("|")(11) = "", "", strData.Split("|")(11) & " ") & _
            '                  IIf(strData.Split("|")(12) = "", "", strData.Split("|")(12) & " ") & _
            '                  IIf(strData.Split("|")(13) = "", "", strData.Split("|")(13) & " ") & _
            '                  IIf(strData.Split("|")(14) = "", "", strData.Split("|")(14) & " ") & _
            '                  IIf(strData.Split("|")(15) = "", "", strData.Split("|")(15) & " ") & _
            '                  IIf(strData.Split("|")(16) = "", "", strData.Split("|")(16) & " ") '& _
            ''strData.Split("|")(17)

            'lblAddress_Card.Text = txtAddress.Text

            PhotoPath = ofd.FileName.Replace(".xml", "_Photo.jpg")

            'For Each strFile As String In IO.Directory.GetFiles(path)
            '    If IO.Path.GetFileName(strFile).Contains("_Photo") Then
            '        PhotoPath = strFile
            '    End If
            'Next

            pbPhoto.BackgroundImage = Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes(PhotoPath)))
        End If
        ofd.Dispose()

        'Dim path2 As String = "D:\EDEL\ACC\Projects\DCS2015\DCS2015\bin\Debug\Captured Data\FINAL\12152015\DCS20151001-00001_20151215_0001"
        'ReadXML(path2)

        'For Each strFile As String In IO.Directory.GetFiles(path2)
        '    If IO.Path.GetFileName(strFile).Contains("_Photo") Then
        '        PhotoPath = strFile
        '    End If
        'Next

        'pbPhoto.BackgroundImage = Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes(PhotoPath)))

        'Return

        'Dim ofd As New FolderBrowserDialog
        'If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Dim path As String = ofd.SelectedPath
        '    Dim id As String = path.Substring(path.LastIndexOf("\") + 1)

        '    ReadXML(path)


        '    'pbSign.BackgroundImage = Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes(path & "\" & id & "_Signature.tiff")))
        'End If
    End Sub

    Private Sub ReadXML(ByVal strFile As String)

        Dim strElementName As String = ""

        Dim reader As System.Xml.XmlTextReader = New System.Xml.XmlTextReader(strFile)
        Do While (reader.Read())
            Select Case reader.NodeType
                Case System.Xml.XmlNodeType.Element 'Display beginning of element.
                    strElementName = reader.Name
                    Console.Write("<" + reader.Name)
                    If reader.HasAttributes Then 'If attributes exist
                        While reader.MoveToNextAttribute()
                            'Display attribute name and value.
                            Console.Write(" {0}='{1}'", reader.Name, reader.Value)
                        End While
                    End If
                    Console.WriteLine(">")
                Case System.Xml.XmlNodeType.Text 'Display the text in each element.
                    Console.WriteLine(reader.Value)
                    Select Case strElementName
                        Case "MemberNo"
                            txtID.Text = reader.Value
                            lblIDRefNo.Text = txtID.Text
                        Case "BOSPayjur"
                            txtBOSPayjur.Text = reader.Value
                            lblBOSPayjur_Card.Text = txtBOSPayjur.Text
                        Case "FirstName"
                            txtFirst.Text = reader.Value
                        Case "MiddleName"
                            txtMiddle.Text = reader.Value
                        Case "LastName"
                            txtLast.Text = reader.Value
                        Case "Gender"
                            txtGender.Text = reader.Value
                            lblGender_Card.Text = txtGender.Text
                        Case "DateOfBirth"
                            txtDOB.Text = reader.Value
                            lblDOB_Card.Text = txtDOB.Text
                        Case "HouseNo", "BlockNo", "LotNo", "StreetName", "Barangay", "Municipality"
                            txtAddress.Text += IIf(reader.Value = "", "", reader.Value & " ")
                            'strData.Split("|")(17)
                    End Select
                Case System.Xml.XmlNodeType.EndElement 'Display end of element.
                    Console.Write("</" + reader.Name)
                    Console.WriteLine(">")
            End Select
        Loop

        'For Each strFile As String In IO.Directory.GetFiles(selectedPath)
        '    If IO.Path.GetExtension(strFile) = ".xml" Then

        '    End If
        'Next
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        PrintCard()
    End Sub

    Private Sub PrintCard()
        'Dim template As String = "AFPSLAI card 100215 joel.jpg"
        Dim template As String = "AFPSLAI ID - Front - Landscape Design 2 121115 arn.jpg"
        Dim template2 As String = "AFPSLAI ID - back - Landscape Design 2 121115 arn.jpg"

        Dim printcard As New PrintCard2()

        printcard.Gender = lblGender_Card.Text
        printcard.DOB = lblDOB_Card.Text.Trim
        printcard.IDRefNo = lblIDRefNo.Text.Trim
        printcard.BOSPayjur = lblBOSPayjur_Card.Text.Trim

        printcard.Address = txtAddress.Text.Trim

        printcard.Template = Image.FromFile(template)
        printcard.Template2 = Image.FromFile(template2)
        printcard.Photo = Image.FromFile(PhotoPath)
        printcard.Print()

        'printcard.IDRefNo = lblIDRefNo.Text.Trim
        'printcard.Name = lblName_Card.Text.Trim
        'printcard.DOBandGender = lblDOB_Card.Text.PadRight(20, " ") & lblGender_Card.Text.Trim
        'printcard.Address = lblAddress_Card.Text.Trim
        'printcard.Template = Image.FromFile(template)
        'printcard.Photo = Image.FromFile(PhotoPath)
        'printcard.Print()



        'printcard.Dispose()
        'printcard = Nothing
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Button1.PerformClick()
    End Sub

End Class
