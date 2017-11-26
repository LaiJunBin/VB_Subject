Public Class Form1
    Class Tree
        Public data As Integer
        Public child As New List(Of Tree)
        Public parent As Tree
        Public subTree As New List(Of Integer)
        Sub New()
            parent = Nothing
        End Sub
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        Dim parent, child As New List(Of Integer)
        For w = 1 To m
            Dim data() As Integer = LineInput(1).Split(",").Select(Function(x) CInt(x)).ToArray
            parent.Add(data(0)) : child.Add(data(1))
        Next
        Dim root As Integer = parent.Find(Function(x) child.Contains(x) = False)
        Dim Tree As New Tree With {.data = root}
        For i = 0 To parent.Count - 1
            createTree(Tree, child(i), parent(i))
        Next
        Dim result As String = ""
        traversal(Tree, result)
        PrintLine(2, Strings.Left(result, result.Length - 1))
        FileClose()
        Close()
    End Sub
    Sub createTree(ByVal Tree As Tree, ByVal data As Integer, ByVal parent As Integer)
        Dim node As New Tree With {.data = data, .parent = Tree}
        If Tree.data = parent Then Tree.child.Add(node) : Tree.subTree.Add(data) : Return
        Dim index As Integer = Tree.child.FindIndex(Function(x) x.data = parent OrElse x.subTree.Contains(parent))
        createTree(Tree.child(index), data, parent)
        Tree.subTree.Add(data)
    End Sub
    Sub traversal(ByVal Tree As Tree, ByRef result As String)
        If Tree Is Nothing Then Return
        result &= Tree.data & ","
        For Each node In Tree.child
            traversal(node, result)
        Next
    End Sub
End Class