'options
Option Strict On
Option Explicit On

'espace de noms
Imports System
Imports System.Text
Imports System.Runtime.InteropServices

Module dllEvolib
    'Declaration of Dll Function
    '<DllImport("evolib.dll", EntryPoint:="?OpenBmp@@YGHPADPAEPAJ@Z")> _
    <DllImport("evolib.dll", EntryPoint:="?OpenBmp@@YGHPADPAEPAJPAUtagBITMAPINFOHEADER@@@Z")> _
    Public Function OpenBmp( _
        <InAttribute()> ByVal pPathFile As String, _
        <OutAttribute()> ByVal pMen As IntPtr, _
        <OutAttribute()> ByRef dwSizeNeeded As Integer, _
        <InAttribute()> ByRef bmpif As BITMAPINFOHEADER) As Boolean
    End Function

    <DllImport("evolib.dll", EntryPoint:="?KinYMC@@YGXPAEJJ@Z")> _
    Public Sub KinYMC( _
        <OutAttribute()> ByVal lpMen As IntPtr, _
        <InAttribute()> ByVal Height As Integer, _
        <InAttribute()> ByVal Width As Integer)
    End Sub

    <DllImport("evolib.dll", EntryPoint:="?ConvertRVBtoK@@YGHPAEJJJ0E@Z")> _
    Public Function ConvertRVBtoK( _
        <OutAttribute()> ByVal lpbRVB As IntPtr, _
        <InAttribute()> ByVal RVBSize As Integer, _
        <InAttribute()> ByVal Height As Integer, _
        <InAttribute()> ByVal Width As Integer, _
        <OutAttribute()> ByVal lpBlack As IntPtr, _
        <InAttribute()> ByVal type As Char) As Boolean
    End Function

    <DllImport("evolib.dll", EntryPoint:="?DB32NC@@YGHPAEJD0JHJJ@Z")> _
    Public Function DB32NC( _
        <OutAttribute()> ByVal lpMen As IntPtr, _
        <InAttribute()> ByVal lPos As Integer, _
        <InAttribute()> ByVal color As Char, _
        <OutAttribute()> ByVal ucCommand As IntPtr, _
        <InAttribute()> ByVal lCommandSize As Integer, _
        <InAttribute()> ByVal bPartial As Boolean, _
        <InAttribute()> ByVal Min As Integer, _
        <InAttribute()> ByVal Max As Integer) As Integer
    End Function

    <DllImport("evolib.dll", EntryPoint:="?DB64NC@@YGHPAEJD0JHJJ@Z")> _
    Public Function DB64NC( _
        <OutAttribute()> ByVal lpMen As IntPtr, _
        <InAttribute()> ByVal lPos As Integer, _
        <InAttribute()> ByVal color As Char, _
        <OutAttribute()> ByVal ucCommand As IntPtr, _
        <InAttribute()> ByVal lCommandSize As Integer, _
        <InAttribute()> ByVal bPartial As Boolean, _
        <InAttribute()> ByVal Min As Integer, _
        <InAttribute()> ByVal Max As Integer) As Integer
    End Function

    <DllImport("evolib.dll", EntryPoint:="?DB128NC@@YGHPAEJD0JHJJ@Z")> _
    Public Function DB128NC( _
        <OutAttribute()> ByVal lpMen As IntPtr, _
        <InAttribute()> ByVal lPos As Integer, _
        <InAttribute()> ByVal color As Char, _
        <OutAttribute()> ByVal ucCommand As IntPtr, _
        <InAttribute()> ByVal lCommandSize As Integer, _
        <InAttribute()> ByVal bPartial As Boolean, _
        <InAttribute()> ByVal Min As Integer, _
        <InAttribute()> ByVal Max As Integer) As Integer
    End Function

    <DllImport("evolib.dll", EntryPoint:="?DB2NC@@YGHPAEJQAD0J@Z")> _
    Public Function DB2NC( _
        <OutAttribute()> ByVal lpMen As IntPtr, _
        <InAttribute()> ByVal lPos As Integer, _
        <InAttribute()> ByVal pannel As Char(), _
        <OutAttribute()> ByVal ucCommand As IntPtr, _
        <InAttribute()> ByVal lCommandSize As Integer) As Integer
    End Function

    <DllImport("evolib.dll", EntryPoint:="?DB32C@@YGHPAEJD0JHJJ@Z")> _
    Public Function DB32C( _
        <OutAttribute()> ByVal lpMen As IntPtr, _
        <InAttribute()> ByVal lPos As Integer, _
        <InAttribute()> ByVal color As Char, _
        <OutAttribute()> ByVal ucCommand As IntPtr, _
        <InAttribute()> ByVal lCommandSize As Integer, _
        <InAttribute()> ByVal bPartial As Boolean, _
        <InAttribute()> ByVal Min As Integer, _
        <InAttribute()> ByVal Max As Integer) As Integer
    End Function

    <DllImport("evolib.dll", EntryPoint:="?DB64C@@YGHPAEJD0JHJJ@Z")> _
    Public Function DB64C( _
        <OutAttribute()> ByVal lpMen As IntPtr, _
        <InAttribute()> ByVal lPos As Integer, _
        <InAttribute()> ByVal color As Char, _
        <OutAttribute()> ByVal ucCommand As IntPtr, _
        <InAttribute()> ByVal lCommandSize As Integer, _
        <InAttribute()> ByVal bPartial As Boolean, _
        <InAttribute()> ByVal Min As Integer, _
        <InAttribute()> ByVal Max As Integer) As Integer
    End Function

    <DllImport("evolib.dll", EntryPoint:="?DB128C@@YGHPAEJD0JHJJ@Z")> _
    Public Function DB128C( _
        <OutAttribute()> ByVal lpMen As IntPtr, _
        <InAttribute()> ByVal lPos As Integer, _
        <InAttribute()> ByVal color As Char, _
        <OutAttribute()> ByVal ucCommand As IntPtr, _
        <InAttribute()> ByVal lCommandSize As Integer, _
        <InAttribute()> ByVal bPartial As Boolean, _
        <InAttribute()> ByVal Min As Integer, _
        <InAttribute()> ByVal Max As Integer) As Integer
    End Function

    <DllImport("evolib.dll", EntryPoint:="?DB2C@@YGHPAEJQAD0J@Z")> _
    Public Function DB2C( _
        <OutAttribute()> ByVal lpMen As IntPtr, _
        <InAttribute()> ByVal lPos As Integer, _
        <InAttribute()> ByVal pannel As Char(), _
        <OutAttribute()> ByVal ucCommand As IntPtr, _
        <InAttribute()> ByVal lCommandSize As Integer) As Integer
    End Function
End Module
