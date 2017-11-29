Public Class 產生樹測資
    Dim output As String = ""
    Private Sub checkWeight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkWeight.CheckedChanged
        minLabel.Visible = checkWeight.Checked
        minTextbox.Visible = checkWeight.Checked
        maxLabel.Visible = checkWeight.Checked
        maxTextbox.Visible = checkWeight.Checked
    End Sub
    Private Sub checkDegree_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkDegree.CheckedChanged
        degreeTextbox.Enabled = Not checkDegree.Checked
    End Sub
    Private Sub createButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles createButton.Click
        If Not checkInit() Then Exit Sub
        Randomize()
        Dim nodeNumber As Integer = nodeTextbox.Text
        Dim nodeType As Boolean = nodeType1.Checked
        Dim degree As Integer = If(checkDegree.Checked, -1, degreeTextbox.Text)
        Dim min, max As Integer
        Dim weightCheck As Boolean = checkWeight.Checked
        If weightCheck Then min = minTextbox.Text : max = maxTextbox.Text
        If weightCheck = False Then weightTextBox.Text = "" : copyWeightButton.Enabled = False Else copyWeightButton.Enabled = True
        createData(nodeNumber, nodeType, degree, min, max, weightCheck, False)
        copyRButton.Enabled = True : copyVBButton.Enabled = True
    End Sub
    Function checkInit()
        If nodeTextbox.Text = "" Then MsgBox("未填寫node數量") : Return False
        If nodeTextbox.Text <= 1 Then MsgBox("節點數量必須大於1") : Return False
        If nodeType2.Checked AndAlso Val(nodeTextbox.Text) > 26 Then MsgBox("英文節點數不得大於26") : Return False
        If checkWeight.Checked Then
            If minTextbox.Text = "" OrElse maxTextbox.Text = "" Then MsgBox("未填寫最小值或最大值") : Return False
            If Not IsNumeric(minTextbox.Text) OrElse Not IsNumeric(maxTextbox.Text) Then MsgBox("請確定最大最小值輸入的是數字") : Return False
            If Val(minTextbox.Text) > Val(maxTextbox.Text) Then MsgBox("最小值不得大於最大值") : Return False
        End If
        If Not IsNumeric(nodeTextbox.Text) Then MsgBox("請確定節點數量是個數字") : Return False
        If checkDegree.Checked = False AndAlso degreeTextbox.Text = "" Then MsgBox("請確定分支度有輸入") : Return False
        If checkDegree.Checked = False AndAlso Not IsNumeric(degreeTextbox.Text) Then MsgBox("請確定分支度輸入的是數字") : Return False
        If checkDegree.Checked = False AndAlso degreeTextbox.Text <= 0 Then MsgBox("分支度必須大於等於1") : Return False
        Return True
    End Function
    Sub createData(ByVal nodeNumber, ByVal nodeType, ByVal degree, ByVal min, ByVal max, ByVal weightCheck, ByVal outputBool)
        Dim child, parent, cost, unit, alreadyNode, resultVB, resultR As New List(Of String)
        Dim index As Integer
        For i = 1 To nodeNumber
            If nodeType = True Then unit.Add(i) Else unit.Add(Chr(64 + i))
        Next
        For i = 1 To 2
            index = Int(Rnd() * unit.Count)
            alreadyNode.Add(unit(index))
            unit.RemoveAt(index)
        Next
        If weightCheck = True Then cost.Add(Int(Rnd() * (max - min + 1) + min))
        child.Add(alreadyNode.First) : parent.Add(alreadyNode.Last)
        While unit.Count > 0
            index = Int(Rnd() * unit.Count)
            Dim p As String = alreadyNode(Int(Rnd() * alreadyNode.Count))
            While degree <> -1 AndAlso parent.FindAll(Function(X) X = p).Count > degree - 1
                p = alreadyNode(Int(Rnd() * alreadyNode.Count))
            End While
            child.Add(unit(index)) : parent.Add(p)
            alreadyNode.Add(unit(index)) : unit.RemoveAt(index)
            If weightCheck = True Then cost.Add(Int(Rnd() * (max - min + 1) + min))
        End While
        Dim root As String = parent.Find(Function(x) child.Contains(x) = False)
        For i = 0 To parent.Count - 1
            resultR.Add(If(nodeType = True, parent(i), Asc(parent(i)) - 64) & "," & If(nodeType = True, child(i), Asc(child(i)) - 64) & If(i = parent.Count - 1, "", ","))
            resultVB.Add(child(i) & " " & parent(i))
            If weightCheck Then resultVB(i) &= " " & cost(i)
        Next
        If outputBool = False Then
            RootLabel.Text = root
            weightTextBox.Text = Strings.Join(cost.ToArray, ",")
            edgeTextBox.Text = Strings.Join(resultVB.ToArray, vbNewLine)
            edgeRTextBox.Text = Strings.Join(resultR.ToArray, vbNewLine)
        Else
            output &= Strings.Join(resultVB.ToArray, ",")
        End If
    End Sub
    Private Sub copyVBButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles copyVBButton.Click
        My.Computer.Clipboard.SetText(edgeTextBox.Text)
        MsgBox("複製成功")
    End Sub
    Private Sub copyRButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles copyRButton.Click
        My.Computer.Clipboard.SetText(edgeRTextBox.Text)
        MsgBox("複製成功")
    End Sub
    Private Sub copyWeightButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles copyWeightButton.Click
        My.Computer.Clipboard.SetText(weightTextBox.Text)
        MsgBox("複製成功")
    End Sub
    Private Sub copyRcodeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles copyRcodeButton.Click
        Dim data As String = "library(igraph)" & vbNewLine
        data &= "g <- make_empty_graph(directed=TRUE)" & vbNewLine
        data &= "g <- add_vertices(g," & nodeTextbox.Text & ", color='#3399ff')" & vbNewLine
        data &= "g <- add_edges(g,c(" & vbNewLine
        data &= edgeRTextBox.Text & vbNewLine
        data &= "  ))" & vbNewLine
        If nodeType2.Checked = True Then data &= "V(g)$label <- LETTERS[1:" & nodeTextbox.Text & "]" & vbNewLine
        If checkWeight.Checked Then data &= "E(g)$weight <- c(" & weightTextBox.Text & ")" & vbNewLine
        data &= "plot(g, " & vbNewLine
        data &= "     edge.label=E(g)$weight ," & vbNewLine
        data &= "     layout=layout_as_tree(g,root=" & If(nodeType2.Checked = True, Asc(RootLabel.Text) - 64, RootLabel.Text) & ")," & vbNewLine
        data &= "     edge.arrow.size = 0.2" & vbNewLine
        data &= ")"
        My.Computer.Clipboard.SetText(data)
        MsgBox("複製成功")
    End Sub
    Private Sub outputButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles outputButton.Click
        If Not checkInit() Then Exit Sub
        If outputTextBox.Text = "" Then MsgBox("請輸入要幾組資料") : Exit Sub
        If IsNumeric(outputTextBox.Text) = False Then MsgBox("請確定輸入的是數字") : Exit Sub
        If outputTextBox.Text < 1 Then MsgBox("至少要一組資料以上") : Exit Sub
        Randomize()
        output = outputTextBox.Text & vbNewLine
        Dim nodeNumber As Integer = nodeTextbox.Text
        Dim nodeType As Boolean = nodeType1.Checked
        Dim degree As Integer = If(checkDegree.Checked, -1, degreeTextbox.Text)
        Dim min, max As Integer
        Dim weightCheck As Boolean = checkWeight.Checked
        If weightCheck Then min = minTextbox.Text : max = maxTextbox.Text
        For i As Integer = 1 To outputTextBox.Text
            createData(nodeNumber, nodeType, degree, min, max, weightCheck, True)
            output &= vbNewLine
        Next
        FileOpen(1, "output.txt", OpenMode.Output)
        PrintLine(1, output)
        Shell("cmd.exe /c D:\VB\產生樹測資\bin\Debug\output.txt")
        FileClose()
    End Sub
End Class