Public Class Form1
    Class Trie
        Public data, current As String
        Public child As New Dictionary(Of String, Trie)
        Public height As Integer
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Do Until EOF(1)
            Dim n As Integer = LineInput(1)
            Dim Trie As New Trie
            For w = 1 To n
                Dim data As String = LineInput(1)
                createTrie(Trie, data, Mid(data, 1, 1))
            Next
            DictionarySort(Trie)
            traversal(Trie)
        Loop
        FileClose()
        Close()
    End Sub
    Sub createTrie(ByRef Trie As Trie, ByVal data As String, ByVal current As String)
        If Trie.data = data Then Return
        If Trie.child.ContainsKey(current) Then createTrie(Trie.child(current), data, Mid(data, 1, current.Length + 1)) : Return
        Trie.child.Add(current, New Trie With {.data = current, .current = Strings.Right(current, 1), .height = Trie.height + 1})
        createTrie(Trie.child(current), data, Mid(data, 1, current.Length + 1))
    End Sub
    Sub DictionarySort(ByRef Trie As Trie)
        If Trie.child.Count = 0 Then Return
        Dim temp As New SortedDictionary(Of Integer, Trie)
        For Each item In Trie.child
            temp.Add(Asc(item.Value.current), item.Value)
        Next
        Trie.child.Clear()
        For Each item In temp
            Trie.child.Add(item.Value.data, item.Value)
            DictionarySort(Trie.child(item.Value.data))
        Next
    End Sub
    Sub traversal(ByVal Trie As Trie, Optional ByRef result As String = "", Optional ByVal ht As Integer = 1)
        If result = "" Then result = Space(Trie.height * 3)
        If Trie.current Is Nothing Then result &= "[ ]" Else result &= "[" & Trie.current & "]"
        If Trie.child.Count = 0 Then PrintLine(2, result) : result = "" : Return
        For Each item In Trie.child
            traversal(item.Value, result, ht + 1)
        Next
    End Sub
End Class