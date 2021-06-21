Module ConversionRoutine

    Public Function ExactBlock(ByVal Sector As Integer, ByVal Block As Integer, ByVal IsSectorTrailer As Boolean) As Byte

        If IsSectorTrailer Then
            If Sector >= 32 Then
                Block = 15
            Else
                Block = 3
            End If
        End If

        If Sector > 38 Then
            Sector -= 38
            Block += 1
        End If

        Dim BLCK As Byte = CByte(Block)

        'If CInt(Sector) >= 32 Then
        '    ExactBlock = CByte(((Sector - 32) * 16) + 128 + BLCK)
        'Else
        '    ExactBlock = CByte((Sector * 4) + BLCK)
        'End If

        If CInt(Sector) >= 32 Then
            ExactBlock = CByte(((Sector - 32) * 16) + 128 + BLCK)
        Else
            ExactBlock = CByte((Sector * 4) + BLCK)
        End If

        'If CInt(Sector) >= 32 Then
        '    ExactBlock = CByte(((Sector - 32) * 16) + 128 + BLCK)
        'Else
        'ExactBlock = CByte((Sector * 4) + BLCK)
        ' End If

    End Function

    Public Function ByteArrayToHexString(ByVal ByteArray As Byte()) As String

        Dim hStr As String = ""

        For i As Integer = 0 To ByteArray.Length - 1
            hStr += ByteArray(i).ToString("X2")
        Next

        Return hStr

    End Function

    Public Sub HexStringToByteArray(ByVal HexString As String, ByRef ByteArray As Byte())

        Dim indexHex As Integer = 1

        For i As Integer = 0 To ByteArray.Length - 1
            ByteArray(i) = CInt("&H" + Mid(HexString, indexHex, 2))
            indexHex += 2
        Next

    End Sub

    Public Function Str2Hex(ByVal strData As String) As String
        Str2Hex = ""

        For i As Integer = 1 To strData.Length
            Str2Hex += Hex(CInt(AscW(CChar(Mid(strData, i, 1))))) + " "
        Next

    End Function

    Public Function Hex2Str(ByVal strData As String) As String
        Dim CurrentHex As String = ""
        Dim i As Integer = strData.Length / 2

        Hex2Str = ""

        For index As Integer = 1 To i
            CurrentHex = Mid(strData, index * 2 - 1, 2)

            Hex2Str += ChrW(CInt("&H" + CurrentHex)).ToString

        Next

    End Function

    Public Function FormatField(ByVal strData As String, Optional ByVal intStartIndex As Short = 0) As String
        If intStartIndex > strData.Length Then
            strData = ""
            Return strData.PadRight(16, " ")
        Else
            If strData.Length > 16 Then
                If strData.Substring(intStartIndex).Length < 16 Then
                    Return strData.Substring(intStartIndex).PadRight(16, " ")
                Else
                    Return strData.Substring(intStartIndex, 16)
                End If
            ElseIf strData.Length < 16 Then
                Return strData.PadRight(16, " ")
            Else
                Return strData
            End If
        End if
    End Function

    Function Spacer(ByVal strData As String, ByVal CharsNeeded As Integer) As String
        Spacer = ""

        If strData.Length = CharsNeeded Then Return strData

        CharsNeeded -= strData.Length

        For i As Integer = 1 To CharsNeeded
            strData += " "
        Next

        Return strData
    End Function

End Module
