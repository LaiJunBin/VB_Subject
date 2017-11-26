Public Class Form1
    Class Tree
        Public data As Integer
        Public Left, Right As Tree
        Public subTree As New List(Of Integer)
        Sub New()
            Left = Nothing : Right = Nothing
        End Sub
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m() As Integer = LineInput(1).Split.Select(Function(x) CInt(x)).ToArray
        Dim parent, child As New List(Of Integer)
        For w = 1 To m.First
            Dim edge() As Integer = LineInput(1).Split.Select(Function(x) CInt(x)).ToArray
            parent.Add(edge.Last) : child.Add(edge.First)
        Next
        Dim root As Integer = parent.Find(Function(x) child.Contains(x) = False)
        Dim alreadyParent As New List(Of Integer) From {root}
        Dim Tree As New Tree With {.data = root}
        Do Until parent.Count = 0
            Dim index As Integer = 0
            For i = 0 To parent.Count - 1
                If alreadyParent.Contains(parent(i)) Then
                    index = i
                    Exit For
                End If
            Next
            createTree(child(index), parent(index), Tree)
            alreadyParent.Add(child(index))
            parent.RemoveAt(index) : child.RemoveAt(index)
        Loop
        For i = 1 To m.Last
            Dim target As Integer = LineInput(1)
            Dim result As String = ""
            preOrder(findNode(target, Tree), result)
            PrintLine(2, Strings.Left(result, result.Length - 1))
        Next
        FileClose()
        Close()
    End Sub
    Sub createTree(ByVal data As Integer, ByVal parent As Integer, ByRef Tree As Tree)
        Dim node As New Tree With {.data = data}
        If Tree.data = parent Then
            If Tree.Left Is Nothing Then Tree.Left = node Else Tree.Right = node
            Tree.subTree.Add(data)
            Return
        End If
        If Tree.Left.data = parent OrElse Tree.Left.subTree.Contains(parent) Then
            createTree(data, parent, Tree.Left) : Tree.subTree.Add(data) : Return
        Else
            createTree(data, parent, Tree.Right) : Tree.subTree.Add(data) : Return
        End If
    End Sub
    Function findNode(ByVal data As Integer, ByVal Tree As Tree)
        If Tree.data = data Then Return Tree
        If Tree.Left.data = data OrElse Tree.Left.subTree.Contains(data) Then
            Return findNode(data, Tree.Left)
        Else
            Return findNode(data, Tree.Right)
        End If
    End Function
    Sub preOrder(ByVal Tree As Tree, ByRef result As String)
        If Tree Is Nothing Then Return
        result &= Tree.data & ","
        preOrder(Tree.Left, result)
        preOrder(Tree.Right, result)
    End Sub
End Class
