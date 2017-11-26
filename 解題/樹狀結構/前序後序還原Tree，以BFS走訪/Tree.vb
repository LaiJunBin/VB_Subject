Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        For q = 1 To 2
            Dim m As Integer = LineInput(q)
            For w = 1 To m
                Dim preorder As List(Of Integer) = LineInput(q).Split(",").Select(Function(X) CInt(X)).ToList
                Dim postorder As List(Of Integer) = LineInput(q).Split(",").Select(Function(X) CInt(X)).ToList
                Dim Tree As New Dictionary(Of Integer, Integer)
                Tree.Add(1, preorder.FirstOrDefault)
                reBuildTree(preorder, postorder, Tree, New List(Of Integer) From {preorder.FirstOrDefault}, preorder.FirstOrDefault)
                Dim BFSResult As String = ""
                Dim queue As New Queue
                queue.Enqueue(1)
                BFSSearch(Tree, BFSResult, queue)
                PrintLine(3, Strings.Left(BFSResult, BFSResult.Length - 1))
            Next
            PrintLine(3)
        Next
        FileClose()
        Close()
    End Sub
    Sub reBuildTree(ByVal preorder As List(Of Integer), ByVal postorder As List(Of Integer), ByVal Tree As Dictionary(Of Integer, Integer), ByVal alreadyNode As List(Of Integer), ByVal current As Integer, Optional ByVal index As Integer = 1)
        Dim Left, Right As Boolean
        If preorder.IndexOf(current) <> preorder.Count - 1 AndAlso alreadyNode.Contains(preorder(preorder.IndexOf(current) + 1)) = False Then
            Tree.Add(index * 2, preorder(preorder.IndexOf(current) + 1))
            alreadyNode.Add(preorder(preorder.IndexOf(current) + 1))
            Left = True
        End If
        If postorder.IndexOf(current) <> 0 AndAlso alreadyNode.Contains(postorder(postorder.IndexOf(current) - 1)) = False Then
            Tree.Add(index * 2 + 1, postorder(postorder.IndexOf(current) - 1))
            alreadyNode.Add(postorder(postorder.IndexOf(current) - 1))
            Right = True
        End If
        If Left AndAlso preorder.IndexOf(current) <> preorder.Count - 1 Then
            reBuildTree(preorder, postorder, Tree, alreadyNode, preorder(preorder.IndexOf(current) + 1), index * 2)
        End If
        If Right AndAlso postorder.IndexOf(current) <> 0 Then
            reBuildTree(preorder, postorder, Tree, alreadyNode, postorder(postorder.IndexOf(current) - 1), index * 2 + 1)
        End If
    End Sub
    Sub BFSSearch(ByVal Tree As Dictionary(Of Integer, Integer), ByRef result As String, ByVal queue As Queue)
        Dim current As Integer = queue.Dequeue
        result &= Tree(current) & ","
        If Tree.ContainsKey(current * 2) Then queue.Enqueue(current * 2)
        If Tree.ContainsKey(current * 2 + 1) Then queue.Enqueue(current * 2 + 1)
        While queue.Count > 0
            BFSSearch(Tree, result, queue)
        End While
    End Sub
End Class