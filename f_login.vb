Public Class f_login

    Private Sub f_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbox1_gender()
        cbox2_usertype()
        Timer1.Start()
        TextBox2.UseSystemPasswordChar = True
        TextBox9.UseSystemPasswordChar = True
        TextBox10.UseSystemPasswordChar = True
        opencon()
    End Sub

    Sub cbox1_gender()
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("[ SELECT ]")
        ComboBox1.Items.Add("MALE")
        ComboBox1.Items.Add("FEMALE")
        ComboBox1.Text = "[ SELECT ]"
    End Sub


    Sub cbox2_usertype()
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("[ SELECT ]")
        ComboBox2.Items.Add("ADMIN")
        ComboBox2.Items.Add("MANAGER")
        ComboBox2.Items.Add("STAFF")
        ComboBox2.Items.Add("CASHIER")
        ComboBox2.Items.Add("USERS")
        ComboBox2.Text = "[ SELECT ]"
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        If ComboBox1.Text = "[ SELECT ]" Or ComboBox1.Text = "MALE" Or ComboBox1.Text = "FEMALE" Then

        Else
            ComboBox1.Text = "[ SELECT ]"
        End If
    End Sub

    Private Sub ComboBox2_TextChanged(sender As Object, e As EventArgs) Handles ComboBox2.TextChanged
        If ComboBox2.Text = "[ SELECT ]" Or ComboBox2.Text = "ADMIN" Or ComboBox2.Text = "MANAGER" Or ComboBox2.Text = "STAFF" Or ComboBox2.Text = "CASHIER" Or ComboBox2.Text = "USERS" Then

        Else
            ComboBox2.Text = "[ SELECT ]"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox10.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "[ SELECT ]" Or ComboBox2.Text = "[ SELECT ]" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Then
            MsgBox("Please enter required information. Thank you!", vbExclamation, "Missing Details")
            TextBox9.Clear()
            TextBox10.Clear()
        ElseIf Not TextBox10.Text = TextBox9.Text Then
            MsgBox("Please enter correct password confirmation. Make sure both password and password confirmation are match.", vbCritical, "Password Mismatch")
            TextBox9.Clear()
            TextBox10.Clear()
        ElseIf Label21.Text = TextBox8.Text Then
            MsgBox("The username you entered is already taken. Please make a new and unique one.", vbExclamation, "Username Existed")
            TextBox8.Clear()
            TextBox9.Clear()
            TextBox10.Clear()
        Else
            insert_into_tb_users_new()
            MsgBox("Please wait for admin to tell you if your account was confirmed and allowed to use in the system. Thank you!", vbExclamation, "Wait To Be Confirmed")
            textclear()
        End If
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.BackColor = Color.DarkRed
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.Black
    End Sub

    Private Sub Button5_MouseEnter(sender As Object, e As EventArgs) Handles Button5.MouseEnter
        Button5.BackColor = Color.DarkRed
    End Sub

    Private Sub Button5_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Button5.BackColor = Color.Black
    End Sub

    Private Sub Button6_MouseEnter(sender As Object, e As EventArgs) Handles Button6.MouseEnter
        Button6.BackColor = Color.DarkRed
    End Sub

    Private Sub Button6_MouseLeave(sender As Object, e As EventArgs) Handles Button6.MouseLeave
        Button6.BackColor = Color.Black
    End Sub

    Private Sub Button7_MouseEnter(sender As Object, e As EventArgs) Handles Button7.MouseEnter
        Button7.BackColor = Color.DarkRed
    End Sub

    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles Button7.MouseLeave
        Button7.BackColor = Color.Black
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Label17.Text = "NOT CONFIRMED" Then
            MsgBox("Please ask the admin to confirm your account first. Thank you!", vbCritical, "Invalid Action")
            TextBox1.Clear()
            TextBox2.Clear()
        ElseIf TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Please enter username/password.", vbExclamation, "Missing Username/Password")
            TextBox2.Clear()
        ElseIf TextBox1.Text = Label6.Text And TextBox2.Text = Label5.Text Then
            MsgBox("You are now logged on.", vbInformation, "Logged On")
            textclear()
            Me.Hide()
            Form1.Show()
        Else
            MsgBox("Please enter correct username/password or maybe username is not existed anymore. Thank you.", vbCritical, "Invalid Action")
            TextBox2.Clear()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox9.UseSystemPasswordChar = False
        TextBox10.UseSystemPasswordChar = False
    End Sub

    Private Sub Button3_MouseEnter(sender As Object, e As EventArgs) Handles Button3.MouseEnter
        Button3.BackColor = Color.DarkRed
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        TextBox9.UseSystemPasswordChar = True
        TextBox10.UseSystemPasswordChar = True
        Button3.BackColor = Color.Black
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.UseSystemPasswordChar = False
    End Sub

    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
        Button2.BackColor = Color.DarkRed
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        TextBox2.UseSystemPasswordChar = True
        Button2.BackColor = Color.Black
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MsgBox("You are now about to exit this system. Thanks for using out services.", vbInformation, "TQM Queuing System Exiting")
        End
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label20.Text = Today
        Label19.Text = TimeOfDay
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        TextBox8.CharacterCasing = CharacterCasing.Lower
        find_existed_user()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.CharacterCasing = CharacterCasing.Lower
        find_existed_user()
    End Sub

    Sub textclear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        ComboBox1.Text = "[ SELECT ]"
        ComboBox2.Text = "[ SELECT ]"

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsLetter(e.KeyChar) Or e.KeyChar = "-" Or e.KeyChar = " " Or e.KeyChar = "." Or e.KeyChar = "," Or e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        TextBox5.MaxLength = 11
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        TextBox9.CharacterCasing = CharacterCasing.Lower
    End Sub

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox10.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        TextBox10.CharacterCasing = CharacterCasing.Lower
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.CharacterCasing = CharacterCasing.Lower
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or e.KeyChar = "-" Or e.KeyChar = " " Or e.KeyChar = "." Or e.KeyChar = "," Or e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or e.KeyChar = "-" Or e.KeyChar = "@" Or e.KeyChar = "." Or e.KeyChar = "," Or e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or e.KeyChar = "-" Or e.KeyChar = " " Or e.KeyChar = "." Or e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

   
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub
End Class