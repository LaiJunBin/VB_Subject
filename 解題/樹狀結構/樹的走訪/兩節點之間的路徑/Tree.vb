Public Class form1
    Public Class Tree
        Public data As String
        Public node As New List(Of Tree)
        Public subTree As New List(Of String)
        Public parent As Tree
        Sub New()
            parent = Nothing
        End Sub
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim n() As Integer = LineInput(1).Split({",", " "}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) CInt(x)).ToArray
        Dim Tree As New Tree
        Tree.data = "A" 'A為根節點
        For i = 1 To n(0)
            Dim data() As String = LineInput(1).Split({",", " "}, StringSplitOptions.RemoveEmptyEntries)
            CreateTree(Tree, data(1), data(0))
        Next
        For i = 1 To n(1)
            Dim xy() As String = LineInput(1).Split({",", " "}, StringSplitOptions.RemoveEmptyEntries)
            Dim count As Integer = 0
            traversal(findNode(Tree, Nothing, xy(1)), xy(0), count)
            PrintLine(2, Trim(count))
        Next
        FileClose()
        Close()
    End Sub
    Sub CreateTree(ByRef tree As Tree, ByVal data As String, ByVal root As String)
        Dim node As New Tree
        node.data = data
        node.parent = tree
        If tree.data = root Then tree.node.Add(node) : tree.subTree.Add(data) : Return
        For i = 0 To tree.node.Count - 1
            CreateTree(tree.node(i), data, root)
        Next
        If tree.subTree.Contains(root) Then tree.subTree.Add(data)
    End Sub
    Function findNode(ByVal tree As Tree, ByRef node As Tree, ByVal target As String)
        If tree.data = target Then node = tree : Return node
        For i = 0 To tree.node.Count - 1
            If tree.node(i).subTree.Contains(target) Or tree.node(i).data = target Then findNode(tree.node(i), node, target) : Return node
        Next
        Return node
    End Function
    Sub traversal(ByVal tree As Tree, ByVal target As String, ByRef n As Integer)
        If tree.data = target Then Return
        If tree.subTree.Contains(target) Then
            For i = 0 To tree.node.Count - 1
                If tree.node(i).subTree.Contains(target) Or tree.node(i).data = target Then traversal(tree.node(i), target, n)
            Next
        Else
            traversal(tree.parent, target, n)
        End If
        n += 1
    End Sub
End Class