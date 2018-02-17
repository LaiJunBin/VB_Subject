Module StrategySort
    Class Student
        Public StudentNumber As Integer
        Public StudentName As String
        Public Score As Integer
        Private Sub New()
        End Sub
        Public Shared Function Create(ByVal name As String, ByVal score As Integer)
            Dim student As New Student
            Static count As Integer = 1
            student.StudentNumber = count
            student.StudentName = name
            student.Score = score
            count += 1
            Return student
        End Function
        Public Overrides Function ToString() As String
            Return Me.StudentNumber & "." & Me.StudentName & "=>" & Me.Score
        End Function
    End Class
    Class SortStudentByNumber
        Implements IComparer(Of Student)
        Public Function Compare(ByVal x As Student, ByVal y As Student) As Integer Implements System.Collections.Generic.IComparer(Of Student).Compare
            Return x.StudentNumber < y.StudentNumber
        End Function
    End Class
    Class SortStudentByName
        Implements IComparer(Of Student)
        Public Function Compare(ByVal x As Student, ByVal y As Student) As Integer Implements System.Collections.Generic.IComparer(Of Student).Compare
            Return x.StudentName < y.StudentName
        End Function
    End Class
    Class SortStudentByScore
        Implements IComparer(Of Student)
        Public Function Compare(ByVal x As Student, ByVal y As Student) As Integer Implements System.Collections.Generic.IComparer(Of Student).Compare
            Return x.Score < y.Score
        End Function
    End Class
    Sub showClass(ByVal classRoom As List(Of Student))
        For Each Student In classRoom
            print(Student.ToString)
        Next
    End Sub
    Sub Main()
        Dim classRoom As New List(Of Student)
        classRoom.Add(Student.Create("Banana", 75))
        classRoom.Add(Student.Create("Cython", 99))
        classRoom.Add(Student.Create("Apple", 90))
        print("未排序")
        showClass(classRoom)
        print("以學號排序")
        classRoom.Sort(New SortStudentByNumber)
        showClass(classRoom)
        print("以姓名排序")
        classRoom.Sort(New SortStudentByName)
        showClass(classRoom)
        print("以分數排序")
        classRoom.Sort(New SortStudentByScore)
        showClass(classRoom)
        pause()
    End Sub
End Module