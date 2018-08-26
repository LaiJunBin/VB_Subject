Imports System.Text
Public Class IfExpression
    Inherits IExpression
    Public Overrides Sub process(ByRef funcName As String, ByRef funcParams() As String, ByRef source As StringBuilder, ByRef target As String, Optional ByVal useReturn As Boolean = True)
        Dim var As List(Of String) = SampleVariable(rand(2, 4))
        funcName = "ifTest"
        funcParams = var.ToArray
        _process(source, var, maxDepth)
        If useReturn Then
            target = SampleVariable(var)
            source.AppendLine(StrDup(4, " ") & "Return " & target)
        End If
    End Sub

    Public Overrides Sub _process(ByRef source As StringBuilder, ByVal var As List(Of String), ByVal maxDepth As Integer, Optional ByVal depth As Integer = 0, Optional ByVal tabCount As Integer = 1)
        If maxDepth = depth Then Return
        Dim _var As List(Of String) = SampleVariable(var, 2)
        source.AppendLine(StrDup(tabCount * 4, " ") & "If " & CreateCompareExpression(_var.First, _var.Last, var) & " Then")
        source.AppendLine(StrDup((tabCount + 1) * 4, " ") & CreateCalcExpression(var))
        For i = 1 To maxDepth - depth
            If Probability(50) Then
                _process(source, var, maxDepth, depth + 1, tabCount + 1)
            End If
        Next
        source.AppendLine(StrDup(tabCount * 4, " ") & "End If")
    End Sub
End Class