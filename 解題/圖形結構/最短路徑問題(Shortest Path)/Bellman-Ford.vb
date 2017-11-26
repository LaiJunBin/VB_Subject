Public Class Form1
    Public Class node
        Public ToNode, weight As Integer
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim title() As Integer = LineInput(1).Split(",").Select(Function(x) CInt(x)).ToArray
            Dim Graph As New Dictionary(Of Integer, List(Of node))
            For i = 1 To title.First : Graph.Add(i, New List(Of node)) : Next
            For i = 1 To title.Last
                Dim edge() As Integer = LineInput(1).Split(",").Select(Function(x) CInt(x)).ToArray
                Graph(edge.First).Add(New node With {.ToNode = edge(1), .weight = edge.Last})
            Next
            Dim dis(title.First) As Integer
            dis = dis.Select(Function(x, i) If(i = 1, 0, 10000000)).ToArray
            dp(dis, Graph, 1)
            PrintLine(2, Strings.Join(dis.Skip(1).Select(Function(x) x.ToString).ToArray, ","))
        Next
        FileClose()
        Close()
    End Sub

    Sub dp(ByVal dis() As Integer, ByVal Graph As Dictionary(Of Integer, List(Of node)), ByVal current As Integer)
        Dim queue As New Queue
        queue.Enqueue(current)
        While queue.Count > 0
            Dim node As Integer = queue.Dequeue
toNext:
            For Each item In Graph(node)
                Dim temp As Integer = dis(item.ToNode)
                dis(item.ToNode) = Math.Min(dis(item.ToNode), dis(node) + item.weight)
                If dis(item.ToNode) <> temp AndAlso queue.Contains(item.ToNode) = False Then queue.Enqueue(item.ToNode)
                If node = item.ToNode Then Graph(node).Remove(item) : GoTo toNext
            Next
            If queue.Count = 0 Then Return
            dp(dis, Graph, queue.Dequeue)
        End While
    End Sub
End Class