Module Decorator
    Interface ISchoolable
        Sub Exam()
    End Interface
    Class Student
        Implements ISchoolable
        Private Name As String
        Sub New(ByVal name As String)
            Me.Name = name
        End Sub
        Public Sub exam() Implements ISchoolable.Exam
            print(Me.Name & "考試")
        End Sub
    End Class
    MustInherit Class Title
        Implements ISchoolable
        Protected student As ISchoolable
        Public Overridable Sub Exam() Implements ISchoolable.Exam
            student.Exam()
        End Sub
    End Class
    Class TitleStudyMaster
        Inherits Title
        Sub New(ByVal stud As ISchoolable)
            MyBase.student = stud
        End Sub
        Overrides Sub Exam()
            student.Exam()
            print("怎麼考都滿分")
        End Sub
    End Class
    Class TitleModelStudent
        Inherits Title
        Sub New(ByVal stud As ISchoolable)
            MyBase.student = stud
        End Sub
        Overrides Sub Exam()
            student.Exam()
            print("寫的很認真")
        End Sub
    End Class
    Sub Main()
        Dim person As New Student("person")
        print("----學生----")
        person.exam()
        Dim studyMasterPerson As New TitleStudyMaster(person)
        print(vbNewLine, "----學霸----")
        studyMasterPerson.Exam()
        Dim modelPerson As New TitleModelStudent(person)
        print(vbNewLine, "---模範生---")
        modelPerson.Exam()
        Dim superPerson As New TitleModelStudent(studyMasterPerson)
        print(vbNewLine, "--是模範生又是學霸--")
        superPerson.Exam()
        print() : pause()
    End Sub
End Module