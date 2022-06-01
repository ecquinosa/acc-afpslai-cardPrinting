
#Region " Imports "

Imports System.Threading
Imports System.Reflection
Imports System.IO

#End Region

Public Class MagEncodingv2

#Region " Variables "

    'Private TrackWrite(0 To 2) As String
    Public TrackRead(0 To 2) As String
    Private Answers As String = ""

    'Public Printer As New CPrinter '= New CPrinter
    'Public AnswerCol As New Collection
    'Private start As Boolean = False
    'Private _drvPrt As New Hashtable
    'Private _coer As Char = "h"
    'Private ListViewInfo As New ListView
    'Private ListViewStat As New ListView

    'Private strTracks() As String

    'Private cmbPrinters As New ComboBox

    Private strErrorMsg As String
    Private IsSuccess As Boolean
    Private IsMagEncode_Success As Boolean
    Private IsPrint_Success As Boolean

    Private strSequence As String

#End Region

    'Public Sub New(ByVal strTracks() As String)
    '    Me.strTracks = strTracks

    '    cmbPrinters.Items.Clear()

    '    For Each strPrinter As [String] In System.Drawing.Printing.PrinterSettings.InstalledPrinters
    '        If strPrinter.StartsWith("Evolis") Then
    '            cmbPrinters.Items.Add(strPrinter)
    '        End If
    '    Next

    '    If InitPrinterList() Then
    '        RefreshListStat()
    '    End If

    '    InitializePrinters()
    'End Sub

    '    Private prntr As New Allcard.Printer.Evolis.Process(My.Settings.CardPrinter)

    '    Public Sub New()
    '        Dim sb As New System.Text.StringBuilder
    '        Try
    '            If Not prntr.Initialize() Then
    '                IsSuccess = False
    '                Main.logger.Error("New(): Failed to initialize. " & prntr.GetMessage)
    '                SharedFunction.ShowErrorMessage("New(): Failed to initialize.")
    '            Else
    '                IsSuccess = True
    '            End If
    '        Catch ex As Exception
    '            IsSuccess = False
    '            Main.logger.Error("New(): " & prntr.GetMessage)
    '            SharedFunction.ShowErrorMessage("New(): " & ex.Message)
    '        End Try
    '    End Sub

    '    Public Shared Function CheckEvolisPrinter() As Boolean
    '        For Each strPrinter As [String] In System.Drawing.Printing.PrinterSettings.InstalledPrinters
    '            If strPrinter.StartsWith("Evolis") Then Return True
    '        Next

    '        Return False
    '    End Function

    '    Public Sub CheckSlotForCard()
    '        If IsSuccess Then prntr.CheckSlotForCard()
    '    End Sub

    '    Public Sub FeedCard()
    '        If IsSuccess Then prntr.FeedCard()
    '    End Sub

    '    Public Function GetPrinterCounter() As Integer
    '        If IsSuccess Then Return prntr.GetPrinterCounter
    '    End Function

    '    Public Sub EjectCard()
    '        If IsSuccess Then prntr.EjectCard()
    '    End Sub


    '#Region "Printer Related Functions"

    '    Public Function ReadTracks() As Short
    '        Dim response As Short
    '        Dim read = prntr.ReadTracks
    '        Try
    '            Select Case read
    '                Case True
    '                    TrackRead(1) = prntr.Track2

    '                    response = 0
    '                Case False
    '                    Main.logger.Error(String.Format("CIF {0} - {1}", Main.cfp.cif, prntr.GetMessage))
    '                    EjectCard()
    '                    response = 2
    '            End Select
    '        Catch ex As Exception
    '            Main.logger.Error(String.Format("CIF {0} - {1}", Main.cfp.cif, ex.Message))
    '            EjectCard()
    '            response = 1
    '        End Try

    '        Return response
    '    End Function

    '#End Region

End Class
