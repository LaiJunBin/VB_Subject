Module SimpleFactory
    Public Class TrainingCamp
        Public Function trainAdventurer(ByVal type As String) As Adventurer
            Select Case type
                Case "warrior"
                    print("訓練一個鬥士")
                    Return New Warrior
                Case "archer"
                    print("訓練一個弓箭手")
                    Return New Archer
                Case Else
                    Return Nothing
            End Select
        End Function
    End Class
    Public Interface Adventurer
        Function getCharacter() As String
    End Interface
    Public Class Warrior
        Implements Adventurer
        Public Function getCharacter() As String Implements Adventurer.getCharacter
            print("我是鬥士")
            Return Me.GetType.Name
        End Function
    End Class
    Public Class Archer
        Implements Adventurer
        Public Function getCharacter() As String Implements Adventurer.getCharacter
            print("我是弓箭手")
            Return Me.GetType.Name
        End Function
    End Class
    Sub Main()
        Dim Village As New TrainingCamp
        Dim player1 As Adventurer = Village.trainAdventurer("warrior")
        Dim player2 As Adventurer = Village.trainAdventurer("archer")
        print("player1是", player1.getCharacter())
        print("player2是", player2.getCharacter())
        pause()
    End Sub
    
End Module