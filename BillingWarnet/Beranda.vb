Imports MySql.Data.MySqlClient

Public Class Beranda
    Public total As Integer
    Public online As Integer
   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        EditNama.ShowDialog()
    End Sub

    Private Sub Beranda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilNamaWarnet()
        Call TampilNamaWarnet()
        lblnama.Text = nama
        lblusername.Text = Login.txtusername.Text
        lihattotal()
        lblpemasukanisi.Text = total
        lblsoisi.Text = online
    End Sub

    Private Sub btnlihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlihat.Click
        TampilNamaWarnet()
        Call TampilNamaWarnet()
        lblnama.Text = nama
        lihattotal()
        lblpemasukanisi.Text = total
        lblsoisi.Text = online
    End Sub


    Sub lihattotal()
        Call kon()
        konek.Open()

        Dim tsql As String = ""
        tsql = "SELECT sum(total_bayar) AS total  FROM laporan"
        cd = New MySqlCommand(tsql, konek)
        rd = cd.ExecuteReader

        'membaca data di database
        If rd.Read Then
            total = rd.Item("total")
        End If

    End Sub


    Sub lihatonline()
        Call kon()
        konek.Open()

        Dim tsql As String = ""
        tsql = "SELECT count(*) as total from penyewaan"
        Dim ocd As MySqlCommand = New MySqlCommand(tsql, konek)
        Dim ord As MySqlDataReader = ocd.ExecuteReader

        'membaca data di database
        If ord.Read Then
            online = ord.Item("total")
        End If
    End Sub


    Private Sub lblusername_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblusername.Click

    End Sub

    Private Sub lblsoisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblsoisi.Click

    End Sub
End Class
