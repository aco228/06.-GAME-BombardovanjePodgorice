Imports System.IO
Public Class splashScreen
    Dim _res As spoljasnjiResursi
    Dim _g As glavnaForma
    Dim _baza As bazaPodataka
    Public Sub New(ByVal r As spoljasnjiResursi, ByVal g As glavnaForma)
        InitializeComponent()
        _res = r
        _g = g
    End Sub
    Private Sub splashScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crtanjePozadine("Спољашњи ресурси учитани" & vbCrLf)
        Me.Show()
        provjera()
    End Sub
    Dim poruka As String = ""
    Private Sub crtanjePozadine(ByVal p As String)
        Dim b As Bitmap = New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(b)
        g.DrawImage(New Bitmap(_res.rRes & _res.rSV & _res.rSVfiles(6)), 0, 0)
        poruka += p
        g.DrawString(poruka, New Font("Arial", 11), New SolidBrush(Color.White), 20, 86)
        Me.BackgroundImage = b
    End Sub
    Private Sub provjera()
        Dim bazaFajl As String = "baza"
        crtanjePozadine("Конекција са базом података..." & vbCrLf)
        If File.Exists(bazaFajl) Then
            crtanjePozadine("" & vbCrLf)
            _baza = New bazaPodataka(bazaFajl)
            If _baza.greska = False Then crtanjePozadine("Конекција са базом података успостављена!" & vbCrLf)
            If _baza.greska = True Then crtanjePozadine("Грешка при конекцији са базом!" & vbCrLf)
        Else
            crtanjePozadine("Конекција са базом онемогућена!" & vbCrLf)
            _baza = New bazaPodataka(True)
        End If
        stoper.Interval = 500
        stoper.Start()
    End Sub

    Private Sub stoper_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stoper.Tick
        System.Threading.Thread.Sleep(1000)
        Me.Dispose()
        _g.nastaviNakoSplasha(_baza)
    End Sub
End Class