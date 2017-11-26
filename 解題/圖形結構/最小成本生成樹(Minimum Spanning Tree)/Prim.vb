Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim data() As String = LineInput(1).Split
            Dim Graph As New SortedDictionary(Of Integer, SortedDictionary(Of Integer, Integer))
            Dim alreadyList As New List(Of Integer) From {1}
            Dim cost As Integer = 0
            For Each item In data
                Dim node() As Integer = item.Split(",").Select(Function(x, i) If(i < 2, CInt(Asc(x) - 64), CInt(x))).ToArray
                If Graph.ContainsKey(node.First) = False Then Graph.Add(node.First, New SortedDictionary(Of Integer, Integer))
                If Graph.ContainsKey(node(1)) = False Then Graph.Add(node(1), New SortedDictionary(Of Integer, Integer))
                Graph(node(0)).Add(node(1), node(2)) : Graph(node(1)).Add(node(0), node(2))
            Next
            Do Until alreadyList.Count = Graph.Count
                Dim edge() As Integer = getMinEdge(Graph, alreadyList)
                alreadyList.Add(edge.First) : cost += edge.Last
            Loop
            PrintLine(2, Trim(cost))
        Next
        FileClose()
        Close()
    End Sub
    Function getMinEdge(ByVal Graph As SortedDictionary(Of Integer, SortedDictionary(Of Integer, Integer)), ByRef alreadyList As List(Of Integer))
        Dim nodeArray() As Integer = {0, 2147483647}
        For Each node In alreadyList
            For Each edge In Graph(node)
                If edge.Value < nodeArray(1) And alreadyList.Contains(edge.Key) = False Then nodeArray(0) = edge.Key : nodeArray(1) = edge.Value
            Next
        Next
        Return nodeArray
    End Function
End Class