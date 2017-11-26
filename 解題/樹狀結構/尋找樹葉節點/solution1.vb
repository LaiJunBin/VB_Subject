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
        Dim terminal As New SortedSet(Of String)
        Tree.data = "A" 'A為根節點
        For i = 1 To n(0)
            Dim data() As String = LineInput(1).Split({",", " "}, StringSplitOptions.RemoveEmptyEntries)
            CreateTree(Tree, data(1), data(0))
        Next
        findTerminal(Tree, terminal)
        For Each value In terminal
            Print(2, value & If(terminal.Last = value, "", ","))
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
    Sub findTerminal(ByVal tree As Tree, ByRef terminal As SortedSet(Of String))
        If tree.node.Count = 0 Then terminal.Add(tree.data) : Return
        For i = 0 To tree.node.Count - 1
            findTerminal(tree.node(i), terminal)
        Next
    End Sub
End Class