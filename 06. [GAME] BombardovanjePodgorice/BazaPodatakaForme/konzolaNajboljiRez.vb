Public Class konzolaNajboljiRez
    Public Sub New(ByVal m As _Meni2, ByVal r As spoljasnjiResursi, ByVal b As bazaPodataka)
        InitializeComponent()
        _M = m
        _res = r
        _baza = b
    End Sub
    ' VARIJABLE
    Dim _M As _Meni2
    Dim _res As spoljasnjiResursi
    Dim _baza As bazaPodataka
    Dim rezultati(,) As String
    Dim slika As PictureBox

    Private Sub konzolaNajboljiRez_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = System.Windows.Forms.Cursors.Default
        crtanjePozadine()
        Me.Show()
        Cursor.Show()
        rezultati = _baza.najboljiRezultati()
        If Not IsNothing(rezultati) Then popunjavanjeListe()
    End Sub
    Private Sub crtanjePozadine()
        Dim b As Bitmap = New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(b)
        g.DrawImage(New Bitmap(_res.rRes & _res.rSV & _res.rSVfiles(7)), 0, 0)
        g.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_najboljiRez_logo, 16, 15)
        Me.BackgroundImage = b
    End Sub
    Private Sub popunjavanjeListe()
        Dim b As Bitmap
        For i As Integer = 0 To (rezultati.Length / 2) - 1
            Select Case i
                Case 0
                    ' ZLATO
                    slika = New PictureBox()
                    slika.Size = New System.Drawing.Size(732, 47)
                    b = New Bitmap(slika.Width, slika.Height)
                    Dim g As Graphics = Graphics.FromImage(b)
                    g.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_rezuktati_zlato, 0, 0)
                    If i < 10 Then g.DrawString((i + 1).ToString() & ")          " & rezultati(i, 0), New Font("Arial", 10), New SolidBrush(Color.FromArgb(255, 56, 56, 56)), 15, 16)
                    If i > 10 Then g.DrawString((i + 1).ToString() & ")         " & rezultati(i, 0), New Font("Arial", 10), New SolidBrush(Color.FromArgb(255, 56, 56, 56)), 15, 16)
                    g.DrawString(rezultati(i, 1) & "%", New Font("Arial", 12), New SolidBrush(Color.FromArgb(255, 65, 65, 65)), 344, 16)
                Case 1
                    ' Srebro
                    slika = New PictureBox()
                    slika.Size = New System.Drawing.Size(732, 47)
                    b = New Bitmap(slika.Width, slika.Height)
                    Dim g As Graphics = Graphics.FromImage(b)
                    g.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_rezuktati_srebro, 0, 0)
                    If i < 10 Then g.DrawString((i + 1).ToString() & ")          " & rezultati(i, 0), New Font("Arial", 10), New SolidBrush(Color.FromArgb(255, 56, 56, 56)), 15, 16)
                    If i > 10 Then g.DrawString((i + 1).ToString() & ")         " & rezultati(i, 0), New Font("Arial", 10), New SolidBrush(Color.FromArgb(255, 56, 56, 56)), 15, 16)
                    g.DrawString(rezultati(i, 1) & "%", New Font("Arial", 12), New SolidBrush(Color.FromArgb(255, 65, 65, 65)), 344, 16)
                Case 2
                    ' Bronza
                    slika = New PictureBox()
                    slika.Size = New System.Drawing.Size(732, 47)
                    b = New Bitmap(slika.Width, slika.Height)
                    Dim g As Graphics = Graphics.FromImage(b)
                    g.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_rezuktati_bronza, 0, 0)
                    If i < 10 Then g.DrawString((i + 1).ToString() & ")          " & rezultati(i, 0), New Font("Arial", 10), New SolidBrush(Color.FromArgb(255, 56, 56, 56)), 15, 16)
                    If i > 10 Then g.DrawString((i + 1).ToString() & ")         " & rezultati(i, 0), New Font("Arial", 10), New SolidBrush(Color.FromArgb(255, 56, 56, 56)), 15, 16)
                    g.DrawString(rezultati(i, 1) & "%", New Font("Arial", 12), New SolidBrush(Color.FromArgb(255, 65, 65, 65)), 344, 16)
                Case Else
                    ' Ispod
                    slika = New PictureBox()
                    slika.Size = New System.Drawing.Size(732, 24)
                    b = New Bitmap(slika.Width, slika.Height)
                    Dim g As Graphics = Graphics.FromImage(b)
                    g.DrawImage(Global._06._GAME__BombardovanjePodgorice.My.Resources.unutrasnjiResursi.konzola_rezuktati_black, 0, 0)
                    If i < 10 Then g.DrawString((i + 1).ToString() & ")          " & rezultati(i, 0), New Font("Arial", 10), New SolidBrush(Color.White), 15, 5)
                    If i > 10 Then g.DrawString((i + 1).ToString() & ")         " & rezultati(i, 0), New Font("Arial", 10), New SolidBrush(Color.White), 15, 5)
                    g.DrawString(rezultati(i, 1) & "%", New Font("Arial", 12), New SolidBrush(Color.White), 344, 5)
            End Select
            slika.Image = b
            slika.Show()
            kontenjer.Controls.Add(slika)
        Next
    End Sub
    Private Sub izlaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles izlaz.Click
        Cursor.Hide()
        _M._ucitanaKonzola = False
        Me.Dispose()
    End Sub
End Class
