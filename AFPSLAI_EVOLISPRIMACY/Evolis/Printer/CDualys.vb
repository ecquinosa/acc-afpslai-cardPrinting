Public Class CDualys
    Inherits CPrinter
    ''<summary>
    ''Standard printer Identificaion
    ''Has to be defined for child class
    ''</summary>Overridable 
    'Public Overrides Function IDPrt() As Boolean
    '    Dim bStatus As Boolean = True
    '    Dim i As Integer
    '    Dim enuId As IDictionaryEnumerator

    '    IDPrt = False

    '    prtId.Clear()
    '    csaValue.Clear()

    '    If (Me.OpenEvoPrinter()) Then
    '        prtId.Add("Printer ID", Chr(27) & "Rtp" & Chr(13))
    '        prtId.Add("Serial Number", Chr(27) & "Rsn" & Chr(13))
    '        prtId.Add("Kit Head", Chr(27) & "Rkn" & Chr(13))
    '        prtId.Add("Firmware", Chr(27) & "Rfv" & Chr(13))
    '        enuId = prtId.GetEnumerator()
    '        doAction(Chr(27) & "Pem;2" & Chr(13), 2000, bStatus)
    '        While enuId.MoveNext
    '            Me.setCde = enuId.Value
    '            If (Me.WRPrinter(bStatus)) Then
    '                csaValue.Add(Me.getLastAnswer)
    '                IDPrt = True
    '            Else
    '                Exit While
    '            End If
    '        End While
    '        doAction(Chr(27) & "Pem;0" & Chr(13), 2000, bStatus)
    '        Me.CloseEvoPrinter()
    '    End If

    'End Function

    '<summary>
    'Standard printer status
    'Has to be defined for child class
    '</summary>Overridable

    Public Overrides Function GetStatusPrt() As Boolean

        Dim bStatus As Boolean = True
        Dim enuId As IDictionaryEnumerator

        GetStatusPrt = False
        prtId.Clear()

        csaValue.Clear()

        If (Me.OpenEvoPrinter()) Then
            prtId.Add("Card present", Chr(27) & "Rlr;p" & Chr(13))
            prtId.Add("Cover is", Chr(27) & "Rse;o" & Chr(13))
            prtId.Add("End of ribbon", Chr(27) & "Rcr" & Chr(13))
            prtId.Add("Feeder is", Chr(27) & "Rse;f" & Chr(13))
            prtId.Add("Need cleaning", Chr(27) & "Rlr;c" & Chr(13))

            enuId = prtId.GetEnumerator()
            doAction(Chr(27) & "Pem;2" & Chr(13), 2000, bStatus)
            While enuId.MoveNext
                Me.setCde = enuId.Value
                If (Me.WRPrinter(bStatus)) Then
                    csaValue.Add(Me.getLastAnswer)
                    GetStatusPrt = True
                Else
                    Exit While
                End If
            End While
            doAction(Chr(27) & "Pem;0" & Chr(13), 2000, bStatus)
            Me.CloseEvoPrinter()
        End If
    End Function
End Class
