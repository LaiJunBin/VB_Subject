Module Facade
    MustInherit Class Electronices
        Public Power As Boolean
        Sub PowerOn()
            Me.Power = True
        End Sub
        Sub PowerOff()
            Me.Power = False
        End Sub
        Function isPowerOn() As Boolean
            Return Me.Power
        End Function
        Public Overridable Sub ShowStatus()
            If Me.Power Then
                print(Me.GetType.Name & "正常運行")
            Else
                print(Me.GetType.Name & "關機中")
            End If
        End Sub
    End Class
    Public Class KTVSystem
        Inherits Electronices
        Private Song As String
        Public Sub SelectSong(ByVal Song As String)
            Me.Song = Song
        End Sub
        Public Sub PlaySong()
            print(Me.GetType.Name & "播放" & Me.Song)
        End Sub
    End Class
    Class PlayStation3
        Inherits Electronices
        Private CD As String
        Public Sub PutCD(ByVal cd As String)
            Me.CD = cd
        End Sub
        Public Function GetCD() As String
            Return Me.CD
        End Function
        Public Sub Play()
            print(Me.GetType.Name & "播放" & Me.CD)
        End Sub
        Public Overrides Sub ShowStatus()
            MyBase.ShowStatus()
            If isPowerOn() Then
                print(Me.GetType.Name & "目前放入" & Me.CD)
            End If
        End Sub
    End Class
    Class Stereo
        Inherits Electronices
        Public Sound As Integer
        Sub SetSound(ByVal sound As Integer)
            Me.Sound = sound
        End Sub
        Function GetSound() As Integer
            Return Me.Sound
        End Function
        Public Overrides Sub ShowStatus()
            MyBase.ShowStatus()
            If isPowerOn() Then
                print(Me.GetType.Name & "目前音量" & Me.Sound)
            End If
        End Sub
    End Class
    Class Television
        Inherits Electronices
        Public Sound As Integer = 50
        Public Source As String = "TVBox"
        Public Channel As String = "9"
        Sub SwitchSource(ByVal source As String)
            Me.Source = source
        End Sub
        Sub SetSound(ByVal sound As Integer)
            Me.Sound = sound
        End Sub
        Sub SwitchChannel(ByVal channel As String)
            Me.Channel = channel
        End Sub
        Sub ShowTV()
            print(Me.GetType.Name & "目前觀看" & Me.Channel)
        End Sub
        Overrides Sub ShowStatus()
            MyBase.ShowStatus()
            If isPowerOn() Then
                print(Me.GetType.Name & "目前音量" & Me.Sound)
                Select Case Me.Channel
                    Case "TVBox"
                        print("當前觀看" & Me.Channel)
                    Case "PS"
                        print("ps運行中")
                    Case "KTV"
                        print("KTV播放中")
                End Select
            End If
        End Sub
        Function GetSound() As Integer
            Return Me.Sound
        End Function
        Function GetSource() As String
            Return Me.Source
        End Function
        Function GetChannel() As String
            Return Me.Channel
        End Function
    End Class
    Class VideoRoomFacade
        Public stereo As New Stereo
        Public tv As New Television
        Public ps3 As New PlayStation3
        Public ktv As New KTVSystem
        Sub ReadyPlayMovie(ByVal cd As String)
            stereo.PowerOn()
            tv.PowerOn()
            tv.SetSound(50)
            tv.SwitchSource("PS")
            ps3.PowerOn()
            ps3.PutCD(cd)
        End Sub
        Sub PlayMovie()
            If ps3.isPowerOn Then
                ps3.Play()
            End If
        End Sub
        Sub ShowTV()
            If tv.isPowerOn Then
                tv.ShowTV()
            End If
        End Sub
        Sub TurnOffAll()
            stereo.PowerOff()
            tv.PowerOff()
            ps3.PowerOff()
            ktv.PowerOff()
        End Sub
        Sub WatchTV()
            tv.PowerOn()
            tv.SwitchSource("TVBox")
        End Sub
        Sub SwitchChannel(ByVal channel As String)
            tv.Channel = channel
        End Sub
        Sub ReadyKTV()
            stereo.PowerOn()
            ktv.PowerOn()
            tv.PowerOn()
            SetSound(50)
            tv.SwitchSource("KTV")
        End Sub
        Sub SelectSong(ByVal song As String)
            ktv.SelectSong(song)
        End Sub
        Sub PlaySong()
            If ktv.isPowerOn Then
                ktv.PlaySong()
            End If
        End Sub
        Sub SetSound(ByVal sound As Integer)
            If tv.isPowerOn Then
                tv.SetSound(sound)
            End If
            If stereo.isPowerOn Then
                stereo.SetSound(sound)
            End If
        End Sub
        Sub ShowAllStatus()
            tv.ShowStatus()
            ps3.ShowStatus()
            ktv.ShowStatus()
            stereo.ShowStatus()
        End Sub
    End Class
    Sub Main()
        Dim superRemote As New VideoRoomFacade
        print("看電影")
        superRemote.ReadyPlayMovie("MovieName")
        superRemote.PlayMovie()
        superRemote.ShowAllStatus()
        superRemote.TurnOffAll()
        superRemote.ShowAllStatus()

        print("看電視")
        superRemote.WatchTV()
        superRemote.ShowTV()
        superRemote.SwitchChannel(20)
        superRemote.ShowTV()
        superRemote.TurnOffAll()

        print("唱KTV")
        superRemote.ReadyKTV()
        superRemote.SelectSong("Moon")
        superRemote.PlaySong()
        superRemote.ShowAllStatus()
        pause()
    End Sub
End Module
