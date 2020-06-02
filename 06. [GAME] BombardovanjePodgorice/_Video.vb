Public Class _Video
    Public Sub New(ByVal zad As Integer, ByVal gg As glavnaForma, ByVal res As spoljasnjiResursi)
        _zad = zad
        _G = gg
        _res = res
        InitializeComponent()
    End Sub

    Dim _zad As Integer
    Dim _G As glavnaForma
    Dim _res As spoljasnjiResursi
    Dim _put As String
    Dim duzina As Integer

    Private Sub _Video_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Focus()
        Me.Show()
        _put = _res.rRes + _res.rSV + _res.rSVfiles(_zad)
        ucitajVideo()
    End Sub
    Private Sub ucitajVideo()
        _player.URL = _put
        _player.Ctlcontrols.play()

    End Sub
    Private Sub _Video_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                zatvoriSekciju()
            Case Keys.Escape
                zatvoriSekciju()
        End Select
    End Sub
    ''Private Sub _player_KeyDownEvent(ByVal sender As System.Object, ByVal e As AxWMPLib._WMPOCXEvents_KeyDownEvent) Handles _player.KeyDownEvent
    ''    Select Case e.nKeyCode
    ''        Case Keys.Enter
    ''            zatvoriSekciju()
    ''        Case Keys.Escape
    ''            zatvoriSekciju()
    ''    End Select
    ''End Sub
    Private Sub zatvoriSekciju()
        _player.Dispose()
        Me.Dispose()
        GC.WaitForPendingFinalizers()
        GC.Collect()
        Select Case _zad
            Case 0
                _G.ucitajMeni()
            Case 1
                _G.startIgrice()
        End Select
    End Sub

    Private Sub _player_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _player.StatusChange
        If _player.status = "Stopped" Then
            _player.Ctlcontrols.stop()
            zatvoriSekciju()
        End If
    End Sub
End Class
