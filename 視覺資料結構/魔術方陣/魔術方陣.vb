Public Class Form1
    Dim WithEvents w_timer As New Timer
    Dim w_secord As Integer
    Dim MaxN As Integer
    Dim speed As Integer = 1000
    Dim printMatrix(,) As Integer
    Dim bool As Boolean = False
    Private Sub moreMsgBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moreMsgBtn.Click
        MsgBox("輸入的n必為奇數，並大於0且小於10")
    End Sub
    Private Sub submitBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submitBtn.Click
        Dim n As String = NTextBox.Text
        If n = "" OrElse Not checkFormula(n) Then MsgBox("請檢查輸入格式") : Exit Sub
        Dim matrix(n, n) As Integer '建立一個跟使用者輸入的大小一樣的矩陣
        Dim x, y As Integer '設定2個索引值
        bool = True
        skipBtn.Enabled = True
        submitBtn.Enabled = False
        MaxN = n
        x = Math.Ceiling(n / 2) : y = 1 'x設為中間值
        For i = 1 To n ^ 2 '從1開始放，直到n平方
            matrix(x, y) = i
            printMatrix = matrix
            If bool = True Then wait(speed)
            If x = 1 And y = 1 Then y += 1 : Continue For '如果到了左上角則往下走
            adjustIndex(x, n) '調整，行35
            adjustIndex(y, n)
            If Not matrix(x, y) = 0 Then x += 1 : y += 2 '如果調整後的位置有設定過 則往下ㄧ格
        Next
        printLabel()
    End Sub
    Function checkFormula(ByVal n As Integer)
        Return n Mod 2 = 1 And n > 0 And n < 10
    End Function
    Sub adjustIndex(ByRef index As Integer, ByVal n As Integer)
        If index - 1 = 0 Then index = n Else index -= 1 '如果-1變成0則設成n
    End Sub
    Sub printLabel()
        OutputLabel.Text = ""
        For i = 1 To MaxN
            For j = 1 To MaxN
                OutputLabel.Text &= printMatrix(j, i).ToString("00") & Space(3)
            Next
            OutputLabel.Text &= vbNewLine
        Next
    End Sub
    Private Sub wait(ByVal second As Integer)
        w_secord = 0
        w_timer.Interval = second
        w_timer.Enabled = True
        printLabel()
        Do Until w_secord >= 1 Or bool = False
            Application.DoEvents()
        Loop
        w_timer.Enabled = False
        w_timer.Interval = 1
    End Sub
    Private Sub w_timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles w_timer.Tick
        w_secord += 1
    End Sub
    Private Sub skipBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles skipBtn.Click
        bool = False
        skipBtn.Enabled = False
        submitBtn.Enabled = True
    End Sub
    Private Sub form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        bool = False
    End Sub
    Private Sub speedTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles speedTrackBar.Scroll
        speed = speedTrackBar.Value
    End Sub
End Class