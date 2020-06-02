<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class citanjePoruke
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(citanjePoruke))
        Me._od = New System.Windows.Forms.Label()
        Me._za = New System.Windows.Forms.Label()
        Me._vrijeme = New System.Windows.Forms.Label()
        Me._tekst = New System.Windows.Forms.Label()
        Me.izlaz = New System.Windows.Forms.Button()
        Me.odgovori = New System.Windows.Forms.Button()
        Me.izbrisi = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        '_od
        '
        Me._od.AutoSize = True
        Me._od.BackColor = System.Drawing.Color.Transparent
        Me._od.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._od.ForeColor = System.Drawing.Color.White
        Me._od.Location = New System.Drawing.Point(42, 5)
        Me._od.Name = "_od"
        Me._od.Size = New System.Drawing.Size(30, 16)
        Me._od.TabIndex = 0
        Me._od.Text = "test"
        '
        '_za
        '
        Me._za.AutoSize = True
        Me._za.BackColor = System.Drawing.Color.Transparent
        Me._za.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._za.ForeColor = System.Drawing.Color.White
        Me._za.Location = New System.Drawing.Point(42, 22)
        Me._za.Name = "_za"
        Me._za.Size = New System.Drawing.Size(30, 16)
        Me._za.TabIndex = 1
        Me._za.Text = "test"
        '
        '_vrijeme
        '
        Me._vrijeme.AutoSize = True
        Me._vrijeme.BackColor = System.Drawing.Color.Transparent
        Me._vrijeme.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._vrijeme.ForeColor = System.Drawing.Color.White
        Me._vrijeme.Location = New System.Drawing.Point(77, 42)
        Me._vrijeme.Name = "_vrijeme"
        Me._vrijeme.Size = New System.Drawing.Size(108, 14)
        Me._vrijeme.TabIndex = 2
        Me._vrijeme.Text = "2012-12-29 15:10:38"
        '
        '_tekst
        '
        Me._tekst.BackColor = System.Drawing.Color.Transparent
        Me._tekst.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._tekst.ForeColor = System.Drawing.Color.White
        Me._tekst.Location = New System.Drawing.Point(38, 92)
        Me._tekst.Name = "_tekst"
        Me._tekst.Size = New System.Drawing.Size(378, 160)
        Me._tekst.TabIndex = 3
        Me._tekst.Text = resources.GetString("_tekst.Text")
        '
        'izlaz
        '
        Me.izlaz.BackColor = System.Drawing.Color.WhiteSmoke
        Me.izlaz.Location = New System.Drawing.Point(371, 1)
        Me.izlaz.Name = "izlaz"
        Me.izlaz.Size = New System.Drawing.Size(75, 23)
        Me.izlaz.TabIndex = 4
        Me.izlaz.Text = "Излаз"
        Me.izlaz.UseVisualStyleBackColor = False
        '
        'odgovori
        '
        Me.odgovori.BackColor = System.Drawing.Color.WhiteSmoke
        Me.odgovori.Location = New System.Drawing.Point(371, 24)
        Me.odgovori.Name = "odgovori"
        Me.odgovori.Size = New System.Drawing.Size(75, 23)
        Me.odgovori.TabIndex = 5
        Me.odgovori.Text = "Одговори"
        Me.odgovori.UseVisualStyleBackColor = False
        '
        'izbrisi
        '
        Me.izbrisi.BackColor = System.Drawing.Color.WhiteSmoke
        Me.izbrisi.Location = New System.Drawing.Point(371, 47)
        Me.izbrisi.Name = "izbrisi"
        Me.izbrisi.Size = New System.Drawing.Size(75, 23)
        Me.izbrisi.TabIndex = 6
        Me.izbrisi.Text = "Избриши"
        Me.izbrisi.UseVisualStyleBackColor = False
        '
        'citanjePoruke
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(450, 276)
        Me.Controls.Add(Me.izbrisi)
        Me.Controls.Add(Me.odgovori)
        Me.Controls.Add(Me.izlaz)
        Me.Controls.Add(Me._tekst)
        Me.Controls.Add(Me._vrijeme)
        Me.Controls.Add(Me._za)
        Me.Controls.Add(Me._od)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximumSize = New System.Drawing.Size(466, 310)
        Me.MinimumSize = New System.Drawing.Size(466, 310)
        Me.Name = "citanjePoruke"
        Me.Text = "Читање поруке"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _od As System.Windows.Forms.Label
    Friend WithEvents _za As System.Windows.Forms.Label
    Friend WithEvents _vrijeme As System.Windows.Forms.Label
    Friend WithEvents _tekst As System.Windows.Forms.Label
    Friend WithEvents izlaz As System.Windows.Forms.Button
    Friend WithEvents odgovori As System.Windows.Forms.Button
    Friend WithEvents izbrisi As System.Windows.Forms.Button
End Class
