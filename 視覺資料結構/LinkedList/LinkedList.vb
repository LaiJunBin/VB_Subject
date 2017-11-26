Public Class Form1
    Public Class LinkedList '建立類別 LinkedList
        Public data As Integer '節點的資料
        Public index As Integer
        Public _Next As LinkedList '存下一個節點
        Public head As LinkedList '存第一個節點
        Sub New() '被new出來執行的程序
            _Next = Nothing '先設下一節點為空
        End Sub
    End Class
    Public Class TempList
        Public data As Integer
        Public type As Integer
        Public key As Integer
    End Class
    Dim List As LinkedList = Nothing '一開始先設為空
    Dim BtnList As New List(Of Button)
    Dim LabelList As New List(Of Label)
    Dim tempL As New TempList With {.data = 0, .type = 0}
    Dim MaxN As Integer = 12 '最大節點數
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BtnList.Add(New Button With {.Text = "NULL", .Left = 30, .Top = 100, .Width = 50})
        Me.Controls.Add(BtnList.First)
    End Sub
    Private Sub addBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addBtn.Click
        Dim data As String = addTextBox.Text
        If checkError(data) Then Exit Sub
        If Not checkLen() Then Exit Sub
        addItem(data, 1) '新增節點
        List = List.head '新增完後，回到head
        printControls(False, 2147483647, 2147483646, 0, 1)
    End Sub
    Private Sub insertBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles insertBtn.Click
        Dim data As String = InsertTextBox.Text
        If Not checkLen() Then Exit Sub
        If data.Replace(",", "").Length = data.Length - 1 AndAlso IsNumeric(data.Split(",")(1)) Then
            Dim temp() As Integer = data.Split(",").Select(Function(x) CInt(x)).ToArray '將檢查過的資料分割後轉數值型態存入陣列
            tempL.data = temp(1) : tempL.type = 1 : tempL.key = temp(0)
            insertTime.Enabled = True '接續行212
        Else
            MsgBox("請確認輸入格式") : Exit Sub
        End If
    End Sub
    Private Sub deleteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteBtn.Click
        Dim data As String = deleteTextBox.Text
        If checkError(data) Then Exit Sub
        tempL.data = data : tempL.type = 2
        searchTime.Enabled = True '接續行177
    End Sub
    Private Sub searchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchBtn.Click
        Dim data As String = searchTextBox.Text
        If checkError(data) Then Exit Sub
        tempL.data = data : tempL.type = 3
        searchTime.Enabled = True '接續行167
    End Sub
    Overloads Sub addItem(ByVal data As Integer, ByVal index As Integer)
        Dim node As New LinkedList With {.data = data, .index = index, .head = List} '建立一個節點，預設值為data，而head一樣是List
        If List Is Nothing Then List = node : List.head = List : Return '如果List為空，則將head設為自己 並立刻終止程序
        addItem(node, index + 1) '若不是空，則繼續
    End Sub
    Overloads Sub addItem(ByVal node As LinkedList, ByVal index As Integer)
        node.index = index
        If List._Next Is Nothing Then List._Next = node : Return '如果下一個節點為空，讓下一個節點設為node
        List = List._Next ' 把自己設為下一個節點
        addItem(node, index + 1)
    End Sub
    Overloads Sub addBtnList()
        Dim btn As New Button With {.Text = If(List._Next Is Nothing, "NULL", List._Next.data), .Left = If(BtnList.Count = 0, 30, BtnList.Last.Left + 65), .Top = 100, .Width = 50}
        Dim label As New Label With {.Text = List.index, .Top = 80, .Width = 30, .Left = BtnList.Last.Left + 20}
        BtnList.Add(btn) : LabelList.Add(label)
        LabelList.Add(New Label With {.Text = "--->", .Top = 105, .Width = 50, .Left = BtnList.Last.Left - 20})
        If List._Next Is Nothing Then List = List.head : Return
        List = List._Next
        addBtnList()
    End Sub
    Overloads Sub addBtnList(ByVal data As Integer, ByVal target As Integer, ByVal current As Integer)
        Dim btn As New Button With {.Text = If(List._Next Is Nothing, "NULL", List._Next.data), .Left = If(BtnList.Count = 0, 30, BtnList.Last.Left + 65), .Top = 100, .Width = 50}
        If BtnList.FindAll(Function(x) x.BackColor <> btn.BackColor).Count < 1 Then
            If btn.Text <> "NULL" AndAlso data = target AndAlso btn.Text = target AndAlso BtnList.FindAll(Function(x) x.BackColor = Color.Red).Count = 0 Then btn.BackColor = Color.Red _
                 Else If btn.Text <> "NULL" AndAlso btn.Text = data And List._Next.index = current Then btn.BackColor = Color.LightYellow
        End If
        Dim label As New Label With {.Text = List.index, .Top = 80, .Width = 30, .Left = BtnList.Last.Left + 20}
        BtnList.Add(btn) : LabelList.Add(label)
        LabelList.Add(New Label With {.Text = "--->", .Top = 105, .Width = 50, .Left = BtnList.Last.Left - 20})
        If List._Next Is Nothing Then
            List = List.head
            Do While Not List.index = current
                List = List._Next
            Loop
            If Not List._Next Is Nothing Then List = List._Next
            Return
        End If
        List = List._Next
        addBtnList(data, target, current)
    End Sub
    Overloads Sub addBtnList(ByVal data As Integer, ByVal target As Integer, ByVal key As Integer, ByVal current As Integer)
        Dim btn As New Button With {.Text = If(List._Next Is Nothing, "NULL", List._Next.data), .Left = If(BtnList.Count = 0, 30, BtnList.Last.Left + 65), .Top = 100, .Width = 50}
        Dim temp = List.head
        Dim bool As Boolean = False
        While Not temp Is Nothing
            If temp.index > current Then Exit While
            If temp.index = key And temp.data = data Then bool = True
            temp = temp._Next
        End While
        If BtnList.FindAll(Function(x) x.BackColor <> btn.BackColor).Count < 1 Then
            If btn.Text <> "NULL" AndAlso btn.Text = data AndAlso List._Next.index = key Then btn.BackColor = Color.Red _
            Else If btn.Text <> "NULL" AndAlso btn.Text = data AndAlso bool = False AndAlso List._Next.index = current Then btn.BackColor = Color.LightYellow
        End If
        Dim label As New Label With {.Text = List.index, .Top = 80, .Width = 30, .Left = BtnList.Last.Left + 20}
        BtnList.Add(btn) : LabelList.Add(label)
        LabelList.Add(New Label With {.Text = "--->", .Top = 105, .Width = 50, .Left = BtnList.Last.Left - 20})
        If List._Next Is Nothing Then
            List = List.head
            Do While Not List.index = current
                List = List._Next
            Loop
            If Not List._Next Is Nothing Then List = List._Next
            Return
        End If
        List = List._Next
        addBtnList(data, target, key, current)
    End Sub
    Overloads Sub printControls(ByVal bool As Boolean, ByVal data As Integer, ByVal target As Integer, ByVal type As Integer, ByVal current As Integer)
        clearControls() : List = List.head
        BtnList.Add(New Button With {.Text = List.data, .Left = 30, .Top = 100, .Width = 50})
        If BtnList.First.Text = data And List.index = current Then BtnList.First.BackColor = Color.LightYellow
        If List.data = target Then BtnList.First.BackColor = Color.Red
        If bool = False Then addBtnList() Else addBtnList(data, target, current)
        For Each item In BtnList : Me.Controls.Add(item) : Next
        For Each item In LabelList : Me.Controls.Add(item) : Next
        If bool = True AndAlso BtnList.FindAll(Function(x) x.BackColor = Color.Red).Count >= 1 Then
            List = List.head
            Select Case tempL.type
                Case 2
                    searchTime.Enabled = False : actionTime.Enabled = True : Return
                Case 3 : searchTime.Enabled = False : MsgBox("找到" & target)
            End Select
        End If
    End Sub
    Overloads Sub printControls(ByVal bool As Boolean, ByVal data As Integer, ByVal target As Integer, ByVal type As Integer, ByVal key As Integer, ByVal current As Integer)
        clearControls() : List = List.head
        BtnList.Add(New Button With {.Text = List.data, .Left = 30, .Top = 100, .Width = 50})
        If List.index = current Then BtnList.First.BackColor = Color.LightYellow
        If List.index = key Then BtnList.First.BackColor = Color.Red
        addBtnList(data, target, key, current)
        For Each item In BtnList : Me.Controls.Add(item) : Next
        For Each item In LabelList : Me.Controls.Add(item) : Next
        If bool = True AndAlso BtnList.FindAll(Function(x) x.BackColor = Color.Red).Count >= 1 Then
            List = List.head
            insertTime.Enabled = False
            actionTime.Enabled = True
        End If
    End Sub
    Sub clearControls()
        For Each item In BtnList : Me.Controls.Remove(item) : Next
        For Each item In LabelList : Me.Controls.Remove(item) : Next
        BtnList.Clear() : LabelList.Clear()
    End Sub
    Private Sub moreMsgBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moreMsgBtn.Click
        MsgBox("新增--輸入值" & vbNewLine & "插入--索引鍵,插入的值" & vbNewLine & "刪除--輸入值" & vbNewLine & "搜尋--輸入值" & vbNewLine & "且每個節點至多不可輸入超過六位數，節點數不超過12個")
    End Sub
    Function checkError(ByVal data As String)
        If Not IsNumeric(data) Then MsgBox("請確定輸入的是數字") : Return True
        If data.Length > 6 Then MsgBox("最多不可輸入超過六位數") : Return True
        Return False
    End Function
    Private Sub searchTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchTime.Tick
        If Not List Is Nothing Then
            Dim temp = List
            printControls(True, List.data, tempL.data, tempL.type, List.index)
            If searchTime.Enabled = False Then Return
            If Not List Is Nothing AndAlso List.Equals(temp) Then List = List.head : searchTime.Enabled = False : MsgBox("沒有找到" & tempL.data)
        Else
            searchTime.Enabled = False : MsgBox("串列中沒有資料")
        End If
    End Sub
    Overloads Sub deleteNodes(ByVal target As Integer) '若第一個資料就是要被刪除的資料
        If List.data = target Then
            List = List._Next '把自己設為下一個節點
            If Not List Is Nothing Then '如果不為空
                List.index = 1
                adjustList(List, 1) '調整，行202
            ElseIf List Is Nothing Then
                clearControls()
                BtnList.Add(New Button With {.Text = "NULL", .Left = 30, .Top = 100, .Width = 50})
                Me.Controls.Add(BtnList.First)
            End If
        Else
            deleteNodes(target, True) '繼續尋找
        End If
    End Sub
    Overloads Sub deleteNodes(ByVal target As Integer, ByVal bool As Boolean)
        If List._Next.data = target Then '如果下一點的資料就是要刪除的
            List._Next = List._Next._Next '把下一個節點設成下下個節點
            List = List.head              '自己設回head
            adjustList(List, 1)           '調整，行202
            Return
        End If
        List = List._Next  '把自己設為下一個節點
        deleteNodes(target, True)
    End Sub
    Sub adjustList(ByVal head As LinkedList, ByVal index As Integer)
        List.head = head '將每個節點的head設為head
        List.index = index '索引值重新設定
        If Not List._Next Is Nothing Then '如果下一個節點還有值
            List = List._Next '到下一個節點
            adjustList(head, index + 1)
        Else
            List = List.head : Return '否則回到head並終止
        End If
    End Sub
    Overloads Sub insertNode() '若索引為1
        If List.index = tempL.key Then '如果List的索引等於使用者輸入的key
            Dim node As New LinkedList With {.data = tempL.data, .index = 1} '建立節點，data等於使用者輸入的data
            node._Next = List 'node的下一點設為List
            List = node
            List.head = List  '在把head設為自己
            adjustList(List.head, 1) '調整，行202
            Return
        End If
        insertNode(True) '若索引不等於1
    End Sub
    Overloads Sub insertNode(ByVal bool As Boolean)
        If List._Next.index = tempL.key Then '如果下一個節點的索引等於key
            Dim node As New LinkedList With {.data = tempL.data, .head = List.head, ._Next = List._Next} '建立節點，這裡的head可以直接設定為List的head，將node的下一個節點設為List的下一個節點
            List._Next = node '將List的下一個節點覆蓋成node
            List = List.head '回到head
            adjustList(List.head, 1) '調整，行202
            Return
        Else
            List = List._Next '否則到下一個節點
            insertNode(True)
        End If
    End Sub
    Private Sub actionTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionTime.Tick
        actionTime.Enabled = False
        Select Case tempL.type
            Case 2
                deleteNodes(tempL.data)
                MsgBox("刪除" & tempL.data)
            Case 1
                insertNode()
                MsgBox("插入" & tempL.data & "成功")
        End Select
        If Not List Is Nothing Then printControls(False, 0, 1, 0, 1)
    End Sub
    Private Sub insertTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles insertTime.Tick
        If Not List Is Nothing Then
            Dim temp = List
            printControls(True, List.data, tempL.data, tempL.type, tempL.key, List.index)
            If insertTime.Enabled = False Then Return
            If Not List Is Nothing AndAlso List.Equals(temp) Then List = List.head : insertTime.Enabled = False : MsgBox("沒有找到" & tempL.key & "索引鍵")
        Else
            insertTime.Enabled = False : MsgBox("串列中沒有資料")
        End If
    End Sub
    Private Sub SpeedTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeedTrackBar.Scroll
        insertTime.Interval = SpeedTrackBar.Value
        searchTime.Interval = SpeedTrackBar.Value
        actionTime.Interval = SpeedTrackBar.Value / 2
    End Sub
    Function checkLen()
        If Not List Is Nothing Then
            List = List.head
            While Not List._Next Is Nothing
                List = List._Next
            End While
            If List.index >= MaxN Then List = List.head : MsgBox("最多12個節點") : Return False
            List = List.head
        End If
        Return True
    End Function
End Class