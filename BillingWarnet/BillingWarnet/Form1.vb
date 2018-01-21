Public Class Form1

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Anda yakin ingin keluar ?", MsgBoxStyle.YesNo)
        If ask = MsgBoxResult.Yes Then
            Login.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Login.Hide()
    End Sub
End Class
