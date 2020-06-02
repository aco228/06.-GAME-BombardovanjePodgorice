<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _Meni2
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
        Me.components = New System.ComponentModel.Container()
        Me.panel_poruka = New System.Windows.Forms.Panel()
        Me.panel_tekstPoruke = New System.Windows.Forms.TextBox()
        Me.panel_naslovPoruke = New System.Windows.Forms.TextBox()
        Me.panel_tekstPoruke2 = New System.Windows.Forms.Label()
        Me.panel_NaslovPoruke2 = New System.Windows.Forms.Label()
        Me.panel_izmjeni = New System.Windows.Forms.Button()
        Me.panel_izadji = New System.Windows.Forms.Button()
        Me._menuBox = New System.Windows.Forms.PictureBox()
        Me.konzolaIgrac = New System.Windows.Forms.PictureBox()
        Me.refreshKonzolaIgrac = New System.Windows.Forms.Timer(Me.components)
        Me.ucitavanjeMenija = New System.ComponentModel.BackgroundWorker()
        Me.panel_poruka.SuspendLayout()
        CType(Me._menuBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.konzolaIgrac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel_poruka
        '
        Me.panel_poruka.BackColor = System.Drawing.Color.Transparent
        Me.panel_poruka.BackgroundImage = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.meni_poruka_back
        Me.panel_poruka.Controls.Add(Me.panel_tekstPoruke)
        Me.panel_poruka.Controls.Add(Me.panel_naslovPoruke)
        Me.panel_poruka.Controls.Add(Me.panel_tekstPoruke2)
        Me.panel_poruka.Controls.Add(Me.panel_NaslovPoruke2)
        Me.panel_poruka.Controls.Add(Me.panel_izmjeni)
        Me.panel_poruka.Controls.Add(Me.panel_izadji)
        Me.panel_poruka.Location = New System.Drawing.Point(559, -5)
        Me.panel_poruka.Name = "panel_poruka"
        Me.panel_poruka.Size = New System.Drawing.Size(325, 70)
        Me.panel_poruka.TabIndex = 3
        Me.panel_poruka.Visible = False
        '
        'panel_tekstPoruke
        '
        Me.panel_tekstPoruke.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.panel_tekstPoruke.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.panel_tekstPoruke.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.panel_tekstPoruke.ForeColor = System.Drawing.Color.White
        Me.panel_tekstPoruke.Location = New System.Drawing.Point(21, 31)
        Me.panel_tekstPoruke.Multiline = True
        Me.panel_tekstPoruke.Name = "panel_tekstPoruke"
        Me.panel_tekstPoruke.Size = New System.Drawing.Size(213, 30)
        Me.panel_tekstPoruke.TabIndex = 3
        Me.panel_tekstPoruke.TabStop = False
        Me.panel_tekstPoruke.Text = "Naslov poruke"
        '
        'panel_naslovPoruke
        '
        Me.panel_naslovPoruke.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.panel_naslovPoruke.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.panel_naslovPoruke.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.panel_naslovPoruke.ForeColor = System.Drawing.Color.White
        Me.panel_naslovPoruke.Location = New System.Drawing.Point(10, 12)
        Me.panel_naslovPoruke.Name = "panel_naslovPoruke"
        Me.panel_naslovPoruke.Size = New System.Drawing.Size(100, 21)
        Me.panel_naslovPoruke.TabIndex = 0
        Me.panel_naslovPoruke.TabStop = False
        Me.panel_naslovPoruke.Text = "Naslov poruke"
        '
        'panel_tekstPoruke2
        '
        Me.panel_tekstPoruke2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.panel_tekstPoruke2.ForeColor = System.Drawing.Color.White
        Me.panel_tekstPoruke2.Location = New System.Drawing.Point(18, 33)
        Me.panel_tekstPoruke2.Name = "panel_tekstPoruke2"
        Me.panel_tekstPoruke2.Size = New System.Drawing.Size(216, 27)
        Me.panel_tekstPoruke2.TabIndex = 2
        Me.panel_tekstPoruke2.Text = "Текст Поруке"
        '
        'panel_NaslovPoruke2
        '
        Me.panel_NaslovPoruke2.AutoSize = True
        Me.panel_NaslovPoruke2.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.panel_NaslovPoruke2.ForeColor = System.Drawing.Color.White
        Me.panel_NaslovPoruke2.Location = New System.Drawing.Point(6, 12)
        Me.panel_NaslovPoruke2.Name = "panel_NaslovPoruke2"
        Me.panel_NaslovPoruke2.Size = New System.Drawing.Size(118, 21)
        Me.panel_NaslovPoruke2.TabIndex = 1
        Me.panel_NaslovPoruke2.Text = "Наслов поруке"
        '
        'panel_izmjeni
        '
        Me.panel_izmjeni.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panel_izmjeni.Location = New System.Drawing.Point(240, 37)
        Me.panel_izmjeni.Name = "panel_izmjeni"
        Me.panel_izmjeni.Size = New System.Drawing.Size(75, 23)
        Me.panel_izmjeni.TabIndex = 0
        Me.panel_izmjeni.TabStop = False
        Me.panel_izmjeni.Text = "Измјени"
        Me.panel_izmjeni.UseVisualStyleBackColor = False
        '
        'panel_izadji
        '
        Me.panel_izadji.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panel_izadji.Location = New System.Drawing.Point(240, 14)
        Me.panel_izadji.Name = "panel_izadji"
        Me.panel_izadji.Size = New System.Drawing.Size(75, 23)
        Me.panel_izadji.TabIndex = 0
        Me.panel_izadji.TabStop = False
        Me.panel_izadji.Text = "Угаси"
        Me.panel_izadji.UseVisualStyleBackColor = False
        '
        '_menuBox
        '
        Me._menuBox.BackColor = System.Drawing.Color.Transparent
        Me._menuBox.Location = New System.Drawing.Point(532, 271)
        Me._menuBox.Name = "_menuBox"
        Me._menuBox.Size = New System.Drawing.Size(378, 212)
        Me._menuBox.TabIndex = 4
        Me._menuBox.TabStop = False
        '
        'konzolaIgrac
        '
        Me.konzolaIgrac.BackColor = System.Drawing.Color.Transparent
        Me.konzolaIgrac.Location = New System.Drawing.Point(11, 9)
        Me.konzolaIgrac.Name = "konzolaIgrac"
        Me.konzolaIgrac.Size = New System.Drawing.Size(192, 63)
        Me.konzolaIgrac.TabIndex = 5
        Me.konzolaIgrac.TabStop = False
        '
        'refreshKonzolaIgrac
        '
        '
        'ucitavanjeMenija
        '
        Me.ucitavanjeMenija.WorkerReportsProgress = True
        Me.ucitavanjeMenija.WorkerSupportsCancellation = True
        '
        '_Meni2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.konzolaIgrac)
        Me.Controls.Add(Me._menuBox)
        Me.Controls.Add(Me.panel_poruka)
        Me.Name = "_Meni2"
        Me.Size = New System.Drawing.Size(910, 506)
        Me.panel_poruka.ResumeLayout(False)
        Me.panel_poruka.PerformLayout()
        CType(Me._menuBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.konzolaIgrac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panel_poruka As System.Windows.Forms.Panel
    Friend WithEvents panel_tekstPoruke As System.Windows.Forms.TextBox
    Friend WithEvents panel_naslovPoruke As System.Windows.Forms.TextBox
    Friend WithEvents panel_tekstPoruke2 As System.Windows.Forms.Label
    Friend WithEvents panel_NaslovPoruke2 As System.Windows.Forms.Label
    Friend WithEvents panel_izmjeni As System.Windows.Forms.Button
    Friend WithEvents panel_izadji As System.Windows.Forms.Button
    Friend WithEvents _menuBox As System.Windows.Forms.PictureBox
    Friend WithEvents konzolaIgrac As System.Windows.Forms.PictureBox
    Friend WithEvents refreshKonzolaIgrac As System.Windows.Forms.Timer
    Friend WithEvents ucitavanjeMenija As System.ComponentModel.BackgroundWorker

End Class
