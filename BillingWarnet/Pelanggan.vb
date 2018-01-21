Imports MySql.Data.MySqlClient

Public Class Pelanggan
    Public waktu As Integer
    Public kode As String
    Public total As Integer
    Private Sub Pelanggan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PanjangData()
        TampilGrid()
        aturDGV()
        cb_paket.Enabled = True
        cb_paket.Visible = True
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

        TampilGrid()
        aturDGV()
    End Sub

    Private Sub txtnohp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnohp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub PanjangData()
        txtusername.MaxLength = 25
        txtpassword.MaxLength = 25
        txtnohp.MaxLength = 13
    End Sub

    Sub TampilGrid()
        Call kon()
        da = New MySqlDataAdapter("SELECT * FROM pelanggan", konek)
        ds = New DataSet
        da.Fill(ds, "pelanggan")
        dgpel.DataSource = ds.Tables("pelanggan")
        dgpel.ReadOnly = True
    End Sub
    Sub aturDGV()
        Try
            dgpel.Columns(0).Width = 100
            dgpel.Columns(1).Width = 100
            dgpel.Columns(2).Width = 100
            dgpel.Columns(3).Width = 75
            dgpel.Columns(4).Width = 75
            dgpel.Columns(0).HeaderText = "USERNAME"
            dgpel.Columns(1).HeaderText = "PASSWORD"
            dgpel.Columns(2).HeaderText = "NOMOR HP"
            dgpel.Columns(3).HeaderText = "KODE PAKET"
            dgpel.Columns(4).HeaderText = "DURASI (DETIK)"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnlihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlihat.Click
        TampilGrid()
        aturDGV()
        cb_paket.Enabled = True
        cb_paket.Visible = True
        Call Bersih()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
            ElseIf txtpassword.Text = "" Then
                MessageBox.Show("Silahkan isi ulangi password anda")
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
                        "VALUES('" & txtusername.Text & "','" & txtpassword.Text & "','" & txtnohp.Text & "','" & cb_paket.SelectedValue & "','" & waktu & "')"
                cd = New MySqlCommand(sqlr, konek)
                Dim x As Integer = cd.ExecuteNonQuery
                If x = 1 Then

                    MessageBox.Show("Registrasi berhasil!")
                    TampilGrid()
                    aturDGV()
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
        txtnohp.Text = ""
        txtusername.Focus()
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


    Private Sub cb_paket_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_paket.SelectedIndexChanged
        
    End Sub

    Private Sub txtusername_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtusername.KeyPress
        If e.KeyChar = Chr(13) Then
            Call kon()
            konek.Open()

            Dim csw As MySqlCommand
            Dim csrrw As MySqlDataReader
            csw = New MySqlCommand("Select * From pelanggan  where username_p='" & txtusername.Text & "'", konek)
            csrrw = csw.ExecuteReader
            csrrw.Read()
            If Not csrrw.HasRows Then
                MsgBox("USERNAME TIDAK ADA, Silahkan coba lagi!")
                txtusername.Focus()
            Else
                txtpassword.Text = csrrw.Item("password_p")
                txtnohp.Text = csrrw.Item("no_hp")
                cb_paket.Visible = False
                cb_paket.Enabled = False
                txtusername.Focus()
            End If
        End If
    End Sub

    Private Sub txtusername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtusername.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        'validasi data
        If MsgBox("Apakah anda yakin akan merubahnya?",
                  MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If txtusername.Text = "" Then
                MessageBox.Show("Silahkan isi Username anda")
                txtusername.Focus()
                Exit Sub
            ElseIf txtpassword.Text = "" Then
                MessageBox.Show("Silahkan isi password anda")
                txtpassword.Focus()
                Exit Sub
            ElseIf txtnohp.Text = "" Then
                MessageBox.Show("Silahkan isi nomor hp anda")
                txtnohp.Focus()
                Exit Sub
            Else
                Call kon()
                konek.Open()

                Dim edit As String = "UPDATE pelanggan SET username_p='" & txtusername.Text & "',password_p='" & txtpassword.Text & "',no_hp='" & txtnohp.Text & "' where username_p='" & txtusername.Text & "'"
                Dim cmd As MySqlCommand
                cmd = New MySqlCommand(edit, konek)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil diUpdate")
                Call TampilGrid()
                Call Bersih()
            End If
        Else
            Call TampilGrid()
            Call aturDGV()
            Call Bersih()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'validasi data
        If MsgBox("Apakah anda yakin akan merubahnya?",
                  MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If txtusername.Text = "" Then
                MessageBox.Show("Silahkan isi Username anda")
                txtusername.Focus()
                Exit Sub
            ElseIf txtpassword.Text = "" Then
                MessageBox.Show("Silahkan isi password anda")
                txtpassword.Focus()
                Exit Sub
            ElseIf txtnohp.Text = "" Then
                MessageBox.Show("Silahkan isi nomor hp anda")
                txtnohp.Focus()
                Exit Sub
            Else
                Call kon()
                konek.Open()
                Dim hapus As String = "DELETE FROM pelanggan WHERE username_p ='" & txtusername.Text & "'"
                Dim cmddel As MySqlCommand
                cmddel = New MySqlCommand(hapus, konek)
                MsgBox("Data Berhasil di hapus")
                cmddel.ExecuteNonQuery()
                Call TampilGrid()
                Call Bersih()
            End If
        Else
            Call TampilGrid()
            Call aturDGV()
            Call Bersih()
        End If
    End Sub

    Private Sub dgpel_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgpel.CellMouseDoubleClick
        txtusername.Text = dgpel.Rows(e.RowIndex).Cells(0).Value.ToString
        txtpassword.Text = dgpel.Rows(e.RowIndex).Cells(1).Value.ToString
        txtnohp.Text = dgpel.Rows(e.RowIndex).Cells(2).Value.ToString

        txtusername.Text = dgpel.Rows(e.RowIndex).Cells(0).Value.ToString
        txtpassword.Text = dgpel.Rows(e.RowIndex).Cells(1).Value.ToString
        txtnohp.Text = dgpel.Rows(e.RowIndex).Cells(2).Value.ToString

        cb_paket.Visible = False
        cb_paket.Enabled = False
    End Sub

    Private Sub txtnohp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnohp.TextChanged

    End Sub
End Class