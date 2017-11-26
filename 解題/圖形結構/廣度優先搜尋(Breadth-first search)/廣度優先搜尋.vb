Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim title() As Integer = LineInput(1).Split.Select(Function(X) CInt(X)).ToArray
            Dim Graph As New Dictionary(Of Integer, List(Of Integer))
            For i = 1 To title.First
                Dim edge() As Integer = LineInput(1).Split.Select(Function(x) CInt(x)).ToArray
                If Graph.ContainsKey(edge.First) = False Then Graph.Add(edge.First, New List(Of Integer))
                If Graph.ContainsKey(edge.Last) = False Then Graph.Add(edge.Last, New List(Of Integer))
                Graph(edge.First).Add(edge.Last) : Graph(edge.Last).Add(edge.First)
            Next
            For i = 1 To title.Last
                Dim node As Integer = LineInput(1)
                Dim queue As New Queue
                queue.Enqueue(node)
                Dim result As String = ""
                traversal(Graph, queue, result)
                PrintLine(2, Strings.Left(result, result.Length - 1))
            Next
        Next
        FileClose()
        Close()
    End Sub
    Sub traversal(ByVal Graph As Dictionary(Of Integer, List(Of Integer)), ByVal queue As Queue, ByRef result As String)
        Dim node As Integer = queue.Dequeue
        result &= node & ","
        For Each item In Graph(node)
            If result.Contains(item) = False AndAlso queue.Contains(item) = False Then queue.Enqueue(item)
        Next
        While queue.Count > 0
            traversal(Graph, queue, result)
        End While
    End Sub
End Class