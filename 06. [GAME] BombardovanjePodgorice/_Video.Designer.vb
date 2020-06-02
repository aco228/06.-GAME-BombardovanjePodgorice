<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _Video
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(_Video))
        Me._player = New AxWMPLib.AxWindowsMediaPlayer()
        CType(Me._player, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_player
        '
        Me._player.Enabled = True
        Me._player.Location = New System.Drawing.Point(-4, -4)
        Me._player.Name = "_player"
        Me._player.OcxState = CType(resources.GetObject("_player.OcxState"), System.Windows.Forms.AxHost.State)
        Me._player.Size = New System.Drawing.Size(910, 506)
        Me._player.TabIndex = 0
        Me._player.TabStop = False
        '
        '_Video
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me._player)
        Me.Name = "_Video"
        Me.Size = New System.Drawing.Size(910, 506)
        CType(Me._player, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents _player As AxWMPLib.AxWindowsMediaPlayer

End Class
