Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.IO
Public Class bazaPodataka

    Public greska As Boolean = False
    Public vecUcitan As Boolean = False
    Public _bazaSeKoristi = False
    Dim konekcijaString As String = ""
    Dim imeKonekcijaFajl As String
    Dim prviPut As Boolean = True
    Dim welcomePoruka As String = "(Automatski generisana poruka)" & vbCrLf & "Dobrodosli na Bombardovanje Podgorice!"
    ' KORISNIK
    Dim admin As String = "aco228"
    Public adminIsOn As Boolean = False
    Public userName As String
    Public najboljiRezultat As Integer
    Public idIgraca As Integer

    'Public vrijemeRefreshaZaMeni As Integer = 60000
    Public neProcitanePoruke As Integer
    Public onlineIgraci As Integer
    Public rangListaIgraca As Integer

    Public naslovPoruke As String
    Public tekstPoruke As String
    Private porukaIzBazeProcitana As Boolean = False
    Public porukaProcitanaUMeniju = False

    ' MYSQL
    Dim konekcija As MySqlConnection
    Dim komanda As MySqlCommand
    Dim reader As MySqlDataReader


    Public Sub New(ByVal f As String)
        imeKonekcijaFajl = f
        citanjeKonekcije()
        greska = openDB()
        If greska = False Then konekcija.Close()
    End Sub
    Public Sub New(ByVal a As Boolean)
        greska = a
    End Sub
    '
    ' KONEKCIJA SA BAZOM
    '
    Private Function openDB() As Boolean
        Try
            konekcija.Open()
            Return False
        Catch ex As Exception
            Return True
        End Try
    End Function
    Private Sub citanjeKonekcije()
        If (File.Exists(imeKonekcijaFajl)) Then
            Using t As TextReader = File.OpenText(imeKonekcijaFajl)
                konekcijaString = t.ReadLine
                t.Close()
                konekcija = New MySqlConnection(konekcijaString)
            End Using
        Else
            greska = True
        End If
    End Sub
    '
    ' UPDATE
    '
    Public Sub updateOnline(ByVal i As Integer)
        ' 0 = ONLINE
        ' 1 = OFFLINE
        If openDB() = False Then
            komanda = New MySqlCommand("UPDATE igrac SET online=" & i & " WHERE username='" & userName & "';", konekcija)
            komanda.ExecuteNonQuery()

            komanda.Dispose()
            konekcija.Close()
        End If
    End Sub

    Public Sub refreshInfo()
        getNeprocitanePoruke()
        getOnlineIgraci()
        getRangLista()
        If porukaIzBazeProcitana = False Then getPorukaIzBaze()
    End Sub
    Private Sub getNeprocitanePoruke()
        If openDB() = False Then
            komanda = New MySqlCommand("SELECT COUNT(*) FROM poruka WHERE prima='" & idIgraca & "' AND procitano=1;", konekcija)
            reader = komanda.ExecuteReader()
            If reader.Read() = True Then neProcitanePoruke = reader.GetInt32(0)
            reader.Close()
            komanda.Dispose()
            konekcija.Close()
        End If
    End Sub
    Private Sub getOnlineIgraci()
        If openDB() = False Then
            komanda = New MySqlCommand("SELECT COUNT(*) FROM igrac WHERE online=0;", konekcija)
            reader = komanda.ExecuteReader()
            If reader.Read() = True Then onlineIgraci = reader.GetInt32(0)
            reader.Close()
            komanda.Dispose()
            konekcija.Close()
        End If
    End Sub
    Private Sub getRangLista()
        If openDB() = False Then
            komanda = New MySqlCommand("SELECT username FROM igrac ORDER BY najboljiRezultat DESC;", konekcija)
            reader = komanda.ExecuteReader()
            Dim i As Integer = 1
            While reader.Read() = True
                If reader.GetString(0) = userName Then
                    Exit While
                Else
                    i += 1
                End If
            End While
            rangListaIgraca = i
            reader.Close()
            komanda.Dispose()
            konekcija.Close()
        End If
    End Sub
    Private Sub getPorukaIzBaze()
        If openDB() = False Then
            komanda = New MySqlCommand("SELECT naslov, tekst FROM porukaIzBaze ORDER BY idB DESC LIMIT 1;", konekcija)
            reader = komanda.ExecuteReader()

            If reader.Read() Then
                naslovPoruke = reader.GetString(0)
                tekstPoruke = reader.GetString(1)
            End If

            reader.Close()
            komanda.Dispose()
            konekcija.Close()
        End If
        porukaIzBazeProcitana = True
    End Sub
    Public Sub setNovuPorukuIzBaze(ByVal naslov As String, ByVal tekst As String)
        If openDB() = False Then
            komanda = New MySqlCommand("INSERT INTO porukaIzBaze (naslov, tekst) VALUES ('" & naslov & "', '" & tekst & "');", konekcija)
            komanda.ExecuteNonQuery()
            komanda.Dispose()
            konekcija.Close()
        End If
    End Sub
    Public Sub setNoviNajboljiRezultat(ByVal rez As Integer)
        If openDB() = False Then
            komanda = New MySqlCommand("UPDATE igrac SET najboljiRezultat=" & rez & " WHERE id=" & idIgraca & ";", konekcija)
            komanda.ExecuteNonQuery()
            najboljiRezultat = rez
            komanda.Dispose()
            konekcija.Close()
        End If
    End Sub

    '
    ' LOG IN KORISNIKA
    '
    Public Function verifikacijaKorisnika(ByVal user As String, ByVal pass As String) As String
        Dim back As String = "Грешка, база се не одазива"
        If openDB() = False Then
            komanda = New MySqlCommand("SELECT COUNT(*) FROM igrac WHERE username ='" & user & "';", konekcija)
            reader = komanda.ExecuteReader()
            If reader.Read() = True And reader.GetInt32(0) = 1 Then
                komanda = New MySqlCommand("SELECT COUNT(*), najboljiRezultat, id FROM igrac WHERE username='" & user & "'AND sifra='" & pass & "';", konekcija)
                reader.Close()
                reader = komanda.ExecuteReader()
                If reader.Read() = True And reader.GetInt32(0) = 1 Then
                    najboljiRezultat = reader.GetInt32(1)
                    idIgraca = reader.GetInt32(2)
                    userName = user
                    If userName = admin Then adminIsOn = True
                    back = ""
                Else
                    back = "Погрешна шифра за играча " & user & "!"
                End If
            Else
                back = "Играч " & user & " не постоји!"
            End If
            reader.Close()
            komanda.Dispose()
            konekcija.Close()
        End If
        Return back
    End Function
    Public Function unosKorisnika(ByVal user As String, ByVal pass As String) As String
        Dim back As String = "Грешка, база се не одазива"
        If openDB() = False Then
            komanda = New MySqlCommand("SELECT COUNT(*) FROM igrac WHERE username='" & user & "';", konekcija)
            reader = komanda.ExecuteReader()
            If reader.Read = True And reader.GetInt32(0) = 0 Then
                reader.Close()
                komanda = New MySqlCommand("INSERT INTO igrac (username, sifra) VALUES ( '" & user & "', '" & pass & "');", konekcija)
                komanda.ExecuteNonQuery()
                back = ""
            Else
                back = "Грешка, корисник већ постоји са именом " & user & "!"
            End If
            If Not reader.IsClosed() Then reader.Close()
            komanda.Dispose()
            konekcija.Close()
        End If
        If back = "" Then slanjeWelcomPoruke(user)
        Return back
    End Function
    Private Sub slanjeWelcomPoruke(ByVal user As String)
        Dim idP = postojiUser(user)
        If Not idP = -1 And openDB() = False Then
            komanda = New MySqlCommand("INSERT INTO poruka (tekst, poslao, prima) VALUES ( '" & welcomePoruka & "', 1, " & idP & ");", konekcija)
            komanda.ExecuteNonQuery()
            komanda.Dispose()
            konekcija.Close()
        End If
    End Sub

    '
    ' SPISAK IGRACA
    '
    Public Function listaIgraca() As String(,)
        If openDB() = False Then
            ' KOLIKO IMA IGRACA
            komanda = New MySqlCommand("SELECT COUNT(*) from igrac", konekcija)
            reader = komanda.ExecuteReader()
            Dim brIgraca As Integer = -1
            If reader.Read() = True Then brIgraca = reader.GetInt32(0)
            Dim back(brIgraca - 1, 1) As String

            ' Citanje Podataka
            If Not brIgraca = -1 Then
                reader.Close()
                komanda = New MySqlCommand("SELECT username, online FROM igrac ORDER BY username", konekcija)
                reader = komanda.ExecuteReader()
                For i As Integer = 0 To brIgraca - 1
                    If reader.Read() = False Then Exit For
                    back(i, 0) = reader.GetString(0)
                    back(i, 1) = reader.GetInt32(1).ToString()
                    'MessageBox.Show(back(i, 0) & "   |   " & back(i, 1))
                Next
            End If

            reader.Close()
            komanda.Dispose()
            konekcija.Close()
            Return back
        End If
        Return Nothing
    End Function

    '
    '   NAJBOLJI REZULTATI
    '
    Public Function najboljiRezultati() As String(,)
        If openDB() = False Then
            Dim back(,) As String = Nothing
            komanda = New MySqlCommand("SELECT COUNT(*) FROM igrac;", konekcija)
            reader = komanda.ExecuteReader()
            Dim brIgraca As Integer
            If reader.Read() = True Then
                brIgraca = reader.GetInt32(0)
                reader.Close()
                'Dim back(brIgraca - 1, 1) As String
                ReDim back(brIgraca - 1, 1)

                ' Preuzimanje rezultata
                komanda = New MySqlCommand("SELECT username, najboljiRezultat FROM igrac ORDER BY najboljiRezultat DESC;", konekcija)
                reader = komanda.ExecuteReader()
                For i As Integer = 0 To brIgraca - 1
                    If reader.Read() = True Then
                        back(i, 0) = reader.GetString(0)
                        back(i, 1) = reader.GetInt32(1).ToString()
                        'MessageBox.Show(back(i, 0) & " } " & back(i, 1))
                    End If
                Next
            End If
            reader.Close()
            komanda.Dispose()
            konekcija.Close()
            Return back
        End If
        Return Nothing
    End Function

    '
    ' PORUKA
    '
    Private Function postojiUser(ByVal d As String) As Integer
        If openDB() = False Then
            komanda = New MySqlCommand("SELECT id FROM igrac WHERE username='" & d & "';", konekcija)
            reader = komanda.ExecuteReader()
            Dim back As Integer = -1
            If reader.Read() Then back = reader.GetInt32(0)

            reader.Close()
            komanda.Dispose()
            konekcija.Close()
            Return back
        End If
        Return -1
    End Function
    Public Function slanjePoruke(ByVal user As String, ByVal poruka As String) As String
        Dim back As String = ""
        Dim userID As Integer = postojiUser(user)
        If userID > -1 And openDB() = False Then
            komanda = New MySqlCommand("INSERT INTO poruka (poslao, prima, tekst) VALUES ( " & idIgraca & ", " & userID & ", '" & poruka & "' );", konekcija)
            komanda.ExecuteNonQuery()
            komanda.Dispose()
            konekcija.Close()
            back = ""
        Else
            back = "Играч " & user & " не постоји!"
        End If
        Return back
    End Function
    Public Function primljenePoruke() As String(,)
        Dim back As String(,) = Nothing
        If openDB() = False Then
            komanda = New MySqlCommand("SELECT COUNT(*) FROM poruka WHERE prima='" & idIgraca & "';", konekcija)
            reader = komanda.ExecuteReader()
            If reader.Read() = True Then
                Dim kolicina As Integer = reader.GetInt32(0)
                ReDim back(kolicina - 1, 4)
                reader.Close()

                komanda = New MySqlCommand("SELECT p.idP, p.tekst, p.procitano, i.username, p.vrijeme FROM poruka as p, igrac as i WHERE p.prima='" & idIgraca & "' AND p.poslao=i.id;", konekcija)
                reader = komanda.ExecuteReader()
                For i As Integer = 0 To kolicina - 1
                    If reader.Read() = True Then
                        back(i, 0) = reader.GetInt32(0).ToString()
                        back(i, 1) = reader.GetString(1)
                        back(i, 2) = reader.GetInt32(2).ToString()
                        back(i, 3) = reader.GetString(3)
                        back(i, 4) = reader.GetString(4)
                    End If
                Next
            End If

            reader.Close()
            komanda.Dispose()
            konekcija.Close()
        End If
        Return back
    End Function

    Public Function poslatePoruke() As String(,)
        Dim back As String(,) = Nothing
        If openDB() = False Then
            komanda = New MySqlCommand("SELECT COUNT(*) FROM poruka WHERE poslao='" & idIgraca & "';", konekcija)
            reader = komanda.ExecuteReader()
            If reader.Read() = True Then
                Dim kolicina As Integer = reader.GetInt32(0)
                ReDim back(kolicina - 1, 4)
                reader.Close()

                komanda = New MySqlCommand("SELECT p.idP, p.tekst, p.procitano, i.username, p.vrijeme FROM poruka as p, igrac as i WHERE p.poslao='" & idIgraca & "' AND p.prima=i.id;", konekcija)
                reader = komanda.ExecuteReader()
                For i As Integer = 0 To kolicina - 1
                    If reader.Read() = True Then
                        back(i, 0) = reader.GetInt32(0).ToString()  ' idP
                        back(i, 1) = reader.GetString(1)            ' tekst
                        back(i, 2) = reader.GetInt32(2).ToString()  ' proocitano
                        back(i, 3) = reader.GetString(3)            ' username
                        back(i, 4) = reader.GetString(4)            ' vrijeme
                    End If
                Next
            End If

            reader.Close()
            komanda.Dispose()
            konekcija.Close()
        End If
        Return back
    End Function
    Public Sub porukaProcitana(ByVal id As Integer)
        If openDB() = False Then
            komanda = New MySqlCommand("UPDATE poruka SET procitano=0 WHERE idP='" & id & "';", konekcija)
            komanda.ExecuteNonQuery()
            komanda.Dispose()
            konekcija.Close()
        End If
    End Sub
    Public Sub brisanjePoruke(ByVal id As Integer)
        If openDB() = False Then
            komanda = New MySqlCommand("DELETE FROM poruka WHERE idP='" & id & "';", konekcija)
            komanda.ExecuteNonQuery()
            komanda.Dispose()
            konekcija.Close()
        End If
    End Sub
End Class
