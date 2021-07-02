
Imports System.Runtime.InteropServices
Imports AFPSLAI_EVOLISPRIMACY.Spooler
Imports System.Drawing.Printing

Public Class PrintCard
    Implements IDisposable

    Private WithEvents m_pDoc As New PrintDocument

#Region " Printing "

    Private Sub m_pDoc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles m_pDoc.BeginPrint
        'm_pDoc.DocumentName = "Card Personalization of ID No." & cardElements(0)
        'm_pDoc.DefaultPageSettings.Landscape = True
        'm_pDoc.PrinterSettings.Copies = 1
        'm_pDoc.PrinterSettings.PrinterName = My.Settings.CardPrinter

        ''for testing purpose only
        'Dim ps As PaperSize = Nothing

        'For Each s In m_pDoc.PrinterSettings.PaperSizes
        '    If s.PaperName = "CR80" Then
        '        ps = s
        '        Console.WriteLine(s)
        '    End If
        'Next

        m_pDoc.DocumentName = "Card Personalization of ID No." & Main.cfp.cardNo
        'm_pDoc.DefaultPageSettings.PaperSize = ps
        m_pDoc.DefaultPageSettings.Landscape = False
        m_pDoc.PrinterSettings.Copies = 1
        m_pDoc.PrinterSettings.PrinterName = "Microsoft XPS Document Writer"
    End Sub

    Private Sub m_pDoc_PrintPage(ByVal sender As System.Object, ByVal e As PrintPageEventArgs) Handles m_pDoc.PrintPage
        Try
            e.Graphics.PageUnit = GraphicsUnit.Pixel

            Dim dBlack As New SolidBrush(Color.Black)
            Dim font12 As New Font("OCRB", 12, FontStyle.Regular)
            Dim font10 As New Font("OCRB", 10, FontStyle.Regular)

            Dim intTextLeftLocationBase As Integer = 40 ' - 30
            Dim intTextTopLocationBase As Integer = 40
            Dim intAddedValue As Integer = 40

            Dim imgTemplate As Image = Image.FromStream(New System.IO.MemoryStream(System.IO.File.ReadAllBytes(Application.StartupPath & "\card_front.jpg")))
            If CBool(Main.chkIncludeIdTemplate.Checked) Then e.Graphics.DrawImage(imgTemplate, 0, 0, 1020, 650)

            Dim imgPhoto As Image = Image.FromStream(New System.IO.MemoryStream(Convert.FromBase64String(Main.cfp.base64Photo)))
            e.Graphics.DrawImage(imgPhoto, 100, 100, 100, 100)

            Dim name As String = Main.cfp.first_name

            Dim cardNo As String = Main.cfp.cardNo
            e.Graphics.DrawString(String.Format("{0} {1} {2} {3}", cardNo.Substring(0, 4), cardNo.Substring(4, 4), cardNo.Substring(8, 4), cardNo.Substring(12, 4)), font12, dBlack, intTextLeftLocationBase, (intTextTopLocationBase + (intAddedValue * 2)))
            e.Graphics.DrawString(Convert.ToDateTime(Main.txtMembershipDate.Text).ToString("MM/yy"), font12, dBlack, intTextLeftLocationBase, (intTextTopLocationBase + (intAddedValue * 2)))
            e.Graphics.DrawString(String.Format("{0}/{1}", Main.cfp.card_valid_thru.Substring(2, 2), Main.cfp.card_valid_thru.Substring(0, 2)), font12, dBlack, intTextLeftLocationBase, (intTextTopLocationBase + (intAddedValue * 2)))
            e.Graphics.DrawString(Main.txtCardName.Text, font12, dBlack, intTextLeftLocationBase, (intTextTopLocationBase + (intAddedValue * 2)))
            e.Graphics.DrawString(Main.txtCIF.Text, font10, dBlack, intTextLeftLocationBase, (intTextTopLocationBase + (intAddedValue * 2)))
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub Print()
        m_pDoc.Print()
    End Sub

    Public Sub Preview()
        Dim ppDlg As New PrintPreviewDialog()
        ppDlg.Document = m_pDoc
        ppDlg.Show()
    End Sub

#End Region

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
                'imgPhoto.Dispose()
            End If

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class

