Module Observer
    Public MustInherit Class Subject
        Protected List As New List(Of Adventurer)
        Public Sub Add(ByVal player As Adventurer)
            List.Add(player)
        End Sub
        Public Sub AddRange(ByVal ParamArray players() As Adventurer)
            For Each player In players
                List.Add(player)
            Next
        End Sub
        Public Sub Remove(ByVal player As Adventurer)
            List.Remove(player)
        End Sub
        Public MustOverride Sub SendQuestions(ByVal questions As String)
    End Class
    Public Class Association
        Inherits Subject
        Public Overrides Sub SendQuestions(ByVal questions As String)
            For Each player In List
                player.GetQuestions(questions)
            Next
        End Sub
    End Class
    Public MustInherit Class Adventurer
        Protected Name As String
        Sub New(ByVal name As String)
            Me.Name = Name
        End Sub
        Public MustOverride Sub GetQuestions(ByVal questions As String)
    End Class
    Public Class Lancer
        Inherits Adventurer
        Sub New(ByVal name As String)
            MyBase.New(name)
        End Sub
        Public Overrides Sub GetQuestions(ByVal questions As String)
            print(Me.Name & "什麼任務都接受!")
        End Sub
    End Class
    Public Class Bard
        Inherits Adventurer
        Sub New(ByVal name As String)
            MyBase.New(name)
        End Sub
        Public Overrides Sub GetQuestions(ByVal questions As String)
            If questions.Length > 20 Then
                print(Me.Name & "任務太難了，不做!")
            Else
                print(Me.Name & "接受任務!")
            End If
        End Sub
    End Class
    Public Class GunMan
        Inherits Adventurer
        Sub New(ByVal name As String)
            MyBase.New(name)
        End Sub
        Public Overrides Sub GetQuestions(ByVal questions As String)
            If questions.Length < 20 Then
                print(Me.Name & "任務太簡單，不做!")
            Else
                print(Me.Name & "接受任務!")
            End If
        End Sub
    End Class
    Sub Main()
        Dim association As Subject = New Association
        Dim lancer As New Lancer("lancer")
        Dim player As New Lancer("Tom")
        Dim bard As New Bard("bard")
        Dim gunMan As New GunMan("gunMan")
        association.AddRange(lancer, player, bard, gunMan)
        print("派送簡單任務")
        association.SendQuestions("Run Easy Task")
        print("派送困難任務")
        association.SendQuestions("Run Hard Hard Hard Hard Task........")
        print("lancer 取消通知")
        association.Remove(lancer)
        association.SendQuestions("Run Normal Task")
        pause()
    End Sub
End Module