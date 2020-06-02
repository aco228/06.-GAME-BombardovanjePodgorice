Imports System.Threading
Public Class _Meni2
    Public Sub New(ByVal g As glavnaForma)
        InitializeComponent()
        GF = g
    End Sub

    ' UCITAVANJE VARIJABLE
    Public GF As glavnaForma
    Dim pozadinskaSlika As Bitmap
    Dim GPS As Graphics ' Grafika pozadinska slika
    Dim ucitavanjeSaBazom As Boolean

    Private Sub _Meni2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' CRTANJE POZADINE
        pozadinskaSlika = New Bitmap(Me.Width, Me.Height)
        GPS = Graphics.FromImage(pozadinskaSlika)
        GPS.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi._pozadina, 0, 0)
        GPS.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi._logo, 277, 176)
        GPS.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi._maliLogo, -9, 439 - 29 - 6)
        Me.BackgroundImage = pozadinskaSlika
        GPS.Dispose()

        ' BAZA
        ucitavanjeSaBazom = GF._baza._bazaSeKoristi
        If ucitavanjeSaBazom = True Then
            inicijalizacijaSaBazom()
        Else
            inicijalizacijaBezBaze()
        End If

        Me.Focus()

    End Sub

    ' MENI VARIJABLE
    Dim menuOpcije As Bitmap
    Dim GMO As Graphics ' Grafika menu opcije
    Dim _klik As Integer = 0
    Dim _kredits As PictureBox
    Public _ucitanaKonzola As Boolean

#Region "BEZ BAZE PODATAKA"

    Private Sub inicijalizacijaBezBaze()
        menuOpcije = New Bitmap(371, 173)
        _menuBox.Location = New System.Drawing.Point(525, 278)
        _menuBox.Size = New System.Drawing.Size(371, 173)
        GMO = Graphics.FromImage(menuOpcije)
        kreirajMeni()

        Cursor.Hide()
        konzolaIgrac.Dispose()
    End Sub

    Private Sub potvrdiBezBaze()
        Select Case _klik
            Case 0
                Me.Dispose()
                GF.ucitajVideo(1)
            Case 1 : ucitajKredits()
            Case 2 : Application.Exit()
        End Select
    End Sub

#End Region

#Region "SA BAZOM PODATAKA"

    ' VARIJABLE
    Dim _konzolaSviIgraci As konzolaSviIgraci
    Dim _konzolaRezultati As konzolaNajboljiRez
    Dim _kozolaPoruke As konzolaPoruke

    ' METODE
    Private Sub inicijalizacijaSaBazom()
        menuOpcije = New Bitmap(355, 254)
        _menuBox.Location = New System.Drawing.Point(541, 217)
        _menuBox.Size = New System.Drawing.Size(355, 254)
        GMO = Graphics.FromImage(menuOpcije)

        konzolaIgrac_Inicijalizacija()

    End Sub

    Private Sub potvrdiSaBazom()
        Select Case _klik
            Case 0
                Me.Dispose()
                GF.ucitajVideo(1)
            Case 1 : ucitajRezultati()
            Case 2 : ucitajSviIgraci()
            Case 3 : ucitajPoruke()
            Case 4 : ucitajKredits()
            Case 5 : Application.Exit()
        End Select
    End Sub

#Region "panel_poruka"
    Private Sub inicijalizacijaPanela()
        If GF._baza.adminIsOn = False Then
            panel_naslovPoruke.Visible = False
            panel_tekstPoruke.Visible = False
            panel_NaslovPoruke2.Text = GF._baza.naslovPoruke
            panel_tekstPoruke2.Text = GF._baza.tekstPoruke
            panel_izadji.Size = New System.Drawing.Size(74, 47)
            panel_izmjeni.Visible = False
        Else
            panel_NaslovPoruke2.Visible = False
            panel_tekstPoruke2.Visible = False
            panel_naslovPoruke.Text = GF._baza.naslovPoruke
            panel_tekstPoruke.Text = GF._baza.tekstPoruke
        End If
        GF._baza.porukaProcitanaUMeniju = True
        panel_poruka.Visible = True
    End Sub
    Private Sub panel_izadji_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        panel_poruka.Dispose()
    End Sub
    Private Sub panel_izmjeni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles panel_izmjeni.Click
        GF._baza.setNovuPorukuIzBaze(panel_naslovPoruke.Text, panel_tekstPoruke.Text)
        panel_poruka.Dispose()
    End Sub
#End Region

#Region "Konzola Igrac"
    Dim vrijemeRefreshaKonzoleIgrac As Integer = 6000
    Private Sub konzolaIgrac_Inicijalizacija()
        GF.f_konzolaIgrac = New crtanjeKonzoleIgrac(GF)

        kreirajMeni(1)
        ucitavanjeMenija.RunWorkerAsync()

        refreshKonzolaIgrac.Interval = vrijemeRefreshaKonzoleIgrac
        refreshKonzolaIgrac.Start()
    End Sub
    Private Sub konzolaIgrac_refresh(Optional ByVal zad As Integer = 0)
        If GF.f_konzolaIgrac.minimized = False Then
            If zad = 0 Then GF.f_konzolaIgrac.refreshInfo()
            konzolaIgrac.Image = GF.f_konzolaIgrac.slika
        Else
            konzolaIgrac.Image = GF.f_konzolaIgrac.slikaSmall
        End If
    End Sub
    Private Sub refreshKonzolaIgrac_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refreshKonzolaIgrac.Tick
        If Not ucitavanjeMenija.IsBusy Then ucitavanjeMenija.RunWorkerAsync()
    End Sub

    ' BACKGROUND WORKER
    Dim prvoUcitavanje As Boolean = True
    Private Sub ucitavanjeMenija_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ucitavanjeMenija.DoWork

        If GF.f_konzolaIgrac.minimized = False Then
            GF.f_konzolaIgrac.refreshInfo()
            konzolaIgrac.Image = GF.f_konzolaIgrac.slika
        Else
            konzolaIgrac.Image = GF.f_konzolaIgrac.slikaSmall
        End If

        If prvoUcitavanje = True Then
            refreshKonzolaIgrac.Interval = vrijemeRefreshaKonzoleIgrac
            refreshKonzolaIgrac.Start()
        End If

    End Sub
    Private Sub ucitavanjeMenija_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ucitavanjeMenija.RunWorkerCompleted
        If prvoUcitavanje = True Then
            kreirajMeni()
            If GF._baza.porukaProcitanaUMeniju = False Then inicijalizacijaPanela()
            prvoUcitavanje = False
        End If
    End Sub
#End Region

    Private Sub ucitajSviIgraci()
        If _ucitanaKonzola = True Then Exit Sub
        _ucitanaKonzola = True
        _konzolaSviIgraci = New konzolaSviIgraci(GF._baza, GF._res, Me)
        _konzolaSviIgraci.Location = New System.Drawing.Point(60, 76)
        Me.Controls.Add(_konzolaSviIgraci)
        _konzolaSviIgraci.BringToFront()
        _konzolaSviIgraci.Show()
    End Sub
    Private Sub ucitajRezultati()
        If _ucitanaKonzola = True Then Exit Sub
        _ucitanaKonzola = True
        _konzolaRezultati = New konzolaNajboljiRez(Me, GF._res, GF._baza)
        _konzolaRezultati.Location = New System.Drawing.Point(60, 76)
        Me.Controls.Add(_konzolaRezultati)
        _konzolaRezultati.BringToFront()
        _konzolaRezultati.Show()
    End Sub
    Public Sub ucitajPoruke(Optional ByVal user As String = "")
        If _ucitanaKonzola = True Then Exit Sub
        _ucitanaKonzola = True
        If user = "" Then
            _kozolaPoruke = New konzolaPoruke(GF._res, GF._baza, Me)
        Else
            _kozolaPoruke = New konzolaPoruke(GF._res, GF._baza, Me, user)
        End If
        _kozolaPoruke.Location = New System.Drawing.Point(60, 76)
        Me.Controls.Add(_kozolaPoruke)
        _kozolaPoruke.BringToFront()
        _kozolaPoruke.Show()
    End Sub
    Public Sub updateKonzolaIgrac(ByVal zadatak As String, ByVal pro As Integer)
        GF.f_konzolaIgrac.refreshInfoBezBaze(zadatak, pro)
        konzolaIgrac_refresh(1)
    End Sub

#End Region

#Region "Zajednicke Metode"

    Private Sub kreirajMeni(Optional ByVal zad As Integer = 0)
        GMO.Clear(Color.Transparent)
        If zad > 0 Then
            GMO.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_ucitavanje, 115, 103)
            _menuBox.Image = menuOpcije
            Exit Sub
        End If

        If ucitavanjeSaBazom = True Then
            Select Case _klik
                Case 0 : GMO.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 0)
                Case 1 : GMO.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 35)
                Case 2 : GMO.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 71)
                Case 3 : GMO.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 105)
                Case 4 : GMO.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 139)
                Case 5 : GMO.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 173)
            End Select
            GMO.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_saBazom, 0, 0)
        Else
            Select Case _klik
                Case 0 : GMO.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 0)
                Case 1 : GMO.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 39)
                Case 2 : GMO.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze_over, 0, 79)
            End Select
            GMO.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.menu_bezBaze, 0, 0)
        End If
        _menuBox.Image = menuOpcije
    End Sub
    Private Sub ucitajKredits()
        If _ucitanaKonzola = False Then
            _ucitanaKonzola = True
            _kredits = New PictureBox()
            _kredits.Size = New System.Drawing.Size(Me.Width, Me.Height)
            _kredits.Location = New System.Drawing.Point(-6, -26)
            Me.Controls.Add(_kredits)
            _kredits.Image = New Bitmap(GF._res.rRes + GF._res.rSV + GF._res.rSVfiles(2))
            _kredits.BringToFront()
        Else
            _ucitanaKonzola = False
            _kredits.Dispose()
        End If
    End Sub
    Protected Overrides Function IsInputKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If _ucitanaKonzola = True Then Return MyBase.IsInputKey(keyData)
        Select Case keyData
            Case Keys.Up
                If _klik = 0 Then
                    If ucitavanjeSaBazom = False Then _klik = 2
                    If ucitavanjeSaBazom = True Then _klik = 5
                Else
                    _klik -= 1
                End If
            Case Keys.Down
                If _klik = 2 And ucitavanjeSaBazom = False Or _klik = 5 And ucitavanjeSaBazom = True Then
                    _klik = 0
                Else
                    _klik += 1
                End If
        End Select
        kreirajMeni()
        Return MyBase.IsInputKey(keyData)
    End Function
    Private Sub _Meni2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If ucitavanjeSaBazom = True Then potvrdiSaBazom()
                If ucitavanjeSaBazom = False Then potvrdiBezBaze()
            Case Keys.Escape : Application.Exit()
            Case Keys.S
                If GF._baza._bazaSeKoristi = True Then
                    If GF.f_konzolaIgrac.minimized = True Then
                        GF.f_konzolaIgrac.minimized = False
                    Else
                        GF.f_konzolaIgrac.minimized = True
                    End If
                    konzolaIgrac_refresh()
                End If

        End Select
    End Sub
#End Region
End Class
