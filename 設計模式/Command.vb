Module Command
    '廚房人員
    Interface KitchenWorker
        Sub FinishOrder()
    End Interface
    '負責飲料的人員
    Class Barkeep
        Implements KitchenWorker
        Public Sub FinishOrder() Implements KitchenWorker.FinishOrder
            print("完成飲料!")
        End Sub
    End Class
    '負責點心的人員
    Class Chef
        Implements KitchenWorker
        Public Sub FinishOrder() Implements KitchenWorker.FinishOrder
            print("完成點心!")
        End Sub
    End Class
    MustInherit Class Order
        Protected Receiver As KitchenWorker
        Protected Name As String
        Sub New(ByVal receiver As KitchenWorker)
            Me.Receiver = receiver
        End Sub
        Sub SendOrder()
            Receiver.FinishOrder()
        End Sub
        Function GetName()
            Return Me.Name
        End Function
    End Class
    Class DrinkOrder
        Inherits Order
        Sub New(ByVal receiver As KitchenWorker)
            MyBase.New(receiver)
            MyBase.Name = "飲料"
        End Sub
    End Class
    Class SnackOrder
        Inherits Order
        Sub New(ByVal receiver As KitchenWorker)
            MyBase.New(receiver)
            MyBase.Name = "點心"
        End Sub
    End Class
    Class Waitress
        Private Qty As New Dictionary(Of String, Integer)
        Private orderList As New List(Of Order)
        Sub SetOrder(ByVal order As Order)
            Dim orderName As String = order.GetName
            If Qty.ContainsKey(orderName) Then
                If Qty(orderName) > 0 Then
                    print("增加" & orderName & "訂單")
                    Qty(orderName) -= 1
                    orderList.Add(order)
                Else
                    print(orderName & "賣完了!")
                End If
            Else
                print("沒有這個訂單!")
            End If
        End Sub
        Sub CleanOrder(ByVal order As Order)
            Dim orderName As String = order.GetName
            print("取消" & orderName & "訂單")
            Qty(orderName) += 1
            orderList.Remove(order)
        End Sub
        Sub SetQty(ByVal Name As String, ByVal Qt As Integer)
            Me.Qty.Add(Name, Qt)
        End Sub
        Sub NotifyBaker()
            For Each Order In orderList
                Order.SendOrder()
            Next
            orderList.Clear()
        End Sub
    End Class
    Sub Main()
        '準備
        Dim snackChef As New Chef
        Dim barkeep As New Barkeep
        Dim snackOrder As New SnackOrder(snackChef)
        Dim drinkOrder As New DrinkOrder(barkeep)
        Dim cuteGirl As New Waitress
        '設定訂單
        cuteGirl.SetQty("點心", 2)
        cuteGirl.SetQty("飲料", 4)
        '客人點餐
        cuteGirl.SetOrder(snackOrder)
        cuteGirl.SetOrder(snackOrder)
        cuteGirl.SetOrder(drinkOrder)
        cuteGirl.SetOrder(drinkOrder)
        cuteGirl.SetOrder(drinkOrder)
        print("---嘗試取消訂單---")
        cuteGirl.CleanOrder(snackOrder)
        cuteGirl.SetOrder(snackOrder)
        print("----點餐完成-----")
        cuteGirl.NotifyBaker()
        print("再次下訂點心(庫存不足)")
        cuteGirl.SetOrder(snackOrder)
        pause()
    End Sub
End Module
