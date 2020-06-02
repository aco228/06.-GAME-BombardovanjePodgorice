<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class konzolaPoruke
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
        Me.novaPoruka = New System.Windows.Forms.Button()
        Me.panelPoruka = New System.Windows.Forms.Panel()
        Me.panel_greska = New System.Windows.Forms.Label()
        Me.panel_tekst = New System.Windows.Forms.TextBox()
        Me.panel_ime = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panel_reset = New System.Windows.Forms.Button()
        Me.panel_send = New System.Windows.Forms.Button()
        Me.panel_close = New System.Windows.Forms.Button()
        Me.kontenjer = New System.Windows.Forms.FlowLayoutPanel()
        Me._promjena = New System.Windows.Forms.Button()
        Me.panelPoruka.SuspendLayout()
        Me.SuspendLayout()
        '
        'izlaz
        '
        Me.izlaz.BackColor = System.Drawing.Color.WhiteSmoke
        Me.izlaz.Location = New System.Drawing.Point(686, 7)
        Me.izlaz.Name = "izlaz"
        Me.izlaz.Size = New System.Drawing.Size(75, 23)
        Me.izlaz.TabIndex = 0
        Me.izlaz.Text = "Излаз"
        Me.izlaz.UseVisualStyleBackColor = False
        '
        'novaPoruka
        '
        Me.novaPoruka.BackColor = System.Drawing.Color.WhiteSmoke
        Me.novaPoruka.Location = New System.Drawing.Point(583, 7)
        Me.novaPoruka.Name = "novaPoruka"
        Me.novaPoruka.Size = New System.Drawing.Size(94, 23)
        Me.novaPoruka.TabIndex = 1
        Me.novaPoruka.Text = "Нова Порука"
        Me.novaPoruka.UseVisualStyleBackColor = False
        '
        'panelPoruka
        '
        Me.panelPoruka.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.panelPoruka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelPoruka.Controls.Add(Me.panel_greska)
        Me.panelPoruka.Controls.Add(Me.panel_tekst)
        Me.panelPoruka.Controls.Add(Me.panel_ime)
        Me.panelPoruka.Controls.Add(Me.Label2)
        Me.panelPoruka.Controls.Add(Me.Label1)
        Me.panelPoruka.Controls.Add(Me.panel_reset)
        Me.panelPoruka.Controls.Add(Me.panel_send)
        Me.panelPoruka.Controls.Add(Me.panel_close)
        Me.panelPoruka.Location = New System.Drawing.Point(746, 46)
        Me.panelPoruka.Name = "panelPoruka"
        Me.panelPoruka.Size = New System.Drawing.Size(310, 252)
        Me.panelPoruka.TabIndex = 2
        Me.panelPoruka.Visible = False
        '
        'panel_greska
        '
        Me.panel_greska.AutoSize = True
        Me.panel_greska.BackColor = System.Drawing.Color.Transparent
        Me.panel_greska.ForeColor = System.Drawing.Color.Navy
        Me.panel_greska.Location = New System.Drawing.Point(13, 229)
        Me.panel_greska.Name = "panel_greska"
        Me.panel_greska.Size = New System.Drawing.Size(10, 13)
        Me.panel_greska.TabIndex = 7
        Me.panel_greska.Text = " "
        '
        'panel_tekst
        '
        Me.panel_tekst.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_tekst.Location = New System.Drawing.Point(12, 101)
        Me.panel_tekst.Multiline = True
        Me.panel_tekst.Name = "panel_tekst"
        Me.panel_tekst.Size = New System.Drawing.Size(215, 123)
        Me.panel_tekst.TabIndex = 6
        '
        'panel_ime
        '
        Me.panel_ime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_ime.Location = New System.Drawing.Point(10, 53)
        Me.panel_ime.Name = "panel_ime"
        Me.panel_ime.Size = New System.Drawing.Size(217, 21)
        Me.panel_ime.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(9, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Текст Поруке:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(9, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Име Играча:"
        '
        'panel_reset
        '
        Me.panel_reset.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panel_reset.Location = New System.Drawing.Point(7, 4)
        Me.panel_reset.Name = "panel_reset"
        Me.panel_reset.Size = New System.Drawing.Size(143, 23)
        Me.panel_reset.TabIndex = 2
        Me.panel_reset.Text = "Поништи све"
        Me.panel_reset.UseVisualStyleBackColor = False
        '
        'panel_send
        '
        Me.panel_send.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panel_send.Location = New System.Drawing.Point(233, 101)
        Me.panel_send.Name = "panel_send"
        Me.panel_send.Size = New System.Drawing.Size(64, 123)
        Me.panel_send.TabIndex = 1
        Me.panel_send.Text = "Пошаљи"
        Me.panel_send.UseVisualStyleBackColor = False
        '
        'panel_close
        '
        Me.panel_close.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panel_close.Location = New System.Drawing.Point(169, 4)
        Me.panel_close.Name = "panel_close"
        Me.panel_close.Size = New System.Drawing.Size(128, 23)
        Me.panel_close.TabIndex = 0
        Me.panel_close.Text = "Затвори Панел"
        Me.panel_close.UseVisualStyleBackColor = False
        '
        'kontenjer
        '
        Me.kontenjer.AutoScroll = True
        Me.kontenjer.BackColor = System.Drawing.Color.Transparent
        Me.kontenjer.Location = New System.Drawing.Point(11, 46)
        Me.kontenjer.Name = "kontenjer"
        Me.kontenjer.Size = New System.Drawing.Size(756, 294)
        Me.kontenjer.TabIndex = 3
        '
        '_promjena
        '
        Me._promjena.BackColor = System.Drawing.Color.WhiteSmoke
        Me._promjena.Location = New System.Drawing.Point(140, 10)
        Me._promjena.Name = "_promjena"
        Me._promjena.Size = New System.Drawing.Size(151, 23)
        Me._promjena.TabIndex = 4
        Me._promjena.Text = "Послате поруке"
        Me._promjena.UseVisualStyleBackColor = False
        '
        'konzolaPoruke
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me._promjena)
        Me.Controls.Add(Me.panelPoruka)
        Me.Controls.Add(Me.kontenjer)
        Me.Controls.Add(Me.novaPoruka)
        Me.Controls.Add(Me.izlaz)
        Me.Name = "konzolaPoruke"
        Me.Size = New System.Drawing.Size(771, 351)
        Me.panelPoruka.ResumeLayout(False)
        Me.panelPoruka.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents izlaz As System.Windows.Forms.Button
    Friend WithEvents novaPoruka As System.Windows.Forms.Button
    Friend WithEvents panelPoruka As System.Windows.Forms.Panel
    Friend WithEvents panel_close As System.Windows.Forms.Button
    Friend WithEvents panel_tekst As System.Windows.Forms.TextBox
    Friend WithEvents panel_ime As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents panel_reset As System.Windows.Forms.Button
    Friend WithEvents panel_send As System.Windows.Forms.Button
    Friend WithEvents panel_greska As System.Windows.Forms.Label
    Friend WithEvents kontenjer As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents _promjena As System.Windows.Forms.Button

End Class
