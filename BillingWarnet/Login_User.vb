Imports MySql.Data.MySqlClient
Imports MySql.Data.MySqlClient.MySqlCommand
Imports MySql.Data
Public Class Login_User

    Public username As String
    Public kode As String
    Public total As Integer

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Registrasi_User.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles login.Click

        'LOGIN'
        If txtusername.Text = "" Then
            MsgBox("Username tidak boleh kosong !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Alert")
            txtusername.Focus()

        ElseIf txtpassword.Text = "" Then
            MsgBox("Password tidak boleh kosong !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Alert")
            txtpassword.Focus()
        Else

            'PILIH PC
            'Buka Koneksi 
            Call kon()
            konek.Open()
            cw = New MySqlCommand("SELECT pc_id FROM penyewaan WHERE pc_id= '" & cbpc.SelectedValue & "'", konek)

            rw = cw.ExecuteReader
            rw.Read()

            If rw.HasRows Then
                MsgBox("PC Sudah Di Gunakan!, Silahkan Pilih PC Lain!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Alert")
                cbpc.Focus()
            Else
                'Save ke tabel penyewaan
                konek.Close()
                konek.Open()

                Dim trx As String
                trx = "INSERT INTO penyewaan (pc_id, username_p)" & _
                        "VALUES('" & cbpc.SelectedValue & "','" & txtusername.Text & "')"
                tx = New MySqlCommand(trx, konek)
                Dim y As String = tx.ExecuteNonQuery


                'Buat Perintah SQL
                konek.Close()
                konek.Open()
                cd = New MySqlCommand("SELECT * FROM pelanggan WHERE username_p='" &
                                       txtusername.Text & "' and password_p='" &
                                       txtpassword.Text & "'", konek)
                rd = cd.ExecuteReader
                'Visual Studio membaca keberadaan data di Database
                rd.Read()
                username = txtusername.Text
                If rd.HasRows Then
                    MsgBox("Login Berhasil", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "WELCOME!")
                    txtusername.Text = ""
                    txtpassword.Text = ""
                    usertimer.Show()
                    Me.Hide()
                Else
                    MsgBox("Login Gagal! ", MsgBoxStyle.Exclamation, "ERROR!")
                    txtusername.Text = ""
                    txtpassword.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Login_User_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call PanjangData()

        'Buka Koneksi 
        Call kon()
        konek.Open()

        Dim adapter As New MySqlDataAdapter("SELECT * FROM pc", konek)
        Dim table As New DataTable()

        adapter.Fill(table)

        cbpc.DataSource = table
        cbpc.ValueMember = "pc_id"
        cbpc.DisplayMember = "pc_id"
    End Sub
    Private Sub PanjangData()
        txtusername.MaxLength = 25
        txtpassword.MaxLength = 25
    End Sub
End Class