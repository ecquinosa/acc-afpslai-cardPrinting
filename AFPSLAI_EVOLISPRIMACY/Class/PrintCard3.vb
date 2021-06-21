
Imports System.Runtime.InteropServices
Imports AFPSLAI_EVOLISPRIMACY.Spooler
Imports System.Drawing.Printing
Imports System.Threading
Imports System.Windows.Forms

Public Class PrintCard3
    Implements IDisposable

    Private WithEvents m_pDoc As New PrintDocument
    Friend WithEvents ppc As New Printing.PreviewPrintController()

    Private MembershipType As String = "REGULAR"
    Private AssociateType As String = "REGULAR"
    Private CIF As String = "1234567890123"
    Private FirstName As String = "JUAN"
    Private MiddleName As String = "D"
    Private LastName As String = "DELA CRUZ"
    Private Suffix As String = "SR"
    Private DateOfBirth As String = "04/04/1978"
    Private Gender2 As String = "M"
    Private MembershipDate As String = "04/04/2000"
    Private CIF_PrincipalMember As String = "1234567890333"

    Private imgPhoto As Image
    Private imgTemplate As Image
    Private imgTemplate2 As Image

    Public X As Integer
    Public Y As Integer
    Public imgWidth As Integer
    Public imgHeight As Integer

    Public intPage As Short = 1

    Public _IsHasMorePages As Boolean = True

    'Public Property IDRefNo() As String
    '    Get
    '        Return strIDRefNo
    '    End Get
    '    Set(ByVal value As String)
    '        strIDRefNo = value
    '    End Set
    'End Property    

    Public Property Photo() As Image
        Get
            Return imgPhoto
        End Get
        Set(ByVal value As Image)
            imgPhoto = value
        End Set
    End Property

    Public Property Template() As Image
        Get
            Return imgTemplate
        End Get
        Set(ByVal value As Image)
            imgTemplate = value
        End Set
    End Property

    Public Property Template2() As Image
        Get
            Return imgTemplate2
        End Get
        Set(ByVal value As Image)
            imgTemplate2 = value
        End Set
    End Property

    Public Property HasMorePages() As Boolean
        Get
            Return _IsHasMorePages
        End Get
        Set(ByVal value As Boolean)
            _IsHasMorePages = value
        End Set
    End Property

    Public Property Page() As Short
        Get
            Return intPage
        End Get
        Set(ByVal value As Short)
            intPage = value
        End Set
    End Property

    Public Sub New()
        m_pDoc.PrintController = ppc
        m_pDoc.PrinterSettings.PrintToFile = True
    End Sub


#Region "Printing"

    Private Sub m_pDoc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles m_pDoc.BeginPrint
        m_pDoc.DocumentName = "Card Personalization of ID No." & ""
        m_pDoc.DefaultPageSettings.Landscape = False
        m_pDoc.PrinterSettings.Copies = 1
        'm_pDoc.PrinterSettings.PrinterName = "Microsoft XPS Document Writer" 'My.Settings.Printer

    End Sub

    Private Sub m_pDoc_EndPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles m_pDoc.EndPrint
        Dim ppi() As Printing.PreviewPageInfo = ppc.GetPreviewPageInfo()
        For x As Integer = 0 To ppi.Length - 1
            ppi(x).Image.Save("D:\testAFPSLAI.jpg")
        Next
    End Sub

    Private Sub m_pDoc_PrintPage(ByVal sender As System.Object, ByVal e As PrintPageEventArgs) Handles m_pDoc.PrintPage
        Try
            m_pDoc.PrintController = ppc

            e.Graphics.PageUnit = GraphicsUnit.Pixel

            Dim dBlack As New SolidBrush(Color.Black)

            Dim fontHightlight As New Font("Arial", 10.5, FontStyle.Bold)
            Dim fontGeneric As New Font("Arial", 7.5)

            If intPage = 1 Then
                'new template
                e.Graphics.DrawImage(Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes("D:\EDEL\ACC\Projects\AFPSLAI_EVOLISPRIMACY\AFPSLAI\digitID_New.jpg"))), _
                                     40, 0, 5050, 3700)

                'photo
                e.Graphics.DrawImage(Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes("D:\EDEL\ACC\Projects\AFPSLAI_EVOLISPRIMACY\AFPSLAI\photo.jpg"))), _
                                     4200, 430, 700, 750)

                Dim intTextLeftLocationBase As Integer = 200
                Dim intAddedValue As Integer = 40

                e.Graphics.DrawString(MembershipType, fontHightlight, dBlack, 800, 950)
                e.Graphics.DrawString(AssociateType, fontHightlight, dBlack, 800, 1110)
                e.Graphics.DrawString(CIF, fontHightlight, dBlack, 90, 1370)
                e.Graphics.DrawString(LastName, fontHightlight, dBlack, 990, 1370)
                e.Graphics.DrawString(FirstName, fontHightlight, dBlack, 1740, 1370)
                e.Graphics.DrawString(Suffix, fontHightlight, dBlack, 2430, 1370)
                e.Graphics.DrawString(MiddleName, fontHightlight, dBlack, 3290, 1370)
                e.Graphics.DrawString(DateOfBirth, fontHightlight, dBlack, 90, 1660)
                e.Graphics.DrawString(Gender2, fontHightlight, dBlack, 1020, 1660)
                e.Graphics.DrawString(MembershipDate, fontHightlight, dBlack, 1900, 1660)
                e.Graphics.DrawString(CIF_PrincipalMember, fontHightlight, dBlack, 2880, 1660)

                'SIGNATURES
                '#1
                e.Graphics.DrawImage(Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes("D:\EDEL\ACC\Projects\AFPSLAI_EVOLISPRIMACY\AFPSLAI\sig.tiff"))), _
                                     300, 1980, 1150, 300)
                '#2
                e.Graphics.DrawImage(Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes("D:\EDEL\ACC\Projects\AFPSLAI_EVOLISPRIMACY\AFPSLAI\sig.tiff"))), _
                                     300, 2360, 1150, 300)
                '#3
                e.Graphics.DrawImage(Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes("D:\EDEL\ACC\Projects\AFPSLAI_EVOLISPRIMACY\AFPSLAI\sig.tiff"))), _
                                     2180, 1980, 1150, 300)

                '#4
                e.Graphics.DrawImage(Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes("D:\EDEL\ACC\Projects\AFPSLAI_EVOLISPRIMACY\AFPSLAI\sig.tiff"))), _
                                     2180, 2360, 1150, 300)

                'e.Graphics.DrawImage(Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes("D:\EDEL\ACC\Projects\AFPSLAI_EVOLISPRIMACY\AFPSLAI\sig.tiff"))), _
                '                     2180, 4000, 1200, 300)
                'e.Graphics.DrawImage(Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes("D:\EDEL\ACC\Projects\AFPSLAI_EVOLISPRIMACY\AFPSLAI\sig.tiff"))), _
                '                     300, 5000, 1200, 300)

                'BIO
                '#left thumb
                e.Graphics.DrawImage(Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes("D:\EDEL\ACC\Projects\AFPSLAI_EVOLISPRIMACY\AFPSLAI\bio1.jpg"))), _
                                     260, 3000, 500, 530)
                '#right thumb
                e.Graphics.DrawImage(Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes("D:\EDEL\ACC\Projects\AFPSLAI_EVOLISPRIMACY\AFPSLAI\bio2.jpg"))), _
                                     1160, 3000, 500, 530)
                '#left index
                e.Graphics.DrawImage(Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes("D:\EDEL\ACC\Projects\AFPSLAI_EVOLISPRIMACY\AFPSLAI\bio3.jpg"))), _
                                     2100, 3000, 500, 530)

                '#right index
                e.Graphics.DrawImage(Image.FromStream(New System.IO.MemoryStream(IO.File.ReadAllBytes("D:\EDEL\ACC\Projects\AFPSLAI_EVOLISPRIMACY\AFPSLAI\bio4.jpg"))), _
                                     3150, 3000, 500, 530)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Preview()
        Print()
        Dim ppDlg As New PrintPreviewDialog()
        ppDlg.Document = m_pDoc
        ppDlg.Show()
    End Sub

    Public Sub Print()
        m_pDoc.Print()
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

