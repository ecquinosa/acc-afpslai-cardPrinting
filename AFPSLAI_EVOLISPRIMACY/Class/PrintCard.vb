
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

    Private Function GetFontStyle(ByVal fs As Integer) As FontStyle
        Select Case fs
            Case 1
                Return FontStyle.Regular
            Case 2
                Return FontStyle.Bold
            Case 3
                Return FontStyle.Italic
        End Select
    End Function

    Private Sub m_pDoc_PrintPage(ByVal sender As System.Object, ByVal e As PrintPageEventArgs) Handles m_pDoc.PrintPage
        Try
            e.Graphics.PageUnit = GraphicsUnit.Pixel

            Dim objPhoto = Main.cardElements.Photo
            Dim objMemberSince = Main.cardElements.MemberSince
            Dim objValidThru = Main.cardElements.ValidThru
            Dim objName = Main.cardElements.Name
            Dim objCIF = Main.cardElements.CIF

            Dim dBlack As New SolidBrush(Color.Black)
            Dim fontMemberSince As New Font(objMemberSince.font_name, CSng(objMemberSince.font_size), GetFontStyle(objMemberSince.font_style))
            Dim fontValidThru As New Font(objValidThru.font_name, CSng(objValidThru.font_size), GetFontStyle(objValidThru.font_style))
            Dim fontName As New Font(objName.font_name, CSng(objName.font_size), GetFontStyle(objName.font_style))
            Dim fontCIF As New Font(objCIF.font_name, CSng(objCIF.font_size), GetFontStyle(objCIF.font_style))

            Dim imgTemplate As Image = Image.FromStream(New System.IO.MemoryStream(System.IO.File.ReadAllBytes(Application.StartupPath & "\card_front.jpg")))
            If CBool(Main.chkIncludeIdTemplate.Checked) Then e.Graphics.DrawImage(imgTemplate, 0, 0, 1020, 650)

            Dim imgPhoto As Image = Image.FromStream(New System.IO.MemoryStream(Convert.FromBase64String(Main.cfp.base64Photo)))
            e.Graphics.DrawImage(imgPhoto, CSng(objPhoto.x), CSng(objPhoto.y), CSng(objPhoto.width), CSng(objPhoto.height))

            Dim cardNo As String = Main.cfp.cardNo
            'e.Graphics.DrawString(String.Format("{0} {1} {2} {3}", cardNo.Substring(0, 4), cardNo.Substring(4, 4), cardNo.Substring(8, 4), cardNo.Substring(12, 4)), font12, dBlack, intTextLeftLocationBase, (intTextTopLocationBase + (intAddedValue * 2)))
            e.Graphics.DrawString(Convert.ToDateTime(Main.txtMembershipDate.Text).ToString("MM/yy"), fontMemberSince, dBlack, CSng(objMemberSince.x), CSng(objMemberSince.y))
            e.Graphics.DrawString(String.Format("{0}/{1}", Main.cfp.card_valid_thru.Substring(2, 2), Main.cfp.card_valid_thru.Substring(0, 2)), fontValidThru, dBlack, CSng(objValidThru.x), CSng(objValidThru.y))
            e.Graphics.DrawString(Main.txtCardName.Text, fontName, dBlack, CSng(objName.x), CSng(objName.y))
            e.Graphics.DrawString(Main.txtCIF.Text, fontCIF, dBlack, CSng(objCIF.x), CSng(objCIF.y))
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

