Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic
Imports System.Drawing.Printing


Namespace Spooler


#Region "PrinterAccessRights"
    <FlagsAttribute()> _
    Public Enum PrinterAccessRights
        ' READ_CONTROL - Allowed to read printer information
        READ_CONTROL = &H20000
        ' WRITE_DAC - Allowed to write device access control info
        WRITE_DAC = &H40000
        ' WRITE_OWNER - Allowed to change the object owner
        WRITE_OWNER = &H80000
        ' SERVER_ACCESS_ADMINISTER 
        SERVER_ACCESS_ADMINISTER = &H1
        '  SERVER_ACCESS_ENUMERATE
        SERVER_ACCESS_ENUMERATE = &H2
        ' PRINTER_ACCESS_ADMINISTER Allows administration of a printer
        PRINTER_ACCESS_ADMINISTER = &H4
        ' PRINTER_ACCESS_USE Allows printer general use (printing, querying)
        PRINTER_ACCESS_USE = &H8
        ' PRINTER_ALL_ACCESS Allows use and administration.
        PRINTER_ALL_ACCESS = &HF000C
        ' SERVER_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | SERVER_ACCESS_ADMINISTER | SERVER_ACCESS_ENUMERATE)
        SERVER_ALL_ACCESS = &HF0003
    End Enum
#End Region

#Region "PRINTER_DEFAULTS STRUCTURE"
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Friend Class PRINTER_DEFAULTS
        Public lpDataType As Int32
        Public lpDevMode As Int32
        <MarshalAs(UnmanagedType.U4)> Public DesiredAccess As PrinterAccessRights

#Region "Public constructor"
        Public Sub New()
            DesiredAccess = PrinterAccessRights.PRINTER_ALL_ACCESS

        End Sub

        Public Sub New(ByVal DefaultDesiredAccess As PrinterAccessRights)

            DesiredAccess = DefaultDesiredAccess

        End Sub

#End Region

    End Class
#End Region
    '#Region "DEVMODE"
    '    Friend Class DEVMODE
    '#Region "Private properties"
    '        Private dmDeviceName(64) As Char
    '        Private dmSpecVersion As Short
    '        Private dmDriverVersion As Short
    '        Private dmSize As Short
    '        Private dmDriverExtra As Short
    '        Private dmFields As Integer
    '        Private dmOrientation As Short
    '        Private dmPaperSize As Short
    '        Private dmPaperLength As Short
    '        Private dmPaperWidth As Short
    '        Private dmScale As Short
    '        Private dmCopies As Short
    '        Private dmDefaultSource As Short
    '        Private dmPrintQuality As Short
    '        Private dmColor As Short
    '        Private dmDuplex As Short
    '        Private dmYResolution As Short
    '        Private dmTTOption As Short
    '        Private dmCollate As Short
    '        Private dmFormName(32) As Char
    '        Private dmUnusedPadding As Short
    '        Private dmBitsPerPel As Integer
    '        Private dmPelsWidth As Integer
    '        Private dmPelsHeight As Integer
    '        Private dmNup As Integer
    '        Private dmDisplayFrequency As Integer
    '        Private dmICMMethod As Integer
    '        Private dmICMIntent As Integer
    '        Private dmMediaType As Integer
    '        Private dmDitherType As Integer
    '        Private dmReserved1 As Integer
    '        Private dmReserved2 As Integer
    '        Private dmPanningWidth As Integer
    '        Private dmPanningHeight As Integer
    '        Private DriverExtra() As Byte
    '#End Region

    '#Region "Public properties"
    '#Region "Fields"
    '        Private ReadOnly Property Fields() As DevModeFields
    '            Get
    '                Return New DevModeFields(dmFields)
    '            End Get
    '        End Property
    '#End Region
    '#Region "DeviceName"
    '        Public ReadOnly Property DeviceName() As String
    '            Get
    '                If dmDeviceName.Length = 64 Then
    '                    '\\ Remove the balnk chars...
    '                    Dim c As Char
    '                    For Each c In dmDeviceName

    '                    Next
    '                End If
    '                Return New String(dmDeviceName)
    '            End Get
    '        End Property
    '#End Region
    '#Region "FormName"
    '        Public ReadOnly Property FormName() As String
    '            Get
    '                If dmFormName Is Nothing Then
    '                    Return ""
    '                Else
    '                    Return New String(dmFormName)
    '                End If
    '            End Get
    '        End Property
    '#End Region

    '#Region "Copies"
    '        Public ReadOnly Property Copies() As Short
    '            Get
    '                If dmCopies < 1 Then
    '                    dmCopies = 1
    '                End If
    '                Return dmCopies
    '            End Get
    '        End Property
    '#End Region
    '#Region "Collate"
    '        Public ReadOnly Property Collate() As Boolean
    '            Get
    '                Return (dmCollate > 0)
    '            End Get
    '        End Property
    '#End Region

    '#Region "DriverVersion"
    '        Public ReadOnly Property DriverVersion() As Integer
    '            Get
    '                Return dmDriverVersion
    '            End Get
    '        End Property
    '#End Region

    '#End Region

    '#Region "Public constructors"
    '        Public Sub New()


    '        End Sub
    '#End Region

    '#Region "DevModeFields"
    '        Private Class DevModeFields

    '#Region "Private properties"
    '            Private _dmFields As Int32
    '#End Region

    '#Region "Private enumerated types"
    '            <Flags()> _
    '        Private Enum DeviceModeFieldFlags
    '                DM_POSITION = &H20
    '                DM_COLLATE = &H8000
    '                DM_COLOR = &H800&
    '                DM_COPIES = &H100&
    '                DM_DEFAULTSOURCE = &H200&
    '                DM_DITHERTYPE = &H10000000
    '                DM_DUPLEX = &H1000&
    '                DM_FORMNAME = &H10000
    '                DM_ICMINTENT = &H4000000
    '                DM_ICMMETHOD = &H2000000
    '                DM_MEDIATYPE = &H8000000
    '                DM_ORIENTATION = &H1&
    '                DM_PAPERLENGTH = &H4&
    '                DM_PAPERSIZE = &H2&
    '                DM_PAPERWIDTH = &H8&
    '                DM_PRINTQUALITY = &H400&
    '                DM_RESERVED1 = &H800000
    '                DM_RESERVED2 = &H1000000
    '                DM_SCALE = &H10&
    '            End Enum
    '#End Region

    '#Region "Public constructor"
    '            Public Sub New(ByVal Flags As Int32)
    '                _dmFields = Flags
    '            End Sub
    '#End Region

    '#Region "Public interface"
    '#Region "Orientation"
    '            Public ReadOnly Property Orientation() As Boolean
    '                Get
    '                    Return ((_dmFields And DeviceModeFieldFlags.DM_ORIENTATION) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#Region "PaperSize"
    '            Public ReadOnly Property PaperSize() As Boolean
    '                Get
    '                    Return ((_dmFields And DeviceModeFieldFlags.DM_PAPERSIZE) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#Region "PaperLength"
    '            Public ReadOnly Property PaperLength() As Boolean
    '                Get
    '                    Return ((_dmFields And DeviceModeFieldFlags.DM_PAPERLENGTH) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#Region "PaperWidth"
    '            Public ReadOnly Property PaperWidth() As Boolean
    '                Get
    '                    Return ((_dmFields And DeviceModeFieldFlags.DM_PAPERWIDTH) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#Region "Scale"
    '            Public ReadOnly Property Scale() As Boolean
    '                Get
    '                    Return ((_dmFields And DeviceModeFieldFlags.DM_SCALE) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#Region "Copies"
    '            Public ReadOnly Property Copies() As Boolean
    '                Get
    '                    Return ((_dmFields And DeviceModeFieldFlags.DM_COPIES) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#Region "DefaultSource"
    '            Public ReadOnly Property DefaultSource() As Boolean
    '                Get
    '                    Return ((_dmFields And DeviceModeFieldFlags.DM_DEFAULTSOURCE) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#Region "Quality"
    '            Public ReadOnly Property Quality() As Boolean
    '                Get
    '                    Return ((_dmFields And DeviceModeFieldFlags.DM_PRINTQUALITY) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#Region "Position"
    '            Public ReadOnly Property Position() As Boolean
    '                Get
    '                    Return ((_dmFields And DeviceModeFieldFlags.DM_POSITION) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#Region "Colour"
    '            Public ReadOnly Property Colour() As Boolean
    '                Get
    '                    Return ((_dmFields Or DeviceModeFieldFlags.DM_COLOR) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#Region "Duplex"
    '            Public ReadOnly Property Duplex() As Boolean
    '                Get
    '                    Return ((_dmFields Or DeviceModeFieldFlags.DM_DUPLEX) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#Region "Collation"
    '            Public ReadOnly Property Collation() As Boolean
    '                Get
    '                    Return ((_dmFields Or DeviceModeFieldFlags.DM_COLLATE) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#Region "Formname"
    '            Public ReadOnly Property FormName() As Boolean
    '                Get
    '                    Return ((_dmFields Or DeviceModeFieldFlags.DM_FORMNAME) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#Region "MediaType"
    '            Public ReadOnly Property MediaType() As Boolean
    '                Get
    '                    Return ((_dmFields Or DeviceModeFieldFlags.DM_MEDIATYPE) > 0)
    '                End Get
    '            End Property
    '#End Region

    '#End Region

    '        End Class
    '#End Region

    '    End Class
    '#End Region


#Region "DEVMODE STRUCTURE"
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Friend Class DEVMODE
        <MarshalAs(UnmanagedType.ByValTStr, Sizeconst:=32)> Public pDeviceName As String
        Public dmSpecVersion As Short
        Public dmDriverVersion As Short
        Public dmSize As Short
        Public dmDriverExtra As Short
        Public dmFields As Integer
        Public dmOrientation As Short
        Public dmPaperSize As Short
        Public dmPaperLength As Short
        Public dmPaperWidth As Short
        Public dmScale As Short
        Public dmCopies As Short
        Public dmDefaultSource As Short
        Public dmPrintQuality As Short
        Public dmColor As Short
        Public dmDuplex As Short
        Public dmYResolution As Short
        Public dmTTOption As Short
        Public dmCollate As Short
        <MarshalAs(UnmanagedType.ByValTStr, Sizeconst:=32)> Public dmFormName As String
        Public dmUnusedPadding As Short
        Public dmBitsPerPel As Integer
        Public dmPelsWidth As Integer
        Public dmPelsHeight As Integer
        Public dmNup As Integer
        Public dmDisplayFrequency As Integer
        Public dmICMMethod As Integer
        Public dmICMIntent As Integer
        Public dmMediaType As Integer
        Public dmDitherType As Integer
        Public dmReserved1 As Integer
        Public dmReserved2 As Integer
        Public dmPanningWidth As Integer
        Public dmPanningHeight As Integer


    End Class
#End Region

#Region "PRINTER_INFO_2 STRUCTURE"
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi), System.Security.SuppressUnmanagedCodeSecurity()> _
    Friend Class PRINTER_INFO_2
        <MarshalAs(UnmanagedType.LPStr)> Public pServerName As String
        <MarshalAs(UnmanagedType.LPStr)> Public pPrinterName As String
        <MarshalAs(UnmanagedType.LPStr)> Public pShareName As String
        <MarshalAs(UnmanagedType.LPStr)> Public pPortName As String
        <MarshalAs(UnmanagedType.LPStr)> Public pDriverName As String
        <MarshalAs(UnmanagedType.LPStr)> Public pComment As String
        <MarshalAs(UnmanagedType.LPStr)> Public pLocation As String
        <MarshalAs(UnmanagedType.U4)> Public lpDeviceMode As Int32
        <MarshalAs(UnmanagedType.LPStr)> Public pSeperatorFilename As String
        <MarshalAs(UnmanagedType.LPStr)> Public pPrintProcessor As String
        <MarshalAs(UnmanagedType.LPStr)> Public pDataType As String
        <MarshalAs(UnmanagedType.LPStr)> Public pParameters As String
        <MarshalAs(UnmanagedType.U4)> Public lpSecurityDescriptor As Int32
        Public Attributes As Int32
        Public Priority As Int32
        Public DefaultPriority As Int32
        Public StartTime As Int32
        Public UntilTime As Int32
        Public Status As Int32
        Public JobCount As Int32
        Public AveragePPM As Int32

#Region "Private member variables"
        Dim dmOut As New DEVMODE
#End Region

#Region "Public constructors"
        Public Sub New(ByVal hPrinter As IntPtr)

            Dim BytesWritten As Int32 = 0
            Dim ptBuf As IntPtr

            ptBuf = Marshal.AllocHGlobal(1)

            If Not GetPrinter(hPrinter, 2, ptBuf, 1, BytesWritten) Then
                If BytesWritten > 0 Then
                    '\\ Free the buffer allocated
                    Marshal.FreeHGlobal(ptBuf)
                    ptBuf = Marshal.AllocHGlobal(BytesWritten)
                    If GetPrinter(hPrinter, 2, ptBuf, BytesWritten, BytesWritten) Then
                        Marshal.PtrToStructure(ptBuf, Me)
                        '\\ Fill any missing members
                        If pServerName Is Nothing Then
                            pServerName = ""
                        End If
                        '\\ If the devicemode is available, get it
                        If lpDeviceMode > 0 Then
                            Dim ptrDevMode As New IntPtr(lpDeviceMode)
                            Marshal.PtrToStructure(ptrDevMode, dmOut)
                        End If
                    End If
                    '\\ Free this buffer again
                    Marshal.FreeHGlobal(ptBuf)
                End If
            End If
        End Sub
        Public ReadOnly Property DeviceMode() As DEVMODE
            Get
                Return dmOut
            End Get
        End Property

        Public Sub New()

        End Sub
#End Region
    End Class


#End Region

#Region "EnumPrinterFlags"
    <Flags()> _
    Public Enum EnumPrinterFlags
        PRINTER_ENUM_DEFAULT = &H1
        PRINTER_ENUM_LOCAL = &H2
        PRINTER_ENUM_CONNECTIONS = &H4
        PRINTER_ENUM_FAVORITE = &H4
        PRINTER_ENUM_NAME = &H8
        PRINTER_ENUM_REMOTE = &H10
        PRINTER_ENUM_SHARED = &H20
        PRINTER_ENUM_NETWORK = &H40
    End Enum
#End Region




End Namespace
