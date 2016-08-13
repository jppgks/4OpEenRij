Public Class EndAlert
    Private winning_color As Color

    Public Sub New(winning_color As Color)
        ' This call is required by the designer.
        InitializeComponent()

        Me.winning_color = winning_color
    End Sub

    Private Sub EndAlert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_message.Text = winning_color.ToString
    End Sub
End Class