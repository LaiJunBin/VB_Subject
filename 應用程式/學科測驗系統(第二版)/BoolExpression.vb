Public Class BoolExpression
    Inherits IExpression
    Private maxBoolOpCount As Integer = 5
    Private maxBoolCount As Integer = 4
    Public Overrides Sub _process(ByRef source As System.Text.StringBuilder, ByVal var As System.Collections.Generic.List(Of String), ByVal maxDepth As Integer, Optional ByVal depth As Integer = 0, Optional ByVal tabCount As Integer = 1)

    End Sub

    Public Overrides Sub process(ByRef funcName As String, ByRef funcParams() As String, ByRef source As System.Text.StringBuilder, ByRef target As String, Optional ByVal useReturn As Boolean = True)
        funcName = "BoolTest"
        target = "Bool"
        Dim var As New List(Of String)
        Dim expression As String = "    Dim Bool As Boolean = "
        For i = 1 To rand(1, maxBoolCount)
            Dim currentMaxBoolCount As Integer = rand(1, maxBoolOpCount)
            Dim currentExpression As String = "    Dim Bool" & i & " As Boolean = "
            var.Add("Bool" & i)

            For j = 1 To currentMaxBoolCount
                Dim useParentheses As Boolean = Probability(50)
                If useParentheses Then currentExpression &= "("
                currentExpression &= If(Probability(50), CreateBoolExpression(), CreateCompareExpression(rand(-5, 5), rand(-5, 5)))
                If useParentheses Then currentExpression &= ")"
                If j < currentMaxBoolCount Then
                    currentExpression &= " " & GetRandBoolOperation() & " "
                End If
            Next
            source.AppendLine(currentExpression)
        Next
        For i = 0 To var.Count - 1
            expression &= var(i)
            If i < var.Count - 1 Then
                expression &= " " & GetRandBoolOperation() & " "
            End If
        Next
        source.AppendLine(expression)
        source.AppendLine("    Return Bool")
    End Sub
End Class
