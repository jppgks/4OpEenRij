Option Explicit On
Option Strict On


Friend Class Board

    Private Property width As Integer
    Private Property height As Integer
    Private Property game As Game
    Private Property coins As List(Of List(Of PictureBox)) = New List(Of List(Of PictureBox))
    Private Property buttons As List(Of Btn) = New List(Of Btn)
    Protected Property panel As Panel


    Friend Sub New(ByVal width As Integer, ByVal height As Integer, ByRef game As Game)
        Me.width = width
        Me.height = height
        Me.game = game
        InitializeCoinsAndButtons()
    End Sub

    ' Add coins and buttons to Me.coins and Me.buttons
    Private Sub InitializeCoinsAndButtons()
        For i As Integer = 0 To width
            coins.Add(New List(Of PictureBox))
            buttons.Add(New Btn(i, Me))
            For j As Integer = 0 To height
                Dim coin = New Coin(i, j, Me)
                coins.ElementAt(i).Add(coin)
            Next
        Next
    End Sub

    ''' Adds all coins and buttons of this board to the given panel as Controls.
    ''' <param name="pnl">The panel to add all coins and buttons to.</param>
    Friend Sub AddToPanel(ByRef pnl As Panel)
        ' SelectMany takes every column and streams every coin,
        ' ToArray collects into Array
        panel = pnl
        panel.Controls.AddRange(coins.SelectMany(Function(col) col).ToArray())
        panel.Controls.AddRange(buttons.ToArray)
    End Sub

    ''' Handles the MouseDown event for all Controls on this board.
    ''' A coin with the color of the active player is dropped in the according column if possible.
    ''' <param name="sender">The clicked Control.</param>
    Protected Sub OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim column = CType(CType(sender, Control).Tag, Tuple(Of Integer, Integer)).Item1
        DropCoinInColumn(column)
    End Sub

    ' Drops a coin with the color of the active player in the given column if it isn't full.
    Private Sub DropCoinInColumn(ByVal column As Integer)
        Dim index = LinearizedIndex(column, 0)
        For i As Integer = height To 0 Step -1
            Dim coin = CType(panel.Controls.Item(index + i), Coin)
            If coin.BackColor.Equals(Color.Gray) Then
                coin.Color(game.active_player.color)
                game.SwitchActivePlayer()
                Return
            End If
        Next
        game.CheckForEndingSituation()
    End Sub

    ''' Flattens the 2D index (column, row) to an index in the one-dimensional panel.Controls list.
    ''' <returns>The index for the element at (column, row) in the one-dimensional panel.Controls list.</returns>
    Private Function LinearizedIndex(ByVal column As Integer, ByVal row As Integer) As Integer
        Return column * (height + 1) + row
    End Function


    ' Custom class derived from Button, representing a button on the game panel.
    Private Class Btn
        Inherits Button

        Public Const SIDE_LENGTH As Integer = 50


        ''' <param name="button_index">
        ''' Saved in this Btn's Tag and Name.
        ''' Used to determine this Btn's location.
        ''' </param>
        ''' <param name="board">The board this Btn is on.</param>
        Sub New(ByVal button_index As Integer, ByRef board As Board)
            MyBase.Size = New Size(SIDE_LENGTH, SIDE_LENGTH)
            Name = "btn_" + button_index.ToString
            Location = New Point(3 + (button_index * SIDE_LENGTH), 3)
            Tag = Tuple.Create(button_index, 0)
            TabIndex = 1
            Text = "⇩"
            UseVisualStyleBackColor = True
            AddHandler MouseDown, AddressOf board.OnClick
        End Sub
    End Class


    ' Custom class derived from PictureBox, representing a coin on the game panel.
    Friend Class Coin
        Inherits PictureBox

        Shared INACTIVE_COLOR As Color = Drawing.Color.Gray
        Private Const COIN_SIZE As Integer = 50
        ' Vertical offset, accounting for buttons above the coins.
        Private Const BUTTON_OFFSET As Integer = Btn.SIDE_LENGTH + 10


        Protected Friend Sub New(ByVal i As Integer, ByVal j As Integer, ByRef board As Board)
            Size = New Size(COIN_SIZE, COIN_SIZE)
            Region = MakeCircle(COIN_SIZE)
            BackColor = INACTIVE_COLOR
            Location = New Point(COIN_SIZE * i, BUTTON_OFFSET + COIN_SIZE * j)
            Tag = Tuple.Create(i, j)
            AddHandler MouseDown, AddressOf board.OnClick
        End Sub

        ' Makes coin of given size appear round on the panel.
        Shared Function MakeCircle(ByVal size As Integer) As Region
            Dim path As New Drawing2D.GraphicsPath
            path.AddEllipse(0, 0, size, size)
            Return New Region(path)
        End Function

        ''' Change the backcolor of this coin to the given color.
        ''' <param name="color">The new backcolor for this coin.</param>
        Sub Color(ByVal color As Color)
            BackColor = color
        End Sub

        ' For debugging purposes. 
        ' Returning the Tag makes it easier to inspect Controls on the panel.
        Overrides Function ToString() As String
            Return Tag.ToString()
        End Function
    End Class
End Class
