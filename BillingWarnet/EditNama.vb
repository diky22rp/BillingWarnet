Imports MySql.Data.MySqlClient

Public Class EditNama


    Private Sub EditNama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call TampilNamaWarnet()
        txtnamawarnet.Text = nama
    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Anda yakin ingin mengganti nama warnet ?", MsgBoxStyle.YesNo)
        If ask = MsgBoxResult.Yes Then
            Call kon()
            konek.Close()
            konek.Open()
            Dim sql As String
            sql = "UPDATE profil SET nama_warnet = '" & txtnamawarnet.Text & "' WHERE id_warnet='1'"
            cd = New MySqlCommand(sql, konek)
            Dim x As Integer = cd.ExecuteNonQuery
            konek.Close()
            Call TampilNamaWarnet()
            Beranda.lblnama.Text = nama
            Me.Close()
        End If
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        Me.Close()
    End Sub
End Class