Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim data() As String = LineInput(1).Split
            Dim Graph As New Dictionary(Of Integer, List(Of Integer))
            Dim record As New List(Of Integer)
            For Each item In data
                Dim edge() As Integer = item.Split(",").Select(Function(X) CInt(X)).ToArray
                If Graph.ContainsKey(edge.First) = False Then Graph.Add(edge.First, New List(Of Integer))
                If Graph.ContainsKey(edge.Last) = False Then Graph.Add(edge.Last, New List(Of Integer))
                Graph(edge.First).Add(edge.Last) : Graph(edge.Last).Add(edge.First)
            Next
            traversal(Graph, Graph.First.Key, New List(Of Integer), record, New Stack)
            record = record.Distinct.ToList
            record.Sort()
            PrintLine(2, Strings.Join(record.Select(Function(X) X.ToString).ToArray, ","))
        Next
        FileClose()
        Close()
    End Sub
    Sub traversal(ByVal Graph As Dictionary(Of Integer, List(Of Integer)), ByVal current As Integer, ByVal alreadyNode As List(Of Integer), ByRef record As List(Of Integer), ByVal stack As Stack, Optional ByVal bool As Boolean = False)
        alreadyNode.Add(current)
        For i = 0 To Graph(current).Count - 1
            If alreadyNode.Contains(Graph(current)(i)) AndAlso Graph(current)(i) <> alreadyNode(alreadyNode.Count - 2) Then
                For j = alreadyNode.Count - 1 To 0 Step -1
                    record.Add(alreadyNode(j))
                    If alreadyNode(j) = Graph(current)(i) Then Exit For
                Next
            End If
            If alreadyNode.Contains(Graph(current)(i)) = False Then stack.Push(Graph(current)(i)) : bool = True
        Next
        If Not bool Then Return
        While stack.Count > 0
            Dim node As Integer = stack.Pop
            traversal(Graph, node, alreadyNode, record, stack)
            alreadyNode.Remove(node)
        End While
    End Sub
End Class