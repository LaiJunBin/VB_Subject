''' <summary>
''' 二元搜尋樹的類別
''' </summary>
''' <typeparam name="T">型別</typeparam>
Public Class BinarySearchTree(Of T)
    Public data As T
    Private Left, Right As BinarySearchTreeNode
    Private Height, NodeCount As Integer
    Private Class BinarySearchTreeNode
        Public data As T
        Public Left, Right As BinarySearchTreeNode
        Sub New()
            Left = Nothing
            Right = Nothing
        End Sub
        Public Overloads Sub BFS_Step(ByVal Tree As BinarySearchTreeNode, ByVal Root As BinarySearchTree(Of T), ByVal Queue As Queue, ByVal path As List(Of T))
            If Not Tree.Left Is Nothing Then Queue.Enqueue(Tree.Left.data)
            If Not Tree.Right Is Nothing Then Queue.Enqueue(Tree.Right.data)
            path.Add(Tree.data)
            If Queue.Count = 0 Then Return
            Dim BinaryFunction As New BinarySearchTree(Of T)
            BFS_Step(BinaryFunction.FindNode(Root, Queue.Dequeue), Root, Queue, path)
        End Sub
        Public Overloads Function FindNode(ByVal Tree As BinarySearchTreeNode, ByVal data As T, Optional ByRef node As BinarySearchTreeNode = Nothing)
            If Tree Is Nothing Then Return node
            If Tree.data.Equals(data) Then node = Tree
            If node Is Nothing Then FindNode(Tree.Left, data, node)
            If node Is Nothing Then FindNode(Tree.Right, data, node)
            Return node
        End Function
    End Class
    ''' <summary>
    ''' 建立二元搜尋樹
    ''' </summary>
    ''' <param name="item">Root的值</param>
    Public Sub New(ByVal item As T)
        data = item
        NodeCount = 1
        Left = Nothing
        Right = Nothing
    End Sub
    Private Sub New()
    End Sub
    ''' <summary>
    ''' 取得樹的高度
    ''' </summary>
    Public Function GetHeight() As Integer
        Return Height
    End Function
    Public Sub CopyTo(ByRef Tree As BinarySearchTree(Of T))
        Tree = Me.MemberwiseClone()
    End Sub
    ''' <summary>
    ''' 取得前序走訪結果。
    ''' </summary>
    Public Function PreOrder() As String
        Dim path As New List(Of T)
        PreOrderStep(Me, path)
        Return Strings.Join(path.Select(Function(x) x.ToString).ToArray, ",")
    End Function
    Private Overloads Sub PreOrderStep(ByVal Tree As BinarySearchTree(Of T), ByRef path As List(Of T))
        If Tree Is Nothing Then Return
        path.Add(Tree.data)
        PreOrderStep(Tree.Left, path)
        PreOrderStep(Tree.Right, path)
    End Sub
    Private Overloads Sub PreOrderStep(ByVal Tree As BinarySearchTreeNode, ByRef path As List(Of T))
        If Tree Is Nothing Then Return
        path.Add(Tree.data)
        PreOrderStep(Tree.Left, path)
        PreOrderStep(Tree.Right, path)
    End Sub
    ''' <summary>
    ''' 取得中序走訪結果。
    ''' </summary>
    Public Function InOrder() As String
        Dim path As New List(Of T)
        InOrderStep(Me, path)
        Return Strings.Join(path.Select(Function(x) x.ToString).ToArray, ",")
    End Function
    Private Overloads Sub InOrderStep(ByVal Tree As BinarySearchTree(Of T), ByRef path As List(Of T))
        If Tree Is Nothing Then Return
        InOrderStep(Tree.Left, path)
        path.Add(Tree.data)
        InOrderStep(Tree.Right, path)
    End Sub
    Private Overloads Sub InOrderStep(ByVal Tree As BinarySearchTreeNode, ByRef path As List(Of T))
        If Tree Is Nothing Then Return
        InOrderStep(Tree.Left, path)
        path.Add(Tree.data)
        InOrderStep(Tree.Right, path)
    End Sub
    ''' <summary>
    ''' 取得後序走訪結果。
    ''' </summary>
    Public Function PostOrder() As String
        Dim path As New List(Of T)
        PostOrderStep(Me, path)
        Return Strings.Join(path.Select(Function(x) x.ToString).ToArray, ",")
    End Function
    Private Overloads Sub PostOrderStep(ByVal Tree As BinarySearchTree(Of T), ByRef path As List(Of T))
        If Tree Is Nothing Then Return
        PostOrderStep(Tree.Left, path)
        PostOrderStep(Tree.Right, path)
        path.Add(Tree.data)
    End Sub
    Private Overloads Sub PostOrderStep(ByVal Tree As BinarySearchTreeNode, ByRef path As List(Of T))
        If Tree Is Nothing Then Return
        PostOrderStep(Tree.Left, path)
        PostOrderStep(Tree.Right, path)
        path.Add(Tree.data)
    End Sub
    ''' <summary>
    ''' 加入節點。
    ''' </summary>
    ''' <param name="item">要加入的資料</param>
    Public Sub Add(ByVal item As T)
        AddNode(item, Me) : NodeCount += 1
    End Sub
    ''' <summary>
    ''' 把集合加入至二元搜尋樹。
    ''' </summary>
    ''' <param name="item">要加入的資料的集合</param>
    Public Sub AddRange(ByVal item As List(Of T))
        For Each node In item
            AddNode(node, Me) : NodeCount += 1
        Next
    End Sub
    Private Overloads Sub AddNode(ByVal item As T, ByRef Tree As BinarySearchTree(Of T), Optional ByVal ht As Integer = 0)
        If Val(item) > Val(Tree.data) Then AddNode(item, Tree.Right, ht + 1) : Return
        AddNode(item, Tree.Left, ht + 1) : Return
    End Sub
    Private Overloads Sub AddNode(ByVal item As T, ByRef Tree As BinarySearchTreeNode, Optional ByVal ht As Integer = 0)
        Dim node As New BinarySearchTreeNode With {.data = item}
        If Tree Is Nothing Then Tree = node : Height = Math.Max(ht, Height) : Return
        If Val(item) > Val(Tree.data) Then AddNode(item, Tree.Right, ht + 1) : Return
        AddNode(item, Tree.Left, ht + 1) : Return
    End Sub
    ''' <summary>
    ''' 取得所有樹葉節點。
    ''' </summary>
    Public Function GetLeaveNode() As String
        Dim path As New List(Of T)
        LeaveStep(Me, path)
        Return Strings.Join(path.Select(Function(x) x.ToString).ToArray, ",")
    End Function
    Private Overloads Sub LeaveStep(ByVal Tree As BinarySearchTree(Of T), ByVal path As List(Of T))
        If Tree Is Nothing Then Return
        If Tree.Left Is Nothing AndAlso Tree.Right Is Nothing Then path.Add(Tree.data) : Return
        LeaveStep(Tree.Left, path) : LeaveStep(Tree.Right, path)
    End Sub
    Private Overloads Sub LeaveStep(ByVal Tree As BinarySearchTreeNode, ByVal path As List(Of T))
        If Tree Is Nothing Then Return
        If Tree.Left Is Nothing AndAlso Tree.Right Is Nothing Then path.Add(Tree.data) : Return
        LeaveStep(Tree.Left, path) : LeaveStep(Tree.Right, path)
    End Sub
    ''' <summary>
    ''' 取得BFS(廣度優先搜尋)走訪結果。
    ''' </summary>
    Public Function GetBFS() As String
        Dim path As New List(Of T)
        Dim Queue As New Queue
        BFS_Step(Me, Queue, path)
        Return Strings.Join(path.Select(Function(x) x.ToString).ToArray, ",")
    End Function
    Private Overloads Sub BFS_Step(ByVal Tree As BinarySearchTree(Of T), ByVal Queue As Queue, ByVal path As List(Of T))
        If Not Tree.Left Is Nothing Then Queue.Enqueue(Tree.Left.data)
        If Not Tree.Right Is Nothing Then Queue.Enqueue(Tree.Right.data)
        path.Add(Tree.data)
        If Queue.Count = 0 Then Return
        Dim binaryFunction As New BinarySearchTreeNode
        binaryFunction.BFS_Step(FindNode(Me, Queue.Dequeue), Me, Queue, path)
    End Sub
    Private Overloads Function FindNode(ByVal Tree As BinarySearchTree(Of T), ByVal data As T, Optional ByRef node As BinarySearchTreeNode = Nothing)
        If Tree.data.Equals(data) Then Return Tree
        Dim binaryFunction As New BinarySearchTreeNode
        If node Is Nothing Then binaryFunction.FindNode(Tree.Left, data, node)
        If node Is Nothing Then binaryFunction.FindNode(Tree.Right, data, node)
        Return node
    End Function
    ''' <summary>
    ''' 前序中序還原二元樹
    ''' </summary>
    ''' <param name="PreOrder">前序的清單</param>
    ''' <param name="InOrder">中序的清單</param>
    ''' <remarks></remarks>
    Public Sub PreOrderInOrderReBuildTree(ByVal PreOrder As List(Of T), ByVal InOrder As List(Of T))
        Dim Tree As BinarySearchTree(Of T) = Nothing
        PreOrderInOrderReBuildTreeStep(PreOrder, InOrder, Tree)
        Me.data = Tree.data : Me.Height = Tree.Height
        Me.Left = Tree.Left : Me.Right = Tree.Right
    End Sub
    Private Overloads Sub PreOrderInOrderReBuildTreeStep(ByVal PreOrder As List(Of T), ByVal InOrder As List(Of T), ByRef Tree As BinarySearchTree(Of T))
        For Each node In PreOrder
            If InOrder.Contains(node) Then
                If Tree Is Nothing Then Tree = New BinarySearchTree(Of T)(node)
                Dim x, y As New List(Of T)
                For i = 0 To InOrder.IndexOf(node) - 1
                    x.Add(InOrder(i))
                Next
                For i = InOrder.IndexOf(node) + 1 To InOrder.Count - 1
                    y.Add(InOrder(i))
                Next
                If x.Count = 1 Then Tree.Left = New BinarySearchTreeNode With {.data = x.First}
                If y.Count = 1 Then Tree.Right = New BinarySearchTreeNode With {.data = y.First}
                If x.Count > 1 Then PreOrderInOrderReBuildTreeStep(PreOrder, x, Tree.Left)
                If y.Count > 1 Then PreOrderInOrderReBuildTreeStep(PreOrder, y, Tree.Right)
                Return
            End If
        Next
    End Sub
    Private Overloads Sub PreOrderInOrderReBuildTreeStep(ByVal PreOrder As List(Of T), ByVal InOrder As List(Of T), ByRef Tree As BinarySearchTreeNode)
        For Each node In PreOrder
            If InOrder.Contains(node) Then
                If Tree Is Nothing Then Tree = New BinarySearchTreeNode With {.data = node}
                Dim x, y As New List(Of T)
                For i = 0 To InOrder.IndexOf(node) - 1
                    x.Add(InOrder(i))
                Next
                For i = InOrder.IndexOf(node) + 1 To InOrder.Count - 1
                    y.Add(InOrder(i))
                Next
                If x.Count = 1 Then Tree.Left = New BinarySearchTreeNode With {.data = x.First}
                If y.Count = 1 Then Tree.Right = New BinarySearchTreeNode With {.data = y.First}
                If x.Count > 1 Then PreOrderInOrderReBuildTreeStep(PreOrder, x, Tree.Left)
                If y.Count > 1 Then PreOrderInOrderReBuildTreeStep(PreOrder, y, Tree.Right)
                Return
            End If
        Next
    End Sub
    ''' <summary>
    ''' 判斷是否為嚴格二元樹(所有節點都有0或2個子節點)
    ''' </summary>
    Public Function IsStrictly() As Boolean
        Return IsStrictlyStep(Me)
    End Function
    Private Overloads Function IsStrictlyStep(ByVal Tree As BinarySearchTree(Of T), Optional ByRef bool As Boolean = True)
        If Tree Is Nothing Then Return bool
        If Tree.Left Is Nothing AndAlso Not Tree.Right Is Nothing Then bool = False : Return bool
        If Not Tree.Left Is Nothing AndAlso Tree.Right Is Nothing Then bool = False : Return bool
        If bool Then IsStrictlyStep(Tree.Left, bool)
        If bool Then IsStrictlyStep(Tree.Right, bool)
        Return bool
    End Function
    Private Overloads Function IsStrictlyStep(ByVal Tree As BinarySearchTreeNode, Optional ByRef bool As Boolean = True)
        If Tree Is Nothing Then Return bool
        If Tree.Left Is Nothing AndAlso Not Tree.Right Is Nothing Then bool = False : Return bool
        If Not Tree.Left Is Nothing AndAlso Tree.Right Is Nothing Then bool = False : Return bool
        If bool Then IsStrictlyStep(Tree.Left, bool)
        If bool Then IsStrictlyStep(Tree.Right, bool)
        Return bool
    End Function
    ''' <summary>
    ''' 判斷是否為完整二元樹(所有樹葉節點都在同一層)
    ''' </summary>
    Public Function IsComplete() As Boolean
        Return 2 ^ Height - 1 < NodeCount And NodeCount < 2 ^ (Height + 1) - 1
    End Function
    ''' <summary>
    ''' 判斷是否為完滿二元樹
    ''' </summary>
    Public Function IsFull() As Boolean
        Return NodeCount = 2 ^ (Height + 1) - 1
    End Function
    ''' <summary>
    ''' 判斷是否為歪斜二元樹(所有節點都在同一側)
    ''' </summary>
    Public Function IsSkewed() As Boolean
        Return NodeCount = Height + 1
    End Function
    ''' <summary>
    ''' 在二元搜尋樹中刪除一個資料
    ''' </summary>
    ''' <param name="item">要刪除的資料</param>
    Public Sub Remove(ByVal item As T)
        '刪除節點 待補
    End Sub
End Class