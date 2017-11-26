Public Class form1
    Class BST
        Public data As Integer
        Public left As BST
        Public right As BST
        Sub New()
            left = Nothing
            right = Nothing
        End Sub
    End Class
    Private Sub form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim data() As String = "5,2,6,8,9,10,4,3,2,1".Split({","}, StringSplitOptions.RemoveEmptyEntries)
        Dim tree As BST = Nothing
        Label1.Text = ""
        For i = 0 To UBound(data)
            Dim n As Integer = data(i)
            add(n, tree)
        Next
        Dim output As String = ""
        output &= "前序走訪：" & preorder("", tree) & vbNewLine
        output &= "中序走訪：" & inorder("", tree) & vbNewLine
        output &= "後序走訪：" & posorder("", tree)
        MsgBox(output)
        Close()
    End Sub
    Sub add(ByVal n As Integer, ByRef tree As BST)
        Dim node As New BST
        node.data = n
        If tree Is Nothing Then
            tree = node
            Return
        End If
        If n > tree.data Then
            add(n, tree.right)
        Else
            add(n, tree.left)
        End If
    End Sub
    Function preorder(ByRef data As String, ByVal node As BST)
        If node Is Nothing Then Return 0
        If data <> "" Then data &= ","
        data &= node.data
        preorder(data, node.left)
        preorder(data, node.right)
        Return data
    End Function
    Function inorder(ByRef data As String, ByVal node As BST)
        If node Is Nothing Then Return 0
        inorder(data, node.left)
        If data <> "" Then data &= ","
        data &= node.data
        inorder(data, node.right)
        Return data
    End Function
    Function posorder(ByRef data As String, ByVal node As BST)
        If node Is Nothing Then Return 0
        posorder(data, node.left)
        posorder(data, node.right)
        If data <> "" Then data &= ","
        data &= node.data
        Return data
    End Function
End Class