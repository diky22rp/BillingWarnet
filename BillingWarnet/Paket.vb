Imports MySql.Data.MySqlClient

Public Class Paket

    Private Sub txtharga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtharga.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtdurasi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdurasi.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
    Sub TampilGrid()
        Call kon()
        da = New MySqlDataAdapter("SELECT * FROM paket", konek)
        ds = New DataSet
        da.Fill(ds, "paket")
        dgpaket.DataSource = ds.Tables("paket")
        dgpaket.ReadOnly = True
    End Sub
    Sub aturDGV()
        Try
            dgpaket.Columns(0).Width = 100
            dgpaket.Columns(1).Width = 150
            dgpaket.Columns(2).Width = 120
            dgpaket.Columns(3).Width = 100
            dgpaket.Columns(0).HeaderText = "KODE PAKET"
            dgpaket.Columns(1).HeaderText = "NAMA PAKET"
            dgpaket.Columns(2).HeaderText = "DURASI PAKET"
            dgpaket.Columns(3).HeaderText = "HARGA PAKET"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Paket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilGrid()
        aturDGV()
    End Sub
    Private Sub Bersih()
        txtkodepaket.Text = ""
        txtnamapaket.Text = ""
        txtdurasi.Text = ""
        txtharga.Text = ""
        txtkodepaket.Focus()
    End Sub

    Private Sub btnlihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlihat.Click
        TampilGrid()
        aturDGV()
        Call Bersih()
    End Sub

    Private Sub dgpaket_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgpaket.CellMouseDoubleClick
        txtkodepaket.Text = dgpaket.Rows(e.RowIndex).Cells(0).Value.ToString
        txtnamapaket.Text = dgpaket.Rows(e.RowIndex).Cells(1).Value.ToString
        txtdurasi.Text = dgpaket.Rows(e.RowIndex).Cells(2).Value.ToString
        txtharga.Text = dgpaket.Rows(e.RowIndex).Cells(3).Value.ToString

        txtkodepaket.Text = dgpaket.Rows(e.RowIndex).Cells(0).Value.ToString
        txtnamapaket.Text = dgpaket.Rows(e.RowIndex).Cells(1).Value.ToString
        txtdurasi.Text = dgpaket.Rows(e.RowIndex).Cells(2).Value.ToString
        txtharga.Text = dgpaket.Rows(e.RowIndex).Cells(3).Value.ToString
    End Sub

    Private Sub btntambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntambah.Click
        'validasi data
        If MsgBox("Apakah anda yakin akan menambah paket?",
                  MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            konek.Close()
            konek.Open()
            'cek user ada ga
            Dim sqlStr As String = "SELECT COUNT(*) FROM paket WHERE kode_paket = ?uname"
            Dim cmd As New MySqlCommand(sqlStr, konek)
            cmd.Parameters.AddWithValue("?uname", txtkodepaket.Text)
            Dim rowCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If txtkodepaket.Text = "" Then
                MessageBox.Show("Silahkan isi kode paket anda")
                txtkodepaket.Focus()
                Exit Sub
            ElseIf txtnamapaket.Text = "" Then
                MessageBox.Show("Silahkan isi nama paket anda")
                txtnamapaket.Focus()
                Exit Sub
            ElseIf txtdurasi.Text = "" Then
                MessageBox.Show("Silahkan isi durasi paket anda")
                txtdurasi.Focus()
                Exit Sub
            ElseIf txtharga.Text = "" Then
                MessageBox.Show("Silahkan isi harga paket anda")
                txtharga.Focus()
                Exit Sub
            ElseIf rowCount <> 0 Then
                MessageBox.Show("Mohon Maaf, kode paket sudah dipakai, gunakan kode paket lain!")
                txtkodepaket.Text = ""
                txtkodepaket.Focus()
                Exit Sub
            Else

                Dim sqlr As String
                'Save ke database
                sqlr = "INSERT INTO paket (kode_paket ,nama_paket, durasi_paket, harga_paket)" & _
                        "VALUES('" & txtkodepaket.Text & "','" & txtnamapaket.Text & "','" & txtdurasi.Text & "','" & txtharga.Text & "')"
                cd = New MySqlCommand(sqlr, konek)
                Dim x As Integer = cd.ExecuteNonQuery
                If x = 1 Then
                    MessageBox.Show("Paket Berhasil di Tambahkan")
                    TampilGrid()
                    aturDGV()
                Else
                    MessageBox.Show("Paket Gagal di Tambahkan!")
                End If
            End If
        End If
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        'validasi data
        If MsgBox("Apakah anda yakin akan merubahnya?",
                  MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If txtkodepaket.Text = "" Then
                MessageBox.Show("Silahkan isi kode paket anda")
                txtkodepaket.Focus()
                Exit Sub
            ElseIf txtnamapaket.Text = "" Then
                MessageBox.Show("Silahkan isi nama paket anda")
                txtnamapaket.Focus()
                Exit Sub
            ElseIf txtdurasi.Text = "" Then
                MessageBox.Show("Silahkan isi durasi paket anda")
                txtdurasi.Focus()
                Exit Sub
            ElseIf txtharga.Text = "" Then
                MessageBox.Show("Silahkan isi harga paket anda")
                txtharga.Focus()
                Exit Sub
            Else
                Call kon()
                konek.Open()

                Dim edit As String = "UPDATE paket SET kode_paket='" & txtkodepaket.Text & "',nama_paket='" & txtnamapaket.Text & "',durasi_paket='" & txtdurasi.Text & "',harga_paket='" & txtharga.Text & "' where kode_paket='" & txtkodepaket.Text & "'"
                Dim cmd As MySqlCommand
                cmd = New MySqlCommand(edit, konek)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil diUpdate")
                Call TampilGrid()
                Call aturDGV()
                Call Bersih()
            End If
        Else
            Call TampilGrid()
            Call aturDGV()
            Call Bersih()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtkodepaket.Text = "" Then
            MsgBox("Silahkan Pilih Data yang akan di hapus dengan double klik pada data di tabel yang akan dihapus")
        Else
            If MessageBox.Show("Yakin akan dihapus..?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call kon()
                konek.Open()
                Dim hapus As String = "DELETE FROM paket WHERE kode_paket ='" & txtkodepaket.Text & "'"
                Dim cmddel As MySqlCommand
                cmddel = New MySqlCommand(hapus, konek)
                MsgBox("Data Berhasil di hapus")
                cmddel.ExecuteNonQuery()
                Call TampilGrid()
                Call aturDGV()
                Call Bersih()
            Else
                Call TampilGrid()
                Call aturDGV()
                Call Bersih()
            End If
        End If
    End Sub
End Class