Module PCSCRoutines

    Public retCode, hContext, hCard, Protocol As Long
    Public SendBuff(262), RecvBuff(262) As Byte

    Public SendLen, RecvLen, nBytesRet, reqType, Aprotocol As Integer
    Public connActive, autoDet, validATS As Boolean

    Public dwProtocol As Integer
    Public cbPciLength As Integer
    Public dwState, dwActProtocol As Long

    Public SendRequest As SCARD_IO_REQUEST
    Public RecvRequest As SCARD_IO_REQUEST

    Public Response As String = ""
    Public LastSendByte As String = ""

    Public ATR(64) As Byte
    Public ATRLen As Long

    Public Sub ClearBuffers()

        For indx As Long = 0 To 262

            RecvBuff(indx) = &H0
            SendBuff(indx) = &H0

        Next indx

    End Sub

    Public Function StrHEX_Dec(ByVal StrHex As String) As Integer

        Select Case StrHex
            Case "1"
                StrHEX_Dec = 1
            Case "2"
                StrHEX_Dec = 2
            Case "3"
                StrHEX_Dec = 3
            Case "4"
                StrHEX_Dec = 4
            Case "5"
                StrHEX_Dec = 5
            Case "6"
                StrHEX_Dec = 6
            Case "7"
                StrHEX_Dec = 7
            Case "8"
                StrHEX_Dec = 8
            Case "9"
                StrHEX_Dec = 9
            Case "0"
                StrHEX_Dec = 0
            Case "A"
                StrHEX_Dec = 10
            Case "B"
                StrHEX_Dec = 11
            Case "C"
                StrHEX_Dec = 12
            Case "D"
                StrHEX_Dec = 13
            Case "E"
                StrHEX_Dec = 14
            Case "F"
                StrHEX_Dec = 15
        End Select

    End Function

    Public Sub displayOut(ByVal errType As Integer, ByVal retVal As Integer, ByVal PrintText As String, ByVal mMsg As ListBox)

        Select Case errType

            Case 0
                mMsg.ForeColor = Color.Teal
            Case 1
                mMsg.ForeColor = Color.Red
                PrintText = ModWinsCard.GetScardErrMsg(retVal)
            Case 2
                mMsg.ForeColor = Color.Black
                PrintText = "<" + PrintText
            Case 3
                mMsg.ForeColor = Color.Black
                PrintText = ">" + PrintText

        End Select

        mMsg.Items.Add(PrintText)
        mMsg.ForeColor = Color.Black
        mMsg.Focus()
        mMsg.SelectedIndex = mMsg.Items.Count - 1

    End Sub

    Public Sub LoadListToControl(ByVal Ctrl As ComboBox, ByVal ReaderList As String)

        Dim sTemp As String
        Dim indx As Integer

        indx = 1
        sTemp = ""
        Ctrl.Items.Clear()

        While (Mid(ReaderList, indx, 1) <> vbNullChar)

            While (Mid(ReaderList, indx, 1) <> vbNullChar)
                sTemp = sTemp + Mid(ReaderList, indx, 1)
                indx = indx + 1
            End While

            indx = indx + 1

            Ctrl.Items.Add(sTemp)

            sTemp = ""
        End While

    End Sub


    Public Sub GetCardName(ByRef CardNameText As String)

        CardNameText = "UNKNOWN CARD"
        ' atr with old driver
        If ATRLen = 17 Then
            If ATR(1) = 15 Then
                If ATR(16) = 17 Then
                    CardNameText = "Mifare Standard 1K"
                End If
                If ATR(16) = 33 Then
                    CardNameText = "Mifare Standard 4K"
                End If
                If ATR(16) = 49 Then
                    CardNameText = "Mifare Ultra Light"
                End If
                If ATR(16) = 22 Then
                    CardNameText = "AT88RF020"
                End If
                If ATR(16) = 38 Then
                    CardNameText = "AT88SC6416CRF"
                End If
                If ATR(16) = 229 Then
                    CardNameText = "STm SR176"
                End If
                If ATR(16) = 245 Then
                    CardNameText = "STm SRI X4K"
                End If
                If ATR(16) = 24 Then
                    CardNameText = "I.CODE 1"
                End If
                If ATR(16) = 131 Then
                    CardNameText = "iClass"
                End If
                If ATR(16) = 212 Then
                    CardNameText = "KSW TempSens"
                End If
                If ATR(16) = 20 Then
                    CardNameText = "SRF55V10P"
                End If
                If ATR(16) = 180 Then
                    CardNameText = "I.CODE SLI"
                End If
                If ATR(16) = 148 Then
                    CardNameText = "Tag It"
                End If
                If ATR(16) = 164 Then
                    CardNameText = "X-ident STm LRI 512"
                End If
                If ATR(16) = 195 Then
                    CardNameText = "iCLASS 2K"
                End If
                If ATR(16) = 147 Then
                    CardNameText = "iCLASS 2KS"
                End If
                If ATR(16) = 211 Then
                    CardNameText = "iCLASS 16K"
                End If
                If ATR(16) = 163 Then
                    CardNameText = "iCLASS 16KS"
                End If
                If ATR(16) = 227 Then
                    CardNameText = "iCLASS 8x2K"
                End If
                If ATR(16) = 179 Then
                    CardNameText = "iCLASS 8x2KS"
                End If

            End If
        End If


        ' atr with new driver Pc/Sc
        If ATRLen = 20 Then
            If ATR(13) = 0 Then
                If ATR(14) = 1 Then
                    CardNameText = "Mifare Standard 1K"
                End If
                If ATR(14) = 2 Then
                    CardNameText = "Mifare Standard 4K"
                End If
                If ATR(14) = 3 Then
                    CardNameText = "Mifare Ultra Light"
                End If
                If ATR(14) = 4 Then
                    CardNameText = "SLE55R_XXXX"
                End If
                If ATR(14) = 6 Then
                    CardNameText = "SR176"
                End If
                If ATR(14) = 7 Then
                    CardNameText = "SRI_X4K"
                End If
                If ATR(14) = 8 Then
                    CardNameText = "AT88RF020"
                End If
                If ATR(14) = 9 Then
                    CardNameText = "AT88SC0204CRF"
                End If
                If ATR(14) = 10 Then
                    CardNameText = "AT88SC0808CRF"
                End If
                If ATR(14) = 11 Then
                    CardNameText = "AT88SC1616RF"
                End If
                If ATR(14) = 12 Then
                    CardNameText = "AT88SC3216CRF"
                End If
                If ATR(14) = 13 Then
                    CardNameText = "AT88SC6416CRF"
                End If
                If ATR(14) = 14 Then
                    CardNameText = "SRF55V10P"
                End If
                If ATR(14) = 15 Then
                    CardNameText = "SRF55V02P"
                End If
                If ATR(14) = 16 Then
                    CardNameText = "SRF55V10S"
                End If
                If ATR(14) = 17 Then
                    CardNameText = "SRF55V02S"
                End If
                If ATR(14) = 18 Then
                    CardNameText = "TAG_IT"
                End If
                If ATR(14) = 19 Then
                    CardNameText = "LRI512"
                End If
                If ATR(14) = 20 Then
                    CardNameText = "ICODE.SII"
                End If
                If ATR(14) = 21 Then
                    CardNameText = "TEMPSENS"
                End If
                If ATR(14) = 22 Then
                    CardNameText = "i.CODE1"
                End If
                If ATR(14) = 24 Then
                    CardNameText = "iCLASS2KS"
                End If
                If ATR(14) = 26 Then
                    CardNameText = "iCLASS16KS"
                End If
                If ATR(14) = 28 Then
                    CardNameText = "iCLASS8x2KS"
                End If
                If ATR(14) = 29 Then
                    CardNameText = "iCLASS32KS_16_16"
                End If
                If ATR(14) = 30 Then
                    CardNameText = "iCLASS32KS_16_8x2"
                End If
                If ATR(14) = 31 Then
                    CardNameText = "iCLASS32KS_8x2_16"
                End If
                If ATR(14) = 32 Then
                    CardNameText = "iCLASS32KS_8x2_8x2"
                End If

            End If
        End If

    End Sub

    Public Function GetSmartCardResponse() As String
        On Error GoTo RET

        Response = ""

        Dim tempByte As String

        For i As Integer = 0 To RecvLen - 1
            tempByte = Hex(RecvBuff(i)).ToString
            Response += " " + IIf(tempByte.Length = 1, "0" + tempByte, tempByte)
        Next

        Return Response

RET:
        Return "Error."
    End Function

    Public Function GetSmartCardResponse2() As String
        On Error GoTo RET

        Response = ""

        Dim tempByte As String

        For i As Integer = 1 To RecvLen - 1
            tempByte = Hex(RecvBuff(i)).ToString
            Response += " " + IIf(tempByte.Length = 1, "0" + tempByte, tempByte)
        Next

        Return Response

RET:
        Return "00"
    End Function

    Public Function GetSmartCardResponse3() As String
        On Error GoTo RET

        Response = ""

        Dim tempByte As String

        For i As Integer = 1 To RecvLen - 3
            tempByte = Hex(RecvBuff(i)).ToString
            Response += " " + IIf(tempByte.Length = 1, "0" + tempByte, tempByte)
        Next

        Return Response

RET:
        Return "00"
    End Function

    Public Function GetSmartCardResponse4() As String
        On Error GoTo RET

        Response = ""

        Dim tempByte As String

        For l As Integer = 0 To RecvLen - 1
            tempByte = Hex(RecvBuff(l)).ToString
            Response += " " + IIf(tempByte.Length = 1, "0" + tempByte, tempByte)
        Next

        Return Response

RET:
        Return "00"
    End Function

    Public Function GetSmartCardResponse5() As String
        On Error GoTo RET

        Response = ""

        Dim tempByte As String

        For i As Integer = RecvLen - 2 To RecvLen - 1
            tempByte = Hex(RecvBuff(i)).ToString
            Response += " " + IIf(tempByte.Length = 1, "0" + tempByte, tempByte)
        Next

        Return Response

RET:
        Return "00"
    End Function

    Public Function Authenticate(ByRef lstBoxLog As ListBox) As Boolean
        SendAPDU("0A00", lstBoxLog)
        Return DESFireAuthenticate(lstBoxLog)
    End Function

    Public Function DESFireAuthenticate(ByVal lstBoxLog As ListBox) As Boolean
        If RecvLen <> 9 Then Return False

        Dim RndA(7) As Byte
        Dim RndB(7) As Byte
        Dim RndAB(15) As Byte
        Dim DKey(15) As Byte

        'Key is All 0x00
        For i As Integer = 0 To DKey.Length - 1
            DKey(i) = &H0
        Next

        'Challenge Data RndA is All 0x00
        For i As Integer = 0 To RndA.Length - 1
            RndA(i) = &H0
        Next

        Buffer.BlockCopy(RecvBuff, 1, RndB, 0, 8)

        ClassDES.Chain_DES(RndB(0), DKey(0), ClassDES.ALGO_DES, 1, ClassDES.DATA_DECRYPT)

        Buffer.BlockCopy(RndA, 0, RndAB, 0, 8)

        Buffer.BlockCopy(RndB, 1, RndAB, 8, 7)

        RndAB(15) = RndB(0)

        ClassDES.Chain_DES(RndAB(0), DKey(0), ClassDES.ALGO_DES, 1, ClassDES.DATA_DECRYPT)

        For i = 0 To 7
            RndAB(8 + i) = RndAB(8 + i) Xor RndAB(i)
        Next

        ClassDES.Chain_DES(RndAB(8), DKey(0), ClassDES.ALGO_DES, 1, ClassDES.DATA_DECRYPT)

        ClearBuffers()

        SendRequest.dwProtocol = 2
        SendRequest.cbPciLength = Len(SendRequest)

        Buffer.BlockCopy(RndAB, 0, SendBuff, 1, 16)
        SendBuff(0) = &HAF
        SendLen = 17
        RecvLen = 256

        retCode = ModWinsCard.SCardTransmit(hCard, SendRequest, SendBuff(0), SendLen, SendRequest, RecvBuff(0), RecvLen)

        Dim RecvByte As String = ""

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
            RecvByte = "Error."
            displayOut(1, retCode, "", lstBoxLog)
            Return False
        Else
            displayOut(1, retCode, "", lstBoxLog)

            RecvByte = GetSmartCardResponse()

            displayOut(3, retCode, RecvByte, lstBoxLog)

        End If

        Dim CheckR As Boolean = True

        For i As Integer = 0 To 7
            If RndAB(i) <> RecvBuff(i + 1) Then
                CheckR = False
                Exit For
            End If
        Next

        If CheckR = False Then Return False

        Return True

    End Function

    Public Sub SendAPDU(ByVal ApduCommand As String, ByVal lstBoxLog As ListBox)

        ClearBuffers()

        SendRequest.dwProtocol = 0
        SendRequest.cbPciLength = Len(SendRequest)

        Dim i2 As Integer = Len(SendRequest)

        Dim SendByte As String = ""
        Dim RecvByte As String = ""

        LastSendByte = ""

        RecvLen = 256

        SendLen = Len(ApduCommand) / 2

        If SendLen > 0 Then

            For i As Integer = 1 To SendLen
                SendByte = Mid(ApduCommand, i * 2 - 1, 2)

                SendBuff(i - 1) = CInt("&H" + SendByte)

                LastSendByte += " " + SendByte
            Next

            displayOut(2, 0, LastSendByte, lstBoxLog)

            retCode = ModWinsCard.SCardTransmit(hCard, SendRequest, SendBuff(0), SendLen, SendRequest, RecvBuff(0), RecvLen)

            If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
                RecvByte = "Error."
                displayOut(1, retCode, "", lstBoxLog)
            Else
                displayOut(1, retCode, "", lstBoxLog)

                RecvByte = GetSmartCardResponse()

                displayOut(3, retCode, RecvByte, lstBoxLog)

            End If

        End If
    End Sub

    Public Function SendAPDUandDisplay(ByVal reqType As Integer, ByRef lstLog As ListBox) As Integer

        Dim indx As Integer
        Dim tmpStr As String

        SendRequest.dwProtocol = 2 '2Aprotocol
        SendRequest.cbPciLength = Len(SendRequest)

        ' Display Apdu In
        tmpStr = ""
        For indx = 0 To SendLen - 1

            tmpStr = tmpStr + " " + Format(Hex(SendBuff(indx)), "")

        Next indx

        displayOut(2, 0, tmpStr, lstLog)
        retCode = ModWinsCard.SCardTransmit(hCard, SendRequest, SendBuff(0), SendLen, SendRequest, RecvBuff(0), RecvLen)

        If retCode <> ModWinsCard.SCARD_S_SUCCESS Then

            displayOut(1, retCode, "", lstLog)
            SendAPDUandDisplay = retCode
            Exit Function

        Else

            tmpStr = ""
            Select Case reqType

                Case 0  '  Display SW1/SW2 value
                    For indx = (RecvLen - 2) To (RecvLen - 1)

                        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "

                    Next indx

                    If Trim(tmpStr) <> "90 00" Then

                        displayOut(4, 0, "Return bytes are not acceptable.", lstLog)

                    End If

                Case 1  ' Display ATR after checking SW1/SW2

                    For indx = (RecvLen - 2) To (RecvLen - 1)

                        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "

                    Next indx

                    If tmpStr.Trim() <> "90 00" Then

                        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "

                    Else

                        tmpStr = "ATR : "
                        For indx = 0 To (RecvLen - 3)

                            tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "

                        Next indx

                    End If

                Case 2  ' Display all data

                    For indx = 0 To (RecvLen - 1)

                        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "

                    Next indx

                Case 3  ' Interpret SW1/SW2

                    For indx = (RecvLen - 2) To (RecvLen - 1)

                        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "

                    Next indx

                    If tmpStr.Trim = "6A 81" Then

                        displayOut(0, 0, "The function is not supported.", lstLog)
                        SendAPDUandDisplay = retCode
                        Exit Select

                    End If

                    If tmpStr.Trim = "63 00" Then

                        displayOut(0, 0, "The operation failed.", lstLog)
                        SendAPDUandDisplay = retCode
                        Exit Select

                    End If

                    validATS = True

            End Select

            displayOut(3, 0, tmpStr.Trim(), lstLog)

        End If

        SendAPDUandDisplay = retCode

    End Function

    Function SmartCardErrorCode() As String

        Dim ErrCode As String = GetSmartCardResponse5.Replace(" ", "")

        Select Case ErrCode

            Case "9000" : Return "Success"
            Case "6581" : Return "Memory Failure"
            Case "6981" : Return "Incompatible Command"
            Case "6982" : Return "Authentication Failed"
            Case "6300" : Return "Authentication Failed"
            Case "6986" : Return "Command not allowed"
            Case "6A81" : Return "Function not supported"
            Case "6A82" : Return "Invalid Block Address"
            Case "6400" : Return "Card execution error"
            Case "6700" : Return "Invalid Length"
            Case "6800" : Return "Invalid Class"
            Case "6B00" : Return "Invalid Parameter"
            Case Else : Return "Unknown error"

        End Select

    End Function

End Module
