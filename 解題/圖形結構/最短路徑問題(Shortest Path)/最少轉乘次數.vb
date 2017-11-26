Public Class Form1
    Const limit As Integer = 1000000000
    Class node
        Public NextNode, weight, color As Integer
    End Class
    Class path
        Public path As New List(Of String)
        Public weight, count As Integer
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim title() As Integer = LineInput(1).Split.Select(Function(X) CInt(X)).ToArray
        Dim nodeList As New List(Of Integer)
        For i = 1 To title(1) : nodeList.Add(i) : Next
        Dim Graph As New Dictionary(Of Integer, List(Of node))
        Dim firstNode, targetNode, firstColor As Integer
        Dim nodeCostArray(title(1)) As path
        firstNode = title(2)
        targetNode = title(3)
        nodeCostArray = nodeCostArray.Select(Function(x, i) New path With {.weight = If(i = firstNode, 0, limit), .count = If(i = firstNode, 1, limit)}).ToArray
        nodeCostArray(firstNode).path.Add(firstNode)
        For i = 1 To title(0)
            Dim edge() As Integer = LineInput(1).Split(",").Select(Function(X) CInt(X)).ToArray
            If Graph.ContainsKey(edge.First) = False Then Graph.Add(edge.First, New List(Of node))
            If Graph.ContainsKey(edge(1)) = False Then Graph.Add(edge(1), New List(Of node))
            Graph(edge.First).Add(New node With {.weight = edge(2), .NextNode = edge(1)})
            Graph(edge(1)).Add(New node With {.weight = edge(2), .NextNode = edge(0)})
        Next
        For i = 1 To title.Last
            Dim colorData() As Integer = LineInput(1).Split.Select(Function(X) CInt(X)).ToArray
            For Each colorNode In colorData
                If colorNode = firstNode Then firstColor = i
                For Each item In Graph
                    For Each node In item.Value
                        If node.NextNode = colorNode Then
                            Graph(item.Key)(Graph(item.Key).FindIndex(Function(x) x.NextNode = colorNode)).color = i
                        End If
                    Next
                Next
            Next
        Next
        traversal(Graph, firstNode, targetNode, nodeList, nodeCostArray, New List(Of String), firstColor)
        PrintLine(2, "targetNode=" & Trim(targetNode) & ",path=" & Strings.Join(nodeCostArray(targetNode).path.ToArray, ",") & ",weight=" & Trim(nodeCostArray(targetNode).weight) & ",count=" & Trim(nodeCostArray(targetNode).count))
        FileClose()
        Close()
    End Sub
    Sub traversal(ByVal Graph As Dictionary(Of Integer, List(Of node)), ByVal current As Integer, ByVal targetNode As Integer, ByVal nodeList As List(Of Integer), ByVal nodeCostArray() As path, ByVal record As List(Of String), ByVal color As Integer)
        nodeList.Remove(current)
        record.Add(current)
        For Each item In Graph(current)
            If nodeList.Contains(item.NextNode) Then
                If item.color = color Then
                    If nodeCostArray(current).count < nodeCostArray(item.NextNode).count Then
                        nodeCostArray(item.NextNode).weight = nodeCostArray(current).weight + item.weight
                        nodeCostArray(item.NextNode).path = record.GetRange(0, record.Count).Concat({item.NextNode}).ToList
                        nodeCostArray(item.NextNode).count = nodeCostArray(current).count
                    ElseIf nodeCostArray(current).count = nodeCostArray(item.NextNode).count AndAlso nodeCostArray(current).weight + item.weight < nodeCostArray(item.NextNode).weight Then
                        nodeCostArray(item.NextNode).weight = nodeCostArray(current).weight + item.weight
                        nodeCostArray(item.NextNode).path = record.GetRange(0, record.Count).Concat({item.NextNode}).ToList
                        nodeCostArray(item.NextNode).count = nodeCostArray(current).count
                    End If
                    traversal(Graph, item.NextNode, targetNode, nodeList.GetRange(0, nodeList.Count), nodeCostArray, record.GetRange(0, record.Count), item.color)
                Else
                    If nodeCostArray(current).count + 1 < nodeCostArray(item.NextNode).count Then
                        nodeCostArray(item.NextNode).weight = nodeCostArray(current).weight + item.weight
                        nodeCostArray(item.NextNode).path = record.GetRange(0, record.Count).Concat({item.NextNode}).ToList
                        nodeCostArray(item.NextNode).count = nodeCostArray(current).count + 1
                    ElseIf nodeCostArray(current).count + 1 = nodeCostArray(item.NextNode).count AndAlso nodeCostArray(current).weight + item.weight < nodeCostArray(item.NextNode).weight Then
                        nodeCostArray(item.NextNode).weight = nodeCostArray(current).weight + item.weight
                        nodeCostArray(item.NextNode).path = record.GetRange(0, record.Count).Concat({item.NextNode}).ToList
                        nodeCostArray(item.NextNode).count = nodeCostArray(current).count + 1
                    End If
                    traversal(Graph, item.NextNode, targetNode, nodeList.GetRange(0, nodeList.Count), nodeCostArray, record.GetRange(0, record.Count), item.color)
                End If
            End If
        Next
    End Sub
End Class