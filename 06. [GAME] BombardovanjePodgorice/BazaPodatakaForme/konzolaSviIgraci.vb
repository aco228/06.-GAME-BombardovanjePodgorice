Public Class konzolaSviIgraci
    Public Sub New(ByVal b As bazaPodataka, ByVal r As spoljasnjiResursi, ByVal m As _Meni2)
        InitializeComponent()
        _baza = b
        _res = r
        _meni = m
    End Sub
    Dim _baza As bazaPodataka
    Dim _res As spoljasnjiResursi
    Dim _meni As _Meni2
    Dim igrac As PictureBox
    Dim listaIgraca(,) As String

    Private Sub konzolaSviIgraci_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = System.Windows.Forms.Cursors.Default
        crtanjePozadine()
        Me.Show()
        Cursor.Show()
        brIgraca.Text = ""
        listaIgraca = _baza.listaIgraca()
        If Not IsNothing(listaIgraca) Then crtanjeListe()
    End Sub
    Private Sub crtanjePozadine()
        Dim b As Bitmap = New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(b)
        g.DrawImage(New Bitmap(_res.rRes + _res.rSV + _res.rSVfiles(7)), 0, 0)
        g.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_sviIgraci_logo, 31, 14)
        Me.BackgroundImage = b
    End Sub
    Dim onlineIgraci As Integer = 0
    Private Sub crtanjeListe()
        'MessageBox.Show(listaIgraca.Length)
        brIgraca.Text = "Укупно " & (listaIgraca.Length / 2) & " играча!"
        For i As Integer = 0 To (listaIgraca.Length / 2) - 1
            'MessageBox.Show(spisakIgraca.IndexOf(i) & " |   " & onlineIgraci.IndexOf(i))
            igrac = New PictureBox()
            igrac.Cursor = System.Windows.Forms.Cursors.Hand
            igrac.Size = New System.Drawing.Size(725, 22)
            Dim b As Bitmap = New Bitmap(igrac.Width, igrac.Height)
            Dim g As Graphics = Graphics.FromImage(b)
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

            If listaIgraca(i, 1) = "0" Then onlineIgraci += 1
            If listaIgraca(i, 1) = "0" Then g.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_sviIgraci_online, 0, 0)
            If listaIgraca(i, 1) = "1" Then g.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_sviIgraci_offline, 0, 0)
            g.DrawString((i + 1).ToString() & " )       " & listaIgraca(i, 0), New Font("Arial", 12), Brushes.White, 4, 2)
            igrac.Image = b

            igrac.Show()
            igrac.Tag = i
            AddHandler igrac.Click, AddressOf Klik

            kontenjer.Controls.Add(igrac)
        Next
        _meni.updateKonzolaIgrac("igraci", onlineIgraci)
    End Sub
    Private Sub Klik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim kliknutaSlika = CType(sender, PictureBox)
        If Not listaIgraca(kliknutaSlika.Tag, 0) = _baza.userName Then
            _meni._ucitanaKonzola = False
            Me.Dispose()
            _meni.ucitajPoruke(listaIgraca(kliknutaSlika.Tag, 0))
        Else
            MessageBox.Show("Глупо би било да сами себи пошаљете поруку")
        End If
    End Sub
    Private Sub izlazak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles izlazak.Click
        _meni._ucitanaKonzola = False
        Cursor.Hide()
        Me.Dispose()
    End Sub

End Class
