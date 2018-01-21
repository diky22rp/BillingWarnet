Imports MySql.Data.MySqlClient
Imports MySql.Data.MySqlClient.MySqlCommand
Imports MySql.Data
Public Class Login

    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'LOGIN'
        If txtusername.Text = "" Then
            MsgBox("Username tidak boleh kosong !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Alert")
            txtusername.Focus()

        ElseIf TextBox2.Text = "" Then
            MsgBox("Password tidak boleh kosong !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Alert")
            TextBox2.Focus()
        End If


        'Buka Koneksi 
        Call kon()

        konek.Open()

        'Buat Perintah SQL
        cd = New MySqlCommand("SELECT * FROM admin WHERE username='" &
                               txtusername.Text & "' and password='" &
                               TextBox2.Text & "'", konek)
        rd = cd.ExecuteReader
        'Visual Studio membaca keberadaan data di Database
        rd.Read()
        If rd.HasRows Then
            MsgBox("Login Berhasil", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "WELCOME!")
            Form1.Show()
            txtusername.Text = ""
            TextBox2.Text = ""
            Me.Hide()
        Else
            MsgBox("Login Gagal! ", MsgBoxStyle.Exclamation, "ERROR!")
            txtusername.Text = ""
            TextBox2.Text = ""
        End If

    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call TampilNamaWarnet()
        lblnama.Text = nama
    End Sub

    Private Sub btnkembali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkembali.Click
        Me.Hide()
        Awal.Show()
    End Sub
End Class