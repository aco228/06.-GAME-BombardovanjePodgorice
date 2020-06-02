Imports System.IO
Imports System.Windows.Forms
Public Class spoljasnjiResursi
    Public Sub New()
        provjeraZaUcitavanje()
        provjeraZaMapu()
        provjeraZaSlikeIVideo()

        If greskaUcitanju = False Then
            _kuceOstaloU = New List(Of Integer)
            _kuceUziCentarU = New List(Of Integer)
            _kuceVarosU = New List(Of Integer)
        End If
    End Sub

    'VARIJABLE
    Public greskaUcitanju As Boolean = False

#Region "MAPA (Lokacije kuca, start lokacije i nijanse mape)"
    Public _kuceUziCentarU As List(Of Integer) ' Unistene kuce
    Public _kuceUziCentar(,) As Integer = New Integer(,) {{1139, 1497, 0},
                                                         {1125, 1532, 0},
                                                         {1141, 1532, 0},
                                                         {1141, 1564, 0},
                                                         {1125, 1564, 0},
                                                         {1141, 1595, 0},
                                                         {1125, 1595, 0},
                                                         {1141, 1625, 0},
                                                         {1125, 1625, 0},
                                                         {1141, 1658, 0},
                                                         {1125, 1658, 0},
                                                         {1187, 1531, 0},
                                                         {1166, 1531, 0},
                                                         {1170, 1564, 0},
                                                         {1187, 1564, 0},
                                                         {1187, 1625, 0},
                                                         {1168, 1625, 0},
                                                         {1183, 1658, 0},
                                                         {1231, 1530, 0},
                                                         {1213, 1532, 0},
                                                         {1232, 1563, 0},
                                                         {1213, 1563, 0},
                                                         {1214, 1625, 0},
                                                         {1233, 1625, 0},
                                                         {1232, 1658, 0},
                                                         {1216, 1658, 0},
                                                         {1273, 1531, 0},
                                                         {1256, 1531, 0},
                                                         {1273, 1563, 0},
                                                         {1256, 1563, 0},
                                                         {1256, 1594, 0},
                                                         {1273, 1624, 0},
                                                         {1257, 1624, 0},
                                                         {1273, 1657, 0},
                                                         {1257, 1657, 0},
                                                         {1298, 1531, 0},
                                                         {1302, 1564, 0},
                                                         {1301, 1594, 0},
                                                         {1301, 1626, 0},
                                                         {1334, 1625, 0},
                                                         {1333, 1592, 0},
                                                         {1335, 1544, 0},
                                                         {1276, 1480, 0},
                                                         {1302, 1469, 0},
                                                         {1303, 1497, 0},
                                                         {1099, 1529, 0},
                                                         {1210, 1740, 0},
                                                         {1129, 1705, 0}}
    Public _kuceVarosU As List(Of Integer) ' Unistene kuce
    Public _kuceVaros(,) As Integer = New Integer(,) {{1126, 1771, 0},
                                                      {1118, 1803, 0},
                                                      {1170, 1764, 0},
                                                      {1149, 1790, 0},
                                                      {1110, 1851, 0},
                                                      {1168, 1820, 0},
                                                      {1174, 1856, 0},
                                                      {1150, 1869, 0},
                                                      {1202, 1852, 0},
                                                      {1223, 1876, 0},
                                                      {1262, 1805, 0},
                                                      {1210, 1797, 0},
                                                      {1244, 1855, 0},
                                                      {1286, 1823, 0},
                                                      {1318, 1801, 0},
                                                      {1338, 1811, 0},
                                                      {1357, 1807, 0},
                                                      {1274, 1860, 0},
                                                      {1165, 1922, 0},
                                                      {1186, 1917, 0},
                                                      {1206, 1914, 0},
                                                      {1226, 1910, 0},
                                                      {1204, 1959, 0},
                                                      {1121, 1896, 0},
                                                      {1137, 1929, 0},
                                                      {1151, 1968, 0},
                                                      {1091, 1912, 0},
                                                      {1078, 1877, 0},
                                                      {1145, 2010, 0},
                                                      {1101, 1969, 0}}
    Public _kuceOstaloU As List(Of Integer) ' Unistene kuce
    Public _kuceOstalo(,) As Integer = New Integer(,) {{1681, 1990, 0},
                                                       {1688, 1407, 0},
                                                       {1805, 1075, 0},
                                                       {2058, 934, 0},
                                                       {2001, 305, 0},
                                                       {1399, 508, 0},
                                                       {1425, 694, 0},
                                                       {1320, 1031, 0},
                                                       {1032, 1397, 0},
                                                       {966, 1474, 0},
                                                       {859, 1553, 0},
                                                       {531, 1519, 0},
                                                       {171, 1530, 0},
                                                       {852, 1838, 0},
                                                       {962, 1569, 0},
                                                       {1003, 1567, 0},
                                                       {1011, 1516, 0}}
    ' BOJE ZA MAPU
    Public _mapaNijanse(,) As Integer = New Integer(,) {{85, 95, 63},
                                                        {39, 42, 31},
                                                        {100, 123, 49},
                                                        {202, 220, 164},
                                                        {221, 233, 194},
                                                        {138, 148, 74}}
    ' LOKACIJE NA MAPI
    Public _startLokacije(,) As Integer = New Integer(,) {{1337, 1835},
                                                          {52, 1817},
                                                          {63, 1258},
                                                          {35, 584},
                                                          {966, 112},
                                                          {1436, 80},
                                                          {1240, 648},
                                                          {1247, 1345},
                                                          {739, 1469}}
#End Region

    Public _poruka As String = ""

    Private sadasnjiFolder As String = Environment.CurrentDirectory
    Public fajloviUcitavanja() As String = {"AxInterop.WMPLib.dll",
                                            "Interop.WMPLib.dll",
                                            "MySql.Data.dll"}

    Public rRes As String = sadasnjiFolder & "\\Resursi"

    Public rMapa As String = "\\Mapa\\"
    Public rMapaFajlovi() As String = {"01.png", "02.png", "03.png", "04.png", "05.png", "06.png", "07.png", "08.png", "09.png", "10.png", "11.png", "12.png", "13.png"}

    Public rSV As String = "\\SV\\"
    Public rSVfiles() As String = {"Video1.wmv",
                                   "Video2.wmv",
                                   "_kredits.png",
                                   "_pomoc.jpg",
                                  "_krajRunde.png",
                                   "_menuLogin.jpg",
                                   "splashScreen.jpg",
                                   "backKonzola.jpg"}

    Private Sub provjeraZaUcitavanje()
        For i As Integer = 0 To fajloviUcitavanja.Length - 1
            If Not File.Exists(sadasnjiFolder & "\\" & fajloviUcitavanja(i)) Then
                greskaUcitanju = True
                _poruka += "Грешка у спољашњим ресурсима." & vbCrLf & " Грешка код фајлова учитавања." & vbCrLf & " Грешка код фајла " & fajloviUcitavanja(i)
                Exit Sub
            End If
        Next
    End Sub
    Private Sub provjeraZaMapu()
        If greskaUcitanju = True Then Exit Sub
        For i As Integer = 0 To rMapaFajlovi.Length - 1
            If Not File.Exists(rRes & rMapa & rMapaFajlovi(i)) Then
                greskaUcitanju = True
                _poruka += "Грешка у спољашњим ресурсима." & vbCrLf & " Грешка код фајлова мапе." & vbCrLf & " Грешка код фајла " & rMapaFajlovi(i)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub provjeraZaSlikeIVideo()
        If greskaUcitanju = True Then Exit Sub
        For i As Integer = 0 To rSVfiles.Length - 1
            If Not File.Exists(rRes & rSV & rSVfiles(i)) Then
                greskaUcitanju = True
                _poruka += "Грешка у спољашњим ресурсима." & vbCrLf & " Грешка код фајлова слика и видеа." & vbCrLf & " Грешка код фајла " & rSVfiles(i)
                Exit Sub
            End If
        Next
    End Sub

End Class
