﻿Option Explicit On
Option Strict On


Friend Class Game

    Property board As Board
    Private Property players As Queue(Of Player) = New Queue(Of Player)
    Property current_turn As Turn
    Private name_labels As ArrayList = New ArrayList()
    Private score_labels As ArrayList = New ArrayList()
    Private colors As ArrayList = New ArrayList()
    Friend full_columns As BitArray


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

    ' Add all labels for the scores of the players to the score_labels list.
    Private Sub InitializeScoreLabels()
        score_labels.Add(frmMain.lbl_score1)
        score_labels.Add(frmMain.lbl_score2)
    End Sub

    ' Initialize each player with an id, color and given name.
    Private Sub InitializePlayers(ByVal names As String())
        For i As Integer = 0 To names.GetUpperBound(0)
            Dim player = New Player(i + 1, CType(colors(i), Color), names(i), CType(name_labels(i), Label), CType(score_labels(i), Label))
            players.Enqueue(player)
        Next
    End Sub

    Friend Sub Start(ByVal names As String())
        full_columns = New BitArray(board.width + 1)
        full_columns.SetAll(False)
        players.Clear()
        InitializeNameLabels()
        InitializeScoreLabels()
        InitializePlayers(names)
        frmMain.tmr_turn.Enabled = True
        ' Make first player the active player.
        SwitchTurns()
        ' Enable clicking on coins and buttons!
        frmMain.pnl_game.Enabled = True
    End Sub

    Private Sub EndGame(Optional ByVal winner As Player = Nothing)
        ' Update scores
        If winner IsNot Nothing Then
            winner.AddPoint()
        End If
        ' Prepare board for playing the next point
        frmMain.board = New Board(frmMain.BOARD_WIDTH - 1, frmMain.BOARD_HEIGHT - 1, Me)
        frmMain.InitializeBoard()
        board = frmMain.board
        full_columns = New BitArray(board.width + 1)
        full_columns.SetAll(False)
    End Sub

    Private Function GetPlayerNames() As String()
        Dim names As List(Of String) = New List(Of String)
        For Each player In players
            names.Add(player.name)
        Next
        Return names.ToArray()
    End Function

    ' Create new turn for next player
    Friend Sub SwitchTurns()
        current_turn = New Turn(players.Dequeue())
        players.Enqueue(current_turn.player)
    End Sub

    Friend Sub CheckForDraw()
        Dim is_draw As Boolean = True
        ' Look for a column that isn't full
        For Each bool As Boolean In full_columns
            If Not bool Then
                ' Not all columns are full
                is_draw = False
                Exit For
            End If
        Next
        If is_draw Then
            Dim frm As Form = New EndAlert(is_draw:=True)
            frm.ShowDialog()
            EndGame()
        End If
    End Sub

    Friend Sub CheckForWinningSituation(ByVal column As Integer, ByVal row As Integer)
        Check(column, row, 0)  ' rows
        Check(column, row, 1)  ' columns
        Check(column, row, 2)  ' diagonal down
        Check(column, row, 3)  ' diagonal up
    End Sub

    Private Function TryStreakGetCoin(ByVal x As Integer, ByVal y As Integer, ByVal i As Integer, ByVal situation As Integer) As Board.Coin
        Select Case situation
            Case 0  ' rows
                Return board.GetCoinAt(x + i, y)
            Case 1  ' columns
                Return board.GetCoinAt(x, y + i)
            Case 2  ' diagonal down
                Return board.GetCoinAt(x + i, y + i)
            Case 3  ' diagonal up
                Return board.GetCoinAt(x + i, y - i)
        End Select
        Return Nothing
    End Function

    Private Function TryStreakGetNextCoin(ByVal x As Integer, ByVal y As Integer, ByVal j As Integer, ByVal streak_coin_tag As Tuple(Of Integer, Integer), ByVal situation As Integer) As Board.Coin
        Select Case situation
            Case 0  ' rows
                Return board.GetCoinAt(streak_coin_tag.Item1 + j + 1, y)
            Case 1  ' columns
                Return board.GetCoinAt(x, streak_coin_tag.Item2 + j + 1)
            Case 2  ' diagonal down
                Return board.GetCoinAt(streak_coin_tag.Item1 + j + 1, streak_coin_tag.Item2 + j + 1)
            Case 3  ' diagonal up
                Return board.GetCoinAt(streak_coin_tag.Item1 + j + 1, streak_coin_tag.Item2 - (j + 1))
        End Select
        Return Nothing
    End Function

    Private Function CurrentGetCoin(ByVal x As Integer, ByVal y As Integer, ByVal j As Integer, ByVal streak_coin_tag As Tuple(Of Integer, Integer), ByVal situation As Integer) As Board.Coin
        Select Case situation
            Case 0  ' rows
                Return board.GetCoinAt(streak_coin_tag.Item1 + j, y)
            Case 1  ' columns
                Return board.GetCoinAt(x, streak_coin_tag.Item2 + j)
            Case 2  ' diagonal down
                Return board.GetCoinAt(streak_coin_tag.Item1 + j, streak_coin_tag.Item2 + j)
            Case 3  ' diagonal up
                Return board.GetCoinAt(streak_coin_tag.Item1 + j, streak_coin_tag.Item2 - j)
        End Select
        Return Nothing
    End Function

    Private Sub Check(ByVal x As Integer, ByVal y As Integer, ByVal situation As Integer)
        If board.width < 4 Then
            Return
        End If
        Dim inactive_color As Color = Board.Coin.INACTIVE_COLOR
        Dim streak_coin As Board.Coin
        Dim streak_color As Color
        Dim streak_coin_tag As Tuple(Of Integer, Integer) = Nothing
        Dim current_coin_color As Color
        Dim winning_color As Color = inactive_color
        Dim cnt As Integer
        cnt = 0
        For i As Integer = -3 To 0
            Try
                streak_coin = TryStreakGetCoin(x, y, i, situation)
                streak_color = streak_coin.BackColor
                streak_coin_tag = CType(streak_coin.Tag, Tuple(Of Integer, Integer))
                Exit For
            Catch ex As Exception
                ' pass
            End Try
        Next
        If streak_color <> inactive_color Then
            cnt += 1
        End If
        Try
            TryStreakGetNextCoin(x, y, 0, streak_coin_tag, situation)
        Catch ex As Exception
            Return
        End Try
        For j As Integer = 1 To 6
            current_coin_color = CurrentGetCoin(x, y, j, streak_coin_tag, situation).BackColor
            If current_coin_color.Equals(inactive_color) Then
                cnt = 0
                streak_color = current_coin_color
                Try
                    TryStreakGetNextCoin(x, y, j, streak_coin_tag, situation)
                Catch ex As Exception
                    Return
                End Try
                Continue For
            End If
            If Not streak_color.Equals(inactive_color) And current_coin_color.Equals(streak_color) Then
                cnt += 1
            Else
                streak_color = current_coin_color
                cnt = 1
                Try
                    TryStreakGetNextCoin(x, y, j, streak_coin_tag, situation)
                Catch ex As Exception
                    Return
                End Try
                Continue For
            End If
            If cnt >= 4 Then
                winning_color = streak_color
                Exit For
            End If
            Try
                TryStreakGetNextCoin(x, y, j, streak_coin_tag, situation)
            Catch ex As Exception
                Return
            End Try
        Next
        If Not winning_color.Equals(inactive_color) Then
            Dim winner As Player = GetPlayerFromColor(winning_color)
            Dim frm As Form = New EndAlert(winner:=winner)
            frm.ShowDialog()
            EndGame(winner)
        End If
    End Sub

    Private Function GetPlayerFromColor(ByVal color As Color) As Player
        For Each player In players
            If player.color = color Then
                Return player
            End If
        Next
        Return Nothing
    End Function

    ' Custom class representing a player in the game with it's color, name and id.
    Class Player

        Property color As Color
        Property name As String
        Property id As Integer
        Property lbl_score As Label
        Property score As Integer = 0


        Sub New(ByVal id As Integer, ByVal color As Color, ByVal name As String, ByRef lbl_name As Label, ByRef lbl_score As Label)
            Me.id = id
            Me.color = color
            If name.Equals("") Then
                Me.name = "Speler " + id.ToString
            Else
                Me.name = name
            End If
            lbl_name.Text = Me.name
            Me.lbl_score = lbl_score
        End Sub

        Friend Sub AddPoint()
            score += 1
            lbl_score.Text = score.ToString
        End Sub

        Overrides Function ToString() As String
            Return name
        End Function
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
