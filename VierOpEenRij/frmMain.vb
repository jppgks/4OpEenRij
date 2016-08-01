Public Class frmMain

    Dim Game = New Game()

    Public Const BOARD_WIDTH As Integer = 7
    Public Const BOARD_HEIGHT As Integer = 6
    Private ReadOnly FIRST_COLOR As Color = Color.Gold
    Private ReadOnly SECOND_COLOR As Color = Color.OrangeRed

    Dim board(BOARD_WIDTH - 1, BOARD_HEIGHT - 1) As PictureBox

    Private Class Coin
        Inherits PictureBox

        Private ReadOnly BACK_COLOR As Color = Color.Gray
        Const COIN_SIZE As Integer = 50
        Const BUTTON_OFFSET As Integer = 75

        Public Sub New(ByVal i As Integer, ByVal j As Integer)
            ' De grootte van de munt
            Size = New Size(COIN_SIZE, COIN_SIZE)
            ' Cirkelvorm
            Region = MakeCircle(COIN_SIZE)
            ' Kleur van de cirkel
            BackColor = BACK_COLOR
            ' Plaats op het spelbord
            Location = New Point(COIN_SIZE * i, BUTTON_OFFSET + COIN_SIZE * j)
            ' Sla de positie op het spelbord op in de munt 
            Tag = Tuple.Create(i, j)
        End Sub

        Private Function MakeCircle(ByVal size As Integer) As Region
            Dim path As New System.Drawing.Drawing2D.GraphicsPath
            path.AddEllipse(0, 0, size, size)
            Return New Region(path)
        End Function
    End Class

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialisatie van het spelbord
        For i As Integer = board.GetLowerBound(0) To board.GetUpperBound(0)
            For j As Integer = board.GetLowerBound(1) To board.GetUpperBound(1)
                Dim coin = New Coin(i, j)
                ' Sla de munt op in de matrix
                board(i, j) = coin
                ' Maak de munt zichtbaar door die toe te voegen aan pnlSpelbord, 
                ' een panel voor alle munten.
                pnl_game.Controls.Add(coin)
            Next
        Next
    End Sub
End Class