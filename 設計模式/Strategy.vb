Module Strategy
    Interface FlightStrategy
        Sub execute()
    End Interface
    Class NormalAttack
        Implements FlightStrategy
        Public Sub execute() Implements FlightStrategy.execute
            print("使用普通攻擊!")
        End Sub
    End Class
    Class UseSkill
        Implements FlightStrategy
        Public Sub execute() Implements FlightStrategy.execute
            print("使用技能!")
        End Sub
    End Class
    Class UseItem
        Implements FlightStrategy
        Public Sub execute() Implements FlightStrategy.execute
            print("使用道具!")
        End Sub
    End Class
    Class Adventurer
        Private flightStrategy As FlightStrategy
        Sub attack()
            If Me.flightStrategy Is Nothing Then
                flightStrategy = New NormalAttack
            End If
            flightStrategy.execute()
        End Sub
        Sub choiceStrategy(ByVal strategy As FlightStrategy)
            Me.flightStrategy = strategy
        End Sub
    End Class
    Sub Main()
        Dim player As New Adventurer
        player.attack()
        player.choiceStrategy(New UseItem)
        player.attack()
        player.choiceStrategy(New UseSkill)
        player.attack()
        pause()
    End Sub
End Module
