Option Explicit On
Option Strict On

Friend Class Board

    Private Property coins As List(Of List(Of PictureBox)) = New List(Of List(Of PictureBox))

    Friend Sub New(ByVal width As Integer, ByVal height As Integer)
        For i As Integer = 0 To width
            coins.Add(New List(Of PictureBox))
            For j As Integer = 0 To height
                Dim coin = New Coin(i, j)
                coins.ElementAt(i).Add(coin)
            Next
        Next
    End Sub

    ''' <summary>
    ''' Adds all coins of this board to the given panel as Controls.
    ''' </summary>
    ''' <param name="panel">The panel to add all coins to.</param>
    Friend Sub AddToPanel(ByRef panel As Panel)
        ' SelectMany takes every column and streams every coin,
        ' ToArray collects into Array
        panel.Controls.AddRange(coins.SelectMany(Function(col) col).ToArray())
    End Sub

    Private Class Coin
        Inherits PictureBox

        Private Const COIN_SIZE As Integer = 50
        Private Const BUTTON_OFFSET As Integer = 75

        Protected Friend Sub New(ByVal i As Integer, ByVal j As Integer)
            ' De grootte van de munt
            Size = New Size(COIN_SIZE, COIN_SIZE)
            ' Cirkelvorm
            Region = MakeCircle(COIN_SIZE)
            ' Kleur van de cirkel
            BackColor = Game.GetColor(Game.Player.NONE)
            ' Plaats op het spelbord
            Location = New Point(COIN_SIZE * i, BUTTON_OFFSET + COIN_SIZE * j)
            ' Sla de positie op het spelbord op in de munt 
            Tag = Tuple.Create(i, j)
        End Sub

        Private Function MakeCircle(ByVal size As Integer) As Region
            Dim path As New Drawing2D.GraphicsPath
            path.AddEllipse(0, 0, size, size)
            Return New Region(path)
        End Function

        ''' <summary>
        ''' Change the backcolor of this coin to the given color.
        ''' </summary>
        ''' <param name="color">The new backcolor for this coin.</param>
        Friend Sub Color(ByVal color As Color)
            BackColor = color
        End Sub
    End Class
End Class
