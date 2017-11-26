Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim n As Integer = LineInput(1)
            Dim form, _to, cFrom, cTo As New List(Of String)
            Dim weight, cWeight As New List(Of Integer)
            Dim stack As New Stack
            Dim max As Integer = 0
            For i = 1 To n
                Dim edge() As String = LineInput(1).Split(",")
                max = Math.Max(max, Math.Max(Asc(edge(0)) - 64, Asc(edge(1)) - 64))
                form.Add(edge(0)) : _to.Add(edge(1)) : weight.Add(edge(2))
            Next
            Dim ES(max), LS(max) As Integer
            copyList(cFrom, cTo, cWeight, form, _to, weight)
            stack.Push(cFrom.Find(Function(x) cTo.Contains(x) = False))
            f(cFrom, cTo, cWeight, stack, ES, 1)
            LS = LS.Select(Function(X) ES.Last).ToArray
            cFrom = _to : cTo = form : cWeight = weight
            stack.Push(cFrom.FindLast(Function(x) cTo.Contains(x) = False))
            f(cFrom, cTo, cWeight, stack, LS, 2)
            Dim result As String = ES.Last & ","
            For i = 1 To UBound(ES)
                If ES(i) = LS(i) Then result &= Chr(i + 64)
            Next
            PrintLine(2, result)
        Next
        FileClose()
        Close()
    End Sub
    Sub f(ByRef cFrom As List(Of String), ByRef cTo As List(Of String), ByRef cWeight As List(Of Integer), ByRef stack As Stack, ByRef S() As Integer, ByVal type As Integer)
        Dim current As String = stack.Pop
        For i = 0 To cFrom.Count - 1
            If cFrom(i) = current Then
                Dim j, k As Integer
                j = Asc(cFrom(i)) - 64
                k = Asc(cTo(i)) - 64
                S(k) = If(type = 1, Math.Max(S(k), S(j) + cWeight(i)), Math.Min(S(k), S(j) - cWeight(i)))
                cFrom(i) = "" : cTo(i) = "" : cWeight(i) = 0
                If cTo.Contains(Chr(k + 64)) = False Then stack.Push(Chr(k + 64).ToString)
            End If
        Next
        For i = 0 To cFrom.Count - 1
            If cTo.Contains(cFrom(i)) = False AndAlso stack.Contains(cFrom(i)) = False Then stack.Push(cFrom(i))
        Next
        While stack.Count > 0
            f(cFrom, cTo, cWeight, stack, S, type)
        End While
    End Sub
    Sub copyList(ByRef cFrom As List(Of String), ByRef cTo As List(Of String), ByRef cWeight As List(Of Integer), ByVal form As List(Of String), ByVal _to As List(Of String), ByVal weight As List(Of Integer))
        cFrom = form.Select(Function(x) x).ToList
        cTo = _to.Select(Function(X) X).ToList
        cWeight = weight.Select(Function(X) X).ToList
    End Sub
End Class