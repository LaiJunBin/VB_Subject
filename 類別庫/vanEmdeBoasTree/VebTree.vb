Public Class VebTree
    Private Class VebNode
        Public universeSize As Integer
        Public min As Integer
        Public max As Integer
        Public summary As VebNode
        Public cluster() As VebNode
        Public Sub New(ByVal universeSize As Integer)
            Me.universeSize = universeSize
            Me.min = VebTree.NULL
            Me.max = VebTree.NULL
            initializeChildren(Me.universeSize)
        End Sub
        Private Sub initializeChildren(ByVal universeSize As Integer)
            If (universeSize <= VebTree.BASE_SIZE) Then
                Me.summary = Nothing
                Me.cluster = Nothing
            Else
                Dim childUnivereSize As Integer = higherSquareRoot()
                Me.summary = New VebNode(childUnivereSize)
                Me.cluster = New VebNode(childUnivereSize - 1) {}
                Me.cluster = Me.cluster.Select(Function(x) New VebNode(childUnivereSize)).ToArray
            End If
        End Sub
        Private Function higherSquareRoot() As Integer
            Return Math.Pow(2, Math.Ceiling(((Math.Log10(Me.universeSize) / Math.Log10(2)) / 2)))
        End Function
    End Class
    ''' <summary>
    ''' 取得Veb樹的基底大小的預設值
    ''' </summary>
    Public Const BASE_SIZE As Integer = 2
    ''' <summary>
    ''' 取得Veb樹NULL的預設值-1
    ''' </summary>
    ''' <remarks></remarks>
    Public Const NULL As Integer = -1
    Private root As VebNode
    ''' <summary>
    ''' 建立VebTree樹
    ''' </summary>
    ''' <param name="universeSize">樹的大小,必須是2的指數</param>
    Public Shared Function createVebTree(ByVal universeSize As Integer) As VebTree
        If Math.Log(universeSize, 2) = Math.Floor(Math.Log(universeSize, 2)) Then
            Return New VebTree(universeSize)
        Else
            Debug.Print("大小必須為2的指數！")
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' 插入節點
    ''' </summary>
    ''' <param name="x">插入節點的值</param>
    Public Sub insert(ByVal x As Integer)
        Me.insertStep(Me.root, x)
    End Sub
    ''' <summary>
    ''' 刪除節點
    ''' </summary>
    ''' <param name="x">刪除節點的值</param>
    Public Sub delete(ByVal x As Integer)
        Me.deleteStep(Me.root, x)
    End Sub
    ''' <summary>
    ''' 搜尋節點
    ''' </summary>
    ''' <param name="x">要搜尋的值</param>
    ''' <returns>有找到回傳True否則False</returns>
    Public Function search(ByVal x As Integer) As Boolean
        Return Me.searchStep(Me.root, x)
    End Function
    ''' <summary>
    ''' 取得某節點的前驅
    ''' </summary>
    ''' <param name="x">輸入一個數字x</param>
    ''' <returns>傳回小於x值的最大值</returns>
    Public Function predecessor(ByVal x As Integer) As Integer
        Return Me.predecessorStep(Me.root, x)
    End Function
    ''' <summary>
    ''' 取得某節點的後繼
    ''' </summary>
    ''' <param name="x">輸入一個數字x</param>
    ''' <returns>傳回大於x值的最小值</returns>
    Public Function successor(ByVal x As Integer) As Integer
        Return Me.successorStep(Me.root, x)
    End Function
    ''' <summary>
    ''' 取得最小值
    ''' </summary>
    Public Function min() As Integer
        Return Me.root.min
    End Function
    ''' <summary>
    ''' 取得最大值
    ''' </summary>
    Public Function max() As Integer
        Return Me.root.max
    End Function
    Private Sub New(ByVal universeSize As Integer)
        Me.root = New VebNode(universeSize)
    End Sub
    Private Sub insertStep(ByVal node As VebNode, ByVal x As Integer)
        If node.min = NULL Then
            node.min = x : node.max = x
        ElseIf (x < node.min) Then
            Dim tempValue As Integer = x
            x = node.min
            node.min = tempValue
        ElseIf x > node.min AndAlso node.universeSize > BASE_SIZE Then
            Dim highOfX As Integer = Me.high(node, x)
            Dim lowOfX As Integer = Me.low(node, x)
            If NULL <> node.cluster(highOfX).min Then
                Me.insertStep(node.cluster(highOfX), lowOfX)
            Else
                Me.insertStep(node.summary, highOfX)
                node.cluster(highOfX).min = lowOfX
                node.cluster(highOfX).max = lowOfX
            End If
        End If
        If x > node.max Then
            node.max = x
        End If
    End Sub
    Private Sub deleteStep(ByVal node As VebNode, ByVal x As Integer)
        If node.min = node.max Then
            node.min = NULL
            node.max = NULL
        ElseIf BASE_SIZE = node.universeSize Then
            If x = 0 Then
                node.min = 1
            Else
                node.min = 0
            End If
            node.max = node.min
        ElseIf x = node.min Then
            Dim summaryMin As Integer = node.summary.min
            x = Me.index(node, summaryMin, node.cluster(summaryMin).min)
            node.min = x
            Dim highOfX As Integer = Me.high(node, x)
            Dim lowOfX As Integer = Me.low(node, x)
            Me.deleteStep(node.cluster(highOfX), lowOfX)
            If node.cluster(highOfX).min = NULL Then
                Me.deleteStep(node.summary, highOfX)
                If x = node.max Then
                    Dim summaryMax As Integer = node.summary.max
                    If summaryMax = NULL Then
                        node.max = node.min
                    Else
                        node.max = Me.index(node, summaryMax, node.cluster(summaryMax).max)
                    End If
                End If
            ElseIf x = node.max Then
                node.max = Me.index(node, highOfX, node.cluster(highOfX).max)
            End If
        End If
    End Sub
    Private Function searchStep(ByVal node As VebNode, ByVal x As Integer) As Boolean
        If x = node.min OrElse x = node.max Then
            Return True
        ElseIf BASE_SIZE = node.universeSize Then
            Return False
        Else
            Return Me.searchStep(node.cluster(Me.high(node, x)), Me.low(node, x))
        End If
    End Function
    Private Function predecessorStep(ByVal node As VebNode, ByVal x As Integer) As Integer
        If BASE_SIZE = node.universeSize Then
            If x = 1 AndAlso node.min = 0 Then
                Return 0
            Else
                Return NULL
            End If
        ElseIf NULL <> node.max AndAlso x > node.max Then
            Return node.max
        Else
            Dim highOfX As Integer = Me.high(node, x)
            Dim lowOfX As Integer = Me.low(node, x)
            Dim minCluster As Integer = node.cluster(highOfX).min
            If NULL <> minCluster AndAlso lowOfX > minCluster Then
                Return Me.index(node, highOfX, Me.predecessorStep(node.cluster(highOfX), lowOfX))
            Else
                Dim clusterPred As Integer = Me.predecessorStep(node.summary, highOfX)
                If NULL = clusterPred Then
                    If NULL <> node.min AndAlso x > node.min Then
                        Return node.min
                    Else
                        Return NULL
                    End If

                Else
                    Return Me.index(node, clusterPred, node.cluster(clusterPred).max)
                End If

            End If
        End If
    End Function
    Private Function successorStep(ByVal node As VebNode, ByVal x As Integer) As Integer
        If BASE_SIZE = node.universeSize Then
            If x = 0 AndAlso node.max = 1 Then
                Return 1
            Else
                Return NULL
            End If
        ElseIf node.min <> NULL AndAlso x < node.min Then
            Return node.min
        Else
            Dim highOfX As Integer = Me.high(node, x)
            Dim lowOfX As Integer = Me.low(node, x)
            Dim maxCluster As Integer = node.cluster(highOfX).max
            If maxCluster <> NULL AndAlso lowOfX < maxCluster Then
                Return Me.index(node, highOfX, Me.successorStep(node.cluster(highOfX), lowOfX))
            Else
                Dim clusterPred As Integer = Me.successorStep(node.summary, highOfX)
                If NULL = clusterPred Then
                    Return NULL
                Else
                    Return Me.index(node, clusterPred, node.cluster(clusterPred).min)
                End If
            End If
        End If
    End Function
    Private Function high(ByVal node As VebNode, ByVal x As Integer) As Integer
        Return Math.Floor((x / Me.lowerSquareRoot(node)))
    End Function
    Private Function low(ByVal node As VebNode, ByVal x As Integer) As Integer
        Return x Mod Me.lowerSquareRoot(node)
    End Function
    Private Function lowerSquareRoot(ByVal node As VebNode) As Double
        Return Math.Pow(2, Math.Floor(((Math.Log10(node.universeSize) / Math.Log10(2)) / 2)))
    End Function
    Private Function index(ByVal node As VebNode, ByVal x As Integer, ByVal y As Integer) As Integer
        Return x * Me.lowerSquareRoot(node) + y
    End Function
End Class