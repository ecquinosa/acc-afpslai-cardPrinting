'options
Option Strict On
Option Explicit On

'espace de noms
Imports System
Imports System.Text
Imports System.Runtime.InteropServices

Module dllIomem
    'Declaration of Dll Function
    <DllImport("iomem.dll", EntryPoint:="_OpenPebble@4")> _
    Public Function OpenPebble( _
         <InAttribute()> ByVal pPrinterName As String) As Int32
    End Function

    <DllImport("iomem.dll", EntryPoint:="_ClosePebble@4")> _
    Public Function ClosePebble( _
        <InAttribute()> ByVal hPrinter As Int32) As Boolean
    End Function

    <DllImport("iomem.dll", EntryPoint:="_ReadPebble@16")> _
    Public Function ReadPebble( _
        <InAttribute()> ByVal hPrinter As Int32, _
        <OutAttribute()> ByVal answer As IntPtr, _
        <InAttribute()> ByVal cbAns As Int32, _
        <OutAttribute()> ByRef lpNumberOfBytesRead As Integer) As Boolean
    End Function

    <DllImport("iomem.dll", EntryPoint:="_WritePebble@12")> _
    Public Function WritePebble( _
        <InAttribute()> ByVal hPrinter As Int32, _
        <InAttribute()> ByVal cde As String, _
        <InAttribute()> ByVal cbNeeded As Int32) As Boolean
    End Function

    <DllImport("iomem.dll", EntryPoint:="_GetIomemVersion@4")> _
    Public Function GetIomemVersion( _
        <OutAttribute()> ByVal version As IntPtr) As Boolean
    End Function

    <DllImport("iomem.dll", EntryPoint:="_GetTimeout@0")> _
    Public Function GetTimeout() As Int32
    End Function

    <DllImport("iomem.dll", EntryPoint:="_SetTimeout@4")> _
    Public Function SetTimeout( _
        <InAttribute()> ByVal timeout As Int32) As Boolean
    End Function

    <DllImport("iomem.dll", EntryPoint:="_GetStatusEvo@8")> _
    Public Function GetStatusEvo( _
        <InAttribute()> ByVal hPrinter As Int32, _
        <OutAttribute()> ByRef lpNumberOfBytesRead As Integer) As Boolean
    End Function
End Module
