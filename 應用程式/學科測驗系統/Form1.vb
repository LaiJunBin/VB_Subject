Public Class form1
    Dim n(5), a(5), b(5), c(5), d(5) As Integer
    Dim ifop(6), ans As String
    Dim AnsList As New List(Of Integer)
    Dim op(5), selectStr(5), selectOp(5) As String
    Dim typeTitle() As String = {"", "單層迴圈", "雙層迴圈", "三層迴圈", "迴圈+if", "迴圈+if...else", "if", "if...else", "if...elseif",
                                 "if if...else", "select", "while", "while+if", "while+ifElse"}
    Dim bool(4), topicTypeRecord(26) As Boolean
    Dim record(2), type(26), errorRecord(26) As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Array.Clear(type, 0, type.Count)
        Array.Clear(errorRecord, 0, errorRecord.Count)
        selectStr(0) = "於麗傳者紅？頭升什式印品成積館去制在保是；動操一西的分目健情票看校其物手以，兒到主；不友產兒分人千男一什發底到香的直幾，個為教的大況皮車的廣積親理神作，區吸部雜電車記農期投心覺緊海腦！上只國起法的。語歡然非孩問成物自入課們公食鄉，國斷下。親起們日行是議著者此必前就，花是適然者立歌親接的展洋；教經意信賽大下相建物臺自告者麼問通里們晚推會特代要興分一一家子，口葉新媽不單火的反系關的。他公家臺小時用運的可動形著，中發十是……東物人一都中訴走，生錢是難裡長同有是度光讓環望來到醫理戰親得；奇務一花青信己們形明。然立的意聲……化了內病那育非如不而氣來女的只工電對水今動。來念細工笑！民商比中樹相在立列十散當老山新點微？不難能運了己者統親生位人，小住職有的生主總聲開復！色總路。樣國這活市文院有師山進參子當平銀證，同管發你物便布能！知對數理資可第點費。"
        For i = 1 To 20
            Dim rand As Integer = Int(Rnd() * 26)
            selectStr(1) &= Chr(If(Int(Rnd() * 2) = 0, 65, 97) + rand)
        Next
        Caseto()
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
            b(i) = a(i) + Int(Rnd() * 10 + 10)
            c(i) = Int(Rnd() * 5 + 1)
            d(i) = Int(Rnd() * 5 + 1)
            op(i) = Choose(Int(Rnd() * 5 + 1), "+", "-", "*", "/", "%")
            selectOp(i) = Choose(Int(Rnd() * 5 + 1), ">", ">=", "=", "<=", "<")
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
        ifop(4) = Choose(Int(Rnd() * 2 + 1), "x", "i")
        ifop(5) = Choose(Int(Rnd() * 5 + 1), ">", ">=", "=", "<=", "<")
        ifop(6) = Choose(Int(Rnd() * 4 + 1), If(ifop(4) = "x", "i", "x"), c(2), b(2), n(2))
        ans = ""
        chooseButton1.Enabled = False
        chooseButton2.Enabled = False
        chooseButton3.Enabled = False
        chooseButton4.Enabled = False
        Array.Clear(bool, 0, bool.Count)
    End Sub
#Region "for"
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
#End Region
#Region "for+if"
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
#End Region
#Region "IfElse"
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
    Sub caseIf_Else()
        init()
        TitleLabel.Text &= "x=" & n(1) & ": i=" & a(2) & vbNewLine
        TitleLabel.Text &= "if " & ifop(1) & ifop(2) & ifop(3) & vbNewLine
        TitleLabel.Text &= "　　x" & op(1) & "=" & d(1) & vbNewLine & "Else" & vbNewLine
        TitleLabel.Text &= "　　x" & op(2) & "=" & d(2) & vbNewLine & "End If" & vbNewLine
        TitleLabel.Text &= vbNewLine & "x=?"
        Dim temp As Integer = n(1)
        Dim i As Integer = a(2)
        Try
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
    Sub caseIf_ElseIf()
        init()
        TitleLabel.Text &= "x=" & n(1) & ": i=" & a(2) & vbNewLine
        TitleLabel.Text &= "if " & ifop(1) & ifop(2) & ifop(3) & vbNewLine
        TitleLabel.Text &= "　　x" & op(1) & "=" & d(1) & vbNewLine & "ElseIf " & ifop(4) & ifop(5) & ifop(6) & vbNewLine
        TitleLabel.Text &= "　　x" & op(2) & "=" & d(2) & vbNewLine & "End If" & vbNewLine
        TitleLabel.Text &= vbNewLine & "x=?"
        Dim temp As Integer = n(1)
        Dim i As Integer = a(2)
        Try
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
            Select Case ifop(5)
                Case ">"
                    If If(ifop(4) = "x", temp, i) > If(ifop(6) = "x", temp, If(ifop(6) = "i", i, ifop(6))) Then  Else GoTo addList
                Case ">="
                    If If(ifop(4) = "x", temp, i) >= If(ifop(6) = "x", temp, If(ifop(6) = "i", i, ifop(6))) Then  Else GoTo addList
                Case "="
                    If If(ifop(4) = "x", temp, i) = If(ifop(6) = "x", temp, If(ifop(6) = "i", i, ifop(6))) Then  Else GoTo addList
                Case "<"
                    If If(ifop(4) = "x", temp, i) < If(ifop(6) = "x", temp, If(ifop(6) = "i", i, ifop(6))) Then  Else GoTo addList
                Case "<="
                    If If(ifop(4) = "x", temp, i) <= If(ifop(6) = "x", temp, If(ifop(6) = "i", i, ifop(6))) Then  Else GoTo addList
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
    Sub caseIf_If_Else()
        init()
        TitleLabel.Text &= "x=" & n(1) & ": i=" & a(2) & vbNewLine
        TitleLabel.Text &= "if " & ifop(4) & ifop(5) & ifop(6) & vbNewLine
        TitleLabel.Text &= "　　if " & ifop(1) & ifop(2) & ifop(3) & vbNewLine
        TitleLabel.Text &= "　　　　x" & op(1) & "=" & d(1) & vbNewLine & "　　Else" & vbNewLine
        TitleLabel.Text &= "　　　　x" & op(2) & "=" & d(2) & vbNewLine & "　　End If" & vbNewLine & "End If" & vbNewLine
        TitleLabel.Text &= vbNewLine & "x=?"
        Dim temp As Integer = n(1)
        Dim i As Integer = a(2)
        Try
            Select Case ifop(5)
                Case ">"
                    If If(ifop(4) = "x", temp, i) > If(ifop(6) = "x", temp, If(ifop(6) = "i", i, ifop(6))) Then  Else GoTo addList
                Case ">="
                    If If(ifop(4) = "x", temp, i) >= If(ifop(6) = "x", temp, If(ifop(6) = "i", i, ifop(6))) Then  Else GoTo addList
                Case "="
                    If If(ifop(4) = "x", temp, i) = If(ifop(6) = "x", temp, If(ifop(6) = "i", i, ifop(6))) Then  Else GoTo addList
                Case "<"
                    If If(ifop(4) = "x", temp, i) < If(ifop(6) = "x", temp, If(ifop(6) = "i", i, ifop(6))) Then  Else GoTo addList
                Case "<="
                    If If(ifop(4) = "x", temp, i) <= If(ifop(6) = "x", temp, If(ifop(6) = "i", i, ifop(6))) Then  Else GoTo addList
            End Select
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
#End Region
#Region "select"
    Sub caseSelect()
        init()
        Dim tempStr As String = ""
        Dim tempRand As Integer = Int(Rnd() * 2)
        Dim strType As Integer = tempRand
        Dim recordTemp As New List(Of List(Of String)) '1=To , 2=Is ,3=>=< ,4=Else
        recordTemp.Add(New List(Of String))
        For j = 1 To Int(Rnd() * 10 + 1)
            tempStr &= Mid(selectStr(tempRand), Int(Rnd() * selectStr(tempRand).Length + 1), 1)
        Next
        TitleLabel.Text &= "x=" & n(1) & " : str=" & Chr(34) & tempStr & Chr(34) & vbNewLine
        tempRand = Int(Rnd() * 3 + 1)
        Dim temp As Integer = n(1)
        Try
            Select Case tempRand
                Case 1
                    TitleLabel.Text &= "select case str.Length" & vbNewLine
                    tempRand = Int(Rnd() * 2 + 2)
                    For i = 1 To tempRand
                        recordTemp.Add({Int(Rnd() * 3 + 1).ToString}.ToList)
                        If i = tempRand And Int(Rnd() * 2) = 0 Then
                            recordTemp(i)(0) = 4
                            TitleLabel.Text &= "Case Else" & vbNewLine
                        Else
                            If recordTemp(i)(0) = 1 Then
                                TitleLabel.Text &= "Case " & c(i) & " To " & d(i) & vbNewLine
                                recordTemp(i).Add(c(i))
                                recordTemp(i).Add(d(i))
                            ElseIf recordTemp(i)(0) = 2 Then
                                TitleLabel.Text &= "Case " & c(i) & vbNewLine
                                recordTemp(i).Add(c(i))
                            Else
                                TitleLabel.Text &= "Case Is " & selectOp(i) & c(i) & vbNewLine
                                recordTemp(i).Add(c(i))
                            End If
                        End If
                        TitleLabel.Text &= "　　x" & op(i) & "=" & d(i) & vbNewLine
                    Next
                    Dim ans As Integer = tempStr.Length
                    For i = 1 To recordTemp.Count - 1
                        Select Case recordTemp(i)(0)
                            Case 1
                                If ans >= Math.Min(Val(recordTemp(i)(1)), Val(recordTemp(i)(2))) And ans <= Math.Max(Val(recordTemp(i)(1)), Val(recordTemp(i)(2))) Then
                                    Select Case op(i)
                                        Case "+"
                                            temp += d(i)
                                        Case "-"
                                            temp -= d(i)
                                        Case "*"
                                            temp *= d(i)
                                        Case "/"
                                            temp /= d(i)
                                        Case "%"
                                            temp = temp Mod d(i)
                                    End Select
                                    Exit For
                                End If
                            Case 2
                                If ans = Val(recordTemp(i)(1)) Then
                                    Select Case op(i)
                                        Case "+"
                                            temp += d(i)
                                        Case "-"
                                            temp -= d(i)
                                        Case "*"
                                            temp *= d(i)
                                        Case "/"
                                            temp /= d(i)
                                        Case "%"
                                            temp = temp Mod d(i)
                                    End Select
                                    Exit For
                                End If
                            Case 3
                                Select Case selectOp(i)
                                    Case ">"
                                        If Not ans > recordTemp(i)(1) Then Continue For
                                    Case ">="
                                        If Not ans >= recordTemp(i)(1) Then Continue For
                                    Case "="
                                        If Not ans = recordTemp(i)(1) Then Continue For
                                    Case "<"
                                        If Not ans < recordTemp(i)(1) Then Continue For
                                    Case "<="
                                        If Not ans <= recordTemp(i)(1) Then Continue For
                                End Select
                                Select Case op(i)
                                    Case "+"
                                        temp += d(i)
                                    Case "-"
                                        temp -= d(i)
                                    Case "*"
                                        temp *= d(i)
                                    Case "/"
                                        temp /= d(i)
                                    Case "%"
                                        temp = temp Mod d(i)
                                End Select
                                Exit For
                            Case 4
                                Select Case op(i)
                                    Case "+"
                                        temp += d(i)
                                    Case "-"
                                        temp -= d(i)
                                    Case "*"
                                        temp *= d(i)
                                    Case "/"
                                        temp /= d(i)
                                    Case "%"
                                        temp = temp Mod d(i)
                                End Select
                                Exit For
                        End Select
                    Next
                Case 2
                    If strType = 0 Then Caseto() : Return
                    TitleLabel.Text &= "select case Asc(str)" & vbNewLine
                    tempRand = Int(Rnd() * 2 + 2)
                    Dim ans As Integer = Asc(tempStr)
                    For i = 1 To tempRand
                        recordTemp.Add({Int(Rnd() * 3 + 1).ToString}.ToList)
                        If i = tempRand And Int(Rnd() * 2) = 0 Then
                            recordTemp(i)(0) = 4
                            TitleLabel.Text &= "Case Else" & vbNewLine
                        Else
                            If recordTemp(i)(0) = 1 Then
                                TitleLabel.Text &= "Case " & ans + c(i) & " To " & ans + d(i) & vbNewLine
                                recordTemp(i).Add(ans + c(i))
                                recordTemp(i).Add(ans + d(i))
                            ElseIf recordTemp(i)(0) = 2 Then
                                TitleLabel.Text &= "Case " & ans + c(i) & vbNewLine
                                recordTemp(i).Add(ans + c(i))
                            Else
                                TitleLabel.Text &= "Case Is " & selectOp(i) & ans + c(i) & vbNewLine
                                recordTemp(i).Add(ans + c(i))
                            End If
                        End If
                        TitleLabel.Text &= "　　x" & op(i) & "=" & d(i) & vbNewLine
                    Next
                    For i = 1 To recordTemp.Count - 1
                        Select Case recordTemp(i)(0)
                            Case 1
                                If ans >= Math.Min(Val(recordTemp(i)(1)), Val(recordTemp(i)(2))) And ans <= Math.Max(Val(recordTemp(i)(1)), Val(recordTemp(i)(2))) Then
                                    Select Case op(i)
                                        Case "+"
                                            temp += d(i)
                                        Case "-"
                                            temp -= d(i)
                                        Case "*"
                                            temp *= d(i)
                                        Case "/"
                                            temp /= d(i)
                                        Case "%"
                                            temp = temp Mod d(i)
                                    End Select
                                    Exit For
                                End If
                            Case 2
                                If ans = Val(recordTemp(i)(1)) Then
                                    Select Case op(i)
                                        Case "+"
                                            temp += d(i)
                                        Case "-"
                                            temp -= d(i)
                                        Case "*"
                                            temp *= d(i)
                                        Case "/"
                                            temp /= d(i)
                                        Case "%"
                                            temp = temp Mod d(i)
                                    End Select
                                    Exit For
                                End If
                            Case 3
                                Select Case selectOp(i)
                                    Case ">"
                                        If Not ans > recordTemp(i)(1) Then Continue For
                                    Case ">="
                                        If Not ans >= recordTemp(i)(1) Then Continue For
                                    Case "="
                                        If Not ans = recordTemp(i)(1) Then Continue For
                                    Case "<"
                                        If Not ans < recordTemp(i)(1) Then Continue For
                                    Case "<="
                                        If Not ans <= recordTemp(i)(1) Then Continue For
                                End Select
                                Select Case op(i)
                                    Case "+"
                                        temp += d(i)
                                    Case "-"
                                        temp -= d(i)
                                    Case "*"
                                        temp *= d(i)
                                    Case "/"
                                        temp /= d(i)
                                    Case "%"
                                        temp = temp Mod d(i)
                                End Select
                                Exit For
                            Case 4
                                Select Case op(i)
                                    Case "+"
                                        temp += d(i)
                                    Case "-"
                                        temp -= d(i)
                                    Case "*"
                                        temp *= d(i)
                                    Case "/"
                                        temp /= d(i)
                                    Case "%"
                                        temp = temp Mod d(i)
                                End Select
                                Exit For
                        End Select
                    Next
                Case 3
                    TitleLabel.Text &= "select case str" & vbNewLine
                    Dim tempList As New List(Of String)
                    tempList.Add("")
                    tempRand = Int(Rnd() * 2 + 2)
                    For i = 1 To tempRand
                        Dim dStr As String = ""
                        For j = 1 To tempStr.Length
                            dStr &= Mid(selectStr(strType), Int(Rnd() * selectStr(strType).Length + 1), 1)
                        Next
                        tempList.Add(dStr)
                        recordTemp.Add({Int(Rnd() * 3 + 1).ToString}.ToList)
                        If i = tempRand And Int(Rnd() * 2) = 0 Then
                            recordTemp(i)(0) = 4
                            TitleLabel.Text &= "Case Else" & vbNewLine
                        Else
                            If recordTemp(i)(0) = 2 Then
                                TitleLabel.Text &= "Case " & Chr(34) & dStr & Chr(34) & vbNewLine
                                recordTemp(i).Add(dStr)
                            Else
                                TitleLabel.Text &= "Case Is " & selectOp(i) & Chr(34) & dStr & Chr(34) & vbNewLine
                                recordTemp(i).Add(dStr)
                            End If
                        End If
                        TitleLabel.Text &= "　　x" & op(i) & "=" & d(i) & vbNewLine
                    Next
                    For i = 1 To recordTemp.Count - 1
                        Select Case recordTemp(i)(0)
                            Case 2
                                If tempStr = tempList(i) Then
                                    Select Case op(i)
                                        Case "+"
                                            temp += d(i)
                                        Case "-"
                                            temp -= d(i)
                                        Case "*"
                                            temp *= d(i)
                                        Case "/"
                                            temp /= d(i)
                                        Case "%"
                                            temp = temp Mod d(i)
                                    End Select
                                    Exit For
                                End If
                            Case 3
                                Select Case selectOp(i)
                                    Case ">"
                                        If Not ans > tempList(i) Then Continue For
                                    Case ">="
                                        If Not ans >= tempList(i) Then Continue For
                                    Case "="
                                        If Not ans = tempList(i) Then Continue For
                                    Case "<"
                                        If Not ans < tempList(i) Then Continue For
                                    Case "<="
                                        If Not ans <= tempList(i) Then Continue For
                                End Select
                                Select Case op(i)
                                    Case "+"
                                        temp += d(i)
                                    Case "-"
                                        temp -= d(i)
                                    Case "*"
                                        temp *= d(i)
                                    Case "/"
                                        temp /= d(i)
                                    Case "%"
                                        temp = temp Mod d(i)
                                End Select
                                Exit For
                            Case 4
                                Select Case op(i)
                                    Case "+"
                                        temp += d(i)
                                    Case "-"
                                        temp -= d(i)
                                    Case "*"
                                        temp *= d(i)
                                    Case "/"
                                        temp /= d(i)
                                    Case "%"
                                        temp = temp Mod d(i)
                                End Select
                                Exit For
                        End Select
                    Next
            End Select

            TitleLabel.Text &= "End select" & vbNewLine
            TitleLabel.Text &= vbNewLine & "x=?"
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
#End Region
#Region "while"
    Sub caseWhileA()
        init()
        TitleLabel.Text &= "x=" & n(1) & " :i=" & n(2) & vbNewLine
        TitleLabel.Text &= "while " & ifop(1) & ifop(2) & ifop(3) & vbNewLine
        TitleLabel.Text &= "　　x" & op(1) & "=" & d(1) & vbNewLine
        TitleLabel.Text &= "　　i" & op(2) & "=" & d(2) & vbNewLine
        TitleLabel.Text &= "End While" & vbNewLine & vbNewLine & "x=?"
        Dim temp As Integer = n(1)
        Dim y As Integer = n(2)
        Dim count As Integer = 0
        Try
            Select Case ifop(2)
                Case ">"
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) > If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
                Case ">="
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) >= If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
                Case "="
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) = If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
                Case "<"
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) < If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
                Case "<="
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) <= If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
            End Select
        Catch ex As Exception
            Caseto() : Return
        End Try
        If AnsList.Count = 0 Then caseWhileA() : Return
        If ans <> "無窮迴圈" Then ans = AnsList.Last
        While AnsList.Distinct.ToList.Count < 4
            Dim rand As Integer = Rnd() * 10 - 5
            Dim index As Integer = Int(Rnd() * AnsList.Count)
            AnsList.Add(AnsList(index) + rand)
        End While
        buttonToAns()
    End Sub
    Sub caseWhileIf()
        init()
        TitleLabel.Text &= "x=" & n(1) & " :i=" & n(2) & vbNewLine
        TitleLabel.Text &= "while " & ifop(1) & ifop(2) & ifop(3) & vbNewLine
        TitleLabel.Text &= "　　x" & op(1) & "=" & d(1) & vbNewLine
        TitleLabel.Text &= "　　i" & op(2) & "=" & d(2) & vbNewLine
        TitleLabel.Text &= "　　if " & ifop(4) & ifop(5) & ifop(6) & vbNewLine
        TitleLabel.Text &= "　　　　x" & op(3) & "=" & d(3) & vbNewLine
        TitleLabel.Text &= "　　End if" & vbNewLine
        TitleLabel.Text &= "End While" & vbNewLine & vbNewLine & "x=?"
        Dim temp As Integer = n(1)
        Dim y As Integer = n(2)
        Dim count As Integer = 0
        Try
            Select Case ifop(2)
                Case ">"
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) > If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        Select Case ifop(5)
                            Case ">"
                                If If(ifop(4) = "x", temp, y) > If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case ">="
                                If If(ifop(4) = "x", temp, y) >= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "="
                                If If(ifop(4) = "x", temp, y) = If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "<"
                                If If(ifop(4) = "x", temp, y) < If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "<="
                                If If(ifop(4) = "x", temp, y) <= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                        End Select
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
                Case ">="
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) >= If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        Select Case ifop(5)
                            Case ">"
                                If If(ifop(4) = "x", temp, y) > If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case ">="
                                If If(ifop(4) = "x", temp, y) >= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "="
                                If If(ifop(4) = "x", temp, y) = If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "<"
                                If If(ifop(4) = "x", temp, y) < If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "<="
                                If If(ifop(4) = "x", temp, y) <= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                        End Select
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
                Case "="
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) = If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        Select Case ifop(5)
                            Case ">"
                                If If(ifop(4) = "x", temp, y) > If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case ">="
                                If If(ifop(4) = "x", temp, y) >= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "="
                                If If(ifop(4) = "x", temp, y) = If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "<"
                                If If(ifop(4) = "x", temp, y) < If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "<="
                                If If(ifop(4) = "x", temp, y) <= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                        End Select
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
                Case "<"
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) < If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        Select Case ifop(5)
                            Case ">"
                                If If(ifop(4) = "x", temp, y) > If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case ">="
                                If If(ifop(4) = "x", temp, y) >= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "="
                                If If(ifop(4) = "x", temp, y) = If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "<"
                                If If(ifop(4) = "x", temp, y) < If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "<="
                                If If(ifop(4) = "x", temp, y) <= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                        End Select
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
                Case "<="
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) <= If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        Select Case ifop(5)
                            Case ">"
                                If If(ifop(4) = "x", temp, y) > If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case ">="
                                If If(ifop(4) = "x", temp, y) >= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "="
                                If If(ifop(4) = "x", temp, y) = If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "<"
                                If If(ifop(4) = "x", temp, y) < If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                            Case "<="
                                If If(ifop(4) = "x", temp, y) <= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then whileProcess(temp, 3)
                        End Select
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
            End Select
        Catch ex As Exception
            Caseto() : Return
        End Try
        If AnsList.Count = 0 Then caseWhileIf() : Return
        If ans <> "無窮迴圈" Then ans = AnsList.Last
        While AnsList.Distinct.ToList.Count < 4
            Dim rand As Integer = Rnd() * 10 - 5
            Dim index As Integer = Int(Rnd() * AnsList.Count)
            AnsList.Add(AnsList(index) + rand)
        End While
        buttonToAns()
    End Sub
    Sub caseWhileIfElse()
        init()
        Dim ifRand As Integer = Int(Rnd() * 2)
        TitleLabel.Text &= "x=" & n(1) & " :i=" & n(2) & vbNewLine
        TitleLabel.Text &= "while " & ifop(1) & ifop(2) & ifop(3) & vbNewLine
        TitleLabel.Text &= "　　x" & op(1) & "=" & d(1) & vbNewLine
        TitleLabel.Text &= "　　i" & op(2) & "=" & d(2) & vbNewLine
        TitleLabel.Text &= "　　if " & ifop(4) & ifop(5) & ifop(6) & vbNewLine
        TitleLabel.Text &= "　　　　" & If(ifRand = 0, "Exit While", "x" & op(4) & "=" & d(4)) & vbNewLine & "　　Else" & vbNewLine
        TitleLabel.Text &= "　　　　x" & op(3) & "=" & d(3) & vbNewLine
        TitleLabel.Text &= "　　End if" & vbNewLine
        TitleLabel.Text &= "End While" & vbNewLine & "x=?"
        Dim temp As Integer = n(1)
        Dim y As Integer = n(2)
        Dim count As Integer = 0
        Try
            Select Case ifop(2)
                Case ">"
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) > If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        Select Case ifop(5)
                            Case ">"
                                If If(ifop(4) = "x", temp, y) > If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case ">="
                                If If(ifop(4) = "x", temp, y) >= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "="
                                If If(ifop(4) = "x", temp, y) = If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "<"
                                If If(ifop(4) = "x", temp, y) < If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "<="
                                If If(ifop(4) = "x", temp, y) <= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                        End Select
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
                Case ">="
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) >= If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        Select Case ifop(5)
                            Case ">"
                                If If(ifop(4) = "x", temp, y) > If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case ">="
                                If If(ifop(4) = "x", temp, y) >= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "="
                                If If(ifop(4) = "x", temp, y) = If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "<"
                                If If(ifop(4) = "x", temp, y) < If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "<="
                                If If(ifop(4) = "x", temp, y) <= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                        End Select
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
                Case "="
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) = If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        Select Case ifop(5)
                            Case ">"
                                If If(ifop(4) = "x", temp, y) > If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case ">="
                                If If(ifop(4) = "x", temp, y) >= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "="
                                If If(ifop(4) = "x", temp, y) = If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "<"
                                If If(ifop(4) = "x", temp, y) < If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "<="
                                If If(ifop(4) = "x", temp, y) <= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                        End Select
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
                Case "<"
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) < If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        Select Case ifop(5)
                            Case ">"
                                If If(ifop(4) = "x", temp, y) > If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case ">="
                                If If(ifop(4) = "x", temp, y) >= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "="
                                If If(ifop(4) = "x", temp, y) = If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "<"
                                If If(ifop(4) = "x", temp, y) < If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "<="
                                If If(ifop(4) = "x", temp, y) <= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                        End Select
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
                Case "<="
                    While If(ifop(1) = "i", y, If(ifop(1) = "x", temp, ifop(1))) <= If(ifop(3) = "i", y, If(ifop(3) = "x", temp, ifop(3)))
                        whileProcess(temp, 1)
                        whileProcess(y, 2)
                        Select Case ifop(5)
                            Case ">"
                                If If(ifop(4) = "x", temp, y) > If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case ">="
                                If If(ifop(4) = "x", temp, y) >= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "="
                                If If(ifop(4) = "x", temp, y) = If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "<"
                                If If(ifop(4) = "x", temp, y) < If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                            Case "<="
                                If If(ifop(4) = "x", temp, y) <= If(ifop(6) = "x", temp, If(ifop(6) = "i", y, ifop(6))) Then If ifRand = 0 Then Exit While Else whileProcess(temp, 4) Else whileProcess(temp, 3)
                        End Select
                        count += 1
                        If count >= 100 Then
                            ans = "無窮迴圈" : Exit While
                        End If
                    End While
            End Select
        Catch ex As Exception
            Caseto() : Return
        End Try
        If AnsList.Count = 0 Then caseWhileIf() : Return
        If ans <> "無窮迴圈" Then ans = AnsList.Last
        While AnsList.Distinct.ToList.Count < 4
            Dim rand As Integer = Rnd() * 10 - 5
            Dim index As Integer = Int(Rnd() * AnsList.Count)
            AnsList.Add(AnsList(index) + rand)
        End While
        buttonToAns()
    End Sub
    Sub whileProcess(ByRef temp As Integer, ByVal i As Integer)
        Select Case op(i)
            Case "+"
                temp += d(i)
            Case "-"
                temp -= d(i)
            Case "*"
                temp *= d(i)
            Case "/"
                temp /= d(i)
            Case "%"
                temp = temp Mod d(i)
        End Select
        If i = 1 Or i = 3 Then AnsList.Add(temp)
    End Sub
#End Region
    Sub buttonToAns()
        Dim randNum As List(Of Integer) = {1, 2, 3, 4}.ToList
        Dim num As Integer = 0
        AnsList = AnsList.Distinct.ToList
        If AnsList.Count < 4 Then Caseto() : Return
        Dim ansNum As Integer = AnsList.Count
        Dim overflowBool As Byte = 0
        While num < 4
            If num >= ansNum Then Exit While
            Dim index As Integer = Int(Rnd() * AnsList.Count)
            Dim rand As Integer = Int(Rnd() * randNum.Count)
            If overflowBool = 0 And num > 1 Then
                If Int(Rnd() * 4) = 0 Then
                    overflowBool = 1
                End If
            End If
            If ans = "" Then ans = AnsList.Last
            If num = 0 Then index = AnsList.IndexOf(Val(ans)) : index = If(index = -1, AnsList.Count - 1, index) : bool(randNum(rand)) = True
            Select Case randNum(rand)
                Case 1
                    If chooseButton1.Text = "" Then
                        chooseButton1.Text = If((ans = "無窮迴圈" And overflowBool <= 1) Or overflowBool = 1, "無窮迴圈", AnsList(index))
                        num += 1 : overflowBool = 2
                        chooseButton1.Enabled = True
                        AnsList.RemoveAt(index)
                        randNum.RemoveAt(rand)
                    End If
                Case 2
                    If chooseButton2.Text = "" Then
                        chooseButton2.Text = If((ans = "無窮迴圈" And overflowBool <= 1) Or overflowBool = 1, "無窮迴圈", AnsList(index))
                        num += 1 : overflowBool = 2
                        chooseButton2.Enabled = True
                        AnsList.RemoveAt(index)
                        randNum.RemoveAt(rand)
                    End If
                Case 3
                    If chooseButton3.Text = "" Then
                        chooseButton3.Text = If((ans = "無窮迴圈" And overflowBool <= 1) Or overflowBool = 1, "無窮迴圈", AnsList(index))
                        num += 1 : overflowBool = 2
                        chooseButton3.Enabled = True
                        AnsList.RemoveAt(index)
                        randNum.RemoveAt(rand)
                    End If
                Case 4
                    If chooseButton4.Text = "" Then
                        chooseButton4.Text = If((ans = "無窮迴圈" And overflowBool <= 1) Or overflowBool = 1, "無窮迴圈", AnsList(index))
                        num += 1 : overflowBool = 2
                        chooseButton4.Enabled = True
                        AnsList.RemoveAt(index)
                        randNum.RemoveAt(rand)
                    End If
            End Select

        End While
    End Sub
    Sub Caseto()
        Dim rand As Integer = Int(Rnd() * 13 + 1)
        'rand = 13
        Array.Clear(topicTypeRecord, 0, topicTypeRecord.Count)
        topicTypeRecord(rand) = True
        Select Case rand
            Case 1 : caseFor1()
            Case 2 : caseFor2()
            Case 3 : caseFor3()
            Case 4 : caseFor_If()
            Case 5 : caseFor_If_Else()
            Case 6 : caseIf()
            Case 7 : caseIf_Else()
            Case 8 : caseIf_ElseIf()
            Case 9 : caseIf_If_Else()
            Case 10 : caseSelect()
            Case 11 : caseWhileA()
            Case 12 : caseWhileIf()
            Case 13 : caseWhileIfElse()
            Case Else : Caseto() : Return
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
    Private Sub form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("確定關閉視窗?", "警告", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            e.Cancel = True
        Else
            If record.Sum > 0 Then
                Dim URL As New Uri("網址")
                Dim web As New System.Net.WebClient()
                web.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
                Dim d As Byte() = System.Text.Encoding.ASCII.GetBytes("total=" & record.Sum & "&correct=" & record(1) & "&error=" & record(2))
                Dim res As Byte() = web.UploadData(URL, "POST", d)
            End If
        End If
    End Sub
End Class