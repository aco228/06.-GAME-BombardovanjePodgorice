Public Class _Meni

    Public Sub New(ByVal g As glavnaForma, ByVal Ger As spoljasnjiResursi)
        InitializeComponent()
        _G = g
        _res = Ger
        _baza = _G._baza
    End Sub

    ' VARIJABLE
    Dim _G As glavnaForma
    Dim _res As spoljasnjiResursi
    Dim _baza As bazaPodataka
    Public _ucitavanjeSaBazom As Boolean = False
    Dim _klik As Byte = 0 ' Provjera koji je taster kliknut
    ' 0 = Start
    ' 1 = najbolji rezultati
    ' 2 = kredits
    ' 3 = izlaz
    Dim BZM As Bitmap ' Bitmap za Menu
    Dim GZM As Graphics ' Grafika za mapu
    Dim pozadinskaSlika As Bitmap
    Dim GPS As Graphics ' Grafika za pozadisku sliku
    Dim f_konzola As crtanjeKonzoleIgrac ' Konzola igrac

    Private Sub _Meni_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' CRTANJE POZADINSKE SLIKE
        pozadinskaSlika = New Bitmap(Me.Width, Me.Height)
        GPS = Graphics.FromImage(pozadinskaSlika)
        GPS.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi._pozadina, 0, 0)
        GPS.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi._logo, 277, 176)
        GPS.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi._maliLogo, -9, 439 - 29 - 6)
        Me.BackgroundImage = pozadinskaSlika

        ' BAZA
        If _baza.greska = False Then
            _ucitavanjeSaBazom = _baza._bazaSeKoristi
            If _ucitavanjeSaBazom = True Then
                'f_konzola = New crtanjeKonzoleIgrac(GF)
                refreshKonzolaIgrac()
                'refresh_zaKonzolu.Interval = _baza.vrijemeRefreshaZaMeni
                refresh_zaKonzolu.Start()
            Else
                Cursor.Hide()
            End If
        Else
            Cursor.Hide()
        End If

        ucitavanjePanelaZaPorukuIzBaze()

        ' Inicijalizacija za meni
        If _ucitavanjeSaBazom = True Then
            BZM = New Bitmap(355, 254)
            _menuBox.Location = New System.Drawing.Point(541, 217)
            _menuBox.Size = New System.Drawing.Size(355, 254)
        Else
            BZM = New Bitmap(371, 173)
            _menuBox.Location = New System.Drawing.Point(525, 278)
            _menuBox.Size = New System.Drawing.Size(371, 173)
        End If

        GZM = Graphics.FromImage(BZM)
        kreirajMeni()

        Me.Focus()

    End Sub
    Private Sub kreirajMeni()
        GZM.Clear(Color.FromArgb(0, Color.Transparent))
        If _ucitavanjeSaBazom = True Then
            Select Case _klik
                Case 0
                    GZM.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 0)
                Case 1
                    GZM.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 35)
                Case 2
                    GZM.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 71)
                Case 3
                    GZM.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 105)
                Case 4
                    GZM.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 139)
                Case 5
                    GZM.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 173)
            End Select
            GZM.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_saBazom, 0, 0)
        Else
            Select Case _klik
                Case 0
                    GZM.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 0)
                Case 1
                    GZM.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 39)
                Case 2
                    GZM.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 79)
            End Select
            GZM.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze, 0, 0)
        End If
        _menuBox.Image = BZM
    End Sub
    Private Sub refreshKonzolaIgrac()
        If f_konzola.minimized = False Then
            f_konzola.refreshInfo()
            konzolaIgrac.Image = f_konzola.slika
        Else
            konzolaIgrac.Image = f_konzola.slikaSmall
        End If
    End Sub
    Private Sub refreshZaKonzolu_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        refreshKonzolaIgrac()
    End Sub
    Private Sub refresh_zaKonzolu_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refresh_zaKonzolu.Tick
        refreshKonzolaIgrac()
    End Sub
    Private Sub ucitavanjePanelaZaPorukuIzBaze()
        If _ucitavanjeSaBazom = True And _baza.porukaProcitanaUMeniju = False Then
            If _baza.adminIsOn = False Then
                panel_naslovPoruke.Dispose()
                panel_tekstPoruke.Dispose()
                panel_NaslovPoruke2.Text = _baza.naslovPoruke
                panel_tekstPoruke2.Text = _baza.tekstPoruke
                panel_izadji.Size = New System.Drawing.Size(74, 47)
                panel_izmjeni.Visible = False
            Else
                panel_NaslovPoruke2.Dispose()
                panel_tekstPoruke2.Dispose()
                panel_naslovPoruke.Text = _baza.naslovPoruke
                panel_tekstPoruke.Text = _baza.tekstPoruke
            End If
            _baza.porukaProcitanaUMeniju = True
        Else
            panel_poruka.Dispose()
        End If
    End Sub
    Private Sub panel_izadji_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles panel_izadji.Click
        panel_poruka.Dispose()
    End Sub

    Private Sub panel_izmjeni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles panel_izmjeni.Click
        _baza.setNovuPorukuIzBaze(panel_naslovPoruke.Text, panel_tekstPoruke.Text)
        panel_poruka.Dispose()
    End Sub
    '
    ' UNOS PREKO TASTATURE
    '
    Public _ucitanaKonzola As Boolean = False
    Dim _Kredits As PictureBox
    Dim _konzolaSviIgraci As konzolaSviIgraci
    Dim _konzolaRezultati As konzolaNajboljiRez
    Dim _kozolaPoruke As konzolaPoruke

    Private Sub _Meni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                potvrdi()
            Case Keys.Escape
                Application.Exit()
            Case Keys.S
                If _ucitavanjeSaBazom = True Then
                    If f_konzola.minimized = False Then
                        refresh_zaKonzolu.Start()
                        f_konzola.minimized = True
                    Else
                        refresh_zaKonzolu.Stop()
                        f_konzola.minimized = False
                    End If
                    refreshKonzolaIgrac()
                End If
        End Select
    End Sub
    Protected Overrides Function IsInputKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Up
                If _ucitanaKonzola = False Then
                    If _klik = 0 Then
                        If _ucitavanjeSaBazom = False Then _klik = 2
                        If _ucitavanjeSaBazom = True Then _klik = 5
                    Else
                        _klik -= 1
                    End If
                End If
            Case Keys.Down
                If _ucitanaKonzola = False Then
                    If _klik = 2 And _ucitavanjeSaBazom = False Or _klik = 5 And _ucitavanjeSaBazom = True Then
                        _klik = 0
                    Else
                        _klik += 1
                    End If
                End If
        End Select
        kreirajMeni()
        Return MyBase.IsInputKey(keyData)
    End Function
    Private Sub potvrdi()
        If _ucitavanjeSaBazom = True Then
            Select Case _klik
                Case 0
                    ' Start Igrice
                    Me.Dispose()
                    _G.ucitajVideo(1)
                    f_konzola.minimized = False
                Case 1
                    If _ucitanaKonzola = False Then ucitajRezultati()
                Case 2
                    If _ucitanaKonzola = False Then ucitajSviIgraci()
                Case 3
                    If _ucitanaKonzola = False Then ucitajPoruke()
                Case 4
        ' Kredits
        If _ucitanaKonzola = False Then
            _ucitanaKonzola = True
            _Kredits = New PictureBox()
            _Kredits.Size = New System.Drawing.Size(Me.Width, Me.Height)
            _Kredits.Location = New System.Drawing.Point(-6, -26)
            Me.Controls.Add(_Kredits)
            _Kredits.Image = New Bitmap(_res.rRes + _res.rSV + _res.rSVfiles(2))
            _Kredits.BringToFront()
        Else
            _ucitanaKonzola = False
            _Kredits.Dispose()
        End If
                Case 5
        ' Izlaz
        Application.Exit()
            End Select
        Else
            Select Case _klik
                Case 0
                    ' Start Igrice
                    Me.Dispose()
                    _G.ucitajVideo(1)
                Case 1
                    ' Kredits
                    If _ucitanaKonzola = False Then
                        _ucitanaKonzola = True
                        _Kredits = New PictureBox()
                        _Kredits.Size = New System.Drawing.Size(Me.Width, Me.Height)
                        _Kredits.Location = New System.Drawing.Point(-6, -26)
                        Me.Controls.Add(_Kredits)
                        _Kredits.Image = New Bitmap(_res.rRes + _res.rSV + _res.rSVfiles(2))
                        _Kredits.BringToFront()
                    Else
                        _ucitanaKonzola = False
                        _Kredits.Dispose()
                    End If
                Case 2
                    ' Izlaz
                    Application.Exit()
            End Select
        End If
    End Sub

    Public Sub ucitajSviIgraci()
        _ucitanaKonzola = True
        '_konzolaSviIgraci = New konzolaSviIgraci(_baza, _res, Me)
        _konzolaSviIgraci.Location = New System.Drawing.Point(60, 76)
        Me.Controls.Add(_konzolaSviIgraci)
        _konzolaSviIgraci.BringToFront()
        _konzolaSviIgraci.Show()
    End Sub
    Public Sub ucitajRezultati()
        _ucitanaKonzola = True
        '_konzolaRezultati = New konzolaNajboljiRez(_res, _baza, Me)
        _konzolaRezultati.Location = New System.Drawing.Point(60, 76)
        Me.Controls.Add(_konzolaRezultati)
        _konzolaRezultati.BringToFront()
        _konzolaRezultati.Show()
    End Sub
    Public Sub ucitajPoruke(Optional ByVal user As String = "")
        _ucitanaKonzola = True
        If user = "" Then
            '_kozolaPoruke = New konzolaPoruke(_res, _baza, Me)
        Else
            '_kozolaPoruke = New konzolaPoruke(_res, _baza, Me, user)
        End If
        _kozolaPoruke.Location = New System.Drawing.Point(60, 76)
        Me.Controls.Add(_kozolaPoruke)
        _kozolaPoruke.BringToFront()
        _kozolaPoruke.Show()
    End Sub
End Class
