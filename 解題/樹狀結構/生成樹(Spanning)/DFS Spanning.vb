Public Class Form1
    Dim alreadyNode As New List(Of String)
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim firstNode As String = "A"
            alreadyNode.Clear()
            Dim data() As String = LineInput(1).Split
            Dim Graph As New Dictionary(Of String, List(Of String))
            For Each edge In data
                Dim node() As String = edge.Split(",")
                If Graph.ContainsKey(node.First) = False Then Graph.Add(node.First, New List(Of String))
                If Graph.ContainsKey(node.Last) = False Then Graph.Add(node.Last, New List(Of String))
                Graph(node.First).Add(node.Last) : Graph(node.Last).Add(node.First)
            Next
            traversal(Graph, firstNode)
            PrintLine(2, Strings.Join(alreadyNode.ToArray, ","))
        Next
        FileClose()
        Close()
    End Sub
    Sub traversal(ByVal Graph As Dictionary(Of String, List(Of String)), ByVal current As String)
        alreadyNode.Add(current)
        For Each node In Graph(current)
            If alreadyNode.Contains(node) = False Then traversal(Graph, node)
        Next
    End Sub
End Class