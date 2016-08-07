Option Explicit On
Option Strict On


Friend Class Player

    Property color As Color
    Property name As String
    Property id As Integer


    Sub New(ByVal id As Integer, ByVal color As Color, ByVal name As String)
        Me.id = id
        Me.color = color
        If name.Equals("") Then
            Me.name = "Speler " + id.ToString
        Else
            Me.name = name
        End If
    End Sub
End Class


Friend Class Game

    Property board As Board
    Private Property players As Queue(Of Player) = New Queue(Of Player)
    Property active_player As Player
    Property scores As ArrayList = New ArrayList()
    Dim score_labels As ArrayList = New ArrayList()
    Dim colors As ArrayList = New ArrayList()


    Sub New()
        InitializeColors()
    End Sub

    Private Sub InitializeColors()
        colors.Add(Color.Gold)
        colors.Add(Color.OrangeRed)
        colors.AddRange([Enum].GetValues(GetType(KnownColor))) ' Square brackets so Enum isn't used as keyword
    End Sub

    Private Sub InitializeScoreLabels()
        score_labels.Add(frmMain.lbl_score_player1)
        score_labels.Add(frmMain.lbl_score_player2)
    End Sub

    Friend Sub Start(ByVal names As String())
        players.Clear()
        InitializeScoreLabels()
        InitializePlayers(names)
        ' Make first player the active player.
        SwitchActivePlayer()
        ' Enable clicking on coins and buttons!
        frmMain.pnl_game.Enabled = True
    End Sub

    Private Sub InitializePlayers(ByVal names As String())
        ' Add all given names to the according players.
        For i As Integer = 0 To names.GetUpperBound(0)
            Dim player = New Player(i + 1, CType(colors(i), Color), names(i))
            players.Enqueue(player)
            scores.Add(0)
            CType(score_labels(i), Control).Text = player.name
        Next
    End Sub

    Friend Sub SwitchActivePlayer()
        active_player = players.Dequeue()
        players.Enqueue(active_player)
        frmMain.pic_current.BackColor = active_player.color
        frmMain.lbl_player_current.Text = active_player.name
    End Sub

    Friend Sub CheckForEndingSituation()
        Throw New NotImplementedException()
    End Sub
End Class
