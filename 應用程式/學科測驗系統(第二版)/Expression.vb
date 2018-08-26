Imports Evaluator
Imports System.Text

Public Class Expression

    Public Variable_Count As Integer = 5 'Max = 26
    Public MinNumber As Integer = -20
    Public MaxNumber As Integer = 20
    Public ExpressionNames As New List(Of String)

    Private variable As List(Of String) = New Integer(Variable_Count - 1) {}.Select(Function(x, i) Chr(i + 65).ToString).ToList
    Private source As New StringBuilder()

    Private stringChanger As MethodResults
    Private funcName As String
    Private funcParams() As String = {}
    Private params As New Dictionary(Of String, Integer)
    Private op As List(Of String) = {"+", "-", "*", "/", "\", "Mod"}.ToList
    Private co As List(Of String) = {">", ">=", "=", "<=", "<"}.ToList
    Private boolOp As List(Of String) = {"Or", "And", "Xor", "=", "<>"}.ToList
    Private target As String

    Public Sub CreateExpression()
        source = New StringBuilder
        params = New Dictionary(Of String, Integer)
        funcParams = New String() {}
        RandExpression()
        For Each param In funcParams
            Dim value = rand(MinNumber, MaxNumber)
            params.Add(param, value)
        Next
        source.AppendLine("End Function")
        source.Insert(0, "Public Function " & GetFunctionName() & vbNewLine)
    End Sub

    Public Function GetSource()
        Return source.ToString
    End Function

    Public Function GetFunctionName()
        Return funcName & "( _ " & vbNewLine & Strings.Join(funcParams.Select(Function(x) StrDup(10, " ") & "ByVal " & x & " As Integer").ToArray, ", _ " & vbNewLine) & ")"
    End Function

    Public Function GetCallFunctionExpression()
        Return funcName & "(" & Strings.Join(params.Values.Select(Function(x) x.ToString).ToArray, ",") & ")"
    End Function

    Protected Function rand(ByVal min As Integer, ByVal max As Integer) As Integer
        Randomize()
        Return Int(Rnd() * (max - min + 1) + min)
    End Function

    Protected Function Probability(ByVal p As Integer)
        Return rand(1, 100) <= p
    End Function

    Public Sub RandExpression()
        Dim index As Integer = rand(0, ExpressionNames.Count - 1)
        Dim expressionName As String = ExpressionNames(index)
        Dim NS = Me.GetType.Namespace
        Dim expression = Activator.CreateInstance(Type.GetType(NS & "." & expressionName))
        expression.process(funcName, funcParams, source, target)
    End Sub

    Protected Function SampleVariable(Optional ByVal count As Integer = 1)
        Dim _var As List(Of String) = variable.GetRange(0, Variable_Count)
        Dim return_var As New List(Of String)
        Do Until return_var.Count = count
            Dim index As Integer = rand(0, _var.Count - 1)
            return_var.Add(_var(index))
            _var.RemoveAt(index)
        Loop
        Return If(count = 1, return_var.First, return_var)
    End Function

    Protected Function SampleVariable(ByVal var As List(Of String), Optional ByVal count As Integer = 1)
        Dim _var As List(Of String) = var.GetRange(0, var.Count)
        Dim return_var As New List(Of String)
        Do Until return_var.Count = count
            Dim index As Integer = rand(0, _var.Count - 1)
            return_var.Add(_var(index))
            _var.RemoveAt(index)
        Loop
        Return If(count = 1, return_var.First, return_var)
    End Function

    Protected Function CreateCompareExpression(ByVal a As String, ByVal b As String, ByVal var As List(Of String))
        Return a & " " & SampleVariable(op) & " " & b & " " & SampleVariable(co) & " " & If(Probability(50), rand(MinNumber, MaxNumber), SampleVariable(var))
    End Function

    Protected Function CreateCompareExpression(ByVal a As String, ByVal b As String)
        Return a & " " & SampleVariable(op) & " " & b & " " & SampleVariable(co) & " " & rand(MinNumber, MaxNumber)
    End Function

    Protected Function CreateCalcExpression(ByVal var As List(Of String))
        Dim _var As String = SampleVariable(var)
        Return _var & " = " & _var & " " & SampleVariable(op) & " " & If(Probability(50), rand(MinNumber, MaxNumber), SampleVariable(var))
    End Function

    Function CreateBoolExpression()
        Dim bool1 As String = If(Probability(50), "True", "False")
        Dim bool2 As String = If(Probability(50), "True", "False")
        Return bool1 & " " & SampleVariable(boolOp) & " " & bool2
    End Function

    Function GetRandBoolOperation()
        Return SampleVariable(boolOp)
    End Function

    Function GetRandOperation()
        Return SampleVariable(op)
    End Function

    Public Function Run()
        Try
            stringChanger = Eval.CreateVirtualMethod(New VBCodeProvider().CreateCompiler(), source.ToString(), funcName, New VBLanguage(), False)
        Catch ce As CompilationException
            MessageBox.Show(Me, "Compilation Errors: " + ce.ToString())
            End
        End Try
        Try
            Dim Res
            If params.Count > 0 Then
                Dim values() As Object = params.Values.Select(Function(x) CObj(x)).ToArray
                Res = stringChanger.Invoke(values)
            Else
                Res = stringChanger.Invoke()
            End If
            If params.ContainsKey(target) AndAlso Res = params(target) Then
                Throw New Exception()
            End If
            'If Res.ToString.Contains(".") AndAlso Res.ToString.Length >= 4 Then
            ' source.Replace("Return " & target, "Return Int(" & target & ")")
            'Return Run()
            'End If
            Return Res
        Catch tie As System.Reflection.TargetInvocationException
            MessageBox.Show(Me, "Method-Thrown Exception: " + Environment.NewLine + tie.InnerException.ToString())
            End
        End Try
    End Function
End Class