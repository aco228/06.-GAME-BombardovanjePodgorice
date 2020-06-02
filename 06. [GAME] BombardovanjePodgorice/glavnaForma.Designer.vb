<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class glavnaForma
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(glavnaForma))
        Me._sekundT = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        '_sekundT
        '
        Me._sekundT.Interval = 1000
        '
        'glavnaForma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.BackgroundImage = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi._pozadina
        Me.ClientSize = New System.Drawing.Size(894, 468)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(910, 506)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(910, 506)
        Me.Name = "glavnaForma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bombardovanje Podgorice"
        Me.TransparencyKey = System.Drawing.SystemColors.MenuHighlight
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents _sekundT As System.Windows.Forms.Timer

End Class
