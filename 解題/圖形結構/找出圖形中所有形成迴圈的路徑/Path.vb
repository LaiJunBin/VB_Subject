Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim data() As String = LineInput(1).Split
            Dim Graph As New Dictionary(Of Integer, List(Of Integer))
            For Each item In data
                Dim edge() As Integer = item.Split(",").Select(Function(x) CInt(x)).ToArray
                If Graph.ContainsKey(edge.First) = False Then Graph.Add(edge.First, New List(Of Integer))
                If Graph.ContainsKey(edge.Last) = False Then Graph.Add(edge.Last, New List(Of Integer))
                Graph(edge.First).Add(edge.Last) : Graph(edge.Last).Add(edge.First)
            Next
            Dim EdgeList As New List(Of List(Of Integer))
            traversal(Graph, Graph.First.Key, New List(Of Integer), EdgeList)
            Print(2, Trim(EdgeList.Count) & ": ")
            For Each item In EdgeList
                Print(2, Strings.Join(item.Select(Function(x) x.ToString).ToArray, ",") & "  ")
            Next
            PrintLine(2)
        Next
        FileClose()
        Close()
    End Sub
    Sub traversal(ByVal Graph As Dictionary(Of Integer, List(Of Integer)), ByVal current As Integer, ByVal record As List(Of Integer), ByVal EdgeList As List(Of List(Of Integer)))
        record.Add(current)
        For Each node In Graph(current)
            If record.Count >= 2 AndAlso record(record.Count - 2) <> node AndAlso record.Contains(node) Then
                Dim d As List(Of Integer) = record.GetRange(record.IndexOf(node), record.Count - record.IndexOf(node)).Concat({node}).ToList
                Dim bool As Boolean = EdgeList.All(Function(x) x.Count <> d.Count Or x.Except(d).Count <> 0)
                If bool Then EdgeList.Add(d)
            ElseIf record.Contains(node) = False Then
                traversal(Graph, node, record.GetRange(0, record.Count), EdgeList)
            End If
        Next
    End Sub
End Class