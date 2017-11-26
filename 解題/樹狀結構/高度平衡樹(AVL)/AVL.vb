Public Class Form1
    Public Class BST
        Public data As string
        Public left As BST
        Public right As BST
        Public BF As Integer
        Public parent As BST
        Sub New()
            left = Nothing
            right = Nothing
            parent = Nothing
        End Sub
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "out.txt", OpenMode.Output)
        Dim data() As String = {"Mary"}
        Dim Tree As New BST
        Dim queue As New Queue
        Tree = Nothing
        For Each value In data
            createBinaryTree(Tree, value, New List(Of Integer), 2, Nothing, Nothing)
        Next
        REM 假設建立好Tree了
        Dim type() As String = {"", "LL", "RR", "LR", "RL"}
        Dim insert_data() As String = {"May", "Mike", "Devin", "Bob", "Jack", "Helen", "Joe", "Ivy", "John", "Peter", "Tom"}
        For Each value In insert_data
            Dim path As New List(Of Integer)  '存路徑判斷LL、RR、LR、RL
            Dim child As New BST              '新增的節點
            Dim bool As Boolean = False       '判斷需不需要調整
            Dim traversal As New List(Of String)
            Dim ans As String = ""
            Dim index As Integer = -1
            createBinaryTree(Tree, value, path, 2, Nothing, child)
            TreeTraversalBFValue(Tree, bool, index, 0)  '走訪看看平衡因子有沒有大於2
            If bool = True Then  '如果失衡
                TreeTraversalBFValue(Tree, False, 0, 0)  '重新設定平衡因子
                TreeTraversal(Tree, traversal)  '取得走訪結果
                For Each key In traversal
                    ans &= key & vbNewLine
                Next
                PrintLine(1, "插入" & value & "後 失衡" & vbNewLine & vbNewLine & ans)
                If adjustType(path, index) = 1 Then adjustAVLTree_LL(Tree, child, False) : GoTo print
                If adjustType(path, index) = 2 Then adjustAVLTree_RR(Tree, child, False) : GoTo print
                If adjustType(path, index) = 3 Then adjustAVLTree_LR(Tree, child, False) : GoTo print
                If adjustType(path, index) = 4 Then adjustAVLTree_RL(Tree, child, False) : GoTo print
print:
                ans = "" : traversal.Clear()
                TreeTraversalBFValue(Tree, False, 0, 0)  '重新設定平衡因子
                TreeTraversal(Tree, traversal)  '取得走訪結果
                For Each key In traversal
                    ans &= key & vbNewLine
                Next
                PrintLine(1, "使用" & type(adjustType(path, index)) & "修正後" & vbNewLine & vbNewLine & ans)
                Continue For
            End If
            TreeTraversalBFValue(Tree, False, 0, 0)  '重新設定平衡因子
            TreeTraversal(Tree, traversal)  '取得走訪結果
            For Each key In traversal
                ans &= key & vbNewLine
            Next
            PrintLine(1, "插入" & value & "後,無需修正" & vbNewLine & vbNewLine & ans)
        Next
        FileClose()
        Close()
    End Sub
    Sub createBinaryTree(ByRef Tree As BST, ByVal data As String, ByRef path As List(Of Integer), ByVal d As Integer, ByVal parent As BST, ByRef child As BST)
        Dim node As New BST
        node.data = data : node.parent = parent
        If Not d = 2 Then path.Add(d)
        If Tree Is Nothing Then Tree = node : child = node : Return
        If data > Tree.data Then createBinaryTree(Tree.right, data, path, 1, Tree, child)
        If data < Tree.data Then createBinaryTree(Tree.left, data, path, 0, Tree, child)
    End Sub
    Function traversalLeftHeight(ByVal Tree As BST, ByVal height As Integer, ByRef bf As Integer)
        If Tree Is Nothing Then bf = Math.Max(bf, height) : Return bf
        traversalLeftHeight(Tree.left, height + 1, bf)
        traversalLeftHeight(Tree.right, height + 1, bf)
        Return bf
    End Function
    Function traversalRightHeight(ByVal Tree As BST, ByVal height As Integer, ByRef bf As Integer)
        If Tree Is Nothing Then bf = Math.Max(bf, height) : Return bf
        traversalRightHeight(Tree.right, height + 1, bf)
        traversalRightHeight(Tree.left, height + 1, bf)
        Return bf
    End Function
    Sub TreeTraversalBFValue(ByRef Tree As BST, ByRef bool As Boolean, ByRef index As Integer, ByVal ht As Integer)
        If Tree Is Nothing Then Return
        Tree.BF = traversalLeftHeight(Tree.left, 0, 0) - traversalRightHeight(Tree.right, 0, 0)
        If Math.Abs(Tree.BF) >= 2 Then bool = True : index = Math.Max(index, ht)
        TreeTraversalBFValue(Tree.left, bool, index, ht + 1)
        TreeTraversalBFValue(Tree.right, bool, index, ht + 1)
    End Sub
    Function adjustType(ByVal path As List(Of Integer), ByVal n As Integer)
        Select Case path(n) & path(n + 1)
            Case "00"
                Return 1
            Case "11"
                Return 2
            Case "01"
                Return 3
            Case "10"
                Return 4
        End Select
        Return 0
    End Function
    Sub adjustAVLTree_LL(ByRef Tree As BST, ByVal child As BST, ByRef bool As Boolean)
        If child Is Nothing Then Return
        Dim data As String = child.data
        If Not Math.Abs(child.BF) >= 2 Then
            If bool = False Then adjustAVLTree_LL(Tree, child.parent, bool)
        End If
        If bool = False Then
            Dim root As BST = child
            Dim temp As BST = child.left.right
            Dim tree_next As BST = child.left
            root.parent = tree_next
            If Not temp Is Nothing Then temp.parent = root
            child = tree_next
            child.right = root
            child.right.left = temp
            merge(Tree, child, data, Nothing)
        End If
        bool = True
    End Sub
    Sub adjustAVLTree_RR(ByRef Tree As BST, ByVal child As BST, ByRef bool As Boolean)
        If child Is Nothing Then Return
        Dim data As String = child.data
        If Not Math.Abs(child.BF) >= 2 Then
            If bool = False Then adjustAVLTree_RR(Tree, child.parent, bool)
        End If
        If bool = False Then
            Dim root As BST = child
            Dim temp As BST = child.right.left
            Dim tree_next As BST = child.right
            root.parent = tree_next
            If Not temp Is Nothing Then temp.parent = root
            child = tree_next : child.parent = Nothing
            child.left = root
            child.left.right = temp
            merge(Tree, child, data, Nothing)
        End If
        bool = True
    End Sub
    Sub adjustAVLTree_LR(ByRef Tree As BST, ByVal child As BST, ByRef bool As Boolean)
        If child Is Nothing Then Return
        Dim data As String = child.data
        If Not Math.Abs(child.BF) >= 2 Then
            If bool = False Then adjustAVLTree_LR(Tree, child.parent, bool)
        End If
        If bool = False Then
            Dim root As BST = child
            Dim temp As BST = child.left.right
            Dim tree_next As BST = child.left
            root.parent = temp
            root.left = If(tree_next.right.right Is Nothing, Nothing, tree_next.right.right)
            If Not root.left Is Nothing Then root.left.parent = root
            tree_next.right = temp.left
            tree_next.parent = temp
            If Not tree_next.right Is Nothing Then tree_next.right.parent = tree_next
            child = temp : child.parent = Nothing
            child.right = root
            child.left = tree_next
            merge(Tree, child, data, Nothing)
        End If
        bool = True
    End Sub
    Sub adjustAVLTree_RL(ByRef Tree As BST, ByVal child As BST, ByRef bool As Boolean)
        If child Is Nothing Then Return
        Dim data As String = child.data
        If Not Math.Abs(child.BF) >= 2 Then
            If bool = False Then adjustAVLTree_RL(Tree, child.parent, bool)
        End If
        If bool = False Then
            Dim root As BST = child
            Dim temp As New BST
            Dim tree_next As New BST
            If Not child.right Is Nothing Then tree_next = child.right
            If Not child.right Is Nothing Then If Not child.right.left Is Nothing Then temp = child.right.left
            temp.parent = Nothing
            root.right = temp.left
            If Not root.right Is Nothing Then root.right.parent = root
            tree_next.left = If(temp.right Is Nothing, Nothing, temp.right)
            tree_next.parent = temp
            root.parent = temp
            child = temp : child.parent = Nothing
            child.left = root
            child.right = tree_next
            merge(Tree, child, data, Nothing)
        End If
        bool = True
    End Sub
    Sub merge(ByRef Tree As BST, ByVal child As BST, ByVal data As String, ByVal root As BST)
        If Tree Is Nothing Then Return
        If Tree.data = data And Math.Abs(Tree.BF) >= 2 Then
            Tree = child
            Tree.parent = root
            Return
        End If
        merge(Tree.left, child, data, Tree)
        merge(Tree.right, child, data, Tree)
    End Sub
    Sub TreeTraversal(ByVal Tree As BST, ByRef traversal As List(Of String))
        If Tree Is Nothing Then Return
        traversal.Add("節點" & Tree.data & If(Tree.parent Is Nothing, "是根節點", "的父節點為:" & Tree.parent.data) & ",平衡因子為" & Tree.BF)
        TreeTraversal(Tree.left, traversal)
        TreeTraversal(Tree.right, traversal)
    End Sub
End Class