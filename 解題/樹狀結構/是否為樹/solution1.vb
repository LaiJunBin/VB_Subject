Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim data() As String = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim root(data.Select(Function(x) x.Split(",").Select(Function(y) CInt(y)).Max).Max) As Integer
            Dim isTree As Boolean = True
            root = root.Select(Function(x, i) i).ToArray
            For Each item In data
                Dim edge() As Integer = item.Split(",").Select(Function(x) CInt(x)).ToArray
                If findRoot(edge.First, root) = findRoot(edge.Last, root) Then isTree = False : Exit For
                merge(edge.First, edge.Last, root)
            Next
            If isTree AndAlso Strings.Join(data, ",").Split(",").Select(Function(x) x).Distinct.Count - 1 = data.Length Then PrintLine(2, "T") Else PrintLine(2, "F")
        Next
        FileClose()
        Close()
    End Sub
    Function findRoot(ByVal x As Integer, ByVal root() As Integer)
        If root(x) = x Then Return x
        root(x) = findRoot(root(x), root)
        Return root(x)
    End Function
    Sub merge(ByVal x As Integer, ByVal y As Integer, ByVal root() As Integer)
        x = findRoot(x, root) : y = findRoot(y, root)
        root(y) = x
    End Sub
End Class