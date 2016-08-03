Class Board

    Property coins As List(Of List(Of PictureBox)) = New List(Of List(Of PictureBox))

    Public Sub New(ByVal width As Integer, ByVal height As Integer)
        For i As Integer = 0 To width
            coins.Add(New List(Of PictureBox))
            For j As Integer = 0 To height
                Dim coin = New Coin(i, j)
                coins.ElementAt(i).Add(coin)
            Next
        Next
    End Sub

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
End Class
