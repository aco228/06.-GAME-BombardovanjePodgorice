Public Class citanjePoruke
    Public Sub New(ByVal k As konzolaPoruke, ByVal i As String, ByVal t As String, ByVal u As String, ByVal p As Boolean, ByVal d As String, ByVal bb As bazaPodataka, ByVal proc As String)
        InitializeComponent()
        _konzolaPoruke = k
        idP = CInt(i)
        tekst = t
        datum = d
        username = u
        poslate = p
        _baza = bb
        procitano = proc
    End Sub

    Dim _konzolaPoruke As konzolaPoruke
    Dim idP As Integer
    Dim tekst As String
    Dim username As String
    Dim datum As String
    Dim poslate As Boolean
    Dim _baza As bazaPodataka
    Dim procitano As String

    Private Sub citanjePoruke_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If procitano = "1" And poslate = False Then _baza.porukaProcitana(idP)

        If poslate = True Then
            _od.Text = _baza.userName
            _za.Text = username
        Else
            _od.Text = username
            _za.Text = _baza.userName
        End If
        _tekst.Text = tekst
        _vrijeme.Text = datum

    End Sub

    Private Sub izlaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles izlaz.Click
        Me.Dispose()
    End Sub

    Private Sub odgovori_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles odgovori.Click
        If poslate = True Then
            _konzolaPoruke.ucitajNovuPoruku(_za.Text)
        Else
            _konzolaPoruke.ucitajNovuPoruku(_od.Text)
        End If
        Me.Dispose()
    End Sub

    Private Sub izbrisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles izbrisi.Click
        If poslate = True Or _baza.userName = "aco228" Then
            _baza.brisanjePoruke(idP)
            MessageBox.Show("Порука избрисана. Морате поново учитати листу из конѕоле за поруке ради промјена!")
            Me.Dispose()
        Else
            MessageBox.Show("Можете брисати само поруке које сте ви послали!")
        End If
    End Sub
End Class