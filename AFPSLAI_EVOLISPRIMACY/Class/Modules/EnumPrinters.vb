Imports System.Runtime.InteropServices
'Imports EvolisPrinter.StructureDefinition
Imports AFPSLAI_EVOLISPRIMACY.Spooler

Module EnumPrinters
    'Const PRINTER_ENUM_LOCAL = &H2
    'Private Declare Auto Function EnumPrinters Lib "winspool.drv" Alias "EnumPrintersA" ( _
    'ByVal Flags As Int32, _
    'ByVal Name As String, _
    'ByVal Level As Int32, _
    'ByVal pPrinterEnum As IntPtr, _
    'ByVal cbBuf As Int32, _
    'ByRef pcbNeeded As Int32, _
    'ByRef pcReturned As Int32) As Integer

    ''Private Declare Auto Function EnumPrinters Lib "winspool.drv" Alias "EnumPrintersA" (ByVal Flags As Long, ByVal Name As String, ByVal Level As Long, ByVal pPrinterEnum As IntPtr, ByVal cdBuf As Long, ByVal pcbNeeded As Long, ByVal pcReturned As Long) As Integer

    'Public Declare Function lstrcpy Lib "kernel32.dll" Alias "lstrcpyA" (ByVal lpString1 As String, ByVal lpString2 As Long) As Long
    'Public Declare Function lstrlen Lib "kernel32.dll" Alias "lstrlenA" (ByVal lpString As Long) As Long


    'Public Function EnumeratePrinters2(ByRef longbuffer As IntPtr) As Long
    '    Dim numbytes As Int32 ' size in bytes of longbuffer()
    '    Dim numneeded As Int32 ' receives number of bytes necessary if longbuffer() is too small
    '    Dim numprinters As Int32 ' receives number of printers found
    '    Dim retval As Integer ' counter variable & return value
    '    ' Get information about the local printers
    '    numbytes = 0 ' should be sufficiently big, but it may not be
    '    longbuffer = Marshal.AllocHGlobal(CInt(numbytes)) 'ReDim longbuffer(0 To numbytes / 4) ' resize array -- note how 1 Long = 4 bytes'ReDim longbuffer(0 To numbytes / 4) ' resize array -- note how 1 Long = 4 bytes
    '    retval = EnumPrinters(PRINTER_ENUM_LOCAL, vbNullString, 2, IntPtr.Zero, numbytes, numneeded, numprinters)
    '    If retval = 0 Then ' try enlarging longbuffer() to receive all necessary information
    '        numbytes = numneeded
    '        longbuffer = Marshal.AllocHGlobal(CInt(numbytes)) 'ReDim longbuffer(0 To numbytes / 4) ' make it large enough
    '        retval = EnumPrinters(PRINTER_ENUM_LOCAL, vbNullString, 2, longbuffer, numbytes, numneeded, numprinters)
    '        If retval = 0 Then ' failed again!
    '            'Debug.Print("Could not successfully enumerate the printer.")
    '            End ' abort program
    '        End If
    '    End If
    '    EnumeratePrinters2 = numprinters
    'End Function

    'Public Const PRINTER_ATTRIBUTE_SHARED As Long = &H8
    'Public Const PRINTER_ATTRIBUTE_LOCAL As Long = &H40
    'Public Const PRINTER_ATTRIBUTE_NETWORK = &H10
    'Public Const PRINTER_LEVEL2 As Long = &H2

    'Public Const STANDARD_RIGHTS_REQUIRED As Long = &HF0000
    'Public Const PRINTER_ACCESS_ADMINISTER As Long = &H4
    'Public Const PRINTER_ACCESS_USE As Long = &H8
    'Public Const PRINTER_ALL_ACCESS As Long = (STANDARD_RIGHTS_REQUIRED Or _
    '                                             PRINTER_ACCESS_ADMINISTER Or _
    '                                             PRINTER_ACCESS_USE)


    ''Public Structure PRINTER_DEFAULTS
    ''    Public pDatatype As String
    ''    Public pDevMode As Long  'DEVMODE
    ''    Public DesiredAccess As Long
    ''End Structure



    'Declare Function Escape Lib "gdi32" (ByVal hDC As IntPtr, ByVal nEscape As Integer, ByVal nCount As Integer, ByVal lpInData As String, ByRef lpOutData As Object) As Integer

    ''Public Structure DOCINFO
    ''    Public pDocName As String
    ''    Public pOutputFile As String
    ''    Public pDatatype As String
    ''End Structure

    ''Private Const CCHDEVICENAME = 32
    ''Private Const CCHFORMNAME = 32
    ''Private Const DM_WIDTH = &H80000
    ''Private Const DM_HEIGHT = &H100000
    ''Private Const WM_DEVMODECHANGE = &H1B
    ''Private Const HWND_BROADCAST = &HFFFF&
    ''Private Const HWND_DESKTOP = 0
    '

    ''Structure DEVMODE
    ''    Public dmDeviceName As String 'CCHDEVICENAME
    ''    Public dmSpecVersion As Integer
    ''    Public dmDriverVersion As Integer
    ''    Public dmSize As Integer
    ''    Public dmDriverExtra As Integer
    ''    Public dmFields As Long
    ''    Public dmOrientation As Integer
    ''    Public dmPaperSize As Integer
    ''    Public dmPaperLength As Integer
    ''    Public dmPaperWidth As Integer
    ''    Public dmScale As Integer
    ''    Public dmCopies As Integer
    ''    Public dmDefaultSource As Integer
    ''    Public dmPrintQuality As Integer
    ''    Public dmColor As Integer
    ''    Public dmDuplex As Integer
    ''    Public dmYResolution As Integer
    ''    Public dmTTOption As Integer
    ''    Public dmCollate As Integer
    ''    Public dmFormName As String 'CCHFORMNAME
    ''    Public dmUnusedPadding As Integer
    ''    Public dmBitsPerPel As Integer
    ''    Public dmPelsWidth As Long
    ''    Public dmPelsHeight As Long
    ''    Public dmDisplayFlags As Long
    ''    Public dmDisplayFrequency As Long
    ''End Structure
    Public Const PASSTHROUGH As Integer = 19
    Declare Function Escape Lib "gdi32" (ByVal hDC As IntPtr, ByVal nEscape As Integer, ByVal nCount As Integer, ByVal lpInData As String, ByRef lpOutData As Object) As Integer

    <DllImport("winspool.drv", EntryPoint:="GetPrinter", _
   SetLastError:=True, CharSet:=CharSet.Ansi, _
   ExactSpelling:=False, _
   CallingConvention:=CallingConvention.StdCall)> _
   Public Function GetPrinter _
               (<InAttribute()> ByVal hPrinter As IntPtr, _
                <InAttribute()> ByVal Level As Int32, _
                <OutAttribute()> ByVal lpPrinter As IntPtr, _
                <InAttribute()> ByVal cbBuf As Int32, _
                <OutAttribute()> ByRef lpbSizeNeeded As Int32) As Boolean

    End Function

    <DllImport("winspool.drv", EntryPoint:="OpenPrinter", _
SetLastError:=True, CharSet:=CharSet.Ansi, _
ExactSpelling:=False, _
CallingConvention:=CallingConvention.StdCall)> _
Public Function OpenPrinter(<InAttribute()> ByVal pPrinterName As String, _
                            <OutAttribute()> ByRef phPrinter As IntPtr, _
                            <InAttribute()> ByVal pDefault As PRINTER_DEFAULTS _
                                   ) As Boolean

    End Function

    <DllImport("winspool.drv", EntryPoint:="ClosePrinter", _
SetLastError:=True, _
ExactSpelling:=True, _
CallingConvention:=CallingConvention.StdCall)> _
Public Function ClosePrinter(<InAttribute()> ByVal hPrinter As IntPtr) As Boolean

    End Function

    <DllImport("winspool.drv", EntryPoint:="EnumPrinters", _
    SetLastError:=True, CharSet:=CharSet.Ansi, _
    ExactSpelling:=False, _
    CallingConvention:=CallingConvention.StdCall)> _
    Public Function EnumPrinters2(<InAttribute()> ByVal Flags As EnumPrinterFlags, _
                                 <InAttribute()> ByVal Name As String, _
                                 <InAttribute()> ByVal Level As Int32, _
                                 <OutAttribute()> ByVal lpBuf As IntPtr, _
                                 <InAttribute()> ByVal cbBuf As Int32, _
                                 <OutAttribute()> ByRef pcbNeeded As Int32, _
                                 <OutAttribute()> ByRef pcbReturned As Int32) As Boolean

    End Function

    <DllImport("winspool.drv", EntryPoint:="EnumPrinters", _
SetLastError:=True, CharSet:=CharSet.Ansi, _
ExactSpelling:=False, _
CallingConvention:=CallingConvention.StdCall)> _
Public Function EnumPrinters2(<InAttribute()> ByVal Flags As EnumPrinterFlags, _
                             <InAttribute()> ByVal Name As IntPtr, _
                             <InAttribute()> ByVal Level As Int32, _
                             <OutAttribute()> ByVal lpBuf As IntPtr, _
                             <InAttribute()> ByVal cbBuf As Int32, _
                             <OutAttribute()> ByRef pcbNeeded As Int32, _
                             <OutAttribute()> ByRef pcbReturned As Int32) As Boolean
    End Function


End Module
