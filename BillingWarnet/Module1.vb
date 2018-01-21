Imports MySql.Data.MySqlClient
Imports MySql.Data.MySqlClient.MySqlCommand
Imports MySql.Data
Module Module1
    Public konek As MySqlConnection
    Public da As MySqlDataAdapter
    Public dt As DataTable
    Public ds As DataSet
    Public cd As MySqlCommand
    Public tx As MySqlCommand
    Public ct As MySqlCommand
    Public rt As MySqlDataReader
    Public rd As MySqlDataReader
    Public cw As MySqlCommand
    Public rw As MySqlDataReader
    Public nama As String

    Sub kon()
        Try
            konek = New MySqlConnection("server=localhost; uid=root; database=bw")
            'Membuat Koneksi'
            konek.Open()

            'Menutup Koneksi'
            konek.Close()

        Catch ex As Exception
            MsgBox("Koneksi Gagal " & ex.Message)
        End Try
    End Sub
    Sub TampilNamaWarnet()
        Call kon()
        konek.Close()
        'buka koneksi database
        konek.Open()
        cw = New MySqlCommand("SELECT * FROM `profil` WHERE id_warnet='1'", konek)

        rw = cw.ExecuteReader
        rw.Read()

        If rw.HasRows Then
            nama = rw.Item("nama_warnet")
        End If
    End Sub

End Module
