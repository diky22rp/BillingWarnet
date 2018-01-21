Imports MySql.Data.MySqlClient

Public Class Laporan
    Public total As Integer
    Public ttran As Integer
    Public tluhnas As Integer

    Private Sub Laporan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilGrid()
        aturDGV()
        Call lihattotal()
        lblpend.Text = total
        Call lihattran()
        lbltran.Text = ttran
        Call tlunas()
        lbllunas.Text = tluhnas
    End Sub
    Sub TampilGrid()
        Call kon()
        da = New MySqlDataAdapter("SELECT * FROM laporan", konek)
        ds = New DataSet
        da.Fill(ds, "laporan")
        dglaporan.DataSource = ds.Tables("laporan")
        dglaporan.ReadOnly = True
    End Sub
    Sub aturDGV()
        Try
            dglaporan.Columns(0).Width = 68
            dglaporan.Columns(1).Width = 70
            dglaporan.Columns(2).Width = 65
            dglaporan.Columns(3).Width = 80
            dglaporan.Columns(4).Width = 80
            dglaporan.Columns(5).Width = 95
            dglaporan.Columns(0).HeaderText = "ID LAPORAN"
            dglaporan.Columns(1).HeaderText = "ID TRANSAKSI"
            dglaporan.Columns(2).HeaderText = "TOTAL BAYAR"
            dglaporan.Columns(3).HeaderText = "PELANGGAN BAYAR"
            dglaporan.Columns(4).HeaderText = "KEMBALIAN BAYAR"
            dglaporan.Columns(5).HeaderText = "TANGGAL"
        Catch ex As Exception
        End Try
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
    Sub lihattran()
        Call kon()
        konek.Open()

        Dim tsql As String = ""
        tsql = "SELECT count(*) as total from transaksi"
        Dim ocd As MySqlCommand = New MySqlCommand(tsql, konek)
        Dim ord As MySqlDataReader = ocd.ExecuteReader

        'membaca data di database
        If ord.Read Then
            ttran = ord.Item("total")
        End If
    End Sub
    Sub tlunas()
        Call kon()
        konek.Open()

        Dim lsql As String = ""
        lsql = "SELECT count(*) as total from laporan"
        Dim lcd As MySqlCommand = New MySqlCommand(lsql, konek)
        Dim lrd As MySqlDataReader = lcd.ExecuteReader

        'membaca data di database
        If lrd.Read Then
            tluhnas = lrd.Item("total")
        End If
    End Sub
    Private Sub dglaporan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dglaporan.CellContentClick

    End Sub
End Class