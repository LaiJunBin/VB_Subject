Public Class form1
    Dim n(5), a(5), b(5), c(5), d(5), ans As Integer
    Dim ifop(3) As String
    Dim AnsList As New List(Of Integer)
    Dim op(5) As String
    Dim typeTitle() As String = {"", "單層迴圈", "雙層迴圈", "三層迴圈", "迴圈+if", "迴圈+if...else", "if"}
    Dim bool(4), topicTypeRecord(26) As Boolean
    Dim record(2), type(26), errorRecord(26) As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Array.Clear(type, 0, type.Count)
        Array.Clear(errorRecord, 0, errorRecord.Count)
        topicTypeRecord(1) = True : caseFor1()
    End Sub
    Sub init()
        Randomize()
        AnsList.Clear()
        TitleLabel.Text = ""
        judgeLabel.Text = ""
        judgeLabel.Text = "正確:" & record(1) & ",錯誤:" & record(2)
        chooseButton1.Text = ""
        chooseButton2.Text = ""
        chooseButton3.Text = ""
        chooseButton4.Text = ""
        For i = 1 To 5
            n(i) = Int(Rnd() * 100)
            a(i) = Int(Rnd() * 20 - 10)
            b(i) = a(1) + Int(Rnd() * 10 + 10)
            c(i) = Int(Rnd() * 5 + 1)
            d(i) = Int(Rnd() * 5 + 1)
            op(i) = Choose(Int(Rnd() * 5 + 1), "+", "-", "*", "/", "%")
            While op(i) = "*" And n(i) = 0
                n(i) += Int(Rnd() * 100)
            End While
            While d(i) = 0
                d(i) += Int(Rnd() * 5 + 1)
            End While
        Next
        ifop(1) = Choose(Int(Rnd() * 2 + 1), "x", "i")
        ifop(2) = Choose(Int(Rnd() * 5 + 1), ">", ">=", "=", "<=", "<")
        ifop(3) = Choose(Int(Rnd() * 4 + 1), If(ifop(1) = "x", "i", "x"), c(1), b(1), n(1))
        chooseButton1.Enabled = False
        chooseButton2.Enabled = False
        chooseButton3.Enabled = False
        chooseButton4.Enabled = False
        Array.Clear(bool, 0, bool.Count)
    End Sub
    Sub caseFor1()
        init()
        TitleLabel.Text &= "x=" & n(1) & vbNewLine
        TitleLabel.Text &= "for i = " & a(1) & " To " & b(1) & " step " & c(1) & vbNewLine
        TitleLabel.Text &= "　　x" & op(1) & "=" & d(1) & vbNewLine & "next" & vbNewLine & vbNewLine & "x=?"
        Dim temp As Integer = n(1)
        Try
            For i = a(1) To b(1) Step c(1)
                Select Case op(1)
                    Case "+"
                        temp += d(1)
                    Case "-"
                        temp -= d(1)
                    Case "*"
                        temp *= d(1)
                    Case "/"
                        temp /= d(1)
                    Case "%"
                        temp = temp Mod d(1)
                End Select
                AnsList.Add(temp)
            Next
        Catch ex As Exception
            Caseto() : Return
        End Try
        buttonToAns()
    End Sub
    Sub caseFor2()
        init()
        TitleLabel.Text &= "x=" & n(1) & vbNewLine
        TitleLabel.Text &= "for i = " & a(1) & " To " & b(1) & " step " & c(1) & vbNewLine
        TitleLabel.Text &= "　　for j = " & a(2) & " To " & b(2) & " step " & c(2) & vbNewLine
        TitleLabel.Text &= "　　　　x" & op(1) & "=" & d(1) & vbNewLine & "　　next" & vbNewLine & "next" & vbNewLine & vbNewLine & "x=?"
        Dim temp As Integer = n(1)
        Try
            For i = a(1) To b(1) Step c(1)
                For j = a(2) To b(2) Step c(2)
                    Select Case op(1)
                        Case "+"
                            temp += d(1)
                        Case "-"
                            temp -= d(1)
                        Case "*"
                            temp *= d(1)
                        Case "/"
                            temp /= d(1)
                        Case "%"
                            temp = temp Mod d(1)
                    End Select
                    AnsList.Add(temp)
                Next
            Next
        Catch ex As Exception
            Caseto() : Return
        End Try
        buttonToAns()
    End Sub
    Sub caseFor3()
        init()
        TitleLabel.Text &= "x=" & n(1) & vbNewLine
        TitleLabel.Text &= "for i = " & a(1) & " To " & b(1) & " step " & c(1) & vbNewLine
        TitleLabel.Text &= "　　for j = " & a(2) & " To " & b(2) & " step " & c(2) & vbNewLine
        TitleLabel.Text &= "　　　　for j = " & a(3) & " To " & b(3) & " step " & c(3) & vbNewLine
        TitleLabel.Text &= "　　　　　　x" & op(1) & "=" & d(1) & vbNewLine & "　　next" & vbNewLine & "next" & vbNewLine & vbNewLine & "x=?"
        Dim temp As Integer = n(1)
        Try
            For i = a(1) To b(1) Step c(1)
                For j = a(2) To b(2) Step c(2)
                    For k = a(3) To b(3) Step c(3)
                        Select Case op(1)
                            Case "+"
                                temp += d(1)
                            Case "-"
                                temp -= d(1)
                            Case "*"
                                temp *= d(1)
                            Case "/"
                                temp /= d(1)
                            Case "%"
                                temp = temp Mod d(1)
                        End Select
                        AnsList.Add(temp)
                    Next
                Next
            Next
        Catch ex As Exception
            Caseto() : Return
        End Try
        buttonToAns()
    End Sub
    Sub caseFor_If()
        init()
        TitleLabel.Text &= "x=" & n(1) & vbNewLine
        TitleLabel.Text &= "for i = " & a(1) & " To " & b(1) & " step " & c(1) & vbNewLine
        TitleLabel.Text &= "　　if " & ifop(1) & ifop(2) & ifop(3) & vbNewLine
        TitleLabel.Text &= "　　　　x" & op(1) & "=" & d(1) & vbNewLine & "　　End If" & vbNewLine
        TitleLabel.Text &= "next" & vbNewLine & vbNewLine & "x=?"
        Dim temp As Integer = n(1)
        Try
            For i = a(1) To b(1) Step c(1)
                Select Case ifop(2)
                    Case ">"
                        If Not If(ifop(1) = "x", temp, i) > If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then Continue For
                    Case ">="
                        If Not If(ifop(1) = "x", temp, i) >= If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then Continue For
                    Case "="
                        If Not If(ifop(1) = "x", temp, i) = If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then Continue For
                    Case "<"
                        If Not If(ifop(1) = "x", temp, i) < If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then Continue For
                    Case "<="
                        If Not If(ifop(1) = "x", temp, i) <= If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then Continue For
                End Select
                Select Case op(1)
                    Case "+"
                        temp += d(1)
                    Case "-"
                        temp -= d(1)
                    Case "*"
                        temp *= d(1)
                    Case "/"
                        temp /= d(1)
                    Case "%"
                        temp = temp Mod d(1)
                End Select
                AnsList.Add(temp)
            Next
        Catch ex As Exception
            Caseto() : Return
        End Try
        If AnsList.Count = 0 Then caseFor_If() : Return
        ans = AnsList.Last
        While AnsList.Distinct.ToList.Count < 4
            Dim rand As Integer = Rnd() * 10 - 5
            Dim index As Integer = Int(Rnd() * AnsList.Count)
            AnsList.Add(AnsList(index) + rand)
        End While
        buttonToAns()
    End Sub
    Sub caseFor_If_Else()
        init()
        TitleLabel.Text &= "x=" & n(1) & vbNewLine
        TitleLabel.Text &= "for i = " & a(1) & " To " & b(1) & " step " & c(1) & vbNewLine
        TitleLabel.Text &= "　　if " & ifop(1) & ifop(2) & ifop(3) & vbNewLine
        TitleLabel.Text &= "　　　　x" & op(1) & "=" & d(1) & vbNewLine & "　　Else" & vbNewLine
        TitleLabel.Text &= "　　　　x" & op(2) & "=" & d(2) & vbNewLine
        TitleLabel.Text &= " 　　End If" & vbNewLine & "next" & vbNewLine & vbNewLine & "x=?"
        Dim temp As Integer = n(1)
        Try
            For i = a(1) To b(1) Step c(1)
                Select Case ifop(2)
                    Case ">"
                        If If(ifop(1) = "x", temp, i) > If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then GoTo caseop1
                    Case ">="
                        If If(ifop(1) = "x", temp, i) >= If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then GoTo caseop1
                    Case "="
                        If If(ifop(1) = "x", temp, i) = If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then GoTo caseop1
                    Case "<"
                        If If(ifop(1) = "x", temp, i) < If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then GoTo caseop1
                    Case "<="
                        If If(ifop(1) = "x", temp, i) <= If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then GoTo caseop1
                End Select
                Select Case op(2)
                    Case "+"
                        temp += d(2)
                    Case "-"
                        temp -= d(2)
                    Case "*"
                        temp *= d(2)
                    Case "/"
                        temp /= d(2)
                    Case "%"
                        temp = temp Mod d(2)
                End Select
                GoTo addList
caseop1:
                Select Case op(1)
                    Case "+"
                        temp += d(1)
                    Case "-"
                        temp -= d(1)
                    Case "*"
                        temp *= d(1)
                    Case "/"
                        temp /= d(1)
                    Case "%"
                        temp = temp Mod d(1)
                End Select
addList:
                AnsList.Add(temp)
            Next
        Catch ex As Exception
            Caseto() : Return
        End Try
        If AnsList.Count = 0 Then caseFor_If_Else() : Return
        ans = AnsList.Last
        While AnsList.Distinct.ToList.Count < 4
            Dim rand As Integer = Rnd() * 10 - 5
            Dim index As Integer = Int(Rnd() * AnsList.Count)
            AnsList.Add(AnsList(index) + rand)
        End While
        buttonToAns()
    End Sub
    Sub caseIf()
        init()
        TitleLabel.Text &= "x=" & n(1) & ": i=" & a(2) & vbNewLine
        TitleLabel.Text &= "if " & ifop(1) & ifop(2) & ifop(3) & vbNewLine
        TitleLabel.Text &= "　　x" & op(1) & "=" & d(1) & vbNewLine & "End If" & vbNewLine
        TitleLabel.Text &= vbNewLine & "x=?"
        Dim temp As Integer = n(1)
        Dim i As Integer = a(2)
        Try
            Select Case ifop(2)
                Case ">"
                    If Not If(ifop(1) = "x", temp, i) > If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then GoTo pro
                Case ">="
                    If Not If(ifop(1) = "x", temp, i) >= If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then GoTo pro
                Case "="
                    If Not If(ifop(1) = "x", temp, i) = If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then GoTo pro
                Case "<"
                    If Not If(ifop(1) = "x", temp, i) < If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then GoTo pro
                Case "<="
                    If Not If(ifop(1) = "x", temp, i) <= If(ifop(3) = "x", temp, If(ifop(3) = "i", i, ifop(3))) Then GoTo pro
            End Select
            Select Case op(1)
                Case "+"
                    temp += d(1)
                Case "-"
                    temp -= d(1)
                Case "*"
                    temp *= d(1)
                Case "/"
                    temp /= d(1)
                Case "%"
                    temp = temp Mod d(1)
            End Select
pro:
            AnsList.Add(temp)
        Catch ex As Exception
            Caseto() : Return
        End Try
        If AnsList.Count = 0 Then caseFor_If() : Return
        ans = AnsList.Last
        While AnsList.Distinct.ToList.Count < 4
            Dim rand As Integer = Rnd() * 10 - 5
            Dim index As Integer = Int(Rnd() * AnsList.Count)
            AnsList.Add(AnsList(index) + rand)
        End While
        buttonToAns()
    End Sub
    Sub buttonToAns()
        Dim randNum As List(Of Integer) = {1, 2, 3, 4}.ToList
        Dim num As Integer = 0
        AnsList = AnsList.Distinct.ToList
        If AnsList.Count < 4 Then Caseto() : Return
        Dim ansNum As Integer = AnsList.Count
        While num < 4
            If num >= ansNum Then Exit While
            Dim index As Integer = Int(Rnd() * AnsList.Count)
            Dim rand As Integer = Int(Rnd() * randNum.Count)
            If num = 0 Then index = AnsList.IndexOf(ans) : index = If(index = -1, AnsList.Count - 1, index) : bool(randNum(rand)) = True
            Select Case randNum(rand)
                Case 1
                    If chooseButton1.Text = "" Then
                        chooseButton1.Text = AnsList(index)
                        num += 1
                        chooseButton1.Enabled = True
                        AnsList.RemoveAt(index)
                        randNum.RemoveAt(rand)
                    End If
                Case 2
                    If chooseButton2.Text = "" Then
                        chooseButton2.Text = AnsList(index)
                        num += 1
                        chooseButton2.Enabled = True
                        AnsList.RemoveAt(index)
                        randNum.RemoveAt(rand)
                    End If
                Case 3
                    If chooseButton3.Text = "" Then
                        chooseButton3.Text = AnsList(index)
                        num += 1
                        chooseButton3.Enabled = True
                        AnsList.RemoveAt(index)
                        randNum.RemoveAt(rand)
                    End If
                Case 4
                    If chooseButton4.Text = "" Then
                        chooseButton4.Text = AnsList(index)
                        num += 1
                        chooseButton4.Enabled = True
                        AnsList.RemoveAt(index)
                        randNum.RemoveAt(rand)
                    End If
            End Select
        End While
    End Sub
    Sub Caseto()
        Dim rand As Integer = Int(Rnd() * 6 + 1)
        Array.Clear(topicTypeRecord, 0, topicTypeRecord.Count)
        topicTypeRecord(rand) = True
        Select Case rand
            Case 1
                caseFor1()
            Case 2
                caseFor2()
            Case 3
                caseFor3()
            Case 4
                caseFor_If()
            Case 5
                caseFor_If_Else()
            Case 6
                caseIf()
            Case Else
                Caseto() : Return
        End Select
    End Sub
    Private Sub chooseButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chooseButton1.Click
        If bool(1) = True Then
            MsgBox("正確")
            record(1) += 1
        Else
            MsgBox("錯誤 答案=" & ans)
            record(2) += 1
            errorRecord(Array.IndexOf(topicTypeRecord, True)) += 1
        End If
        type(Array.IndexOf(topicTypeRecord, True)) += 1
        Caseto()
    End Sub
    Private Sub chooseButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chooseButton2.Click
        If bool(2) = True Then
            MsgBox("正確")
            record(1) += 1
        Else
            MsgBox("錯誤 答案=" & ans)
            errorRecord(Array.IndexOf(topicTypeRecord, True)) += 1
            record(2) += 1
        End If
        type(Array.IndexOf(topicTypeRecord, True)) += 1
        Caseto()
    End Sub

    Private Sub chooseButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chooseButton3.Click
        If bool(3) = True Then
            MsgBox("正確")
            record(1) += 1
        Else
            MsgBox("錯誤 答案=" & ans)
            errorRecord(Array.IndexOf(topicTypeRecord, True)) += 1
            record(2) += 1
        End If
        type(Array.IndexOf(topicTypeRecord, True)) += 1
        Caseto()
    End Sub

    Private Sub chooseButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chooseButton4.Click
        If bool(4) = True Then
            MsgBox("正確")
            record(1) += 1
        Else
            MsgBox("錯誤 答案=" & ans)
            errorRecord(Array.IndexOf(topicTypeRecord, True)) += 1
            record(2) += 1
        End If
        type(Array.IndexOf(topicTypeRecord, True)) += 1
        Caseto()
    End Sub

    Private Sub moreMsgButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moreMsgButton.Click
        Dim temp As String = ""
        For i = 1 To UBound(typeTitle)
            temp &= typeTitle(i) & "總數=" & type(i) & "　錯誤數=" & errorRecord(i)
            temp &= "　正確率=" & ((type(i) - errorRecord(i)) / type(i)).ToString("0.00%")
            temp &= vbNewLine
        Next
        MsgBox(temp)
    End Sub
    Private Sub skipButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles skipButton.Click
        Caseto()
    End Sub
End Class