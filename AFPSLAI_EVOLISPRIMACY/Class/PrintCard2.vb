
Imports System.Runtime.InteropServices
Imports AFPSLAI_EVOLISPRIMACY.Spooler
Imports System.Drawing.Printing
Imports System.Threading
Imports System.Windows.Forms

Public Class PrintCard2
    Implements IDisposable

    Private WithEvents m_pDoc As New PrintDocument

    Private strIDRefNo As String = ""
    Private strBOSPayjur As String = ""
    Private strGender As String = ""
    Private strDOB As String = ""

    Private strAddress As String = ""

    Private imgPhoto As Image
    Private imgTemplate As Image
    Private imgTemplate2 As Image

    Public X As Integer
    Public Y As Integer
    Public imgWidth As Integer
    Public imgHeight As Integer

    Public intPage As Short = 1

    Public _IsHasMorePages As Boolean = True

    Public Property IDRefNo() As String
        Get
            Return strIDRefNo
        End Get
        Set(ByVal value As String)
            strIDRefNo = value
        End Set
    End Property

    Public Property BOSPayjur() As String
        Get
            Return strBOSPayjur
        End Get
        Set(ByVal value As String)
            strBOSPayjur = value
        End Set
    End Property

    Public Property Gender() As String
        Get
            Return strGender
        End Get
        Set(ByVal value As String)
            strGender = value
        End Set
    End Property

    Public Property DOB() As String
        Get
            Return strDOB
        End Get
        Set(ByVal value As String)
            strDOB = value
        End Set
    End Property

    Public Property Address() As String
        Get
            Return strAddress
        End Get
        Set(ByVal value As String)
            strAddress = value
        End Set
    End Property

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


#Region "Printing"

    Private Sub m_pDoc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles m_pDoc.BeginPrint
        m_pDoc.DocumentName = "Card Personalization of ID No." & strIDRefNo
        m_pDoc.DefaultPageSettings.Landscape = True
        m_pDoc.PrinterSettings.Copies = 1
        m_pDoc.PrinterSettings.PrinterName = My.Settings.Printer
    End Sub

    Private Sub m_pDoc_PrintPage(ByVal sender As System.Object, ByVal e As PrintPageEventArgs) Handles m_pDoc.PrintPage
        Try
            e.Graphics.PageUnit = GraphicsUnit.Pixel

            Dim dBlack As New SolidBrush(Color.Black)

            Dim fontHightlight As New Font("Arial", 10.5, FontStyle.Bold)
            Dim fontGeneric As New Font("Arial", 7.5)

            If intPage = 1 Then
                e.Graphics.DrawImage(imgTemplate, 0, 0, 1050, 640)
                'e.Graphics.DrawImage(imgPhoto, 85, 228, 295, 370)
                e.Graphics.DrawImage(imgPhoto, 83, 190, 300, 380)

                Dim intTextLeftLocationBase As Integer = 200
                Dim intAddedValue As Integer = 40

                e.Graphics.DrawString(strGender, fontGeneric, dBlack, 675, intTextLeftLocationBase)
                e.Graphics.DrawString(strDOB, fontGeneric, dBlack, 675, (intTextLeftLocationBase + (intAddedValue * 1)))
                e.Graphics.DrawString(strIDRefNo, fontGeneric, dBlack, 675, (intTextLeftLocationBase + (intAddedValue * 2)))
                e.Graphics.DrawString(strBOSPayjur, fontGeneric, dBlack, 675, (intTextLeftLocationBase + (intAddedValue * 3)))


                e.HasMorePages = _IsHasMorePages
                intPage += 1
                'Else
              
            ElseIf intPage = 2 Then
                e.Graphics.DrawImage(imgTemplate2, 0, 0, 1050, 640)
                Dim intTextLeftLocationBase As Integer = 200
                Dim intAddedValue As Integer = 40
                e.Graphics.DrawString(strAddress, fontGeneric, dBlack, 175, 270)
                e.Graphics.DrawString(Now.Today.ToString("MM/dd/yyyy"), fontGeneric, dBlack, 575, 270)
                e.Graphics.DrawString(strIDRefNo, fontGeneric, dBlack, 575, 270 + 80)
                e.Graphics.DrawString(strBOSPayjur, fontGeneric, dBlack, 575, 270 + 160)

                intPage += 1
                _IsHasMorePages = False

            End If

            'Dim flags As TextFormatFlags = TextFormatFlags.WordBreak
            'e.Graphics.DrawString(strAddress, fontGeneric, dBlack, 400, 410)

            'TextRenderer.DrawText(e.Graphics, strAddress, New Font("Arial", 23), New Rectangle(400, 405, 500, 400), Color.Black, flags)

            'Dim flags As TextFormatFlags = TextFormatFlags.WordBreak
            'TextRenderer.DrawText(e.Graphics, "TEST ".PadRight(200, "x"), New Font("Arial", 15, FontStyle.Bold), New Rectangle(400, 460, 300, 300), Color.Black, flags)

            'e.Graphics.PageUnit = GraphicsUnit.Pixel

            'Dim dBlack As New SolidBrush(Color.Black)

            'Dim fontHightlight As New Font("Arial", 10.5, FontStyle.Bold)
            'Dim fontGeneric As New Font("Arial", 8.5)

            'e.Graphics.DrawImage(imgTemplate, 0, 0, 1050, 640)
            'e.Graphics.DrawImage(imgPhoto, 85, 228, 295, 370)

            'e.Graphics.DrawString(strIDRefNo, fontHightlight, dBlack, 400, 260)
            'e.Graphics.DrawString(strName, fontHightlight, dBlack, 400, 310)
            'e.Graphics.DrawString(strDOBandGender, fontGeneric, dBlack, 400, 360)

            'Dim flags As TextFormatFlags = TextFormatFlags.WordBreak
            ''e.Graphics.DrawString(strAddress, fontGeneric, dBlack, 400, 410)

            'TextRenderer.DrawText(e.Graphics, strAddress, New Font("Arial", 23), New Rectangle(400, 405, 500, 400), Color.Black, flags)

            ''Dim flags As TextFormatFlags = TextFormatFlags.WordBreak
            ''TextRenderer.DrawText(e.Graphics, "TEST ".PadRight(200, "x"), New Font("Arial", 15, FontStyle.Bold), New Rectangle(400, 460, 300, 300), Color.Black, flags)
        Catch ex As Exception

        End Try
        'e.Graphics.DrawImage(imgTemplate2, 0, 0, 1050, 640)
        'e.HasMorePages = False
    End Sub

    Public Sub Print()
        m_pDoc.Print()
        'm_pDoc.Print()
        'Dim ppDlg As New PrintPreviewDialog()
        'ppDlg.Document = m_pDoc
        'ppDlg.Show()
    End Sub

#End Region

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
                imgPhoto.Dispose()
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

