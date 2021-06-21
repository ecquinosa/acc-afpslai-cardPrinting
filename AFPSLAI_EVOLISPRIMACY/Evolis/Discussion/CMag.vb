'options
Option Strict On
Option Explicit On 

Imports System
Imports System.Text
Imports System.Runtime.InteropServices

'-------------------------------------------------'
'                                                 '
' CMag Classe allowing the stockage magnetic data '
'                                                 '
'-------------------------------------------------'
Public Class CMag
    'properties
    Private _coercivity As String
    Private _writeDataTrack(3) As String
    Private _statusTrack(3) As String
    Private _DataToWriteOnTrack(3) As String
    Private _cdeTrack As String

    Public Sub initialize()
        _coercivity = "h"
        _writeDataTrack(0) = ""
        _statusTrack(0) = ""
        _DataToWriteOnTrack(0) = ""
    End Sub

    '<summary>
    'Fill that printer for a specified tracks.
    'It has to be used after write or read tasks.
    '</summary>
    '<param name="status"></param>
    '<param name="trackNumber"></param>
    Public Sub SetStatusCdeTrack(<InAttribute()> ByVal status As String, <InAttribute()> ByVal trackNumber As Integer)
        If (trackNumber > 0 And trackNumber < 4) Then
            Me._statusTrack(trackNumber) = status
        End If
    End Sub

    Public Sub SetDownloadData(<InAttribute()> ByVal newTrack As String, <InAttribute()> ByVal trackNumber As Integer)
        If (trackNumber > 0 And trackNumber < 4) Then
            If (newTrack.Length <> 0) Then
                Me._DataToWriteOnTrack(trackNumber) = newTrack
                Me._writeDataTrack(trackNumber) = Chr(27) & "Dm;" & trackNumber & ";" & Me._DataToWriteOnTrack(trackNumber) & Chr(13)
            Else
                Me._DataToWriteOnTrack(trackNumber) = ""
                Me._writeDataTrack(trackNumber) = ""
            End If
        End If
    End Sub
    '<summary>
    ' 
    ' </summary>
    Public ReadOnly Property gDownloadData(ByVal trackNumber As Integer) As String
        Get
            gDownloadData = ""
            If (trackNumber > 0 And trackNumber < 4) Then
                gDownloadData = Me._writeDataTrack(trackNumber)
            End If
        End Get
    End Property
    '<summary>
    '
    '</summary>
    '<param name="trackNumber"></param>
    '<returns></returns>
    Public ReadOnly Property gDataReadFromTrack(ByVal trackNumber As Integer) As String
        Get
            gDataReadFromTrack = Me._statusTrack(0)
            If (trackNumber > 0 And trackNumber < 4) Then
                gDataReadFromTrack = Me._statusTrack(trackNumber)
            End If
        End Get
    End Property
    '<summary>
    ' 
    ' </summary>
    Public Sub Clear()
        Dim i As Integer
        For i = 1 To 4
            Me._writeDataTrack(i) = ""
            Me._statusTrack(i) = ""
            Me._DataToWriteOnTrack(i) = ""
        Next i

    End Sub

    '<summary>
    ' 
    '</summary>
    '<returns>Escape commande to start encoding sequence</returns>
    Public Function WriteMagTracks() As String
        Me._cdeTrack = ""
        WriteMagTracks = ""

        If (Me._DataToWriteOnTrack(1).Length() <> 0 _
            Or Me._DataToWriteOnTrack(2).Length() <> 0 _
            Or Me._DataToWriteOnTrack(3).Length() <> 0) Then
            Me._cdeTrack = Chr(27) & "Smw" & Chr(13)
            WriteMagTracks = Chr(27) & "Smw" & Chr(13)
        End If
    End Function
    '<summary>
    '
    '</summary>
    '<returns>Escape commande to start reading process</returns>
    Public Function ReadMagTracks() As String
        Me._cdeTrack = Chr(27) & "Smr" & Chr(13)
        ReadMagTracks = Chr(27) & "Smr" & Chr(13)
    End Function
    '<summary>
    ' 
    '</summary>
    '<returns>Escape command to start reading track X process</returns>
    Public Function ReadMagTracks(<InAttribute()> ByVal iTrack As Integer) As String
        Me._cdeTrack = ""
        ReadMagTracks = ""
        If (iTrack > 0 And iTrack < 4) Then
            Me._cdeTrack = Chr(27) & "Smr;" & iTrack & Chr(13)
            ReadMagTracks = Chr(27) & "Smr;" & iTrack & Chr(13)
        End If
    End Function
    '<summary>
    ' 
    '</summary>
    '<param name="iTrack"></param>
    '<returns>Escape command to read the track buffer</returns>
    Public Function ReadMagTracksBuffer(<InAttribute()> ByVal iTrack As Integer) As String
        If (iTrack > 0 And iTrack < 4) Then
            Me._cdeTrack = Chr(27) & "Rmb;" & iTrack & Chr(13)
            ReadMagTracksBuffer = Chr(27) & "Rmb;" & iTrack & Chr(13)
        Else
            Me._cdeTrack = ""
            ReadMagTracksBuffer = ""
        End If
    End Function

    Public Property gsCoer() As String
        Get
            gsCoer = Me._coercivity
        End Get
        Set(ByVal value As String)
            If (value = "l" Or value = "h") Then
                Me._coercivity = Chr(27) & "Pmc;" & value & Chr(13)
            End If
        End Set
    End Property

End Class
