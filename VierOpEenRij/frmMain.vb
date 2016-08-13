Option Explicit On
Option Strict On


Public Class frmMain


    Friend Const BOARD_WIDTH As Integer = 7
    Friend Const BOARD_HEIGHT As Integer = 6

    Friend Property game As Game
    Friend Property board As Board


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pic_current.Region = Board.Coin.MakeCircle(pic_current.Width)
    End Sub

    ' Clear the game panel and add the current board (with coins and buttons) to it.
    Friend Sub InitializeBoard()
        pnl_game.Controls.Clear()
        game.board = board
        board.AddToPanel(pnl_game)
    End Sub

    Private Sub btn_start_Click(sender As Object, e As EventArgs) Handles btn_start.Click
        DisableControl(CType(btn_start, Control))
        DisableControl(CType(txt_player1, Control))
        DisableControl(CType(txt_player2, Control))
        EnableControl(CType(btn_stop, Control))
        game = New Game()
        board = New Board(BOARD_WIDTH - 1, BOARD_HEIGHT - 1, game)
        InitializeBoard()
        game.Start(New String() {txt_player1.Text, txt_player2.Text})
    End Sub

    ' Helper
    Private Sub DisableControl(ByRef control As Control)
        control.Enabled = False
    End Sub

    ' Helper
    Private Sub EnableControl(ByRef control As Control)
        control.Enabled = True
    End Sub

    Private Sub btn_stop_Click(sender As Object, e As EventArgs) Handles btn_stop.Click
        pnl_game.Controls.Clear()
        EnableControl(CType(btn_start, Control))
        EnableControl(CType(txt_player1, Control))
        EnableControl(CType(txt_player2, Control))
        DisableControl(CType(btn_stop, Control))
        lbl_name_player1.Text = "Speler 1"
        lbl_name_player2.Text = "Speler 2"
        lbl_score1.Text = "0"
        lbl_score2.Text = "0"
        tmr_turn.Enabled = False
        lbl_time.Text = "0s"
        lbl_player_current.Text = ""
        pic_current.BackColor = Board.Coin.INACTIVE_COLOR
    End Sub

    ' On each tick of the timer (every second), the time label is updated with the elapsed
    ' time of the turn stopwatch.
    Private Sub tmr_turn_Tick(sender As Object, e As EventArgs) Handles tmr_turn.Tick
        lbl_time.Text = game.current_turn.stopwatch.Elapsed.Seconds.ToString + "s"
    End Sub
End Class