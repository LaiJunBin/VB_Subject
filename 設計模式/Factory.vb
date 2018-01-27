Module Factory
    Public Interface Adventurer
        Function getCharacter() As String
    End Interface
    Public Interface TrainingCamp
        Function trainAdventurer() As Adventurer
    End Interface
    Public Class Warrior
        Implements Adventurer
        Public Function getCharacter() As String Implements Adventurer.getCharacter
            Print("我是鬥士")
            Return Me.GetType.Name
        End Function
    End Class
    Public Class Archer
        Implements Adventurer
        Public Function getCharacter() As String Implements Adventurer.getCharacter
            Print("我是弓箭手")
            Return Me.GetType.Name
        End Function
    End Class
    Public Class ArcherTrainingCamp
        Implements TrainingCamp
        Public Function trainAdventurer() As Adventurer Implements TrainingCamp.trainAdventurer
            Print("訓練一個弓箭手")
            Return New Archer
        End Function
    End Class
    Public Class WarriorTrainingCamp
        Implements TrainingCamp
        Public Function trainAdventurer() As Adventurer Implements TrainingCamp.trainAdventurer
            Print("訓練一個鬥士")
            Return New Warrior
        End Function
    End Class
    Sub Main()
        Dim trainingCamp As Object = New ArcherTrainingCamp
        Dim player1 As Adventurer = trainingCamp.trainAdventurer
        trainingCamp = New WarriorTrainingCamp
        Dim player2 As Adventurer = trainingCamp.trainAdventurer
        Print("player1 =", player1.getCharacter)
        Print("player2 =", player2.getCharacter)
        pause()
    End Sub
End Module