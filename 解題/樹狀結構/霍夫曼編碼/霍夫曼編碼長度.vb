Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        For q = 1 To 2
            Dim m As Integer = LineInput(q)
            For w = 1 To m
                Dim data() As Integer = LineInput(q).Split(",").Select(Function(X) CInt(X)).ToArray
                Dim node As List(Of Integer) = data.Select(Function(x) x).ToList
                Dim parent, child As New List(Of Integer)
                Do Until node.Count = 1
                    Dim parentNode As Integer = 0
                    For i = 1 To 2
                        Dim min As Integer = node.Min
                        parentNode += min
                        child.Add(min)
                        node.Remove(node.Min)
                    Next
                    node.Add(parentNode)
                    parent.AddRange({parentNode, parentNode})
                Loop
                Dim result As String = ""
                For Each current In data
                    result &= traversal(parent, child, current) & ","
                Next
                PrintLine(3, Strings.Left(result, result.Length - 1))
            Next
            PrintLine(3)
        Next
        FileClose()
        Close()
    End Sub
    Function traversal(ByVal parent As List(Of Integer), ByVal child As List(Of Integer), ByVal current As Integer, Optional ByVal ht As Integer = 0)
        If child.Contains(current) = False Then Return ht
        Return traversal(parent, child, parent(child.IndexOf(current)), ht + 1)
    End Function
End Class