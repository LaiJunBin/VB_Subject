Public Class Form1
    Class sortMethod
        Implements IComparer(Of String)
        Public Function Compare(ByVal x As String, ByVal y As String) As Integer Implements System.Collections.Generic.IComparer(Of String).Compare
            Return Val(x) < Val(y)
        End Function
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim data() As String = LineInput(1).Split
            Dim Graph As New Dictionary(Of Integer, List(Of String))
            For Each item In data
                Dim edge() As Integer = item.Split(",").Select(Function(x) CInt(x)).ToArray
                If Graph.ContainsKey(edge.First) = False Then Graph.Add(edge.First, New List(Of String))
                If Graph.ContainsKey(edge.Last) = False Then Graph.Add(edge.Last, New List(Of String))
                Graph(edge.First).Add(edge.Last) : Graph(edge.Last).Add(edge.First)
            Next
            Dim List As New List(Of String)
            Dim terminalNode As New HashSet(Of Integer)
            Dim count As Integer = -1
            Do Until List.Count = count
                Dim record As New HashSet(Of Integer)
                count = List.Count
                traversal(Graph, Graph.First.Key, New List(Of Integer), record, terminalNode, terminalNode.Select(Function(X) X.ToString).ToList)
                For Each item In record
                    List.Add(item)
                Next
            Loop
            List = List.Distinct.ToList
            List.Sort(New sortMethod)
            PrintLine(2, If(List.Count = 0, "N", Strings.Join(List.ToArray, ",")))
        Next
        FileClose()
        Close()
    End Sub
    Sub traversal(ByVal Graph As Dictionary(Of Integer, List(Of String)), ByVal current As Integer, ByVal path As List(Of Integer), ByVal record As HashSet(Of Integer), ByVal terminalNode As HashSet(Of Integer), ByVal List As List(Of String))
        path.Add(current)
        If Graph(current).Except(List).Count = 1 AndAlso terminalNode.Contains(current) = False Then
            terminalNode.Add(current)
            record.Add(Graph(current).Except(List).First) : Return
        End If
        For Each node In Graph(current)
            If path.Contains(node) = False AndAlso terminalNode.Contains(node) = False Then
                traversal(Graph, node, path.GetRange(0, path.Count), record, terminalNode, List)
            End If
        Next
    End Sub
End Class