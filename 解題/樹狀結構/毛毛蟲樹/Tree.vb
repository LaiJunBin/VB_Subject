Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim data() As String = LineInput(1).Split
            Dim Tree As New Dictionary(Of Integer, List(Of Integer))
            For Each item In data
                Dim edge() As Integer = item.Split(",").Select(Function(x) CInt(x)).ToArray
                If Tree.ContainsKey(edge.First) = False Then Tree.Add(edge.First, New List(Of Integer))
                If Tree.ContainsKey(edge.Last) = False Then Tree.Add(edge.Last, New List(Of Integer))
                Tree(edge.First).Add(edge.Last) : Tree(edge.Last).Add(edge.First)
            Next
            Dim bool As Boolean = True
            Dim alreadyNode As New List(Of Integer)
            For Each node In Tree
                If Not bool Then Exit For
                alreadyNode.Add(node.Key)
                traversal(Tree, node.Key, alreadyNode, bool)
            Next
            PrintLine(2, If(bool, "T", "F"))
        Next
        FileClose()
        Close()
    End Sub
    Sub traversal(ByVal Tree As Dictionary(Of Integer, List(Of Integer)), ByVal current As Integer, ByVal alreadyNode As List(Of Integer), ByRef bool As Boolean, Optional ByVal switch As Boolean = True)
        Dim List As List(Of Integer) = Tree(current).Except(alreadyNode).ToList
        For Each node In List
            If alreadyNode.Contains(node) Then Continue For
            Dim subTree As List(Of Integer) = Tree(node).Except({current}).ToList
            If subTree.Count <> 0 Then
                If switch Then switch = False Else bool = False : Return
            End If
        Next
    End Sub
End Class