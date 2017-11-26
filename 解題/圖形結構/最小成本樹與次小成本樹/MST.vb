Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        For q = 1 To 2
            Dim m As Integer = LineInput(q)
            For w = 1 To m
                Dim data() As String = LineInput(q).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                Dim costArray(UBound(data)) As Integer
                Dim edgeArray(UBound(data)) As String
                Dim max As Integer = 0
                For i = 0 To UBound(data)
                    Dim edge() As Integer = data(i).Split(",").Select(Function(X, y) CInt(If(y <= 1, Asc(X) - 65, X))).ToArray
                    costArray(i) = edge.Last : edgeArray(i) = edge(0) & " " & edge(1)
                    max = Math.Max(edge(0), Math.Max(edge(1), max))
                Next
                Array.Sort(costArray, edgeArray)
                Dim record As New SortedDictionary(Of Integer, List(Of List(Of String)))
                For i = 0 To UBound(edgeArray)
                    Dim root(max) As Integer
                    root = root.Select(Function(X, z) z).ToArray
                    Dim edgeList As New List(Of String)
                    Dim cost As Integer = 0
                    For j = 0 To UBound(edgeArray)
                        If i = j Then Continue For
                        Dim edge() As Integer = edgeArray(j).Split.Select(Function(x) CInt(x)).ToArray
                        If is_same(edge.First, edge.Last, root) Then Continue For
                        edgeList.Add(edge.First & " " & edge.Last)
                        cost += costArray(j)
                        merge(edge.First, edge.Last, root)
                    Next
                    If record.ContainsKey(cost) = False Then record.Add(cost, New List(Of List(Of String)))
                    If Not sameList(edgeList, record(cost)) Then record(cost).Add(edgeList)
                Next
                Dim CostList As New List(Of String)
                For Each item In record
                    For Each value In item.Value
                        CostList.Add(item.Key)
                        If CostList.Count >= 2 Then Exit For
                    Next
                    If CostList.Count >= 2 Then Exit For
                Next
                PrintLine(3, Strings.Join(CostList.ToArray, " "))
            Next
           PrintLine(3)
        Next
        FileClose()
        Close()
    End Sub
    Function sameList(ByVal edgeList As List(Of String), ByVal record As List(Of List(Of String)))
        For Each item In record
            If item.Except(edgeList).Count = 0 Then Return True
        Next
        Return False
    End Function
    Function findRoot(ByVal x As Integer, ByVal root() As Integer)
        If x = root(x) Then Return x
        root(x) = findRoot(root(x), root)
        Return root(x)
    End Function
    Function is_same(ByVal x As Integer, ByVal y As Integer, ByVal root() As Integer)
        Return findRoot(x, root) = findRoot(y, root)
    End Function
    Sub merge(ByVal x As Integer, ByVal y As Integer, ByVal root() As Integer)
        x = findRoot(x, root) : y = findRoot(y, root) : root(y) = x
    End Sub
End Class