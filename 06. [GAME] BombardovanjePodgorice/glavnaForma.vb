Imports System.IO
Public Class glavnaForma
    'KLASA RESURSI
    Public _res As spoljasnjiResursi
    Public _baza As bazaPodataka
    Private Sub glavnaForma_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Provjera resursa
        _res = New spoljasnjiResursi()

        If _res.greskaUcitanju = True Then
            ucitajGresku("")
        Else
            f_splash = New splashScreen(_res, Me)
            f_splash.Show()
        End If
    End Sub
    Public Sub nastaviNakoSplasha(ByVal b As bazaPodataka)
        _baza = b
        ucitajBackground()
        inicijalizacija()
    End Sub
    Public Sub ucitajGresku(ByVal poruka As String)
        Cursor.Hide()
        Dim back As Bitmap = New Bitmap(Me.Width, Me.Height)
        Dim GZB As Graphics = Graphics.FromImage(back)
        Dim r As Rectangle = New Rectangle(189, 92, 683, 275)
        GZB.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi._pozadina, 0, 0)
        GZB.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.White)), r)
        GZB.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi._logo, 12, 13)
        GZB.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi._maliLogo, -9, 439 - 29 - 6)
        If poruka = "" Then
            GZB.DrawString(_res._poruka, New Font("Arial", 12), Brushes.Black, 283, 118)
        Else
            f_meni.Dispose()
            f_video.Dispose()
            GZB.DrawString(poruka, New Font("Arial", 12), Brushes.Black, 283, 118)
        End If
        Me.BackgroundImage = back
    End Sub
    Public Sub ucitajBackground()
        Dim back As Bitmap = New Bitmap(Me.Width, Me.Height)
        Dim GZB As Graphics = Graphics.FromImage(back)
        GZB.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi._pozadina, 0, 0)
        GZB.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi._maliLogo, -9, 439 - 29 - 6)
        Me.BackgroundImage = back
    End Sub
    '
    ' INICIJALIZACIJE
    '
    Dim f_meni As _Meni2 ' Forma MENU
    Dim f_video As _Video ' Forma VIDEO
    Dim f_logIn As menu_login ' Forma Login
    Dim f_splash As splashScreen ' Splash Screen
    Public f_konzolaIgrac As crtanjeKonzoleIgrac

    Private Sub inicijalizacija()
        Me.Show()

        ucitajVideo(0)
        'ucitajMeni()
        'startIgrice()
    End Sub
    Public Sub ucitajMeni()
        If _baza.greska = False And _baza.vecUcitan = False Then
            f_logIn = New menu_login(Me, _res, _baza)
            f_logIn.Show()
            Me.Controls.Add(f_logIn)
            _baza.vecUcitan = True
        Else
            ' f_meni = New _Meni(Me, _res)
            f_meni = New _Meni2(Me)
            f_meni.Show()
            Me.Controls.Add(f_meni)
            f_meni.Focus()
        End If
    End Sub
    Public Sub ucitajVideo(ByVal zad As Integer)
        f_video = New _Video(zad, Me, _res)
        f_video.Show()
        Me.Controls.Add(f_video)
        f_video.Focus()
        f_video.BringToFront()
    End Sub


#Region "IGRICA"
    '
    ' METODE IGRICE
    '
    ' GRAFIKA
    Dim GG As Graphics 'Glavna grafika za crtanje mape
    Dim _MAPA As Bitmap  'MAPA
    Dim GZM As Graphics 'Grafika za mapu
    Dim _KUCE As Bitmap
    Dim GZK As Graphics ' Grafika za kuce
    Dim _SCREEN As Bitmap ' Bitmap ekran
    Dim GZS As Graphics ' Grafika za screen
    Dim GZG As Graphics ' Grafika za GUI
    ' GUI
    Dim _GUIgame As Bitmap
    Dim _guiKrajRunde As Bitmap
    Dim konzolaIgraca As Bitmap
    ' AVION ELEMENTI
    Dim karAvion As Bitmap  ' karakter avion 
    Dim karAvionUP As Bitmap
    Dim karAvionDWN As Bitmap
    Dim karAvionLFT As Bitmap
    Dim karAvionRGT As Bitmap
    Dim karSjenka As Bitmap  ' Karakter sjenka
    Dim karSjenkaUP As Bitmap
    Dim karSjenkaDWN As Bitmap
    Dim karSjenkaLFT As Bitmap
    Dim karSjenkaRGT As Bitmap

    Public Sub startIgrice()
        Me.Focus()
        Cursor.Hide()
        GG = Me.CreateGraphics()
        _MAPA = New Bitmap(2360, 2356)
        GZM = Graphics.FromImage(_MAPA)
        _SCREEN = New Bitmap(Me.Width, Me.Height)
        GZS = Graphics.FromImage(_SCREEN)
        _KUCE = New Bitmap(2360, 2356)
        GZK = Graphics.FromImage(_KUCE)

        ' Kreiranje mapa
        kreirajMapu() ' sa bojama
        kreirajKuce() ' kreiranje kuca na mapi

        ' Inicijalizaicja GUI-a
        _GUIgame = New Bitmap(596, 50)
        GZG = Graphics.FromImage(_GUIgame)
        _guiKrajRunde = New Bitmap(_res.rRes + _res.rSV + _res.rSVfiles(4))
        ' Inicijalizacija konzole za igraca
        If _baza._bazaSeKoristi = True Then
            f_konzolaIgrac = New crtanjeKonzoleIgrac(Me)
            konzolaIgraca = f_konzolaIgrac.slika
        End If

        ' Podesavanje startUp
        _vrijeme = UkupnoVrijeme
        _brojBombi = 15
        prekid = False
        pauza = False

        ' Kreiranje i rotacija elemenata aviona
        karAvionUP = New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.karPlane)
        karAvionDWN = New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.karPlane) ' DOlje
        karAvionLFT = New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.karPlane) ' Lijevo
        karAvionRGT = New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.karPlane) ' Desno
        karSjenkaUP = New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.karSjenka)
        karSjenkaDWN = New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.karSjenka) ' Dolje
        karSjenkaLFT = New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.karSjenka) ' Lijevo
        karSjenkaRGT = New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.karSjenka) ' Desnop

        karAvionDWN.RotateFlip(RotateFlipType.Rotate180FlipNone)
        karSjenkaDWN.RotateFlip(RotateFlipType.Rotate180FlipNone)
        karAvionLFT.RotateFlip(RotateFlipType.Rotate270FlipNone)
        karSjenkaLFT.RotateFlip(RotateFlipType.Rotate270FlipNone)
        karAvionRGT.RotateFlip(RotateFlipType.Rotate90FlipNone)
        karSjenkaRGT.RotateFlip(RotateFlipType.Rotate90FlipNone)

        karAvion = karAvionUP
        karSjenka = karSjenkaUP
        pravacKretanja = 0

        _sekundT.Start()
        gameLoop()
    End Sub

#Region "Crtanje Mape i Kuca"
    Private Sub kreirajMapu()
        GZM.Clear(Color.FromArgb(0, Color.Transparent))
        GZM.DrawImage(New Bitmap(_res.rRes & _res.rMapa & _res.rMapaFajlovi(0)), 200, 0)
        GZM.DrawImage(New Bitmap(_res.rRes & _res.rMapa & _res.rMapaFajlovi(1)), 1058, 0)
        GZM.DrawImage(New Bitmap(_res.rRes & _res.rMapa & _res.rMapaFajlovi(2)), 1822, 0)
        GZM.DrawImage(New Bitmap(_res.rRes & _res.rMapa & _res.rMapaFajlovi(3)), 200, 732)
        GZM.DrawImage(New Bitmap(_res.rRes & _res.rMapa & _res.rMapaFajlovi(4)), 1058, 732)
        GZM.DrawImage(New Bitmap(_res.rRes & _res.rMapa & _res.rMapaFajlovi(5)), 1822, 732)
        GZM.DrawImage(New Bitmap(_res.rRes & _res.rMapa & _res.rMapaFajlovi(6)), 200, 1472)
        GZM.DrawImage(New Bitmap(_res.rRes & _res.rMapa & _res.rMapaFajlovi(7)), 1058, 1472)
        GZM.DrawImage(New Bitmap(_res.rRes & _res.rMapa & _res.rMapaFajlovi(8)), 1822, 1472)
        GZM.DrawImage(New Bitmap(_res.rRes & _res.rMapa & _res.rMapaFajlovi(9)), 0, 1918)
        GZM.DrawImage(New Bitmap(_res.rRes & _res.rMapa & _res.rMapaFajlovi(10)), 200, 1918)
        GZM.DrawImage(New Bitmap(_res.rRes & _res.rMapa & _res.rMapaFajlovi(11)), 1058, 1918)
        GZM.DrawImage(New Bitmap(_res.rRes & _res.rMapa & _res.rMapaFajlovi(12)), 1822, 1918)
    End Sub
    Private Sub kreirajKuce()
        GZK.Clear(Color.FromArgb(0, Color.Coral))
        ' Stampa centra grada
        For kuc As Integer = 0 To _res._kuceUziCentar.Length / 3 - 1
            If _res._kuceUziCentar(kuc, 2) = 0 Then
                GZK.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.kucNormal, _res._kuceUziCentar(kuc, 0) - 4, _res._kuceUziCentar(kuc, 1) - 4)
            Else
                GZK.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.kucBomb, _res._kuceUziCentar(kuc, 0) - 4, _res._kuceUziCentar(kuc, 1) - 4)
            End If
        Next
        ' Stampa stare varoso
        For kus As Integer = 0 To _res._kuceVaros.Length / 3 - 1
            If _res._kuceVaros(kus, 2) = 0 Then
                GZK.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.kucNormal, _res._kuceVaros(kus, 0), _res._kuceVaros(kus, 1))
            Else
                GZK.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.kucBomb, _res._kuceVaros(kus, 0), _res._kuceVaros(kus, 1))
            End If
        Next
        ' Stampa ostalo
        For kos As Integer = 0 To _res._kuceOstalo.Length / 3 - 1
            If _res._kuceOstalo(kos, 2) = 0 Then
                GZK.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.kucNormal, _res._kuceOstalo(kos, 0), _res._kuceOstalo(kos, 1))
            Else
                GZK.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.kucBomb, _res._kuceOstalo(kos, 0), _res._kuceOstalo(kos, 1))
            End If
        Next
    End Sub
#End Region

    '
    ' VARIJABLE ZA IGRICU
    '
    Dim prekid As Boolean = False 'Za prekid game loopa
    Dim pauza As Boolean = False ' Za pauzu game loopa
    Public unutarIgrice As Boolean = False
    Dim _iX As Integer = -1337 ' Igrac x kordnanta
    Dim _iY As Integer = -1835 'Igrac y kordinanta
    Dim _up As Boolean = False
    Dim _down As Boolean = False
    Dim _right As Boolean = False
    Dim _left As Boolean = False
    Dim pravacKretanja = 0 ' 0=Gore; 1=dolje; 2=lijevo; 3=desno
    Dim _bacenaBomba As Boolean = False ' Crtanje eksplozije
    Dim _indeksZaPozadinskuBoju  ' Indeks od _res.__mapaNijanse za pozadinsku boju
    Dim _brojBombi As Integer = 10
    Dim _vrijeme As Integer = 2
    Public UkupnoVrijeme As Integer = 30
    Dim _brRunde As Integer = 1
    Dim _ukupnoUnistenih As Integer = 0
    Dim _unistenoSada As Integer = 0

#Region "GAME_LOOP"
    Private Sub gameLoop()
        getIndeksPozadinskeBoje()
        getStartPoziciju()
        unutarIgrice = True
        Do
            Application.DoEvents()
            ' KONTROLE
            If prekid = True Then Exit Do
            If pauza = True Then Continue Do
            If _up = True Then _iY += 3
            If _down = True Then _iY -= 3
            If _left = True Then _iX += 3
            If _right = True Then _iX -= 3
            If _bacenaBomba = True Then eksplozija()
            If _vrijeme = 0 Then krajRunde()

            ' Crtanje MAPE
            GZS.Clear(Color.FromArgb(255, _res._mapaNijanse(_indeksZaPozadinskuBoju, 0), _res._mapaNijanse(_indeksZaPozadinskuBoju, 1), _res._mapaNijanse(_indeksZaPozadinskuBoju, 2)))
            GZS.DrawImage(_MAPA, _iX, _iY)
            GZS.DrawImage(_KUCE, _iX, _iY)
            GZS.DrawImage(karAvion, 392, 206)
            GZS.DrawImage(karSjenka, 349, 174)

            ' Crtanje GUI
            crtanjeGui()
            GZS.DrawImage(_GUIgame, 0, 415)
            ' Crtanje Pomoc
            GZS.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.status_pomoc, 820, 380)
            If _baza._bazaSeKoristi = True Then GZS.DrawImage(konzolaIgraca, 11, 9)

            ' ZAVRSNO CRTANJE
            GG.DrawImage(_SCREEN, 0, 0)

            If pravacKretanja = 0 Then ' GORE
                _iY += 1
            ElseIf pravacKretanja = 1 Then ' DOLJE
                _iY -= 1
            ElseIf pravacKretanja = 2 Then ' LIJEVO
                _iX += 1
            ElseIf pravacKretanja = 3 Then ' DESNO
                _iX -= 1
            End If
        Loop
        unutarIgrice = False
        napustanjeForme()
    End Sub
    Private Sub krajRunde()
        ' KRAJ RUNDE
        _sekundT.Stop()
        GZS.DrawImage(_guiKrajRunde, 0, 0)

        GZS.DrawString("Крај " & _brRunde & " рунде!", New Font("Arial", 35), New SolidBrush(Color.FromArgb(255, 14, 83, 176)), 112, 220)

        Dim solid As SolidBrush = New SolidBrush(Color.FromArgb(255, 74, 74, 74))
        Dim font As Font = New Font("Arial", 18)
        Dim ukupnaSteta As Integer = Math.Ceiling(((_res._kuceOstaloU.Count + _res._kuceUziCentarU.Count + _res._kuceVarosU.Count) * 100) / 95)
        Dim sihronizacijaSaBazom As Boolean = False

        GZS.DrawString("Учинили сте " & Math.Ceiling((_unistenoSada * 100) / 95) & "% штете!", font, solid, 481, 192)
        GZS.DrawString("Укупна штета је " & ukupnaSteta & "%.", font, solid, 480, 228)
        GZS.DrawString("Обновљено је " & obnavljanjeKuca() & " кућа!", font, solid, 479, 265)
        If _baza._bazaSeKoristi = True And _baza.najboljiRezultat < ukupnaSteta Then
            GZS.DrawString("(Резултат сихронизован са базом)", New Font("Arial", 15), New SolidBrush(Color.FromArgb(255, 14, 83, 176)), 94, 280)
            sihronizacijaSaBazom = True
        End If
        GG.DrawImage(_SCREEN, 0, 0)

        ' Reset komande
        kreirajMapu()
        kreirajKuce()
        _iX = -1337
        _iY = -1835
        _vrijeme = UkupnoVrijeme
        _brRunde += 1
        _unistenoSada = 0
        _brojBombi = 15

        getIndeksPozadinskeBoje()
        getStartPoziciju()

        If _baza._bazaSeKoristi = True Then
            If sihronizacijaSaBazom = True Then _baza.setNoviNajboljiRezultat(ukupnaSteta)
            f_konzolaIgrac.refreshInfo()
            Threading.Thread.Sleep(4000)
        Else
            Threading.Thread.Sleep(4000)
        End If
        _sekundT.Start()
        _bacenaBomba = False
        s_duzina = s_ukupnaDuzina
    End Sub

    Dim s_ukupnaDuzina As Integer = 243
    Dim s_duzina As Integer = 243
    Private Sub crtanjeGui()
        ' PRIPADA GAME_LOOPU
        GZG.Clear(Color.Transparent)
        GZG.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.status_back, 0, 23)

        Dim procenatVremena = Math.Floor((_vrijeme * 100) / UkupnoVrijeme)
        s_duzina = Math.Floor((s_ukupnaDuzina * procenatVremena) / 100)

        GZG.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.statu_vrijeme, 13, 31, s_duzina, 12)
        'GZG.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.satus_vrijeme_bar, s_duzina - 18, 1)
        'GZG.DrawString(_vrijeme, New Font("Calibri", 10), New SolidBrush(Color.FromArgb(199, 220, 234)), s_duzina, 3)

        ' Crtanje raketa
        Dim s = 267
        For i As Integer = 0 To _brojBombi - 1
            GZG.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.status_bomba, s, 23)
            s += 9
        Next
    End Sub
    Private Function obnavljanjeKuca() As Integer
        ' PRIPADA KRAJU RUNDE
        Dim rand As Random = New Random()
        Dim uzi As Integer = rand.Next(0, _res._kuceUziCentarU.Count)

        If uzi > 0 Then
            For i As Integer = 0 To uzi - 1
                Dim a As Integer = rand.Next(0, _res._kuceUziCentarU.Count - 1)
                _res._kuceUziCentar(_res._kuceUziCentarU(a), 2) = 0
                _res._kuceUziCentarU.RemoveAt(a)
            Next
        End If

        Dim varos As Integer = rand.Next(0, _res._kuceVarosU.Count)
        If varos > 0 Then
            For ii As Integer = 0 To varos
                Dim a As Integer = rand.Next(0, _res._kuceVarosU.Count - 1)
                _res._kuceVaros(_res._kuceVarosU(a), 2) = 0
                _res._kuceVarosU.RemoveAt(a)
            Next
        End If

        Dim ostalo As Integer = rand.Next(0, _res._kuceOstaloU.Count)
        If ostalo > 0 Then
            For iii As Integer = 0 To ostalo
                Dim a As Integer = rand.Next(0, _res._kuceOstaloU.Count - 1)
                _res._kuceOstalo(_res._kuceOstaloU(a), 2) = 0
                _res._kuceOstaloU.RemoveAt(a)
            Next
        End If

        Return uzi + varos + ostalo
    End Function
#End Region

#Region "Eksplozija / Koalizija"
    Dim plusX As Integer = 455 '
    Dim plusY As Integer = 270 ' 
    Private Sub eksplozija()
        _bacenaBomba = False
        If _brojBombi = 0 Then Exit Sub
        _brojBombi -= 1

        ' PROVJERA KOALIZIJE

        ' Velicine potrebne za regiju koalizije
        Dim __xL As Integer = Math.Abs(_iX) + plusX - 12 ' X Gornje
        Dim __xD As Integer = Math.Abs(_iX) + plusX + 12 ' X Doljnje
        Dim __yL As Integer = Math.Abs(_iY) + plusY - 12 ' Y Gornje
        Dim __yD As Integer = Math.Abs(_iY) + plusY + 12 ' Y Donje

        If __xL + 12 >= 1078 And __xL + 12 <= 1379 And __yL + 12 >= 1765 And __yL + 12 <= 2041 Then
            ' Stara varos
            For kav As Integer = 0 To _res._kuceVaros.Length / 3 - 1
                'Provjera koalizije
                If _res._kuceVaros(kav, 2) = 0 And pripada(__xL, __xD, __yL, __yD, _res._kuceVaros(kav, 0), _res._kuceVaros(kav, 1)) = True Then
                    GZK.DrawImage(New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.kucBomb), _res._kuceVaros(kav, 0), _res._kuceVaros(kav, 1))
                    _res._kuceVaros(kav, 2) = 1
                    _ukupnoUnistenih += 1
                    _unistenoSada += 1
                    _res._kuceVarosU.Add(kav)
                End If
            Next
        ElseIf __xL + 12 >= 1099 And __xL + 12 <= 1351 And __yL + 12 >= 1469 And __yL + 12 <= 1765 Then
            ' Uzi centar
            For kuc As Integer = 0 To _res._kuceUziCentar.Length / 3 - 1
                ' Provjera koalizije
                If _res._kuceUziCentar(kuc, 2) = 0 And pripada(__xL, __xD, __yL, __yD, _res._kuceUziCentar(kuc, 0) - 4, _res._kuceUziCentar(kuc, 1) - 4) = True Then
                    GZK.DrawImage(New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.kucBomb), _res._kuceUziCentar(kuc, 0) - 4, _res._kuceUziCentar(kuc, 1) - 4)
                    _res._kuceUziCentar(kuc, 2) = 1
                    _ukupnoUnistenih += 1
                    _unistenoSada += 1
                    _res._kuceUziCentarU.Add(kuc)
                End If
            Next
        Else
            ' Ostalo
            For ko As Integer = 0 To _res._kuceOstalo.Length / 3 - 1
                'Provjera Kolazije
                If _res._kuceOstalo(ko, 2) = 0 And pripada(__xL, __xD, __yL, __yD, _res._kuceOstalo(ko, 0), _res._kuceOstalo(ko, 1)) = True Then
                    GZK.DrawImage(New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.kucBomb), _res._kuceOstalo(ko, 0), _res._kuceOstalo(ko, 1))
                    _res._kuceOstalo(ko, 2) = 1
                    _ukupnoUnistenih += 1
                    _unistenoSada += 1
                    _res._kuceOstaloU.Add(ko)
                End If
            Next
        End If

        ' Crtanje grafike
        ' Crni okvir se crta direktno na mapu
        GZK.DrawImage(New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.karBdim), Math.Abs(_iX) + plusX - 12, Math.Abs(_iY) + plusY - 32)
        ' Dim se crta direktno na kuce
        GZM.DrawImage(New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.karBblack), Math.Abs(_iX) + plusX - 12, Math.Abs(_iY) + plusY - 10)
    End Sub
    Function pripada(ByVal __xL As Integer, ByVal __xD As Integer, ByVal __yL As Integer, ByVal __yD As Integer, ByVal _x As Integer, ByVal _y As Integer) As Boolean
        ' Velicine kuce radi uporedjivanja
        Dim vW As Integer = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.kucNormal.Width
        Dim vH As Integer = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.kucNormal.Height

        If _x >= __xL And _x <= __xD And _y >= __yL And _y <= __yD Then
            Return True
        ElseIf _x + vW >= __xL And _x + vW <= __xD And _y >= __yL And _y <= __yD Then
            Return True
        ElseIf _x >= __xL And _x <= __xD And _y - vH >= __yL And _y - vH <= __yD Then
            Return True
        ElseIf _x + vW >= __xL + vW And _x <= __xD And _y - vH >= __yL And _y - vH <= __yD Then
            Return True
        End If

        Return False
    End Function
#End Region

    Private Sub getIndeksPozadinskeBoje()
        Randomize()
        _indeksZaPozadinskuBoju = Int((((_res._mapaNijanse.Length / 3)) * Rnd()) + 0)
        'Dim radn As New Random()
        '_indeksZaPozadinskuBoju = radn.Next(0, _res._mapaNijanse.Length / 3 - 1)
    End Sub
    Private Sub getStartPoziciju()
        Dim a As Integer = Int((((_res._startLokacije.Length / 3)) * Rnd()) + 0)
        _iX = 0 - _res._startLokacije(a, 0)
        _iY = 0 - _res._startLokacije(a, 1)
    End Sub
    Private Sub _sekundT_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _sekundT.Tick
        ' SMANJUJE ZA SEKUND
        _vrijeme -= 1
    End Sub
    ' KONTROLE
    Dim _eksterniEkran As PictureBox
    Private Sub glavnaForma_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                pauza = True
            Case Keys.Up
                _up = True
                pravacKretanja = 0
                karAvion = karAvionUP
                karSjenka = karSjenkaUP
            Case Keys.Down
                _down = True
                pravacKretanja = 1
                karAvion = karAvionDWN
                karSjenka = karSjenkaDWN
            Case Keys.Left
                _left = True
                pravacKretanja = 2
                karAvion = karAvionLFT
                karSjenka = karSjenkaLFT
            Case Keys.Right
                _right = True
                pravacKretanja = 3
                karAvion = karAvionRGT
                karSjenka = karSjenkaRGT
            Case Keys.Space
                _bacenaBomba = True
            Case Keys.M : prikazMape_EksterniEkran()
            Case Keys.P : prikazPomoc_EksterniEkran()
            Case Keys.S
                If _baza._bazaSeKoristi = True Then
                    If f_konzolaIgrac.minimized = True Then
                        f_konzolaIgrac.minimized = False
                        konzolaIgraca = f_konzolaIgrac.slika
                    Else
                        f_konzolaIgrac.minimized = True
                        konzolaIgraca = f_konzolaIgrac.slikaSmall
                    End If
                End If
        End Select
    End Sub
    Private Sub glavnaForma_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                If unutarIgrice = True Then
                    If MessageBox.Show("Да ли сте сигурни да желите да изађете у мени?", "Излазак у мени!", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        prekid = True
                    Else
                        pauza = False
                    End If
                Else
                    Application.Exit()
                End If
            Case Keys.Up : _up = False
            Case Keys.Down : _down = False
            Case Keys.Left : _left = False
            Case Keys.Right : _right = False
        End Select
    End Sub

#Region "Prikaz Eksterni_Ekran"
    Private Sub prikazMape_EksterniEkran()
        If pauza = False Then
            _sekundT.Stop()
            pauza = True
            _eksterniEkran = New PictureBox()
            _eksterniEkran.Size = New System.Drawing.Size(341, 341)
            _eksterniEkran.Location = New System.Drawing.Point(292, 73)
            _eksterniEkran.BringToFront()
            Me.Controls.Add(_eksterniEkran)
            _eksterniEkran.Show()
            Dim SZE As Bitmap = New Bitmap(341, 341) ' SLIKA ZA EKRAN
            Dim GZE As Graphics = Graphics.FromImage(SZE) ' GRAFIKA ZA EKRAN
            GZE.DrawImage(New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.mapPG), 0, 0)
            GZE.DrawImage(_MAPA, 0, 0, 341, 341)
            GZE.DrawImage(_KUCE, 0, 0, 341, 341)
            ' Crtanje linija
            Dim __y As Integer = Math.Floor((Math.Abs(_iX) + (Me.Width / 2)) / 7) '(Me.Width / 2)
            Dim __x As Integer = Math.Floor((Math.Abs(_iY) + (Me.Height / 2)) / 7) '(Me.Height / 2)
            GZE.DrawLine(Pens.Black, 0, __x, 341, __x) ' X KORDINANTA
            GZE.DrawLine(Pens.Black, __y, 0, __y, 341) ' Y KORDINANTA
            GZE.DrawImage(New Bitmap(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.mapPGover), 0, 0)
            _eksterniEkran.Image = SZE
        ElseIf pauza = True Then
            _sekundT.Start()
            pauza = False
            _eksterniEkran.Dispose()
        End If
    End Sub
    Private Sub prikazPomoc_EksterniEkran()
        ' POMOC
        If pauza = False Then
            pauza = True
            _sekundT.Stop()
            _eksterniEkran = New PictureBox()
            _eksterniEkran.Size = New System.Drawing.Size(751, 337)
            _eksterniEkran.Location = New System.Drawing.Point(91, 81)
            _eksterniEkran.BringToFront()
            Me.Controls.Add(_eksterniEkran)
            _eksterniEkran.Show()
            Dim SZE As Bitmap = New Bitmap(751, 337)
            Dim GZE As Graphics = Graphics.FromImage(SZE)
            GZE.DrawImage(New Bitmap(_res.rRes + _res.rSV + _res.rSVfiles(3)), 0, 0)
            _eksterniEkran.Image = SZE
        Else
            pauza = False
            _sekundT.Start()
            _eksterniEkran.Dispose()
        End If
    End Sub
#End Region

    Private Sub napustanjeForme()
        ' BRISANJE KOMPLETA I UCITAVANJE MENIJA

        ' Zaustavljanje loopa
        _sekundT.Stop()
        _sekundT.Dispose()

        ' Brisanje kompletne grafike
        _MAPA.Dispose()
        _SCREEN.Dispose()
        _KUCE.Dispose()
        _GUIgame.Dispose()
        'If Not IsNothing(konzolaIgraca) Then konzolaIgraca.Dispose()

        GG.Dispose()
        GZG.Dispose()
        GZM.Dispose()
        GZK.Dispose()
        GZS.Dispose()

        ' Brisanje elemenata aviona
        karAvionUP.Dispose()
        karAvionDWN.Dispose()
        karAvionLFT.Dispose()
        karAvionRGT.Dispose()
        karSjenkaUP.Dispose()
        karSjenkaDWN.Dispose()
        karSjenkaLFT.Dispose()
        karSjenkaRGT.Dispose()

        ' Restartovanje kuca na pocetno stanje
        _res._kuceUziCentarU.Clear()
        _res._kuceVarosU.Clear()
        _res._kuceOstaloU.Clear()
        For i1 As Integer = 0 To (_res._kuceVaros.Length / 3) - 1
            If _res._kuceVaros(i1, 2) = 1 Then _res._kuceVaros(i1, 2) = 0
        Next
        For i2 As Integer = 0 To (_res._kuceUziCentar.Length / 3) - 1
            If _res._kuceUziCentar(i2, 2) = 1 Then _res._kuceUziCentar(i2, 2) = 0
        Next
        For i3 As Integer = 0 To (_res._kuceOstalo.Length / 3) - 1
            If _res._kuceOstalo(i3, 2) = 1 Then _res._kuceOstalo(i3, 2) = 0
        Next

        ' konacan izlazak
        ucitajMeni()
    End Sub
    Private Function cekanjeNaKrajLoopa() As Boolean
        If unutarIgrice = False Then Return True
        Return cekanjeNaKrajLoopa()
    End Function
#End Region

    Private Sub glavnaForma_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Zatvaranje forme
        prekid = True
        If Not IsNothing(_baza) Then
            If _baza._bazaSeKoristi = True Then _baza.updateOnline(1)
        End If
    End Sub
End Class
