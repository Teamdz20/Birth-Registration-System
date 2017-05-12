Imports MySql.Data.MySqlClient

Public Class Form1
    Dim conn As MySqlConnection
    Dim command As MySqlCommand

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click

        Try
            conn = New MySqlConnection
            conn.ConnectionString =
            "server=localhost;userid=adminBirth;password=birth;database=birth_certificate"
            Dim Reader As MySqlDataReader

            conn.Open()
            Dim query As String
            query = ("Select * from login where username ='" & BunifuMaterialTextbox1.Text & "'AND pwd='" & BunifuMaterialTextbox2.Text & "' ")
            command = New MySqlCommand(query, conn)
            Reader = command.ExecuteReader()
            If Reader.Read Then
                MessageBox.Show("Sucessfully sign-in")
                Hide()
                Birth_Dashboard.BunifuCustomLabel9.Text = BunifuMaterialTextbox1.Text
                Birth_Dashboard.Show()
            Else
                MessageBox.Show("Username or password Invalid")
            End If

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub BunifuMaterialTextbox1_MouseClick(sender As Object, e As MouseEventArgs) Handles BunifuMaterialTextbox1.MouseClick
        BunifuMaterialTextbox1.Text = ""
    End Sub

    Private Sub BunifuMaterialTextbox2_MouseClick(sender As Object, e As MouseEventArgs) Handles BunifuMaterialTextbox2.MouseClick
        BunifuMaterialTextbox2.Text = ""
    End Sub

    Private Sub BunifuCheckbox1_OnChange(sender As Object, e As EventArgs) Handles BunifuCheckbox1.OnChange
        BunifuMaterialTextbox2.isPassword = Not BunifuCheckbox1.Checked

    End Sub
End Class

Friend Class BunifuCustomLabel9
End Class
