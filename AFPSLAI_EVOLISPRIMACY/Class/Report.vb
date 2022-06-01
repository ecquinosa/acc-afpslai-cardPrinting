
Imports System.IO
Imports OfficeOpenXml

Public Class Report

    Public Shared Function GenerateReport(ByVal grid As DataGridView, ByVal reportName As String, ByVal reportPeriod As String) As Boolean
        Try
            Dim fileName As String = ""
            Dim sfd As New SaveFileDialog
            If sfd.ShowDialog = DialogResult.OK Then
                fileName = sfd.FileName
            End If
            sfd.Dispose()

            If fileName = "" Then
                accAfpslaiEmvObjct.Utilities.ShowWarningMessage("No file name entered.")
                Return False
            End If

            fileName = fileName.Replace(".xls", "").Replace(".xlsx", "")

            Dim newFile As FileInfo = New FileInfo(String.Format("{0}.xlsx", fileName))
            Dim rng As ExcelRange = Nothing
            Dim branch As String = My.Settings.BranchIssue
            If Main.dcsUser.roleId = 2 Then branch = "allBranch"

            Using xlPck As ExcelPackage = New ExcelPackage(newFile)
                Dim ws As ExcelWorksheet = xlPck.Workbook.Worksheets.Add(branch & "-" & DateTime.Now.ToString("yyyyMMdd_hhmmss"))
                ws.View.ShowGridLines = False

                Dim intColBase As Integer = 1
                Dim intCol As Integer = intColBase
                Dim intRow As Integer = 5

                'rng = ws.Cells("A1:A1")
                'rng.Merge = True

                For Each gridCol As DataGridViewColumn In grid.Columns
                    If gridCol.Name.Substring(gridCol.Name.Length - 2).ToUpper() <> "ID" Then
                        PopulateCell(ws, gridCol.HeaderText, intRow, intCol, OfficeOpenXml.Style.ExcelHorizontalAlignment.Center, OfficeOpenXml.Style.ExcelVerticalAlignment.Top, 10, True, False, True, "", False)
                    End If
                Next

                intCol = intColBase
                intRow += 1

                For Each gridRow As DataGridViewRow In grid.Rows
                    For Each gridCol As DataGridViewColumn In grid.Columns
                        If gridCol.Name.Substring(gridCol.Name.Length - 2).ToUpper() <> "ID" Then
                            Dim value = grid.Item(gridCol.Index, gridRow.Index).Value
                            If IsDate(value.ToString()) Then
                                value = CDate(value).ToString("MM/dd/yyyy")
                            End If

                            If Not IsNumeric(value.ToString()) Then
                                'If value.ToString().Trim().ToUpper() = "CORPORATE REGULAR" Then value = "Regular"

                                PopulateCell(ws, value, intRow, intCol, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left, OfficeOpenXml.Style.ExcelVerticalAlignment.Top, 10, False, False, True, "", False)
                            Else
                                PopulateCell(ws, value, intRow, intCol, OfficeOpenXml.Style.ExcelHorizontalAlignment.Center, OfficeOpenXml.Style.ExcelVerticalAlignment.Top, 10, False, False, True, "", False)
                            End If
                        End If
                    Next
                    intRow += 1
                    intCol = intColBase
                Next

                For i = 1 To grid.Columns.Count
                    ws.Column(i).AutoFit()
                Next

                PopulateCell(ws, reportName, 1, 1, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left, OfficeOpenXml.Style.ExcelVerticalAlignment.Top, 10, True, True, False, "", False)
                PopulateCell(ws, reportPeriod, 2, 1, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left, OfficeOpenXml.Style.ExcelVerticalAlignment.Top, 10, True, True, False, "", False)
                PopulateCell(ws, "TOTAL: " & grid.Rows.Count.ToString("N0"), 3, 1, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left, OfficeOpenXml.Style.ExcelVerticalAlignment.Top, 10, True, True, False, "", False)

                xlPck.Save()
            End Using


            Return True
        Catch ex As Exception
            'Program.logger.[Error]("Failed to generate report. Runtime error " & ex.Message)
            Return False
        Finally
        End Try
    End Function

    Public Shared Sub PopulateCell(ByRef ws As ExcelWorksheet, ByVal value As Object, ByRef intRow As Integer, ByRef intCol As Integer, ByVal ExcelHorizontalAlignment As OfficeOpenXml.Style.ExcelHorizontalAlignment, ByVal ExcelVerticalAlignment As OfficeOpenXml.Style.ExcelVerticalAlignment, ByVal ExcelFontSize As Integer, ByVal IsBold As Boolean, ByVal Optional isIncrementRow As Boolean = False, ByVal Optional isIncrementColumn As Boolean = True, ByVal Optional ExcelNumberFormat As String = "", ByVal Optional IsPutCellBorders As Boolean = True)
        ws.Cells(intRow, intCol).Value = value
        ws.Cells(intRow, intCol).Style.HorizontalAlignment = ExcelHorizontalAlignment
        ws.Cells(intRow, intCol).Style.VerticalAlignment = ExcelVerticalAlignment
        ws.Cells(intRow, intCol).Style.Font.Bold = IsBold
        ws.Cells(intRow, intCol).Style.Font.Size = ExcelFontSize
        ws.Cells(intRow, intCol).Style.Font.Color.SetColor(Color.Black)
        If ExcelNumberFormat <> "" Then ws.Cells(intRow, intCol).Style.Numberformat.Format = ExcelNumberFormat

        If IsPutCellBorders Then
            ws.Cells(intRow, intCol).Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
            ws.Cells(intRow, intCol).Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
            ws.Cells(intRow, intCol).Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
            ws.Cells(intRow, intCol).Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
        End If

        If isIncrementRow Then intRow += 1
        If isIncrementColumn Then intCol += 1
    End Sub

End Class
