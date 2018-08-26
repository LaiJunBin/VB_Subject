Imports System.Text
Public MustInherit Class IExpression
    Inherits Expression
    Protected maxDepth As Integer = 3
    Public MustOverride Sub process(ByRef funcName As String, ByRef funcParams() As String, ByRef source As StringBuilder, ByRef target As String, Optional ByVal useReturn As Boolean = True)
    Public MustOverride Sub _process(ByRef source As StringBuilder, ByVal var As List(Of String), ByVal maxDepth As Integer, Optional ByVal depth As Integer = 0, Optional ByVal tabCount As Integer = 1)
End Class
