Public Class form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim data() As String = LineInput(1).Split
            Dim parent, child, record As New List(Of String)
            For Each item In data
                Dim edge() As String = item.Split(",")
                parent.Add(edge.Last) : child.Add(edge.First)
            Next
            Dim root As String = parent.Find(Function(X) child.Contains(X) = False)
            Dim ht As Integer = findHt(child, parent, root)
            Dim Tree As New Dictionary(Of Integer, Dictionary(Of String, List(Of String)))
            traversal(child, parent, record, root, 1)
            PrintLine(2, Strings.Join(record.ToArray, ","))
            record.Clear()
            traversal(child, parent, record, root, 2)
            PrintLine(2, Strings.Join(record.ToArray, ","))
            record.Clear()
            For i = ht To 1 Step -1
                postTraversal(Tree, child, parent, root, i)
            Next
            For Each item In Tree
                For Each node In item.Value
                    For i = node.Value.Count - 1 To 0 Step -1
                        record.Add(node.Value(i))
                    Next
                Next
            Next
            record.Add(root)
            PrintLine(2, Strings.Join(record.ToArray, ","))
            PrintLine(2)
        Next
        FileClose()
        Close()
    End Sub
    Function findHt(ByVal child As List(Of String), ByVal parent As List(Of String), ByVal cureent As String, Optional ByVal ht As Integer = 0)
        If parent.Contains(cureent) = False Then Return ht
        Dim min As Integer = ht
        For i = 0 To parent.Count - 1
            If parent(i) = cureent Then min = Math.Max(findHt(child, parent, child(i), ht + 1), min)
        Next
        Return min
    End Function
    Sub traversal(ByVal child As List(Of String), ByVal parent As List(Of String), ByVal record As List(Of String), ByVal current As String, ByVal type As Integer)
        If type = 1 Then record.Add(current)
        If parent.Contains(current) Then
            For i = 0 To parent.Count - 1
                If parent(i) = current Then traversal(child, parent, record, child(i), type)
            Next
        End If
        If type = 2 Then record.Add(current)
    End Sub
    Sub postTraversal(ByRef Tree As Dictionary(Of Integer, Dictionary(Of String, List(Of String))), ByVal child As List(Of String), ByVal parent As List(Of String), ByVal current As String, ByVal target As Integer, Optional ByVal ht As Integer = 0)
        If ht = target Then
            If Tree.ContainsKey(ht) = False Then Tree.Add(ht, New Dictionary(Of String, List(Of String)))
            Dim index As Integer = child.IndexOf(current)
            If Tree(ht).ContainsKey(parent(index)) = False Then Tree(ht).Add(parent(index), New List(Of String))
            Tree(ht)(parent(index)).Add(current)
            Return
        End If
        If parent.Contains(current) Then
            For i = 0 To parent.Count - 1
                If parent(i) = current Then
                    postTraversal(Tree, child, parent, child(i), target, ht + 1)
                End If
            Next
        End If
    End Sub
End Class