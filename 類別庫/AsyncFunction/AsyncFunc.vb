Imports System.Threading

Public Class AsyncFunc(Of T)
    Protected Friend func As [Delegate]
    Protected Friend response As T
    Protected Friend params() As Object
    Protected Friend callback As CallBack

    Public Sub New(ByVal func As [Delegate])
        Me.func = func
    End Sub

    Public Function GetResponse() As T
        Return Me.response
    End Function

    Default ReadOnly Property Item(<[ParamArray]()> ByVal params() As Object) As CallBack
        Get
            Dim callback As New CallBack(Me.func, params)
            callback.Start()
            Return callback
        End Get
    End Property

End Class