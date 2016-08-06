Option Explicit On
Option Strict On


Public Class frmMain

    Dim game As Game = New Game()

    Const BOARD_WIDTH As Integer = 7
    Const BOARD_HEIGHT As Integer = 6


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim board = New Board(BOARD_WIDTH - 1, BOARD_HEIGHT - 1, game)
        board.AddToPanel(pnl_game)
    End Sub

    Private Sub btn_start_Click(sender As Object, e As EventArgs) Handles btn_start.Click
        DisableControl(CType(btn_start, Control))
        DisableControl(CType(txt_player1, Control))
        DisableControl(CType(txt_player2, Control))
        game.Start(New String() {txt_player1.Text, txt_player2.Text})
    End Sub

    Private Sub DisableControl(ByRef control As Control)
        control.Enabled = False
    End Sub

    Private Sub btn_stop_Click(sender As Object, e As EventArgs) Handles btn_stop.Click
        Close()
    End Sub
End Class