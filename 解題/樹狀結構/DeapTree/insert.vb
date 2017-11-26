Public Class Form1
    Class node
        Public data, d As Integer
        Public type As Boolean
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim deap As New SortedDictionary(Of Integer, node)
            Dim input() As Integer = LineInput(1).Split.Select(Function(x) CInt(x)).ToArray
            Dim data() As Integer = LineInput(1).Split.Select(Function(x) CInt(x)).ToArray
            init(deap, input)
            For Each node In data
                addNode(deap, node)
            Next
            PrintLine(2, "deap沒有Root")
            For Each node In deap
                Dim item As node = node.Value
                Dim d As Integer = If(deap.ContainsKey(item.d) = False, Math.Floor(item.d / 2), item.d)
                PrintLine(2, "編號:" & node.Key & ",節點的資料為:" & Trim(item.data) & ",對應到的節點編號是:" & Trim(d))
            Next
            PrintLine(2)
        Next
        FileClose()
        Close()
    End Sub
    Sub init(ByRef deap As SortedDictionary(Of Integer, node), ByVal data() As Integer, Optional ByVal point As Integer = 2)
        For Each node In data
            deap.Add(point, New node With {.data = node, .type = getDeapType(point)})
            point += 1
        Next
        adjustDValue(deap)
    End Sub
    Sub addNode(ByRef deap As SortedDictionary(Of Integer, node), ByVal data As Integer)
        Dim point As Integer = deap.Last.Key + 1
        deap.Add(point, New node With {.data = data, .type = getDeapType(point)})
        adjustDValue(deap, point, True)
        If Not checkNode(deap, point) Then swap(deap, point, deap(point).d) : point = deap(point).d
        If deap.ContainsKey(point) = False Then point = Math.Floor(point / 2)
        While point > 3 AndAlso checkHeap(deap, point)
            swap(deap, point, Math.Floor(point / 2))
            point = Math.Floor(point / 2)
        End While
    End Sub
    Overloads Sub adjustDValue(ByRef deap As SortedDictionary(Of Integer, node), Optional ByVal point As Integer = 0)
        For Each node In deap
            Dim n As Integer = 2 ^ (Math.Floor(Math.Log(node.Key, 2)) - 1)
            point = If(getDeapType(node.Key), node.Key - n, node.Key + n)
            Dim key As Integer = node.Key
            deap(key).d = Point
        Next
    End Sub
    Overloads Sub adjustDValue(ByRef deap As SortedDictionary(Of Integer, node), ByVal key As Integer, ByVal bool As Boolean)
        Dim n As Integer = 2 ^ (Math.Floor(Math.Log(key, 2)) - 1)
        Dim point As Integer = If(getDeapType(key), key - n, key + n)
        deap(key).d = Point
    End Sub
    Function checkNode(ByVal deap As SortedDictionary(Of Integer, node), ByVal key As Integer, Optional ByVal bool As Boolean = False)
        Dim key2 As Integer = deap(key).d
        If deap.ContainsKey(key2) = False Then key2 = Math.Floor(key2 / 2)
        If deap(key).type = True Then
            If deap(key).data > deap(key2).data Then bool = True
        Else
            If deap(key).data < deap(key2).data Then bool = True
        End If
        Return bool
    End Function
    Sub swap(ByRef deap As SortedDictionary(Of Integer, node), ByVal key1 As Integer, ByVal key2 As Integer)
        Dim node As Integer = deap(key1).data
        If deap.ContainsKey(key2) = False Then key2 = Math.Floor(key2 / 2)
        deap(key1).data = deap(key2).data
        deap(key2).data = node
    End Sub
    Function getDeapType(ByVal key As Integer, Optional ByVal bool As Boolean = False)
        Dim d As Integer = Math.Floor(Math.Log(key, 2))
        Dim middle As Integer = Math.Floor(2 ^ d + (2 ^ (d + 1) + 1) / 2 / 2)
        If key < middle Then bool = False Else bool = True
        Return bool
    End Function
    Function checkHeap(ByVal deap As SortedDictionary(Of Integer, node), ByVal key As Integer, Optional ByVal bool As Boolean = False)
        If deap(key).type = True Then
            If deap(key).data > deap(Math.Floor(key / 2)).data Then bool = True
        Else
            If deap(key).data < deap(Math.Floor(key / 2)).data Then bool = True
        End If
        Return bool
    End Function
End Class