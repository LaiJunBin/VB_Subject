Public Class form1
    Public Class BST
        Public data, ht As Integer
        Public Left, Right As BST
        Sub New()
            Left = Nothing : Right = Nothing
        End Sub
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim n As Integer = LineInput(1)
        For w = 1 To n
            Dim Tree As BST = Nothing
            Dim data() As Integer = LineInput(1).Split.Select(Function(x) CInt(x)).ToArray
            Dim bool As Boolean = True
            For Each node In data
                createBinarySearchTree(Tree, node)
            Next
            traversal(Tree, bool)
            PrintLine(2, If(bool, "Y", "N"))
        Next
        FileClose()
        Close()
    End Sub
    Sub createBinarySearchTree(ByRef Tree As BST, ByVal data As Integer, Optional ByVal ht As Integer = 0)
        Dim node As New BST With {.data = data, .ht = ht}
        If Tree Is Nothing Then Tree = node : Return
        If data > Tree.data Then createBinarySearchTree(Tree.Right, data, ht + 1) : Return
        createBinarySearchTree(Tree.Left, data, ht + 1) : Return
    End Sub
    Sub traversal(ByVal tree As BST, ByRef bool As Boolean)
        If tree Is Nothing Then Return
        bool = checkBF(tree)
        If bool = True Then traversal(tree.Left, bool)
        If bool = True Then traversal(tree.Right, bool)
    End Sub
    Function checkBF(ByVal Tree As BST)
        If Math.Abs(findHeight(Tree.Left) - findHeight(Tree.Right)) > 1 Then Return False Else Return True
    End Function
    Function findHeight(ByVal tree As BST, Optional ByVal ht As Integer = 0)
        If tree Is Nothing Then Return ht
        Return Math.Max(findHeight(tree.Left, ht + 1), findHeight(tree.Right, ht + 1))
    End Function
End Class