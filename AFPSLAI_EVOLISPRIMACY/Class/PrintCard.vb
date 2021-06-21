
Imports System.Runtime.InteropServices
Imports AFPSLAI_EVOLISPRIMACY.Spooler
Imports System.Drawing.Printing
Imports System.Threading
Imports System.Windows.Forms

Public Class PrintCard
    Implements IDisposable

    Public Shared presidentSignatureFile As String = Application.StartupPath & "\Images\pres_sign.png"

    Private WithEvents m_pDoc As New PrintDocument

    Private cardElements(12) As String

    'Private _CIF As String = "" '0
    'Private _CompleteName As String = "" '1
    'Private _Address As String = ""
    'Private _ContactNos As String = ""
    'Private _DateOfBirth As String = ""
    'Private _IDNumber As String = ""
    'Private _DateOfIssue As String = ""
    'Private _ContactName As String = ""
    'Private _ContactContactNos As String = ""
    'Private _Branch As String = "" '9
    'Private _PhotoPath As String = "" '10
    'Private _SignaturePath As String = "" '11 
    'Private _BarcodePath As String = "" '11 

    Public X As Integer
    Public Y As Integer
    Public imgWidth As Integer
    Public imgHeight As Integer

    Public intPage As Short = 1

    Public _IsHasMorePages As Boolean = True

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


#Region " Printing "

    Private fingerprints As List(Of String)

    Public Sub New(ByVal fingerprints As List(Of String), ByVal ParamArray param() As String)
        cardElements = param
        Me.fingerprints = fingerprints
    End Sub

    Private Sub m_pDoc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles m_pDoc.BeginPrint
        'm_pDoc.DocumentName = "Card Personalization of ID No." & cardElements(0)
        'm_pDoc.DefaultPageSettings.Landscape = True
        'm_pDoc.PrinterSettings.Copies = 1
        'm_pDoc.PrinterSettings.PrinterName = My.Settings.CardPrinter

        ''for testing purpose only
        Dim ps As PaperSize = Nothing

        For Each s In m_pDoc.PrinterSettings.PaperSizes
            If s.PaperName = "CR80" Then
                ps = s
                Console.WriteLine(s)
            End If
        Next

        m_pDoc.DocumentName = "Card Personalization of ID No." & cardElements(0)
        m_pDoc.DefaultPageSettings.PaperSize = ps
        m_pDoc.DefaultPageSettings.Landscape = False
        m_pDoc.PrinterSettings.Copies = 1
        m_pDoc.PrinterSettings.PrinterName = "Microsoft Print To PDF"
    End Sub

    Private Sub m_pDoc_PrintPage(ByVal sender As System.Object, ByVal e As PrintPageEventArgs) Handles m_pDoc.PrintPage
        Try
            e.Graphics.PageUnit = GraphicsUnit.Pixel

            Dim dBlack As New SolidBrush(Color.Black)

            Dim fontHightlight As New Font("Arial", 10, FontStyle.Bold)

            Dim fontHightlight_max1 As New Font("Arial", 9, FontStyle.Bold)
            Dim fontHightlight_max2 As New Font("Arial", 8, FontStyle.Bold)

            Dim fontGeneric As New Font("Arial", 8)
            Dim fontGeneric2 As New Font("Arial", 5)

            Dim ce As New CardElements

            If intPage = 1 Then
                Dim imgTemplate As Image = Image.FromStream(New System.IO.MemoryStream(System.IO.File.ReadAllBytes("Approval AFPSLAI ID 051017 MPL-03.jpg")))
                If CBool(cardElements(13)) Then e.Graphics.DrawImage(imgTemplate, 0, 0, 1020, 650)

                If IO.File.Exists(cardElements(10)) Then
                    Dim imgPhoto As Image = Image.FromStream(New System.IO.MemoryStream(System.IO.File.ReadAllBytes(cardElements(10))))
                    e.Graphics.DrawImage(imgPhoto, ce.Photo_X, ce.Photo_Y, ce.Photo_Width, ce.Photo_Height)
                End If

                If IO.File.Exists(cardElements(11)) Then
                    Dim myBitmap As New Bitmap(cardElements(11))
                    myBitmap.MakeTransparent()
                    e.Graphics.DrawImage(myBitmap, ce.Signature_X, ce.Signature_Y, ce.Signature_Width, ce.Signature_Height)
                Else
                    Dim myBitmap As New Bitmap(fingerprints(0))
                    myBitmap.MakeTransparent(Color.White)
                    e.Graphics.DrawImage(myBitmap, ce.Biometric_X, ce.Biometric_Y, ce.Biometric_Width, ce.Biometric_Height)
                    'e.Graphics.DrawImage(myBitmap, Me.X, Me.Y, Me.imgWidth, Me.imgHeight)
                End If

                If IO.File.Exists(cardElements(12)) Then
                    Dim imgBarcode As Image = Image.FromStream(New System.IO.MemoryStream(System.IO.File.ReadAllBytes(cardElements(12))))
                    e.Graphics.DrawImage(imgBarcode, ce.Barcode_X, ce.Barcode_Y, ce.Barcode_Width, ce.Barcode_Height)
                End If

                Dim intTextLeftLocationBase As Integer = ce.Name_X ' - 30
                Dim intTextTopLocationBase As Integer = ce.Name_Y
                Dim intAddedValue As Integer = 40

                Dim name As String = cardElements(1)

                'If name.Length > 32 Then
                '    e.Graphics.DrawString(name, fontHightlight_max2, dBlack, intTextLeftLocationBase, (intTextTopLocationBase + (intAddedValue * 2)))
                'ElseIf name.Length > 20 Then
                '    e.Graphics.DrawString(name, fontHightlight_max1, dBlack, intTextLeftLocationBase, (intTextTopLocationBase + (intAddedValue * 2)))
                'Else
                '    e.Graphics.DrawString(name, fontHightlight, dBlack, intTextLeftLocationBase, (intTextTopLocationBase + (intAddedValue * 2)))
                'End If

                'Dim value As String = "1234567890 1234567890 1234567890 1234567890"
                name = FormatName(name, 24)

                Dim flags As TextFormatFlags = TextFormatFlags.HorizontalCenter
                TextRenderer.DrawText(e.Graphics, name, New Font("Arial", 28, FontStyle.Bold), New Rectangle(ce.Name_X, (intTextTopLocationBase + (intAddedValue * 2)), ce.Barcode_Width + 10, 450), Color.Black, flags)
                If name.Length < 24 Then
                    TextRenderer.DrawText(e.Graphics, cardElements(0), New Font("Arial", 24, FontStyle.Bold), New Rectangle(ce.Name_X, (intTextTopLocationBase + (intAddedValue * 3)), ce.Barcode_Width + 10, 450), Color.Black, flags)
                Else
                    TextRenderer.DrawText(e.Graphics, cardElements(0), New Font("Arial", 24, FontStyle.Bold), New Rectangle(ce.Name_X, (intTextTopLocationBase + (intAddedValue * 4)), ce.Barcode_Width + 10, 450), Color.Black, flags)
                End If


                'e.Graphics.DrawString(cardElements(0), fontGeneric, dBlack, intTextLeftLocationBase + 60, (intTextTopLocationBase + (intAddedValue * 3)))

                e.HasMorePages = _IsHasMorePages
                intPage += 1
                'Else

            ElseIf intPage = 2 Then
                Dim imgTemplate As Image = Image.FromStream(New System.IO.MemoryStream(System.IO.File.ReadAllBytes("Approval AFPSLAI ID 051017 MPL-04.jpg")))
                If CBool(cardElements(13)) Then e.Graphics.DrawImage(imgTemplate, 0, 0, 1020, 650)

                'address
                Dim address As String = FormatName(cardElements(2), 50)
                e.Graphics.DrawString(address, fontGeneric2, dBlack, ce.Address_X, ce.Address_Y)
                'contact#
                e.Graphics.DrawString(cardElements(3), fontGeneric2, dBlack, ce.ContactNos_X, ce.ContactNos_Y)
                'contactperson and contact#
                e.Graphics.DrawString(cardElements(7), fontGeneric2, dBlack, ce.ContactName_X, ce.ContactName_Y)
                e.Graphics.DrawString(cardElements(8), fontGeneric2, dBlack, ce.ContactContactNos_X, ce.ContactContactNos_Y)
                'dob
                e.Graphics.DrawString(CDate(cardElements(4)).ToString("MMMM dd, yyyy"), fontGeneric2, dBlack, ce.DOB_X, ce.DOB_Y)
                'id#
                e.Graphics.DrawString(cardElements(5), fontGeneric2, dBlack, ce.IDNumber_X, ce.IDNumber_Y)
                'branch
                e.Graphics.DrawString(cardElements(9), fontGeneric2, dBlack, ce.Branch_X, ce.Branch_Y)
                'dateissued
                e.Graphics.DrawString(CDate(cardElements(6)).ToString("MMMM dd, yyyy"), fontGeneric2, dBlack, ce.IssueDate_X, ce.IssueDate_Y)

                If IO.File.Exists(presidentSignatureFile) Then
                    Dim myBitmap2 As New Bitmap(presidentSignatureFile)
                    myBitmap2.MakeTransparent()
                    e.Graphics.DrawImage(myBitmap2, X, Y, imgWidth, imgHeight)
                End If

                intPage += 1
                _IsHasMorePages = False
            End If

            ce = Nothing
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Function FormatName(ByVal value As String, ByVal intCharLength As Short) As String
        'Dim intCharLength As Short = 24
        Dim space As String = " "

        Dim sbOld As New System.Text.StringBuilder
        sbOld.Append(value)

        Dim sbNew As New System.Text.StringBuilder

        Do While sbOld.ToString <> ""
            Dim intSpaceLastIndex As Short
            If sbOld.ToString.Length > intCharLength Then
                If sbOld.ToString.Substring(intCharLength - 1, 1) = space Then
                    sbNew.AppendLine(Trim(sbOld.ToString.Substring(0, intCharLength)))
                    sbOld.Remove(0, intCharLength)
                ElseIf sbOld.ToString.Substring(intCharLength - 1, 1) <> space And sbOld.ToString.Substring(intCharLength, 1) <> space Then
                    intSpaceLastIndex = sbOld.ToString.Substring(0, intCharLength).LastIndexOf(space)
                    sbNew.AppendLine(Trim(sbOld.ToString.Substring(0, intSpaceLastIndex)))
                    sbOld.Remove(0, intSpaceLastIndex)
                Else
                    sbNew.AppendLine(Trim(sbOld.ToString.Substring(0, intCharLength)))
                    sbOld.Remove(0, intCharLength)
                End If
            Else
                sbNew.AppendLine(Trim(sbOld.ToString.Substring(0)))
                sbOld.Clear()
            End If
        Loop

        Return sbNew.ToString
    End Function


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

