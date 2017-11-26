Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        For q = 1 To 2
            Dim n As Integer = LineInput(q)
            For w = 1 To n
                Dim data() As String = LineInput(q).Split
                Dim edge(UBound(data)) As String
                Dim cost(UBound(data)), ans As Integer : ans = 0
                Dim node, adj, repeat As New List(Of String)
                For i = 0 To UBound(data)
                    Dim xy() As String = data(i).Split(",")
                    edge(i) = xy(0) & "," & xy(1)
                    cost(i) = xy(2)
                    node.Add(xy(0)) : node.Add(xy(1))
                Next
                node = node.Distinct.ToList
                Array.Sort(cost, edge)
                For i = 0 To node.Count - 1
                    For j = 0 To UBound(edge)
                        If InStr(edge(j), node(i)) <> 0 Then adj.Add(edge(j)) : repeat.Add(StrReverse(edge(j))) : Exit For
                    Next
                Next
                adj = adj.Distinct.ToList : repeat = repeat.Distinct.ToList
check:
                Dim connected() As Boolean = checkAdj(adj, Asc(node.Max) - 65)
                If Array.Exists(connected, Function(d) d = True) Then
                    Dim list, d As New List(Of String)
                    Dim coin As New List(Of Integer)
                    While Array.IndexOf(connected, False) <> -1
                        Dim index As String = Chr(Array.IndexOf(connected, False) + 65)
                        connected(Array.IndexOf(connected, False)) = True
                        d.Add(index)
                        For i = 0 To UBound(edge)
                            If InStr(edge(i), index) <> 0 And Not adj.Contains(edge(i)) Then list.Add(edge(i)) : coin.Add(Val(i))
                        Next
                    End While
                    For i = 0 To list.Count - 1 Step 1
                        If i >= list.Count Then Exit For
                        Dim count As Integer = 0
                        For j = 0 To d.Count - 1
                            If InStr(list(i), d(j)) <> 0 Then count += 1
                            If count = 2 Then list.RemoveAt(i) : coin.RemoveAt(i) : i -= 1 : Exit For
                        Next
                    Next
                    adj.Add(list(coin.IndexOf(coin.Min))) : GoTo check
                End If
                For i = 0 To adj.Count - 1
                    If i < repeat.Count Then If adj.Contains(repeat(i)) Then adj.Remove(repeat(i)) : Continue For
                    ans += cost(Array.IndexOf(edge, adj(i)))
                Next
                PrintLine(3, Trim(ans))
            Next
            PrintLine(3)
        Next
        FileClose()
        Close()
    End Sub
    Function checkAdj(ByVal adj As List(Of String), ByVal max As Integer)
        Dim adjLink(max, max), edge(max) As Boolean
        Dim first As Integer
        For i = 0 To adj.Count - 1
            Dim x = Asc(Mid(adj(i), 1, 1)) - 65, y = Asc(Mid(adj(i), 3, 1)) - 65
            adjLink(x, y) = True : adjLink(y, x) = True : first = x : edge(x) = True : edge(y) = True
        Next
        visit(adjLink, edge, first, max)
        Return edge
    End Function
    Sub visit(ByVal adjLink(,) As Boolean, ByVal edge() As Boolean, ByVal n As Integer, ByVal max As Integer)
        edge(n) = False
        For i = 0 To max
            If adjLink(n, i) And edge(i) Then visit(adjLink, edge, i, max)
        Next
    End Sub
End Class