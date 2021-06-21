Option Strict On
Option Explicit On

Imports System
Imports System.Runtime.InteropServices

Module StructureDefinition

    Structure BITMAPINFOHEADER '40 bytes
        Public biSize As Integer
        Public biWidth As Integer
        Public biHeight As Integer
        Public biPlanes As Short
        Public biBitCount As Short
        Public biCompression As Integer
        Public biSizeImage As Integer
        Public biXPelsPerMeter As Integer
        Public biYPelsPerMeter As Integer
        Public biClrUsed As Integer
        Public biClrImportant As Integer
    End Structure

    Structure BITMAPFILEHEADER
        Public bfType As Integer
        Public bfSize As Long
        Public bfReserved1 As Integer
        Public bfReserved2 As Integer
        Public bfOhFileBits As Long
    End Structure

End Module
