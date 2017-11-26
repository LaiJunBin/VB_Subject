Public Class Form1
    Public Class node
        Public data, depth As Integer
        Public parent As node
        Sub New()
            parent = Nothing
        End Sub
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim DisjoinSet As New List(Of node)
        Dim n As Integer = 0
        Do Until EOF(1)
            Dim action() As String = LineInput(1).Split
            Select Case action.First
                Case "makeSet"
                    DisjoinSet.Clear()
                    makeSet(DisjoinSet, action.Last)
                    If n <> 0 Then PrintLine(2)
                    n = 0
                Case "merge"
                    Dim data() As Integer = action.SkipWhile(Function(x, i) i = 0).Select(Function(x) CInt(x.Replace("{", "").Replace("}", ""))).ToArray
                    merge(DisjoinSet, data.First, data.Last)
                Case "list"
                    n += 1
                    PrintLine(2, "Case " & Trim(n) & ":")
                    list(DisjoinSet)
            End Select
        Loop
        FileClose()
        Close()
    End Sub
    Sub makeSet(ByRef DisjoinSet As List(Of node), ByVal max As Integer)
        For i = 1 To max
            DisjoinSet.Add(New node With {.data = i, .depth = 0})
        Next
    End Sub
    Function find(ByVal DisjoinSet As List(Of node), ByVal data As Integer, ByVal index As Integer)
        Dim current As node = DisjoinSet(index)
        While (1)
            If current.data = data Then Return current
            If current.parent Is Nothing Then Exit While
            current = current.parent
        End While
    End Function
    Function findIndex(ByVal DisjoinSet As List(Of node), ByVal target As Integer)
        For i = 0 To DisjoinSet.Count - 1
            Dim current As node = DisjoinSet(i)
            While (1)
                If current.data = target Then Return i
                If current.parent Is Nothing Then Exit While
                current = current.parent
            End While
        Next
    End Function
    Sub merge(ByRef DisjoinSet As List(Of node), ByVal pdata As Integer, ByVal qdata As Integer)
        Dim pindex = findIndex(DisjoinSet, pdata)
        Dim qindex = findIndex(DisjoinSet, qdata)
        Dim p As node = find(DisjoinSet, pdata, pindex)
        Dim q As node = find(DisjoinSet, qdata, qindex)
        DisjoinSet(qindex).parent = p
        DisjoinSet(qindex).depth += 1
    End Sub
    Sub list(ByVal DisjoinSet As List(Of node))
        For Each node In DisjoinSet
            Dim current As node = node
            While Not current.parent Is Nothing
                Print(2, Trim(current.data) & "->")
                current = current.parent
            End While
            PrintLine(2, Trim(current.data))
        Next
    End Sub
End Class