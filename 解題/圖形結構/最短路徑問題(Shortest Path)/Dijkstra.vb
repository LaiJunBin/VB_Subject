Public Class form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim n() As Integer = LineInput(1).Split.Select(Function(x) CInt(x)).ToArray
        Dim map(n(0)) As Integer
        Dim data, d As New List(Of Object)
        For i = 2 To n(0) : map(i) = 2147483647 : d.Add(i) : Next
        For i = 1 To n(1)
            data.Add(LineInput(1))
        Next
        For i = 0 To data.Count - 1
            Dim temp() As Integer = data(i).ToString.Split({" "}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) CInt(x)).ToArray
            If temp(0) = 1 Then
                map(temp(1)) = temp(2)
            End If
        Next
        While d.Count > 0
            Dim index As Integer = getMinValue(map, d)
            d.Remove(index)
            Dim targetData As List(Of Object) = data.FindAll(Function(x) InStr(x, index) = 1).ToList
            visit(targetData, map)
        End While
        For i = 1 To UBound(map)
            Print(2, Trim(map(i)) & " ")
        Next
        FileClose()
        Close()
    End Sub
    Function getMinValue(ByVal map() As Integer, ByVal d As List(Of Object))
        Dim temp As Integer = 2147483647
        For i = 0 To d.Count - 1
            If map(d(i)) < temp Then temp = map(d(i))
        Next
        Return Array.IndexOf(map, temp)
    End Function
    Sub visit(ByVal targetData As List(Of Object), ByRef map() As Integer)
        While targetData.Count > 0
            Dim temp() As Integer = targetData.First.ToString.Split({" "}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) CInt(x)).ToArray
            map(temp(1)) = Math.Min(map(temp(1)), map(temp(0)) + temp(2))
            targetData.RemoveAt(0)
        End While
    End Sub
End Class