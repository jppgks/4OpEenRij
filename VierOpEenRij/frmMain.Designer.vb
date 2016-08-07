<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnl_controls = New System.Windows.Forms.Panel()
        Me.grp_current_player = New System.Windows.Forms.GroupBox()
        Me.lbl_time = New System.Windows.Forms.Label()
        Me.lbl_player_current = New System.Windows.Forms.Label()
        Me.pic_current = New System.Windows.Forms.PictureBox()
        Me.grp_score = New System.Windows.Forms.GroupBox()
        Me.lbl_score2 = New System.Windows.Forms.Label()
        Me.lbl_score1 = New System.Windows.Forms.Label()
        Me.lbl_player2_score = New System.Windows.Forms.Label()
        Me.lbl_player1_score = New System.Windows.Forms.Label()
        Me.grp_settings = New System.Windows.Forms.GroupBox()
        Me.btn_stop = New System.Windows.Forms.Button()
        Me.btn_start = New System.Windows.Forms.Button()
        Me.txt_player2 = New System.Windows.Forms.TextBox()
        Me.txt_player1 = New System.Windows.Forms.TextBox()
        Me.lbl_player2_settings = New System.Windows.Forms.Label()
        Me.lbl_player1_settings = New System.Windows.Forms.Label()
        Me.pnl_game = New System.Windows.Forms.Panel()
        Me.pnl_controls.SuspendLayout()
        Me.grp_current_player.SuspendLayout()
        CType(Me.pic_current, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_score.SuspendLayout()
        Me.grp_settings.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_controls
        '
        Me.pnl_controls.Controls.Add(Me.grp_current_player)
        Me.pnl_controls.Controls.Add(Me.grp_score)
        Me.pnl_controls.Controls.Add(Me.grp_settings)
        Me.pnl_controls.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_controls.Location = New System.Drawing.Point(755, 0)
        Me.pnl_controls.Name = "pnl_controls"
        Me.pnl_controls.Size = New System.Drawing.Size(445, 764)
        Me.pnl_controls.TabIndex = 5
        '
        'grp_current_player
        '
        Me.grp_current_player.Controls.Add(Me.lbl_time)
        Me.grp_current_player.Controls.Add(Me.lbl_player_current)
        Me.grp_current_player.Controls.Add(Me.pic_current)
        Me.grp_current_player.Location = New System.Drawing.Point(11, 550)
        Me.grp_current_player.Name = "grp_current_player"
        Me.grp_current_player.Size = New System.Drawing.Size(416, 199)
        Me.grp_current_player.TabIndex = 9
        Me.grp_current_player.TabStop = False
        Me.grp_current_player.Text = "Huidige Speler"
        '
        'lbl_time
        '
        Me.lbl_time.AutoSize = True
        Me.lbl_time.Location = New System.Drawing.Point(333, 86)
        Me.lbl_time.Name = "lbl_time"
        Me.lbl_time.Size = New System.Drawing.Size(35, 25)
        Me.lbl_time.TabIndex = 8
        Me.lbl_time.Text = "0s"
        Me.lbl_time.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_player_current
        '
        Me.lbl_player_current.AutoSize = True
        Me.lbl_player_current.Location = New System.Drawing.Point(117, 86)
        Me.lbl_player_current.Name = "lbl_player_current"
        Me.lbl_player_current.Size = New System.Drawing.Size(92, 25)
        Me.lbl_player_current.TabIndex = 7
        Me.lbl_player_current.Text = "Speler 1"
        '
        'pic_current
        '
        Me.pic_current.Location = New System.Drawing.Point(11, 61)
        Me.pic_current.Name = "pic_current"
        Me.pic_current.Size = New System.Drawing.Size(100, 80)
        Me.pic_current.TabIndex = 0
        Me.pic_current.TabStop = False
        '
        'grp_score
        '
        Me.grp_score.Controls.Add(Me.lbl_score2)
        Me.grp_score.Controls.Add(Me.lbl_score1)
        Me.grp_score.Controls.Add(Me.lbl_player2_score)
        Me.grp_score.Controls.Add(Me.lbl_player1_score)
        Me.grp_score.Location = New System.Drawing.Point(11, 386)
        Me.grp_score.Name = "grp_score"
        Me.grp_score.Size = New System.Drawing.Size(416, 158)
        Me.grp_score.TabIndex = 8
        Me.grp_score.TabStop = False
        Me.grp_score.Text = "Score"
        '
        'lbl_score2
        '
        Me.lbl_score2.AutoSize = True
        Me.lbl_score2.Location = New System.Drawing.Point(333, 97)
        Me.lbl_score2.Name = "lbl_score2"
        Me.lbl_score2.Size = New System.Drawing.Size(24, 25)
        Me.lbl_score2.TabIndex = 8
        Me.lbl_score2.Text = "0"
        Me.lbl_score2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_score1
        '
        Me.lbl_score1.AutoSize = True
        Me.lbl_score1.Location = New System.Drawing.Point(333, 53)
        Me.lbl_score1.Name = "lbl_score1"
        Me.lbl_score1.Size = New System.Drawing.Size(24, 25)
        Me.lbl_score1.TabIndex = 7
        Me.lbl_score1.Text = "0"
        Me.lbl_score1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_player2_score
        '
        Me.lbl_player2_score.AutoSize = True
        Me.lbl_player2_score.Location = New System.Drawing.Point(6, 97)
        Me.lbl_player2_score.Name = "lbl_player2_score"
        Me.lbl_player2_score.Size = New System.Drawing.Size(92, 25)
        Me.lbl_player2_score.TabIndex = 6
        Me.lbl_player2_score.Text = "Speler 2"
        '
        'lbl_player1_score
        '
        Me.lbl_player1_score.AutoSize = True
        Me.lbl_player1_score.Location = New System.Drawing.Point(6, 53)
        Me.lbl_player1_score.Name = "lbl_player1_score"
        Me.lbl_player1_score.Size = New System.Drawing.Size(92, 25)
        Me.lbl_player1_score.TabIndex = 5
        Me.lbl_player1_score.Text = "Speler 1"
        '
        'grp_settings
        '
        Me.grp_settings.Controls.Add(Me.btn_stop)
        Me.grp_settings.Controls.Add(Me.btn_start)
        Me.grp_settings.Controls.Add(Me.txt_player2)
        Me.grp_settings.Controls.Add(Me.txt_player1)
        Me.grp_settings.Controls.Add(Me.lbl_player2_settings)
        Me.grp_settings.Controls.Add(Me.lbl_player1_settings)
        Me.grp_settings.Location = New System.Drawing.Point(11, 7)
        Me.grp_settings.Name = "grp_settings"
        Me.grp_settings.Size = New System.Drawing.Size(416, 373)
        Me.grp_settings.TabIndex = 7
        Me.grp_settings.TabStop = False
        Me.grp_settings.Text = "Instellingen"
        '
        'btn_stop
        '
        Me.btn_stop.Location = New System.Drawing.Point(204, 240)
        Me.btn_stop.Name = "btn_stop"
        Me.btn_stop.Size = New System.Drawing.Size(144, 100)
        Me.btn_stop.TabIndex = 4
        Me.btn_stop.Text = "Stop"
        Me.btn_stop.UseVisualStyleBackColor = True
        '
        'btn_start
        '
        Me.btn_start.Location = New System.Drawing.Point(54, 240)
        Me.btn_start.Name = "btn_start"
        Me.btn_start.Size = New System.Drawing.Size(144, 100)
        Me.btn_start.TabIndex = 0
        Me.btn_start.Text = "Start"
        Me.btn_start.UseVisualStyleBackColor = True
        '
        'txt_player2
        '
        Me.txt_player2.Location = New System.Drawing.Point(11, 177)
        Me.txt_player2.Name = "txt_player2"
        Me.txt_player2.Size = New System.Drawing.Size(399, 31)
        Me.txt_player2.TabIndex = 3
        '
        'txt_player1
        '
        Me.txt_player1.Location = New System.Drawing.Point(11, 88)
        Me.txt_player1.Name = "txt_player1"
        Me.txt_player1.Size = New System.Drawing.Size(399, 31)
        Me.txt_player1.TabIndex = 2
        '
        'lbl_player2_settings
        '
        Me.lbl_player2_settings.AutoSize = True
        Me.lbl_player2_settings.Location = New System.Drawing.Point(6, 134)
        Me.lbl_player2_settings.Name = "lbl_player2_settings"
        Me.lbl_player2_settings.Size = New System.Drawing.Size(92, 25)
        Me.lbl_player2_settings.TabIndex = 1
        Me.lbl_player2_settings.Text = "Speler 2"
        '
        'lbl_player1_settings
        '
        Me.lbl_player1_settings.AutoSize = True
        Me.lbl_player1_settings.Location = New System.Drawing.Point(6, 51)
        Me.lbl_player1_settings.Name = "lbl_player1_settings"
        Me.lbl_player1_settings.Size = New System.Drawing.Size(92, 25)
        Me.lbl_player1_settings.TabIndex = 0
        Me.lbl_player1_settings.Text = "Speler 1"
        '
        'pnl_game
        '
        Me.pnl_game.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_game.AutoSize = True
        Me.pnl_game.Enabled = False
        Me.pnl_game.Location = New System.Drawing.Point(12, 12)
        Me.pnl_game.Name = "pnl_game"
        Me.pnl_game.Size = New System.Drawing.Size(737, 740)
        Me.pnl_game.TabIndex = 6
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1200, 764)
        Me.Controls.Add(Me.pnl_game)
        Me.Controls.Add(Me.pnl_controls)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(445, 835)
        Me.Name = "frmMain"
        Me.Text = "Vier Op Een Rij"
        Me.pnl_controls.ResumeLayout(False)
        Me.grp_current_player.ResumeLayout(False)
        Me.grp_current_player.PerformLayout()
        CType(Me.pic_current, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_score.ResumeLayout(False)
        Me.grp_score.PerformLayout()
        Me.grp_settings.ResumeLayout(False)
        Me.grp_settings.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnl_controls As Panel
    Friend WithEvents grp_current_player As GroupBox
    Friend WithEvents lbl_time As Label
    Friend WithEvents lbl_player_current As Label
    Friend WithEvents pic_current As PictureBox
    Friend WithEvents grp_score As GroupBox
    Friend WithEvents lbl_score2 As Label
    Friend WithEvents lbl_score1 As Label
    Friend WithEvents lbl_player2_score As Label
    Friend WithEvents lbl_player1_score As Label
    Friend WithEvents grp_settings As GroupBox
    Friend WithEvents btn_stop As Button
    Friend WithEvents btn_start As Button
    Friend WithEvents txt_player2 As TextBox
    Friend WithEvents txt_player1 As TextBox
    Friend WithEvents lbl_player2_settings As Label
    Friend WithEvents lbl_player1_settings As Label
    Friend WithEvents pnl_game As Panel
End Class
