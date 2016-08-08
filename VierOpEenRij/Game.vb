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
        ' Check rows
        CheckStraight(board.height, board.width, True)
        ' Check columns
        CheckStraight(board.width, board.height, False)
        ' Check diagonals upwards
        CheckDiagonals(board.width, board.height, True)
        ' Check diagonals downwards
        CheckDiagonals(board.width, board.height, False)
    End Sub

    Private Sub CheckStraight(ByVal vertical_length As Integer, ByVal horizontal_length As Integer, ByVal is_check_for_row As Boolean)
        Dim inactive_color As Color = Board.Coin.INACTIVE_COLOR
        Dim streak_color As Color
        Dim current_coin_color As Color
        Dim winning_color As Color = Board.Coin.INACTIVE_COLOR
        Dim cnt As Integer
        For row As Integer = 0 To vertical_length
            cnt = 0
            If is_check_for_row Then
                streak_color = board.GetCoinAt(0, row).BackColor
            Else
                streak_color = board.GetCoinAt(row, 0).BackColor
            End If
            If streak_color <> inactive_color Then
                cnt += 1
            End If
            For clm As Integer = 1 To horizontal_length
                If is_check_for_row Then
                    current_coin_color = board.GetCoinAt(clm, row).BackColor
                Else
                    current_coin_color = board.GetCoinAt(row, clm).BackColor
                End If
                If current_coin_color.Equals(inactive_color) Then
                    cnt = 0
                    streak_color = current_coin_color
                    Continue For
                End If
                If Not streak_color.Equals(inactive_color) And current_coin_color.Equals(streak_color) Then
                    cnt += 1
                Else
                    streak_color = current_coin_color
                    cnt = 1
                    Continue For
                End If
                If cnt >= 4 Then
                    winning_color = streak_color
                    Exit For
                    Exit For
                End If
            Next
        Next
        If Not winning_color.IsEmpty Then
            Dim frm As Form = New EndAlert(winning_color)
            frm.ShowDialog()
            ' Todo: stop game
        End If
    End Sub

    Private Sub CheckDiagonals(ByVal vertical_length As Integer, ByVal horizontal_length As Integer, ByVal is_check_for_upwards As Boolean)

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
