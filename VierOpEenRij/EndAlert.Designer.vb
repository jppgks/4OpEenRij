<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EndAlert
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbl_message = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_message
        '
        Me.lbl_message.AutoSize = True
        Me.lbl_message.Location = New System.Drawing.Point(90, 94)
        Me.lbl_message.Name = "lbl_message"
        Me.lbl_message.Size = New System.Drawing.Size(73, 25)
        Me.lbl_message.TabIndex = 0
        Me.lbl_message.Text = "Boom!"
        '
        'EndAlert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(274, 229)
        Me.Controls.Add(Me.lbl_message)
        Me.Name = "EndAlert"
        Me.Text = "EndAlert"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_message As Label
End Class
