Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim data As List(Of String) = LineInput(1).Split({",", " "}, StringSplitOptions.RemoveEmptyEntries).Select(Function(X) X & "x").ToList
            Dim parent, child As New List(Of String)
            Dim path As New List(Of Integer)
            Dim result As Integer = 0
            Do Until data.Count = 1
                Dim d As Integer = 0
                For i = 1 To 2
                    Dim min As String = getMin(data)
                    d += Val(min)
                    child.Add(min)
                    data.Remove(min)
                Next
                data.Add(d)
                parent.AddRange({d, d})
            Loop
            For Each node In child
                If node.Contains("x") Then
                    Dim ht As Integer = traversal(parent, child, node, path)
                    result += ht * Val(node)
                End If
            Next
            PrintLine(2, Trim(result))
        Next
        FileClose()
        Close()
    End Sub
    Function getMin(ByVal data As List(Of String), Optional ByVal n As String = "100000000")
        For Each item In data
            Dim d As Integer = Val(item)
            Dim m As Integer = Val(n)
            If m > d OrElse m = d And item.Contains("x") = False Then n = item
        Next
        Return n
    End Function
    Function traversal(ByVal parent As List(Of String), ByVal child As List(Of String), ByVal current As String, ByVal path As List(Of Integer), Optional ByRef ht As Integer = 0)
        If child.Contains(current) = False Then Return ht
        For i = 0 To child.Count - 1
            If current.Contains("x") = False AndAlso child(i) = current OrElse path.Contains(i) = False AndAlso child(i) = current Then
                path.Add(i)
                Return traversal(parent, child, parent(i), path, ht + 1)
            End If
        Next
    End Function
End Class