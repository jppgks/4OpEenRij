Public Class frmMain

    Dim Game = New Game()

    Public Const BOARD_WIDTH As Integer = 7
    Public Const BOARD_HEIGHT As Integer = 6

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim board = New Board(BOARD_WIDTH - 1, BOARD_HEIGHT - 1)
        ' SelectMany takes every column and streams every coin,
        ' ToArray collects into Array
        Dim coins = board.coins.SelectMany(Function(col) col).ToArray()
        pnl_game.Controls.AddRange(coins)
    End Sub

End Class