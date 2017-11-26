Public Class Form1
    Dim maxNum As Integer '設定印出來的最大值，為了輸出格式好看
    Private Sub submitBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submitBtn.Click
        Dim n As String = NTextBox.Text  '設定為使用者輸入的值
        maxNum = 0  '把最大值先設為0
        If Not checkNumber(n) Then MsgBox("請確定輸入格式") : Exit Sub '檢查輸入格式
        Dim Record As New List(Of List(Of Integer)) From {New List(Of Integer)}  '建立一個清單(清單)，並預存一個空紀錄，這樣清單索引可以跟使用者輸入的n對應到。
        Dim formula As String = ""  '用來儲存格式
        Recursive(n, Record)    '呼叫程序 行17
        Record.RemoveAt(0)  '刪除第一個空紀錄
        For i = 1 To maxNum.ToString.Length : formula &= "0" : Next
        printLabel(n, Record, formula) '印出來，行30
    End Sub
    Function checkNumber(ByVal n As String)
        Return IsNumeric(n) AndAlso n <= 15 AndAlso n > 0 '如果是數字且小於15並大於0則回傳true否則false
    End Function
    Sub Recursive(ByVal n As Integer, ByRef Record As List(Of List(Of Integer)))
        Record.Add(New List(Of Integer)) '每次都先建立一個空清單
        If n = 1 Then Record(1).Add(1) : Return '如果n=1則將清單中的第一個項目額外增加1
        Recursive(n - 1, Record) '不斷呼叫自己
        For i = 0 To n - 1
            If i = 0 Or i = n - 1 Then '如果是最左邊或最右邊就設成1
                Record(n).Add(1)
            Else
                Record(n).Add(Record(n - 1)(i - 1) + Record(n - 1)(i)) '否則設成左邊+右邊的值
            End If
        Next
        If Record(n).Max > maxNum Then maxNum = Record(n).Max '設定最大值
    End Sub
    Sub printLabel(ByVal n As Integer, ByVal Record As List(Of List(Of Integer)), ByVal formula As String)
        outputLabel.Text = "" '一開始先設為空
        Dim formulaArray() As Integer = {0, 16, 15, 14, 13} '這邊設定格式用的
        For Each item In Record '讀取每一個清單
            outputLabel.Text &= Space(9 * (15 - item.Count)) '空格
            For Each value In item  '讀取每一個清單中的子元素
                outputLabel.Text &= Space(formulaArray(formula.Length) - formula.Length) & Trim(value.ToString(formula)) & " "
            Next
            outputLabel.Text &= vbNewLine
        Next
    End Sub
    Private Sub moreMsgBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moreMsgBtn.Click
        MsgBox("輸入僅能是數字，並且值在1~15之間")
    End Sub
End Class