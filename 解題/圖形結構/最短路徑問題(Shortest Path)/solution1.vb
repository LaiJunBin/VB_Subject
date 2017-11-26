Public Class Form1
    Const limit As Integer = 1000000000.0
    Class node
        Public ToNode, Cost As Integer
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim data() As Integer = LineInput(1).Split.Select(Function(X) CInt(X)).ToArray
        Dim targetNode As Integer = data.First
        Dim Graph As New Dictionary(Of Integer, List(Of node))
        For i = 1 To data.Last
            Dim edge() As Integer = LineInput(1).Split.Select(Function(x) CInt(x)).ToArray
            If Graph.ContainsKey(edge(0)) = False Then Graph.Add(edge(0), New List(Of node))
            If Graph.ContainsKey(edge(1)) = False Then Graph.Add(edge(1), New List(Of node))
            Graph(edge(0)).Add(New node With {.ToNode = edge(1), .Cost = edge.Last})
            Graph(edge(1)).Add(New node With {.ToNode = edge(0), .Cost = edge.Last})
        Next
        Dim pathCost(targetNode) As Integer
        pathCost = pathCost.Select(Function(x, i) If(i = 1, 0, limit)).ToArray
        Dim pathRecord As New List(Of Integer)
        traversal(Graph, 1, targetNode, pathCost, pathRecord, New List(Of Integer) From {1})
        MsgBox(pathCost(targetNode) & ",path:" & Strings.Join(pathRecord.Select(Function(x) x.ToString).ToArray, ","))
        FileClose()
        Close()
    End Sub
    Sub traversal(ByVal Graph As Dictionary(Of Integer, List(Of node)), ByVal current As Integer, ByVal targetNode As Integer, ByVal pathCost() As Integer, ByRef pathRecord As List(Of Integer), ByVal alreadyNode As List(Of Integer))
        If current = targetNode Then Return
        For Each item In Graph(current)
            If alreadyNode.Contains(item.ToNode) Then Continue For
            If pathCost(item.ToNode) > pathCost(current) + item.Cost Then
                pathCost(item.ToNode) = pathCost(current) + item.Cost
                If item.ToNode = targetNode Then
                    pathRecord = alreadyNode.GetRange(0, alreadyNode.Count)
                    pathRecord.Add(targetNode)
                End If
                traversal(Graph, item.ToNode, targetNode, pathCost, pathRecord, alreadyNode.GetRange(0, alreadyNode.Count).Concat({item.ToNode}).ToList)
            End If
        Next
    End Sub
End Class