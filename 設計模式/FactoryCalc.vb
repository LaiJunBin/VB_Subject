Module FactoryCalc
    Private Interface ICalcable
        Function Calculate(ByVal a As Integer, ByVal b As Integer)
    End Interface
    Private Class Addition
        Implements ICalcable
        Public Function Calculate(ByVal a As Integer, ByVal b As Integer) As Object Implements ICalcable.Calculate
            Return a + b
        End Function
    End Class
    Private Class Subtraction
        Implements ICalcable
        Public Function Calculate(ByVal a As Integer, ByVal b As Integer) As Object Implements ICalcable.Calculate
            Return a - b
        End Function
    End Class
    Private Class Multiplication
        Implements ICalcable
        Public Function Calculate(ByVal a As Integer, ByVal b As Integer) As Object Implements ICalcable.Calculate
            Return a * b
        End Function
    End Class
    Private Class Division
        Implements ICalcable
        Public Function Calculate(ByVal a As Integer, ByVal b As Integer) As Object Implements ICalcable.Calculate
            Return a / b
        End Function
    End Class
    Public Class CalcFactory
        Public Shared Function create(ByVal symbol As String)
            Dim name = NS.GetNamespace
            Return CType(Activator.CreateInstance(Type.GetType(name & "+" & symbol)), ICalcable)
        End Function
    End Class
    Private Class NS
        Private Shared name As String
        Private Sub New()
            name = Me.GetType.DeclaringType.FullName
        End Sub
        Public Shared Function GetNamespace()
            If name Is Nothing Then Dim obj As New NS
            Return name
        End Function
    End Class
    Sub Main()
        Dim operation As New Dictionary(Of String, ICalcable)
        Dim a As Integer = 100
        Dim b As Integer = 50
        operation.Add("+", CalcFactory.create("Addition"))
        operation.Add("-", CalcFactory.create("Subtraction"))
        operation.Add("*", CalcFactory.create("Multiplication"))
        operation.Add("/", CalcFactory.create("Division"))
        print("a = " & a & ", b = " & b)
        print("a + b = " & operation("+").Calculate(a, b))
        print("a - b = " & operation("-").Calculate(a, b))
        print("a * b = " & operation("*").Calculate(a, b))
        print("a / b = " & operation("/").Calculate(a, b))
        pause()
    End Sub
End Module