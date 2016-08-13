Friend Class EndAlert
    Private winner As Game.Player
    Private is_draw As Boolean

    Public Sub New(Optional ByVal winner As Game.Player = Nothing, Optional ByVal is_draw As Boolean = False)
        ' This call is required by the designer.
        InitializeComponent()

        Me.winner = winner
        Me.is_draw = is_draw
    End Sub

    Private Sub EndAlert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If is_draw Then
            lbl_message.Text = "Gelijkspel!"
        Else
            lbl_message.Text = "En het punt gaat naar... " + winner.ToString + "!"
        End If
    End Sub
End Class