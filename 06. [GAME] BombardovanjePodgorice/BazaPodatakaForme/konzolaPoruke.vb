Public Class konzolaPoruke
    Public Sub New(ByVal r As spoljasnjiResursi, ByVal b As bazaPodataka, ByVal m As _Meni2)
        InitializeComponent()
        _res = r
        _baza = b
        _M = m
    End Sub
    Public Sub New(ByVal r As spoljasnjiResursi, ByVal b As bazaPodataka, ByVal m As _Meni2, ByVal user As String)
        InitializeComponent()
        _res = r
        _baza = b
        _M = m
        ucitajNovuPoruku(user)
    End Sub

    Dim _res As spoljasnjiResursi
    Dim _baza As bazaPodataka
    Dim _M As _Meni2


    Private Sub konzolaPoruke_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = System.Windows.Forms.Cursors.Default
        crtanjePozadine()
        Me.Show()
        Cursor.Show()
        ucitavanjePoruka()
    End Sub
    Private Sub crtanjePozadine()
        Dim b As Bitmap = New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(b)
        g.DrawImage(New Bitmap(_res.rRes + _res.rSV + _res.rSVfiles(7)), 0, 0)
        g.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_poruke_logo, 18, 13)
        Me.BackgroundImage = b
    End Sub

    Private Sub izlaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles izlaz.Click
        panel_ime.Text = ""
        panel_tekst.Text = ""
        panel_greska.Text = ""
        _M._ucitanaKonzola = False
        Cursor.Hide()
        Me.Dispose()
    End Sub

    '
    ' NOVA PORUKA
    '
    Private Sub novaPoruka_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles novaPoruka.Click
        ucitajNovuPoruku()
    End Sub
    Public Sub ucitajNovuPoruku(Optional ByVal user As String = "")
        panelPoruka.Visible = True
        panelPoruka.Location = New System.Drawing.Point(223, 51)
        panel_ime.Text = user
    End Sub

    Private Sub iskljuciPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles panel_close.Click
        panelPoruka.Visible = False
        panel_ime.Text = ""
        panel_tekst.Text = ""
    End Sub

    Private Sub panel_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles panel_reset.Click
        panel_ime.Text = ""
        panel_tekst.Text = ""
    End Sub

    Private Sub panel_send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles panel_send.Click
        If panel_ime.Text = "" Or panel_tekst.Text = "" Then
            setGreska(0, "Неко од поља није унијето!")
        Else
            Dim s As String = _baza.slanjePoruke(panel_ime.Text, panel_tekst.Text)
            If s = "" Then setGreska(1, "Порука успјешно послата")
            If Not s = "" Then setGreska(0, s)
        End If
    End Sub
    Private Sub setGreska(ByVal i As Integer, ByVal d As String)
        Select Case i
            Case 0
                panel_greska.ForeColor = Color.FromArgb(64, 0, 0)
                panel_greska.Text = d
            Case 1
                panel_greska.ForeColor = Color.Navy
                panel_greska.Text = d
        End Select
    End Sub
    Private Sub panel_greska_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles panel_greska.MouseHover
        panel_greska.Text = ""
    End Sub

    '
    '   KONZOLA
    '
    Dim poslate As Boolean = False

    Private Sub _promjena_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _promjena.Click
        If poslate = False Then
            poslate = True
            _promjena.Text = "Примљене поруке"
        Else
            poslate = False
            _promjena.Text = "Послате поруке"
        End If
        ucitavanjePoruka()
    End Sub

    Dim lista As String(,)
    Dim slika As PictureBox
    Dim citanjePoruke As citanjePoruke

    Private Sub ucitavanjePoruka()
        If poslate = True Then
            lista = _baza.poslatePoruke()
        Else
            lista = _baza.primljenePoruke()
        End If
        If Not IsNothing(lista) Then izlistavanjePoruka()
    End Sub
    Dim neProcitanePoruke As Integer = 0
    Private Sub izlistavanjePoruka()
        kontenjer.Controls.Clear()
        For i As Integer = 0 To (lista.Length / 5) - 1
            slika = New PictureBox()
            slika.Size = New System.Drawing.Size(732, 20)
            Dim b As Bitmap = New Bitmap(slika.Width, slika.Height)
            Dim g As Graphics = Graphics.FromImage(b)

            If lista(i, 2) = "1" Then g.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_poruka_neprocitano, 0, 0)
            If lista(i, 2) = "0" Or lista(i, 2) = "3" Then g.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_poruka_procitano, 0, 0)


            If poslate = True Then g.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_poruka_za, 53, 3)
            If poslate = False Then g.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_poruka_od, 53, 3)

            g.DrawString((i + 1).ToString() & ")", New Font("Arial", 10), New SolidBrush(Color.FromArgb(255, 233, 233, 233)), 6, 1)
            g.DrawString(lista(i, 3), New Font("Arial", 10), New SolidBrush(Color.FromArgb(255, 233, 233, 233)), 79, 1)
            If lista(i, 1).Length > 10 Then g.DrawString(lista(i, 1).Substring(0, 10) & "...", New Font("Arial", 10), New SolidBrush(Color.FromArgb(255, 233, 233, 233)), 300, 1)
            If lista(i, 1).Length < 10 Then g.DrawString(lista(i, 1), New Font("Arial", 10), New SolidBrush(Color.FromArgb(255, 233, 233, 233)), 300, 1)

            If lista(i, 2) = 1 And poslate = False Then neProcitanePoruke += 1
            If lista(i, 2) = 1 Then g.DrawString("непрочитано", New Font("Arial", 10), New SolidBrush(Color.FromArgb(255, 233, 233, 233)), 626, 1)
            If lista(i, 2) = 0 Or lista(i, 2) = 3 Then g.DrawString("прочитано", New Font("Arial", 10), New SolidBrush(Color.FromArgb(255, 233, 233, 233)), 626, 1)

            slika.BackgroundImage = b
            slika.Show()
            slika.Tag = i
            AddHandler slika.Click, AddressOf porukaKlik
            slika.Cursor = Cursors.Hand
            kontenjer.Controls.Add(slika)
        Next
        _M.updateKonzolaIgrac("poruka", neProcitanePoruke)
    End Sub
    Private Sub porukaKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim slika = CType(sender, PictureBox)
        citanjePoruke = New citanjePoruke(Me, lista(slika.Tag, 0), lista(slika.Tag, 1), lista(slika.Tag, 3), poslate, lista(slika.Tag, 4), _baza, lista(slika.Tag, 2))
        citanjePoruke.Show()
    End Sub
End Class
