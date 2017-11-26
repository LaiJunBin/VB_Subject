Public Class Form1
    Class Tree
        Public data As Integer
        Public Left, Right As Tree
        Sub New()
            Left = Nothing : Right = Nothing
        End Sub
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim n As Integer = LineInput(1)
            Dim Tree As Tree = Nothing
            Dim data() As Integer = LineInput(1).Split.Select(Function(x) CInt(x)).ToArray
            For Each node In data
                createTree(node, Tree)
            Next
            For i = 1 To n
                Dim target As Integer = LineInput(1)
                Dim ht As Integer = findNode(target, Tree)
                PrintLine(2, Trim(ht))
            Next
            PrintLine(2)
        Next
        FileClose()
        Close()
    End Sub
    Sub createTree(ByVal data As Integer, ByRef Tree As Tree)
        Dim node As New Tree With {.data = data}
        If Tree Is Nothing Then Tree = node : Return
        If data > Tree.data Then createTree(data, Tree.Right)
        If data < Tree.data Then createTree(data, Tree.Left)
    End Sub
    Function findNode(ByVal data As Integer, ByVal Tree As Tree, Optional ByRef ht As Integer = 0)
        If Tree Is Nothing Then Return -1
        If Tree.data = data Then Return ht
        Return findNode(data, If(data > Tree.data, Tree.Right, Tree.Left), ht + 1)
    End Function
End Class
