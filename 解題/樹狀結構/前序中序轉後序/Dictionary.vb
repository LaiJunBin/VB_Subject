Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        For q = 1 To 2
            Dim m As Integer = LineInput(q)
            For w = 1 To m
                Dim inorder As List(Of Integer) = LineInput(q).Split(",").Select(Function(x) CInt(x)).ToList
                Dim preorder As List(Of Integer) = LineInput(q).Split(",").Select(Function(X) CInt(X)).ToList
                Dim Tree As New Dictionary(Of Integer, Integer)
                Dim result As String = ""
                reBuildTree(preorder, inorder, Tree)
                postOrder(Tree, result)
                PrintLine(3, Strings.Left(result, result.Length - 1))
            Next
            PrintLine(3)
        Next
        FileClose()
        Close()
    End Sub
    Sub reBuildTree(ByVal preorder As List(Of Integer), ByVal inorder As List(Of Integer), ByVal Tree As Dictionary(Of Integer, Integer), Optional ByVal index As Integer = 1)
        For Each item In preorder
            If inorder.Contains(item) = True Then
                Tree.Add(index, item)
                Dim x, y As New List(Of Integer)
                For i = 0 To inorder.IndexOf(item) - 1
                    x.Add(inorder(i))
                Next
                For i = inorder.IndexOf(item) + 1 To inorder.Count - 1
                    y.Add(inorder(i))
                Next
                If x.Count = 1 Then Tree.Add(index * 2, x.First)
                If y.Count = 1 Then Tree.Add(index * 2 + 1, y.First)
                If x.Count > 1 Then reBuildTree(preorder, x, Tree, index * 2)
                If y.Count > 1 Then reBuildTree(preorder, y, Tree, index * 2 + 1)
                Return
            End If
        Next
    End Sub
    Sub postOrder(ByVal Tree As Dictionary(Of Integer, Integer), ByRef result As String, Optional ByVal index As Integer = 1)
        If Tree.ContainsKey(index) = False Then Return
        postOrder(Tree, result, index * 2)
        postOrder(Tree, result, index * 2 + 1)
        result &= Tree(index) & ","
    End Sub
End Class