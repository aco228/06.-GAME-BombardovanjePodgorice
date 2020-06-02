Public Class menu_login
    Dim _res As spoljasnjiResursi
    Dim _baza As bazaPodataka
    Dim _G As glavnaForma
    Sub New(ByVal g As glavnaForma, ByVal r As spoljasnjiResursi, ByVal b As bazaPodataka)
        InitializeComponent()
        _res = r
        _baza = b
        _G = g
        crtajPozadinu()
    End Sub

    Sub crtajPozadinu()
        Dim back As Bitmap = New Bitmap(Me.Width, Me.Height)
        Dim G As Graphics = Graphics.FromImage(back)
        G.DrawImage(New Bitmap(_res.rRes + _res.rSV + _res.rSVfiles(5)), 0, 0)
        Me.BackgroundImage = back
    End Sub

    ' GLAVNE VARIJABLE
    Dim logUlazak As Boolean = True
    Private Sub menu_login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Show()
        Me.Cursor = System.Windows.Forms.Cursors.Default
        greskaPoruka.Visible = False
    End Sub

    '
    ' KONTROLE
    '
    Private Sub Bpotvrdi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bpotvrdi.Click
        potvrda()
    End Sub

    Private Sub potvrda()
        prikaziGresku("Конекција са базом...", True)
        If username.Text = "" Or password.Text = "" Then
            prikaziGresku("Неко од поља није унијето!", False)
        ElseIf username.Text.Length < 3 Or password.Text.Length < 3 Then
            prikaziGresku("Мора имати више од 3 знака!", False)
        Else
            If logUlazak = True Then
                'Direktan login
                Dim odgovor As String = _baza.verifikacijaKorisnika(username.Text, password.Text)
                If odgovor = "" Then
                    Me.Dispose()
                    _baza._bazaSeKoristi = True
                    _baza.updateOnline(0)
                    ucitajMeni()
                Else
                    prikaziGresku(odgovor, False)
                End If
            Else
                ' Registracija novog clana
                Dim odgovor As String = _baza.unosKorisnika(username.Text, password.Text)
                If odgovor = "" Then
                    prikaziGresku("Играч је успјешно регистрован!" & vbCrLf & "Можете се улоговати!", True)
                Else
                    prikaziGresku(odgovor, False)
                End If
            End If
        End If
    End Sub

    Private Sub Bpromjena_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bpromjena.Click
        ' REGISTRACIJA NOVOG CLANA
        username.Text = ""
        password.Text = ""
        If logUlazak = True Then
            Bpromjena.Image = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.login_ulazak
            odabir.Image = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.login_registracija
            logUlazak = False
        Else
            Bpromjena.Image = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.login_registracija
            odabir.Image = Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.login_ulazak
            logUlazak = True

        End If
    End Sub

    Private Sub Bstandard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bstandard.Click
        ucitajMeni()
        Cursor.Hide()
    End Sub

    Private Sub greskaPoruka_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles greskaPoruka.MouseHover
        greskaPoruka.Visible = False
    End Sub

    Private Sub prikaziGresku(ByVal poruka As String, ByVal plava As Boolean)
        If plava = True Then
            greskaPoruka.ForeColor = Color.FromArgb(255, 0, 37, 174)
        Else
            greskaPoruka.ForeColor = Color.FromArgb(255, 174, 0, 0)
        End If
        greskaPoruka.Text = poruka
        greskaPoruka.Visible = True
    End Sub

    Private Sub menu_login_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                potvrda()
        End Select
    End Sub

    Private Sub password_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles password.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                potvrda()
        End Select
    End Sub

    Private Sub ucitajMeni()
        Me.Dispose()
        _G.ucitajMeni()
    End Sub
End Class
