Public Class IfElseExpression
    Inherits IExpression
    Shadows maxDepth As Integer = 2
    Private ifExpression As New IfExpression
    Public Overrides Sub _process(ByRef source As System.Text.StringBuilder, ByVal var As System.Collections.Generic.List(Of String), ByVal maxDepth As Integer, Optional ByVal depth As Integer = 0, Optional ByVal tabCount As Integer = 1)
        If maxDepth = depth Then Return
        Dim _var As List(Of String) = SampleVariable(var, 2)
        source.AppendLine(StrDup(tabCount * 4, " ") & "If " & CreateCompareExpression(_var.First, _var.Last, var) & " Then")
        source.AppendLine(StrDup((tabCount + 1) * 4, " ") & CreateCalcExpression(var))
        For i = 0 To maxDepth - depth
            If Probability(50) Then
                ifExpression._process(source, var, 1, depth + 1, tabCount + 1)
            End If
            If Probability(50) Then
                _process(source, var, maxDepth, depth + 1, tabCount + 1)
            End If
        Next
        source.AppendLine(StrDup(tabCount * 4, " ") & "Else")
        source.AppendLine(StrDup((tabCount + 1) * 4, " ") & CreateCalcExpression(var))
        source.AppendLine(StrDup(tabCount * 4, " ") & "End If")
    End Sub

    Public Overrides Sub process(ByRef funcName As String, ByRef funcParams() As String, ByRef source As System.Text.StringBuilder, ByRef target As String, Optional ByVal useReturn As Boolean = True)
        Dim var As List(Of String) = SampleVariable(rand(2, 4))
        funcName = "ifElseTest"
        funcParams = var.ToArray
        _process(source, var, maxDepth)
        If useReturn Then
            target = SampleVariable(var)
            source.AppendLine(StrDup(4, " ") & "Return " & target)
        End If
    End Sub
End Class
