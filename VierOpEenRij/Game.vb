Option Explicit On
Option Strict On


Friend Class Game

    Property board As Board
    Private Property players As Queue(Of Player) = New Queue(Of Player)
    Property current_turn As Turn
    Private Property scores As ArrayList = New ArrayList()
    Private name_labels As ArrayList = New ArrayList()
    Private colors As ArrayList = New ArrayList()


    Sub New()
        InitializeColors()
    End Sub

    ' Initializes an array of colors to use for representing player's coin on the board.
    Private Sub InitializeColors()
        colors.Add(Color.Gold)
        colors.Add(Color.OrangeRed)
        colors.AddRange([Enum].GetValues(GetType(KnownColor))) ' Square brackets so Enum isn't used as keyword
    End Sub

    ' Add all labels for the names of the players to the name_labels list. 
    Private Sub InitializeNameLabels()
        name_labels.Add(frmMain.lbl_name_player1)
        name_labels.Add(frmMain.lbl_name_player2)
    End Sub

    Friend Sub Start(ByVal names As String())
        players.Clear()
        InitializeNameLabels()
        InitializePlayers(names)
        frmMain.tmr_turn.Enabled = True
        ' Make first player the active player.
        SwitchTurns()
        ' Enable clicking on coins and buttons!
        frmMain.pnl_game.Enabled = True
    End Sub

    ' Initialize each player with an id, color and given name.
    Private Sub InitializePlayers(ByVal names As String())
        For i As Integer = 0 To names.GetUpperBound(0)
            Dim player = New Player(i + 1, CType(colors(i), Color), names(i))
            players.Enqueue(player)
            scores.Add(0)
            ' Add player's name to the name label
            CType(name_labels(i), Control).Text = player.name
        Next
    End Sub

    ' Create new turn for next player
    Friend Sub SwitchTurns()
        current_turn = New Turn(players.Dequeue())
        players.Enqueue(current_turn.player)
    End Sub

    Friend Sub CheckForEndingSituation()
        ' Not implemented yet
    End Sub


    ' Custom class representing a player in the game with it's color, name and id.
    Class Player

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


    ' Custom class representing a single turn in the game with a corresponding player and stopwatch.
    Class Turn

        Property player As Player
        Property stopwatch As Stopwatch = New Stopwatch()

        Sub New(ByVal player As Player)
            stopwatch.Start()
            Me.player = player
            frmMain.pic_current.BackColor = player.color
            frmMain.lbl_player_current.Text = player.name
        End Sub
    End Class
End Class
