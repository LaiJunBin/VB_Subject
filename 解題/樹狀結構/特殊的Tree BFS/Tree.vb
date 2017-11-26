Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim n As Integer = LineInput(1)
            Dim parent, child As New List(Of String)
            For i = 1 To n
                Dim edge() As String = LineInput(1).Split(",")
                parent.Add(edge.Last) : child.Add(edge.First)
            Next
            Dim root As String = parent.Find(Function(x) child.Contains(x) = False)
            Dim Tree As New Dictionary(Of Integer, Dictionary(Of String, Queue))
            traversal(parent, child, root, Tree)
            Dim record As New List(Of String)
            For Each node In Tree
                Do Until node.Value.All(Function(x) x.Value.Count = 0)
                    For Each key In node.Value
                        If Tree(node.Key)(key.Key).Count > 0 Then
                            record.Add(key.Value.Dequeue)
                        End If
                    Next
                Loop
            Next
            PrintLine(2, Strings.Join(record.ToArray, ","))
        Next
        FileClose()
        Close()
    End Sub
    Sub traversal(ByVal parent As List(Of String), ByVal child As List(Of String), ByVal current As String, _
                       ByVal Tree As Dictionary(Of Integer, Dictionary(Of String, Queue)), Optional ByVal ht As Integer = 0)
        If Tree.ContainsKey(ht) = False Then Tree.Add(ht, New Dictionary(Of String, Queue))
        Dim index As Integer = child.IndexOf(current)
        Dim parentNode As String = If(index = -1, "root", parent(index))
        If Tree(ht).ContainsKey(parentNode) = False Then Tree(ht).Add(parentNode, New Queue)
        Tree(ht)(parentNode).Enqueue(current)
        For i = 0 To parent.Count - 1
            If parent(i) = current Then traversal(parent, child, child(i), Tree, ht + 1)
        Next
    End Sub
End Class