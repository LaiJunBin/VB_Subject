Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        For q = 1 To 2
            Dim m As Integer = LineInput(q)
            For w = 1 To m
                Dim data() As String = LineInput(q).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                Dim edge(UBound(data)) As String
                Dim cost(UBound(data)) As Integer
                For i = 0 To UBound(data)
                    Dim eg() As String = data(i).Split(",")
                    edge(i) = eg(0) & " " & eg(1)
                    cost(i) = eg(2)
                Next
                Array.Sort(cost, edge)
                Dim result As Integer = 0
                Dim root(26) As Integer
                root = root.Select(Function(x, i) i).ToArray
                For i = 0 To UBound(edge)
                    Dim eg() As Integer = edge(i).Split.Select(Function(x) Asc(x) - 65).ToArray
                    If same(eg.First, eg.Last, root) Then Continue For
                    result += cost(i) : merge(eg.First, eg.Last, root)
                Next
                PrintLine(3, Trim(result))
            Next
            PrintLine(3)
        Next
        FileClose()
        Close()
    End Sub
    Function findRoot(ByVal x As Integer, ByVal root() As Integer)
        If x = root(x) Then Return x
        root(x) = findRoot(root(x), root)
        Return root(x)
    End Function
    Function same(ByVal x As Integer, ByVal y As Integer, ByVal root() As Integer)
        If findRoot(x, root) = findRoot(y, root) Then Return True Else Return False
    End Function
    Sub merge(ByVal x As Integer, ByVal y As Integer, ByVal root() As Integer)
        x = findRoot(x, root) : y = findRoot(y, root) : root(y) = x
    End Sub
End Class