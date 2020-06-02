<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class konzolaNajboljiRez
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
        Me.izlaz = New System.Windows.Forms.Button()
        Me.kontenjer = New System.Windows.Forms.FlowLayoutPanel()
        Me.SuspendLayout()
        '
        'izlaz
        '
        Me.izlaz.BackColor = System.Drawing.Color.WhiteSmoke
        Me.izlaz.Location = New System.Drawing.Point(684, 7)
        Me.izlaz.Name = "izlaz"
        Me.izlaz.Size = New System.Drawing.Size(75, 23)
        Me.izlaz.TabIndex = 0
        Me.izlaz.Text = "Излаз"
        Me.izlaz.UseVisualStyleBackColor = False
        '
        'kontenjer
        '
        Me.kontenjer.AutoScroll = True
        Me.kontenjer.BackColor = System.Drawing.Color.Transparent
        Me.kontenjer.Location = New System.Drawing.Point(13, 52)
        Me.kontenjer.Name = "kontenjer"
        Me.kontenjer.Size = New System.Drawing.Size(755, 281)
        Me.kontenjer.TabIndex = 1
        '
        'konzolaNajboljiRez
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kontenjer)
        Me.Controls.Add(Me.izlaz)
        Me.Name = "konzolaNajboljiRez"
        Me.Size = New System.Drawing.Size(771, 351)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents izlaz As System.Windows.Forms.Button
    Friend WithEvents kontenjer As System.Windows.Forms.FlowLayoutPanel

End Class
