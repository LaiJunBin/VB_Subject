Module AbstractFactory
    '角色(冒險家)
    Public MustInherit Class Adventurer
        Protected weapon As Weapon
        Protected clothes As Clothes
        MustOverride Sub display()
        Sub setWeapon(ByVal item As Weapon)
            Me.weapon = item
        End Sub
        Sub setClothes(ByVal item As Clothes)
            Me.clothes = item
        End Sub
    End Class
    '訓練場介面
    Public Interface TrainingCamp
        Function trainAdventurer()
    End Interface
    '鬥士
    Public Class Warrior
        Inherits Adventurer
        Public Overrides Sub display()
            print("我是鬥士,裝備:")
            weapon.display()
            clothes.display()
        End Sub
    End Class
    '弓箭手
    Public Class Archer
        Inherits Adventurer
        Public Overrides Sub display()
            print("我是弓箭手,裝備:")
            weapon.display()
            clothes.display()
        End Sub
    End Class
    '弓箭手訓練場
    Public Class ArcherTrainingCamp
        Implements TrainingCamp
        Private factor As New ArcherEquipFactory
        Public Function trainAdventurer() As Object Implements TrainingCamp.trainAdventurer
            Dim archer As New Archer
            archer.setClothes(factor.makeArmor)
            archer.setWeapon(factor.makeWeapon)
            print("訓練一個弓箭手")
            Return archer
        End Function
    End Class
    '鬥士訓練場
    Public Class WarriorTrainingCamp
        Implements TrainingCamp
        Private factory As New WarriorEquipFactory
        Public Function trainAdventurer() As Object Implements TrainingCamp.trainAdventurer
            Dim warrior As New Warrior
            warrior.setClothes(factory.makeArmor)
            warrior.setWeapon(factory.makeWeapon)
            print("訓練一個鬥士")
            Return warrior
        End Function
    End Class
    '裝備工廠介面
    Interface EquipFactory
        Function makeWeapon()
        Function makeArmor()
    End Interface
    '武器
    MustInherit Class Weapon
        Protected atk, range As Integer
        Sub display()
            print(Me.GetType.Name & " atk = " & atk & " , range = " & range)
        End Sub
        Sub setAtk(ByVal value As Integer)
            Me.atk = value
        End Sub
        Sub setRange(ByVal value As Integer)
            Me.range = value
        End Sub
    End Class
    '上衣
    MustInherit Class Clothes
        Protected def As Integer
        Sub display()
            print(Me.GetType.Name & " def = " & def)
        End Sub
        Sub setDef(ByVal value As Integer)
            Me.def = value
        End Sub
    End Class
    '鬥士裝備工廠
    Class WarriorEquipFactory
        Implements EquipFactory
        Public Function makeArmor() As Object Implements EquipFactory.makeArmor
            Dim armor As New Armor
            armor.setDef(10)
            Return armor
        End Function
        Public Function makeWeapon() As Object Implements EquipFactory.makeWeapon
            Dim longSword As New LongSword
            longSword.setAtk(10)
            longSword.setRange(5)
            Return longSword
        End Function
    End Class
    '弓箭手裝備工廠
    Class ArcherEquipFactory
        Implements EquipFactory
        Public Function makeArmor() As Object Implements EquipFactory.makeArmor
            Dim leather As New Leather
            leather.setDef(10)
            Return leather
        End Function
        Public Function makeWeapon() As Object Implements EquipFactory.makeWeapon
            Dim bow As New Bow
            bow.setAtk(5)
            bow.setRange(15)
            Return bow
        End Function
    End Class
    '鬥士武器
    Class LongSword
        Inherits Weapon
    End Class
    '鬥士上衣
    Class Armor
        Inherits Clothes
    End Class
    '弓箭手武器
    Class Bow
        Inherits Weapon
    End Class
    '弓箭手上衣
    Class Leather
        Inherits Clothes
    End Class
    Sub Main()
        Dim warriorTrainingCamp As TrainingCamp = New WarriorTrainingCamp
        Dim player1 As Adventurer = warriorTrainingCamp.trainAdventurer
        Dim archerTrainingCamp As TrainingCamp = New ArcherTrainingCamp
        Dim player2 As Adventurer = archerTrainingCamp.trainAdventurer
        player1.display()
        player2.display()
        pause()
    End Sub
End Module