Public Class BinarySearchTree
    Dim Standard As New List(Of Integer) From {0}
    Dim spaceNumber As Integer = 18
    Public Class BinarySearchTree
        Public data As Integer '存資料
        Public Left As BinarySearchTree '左邊的節點
        Public Right As BinarySearchTree '右邊的節點
        Public propety As New SortedDictionary(Of String, Integer) From {{"Height", 0}, {"parent", -1}, {"direction", 0}, {"Left", 0}} '存一些屬性(可依需求增加)
        Sub New() '當這個類別被new出來執行的程序
            Left = Nothing '一開始先設左右節點為nothing
            Right = Nothing
        End Sub
    End Class
    Private Sub moreBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moreBtn.Click
        MsgBox("輸入以,分隔，最高高度為4。最大節點值為99")
    End Sub
    Private Sub createBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles createBtn.Click
        If checkError() Then Exit Sub '檢查輸入格式
        Dim data() As Integer = nodeTextBox.Text.Split({","}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) CInt(x)).ToArray '將資料分割並轉型成整數陣列存進data()
        Dim BinaryTree As BinarySearchTree = Nothing '先設BinaryTree 為 BinarySearchTree 且為空
        Dim MaxHeight As Integer = 1    '先假設樹高為1
        For Each node As Integer In data '讀取data()中的每一個元素
            createBinarySearchTree(BinaryTree, node, MaxHeight, 1) '呼叫createBinarySearchTree建樹
        Next
        If MaxHeight > 4 Then MsgBox("樹高超過4，請重新輸入資料") : Exit Sub
        spaceNumber = 18 * MaxHeight
        Standard = New List(Of Integer) From {0}
        updateStandard(MaxHeight)
        Dim btnList As New List(Of Button)
        Dim labelList As New List(Of Label)
        Traversal(BinaryTree, btnList, labelList, MaxHeight) '呼叫Traversal走訪 (這裡使用前序走訪)
        printControls(btnList, labelList)
    End Sub
    Overloads Sub createBinarySearchTree(ByRef Tree As BinarySearchTree, ByVal data As Integer, ByRef MaxHeight As Integer, ByVal Height As Integer)
        Dim node As New BinarySearchTree With {.data = data} : node.propety("Height") = Height '設node為BinarySearchTree並設定初始值
        If Tree Is Nothing Then Tree = node : MaxHeight = Math.Max(Height, MaxHeight) : Return '如果當前樹為空，則Tree=Node
        If data > Tree.data Then createBinarySearchTree(Tree.Right, data, MaxHeight, Height + 1, Tree.data, 1) : Return '如果不為空，資料小於Tree的資料，則往左邊走
        If data < Tree.data Then createBinarySearchTree(Tree.Left, data, MaxHeight, Height + 1, Tree.data, -1) : Return '否則往右
    End Sub
    Overloads Sub createBinarySearchTree(ByRef Tree As BinarySearchTree, ByVal data As Integer, ByRef MaxHeight As Integer, ByVal Height As Integer, ByVal parent As Integer, ByVal direction As Integer)
        Dim node As New BinarySearchTree With {.data = data}
        node.propety("Height") = Height : node.propety("parent") = parent : node.propety("direction") = direction
        If Tree Is Nothing Then Tree = node : MaxHeight = Math.Max(Height, MaxHeight) : Return
        If data > Tree.data Then createBinarySearchTree(Tree.Right, data, MaxHeight, Height + 1, Tree.data, 1) : Return
        If data < Tree.data Then createBinarySearchTree(Tree.Left, data, MaxHeight, Height + 1, Tree.data, -1) : Return
    End Sub
    Sub Traversal(ByVal Tree As BinarySearchTree, ByRef btnList As List(Of Button), ByRef labelList As List(Of Label), ByVal maxHeight As Integer)
        If Tree Is Nothing Then Return '如果Tree為空，則return
        addControl(Tree, btnList, labelList, maxHeight)
        Traversal(Tree.Left, btnList, labelList, maxHeight) '先往左走
        Traversal(Tree.Right, btnList, labelList, maxHeight) '再往右走
    End Sub
    Sub addControl(ByVal Tree As BinarySearchTree, ByRef btnList As List(Of Button), ByRef labelList As List(Of Label), ByVal maxHeight As Integer)
        Dim parentLeft As Integer = If(Tree.propety("parent") <> -1, btnList.Find(Function(x) x.Text = Tree.propety("parent")).Left, 0)
        btnList.Add(New Button With {.Text = Tree.data, .Width = 30, .Top = (Tree.propety("Height") * 60) + 85,
                                     .Left = If(Tree.propety("Height") = 1, Standard(1), If(Tree.propety("direction") = -1, parentLeft - Standard(Tree.propety("Height")), parentLeft + Standard(Tree.propety("Height"))))})
        If Not Tree.propety("direction") = 0 Then
            labelList.Add(New Label With {.Text = If(Tree.propety("direction") = -1, "/", "\"), .Top = (Tree.propety("Height") * 60) + 55,
                                          .Left = (btnList.Find(Function(x) x.Text = Tree.data).Left + parentLeft + spaceNumber / 3) / 2, .Width = 20})
        End If
    End Sub
    Sub updateStandard(ByVal maxHeight As Integer)
        Standard.Add(maxHeight * spaceNumber)
        For i = 2 To maxHeight : Standard.Add(Math.Abs(Standard(i - 1) - maxHeight * spaceNumber / i)) : Next
    End Sub
    Function checkError()
        Dim inputData As String = nodeTextBox.Text
        Dim filter() As String = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, ","}
        For i = 0 To UBound(filter) : inputData = inputData.Replace(filter(i), "") : Next
        If Not inputData = "" Then
            MsgBox("請檢查輸入的格式是否有誤，詳情請看說明") : Return True
        ElseIf nodeTextBox.Text = "" Then
            MsgBox("請確定有輸入值")
        End If
        Dim data() As Integer = nodeTextBox.Text.Split({","}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) CInt(x)).ToArray
        If Data.Distinct.ToArray.Count <> Data.Count Then
            Dim d As List(Of Integer) = Data.ToList
            Dim tempList As List(Of Integer) = d.Distinct.ToList
            While tempList.Count > 0
                d.Remove(tempList.First) : tempList.RemoveAt(0)
            End While
            Dim repeatNode As String = ""
            For Each item In d
                repeatNode &= item & ","
            Next
            MsgBox("以下這些節點重複" & Strings.Left(repeatNode, repeatNode.Length - 1))
            Return True
        End If
        If data.Max > 99 Then MsgBox("請檢查輸入的格式是否有誤，詳情請看說明") : Return True
        Return False
    End Function
    Sub printControls(ByVal btnList As List(Of Button), ByVal labelList As List(Of Label))
        While Me.Controls.Count > 4
            Me.Controls.RemoveAt(4)
        End While
        For Each item As Button In btnList
            Me.Controls.Add(item)
        Next
        For Each item As Label In labelList
            Me.Controls.Add(item)
        Next
    End Sub
End Class