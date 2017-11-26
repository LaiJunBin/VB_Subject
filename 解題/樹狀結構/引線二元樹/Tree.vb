Public Class Form1
    Public Class Tree
        Public data As Object
        Public L_child As Tree
        Public R_child As Tree
        Public L_thread As Boolean = False
        Public R_thread As Boolean = False
        Sub New()
            L_child = Nothing
            R_child = Nothing
        End Sub
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim n As Integer = LineInput(1)
        For w = 1 To n
            PrintLine(2, "Case:" & Trim(w))
            Dim data As List(Of String) = LineInput(1).Split({" ", ","}, StringSplitOptions.RemoveEmptyEntries).ToList
            Dim Tree As Tree = Nothing
            Dim inorderPath As New List(Of Object)
            inorderPath.AddRange({"null", "null"})
            For Each value In data
                createBinaryTree(Tree, adjustType(value))
            Next
            inorderTraversal(Tree, inorderPath)
            adjustThread(Tree, New List(Of Object), inorderPath, Tree)
            PrintLine(2)
        Next
        FileClose()
        Close()
    End Sub
    Sub createBinaryTree(ByRef Tree As Tree, ByVal data As Object)
        Dim node As New Tree
        node.data = data
        If Tree Is Nothing Then Tree = node : Return
        If data > Tree.data Then createBinaryTree(Tree.R_child, data) Else createBinaryTree(Tree.L_child, data)
        Return
    End Sub
    Sub inorderTraversal(ByVal Tree As Tree, ByRef inorderPath As List(Of Object))
        If Tree Is Nothing Then Return
        inorderTraversal(Tree.L_child, inorderPath)
        inorderPath.Insert(inorderPath.Count - 1, Tree.data)
        inorderTraversal(Tree.R_child, inorderPath)
    End Sub
    Sub adjustThread(ByRef Tree As Tree, ByVal record As List(Of Object), ByVal inorderPath As List(Of Object), ByVal prototypeTree As Tree)
        If Tree Is Nothing Then Return
        record.Add(Tree.data)
        adjustThread(Tree.L_child, record, inorderPath, prototypeTree)
        adjustThread(Tree.R_child, record, inorderPath, prototypeTree)
        If Tree.L_child Is Nothing And Tree.L_thread = False Then
            If record.IndexOf(inorderPath(inorderPath.IndexOf(Tree.data) - 1)) <> -1 Then
                Tree.L_child = findNode(prototypeTree, inorderPath(inorderPath.IndexOf(Tree.data) - 1), Nothing)
            End If
            Tree.L_thread = True
        End If
        If Tree.R_child Is Nothing And Tree.R_thread = False Then
            If record.IndexOf(inorderPath(inorderPath.IndexOf(Tree.data) + 1)) <> -1 Then
                Tree.R_child = findNode(prototypeTree, inorderPath(inorderPath.IndexOf(Tree.data) + 1), Nothing)
            End If
            Tree.R_thread = True
        End If
        PrintLine(2, "current:" & Tree.data & ":" & vbNewLine & _
                  "Left    :" & If(Tree.L_thread = False, If(Tree.L_child Is Nothing, "null", Tree.L_child.data), "null") & vbNewLine & _
                  "Right   :" & If(Tree.R_thread = False, If(Tree.R_child Is Nothing, "null", Tree.R_child.data), "null") & vbNewLine & _
                   "L_thread:" & If(Tree.L_thread = True, If(Tree.L_child Is Nothing, "null", Tree.L_child.data), "null") & vbNewLine & _
                   "R_thread:" & If(Tree.R_thread = True, If(Tree.R_child Is Nothing, "null", Tree.R_child.data), "null") & vbNewLine)
    End Sub
    Function findNode(ByVal Tree As Tree, ByVal target As Object, ByRef node As Tree)
        If Tree Is Nothing Then Return 0
        If Tree.data = target Then node = Tree : Return node
        If Tree.L_thread = False Then findNode(Tree.L_child, target, node) : If Not node Is Nothing Then Return node
        If Tree.R_thread = False Then findNode(Tree.R_child, target, node) : If Not node Is Nothing Then Return node
        Return node
    End Function
    Function adjustType(ByVal data As Object)
        Return If(IsNumeric(data), CInt(data), CStr(data))
    End Function
End Class
