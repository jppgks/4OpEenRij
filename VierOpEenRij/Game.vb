﻿Option Explicit On
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

    Friend Sub CheckForEndingSituation(ByVal column As Integer, ByVal row As Integer)
        CheckRow(column, row)
        CheckColumn(column, row)
        CheckDiagonalDown(column, row)
        CheckDiagonalUp(column, row)
    End Sub

    Private Sub CheckRow(ByVal x As Integer, ByVal ROW As Integer)
        If board.width < 4 Then
            Return
        End If
        Dim inactive_color As Color = Board.Coin.INACTIVE_COLOR
        Dim streak_coin As Board.Coin
        Dim streak_color As Color
        Dim streak_coin_tag As Tuple(Of Integer, Integer)
        Dim current_coin_color As Color
        Dim winning_color As Color = inactive_color
        Dim cnt As Integer
        cnt = 0
        For i As Integer = -3 To 0
            Try
                streak_coin = board.GetCoinAt(x + i, ROW)
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
            board.GetCoinAt(streak_coin_tag.Item1 + 1, ROW)
        Catch ex As Exception
            Return
        End Try
        For j As Integer = 1 To 6
            current_coin_color = board.GetCoinAt(streak_coin_tag.Item1 + j, ROW).BackColor
            If current_coin_color.Equals(inactive_color) Then
                cnt = 0
                streak_color = current_coin_color
                Try
                    board.GetCoinAt(streak_coin_tag.Item1 + j + 1, ROW)
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
                    board.GetCoinAt(streak_coin_tag.Item1 + j + 1, ROW)
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
                board.GetCoinAt(streak_coin_tag.Item1 + j + 1, ROW)
            Catch ex As Exception
                Return
            End Try
        Next
        If Not winning_color.Equals(inactive_color) Then
            Dim frm As Form = New EndAlert(winning_color)
            frm.ShowDialog()
            ' Todo: stop game
        End If
    End Sub

    Private Sub CheckColumn(ByVal COL As Integer, ByVal y As Integer)
        If board.height < 4 Then
            Return
        End If
        Dim inactive_color As Color = Board.Coin.INACTIVE_COLOR
        Dim streak_coin As Board.Coin
        Dim streak_color As Color
        Dim streak_coin_tag As Tuple(Of Integer, Integer)
        Dim current_coin_color As Color
        Dim winning_color As Color = inactive_color
        Dim cnt As Integer
        cnt = 0
        For i As Integer = -3 To 0
            Try
                streak_coin = board.GetCoinAt(COL, y + i)
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
            board.GetCoinAt(COL, streak_coin_tag.Item2 + 1)
        Catch ex As Exception
            Return
        End Try
        For j As Integer = 1 To 6
            current_coin_color = board.GetCoinAt(COL, streak_coin_tag.Item2 + j).BackColor
            If current_coin_color.Equals(inactive_color) Then
                cnt = 0
                streak_color = current_coin_color
                Try
                    board.GetCoinAt(COL, streak_coin_tag.Item2 + j + 1)
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
                    board.GetCoinAt(COL, streak_coin_tag.Item2 + j + 1)
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
                board.GetCoinAt(COL, streak_coin_tag.Item2 + j + 1)
            Catch ex As Exception
                Return
            End Try
        Next
        If Not winning_color.Equals(inactive_color) Then
            Dim frm As Form = New EndAlert(winning_color)
            frm.ShowDialog()
            ' Todo: stop game
        End If
    End Sub

    Private Sub CheckDiagonalDown(ByVal x As Integer, ByVal y As Integer)
        If board.height < 4 Or board.width < 4 Then
            Return
        End If
        Dim inactive_color As Color = Board.Coin.INACTIVE_COLOR
        Dim streak_coin As Board.Coin
        Dim streak_color As Color
        Dim streak_coin_tag As Tuple(Of Integer, Integer)
        Dim current_coin_color As Color
        Dim winning_color As Color = inactive_color
        Dim cnt As Integer
        cnt = 0
        For i As Integer = -3 To 0
            Try
                streak_coin = board.GetCoinAt(x + i, y + i)
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
            board.GetCoinAt(streak_coin_tag.Item1 + 1, streak_coin_tag.Item2 + 1)
        Catch ex As Exception
            Return
        End Try
        For j As Integer = 1 To 6
            current_coin_color = board.GetCoinAt(streak_coin_tag.Item1 + j, streak_coin_tag.Item2 + j).BackColor
            If current_coin_color.Equals(inactive_color) Then
                cnt = 0
                streak_color = current_coin_color
                Try
                    board.GetCoinAt(streak_coin_tag.Item1 + j + 1, streak_coin_tag.Item2 + j + 1)
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
                    board.GetCoinAt(streak_coin_tag.Item1 + j + 1, streak_coin_tag.Item2 + j + 1)
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
                board.GetCoinAt(streak_coin_tag.Item1 + j + 1, streak_coin_tag.Item2 + j + 1)
            Catch ex As Exception
                Return
            End Try
        Next
        If Not winning_color.Equals(inactive_color) Then
            Dim frm As Form = New EndAlert(winning_color)
            frm.ShowDialog()
            ' Todo: stop game
        End If
    End Sub

    Private Sub CheckDiagonalUp(ByVal x As Integer, ByVal y As Integer)
        If board.height < 4 Or board.width < 4 Then
            Return
        End If
        Dim inactive_color As Color = Board.Coin.INACTIVE_COLOR
        Dim streak_coin As Board.Coin
        Dim streak_color As Color
        Dim streak_coin_tag As Tuple(Of Integer, Integer)
        Dim current_coin_color As Color
        Dim winning_color As Color = inactive_color
        Dim cnt As Integer
        cnt = 0
        For i As Integer = -3 To 0
            Try
                streak_coin = board.GetCoinAt(x + i, y - i)
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
            board.GetCoinAt(streak_coin_tag.Item1 + 1, streak_coin_tag.Item2 - 1)
        Catch ex As Exception
            Return
        End Try
        For j As Integer = 1 To 6
            current_coin_color = board.GetCoinAt(streak_coin_tag.Item1 + j, streak_coin_tag.Item2 - j).BackColor
            If current_coin_color.Equals(inactive_color) Then
                cnt = 0
                streak_color = current_coin_color
                Try
                    board.GetCoinAt(streak_coin_tag.Item1 + j + 1, streak_coin_tag.Item2 - (j + 1))
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
                    board.GetCoinAt(streak_coin_tag.Item1 + j + 1, streak_coin_tag.Item2 - (j + 1))
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
                board.GetCoinAt(streak_coin_tag.Item1 + j + 1, streak_coin_tag.Item2 - (j + 1))
            Catch ex As Exception
                Return
            End Try
        Next
        If Not winning_color.Equals(inactive_color) Then
            Dim frm As Form = New EndAlert(winning_color)
            frm.ShowDialog()
            ' Todo: stop game
        End If
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
