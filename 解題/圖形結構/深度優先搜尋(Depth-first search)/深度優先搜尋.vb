Public Class form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim repNum() As Integer = LineInput(1).Split.Select(Function(X) CInt(X)).ToArray
        Dim Graph As New SortedDictionary(Of Integer, List(Of Integer))
        For i = 1 To repNum.First
            Dim edge() As Integer = LineInput(1).Split.Select(Function(X) CInt(X)).ToArray
            If Graph.ContainsKey(edge.First) = False Then Graph.Add(edge.First, New List(Of Integer))
            If Graph.ContainsKey(edge.Last) = False Then Graph.Add(edge.Last, New List(Of Integer))
            Graph(edge.First).Add(edge.Last) : Graph(edge.Last).Add(edge.First)
        Next
        For i = 1 To repNum.Last
            Dim result As String = ""
            Dim node As Integer = LineInput(1)
            traversal(Graph, node, result, New List(Of Integer))
            PrintLine(2, Strings.Left(result, result.Length - 1))
        Next
        FileClose()
        Close()
    End Sub
    Sub traversal(ByVal Graph As SortedDictionary(Of Integer, List(Of Integer)), ByVal startNode As Integer, ByRef result As String, ByRef List As List(Of Integer))
        If List.Contains(startNode) = False Then List.Add(startNode) : result &= startNode & ","
        For Each node In Graph(startNode)
            If List.Contains(node) = False Then traversal(Graph, node, result, List)
        Next
    End Sub
End Class