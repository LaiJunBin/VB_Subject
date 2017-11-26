Public Class Form1
    Public Class Tree
        Public data As Integer
        Public left, right As Tree
        Sub New()
            left = Nothing
            right = Nothing
        End Sub
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        For q = 1 To 2
            Dim n As Integer = LineInput(q)
            For w = 1 To n
                Dim inorder As List(Of Integer) = LineInput(q).Split(",").Select(Function(X) CInt(X)).ToList
                Dim preorder As List(Of Integer) = LineInput(q).Split(",").Select(Function(X) CInt(X)).ToList
                Dim Tree As Tree = Nothing
                Dim result As String = ""
                createTree(Tree, preorder, inorder)
                traversal(Tree, result)
                PrintLine(3, Strings.Left(result, result.Length - 1))
            Next
            PrintLine(3)
        Next
        FileClose()
        Close()
    End Sub
    Sub createTree(ByRef Tree As Tree, ByVal preorder As List(Of Integer), ByVal inorder As List(Of Integer))
        For i = 0 To preorder.Count - 1
            If inorder.Contains(preorder(i)) = False Then Continue For
            If Tree Is Nothing Then Dim root As New Tree With {.data = preorder(i)} : Tree = root
            Dim x, y As New List(Of Integer)
            For j = 0 To inorder.IndexOf(preorder(i)) - 1
                x.Add(inorder(j))
            Next
            For j = inorder.IndexOf(preorder(i)) + 1 To inorder.Count - 1
                y.Add(inorder(j))
            Next
            If x.Count = 1 Then Dim node As New Tree With {.data = x.First} : Tree.left = node
            If y.Count = 1 Then Dim node As New Tree With {.data = y.First} : Tree.right = node
            If x.Count > 1 Then createTree(Tree.left, preorder, x)
            If y.Count > 1 Then createTree(Tree.right, preorder, y)
            Return
        Next
    End Sub
    Sub traversal(ByVal tree As Tree, ByRef result As String)
        If tree Is Nothing Then Return
        traversal(tree.left, result)
        traversal(tree.right, result)
        result &= tree.data & ","
    End Sub
End Class