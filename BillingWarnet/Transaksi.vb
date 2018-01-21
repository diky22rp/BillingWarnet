Imports MySql.Data.MySqlClient

Public Class Transaksi
    Public waktu As String
    Private Sub Transaksi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilGrid()
        aturDGV()
        btnbayar.Enabled = False
        Bersih()
        If cbstatus.SelectedItem = "Belum Lunas" Then
            btnbayar.Enabled = True
        Else
            btnbayar.Enabled = False
        End If
    End Sub
    Sub TampilGrid()
        Call kon()
        da = New MySqlDataAdapter("SELECT * FROM transaksi", konek)
        ds = New DataSet
        da.Fill(ds, "transaksi")
        dgtrpem.DataSource = ds.Tables("transaksi")
        dgtrpem.ReadOnly = True
    End Sub
    Sub aturDGV()
        Try
            dgtrpem.Columns(0).Width = 100
            dgtrpem.Columns(1).Width = 80
            dgtrpem.Columns(2).Width = 80
            dgtrpem.Columns(3).Width = 100
            dgtrpem.Columns(4).Width = 110
            dgtrpem.Columns(0).HeaderText = "ID TRANSAKSI"
            dgtrpem.Columns(1).HeaderText = "USERNAME"
            dgtrpem.Columns(2).HeaderText = "KODE PAKET"
            dgtrpem.Columns(3).HeaderText = "TOTAL BAYAR"
            dgtrpem.Columns(4).HeaderText = "STATUS TRANSAKSI"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnlihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlihat.Click
        TampilGrid()
        aturDGV()
        Bersih()
        btnbayar.Enabled = False
    End Sub

    Private Sub dgtrpem_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgtrpem.CellMouseDoubleClick
        txtid.Text = dgtrpem.Rows(e.RowIndex).Cells(0).Value.ToString
        txtusername.Text = dgtrpem.Rows(e.RowIndex).Cells(1).Value.ToString
        txtkodepaket.Text = dgtrpem.Rows(e.RowIndex).Cells(2).Value.ToString
        txttotal.Text = dgtrpem.Rows(e.RowIndex).Cells(3).Value.ToString
        cbstatus.SelectedItem = dgtrpem.Rows(e.RowIndex).Cells(4).Value.ToString

        txtid.Text = dgtrpem.Rows(e.RowIndex).Cells(0).Value.ToString
        txtusername.Text = dgtrpem.Rows(e.RowIndex).Cells(1).Value.ToString
        txtkodepaket.Text = dgtrpem.Rows(e.RowIndex).Cells(2).Value.ToString
        txttotal.Text = dgtrpem.Rows(e.RowIndex).Cells(3).Value.ToString
        cbstatus.SelectedItem = dgtrpem.Rows(e.RowIndex).Cells(4).Value.ToString

        If cbstatus.SelectedItem = "Belum Lunas" Then
            btnbayar.Enabled = True
        Else
            btnbayar.Enabled = False
        End If

    End Sub

    Sub Bersih()
        txtid.Text = ""
        txtkodepaket.Text = ""
        txttotal.Text = ""
        txtusername.Text = ""
        cbstatus.SelectedItem = ""
    End Sub

    Private Sub btnbayar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbayar.Click
        JLaporan.ShowDialog()
        btnbayar.Enabled = False
    End Sub

    Private Sub txttotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttotal.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txttotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttotal.TextChanged

    End Sub
End Class