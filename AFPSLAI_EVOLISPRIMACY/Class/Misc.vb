
Public Class Misc

    Public Sub New(Optional ByVal strReaderName As String = "", Optional ByRef lstBoxLog As ListBox = Nothing)
        Me.lstBoxLog = lstBoxLog
        Me.strReaderName = strReaderName
    End Sub

    Private lstBoxLog As ListBox
    Private strReaderName As String = ""

    'Public Enum SectorID
    '    IDRefNo = 1
    '    BOSPayjur
    '    FirstName1
    '    MiddleName1
    '    LastName1
    '    Suffix
    '    BirthDate
    '    Gender
    '    Address1
    '    Address2
    '    Address3
    '    Address4
    '    Address5
    '    Address6
    '    'Address6

    '    'IDRefNo = 1
    '    'BOSPayjur
    '    'FirstName1
    '    'FirstName2
    '    'MiddleName1
    '    'MiddleName2
    '    'LastName1
    '    'LastName2
    '    'Suffix
    '    'BirthDate
    '    'Gender
    '    'Address1
    '    'Address2
    '    'Address3
    '    'Address4
    '    'Address5
    '    ''Address6
    'End Enum


    Private Function ExcelConStr(ByVal strExcelPath As String) As String
        Return "Provider=Microsoft.Jet.OLEDB.4.0;Excel 8.0; Extended Properties=HDR=Yes; IMEX=1;Data Source=" + strExcelPath + ""
    End Function

    Public Sub LoadSheets(ByVal strExcelPath As String, ByVal cboSheet As ComboBox, Optional ByRef arrList As ArrayList = Nothing)
        Try
            Dim con As New System.Data.OleDb.OleDbConnection(ExcelConStr(strExcelPath))
            con.Open()

            Dim dtSheets As DataTable = con.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, Nothing)
            'Dim dtRowHeader As DataTable = con.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Columns, Nothing)
            con.Close()

            For Each rw As DataRow In dtSheets.Rows
                cboSheet.Items.Add(rw("TABLE_NAME"))
            Next

            'If Not arrList Is Nothing Then
            '    For Each rw2 As DataRow In dtRowHeader.Rows
            '        arrList.Add(rw2("COLUMN_NAME"))
            '    Next
            'End If

            If cboSheet.Items.Count > 0 Then cboSheet.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed to load sheets...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Public Sub LoadExcelFile(ByVal strExcelPath As String, ByVal strExcelSheet As String, ByRef dt As DataTable)
        Try
            Dim ds As New DataSet()
            Dim con As New System.Data.OleDb.OleDbConnection(ExcelConStr(strExcelPath))
            Dim cmd As System.Data.OleDb.OleDbCommand
            'cmd = New System.Data.OleDb.OleDbCommand("SELECT * FROM [" + strExcelSheet + "$] WHERE [last name] <> ''", con)
            cmd = New System.Data.OleDb.OleDbCommand("SELECT * FROM [" + strExcelSheet + "]", con)
            cmd.CommandType = CommandType.Text

            con.Open()

            Dim da As New System.Data.OleDb.OleDbDataAdapter(cmd)
            da.Fill(ds, "Result")

            dt = ds.Tables(0)
            con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed to load excel file...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LoadFile(ByRef txtFile As TextBox, Optional ByVal intFileType As Short = 0)
        Dim openDLG As New OpenFileDialog

        openDLG.InitialDirectory = Application.StartupPath
        If intFileType = 0 Then 'excel
            openDLG.Filter = "Microsoft Excel 2003 | *.xls; *.xlsx"
        ElseIf intFileType = 1 Then 'notepad
            openDLG.Filter = "Text Files | *.txt"
        End If


        If openDLG.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFile.Text = openDLG.FileName
        End If

        openDLG.Dispose()
    End Sub

End Class
