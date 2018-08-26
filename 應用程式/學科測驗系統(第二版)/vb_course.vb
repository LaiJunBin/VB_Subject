Public Class vb_course
    Dim Ans As String
    Dim Expression As New Expression
    Dim Code As String
    Dim UseOneGrid As Boolean = False
    Private Sub vb_course_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Expression.ExpressionNames.AddRange({ _
        "IfExpression", _
        "IfElseExpression", _
        "ForExpression", _
        "BoolExpression", _
        "NumberSystemExpression"
        })
        newProblem()

    End Sub
    Sub newProblem()
        Expression.CreateExpression()
        Try
            Ans = Expression.Run
            Code = Expression.GetSource
            Draw()
        Catch ex As Exception
            newProblem()
            Return
        End Try
    End Sub
    Sub Draw()
        Dim codeSet As List(Of String) = Code.Split({vbNewLine}, StringSplitOptions.RemoveEmptyEntries).ToList
        If codeSet.Count > 90 Then Throw New Exception()
        Dim MaxLine As Integer = 30
        If UseOneGrid Then
            CodeTextBoxA.Width = 900
            CodeTextBoxB.Hide()
            CodeTextBoxC.Hide()
            CodeTextBoxA.Text = Code
        Else
            CodeTextBoxA.Width = 300
            CodeTextBoxB.Show()
            CodeTextBoxC.Show()
            CodeTextBoxA.Text = Strings.Join(codeSet.GetRange(0, Math.Min(MaxLine, codeSet.Count)).ToArray, vbNewLine)
            CodeTextBoxB.Text = If(codeSet.Count > MaxLine, Strings.Join(codeSet.GetRange(MaxLine, Math.Min(MaxLine, codeSet.Count - MaxLine)).ToArray, vbNewLine), "")
            CodeTextBoxC.Text = If(codeSet.Count > MaxLine * 2, Strings.Join(codeSet.GetRange(MaxLine * 2, Math.Min(MaxLine, codeSet.Count - MaxLine * 2)).ToArray, vbNewLine), "")
        End If
        
        CallFuncLabel.Text = Expression.GetCallFunctionExpression
        Me.Text = "答案 = " & Ans
    End Sub

    Private Sub AnsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnsButton.Click
        If AnsTextBox.Text = "" Then
            MsgBox("請輸入答案!")
            Return
        End If
        If Ans = AnsTextBox.Text Then
            MsgBox("正確")
        Else
            MsgBox("錯誤 答案為=> " & Ans)
        End If
        AnsTextBox.Text = ""
        newProblem()
    End Sub

    Private Sub SwitchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SwitchButton.Click
        UseOneGrid = Not UseOneGrid
        Draw()
    End Sub
End Class