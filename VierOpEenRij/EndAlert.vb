Public Class EndAlert
    Private winning_color As Color
    Private is_draw As Boolean

    Public Sub New(Optional ByVal winning_color As Color = Nothing, Optional ByVal is_draw As Boolean = False)
        ' This call is required by the designer.
        InitializeComponent()

        Me.winning_color = winning_color
        Me.is_draw = is_draw
    End Sub

    Private Sub EndAlert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If is_draw Then
            lbl_message.Text = "Draw!"
        Else
            lbl_message.Text = winning_color.ToString
        End If
    End Sub
End Class