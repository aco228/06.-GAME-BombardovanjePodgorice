Public Class crtanjeKonzoleIgrac

    Public Sub New(ByVal b As glavnaForma)
        slika = New Bitmap(162, 63)
        slikaSmall = New Bitmap(162, 25)
        G = Graphics.FromImage(slika)
        Gs = Graphics.FromImage(slikaSmall)
        GF = b
        _baza = GF._baza
        fontZaInfo = New System.Drawing.Font("Franklin Gothic Medium Cond", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        fontZaIgraca = New System.Drawing.Font("Franklin Gothic Medium", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        backImage = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_igrac_back

        refreshInfo()
        crtanjeMinimized()
    End Sub

    Dim GF As glavnaForma

    Public slika As Bitmap
    Public slikaSmall As Bitmap
    Dim G As Graphics
    Dim Gs As Graphics
    Dim _baza As bazaPodataka
    Dim backImage As Bitmap

    Dim imeIgraca As String
    Dim rangLista As String
    Dim poruke As String
    Dim online As String

    Dim fontZaInfo As Font
    Dim fontZaIgraca As Font

    Public minimized As Boolean = False

    Public Sub refreshInfo()
        _baza.refreshInfo()
        imeIgraca = _baza.userName
        rangLista = "Ранг листа - " & _baza.rangListaIgraca & " мјесто (" & _baza.najboljiRezultat & "%)"

        If _baza.neProcitanePoruke = 0 Then
            poruke = "Нема порука"
        ElseIf _baza.neProcitanePoruke = 1 Then
            poruke = _baza.neProcitanePoruke & " не прочитана порука"
        ElseIf _baza.neProcitanePoruke > 1 And _baza.neProcitanePoruke < 5 Then
            poruke = _baza.neProcitanePoruke & " не прочитане поруке"
        ElseIf _baza.neProcitanePoruke > 5 Then
            poruke = _baza.neProcitanePoruke & " не прочитаних порука"
        End If

        If _baza.onlineIgraci = 0 Then
            online = "Нема онлајн играча"
        ElseIf _baza.onlineIgraci = 1 Then
            online = _baza.onlineIgraci & " онлајн играч"
        ElseIf _baza.onlineIgraci >= 2 Then
            online = _baza.onlineIgraci & " онлајн играча"
        End If
        crtanjeSlike()
    End Sub
    Public Sub refreshInfoBezBaze(ByVal zad As String, ByVal promjena As Integer)
        Select Case zad
            Case "poruka"
                If promjena = 0 Then
                    poruke = "Нема порука"
                ElseIf promjena = 1 Then
                    poruke = _baza.neProcitanePoruke & " не прочитана порука"
                ElseIf promjena > 1 And _baza.neProcitanePoruke < 5 Then
                    poruke = _baza.neProcitanePoruke & " не прочитане поруке"
                ElseIf promjena > 5 Then
                    poruke = _baza.neProcitanePoruke & " не прочитаних порука"
                End If
            Case "igraci"

        End Select
    End Sub
    Private Sub crtanjeSlike()
        G.Clear(Color.Transparent)

        ' CRTANJE BACK-a
        G.DrawImage(backImage, 0, 0)

        ' CRTANJE INFO
        G.DrawString(imeIgraca, fontZaIgraca, Brushes.White, 1, 0)
        G.DrawString(rangLista, fontZaInfo, Brushes.White, 1, 22)
        G.DrawString(poruke, fontZaInfo, Brushes.White, 1, 34)
        G.DrawString(online, fontZaInfo, Brushes.White, 1, 46)

    End Sub

    Private Sub crtanjeMinimized()
        Gs.Clear(Color.Transparent)

        ' CRTANJE BACK-a
        Gs.DrawImage(backImage, 0, 0, 162, 25)

        ' CRTANJE INFO
        Gs.DrawString(imeIgraca, fontZaIgraca, Brushes.White, 1, 0)

    End Sub
End Class
