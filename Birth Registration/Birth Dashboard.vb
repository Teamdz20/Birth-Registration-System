Imports MySql.Data.MySqlClient
Public Class Birth_Dashboard
    Dim conn As MySqlConnection
    Dim command As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim mydataset As DataSet
    Dim query As String
    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        TabControl1.SelectedIndex = 1
        registration.Show()

        If BunifuFlatButton2.selected Then
            BunifuCustomLabel10.Text = "Birth Certificate Registration"
        End If

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        TabControl1.SelectedIndex = 0
        dashboard.Show()

        If BunifuFlatButton1.selected Then
            BunifuCustomLabel10.Text = "Dashboard"
        End If

    End Sub
    Sub hideme()
        BunifuMaterialTextbox1.Hide()
        BunifuFlatButton3.Hide()

    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        TabControl1.SelectedIndex = 2
        update_reg.Show()
        If BunifuFlatButton5.selected Then
            BunifuCustomLabel10.Text = "Update New Records"
        End If
        BunifuMaterialTextbox1.Visible = True
        BunifuFlatButton3.Visible = True

    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        TabControl1.SelectedIndex = 3
        preferences.Show()

        If BunifuFlatButton4.selected Then
            BunifuCustomLabel10.Text = "Preferences"
        End If

        hideme()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub BunifuMetroTextbox12_OnValueChanged(sender As Object, e As EventArgs)
        Enabled = False
    End Sub

    Private Sub BunifuCustomLabel5_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel5.Click

    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Dim counter As Integer = 0

        conn = New MySqlConnection
        conn.ConnectionString =
            "server=localhost; userid=adminBirth; password=birth; database=birth_certificate"
        Try
            conn.Open()
            query = ("INSERT INTO `birth_registration_details`(`first_name`, `middle_name`, `last_name`, `place_of_birth`, `dob`, `r_denomination`, `gender`, `fathers_name`, `nationality_father`, `mothers_name`, `nationality_mother`, `informant_relation`, `date_of_registry`, `registrar_name`, `district`) 
            VALUES ('" & BunifuMetroTextbox1.Text & "','" & BunifuMetroTextbox2.Text & "','" & BunifuMetroTextbox3.Text & "','" & BunifuMetroTextbox4.Text & "','" & MetroDateTime1.Text & "','" & BunifuDropdown2.selectedValue & "','" & BunifuDropdown1.selectedValue & "','" & BunifuMetroTextbox5.Text & "','" & BunifuMetroTextbox6.Text & "','" & BunifuMetroTextbox7.Text & "','" & BunifuMetroTextbox8.Text & "','" & BunifuMetroTextbox9.Text & "','" & MetroDateTime2.Text & "','" & BunifuMetroTextbox10.Text & "','" & BunifuMetroTextbox11.Text & "')")
            command = New MySqlCommand(query, conn)
            If command.ExecuteNonQuery Then
                MessageBox.Show("Successfully Register User")
                BunifuMetroTextbox1.Text = ""
                BunifuMetroTextbox2.Text = ""
                BunifuMetroTextbox3.Text = ""
                BunifuMetroTextbox4.Text = ""
                BunifuMetroTextbox5.Text = ""
                BunifuMetroTextbox6.Text = ""
                BunifuMetroTextbox7.Text = ""
                BunifuMetroTextbox8.Text = ""
                BunifuMetroTextbox9.Text = ""
                BunifuMetroTextbox10.Text = ""
                BunifuMetroTextbox11.Text = ""


                dload()


            End If
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)


        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub BunifuCustomLabel9_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel9.Click


    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Sub dload()
        Dim con As New MySqlConnection
        con.ConnectionString = "server=localhost; userid=root; password=; database= birth_certificate"
        con.Open()
        Dim cmd As New MySqlCommand("select * from birth_registration_details", con)
        Dim adp As New MySqlDataAdapter(cmd)
        Dim a As New DataSet()
        adp.Fill(a, "birth_registration_details")
        BunifuCustomDataGrid1.DataSource = a.Tables("birth_registration_details").DefaultView
        adp.UpdateCommand = New MySqlCommandBuilder(adp).GetUpdateCommand


        con.Close()


    End Sub
    Private Sub Birth_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dload()

    End Sub

    Private Sub MetroTextBox1_Click(sender As Object, e As EventArgs)
        hideme()

    End Sub
    Sub searchme(search As String)

        Dim myadapter As New MySqlDataAdapter(search, conn)
        mydataset = New DataSet
        myadapter.FillSchema(mydataset, SchemaType.Source, "birth_registration_details")
        myadapter.Fill(mydataset, "birth_registration_details")

        If mydataset.Tables("birth_registration_details").Rows.Count > 0 Then
            BunifuCustomDataGrid1.DataSource = mydataset.Tables("birth_registration_details")
            myadapter.UpdateCommand = New MySqlCommandBuilder(myadapter).GetUpdateCommand
        End If

    End Sub
    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim s As String
        Try
            s = "select * from birth_registration_details where first_name like'%" & BunifuMaterialTextbox1.Text & "%'"

            searchme(s)
        Catch

        End Try
    End Sub
End Class