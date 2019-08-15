Imports System.Threading 

Public Class Promise(Of T)
    Inherits CallBack

    Public Sub New(ByVal func As Action(Of Action(Of T), Action(Of String)))
        MyBase.New(Nothing)
        Dim t As New Thread(Sub() func.Invoke(AddressOf Me.Resolve, AddressOf Me.Reject))
        t.Start()
    End Sub

    Private Sub Resolve(ByVal value As T)
        Me.response = value
        Me.Start()
    End Sub

    Private Sub Reject(ByVal msg As String)
        Throw New Exception(msg)
    End Sub
End Class