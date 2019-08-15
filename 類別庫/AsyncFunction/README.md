# AsyncFunction Library

> JavaScript Promise And CallBack, Async Function implement in Visual Basic

## Example

### Class Declare
```vb

    Class User
        Public ID As String
        Public Username As String
    End Class

    Class UserService
        Private http As New System.Net.WebClient
        Private url As String = "http://localhost:8000/api/"

        Public Function GetUsers() As Promise(Of User())
            Return New Promise(Of User())(
                Function(Resolve, Reject)
                    Dim data As String = Me.http.DownloadString(url + "users")
                    Dim users() As User = JsonConvert.DeserializeObject(Of User())(data)
                    Resolve(users)
                End Function
            )

        End Function

    End Class

```

### Function Declare
```vb
    Function Add(ByVal a As Integer, ByVal b As Integer)
        Return a + b
    End Function
```

### Main Program
```vb
    Sub Main()
        Debug.Print("Program Start.")
        Dim UserService As New UserService

        UserService.GetUsers().ThenDo(
            Function(users As User())
                For Each User In users
                    Debug.Print(User.ID & ", " & User.Username)
                Next
            End Function
        ).ThenDo(Function()
                     Debug.Print("Done.")
                 End Function)


        Dim AddFunction As Func(Of Integer, Integer, Integer) = AddressOf Add
        Dim AsyncAddFunction As New AsyncFunc(Of Integer)(AddFunction)
        Dim AddResult As CallBack = AsyncAddFunction(5, 10)

        Debug.Print(AddResult.GetResponse)
        Threading.Thread.Sleep(100)
        Debug.Print(AddResult.GetResponse)

        AsyncAddFunction(10, 20).
            ThenDo(Function(Res)
                       Debug.Print(Res)
                   End Function)

        Debug.Print("Hello World.")

    End Sub
```

### Output:
```vb
Program Start.

15
Hello World.
30
1, admin
2, Tom
3, Judy
Done.
```