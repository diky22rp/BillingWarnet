Public Class Form1

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Anda yakin ingin keluar ?", MsgBoxStyle.YesNo)
        If ask = MsgBoxResult.Yes Then
            Awal.Show()
            Me.Hide()
            Call TampilNamaWarnet()
            Awal.lblnama.Text = nama
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Buka Koneksi 
        Call kon()
        konek.Close()
        konek.Open()

        utama.Controls.Clear()
        Beranda.TopLevel = False
        utama.Controls.Add(Beranda)
        Beranda.Show()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles utama.Paint

    End Sub

    Private Sub btnhome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhome.Click
        utama.Controls.Clear()
        Beranda.TopLevel = False
        utama.Controls.Add(Beranda)
        Beranda.Show()
    End Sub

    Private Sub btnonline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnonline.Click
        POnline.TampilGrid()
        POnline.aturDGV()

        'Buka Koneksi 
        Call kon()
        konek.Close()
        konek.Open()

        utama.Controls.Clear()
        POnline.TopLevel = False
        utama.Controls.Add(POnline)
        POnline.Show()
    End Sub

    Private Sub btnpelanggan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpelanggan.Click
        Pelanggan.TampilGrid()
        Pelanggan.aturDGV()
        'Buka Koneksi 
        Call kon()
        konek.Close()
        konek.Open()

        utama.Controls.Clear()
        Pelanggan.TopLevel = False
        utama.Controls.Add(Pelanggan)
        Pelanggan.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadmin.Click
        Admin.TampilGrid()
        Admin.aturDGV()

        'Buka Koneksi 
        Call kon()
        konek.Close()
        konek.Open()

        utama.Controls.Clear()
        Admin.TopLevel = False
        utama.Controls.Add(Admin)
        Admin.Show()
    End Sub

    Private Sub btntransaksi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntransaksi.Click
        Transaksi.TampilGrid()
        Transaksi.aturDGV()
        'Buka Koneksi 
        Call kon()
        konek.Close()
        konek.Open()

        utama.Controls.Clear()
        Transaksi.TopLevel = False
        utama.Controls.Add(Transaksi)
        Transaksi.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Laporan.TampilGrid()
        Laporan.aturDGV()
        'Buka Koneksi 
        Call kon()
        konek.Close()
        konek.Open()

        utama.Controls.Clear()
        Laporan.TopLevel = False
        utama.Controls.Add(Laporan)
        Laporan.Show()
    End Sub

    Private Sub btnpaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpaket.Click
        Paket.TampilGrid()
        Paket.aturDGV()
        'Buka Koneksi 
        Call kon()
        konek.Close()
        konek.Open()

        utama.Controls.Clear()
        Paket.TopLevel = False
        utama.Controls.Add(Paket)
        Paket.Show()
    End Sub


    Private Sub btnabout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnabout.Click
        About.ShowDialog()
    End Sub
End Class
