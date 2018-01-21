Imports MySql.Data.MySqlClient

Public Class JLaporan
    Public total As Integer
    Public bayar As Integer
    Public kembali As Integer
    Private Sub JLaporan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtid.Text = Transaksi.txtid.Text
        txtkodepaket.Text = Transaksi.txtkodepaket.Text
        txttotal.Text = Transaksi.txttotal.Text
        txtusername.Text = Transaksi.txtusername.Text
        txtid.Enabled = False
        txtkodepaket.Enabled = False
        txttotal.Enabled = False
        txtusername.Enabled = False
        txtkembali.Enabled = False
        NomorOtomatis()

    End Sub

    Private Sub txtpelangganbayar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpelangganbayar.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = Chr(13) Then
            total = Val(txttotal.Text)
            bayar = Val(txtpelangganbayar.Text)
            kembali = bayar - total
            txtkembali.Text = kembali
        Else
            txtkembali.Text = 0
        End If
    End Sub

    Private Sub btnbayar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbayar.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Apakah anda semua data pembayaran sudah benar ?", MsgBoxStyle.YesNo)
        If ask = MsgBoxResult.Yes Then
            Call kon()
            konek.Close()
            konek.Open()
            Dim sql As String
            Dim status As String
            status = "Sudah Lunas"
            sql = "UPDATE transaksi SET status_transaksi = '" & status & "' WHERE id_transaksi='" & txtid.Text & "'"
            cd = New MySqlCommand(sql, konek)
            Dim x As Integer = cd.ExecuteNonQuery
            konek.Close()
            konek.Open()
            Dim lapsql As String
            Dim regDate As DateTime = DateTime.Now
            Dim strDate As String = regDate.ToString("yyyy-MM-dd HH:mm:ss")
            lapsql = "INSERT INTO laporan (id_laporan , id_transaksi, total_bayar, pelanggan_bayar, kembalian_bayar, tanggal)" & _
                                "VALUES('" & txtidlap.Text & "','" & txtid.Text & "','" & txttotal.Text & "','" & txtpelangganbayar.Text & "','" & txtkembali.Text & "','" & strDate & "')"
            cd = New MySqlCommand(lapsql, konek)
            Dim y As Integer = cd.ExecuteNonQuery
            MsgBox("Terimakasih, Transaksi Berhasil Tercatat Di Laporan!", MsgBoxStyle.OkOnly)
            Me.Close()

        End If
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
            tsql = "SELECT * FROM laporan ORDER BY id_laporan DESC"
            cd = New MySqlCommand(tsql, konek)
            rd = cd.ExecuteReader

            'membaca data di database
            If rd.Read Then
                tstrTemp = Mid(rd.Item("id_laporan"), 4, 6)
            Else
                txtidlap.Text = "LAP001"
                Exit Sub
            End If
            tstrValue = Val(tstrTemp) + 1
            txtidlap.Text = "LAP" & Mid("000", 1, 3 - tstrValue.Length) & tstrValue
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtpelangganbayar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpelangganbayar.TextChanged

    End Sub
End Class