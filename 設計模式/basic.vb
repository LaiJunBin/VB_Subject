Module basic
    Sub print(ByVal ParamArray data())
        Console.WriteLine(Strings.Join(data, " "))
    End Sub
    Sub pause()
        Console.WriteLine("按下任意鍵結束...")
        Console.ReadKey()
    End Sub
End Module
