Option Explicit On
Option Strict On

Friend Class Game

    Enum Player
        NONE
        One
        Two
    End Enum

    Public Shared Function GetColor(ByVal player As Player) As Color
        Select Case player
            Case Player.One
                Return Color.Gold
            Case Player.Two
                Return Color.OrangeRed
            Case Player.NONE
                Return Color.Gray
            Case Else
                Return Color.Gray
        End Select
    End Function

    Public Sub New()
    End Sub
End Class
