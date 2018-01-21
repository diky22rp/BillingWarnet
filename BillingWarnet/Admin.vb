Imports MySql.Data.MySqlClient

Public Class Admin

    Private Sub txtpassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpassword.TextChanged

    End Sub
    Sub TampilGrid()
        Call kon()
        da = New MySqlDataAdapter("SELECT * FROM admin", konek)
        ds = New DataSet
        da.Fill(ds, "admin")
        dgadmin.DataSource = ds.Tables("admin")
        dgadmin.ReadOnly = True
    End Sub
    Sub aturDGV()
        Try
            dgadmin.Columns(0).Width = 100
            dgadmin.Columns(1).Width = 100
            dgadmin.Columns(2).Width = 130
            dgadmin.Columns(3).Width = 145
            dgadmin.Columns(0).HeaderText = "USERNAME"
            dgadmin.Columns(1).HeaderText = "PASSWORD"
            dgadmin.Columns(2).HeaderText = "NAMA LENGKAP"
            dgadmin.Columns(3).HeaderText = "TANGGAL REGISTRASI"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilGrid()
        aturDGV()
    End Sub

    Private Sub btnlihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlihat.Click
        TampilGrid()
        aturDGV()
        Call Bersih()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'validasi data
        If MsgBox("Apakah anda yakin akan registrasi?",
                  MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim strTemp As String = ""
            Dim strValue As String = ""

            konek.Close()
            konek.Open()
            'cek user ada ga
            Dim sqlStr As String = "SELECT COUNT(*) FROM admin WHERE username = ?uname"
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
            ElseIf txtnamalengkap.Text = "" Then
                MessageBox.Show("Silahkan isi nama lengkap anda")
                txtnamalengkap.Focus()
                Exit Sub
            ElseIf rowCount <> 0 Then
                MessageBox.Show("Mohon Maaf, Username sudah dipakai, gunakan username lain!")
                txtusername.Text = ""
                txtusername.Focus()
                Exit Sub
            Else
                Dim sqlrs As String
                Dim regDate As DateTime = DateTime.Now
                Dim strDate As String = regDate.ToString("yyyy-MM-dd HH:mm:ss")
                'Save ke database
                sqlrs = "INSERT INTO admin (username ,password, nama_lengkap, last_login)" & _
                        "VALUES('" & txtusername.Text & "','" & txtpassword.Text & "','" & txtnamalengkap.Text & "','" & strDate & "')"
                cd = New MySqlCommand(sqlrs, konek)
                Dim x As Integer = cd.ExecuteNonQuery
                If x = 1 Then
                    MessageBox.Show("Registrasi berhasil!")
                    TampilGrid()
                    aturDGV()
                Else
                    MessageBox.Show("Registrasi Gagal!")
                End If
            End If
        End If
    End Sub

    Private Sub dgadmin_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgadmin.CellMouseDoubleClick
        txtusername.Text = dgadmin.Rows(e.RowIndex).Cells(0).Value.ToString
        txtpassword.Text = dgadmin.Rows(e.RowIndex).Cells(1).Value.ToString
        txtnamalengkap.Text = dgadmin.Rows(e.RowIndex).Cells(2).Value.ToString

        txtusername.Text = dgadmin.Rows(e.RowIndex).Cells(0).Value.ToString
        txtpassword.Text = dgadmin.Rows(e.RowIndex).Cells(1).Value.ToString
        txtnamalengkap.Text = dgadmin.Rows(e.RowIndex).Cells(2).Value.ToString
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
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
            ElseIf txtnamalengkap.Text = "" Then
                MessageBox.Show("Silahkan isi nama lengkap anda")
                txtnamalengkap.Focus()
                Exit Sub
            Else
                Call kon()
                konek.Open()

                Dim edit As String = "UPDATE admin SET username='" & txtusername.Text & "',password='" & txtpassword.Text & "',nama_lengkap='" & txtnamalengkap.Text & "' where username='" & txtusername.Text & "'"
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

    Private Sub Bersih()
        txtusername.Text = ""
        txtpassword.Text = ""
        txtnamalengkap.Text = ""
        txtusername.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtusername.Text = "" Then
            MsgBox("Silahkan Pilih Data yang akan di hapus dengan Masukan username dan ENTER")
        Else
            If MessageBox.Show("Yakin akan dihapus..?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call kon()
                konek.Open()
                Dim hapus As String = "DELETE FROM admin WHERE username ='" & txtusername.Text & "'"
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