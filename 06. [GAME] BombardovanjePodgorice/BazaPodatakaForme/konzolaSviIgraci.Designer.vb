<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class konzolaSviIgraci
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
        Me.kontenjer = New System.Windows.Forms.FlowLayoutPanel()
        Me.izlazak = New System.Windows.Forms.Button()
        Me.brIgraca = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'kontenjer
        '
        Me.kontenjer.AutoScroll = True
        Me.kontenjer.BackColor = System.Drawing.Color.Transparent
        Me.kontenjer.Location = New System.Drawing.Point(15, 53)
        Me.kontenjer.Name = "kontenjer"
        Me.kontenjer.Size = New System.Drawing.Size(753, 281)
        Me.kontenjer.TabIndex = 0
        '
        'izlazak
        '
        Me.izlazak.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.izlazak.Location = New System.Drawing.Point(681, 9)
        Me.izlazak.Name = "izlazak"
        Me.izlazak.Size = New System.Drawing.Size(75, 23)
        Me.izlazak.TabIndex = 1
        Me.izlazak.Text = "Излазак"
        Me.izlazak.UseVisualStyleBackColor = False
        '
        'brIgraca
        '
        Me.brIgraca.AutoSize = True
        Me.brIgraca.BackColor = System.Drawing.Color.Transparent
        Me.brIgraca.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.brIgraca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.brIgraca.Location = New System.Drawing.Point(247, 14)
        Me.brIgraca.Name = "brIgraca"
        Me.brIgraca.Size = New System.Drawing.Size(124, 16)
        Me.brIgraca.TabIndex = 2
        Me.brIgraca.Text = "Ukupno 15 igraca!"
        '
        'konzolaSviIgraci
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.brIgraca)
        Me.Controls.Add(Me.izlazak)
        Me.Controls.Add(Me.kontenjer)
        Me.Name = "konzolaSviIgraci"
        Me.Size = New System.Drawing.Size(771, 351)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents kontenjer As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents izlazak As System.Windows.Forms.Button
    Friend WithEvents brIgraca As System.Windows.Forms.Label

End Class
