Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim data() As String = LineInput(1).Split(",")
            Dim target As String = LineInput(1)
            Dim parent, child As New List(Of String)
            For Each item In data
                Dim edge() As String = item.Split
                parent.Add(edge.Last) : child.Add(edge.First)
            Next
            Dim root As String = parent.Find(Function(x) child.Contains(x) = False)
            Dim Tree As New Dictionary(Of Integer, List(Of String))
            traversal(parent, child, root, Tree)
            Dim List As List(Of String) = Tree.Where(Function(x) x.Value.Contains(target)).ToList.First.Value
            List.Sort()
            PrintLine(2, Strings.Join(List.ToArray, ","))
        Next
        FileClose()
        Close()
    End Sub
    Sub traversal(ByVal parent As List(Of String), ByVal child As List(Of String), ByVal current As String, ByVal Tree As Dictionary(Of Integer, List(Of String)), Optional ByVal ht As Integer = 0)
        If Tree.ContainsKey(ht) = False Then Tree.Add(ht, New List(Of String))
        Tree(ht).Add(current)
        For i = 0 To parent.Count - 1
            If parent(i) = current Then
                traversal(parent, child, child(i), Tree, ht + 1)
            End If
        Next
    End Sub
End Class