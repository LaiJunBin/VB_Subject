Public Class NumberSystemExpression
    Inherits IExpression
    Private maxOpCount As Integer = 5
    Private maxCount As Integer = 4
    Shadows MaxNumber As Integer = 255
    Public Overrides Sub _process(ByRef source As System.Text.StringBuilder, ByVal var As System.Collections.Generic.List(Of String), ByVal maxDepth As Integer, Optional ByVal depth As Integer = 0, Optional ByVal tabCount As Integer = 1)

    End Sub

    Public Overrides Sub process(ByRef funcName As String, ByRef funcParams() As String, ByRef source As System.Text.StringBuilder, ByRef target As String, Optional ByVal useReturn As Boolean = True)
        funcName = "NumberSystemTest"
        target = "Number"

        Dim var As New List(Of String)
        Dim expression As String = "    Dim Number As Integer = "
        For i = 1 To rand(1, maxCount)
            Dim currentMaxCount As Integer = rand(1, maxOpCount)
            Dim currentExpression As String = "    Dim Number" & i & " As Integer = "
            var.Add("Number" & i)

            For j = 1 To currentMaxCount
                If Probability(50) Then
                    currentExpression &= rand(0, MaxNumber)
                Else
                    If Probability(50) Then
                        currentExpression &= "&H"
                        currentExpression &= If(Probability(50), Chr(rand(48, 57)), Chr(rand(65, 70)))
                        currentExpression &= If(Probability(50), Chr(rand(48, 57)), Chr(rand(65, 70)))
                    Else
                        currentExpression &= "&O"
                        currentExpression &= Chr(rand(48, 55))
                        currentExpression &= Chr(rand(48, 55))
                    End If
                End If
                If j < currentMaxCount Then
                    Dim currentBoolOperation As String = GetRandBoolOperation()
                    While currentBoolOperation = "<>" Or currentBoolOperation = "="
                        currentBoolOperation = GetRandBoolOperation()
                    End While
                    currentExpression &= " " & currentBoolOperation & " "
                End If
            Next
            source.AppendLine(currentExpression)
        Next
        For i = 0 To var.Count - 1
            expression &= var(i)
            If i < var.Count - 1 Then
                expression &= " " & SampleVariable({"+", "-", "Mod"}.ToList) & " "
            End If
        Next
        source.AppendLine(expression)
        source.AppendLine("    Return Number")
    End Sub
End Class
