Imports System.Threading

Public Class CallBack
    Inherits AsyncFunc(Of Object)

    Public Sub New(ByVal func As [Delegate], ByVal ParamArray params() As Object)
        MyBase.New(func)
        Me.params = params
    End Sub

    Public Function ThenDo(ByVal Func As Func(Of Object, Object)) As CallBack
        Me.callback = New CallBack(Func)
        Return Me.callback
    End Function

    Protected Friend Sub Start(Optional ByVal value As Object = Nothing)
        Dim t As New Thread(Sub()
                                If Not Me.func Is Nothing Then
                                    If Me.func.Method.GetParameters().Length = 0 Then
                                        Me.response = Me.func.DynamicInvoke()
                                    Else
                                        Me.response = Me.func.DynamicInvoke(If(value Is Nothing AndAlso Me.params.Length <> 0, Me.params, {value}))
                                    End If
                                End If
                                If Not Me.callback Is Nothing Then Me.callback.Start(Me.response)
                            End Sub)
        t.Start()
    End Sub

End Class