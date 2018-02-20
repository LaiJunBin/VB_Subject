Module Adapter
    Public Interface Archer
        Sub Shot()
    End Interface
    Public Interface Wizard
        Sub FireBall()
    End Interface
    Public Class ArcherPlayer
        Implements Archer
        Public Sub Shot() Implements Archer.Shot
            print("射箭")
        End Sub
    End Class
    Public Class Adapter
        Implements Wizard
        Private Archer As Archer
        Sub New(ByVal archer As Archer)
            Me.Archer = archer
        End Sub
        Public Sub FireBall() Implements Wizard.FireBall
            print("在弓箭上點火")
            Archer.Shot()
            print("火球飛出去了!")
        End Sub
    End Class
    Sub Main()
        Dim player As New Adapter(New ArcherPlayer())
        player.FireBall()
        pause()
    End Sub
End Module