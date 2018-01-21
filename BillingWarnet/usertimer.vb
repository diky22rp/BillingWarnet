Option Explicit On
Imports MySql.Data.MySqlClient
Imports MySql.Data.MySqlClient.MySqlCommand
Imports MySql.Data
Public Class usertimer
    Dim lSeconds As Long
    Dim JW
    Public waktu As Integer
    Public username As String
    Public kode As String
    Public total As Integer
    Public pc As String
    Private Sub usertimer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        stpw.Start()
        lblpc.Text = Login_User.cbpc.SelectedValue
        txtusername.Text = Login_User.username
        StartCountDown()
        Timer1.Interval = 500
        Timer1.Start()
        Label2.Text = "Hallo,"

    End Sub

    Dim stpw As New Stopwatch
    Dim CountDown As New TimeSpan
    Private Sub StartCountDown()
        username = Login_User.username
        'Buka Koneksi 
        Call kon()

        konek.Open()

        cw = New MySqlCommand("SELECT pelanggan.durasi FROM pelanggan INNER JOIN paket ON paket.kode_paket=pelanggan.kode_paket WHERE pelanggan.username_p = '" &
                               username & "'", konek)

        rw = cw.ExecuteReader
        rw.Read()

        If rw.HasRows Then

            waktu = rw.Item("durasi")

            If String.IsNullOrEmpty(waktu) Then
                Dim CountDownFrom As Integer = 1 * 60 'as seconds
                CountDown = TimeSpan.FromSeconds(CountDownFrom)
                stpw.Stop() : stpw.Reset() : stpw.Start()
            Else
                Dim CountDownFrom As Integer = waktu 'as seconds
                CountDown = TimeSpan.FromSeconds(CountDownFrom)
                stpw.Stop() : stpw.Reset() : stpw.Start()
            End If
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not stpw.IsRunning Then Exit Sub
        Dim TimeRemaining As TimeSpan = CountDown - stpw.Elapsed
        Label1.Text = TimeRemaining.Hours.ToString.PadLeft(2, "0"c) & ":" & _
                        TimeRemaining.Minutes.ToString.PadLeft(2, "0"c) & ":" & _
                        TimeRemaining.Seconds.ToString.PadLeft(2, "0"c)
        'Save ke database
        'tutup dan buka koneksi
        konek.Close()
        konek.Open()
        Dim sql As String
        sql = "UPDATE pelanggan SET durasi = '" & TimeRemaining.TotalSeconds & "' WHERE username_p='" & username & "'"
        cd = New MySqlCommand(sql, konek)
        Dim x As Integer = cd.ExecuteNonQuery


        If TimeRemaining.TotalMilliseconds <= 0 Then
            stpw.Stop()
            MsgBox("Waktu Anda Sudah Habis, Silahkan Lakukan Pembayaran Pada Operator!", MsgBoxStyle.OkOnly)
            txtusername.Text = ""
            'jika waktu habis , user akan didelete
            Dim del As String
            del = "DELETE FROM pelanggan WHERE username_p='" & username & "'"
            cd = New MySqlCommand(del, konek)
            Dim d As Integer = cd.ExecuteNonQuery

            'jika waktu habis , penyewaan akan didelete
            Dim delp As String
            delp = "DELETE FROM penyewaan WHERE username_p='" & username & "'"
            Dim cdp As MySqlCommand
            cdp = New MySqlCommand(delp, konek)
            Dim p As Integer = cd.ExecuteNonQuery
            Me.Hide()
            Login_User.Show()
            StartCountDown()
            konek.Close()
        End If
    End Sub

    Private Sub btnselsai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnselsai.Click
        Call kon()
        konek.Open()
        Dim hapus As String = "DELETE FROM penyewaan WHERE username_p='" & username & "'"
        Dim cmddel As MySqlCommand
        cmddel = New MySqlCommand(hapus, konek)
        cmddel.ExecuteNonQuery()
        Application.Restart()
    End Sub
End Class