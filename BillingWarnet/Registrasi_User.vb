Imports MySql.Data.MySqlClient
Imports MySql.Data.MySqlClient.MySqlCommand
Imports MySql.Data
Imports System.Data.SqlClient

Public Class Registrasi_User
    Public waktu As Integer
    Public kode As String
    Public total As Integer

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'tutup dan buka koneksi
        

        'validasi data
        If MsgBox("Apakah anda yakin akan registrasi?",
                  MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'panggil nomor otomatis
            NomorOtomatis()
            Dim sqlr As String
            Dim strTemp As String = ""
            Dim strValue As String = ""

            konek.Close()
            konek.Open()
            'cek user ada ga
            Dim sqlStr As String = "SELECT COUNT(*) FROM pelanggan WHERE username_p = ?uname"
            Dim cmd As New MySqlCommand(sqlStr, konek)
            cmd.Parameters.AddWithValue("?uname", txtusername.Text)
            Dim rowCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If txtusername.Text = "" Then
                MessageBox.Show("Silahkan isi Username anda")
                txtusername.Focus()
                Exit Sub
            ElseIf txtpassword.Text = "" Then
                MessageBox.Show("Silahkan isi password anda")
                txtpassword.Focus()
                Exit Sub
            ElseIf txtkonfirmasipassword.Text = "" Then
                MessageBox.Show("Silahkan isi ulangi password anda")
                txtkonfirmasipassword.Focus()
                Exit Sub
            ElseIf txtpassword.Text <> txtkonfirmasipassword.Text Then
                MessageBox.Show("Password dan Ulangi Password tidak sama!, Silahkan Isi Ulang!")
                txtpassword.Text = ""
                txtkonfirmasipassword.Text = ""
                txtpassword.Focus()
                Exit Sub
            ElseIf rowCount <> 0 Then
                MessageBox.Show("Mohon Maaf, Username sudah dipakai, gunakan username lain!")
                txtusername.Text = ""
                txtusername.Focus()
                Exit Sub
            Else
                'get durasi berdasarkan kode paket

                Dim sw As MySqlCommand
                Dim rrw As MySqlDataReader

                sw = New MySqlCommand("SELECT paket.durasi_paket FROM pelanggan INNER JOIN paket ON paket.kode_paket=pelanggan.kode_paket WHERE pelanggan.kode_paket= '" & cb_paket.SelectedValue.ToString & "'", konek)
                rrw = sw.ExecuteReader
                rrw.Read()

                If rrw.HasRows Then
                    waktu = rrw.Item("durasi_paket")
                End If

                konek.Close()
                konek.Open()

                'Save ke database
                sqlr = "INSERT INTO pelanggan (username_p ,password_p, no_hp, kode_paket, durasi)" & _
                        "VALUES('" & txtusername.Text & "','" & txtpassword.Text & "','" & txthp.Text & "','" & cb_paket.SelectedValue & "','" & waktu & "')"
                cd = New MySqlCommand(sqlr, konek)
                Dim x As Integer = cd.ExecuteNonQuery
                If x = 1 Then

                    MessageBox.Show("Registrasi berhasil!")

                    'Buka Koneksi 
                    Call kon()
                    konek.Open()
                    cw = New MySqlCommand("SELECT pelanggan.kode_paket, paket.harga_paket FROM pelanggan INNER JOIN paket ON paket.kode_paket=pelanggan.kode_paket WHERE pelanggan.username_p = '" &
                                            txtusername.Text & "'", konek)

                    rw = cw.ExecuteReader
                    rw.Read()

                    If rw.HasRows Then

                        kode = rw.Item("kode_paket")
                        total = rw.Item("harga_paket")

                        'Save ke tabel trx
                        konek.Close()
                        konek.Open()

                        Dim trx As String
                        Dim status As String
                        status = "Belum Lunas"
                        trx = "INSERT INTO transaksi (id_transaksi , username_p, kode_paket, total_bayar, status_transaksi)" & _
                                "VALUES('" & txtkode.Text & "','" & txtusername.Text & "','" & kode & "','" & total & "','" & status & "')"
                        tx = New MySqlCommand(trx, konek)
                        Dim y As Integer = tx.ExecuteNonQuery
                    End If
                    Call Bersih()
                    Me.Hide()
                    Login_User.Show()
                    konek.Close()

                Else
                    MessageBox.Show("Registrasi Gagal!")
                End If
            End If
        End If
    End Sub

    Private Sub Bersih()
        txtusername.Text = ""
        txtpassword.Text = ""
        txtkonfirmasipassword.Text = ""
        txthp.Text = ""
        txtusername.Focus()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_paket.SelectedIndexChanged
        
    End Sub


    Private Sub Registrasi_User_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtusername.Focus()
        Call PanjangData()
        Call Bersih()

        'Buka Koneksi 
        Call kon()
        konek.Close()
        konek.Open()

        Dim adapter As New MySqlDataAdapter("SELECT `kode_paket`, `nama_paket`, `durasi_paket`, `harga_paket` FROM `paket", konek)
        Dim table As New DataTable()

        adapter.Fill(table)

        cb_paket.DataSource = table
        cb_paket.ValueMember = "kode_paket"
        cb_paket.DisplayMember = "nama_paket"


    End Sub

    Private Sub NomorOtomatis()
        'buat koneksi
        konek = New MySqlConnection("server=localhost;uid=root;database=bw;")
        If konek.State <> ConnectionState.Closed Then konek.Close()

        'buka koneksi database
        konek.Open()
        'deklarasi variable
        Dim tstrTemp As String = ""
        Dim tstrValue As String = ""
        Dim tsql As String = ""

        Try
            tsql = "SELECT * FROM transaksi ORDER BY id_transaksi DESC"
            cd = New MySqlCommand(tsql, konek)
            rd = cd.ExecuteReader

            'membaca data di database
            If rd.Read Then
                tstrTemp = Mid(rd.Item("id_transaksi"), 4, 6)
            Else
                txtkode.Text = "TRX001"
                Exit Sub
            End If
            tstrValue = Val(tstrTemp) + 1
            txtkode.Text = "TRX" & Mid("000", 1, 3 - tstrValue.Length) & tstrValue
            txtusername.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        Call Bersih()
        Me.Hide()
        Login_User.Show()
        Awal.Hide()
        Login.Hide()

    End Sub

    Private Sub txtkode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkode.TextChanged

    End Sub

    Private Sub txthp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txthp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthp.TextChanged

    End Sub

    Private Sub PanjangData()
        txtusername.MaxLength = 25
        txtpassword.MaxLength = 25
        txthp.MaxLength = 13
    End Sub
End Class