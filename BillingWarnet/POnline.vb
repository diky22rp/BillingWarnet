Imports MySql.Data.MySqlClient

Public Class POnline

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub POnline_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilGrid()
        aturDGV()
    End Sub

    Sub TampilGrid()
        Call kon()
        da = New MySqlDataAdapter("SELECT penyewaan.pc_id, penyewaan.username_p, pelanggan.kode_paket, pelanggan.durasi FROM penyewaan INNER JOIN pelanggan ON penyewaan.username_p = pelanggan.username_p", konek)
        ds = New DataSet
        da.Fill(ds, "penyewaan")
        DataGridView1.DataSource = ds.Tables("penyewaan")
        DataGridView1.ReadOnly = True
    End Sub
    Sub aturDGV()
        Try
            DataGridView1.Columns(0).Width = 100
            DataGridView1.Columns(1).Width = 125
            DataGridView1.Columns(2).Width = 125
            DataGridView1.Columns(3).Width = 125
            DataGridView1.Columns(0).HeaderText = "PC ID"
            DataGridView1.Columns(1).HeaderText = "USERNAME"
            DataGridView1.Columns(2).HeaderText = "KODE PAKET"
            DataGridView1.Columns(3).HeaderText = "DURASI TERSISA (DETIK)"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub btnlihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlihat.Click
        TampilGrid()
        aturDGV()
    End Sub
End Class