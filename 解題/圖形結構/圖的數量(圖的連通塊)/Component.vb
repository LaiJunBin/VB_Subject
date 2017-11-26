Public Class form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim n As Integer = LineInput(1)
        Dim graph(n, n), count As Integer : count = 0
        Dim list As New List(Of Integer)
        For i = 1 To n : list.Add(i) : Next
        Do Until EOF(1)
            Dim data() As Integer = LineInput(1).Split({",", " "}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) CInt(x)).ToArray
            graph(data(0), data(1)) = 1 : graph(data(1), data(0)) = 1
        Loop
        While list.Count > 0
            dfs(graph, list, list.First)
            count += 1
        End While
        PrintLine(2, Trim(count))
        FileClose()
        Close()
    End Sub
    Sub dfs(ByVal graph(,) As Integer, ByRef list As List(Of Integer), ByVal current As Integer)
        list.Remove(current)
        Dim queue As New Queue
        For i = 1 To UBound(graph)
            If graph(current, i) = 1 And list.Contains(i) Then queue.Enqueue(i)
        Next
        While queue.Count > 0
            dfs(graph, list, queue.Dequeue)
        End While
    End Sub
End Class