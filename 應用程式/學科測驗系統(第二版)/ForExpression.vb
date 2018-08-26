Public Class ForExpression
    Inherits IExpression
    Private MinForVariable As Integer = -10
    Private MaxForVariable As Integer = 10

    Private MaxStepVariable As Integer = 3

    Private IfExpression As New IfExpression
    Private IfElseExpression As New IfElseExpression
    Public Overrides Sub _process(ByRef source As System.Text.StringBuilder, ByVal var As System.Collections.Generic.List(Of String), ByVal maxDepth As Integer, Optional ByVal depth As Integer = 0, Optional ByVal tabCount As Integer = 1)
        If maxDepth = depth Then Return
        Dim a As Integer = rand(MinForVariable, MaxForVariable)
        Dim b As Integer = rand(MinForVariable, MaxForVariable)
        source.AppendLine(StrDup(tabCount * 4, " ") & "For " & Chr(105 + depth) & " As Integer = " & a & " To " & b & " Step " & If(b > a, rand(1, MaxStepVariable), rand(-MaxStepVariable, -1)))
        If Probability(70) Then
            source.AppendLine(StrDup((tabCount + 1) * 4, " ") & CreateCalcExpression(var))
        End If
        If Probability(50) Then
            IfExpression._process(source, var, maxDepth, depth + 1, tabCount + 1)
        ElseIf Probability(50) Then
            IfElseExpression._process(source, var, maxDepth, depth + 1, tabCount + 1)
        End If
        If Probability(50) Then
            _process(source, var, maxDepth, depth + 1, tabCount + 1)
        Else
            source.AppendLine(StrDup((tabCount + 1) * 4, " ") & CreateCalcExpression(var))
        End If
        source.AppendLine(StrDup(tabCount * 4, " ") & "Next")
    End Sub
    Public Overrides Sub process(ByRef funcName As String, ByRef funcParams() As String, ByRef source As System.Text.StringBuilder, ByRef target As String, Optional ByVal useReturn As Boolean = True)
        Dim var As List(Of String) = SampleVariable(rand(2, 4))
        funcName = "ForTest"
        funcParams = var.ToArray
        _process(source, var, maxDepth)
        If useReturn Then
            target = SampleVariable(var)
            source.AppendLine(StrDup(4, " ") & "Return " & target)
        End If
    End Sub
End Class
