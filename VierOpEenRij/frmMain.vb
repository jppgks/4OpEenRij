Option Explicit On
Option Strict On

Public Class frmMain

    Dim Game As Game = New Game()

    Public Const BOARD_WIDTH As Integer = 7
    Public Const BOARD_HEIGHT As Integer = 6

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim board = New Board(BOARD_WIDTH - 1, BOARD_HEIGHT - 1)
        board.AddToPanel(pnl_game)
    End Sub

End Class