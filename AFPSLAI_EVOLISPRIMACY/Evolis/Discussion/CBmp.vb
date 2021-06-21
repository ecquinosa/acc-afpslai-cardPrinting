'options
Option Strict Off
Option Explicit On

Imports System
Imports System.Text
Imports System.Runtime.InteropServices
Imports AFPSLAI_EVOLISPRIMACY.dllEvolib
Imports AFPSLAI_EVOLISPRIMACY.StructureDefinition

'-----------------------------------------------'
'                                               '
'       CBmp Class allowing the escape          '
'     command creation from a bmp image         '
'                                               '
'-----------------------------------------------'
Public Class CBmp
    'properties
    Dim InfoHead As New BITMAPINFOHEADER
    Private _fileNameIn As String
    Private _fileSize As Int32
    Private _lpMem As IntPtr
    Private _bPartial As Boolean
    Private _colorSmooth As Integer
    Private _compress As Boolean
    Private _blackOption As Boolean
    Private _blackMode As Integer
    Private _lPartialStart As Integer
    Private _lPartialTotal As Integer

    Public Sub initialize()
        _lPartialStart = 0
        _lPartialTotal = 0
        _lpMem = IntPtr.Zero
    End Sub
    'for the '_blackOption' property
    Public Property BlackOption() As Boolean
        Get
            BlackOption = Me._blackOption
        End Get
        Set(ByVal value As Boolean)
            Me._blackOption = value
        End Set
    End Property
    Public Property BlackMode() As Integer
        Get
            BlackMode = Me._blackMode
        End Get
        Set(ByVal value As Integer)
            Me._blackMode = value
        End Set
    End Property
    'for the 'colorSmooth' property
    Public Property ColorSmooth() As Integer
        Get
            ColorSmooth = Me._colorSmooth
        End Get
        Set(ByVal value As Integer)
            Me._colorSmooth = value
        End Set
    End Property
    'for the '_compress' property 
    Public Property Comp() As Boolean
        Get
            Comp = Me._compress
        End Get
        Set(ByVal value As Boolean)
            Me._compress = value
        End Set
    End Property

    'for the '_fileNameIn' property
    Public Property FileNameIn() As String
        Get
            FileNameIn = Me._fileNameIn
        End Get
        Set(ByVal value As String)
            Me._fileNameIn = value
        End Set
    End Property
    'for the '_bPartial' property
    Public Property bPartial() As Boolean
        Get
            bPartial = Me._bPartial
        End Get
        Set(ByVal value As Boolean)
            Me._bPartial = value
        End Set
    End Property
    'for the '_lPartialStart' property
    Public Property lPartialStart() As Integer
        Get
            lPartialStart = Me._lPartialStart
        End Get
        Set(ByVal value As Integer)
            Me._lPartialStart = value
        End Set
    End Property
    'for the '_lPartialTotal' property
    Public Property lPartialTotal() As Integer
        Get
            lPartialTotal = Me._lPartialTotal
        End Get
        Set(ByVal value As Integer)
            Me._lPartialTotal = value
        End Set
    End Property
    'OpenFile() method for the image opening and the data stockage for printing
    Public Function OpenFile() As Boolean
        Me._lpMem = IntPtr.Zero
        'First call to get size to get
        If (OpenBmp(Me._fileNameIn, Me._lpMem, Me._fileSize, Me.InfoHead) = True) Then
            'Get memory
            Me._lpMem = Marshal.AllocHGlobal(Me._fileSize)
            If (Me._lpMem.Equals(IntPtr.Zero)) Then
                OpenFile = False
            Else
                'Copy file information
                If (OpenBmp(Me._fileNameIn, Me._lpMem, Me._fileSize, Me.InfoHead) = False) Then
                    OpenFile = False
                    Marshal.FreeHGlobal(Me._lpMem)
                    Me._lpMem = IntPtr.Zero
                Else
                    OpenFile = True
                End If
            End If
        End If
    End Function
    'CloseFile() method for the image closing
    Public Sub CloseFile()
        Marshal.FreeHGlobal(Me._lpMem) 'free memory
        Me._lpMem = IntPtr.Zero
    End Sub

    '<summary>
    'To create download escape command for color panel (no compressed format)
    '</summary>
    '<param name="iPanel">'0' for yellow, '1' for magenta, '2' for cyan</param>
    '<param name="ucCommand">pointer on memory allocated where to copy escape command</param>
    '<param name="lCommandSize">size of memory allocated</param>
    '<returns>0 on error</returns>
    '<returns>the size of the escape command</returns>
    Function DlBitmap32NC(<InAttribute()> ByVal iPanel As Integer, <InAttribute()> ByVal ucCommand As IntPtr, <InAttribute()> ByVal lCommandSize As Int32) As Int32
        Dim col As Char() = {"y", "m", "c", "@"}
        DlBitmap32NC = 0
        DlBitmap32NC = DB32NC(Me._lpMem, CInt(iPanel * ((Me._fileSize) / 5)), col(iPanel), ucCommand, lCommandSize, Me._bPartial, Me._lPartialStart, Me._lPartialTotal)
    End Function

    '<summary>
    'Same as above but a dot is coded from 6 bits.
    '</summary>
    Function DlBitmap64NC(<InAttribute()> ByVal iPanel As Integer, <InAttribute()> ByVal ucCommand As IntPtr, <InAttribute()> ByVal lCommandSize As Int32) As Int32
        Dim col As Char() = {"y", "m", "c", "@"}
        DlBitmap64NC = 0
        DlBitmap64NC = DB64NC(Me._lpMem, CInt(iPanel * ((Me._fileSize) / 5)), col(iPanel), ucCommand, lCommandSize, Me._bPartial, Me._lPartialStart, Me._lPartialTotal)
    End Function
    '<summary>
    'Same as above but a dot is coded from 7 bits.
    '</summary>
    Function DlBitmap128NC(<InAttribute()> ByVal iPanel As Integer, <InAttribute()> ByVal ucCommand As IntPtr, <InAttribute()> ByVal lCommandSize As Int32) As Int32
        Dim col As Char() = {"y", "m", "c", "@"}
        DlBitmap128NC = 0
        DlBitmap128NC = DB128NC(Me._lpMem, CInt(iPanel * ((Me._fileSize) / 5)), col(iPanel), ucCommand, lCommandSize, Me._bPartial, Me._lPartialStart, Me._lPartialTotal)
    End Function
    '<summary>
    'To create black or overlay donwloading escape command( no compressed format)
    '</summary>
    '<param name="iPanel">'4' for overlay, '3' for kresin</param>
    '<param name="ucCommand">pointer on memory allocated where to copy escape command</param>
    '<param name="lCommandSize">size of memory allocated</param>
    '<returns>0 on error</returns>
    '<returns>the size of the escape command</returns>
    Function DlBitmap2NC(<InAttribute()> ByVal iPanel As Integer, <InAttribute()> ByVal ucCommand As IntPtr, <InAttribute()> ByVal lCommandSize As Int32) As Int32
        Dim col As Char() = {"A", "B", "P", Chr(0)}
        Dim col1 As Char() = {"F", "O", Chr(0)}
        DlBitmap2NC = 0
        If (iPanel = 3) Then 'for black pannel
            DlBitmap2NC = DB2NC(Me._lpMem, CInt(iPanel * ((Me._fileSize) / 5)), col, ucCommand, lCommandSize)
        ElseIf (iPanel = 4) Then
            DlBitmap2NC = DB2NC(Me._lpMem, 0, col1, ucCommand, lCommandSize)
        End If

    End Function
    '<summary>
    'To create download escape command for color panel (compressed format)
    '</summary>
    '<param name="iPanel">'0' for yellow, '1' for magenta, '2' for cyan</param>
    '<param name="ucCommand">pointer on memory allocated where to copy escape command</param>
    '<param name="lCommandSize">size of memory allocated</param>
    '<returns>0 on error</returns>
    '<returns>the size of the escape command</returns>
    Function DlBitmap32C(<InAttribute()> ByVal iPanel As Integer, <InAttribute()> ByVal ucCommand As IntPtr, <InAttribute()> ByVal lCommandSize As Int32) As Int32
        Dim col As Char() = {"y", "m", "c", "@"}
        DlBitmap32C = 0
        DlBitmap32C = DB32C(Me._lpMem, CInt(iPanel * ((Me._fileSize) / 5)), col(iPanel), ucCommand, lCommandSize, Me._bPartial, Me._lPartialStart, Me._lPartialTotal)
    End Function
    '<summary>
    'Same as above but a dot is coded from 6 bits.
    '</summary
    Function DlBitmap64C(<InAttribute()> ByVal iPanel As Integer, <InAttribute()> ByVal ucCommand As IntPtr, <InAttribute()> ByVal lCommandSize As Int32) As Int32
        Dim col As Char() = {"y", "m", "c", "@"}
        DlBitmap64C = 0
        DlBitmap64C = DB64C(Me._lpMem, CInt(iPanel * ((Me._fileSize) / 5)), col(iPanel), ucCommand, lCommandSize, Me._bPartial, Me._lPartialStart, Me._lPartialTotal)
    End Function
    '<summary>
    'Same as above but a dot is coded from 7 bits.
    '</summary
    Function DlBitmap128C(<InAttribute()> ByVal iPanel As Integer, <InAttribute()> ByVal ucCommand As IntPtr, <InAttribute()> ByVal lCommandSize As Int32) As Int32
        Dim col As Char() = {"y", "m", "c", "@"}
        DlBitmap128C = 0
        DlBitmap128C = DB128C(Me._lpMem, CInt(iPanel * ((Me._fileSize) / 5)), col(iPanel), ucCommand, lCommandSize, Me._bPartial, Me._lPartialStart, Me._lPartialTotal)
    End Function

    '<summary>
    'To create black or overlay donwloading escape command( compressed format)
    '</summary>
    '<param name="iPanel">'4' for overlay, '3' for kresin</param>
    '<param name="ucCommand">pointer on memory allocated where to copy escape command</param>
    '<param name="lCommandSize">size of memory allocated</param>
    '<returns>0 on error</returns>
    '<returns>the size of the escape command</returns>
    Function DlBitmap2C(<InAttribute()> ByVal iPanel As Integer, <InAttribute()> ByVal ucCommand As IntPtr, <InAttribute()> ByVal lCommandSize As Int32) As Int32
        Dim col As Char() = {"A", "B", "P", Chr(0)}
        Dim col1 As Char() = {"F", "O", Chr(0)}
        If (iPanel = 3) Then 'for black pannel
            DlBitmap2C = DB2C(Me._lpMem, CInt(iPanel * ((Me._fileSize) / 5)), col, ucCommand, lCommandSize)
        ElseIf (iPanel = 4) Then
            DlBitmap2C = DB2C(Me._lpMem, 0, col1, ucCommand, lCommandSize)
        End If
    End Function

    '<summary>
    'Convert RVB info to gray and then to black information.
    'Allows to apply image treatment for monochrome printing
    '</summary>
    '<param name="method">'d' for dithering, 'f' for floyd, 't' for threshold</param>
    '<returns>True if correct</returns>
    Public Function RVBtoK(ByVal method As Char) As Boolean
        Dim x As IntPtr
        Dim z As Int32
        Dim f As Int32
        z = ((3 * Me._fileSize) / 5)
        f = Me._lpMem.ToInt32() + z
        x = New IntPtr(f)

        RVBtoK = ConvertRVBtoK(Me._lpMem, Me._fileSize, Me.InfoHead.biHeight, Me.InfoHead.biWidth, x, method)
    End Function

    '<summary>
    'Real black dots will be printed with Kresion panel
    '</summary>
    Public Sub BlackInYMC()
        KinYMC(Me._lpMem, Me.InfoHead.biHeight, Me.InfoHead.biWidth)
    End Sub
End Class
