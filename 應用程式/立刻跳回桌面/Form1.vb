Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim clsidShell As New Guid("13709620-C279-11CE-A49E-444553540000")
        Dim shell1 As Object = Activator.CreateInstance( _
        Type.GetTypeFromCLSID(clsidShell))
        shell1.ToggleDesktop()
        Close()
    End Sub
End Class