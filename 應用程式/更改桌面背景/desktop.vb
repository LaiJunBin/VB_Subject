Public Class Form1
    Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" _
     (ByVal uAction As Integer, ByVal uParam As Integer, _
      ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' 參數 1 :  圖檔完整路徑+檔名
        ' 參數 2 :   0 置中, 1 並排顯示 , 2 延展
        ChangeWallpaper("路徑", 0)
        Shell("cmd.exe /c" & "指令", vbNormalFocus)
    End Sub
    Sub ChangeWallpaper(ByVal strPicPath As String, ByRef intStyle As Integer)
        Dim objRegKey As Microsoft.Win32.RegistryKey
        Dim objImg As Image
        If strPicPath Is Nothing Then Exit Sub
        If System.IO.File.Exists(strPicPath) Then
            objRegKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\Desktop", True)
            Select Case intStyle
                Case 0 ' 置中 
                    objRegKey.SetValue("TileWallpaper", "0")
                    objRegKey.SetValue("WallpaperStyle", "0")
                Case 1 ' 並排顯示 
                    objRegKey.SetValue("TileWallpaper", "1")
                    objRegKey.SetValue("WallpaperStyle", "0")
                Case 2 ' 延展 
                    : objRegKey.SetValue("TileWallpaper", "0")
                    objRegKey.SetValue("WallpaperStyle", "2")
                    : End Select
            objRegKey.Flush()
            objRegKey.Close()
            Dim fi As New System.IO.FileInfo(strPicPath)
            If fi.Extension.ToLower <> ".bmp" Then
                objImg = Image.FromFile(strPicPath, True)
                strPicPath = strPicPath.Substring(0, strPicPath.Length - 3) & "bmp"
                objImg.Save(strPicPath, Drawing.Imaging.ImageFormat.Bmp)
            End If
            SystemParametersInfo(20, 0, strPicPath, 1 Or 2)
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Shell("CMD.EXE", vbNormalFocus)
    End Sub
    Private Sub form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim n As Integer = 0
        Dim msg As String = ""
rep:
        If MessageBox.Show("確定關閉視窗?" & msg, "警告", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            e.Cancel = True
        Else
            If n < 10 Then
                msg = "(在點" & 10 - n & "次就可以關閉)"
                n += 1
                GoTo rep
            End If
        End If
    End Sub
End Class
