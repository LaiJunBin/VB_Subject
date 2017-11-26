Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim data() As Integer = LineInput(1).Split(",").Select(Function(x) CInt(x)).ToArray
            Dim Tree, record As New Dictionary(Of Integer, Integer)
            For i = 1 To data.Length
                Tree.Add(i, data(i - 1))
            Next
            For Each node In Tree
                Dim L, R, LValue, RValue As Integer
                L = node.Key * 2
                R = node.Key * 2 + 1
                If Tree.ContainsKey(L) = False AndAlso Tree.ContainsKey(R) = False Then Exit For
                LValue = traversal(Tree, L)
                RValue = traversal(Tree, R)
                If LValue = RValue Then record.Add(node.Value, LValue)
            Next
            For Each item In record
                PrintLine(2, "node=" & item.Key & ",sum=" & item.Value)
            Next
            If record.Count = 0 Then PrintLine(2, "N")
            PrintLine(2)
        Next
        FileClose()
        Close()
    End Sub
    Function traversal(ByVal Tree As Dictionary(Of Integer, Integer), ByVal index As Integer, Optional ByRef n As Integer = 0)
        If Tree.ContainsKey(index) = False Then Return n
        n += Tree(index)
        traversal(Tree, index * 2, n)
        traversal(Tree, index * 2 + 1, n)
        Return n
    End Function
End Class