Public Class Form1
    Class Tree
        Public data As Integer
        Public child As New List(Of Tree)
        Public subTree As New List(Of Integer)
        Public parent As Tree
        Sub New()
            parent = Nothing
        End Sub
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim data As List(Of String) = LineInput(1).Split.ToList
            Dim node As New List(Of Integer)
            For Each item In data
                Dim edge() As Integer = item.Split(",").Select(Function(X) CInt(X)).ToArray
                node.AddRange(edge.ToList)
            Next
            Dim root As Integer = node.Find(Function(x) node.FindAll(Function(y) y = x).Count = 1)
            Dim alreadyNode As New List(Of Integer) From {root}
            Dim Tree As New Tree With {.data = root}
            Dim centerNode As New List(Of Integer)
            Do Until data.Count = 0
                Dim index As Integer = 0
                Dim parent, child As Integer
                For i = 0 To data.Count - 1
                    Dim edge() As Integer = data(i).Split(",").Select(Function(x) CInt(x)).ToArray
                    If alreadyNode.Contains(edge.First) Or alreadyNode.Contains(edge.Last) Then
                        parent = Array.Find(edge, Function(x) alreadyNode.Contains(x))
                        child = Array.Find(edge, Function(x) alreadyNode.Contains(x) = False)
                        alreadyNode.AddRange(edge.ToList)
                        index = i : Exit For
                    End If
                Next
                createTree(Tree, child, parent)
                data.RemoveAt(index)
            Loop
            For Each current In alreadyNode.Distinct
                Dim startNode As Tree = findNode(Tree, current)
                Dim depth As Integer = depthSearch(startNode)
                Dim topHt As Integer = topSearch(startNode)
                If topHt = depth Then centerNode.Add(current)
            Next
            PrintLine(2, If(centerNode.Count > 0, Strings.Join(centerNode.Select(Function(X) X.ToString).ToArray, ","), "0"))
        Next
        FileClose()
        Close()
    End Sub
    Sub createTree(ByVal Tree As Tree, ByVal data As Integer, ByVal parent As Integer)
        Dim node As New Tree With {.data = data, .parent = Tree}
        If Tree.data = parent Then Tree.child.Add(node) : Tree.subTree.Add(data) : Return
        Dim index As Integer = Tree.child.FindIndex(Function(X) X.data = parent OrElse X.subTree.Contains(parent))
        createTree(Tree.child(index), data, parent)
        Tree.subTree.Add(data)
    End Sub
    Function depthSearch(ByVal Tree As Tree, Optional ByVal ht As Integer = 0, Optional ByRef maxHt As Integer = 0)
        If Tree.child.Count = 0 Then maxHt = Math.Max(maxHt, ht) : Return maxHt
        For Each node In Tree.child
            depthSearch(node, ht + 1, maxHt)
        Next
        Return maxHt
    End Function
    Function topSearch(ByVal Tree As Tree, Optional ByVal ht As Integer = 0, Optional ByRef maxHt As Integer = 0)
        If Tree.parent Is Nothing Then maxHt = Math.Max(ht, maxHt) : Return maxHt
        Return topSearch(Tree.parent, ht + 1, maxHt)
    End Function
    Function findNode(ByVal Tree As Tree, ByVal target As Integer)
        If Tree.data = target Then Return Tree
        Dim index As Integer = Tree.child.FindIndex(Function(X) X.data = target Or X.subTree.Contains(target))
        Return findNode(Tree.child(index), target)
    End Function
End Class