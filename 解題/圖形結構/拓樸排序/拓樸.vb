Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim data() As String = {"1,2 1,6 4,5 3,5 2,4 2,3 3,7 7,8 5,7 6,5 5,8", "1,2 2,6 2,5 3,5 3,6 1,3 1,4 4,6"}
        For i = 0 To UBound(data)
            Dim G() As String = data(i).Split
            Dim predecessor, successor, preNothing As New List(Of Integer)
            Dim path As String = ""
            For j = 0 To UBound(G)
                Dim xy() As String = G(j).Split({",", " ", vbTab}, StringSplitOptions.RemoveEmptyEntries)
                predecessor.Add(xy(0)) : successor.Add(xy(1))
            Next
            While predecessor.Count > 0
                preNothing = successor.Distinct.ToList
                Dim search As List(Of Integer) = predecessor.Except(preNothing).ToList
                While search.Count > 0
                    path &= search(0) & ","
                    Dim count As Integer = predecessor.FindAll(Function(x) x = search(0)).Count
                    For j = 1 To count
                        Dim d As Integer = predecessor.IndexOf(search(0))
                        successor.RemoveAt(d) : predecessor.RemoveAt(d)
                    Next
                    search.RemoveAt(0)
                End While
            End While
            For j = 0 To preNothing.Count - 1 : path &= preNothing(j) & "," : Next
            MsgBox(Strings.Left(path, path.Length - 1))
        Next
        Close()
    End Sub
End Class