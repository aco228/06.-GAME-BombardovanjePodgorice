<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class menu_login
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
        Me.username = New System.Windows.Forms.TextBox()
        Me.password = New System.Windows.Forms.TextBox()
        Me.odabir = New System.Windows.Forms.PictureBox()
        Me.Bstandard = New System.Windows.Forms.PictureBox()
        Me.Bpromjena = New System.Windows.Forms.PictureBox()
        Me.Bpotvrdi = New System.Windows.Forms.PictureBox()
        Me.tabovi = New System.Windows.Forms.PictureBox()
        Me.greskaPoruka = New System.Windows.Forms.Label()
        CType(Me.odabir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bstandard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bpromjena, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bpotvrdi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabovi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'username
        '
        Me.username.BackColor = System.Drawing.Color.FromArgb(CType(CType(121, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.username.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.username.Cursor = System.Windows.Forms.Cursors.Hand
        Me.username.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.username.ForeColor = System.Drawing.SystemColors.Info
        Me.username.Location = New System.Drawing.Point(383, 181)
        Me.username.MaxLength = 15
        Me.username.Name = "username"
        Me.username.Size = New System.Drawing.Size(177, 18)
        Me.username.TabIndex = 5
        '
        'password
        '
        Me.password.BackColor = System.Drawing.Color.FromArgb(CType(CType(121, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.password.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.password.Cursor = System.Windows.Forms.Cursors.Hand
        Me.password.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.password.ForeColor = System.Drawing.SystemColors.Info
        Me.password.Location = New System.Drawing.Point(383, 234)
        Me.password.MaxLength = 15
        Me.password.Name = "password"
        Me.password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.password.Size = New System.Drawing.Size(177, 18)
        Me.password.TabIndex = 6
        Me.password.UseSystemPasswordChar = True
        '
        'odabir
        '
        Me.odabir.BackColor = System.Drawing.Color.Transparent
        Me.odabir.Image = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.login_ulazak
        Me.odabir.Location = New System.Drawing.Point(349, 123)
        Me.odabir.Name = "odabir"
        Me.odabir.Size = New System.Drawing.Size(200, 42)
        Me.odabir.TabIndex = 4
        Me.odabir.TabStop = False
        '
        'Bstandard
        '
        Me.Bstandard.BackColor = System.Drawing.Color.Transparent
        Me.Bstandard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Bstandard.Image = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.login_standard
        Me.Bstandard.Location = New System.Drawing.Point(655, 243)
        Me.Bstandard.Name = "Bstandard"
        Me.Bstandard.Size = New System.Drawing.Size(124, 52)
        Me.Bstandard.TabIndex = 3
        Me.Bstandard.TabStop = False
        '
        'Bpromjena
        '
        Me.Bpromjena.BackColor = System.Drawing.Color.Transparent
        Me.Bpromjena.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Bpromjena.Image = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.login_registracija
        Me.Bpromjena.Location = New System.Drawing.Point(611, 181)
        Me.Bpromjena.Name = "Bpromjena"
        Me.Bpromjena.Size = New System.Drawing.Size(200, 42)
        Me.Bpromjena.TabIndex = 2
        Me.Bpromjena.TabStop = False
        '
        'Bpotvrdi
        '
        Me.Bpotvrdi.BackColor = System.Drawing.Color.Transparent
        Me.Bpotvrdi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Bpotvrdi.Image = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.login_button
        Me.Bpotvrdi.Location = New System.Drawing.Point(329, 272)
        Me.Bpotvrdi.Name = "Bpotvrdi"
        Me.Bpotvrdi.Size = New System.Drawing.Size(245, 47)
        Me.Bpotvrdi.TabIndex = 1
        Me.Bpotvrdi.TabStop = False
        '
        'tabovi
        '
        Me.tabovi.BackColor = System.Drawing.Color.Transparent
        Me.tabovi.Image = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.login_tabs
        Me.tabovi.Location = New System.Drawing.Point(329, 171)
        Me.tabovi.Name = "tabovi"
        Me.tabovi.Size = New System.Drawing.Size(245, 96)
        Me.tabovi.TabIndex = 0
        Me.tabovi.TabStop = False
        '
        'greskaPoruka
        '
        Me.greskaPoruka.AutoSize = True
        Me.greskaPoruka.BackColor = System.Drawing.Color.Transparent
        Me.greskaPoruka.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.greskaPoruka.ForeColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.greskaPoruka.Location = New System.Drawing.Point(328, 318)
        Me.greskaPoruka.Name = "greskaPoruka"
        Me.greskaPoruka.Size = New System.Drawing.Size(130, 16)
        Me.greskaPoruka.TabIndex = 7
        Me.greskaPoruka.Text = "Грешка се десила!"
        '
        'menu_login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.greskaPoruka)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.username)
        Me.Controls.Add(Me.odabir)
        Me.Controls.Add(Me.Bstandard)
        Me.Controls.Add(Me.Bpromjena)
        Me.Controls.Add(Me.Bpotvrdi)
        Me.Controls.Add(Me.tabovi)
        Me.Name = "menu_login"
        Me.Size = New System.Drawing.Size(896, 471)
        CType(Me.odabir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bstandard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bpromjena, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bpotvrdi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabovi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabovi As System.Windows.Forms.PictureBox
    Friend WithEvents Bpotvrdi As System.Windows.Forms.PictureBox
    Friend WithEvents Bpromjena As System.Windows.Forms.PictureBox
    Friend WithEvents Bstandard As System.Windows.Forms.PictureBox
    Friend WithEvents odabir As System.Windows.Forms.PictureBox
    Friend WithEvents username As System.Windows.Forms.TextBox
    Friend WithEvents password As System.Windows.Forms.TextBox
    Friend WithEvents greskaPoruka As System.Windows.Forms.Label

End Class
