Option Explicit On
Option Strict On


Friend Class Player

    Property color As Color
    Property name As String
    Property id As Integer


    Sub New(ByVal id As Integer, ByVal color As Color)
        Me.id = id
        Me.color = color
    End Sub
End Class


Friend Class Game

    Property players As Queue(Of Player) = New Queue(Of Player)
    Property active_player As Player


    Sub New()
        players.Enqueue(New Player(1, Color.Gold))
        players.Enqueue(New Player(2, Color.OrangeRed))
    End Sub

    Friend Sub Start(ByVal names As String())
        ' Add all given names to the according players.
        For i As Integer = 0 To names.GetUpperBound(0)
            players(i).name = names(i)
        Next
        ' Make first player the active player.
        active_player = players.Dequeue
        players.Enqueue(active_player)
        ' Enable clicking on coins and buttons!
        frmMain.pnl_game.Enabled = True
    End Sub

    Friend Sub SwitchActivePlayer()
        active_player = players.Dequeue
        players.Enqueue(active_player)
    End Sub
End Class
