Public Class Form1
    Dim FirstNumber, LastNumber, n, OtherNumber() As Integer
    Dim currentList, HistoryList, queueList As New List(Of Integer)
    Private Sub start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startButton.Click
        Randomize()
        If queueList.Count = 0 Then MsgBox("已經沒有人了!請重置!") : Exit Sub
        If IsNumeric(NumberPeopleTextbox.Text) Then n = NumberPeopleTextbox.Text Else MsgBox("抽籤人數請輸入數字") : Exit Sub
        If n > queueList.Count Then MsgBox("抽籤人數超出剩餘人數，請重新輸入") : Exit Sub
        currentList.Clear()
        For i = 1 To n
            Dim randNumber As Integer = Int(Rnd() * queueList.Count)
            currentList.Add(queueList(randNumber))
            HistoryList.Add(queueList(randNumber))
            queueList.RemoveAt(randNumber)
        Next
        showLabel()
    End Sub
    Function init()
        Dim temp As String = ""
        temp = FirstNumberTextbox.Text
        If IsNumeric(temp) Then FirstNumber = FirstNumberTextbox.Text Else MsgBox("請確定初始號碼輸入的是數字") : Return False
        If temp < 1 Then MsgBox("初始值不可小於1") : Return False
        temp = LastNumberTextbox.Text
        If IsNumeric(temp) Then LastNumber = LastNumberTextbox.Text Else MsgBox("請確定結束號碼輸入的是數字") : Return False
        If temp > 99 Then MsgBox("結束值不可大於99") : Return False
        temp = OtherNumberTextbox.Text
        For i = 1 To temp.Length
            If Not Mid(temp, i, 1) = "," And Not IsNumeric(Mid(temp, i, 1)) Then MsgBox("請確定休學號碼的格式") : Return False
        Next
        OtherNumber = OtherNumberTextbox.Text.Split({" ", ","}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) CInt(x)).ToArray
        If Array.FindAll(OtherNumber, Function(x) x > LastNumber Or x < FirstNumber).Count > 0 Then MsgBox("休學號碼中有不合法的號碼") : Return False
        If FirstNumber > LastNumber Then MsgBox("初始值必須小於結束值") : Return False
        FirstNumberTextbox.Enabled = False
        LastNumberTextbox.Enabled = False
        OtherNumberTextbox.Enabled = False
        startButton.Enabled = True
        configButton.Enabled = False
        resetList.Enabled = True
        NumberPeopleTextbox.Enabled = True
        resetButton.Enabled = True
        initList()
        Return True
    End Function
    Sub showLabel()
        Dim temp As String = vbNewLine
        Dim n As Integer = 0
        showCurrentLabel.Text = "當前被抽到的為："
        PeopleHistoryLabel.Text = "已經被抽過的為："
        queuePeopleLabel.Text = "尚未被抽到的人："
        For Each value In currentList
            n += 1 : temp &= value.ToString("00") & ","
            If n = 5 Then temp = Strings.Left(temp, temp.Length - 1) & vbNewLine : n = 0
        Next
        showCurrentLabel.Text &= Strings.Left(temp, temp.Length - 1)
        temp = vbNewLine : n = 0
        For Each value In HistoryList
            n += 1 : temp &= value.ToString("00") & ","
            If n = 5 Then temp = Strings.Left(temp, temp.Length - 1) & vbNewLine : n = 0
        Next
        PeopleHistoryLabel.Text &= Strings.Left(temp, temp.Length - 1)
        temp = vbNewLine : n = 0
        For Each value In queueList
            n += 1 : temp &= value.ToString("00") & ","
            If n = 5 Then temp = Strings.Left(temp, temp.Length - 1) & vbNewLine : n = 0
        Next
        queuePeopleLabel.Text &= Strings.Left(temp, temp.Length - 1)
    End Sub
    Private Sub resetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resetButton.Click
        FirstNumberTextbox.Enabled = True
        LastNumberTextbox.Enabled = True
        OtherNumberTextbox.Enabled = True
        NumberPeopleTextbox.Enabled = False
        startButton.Enabled = False
        resetButton.Enabled = False
        configButton.Enabled = True
        currentList.Clear()
        HistoryList.Clear()
        resetList.Enabled = False
        queueList.Clear()
        showLabel()
    End Sub
    Private Sub configButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles configButton.Click
        If Not init() Then Exit Sub
        showLabel()
    End Sub
    Private Sub resetList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resetList.Click
        currentList.Clear()
        HistoryList.Clear()
        queueList.Clear()
        initList()
        showLabel()
    End Sub
    Sub initList()
        For i As Integer = FirstNumber To LastNumber
            If Array.Exists(OtherNumber, Function(x) x = i) Then Continue For
            queueList.Add(i)
        Next
    End Sub
End Class
