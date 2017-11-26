Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim data() As Integer = LineInput(1).Split(",").Select(Function(x) CInt(x)).ToArray
            Dim Tree As New Dictionary(Of Integer, Integer)
            For i = 1 To data.Length
                Tree.Add(i, data(i - 1))
            Next
            Dim max As Integer = traversal(Tree)
            PrintLine(2, Trim(max))
        Next
        FileClose()
        Close()
    End Sub
    Function traversal(ByVal Tree As Dictionary(Of Integer, Integer), Optional ByVal index As Integer = 1, Optional ByVal n As Integer = 0, Optional ByRef max As Integer = 0)
        If Tree.ContainsKey(index) = False Then Return max
        n += Tree(index)
        max = Math.Max(n, max)
        traversal(Tree, index * 2, n, max)
        traversal(Tree, index * 2 + 1, n, max)
        Return max
    End Function
End Class