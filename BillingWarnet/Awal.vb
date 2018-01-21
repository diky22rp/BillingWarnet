Public Class Awal

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call TampilNamaWarnet()
        Login.lblnama.Text = nama
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Login_User.Show()
    End Sub


    Private Sub Awal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call TampilNamaWarnet()
        lblnama.Text = nama
    End Sub
End Class