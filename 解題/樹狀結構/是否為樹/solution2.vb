Public Class form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim n As Integer = LineInput(1)
        For w = 1 To n
            Dim data() As String = LineInput(1).Split
            Dim datalist As New List(Of Integer)
            For i = 0 To UBound(data)
                Dim xy() As Integer = data(i).Split({","}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) CInt(x)).ToArray
                datalist.AddRange(xy)
            Next
            Dim max As Integer = datalist.Max
            Dim edge(max, max), node(max) As Boolean
            Dim firstNode As Integer
            While datalist.Count > 0
                Dim x = datalist(0), y = datalist(1)
                edge(x, y) = True : edge(y, x) = True
                node(x) = True : node(y) = True
                firstNode = x : datalist.RemoveRange(0, 2)
            End While
            If Array.FindAll(node, Function(x) x = True).Count - 1 <> data.Count Then PrintLine(2, "F") : Continue For
            dfs(max, firstNode, edge, node)
            PrintLine(2, If(Array.Exists(node, Function(x) x = True), "F", "T"))
        Next
        FileClose()
        Close()
    End Sub
    Sub dfs(ByVal max As Integer, ByVal n As Integer, ByVal edge(,) As Boolean, ByVal node() As Boolean)
        node(n) = False
        For i = 0 To max
            If edge(n, i) And node(i) Then dfs(max, i, edge, node)
        Next
    End Sub
End Class