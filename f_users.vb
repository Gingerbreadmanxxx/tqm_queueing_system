Public Class f_users

    Private Sub f_users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lv1_pendings()
        cbox1_usertype()
        Button5.Enabled = False
        Button5.BackColor = Color.Silver
        opencon()
        reload_users_NOTCONFIRMED()
        reload_users_CONFIRMED()
        reload_users()
    End Sub

    Sub cbox1_usertype()
        ' ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("[ SELECT ]")
        ComboBox1.Items.Add("ADMIN")
        ComboBox1.Items.Add("MANAGER")
        ComboBox1.Items.Add("STAFF")
        ComboBox1.Items.Add("CASHIER")
        ComboBox1.Items.Add("USERS")
        ComboBox1.Text = "[ SELECT ]"
    End Sub

    Sub lv1_pendings()
        ListView1.Items.Clear()
        ListView1.BackColor = Color.Black
        ListView1.View = View.Details
        ListView1.GridLines = False
        ListView1.FullRowSelect = True
        ListView1.Columns.Clear()
        ListView1.Columns.Add("#", 0)
        ListView1.Columns.Add("Fullname", 200)
        ListView1.Columns.Add("Address", 200)
        ListView1.Columns.Add("Sex", 100)
        ListView1.Columns.Add("Contact No.", 100)
        ListView1.Columns.Add("Email Address", 150)
        ListView1.Columns.Add("Designation", 120)
        ListView1.Columns.Add("UserType", 100)
        ListView1.Columns.Add("Username", 100)
        ListView1.Columns.Add("Password", 0)
        ListView1.Columns.Add("Date Reg.", 100)
        ListView1.Columns.Add("Status", 100)
        ListView1.Columns.Add("Confirmed By", 200)
        ListView1.Columns.Add(" ", 40)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        reload_tb_tickets()
        reload_tb_lightvehicle_tickets()
        reload_tb_lto_tickets()
        reload_tb_motorcyle_tickets()
        reload_users()
        reload_users_CONFIRMED()
        reload_users_NOTCONFIRMED()
        Form1.IsMdiContainer = False
        For Each ChildForm As Form In Form1.MdiChildren
            ChildForm.Close()
        Next
        Form1.GroupBox1.Visible = True
    End Sub

    Private Sub Button6_MouseEnter(sender As Object, e As EventArgs) Handles Button6.MouseEnter
        Button6.BackColor = Color.DarkRed
    End Sub

    Private Sub Button6_MouseLeave(sender As Object, e As EventArgs) Handles Button6.MouseLeave
        Button6.BackColor = Color.Black
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        Button5.Enabled = True
        Button5.BackColor = Color.Black
        select_to_confirm()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If Label13.Text = Form1.ToolStripStatusLabel4.Text Then
            MsgBox("Sorry! You are not allowed to deleted your own and logged on account.", vbCritical, "Invalid Action")
        Else
            Dim ask As MsgBoxResult = MsgBox("Are you sure that you want to delete that account?", vbYesNo, "Asking To Delete")
            If ask = MsgBoxResult.Yes Then
                delete_an_accounts()
                MsgBox("An account is now deleted.", vbInformation, "Deleted Successfully")
            Else
                MsgBox("Deleting an account is now cancelled.", vbInformation, "Cancelled Successfully")
            End If
            reload_users()
            Button5.Enabled = False
            Button5.BackColor = Color.Silver
        End If
    End Sub

    Private Sub ListView1_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles ListView1.DrawColumnHeader
        e.DrawDefault = True
    End Sub

    Private Sub ListView1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListView1.DrawItem
        If e.Item.Selected = False Then
            e.DrawDefault = True
        End If
    End Sub

    Private Sub ListView1_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles ListView1.DrawSubItem
        If e.Item.Selected = True Then
            e.Graphics.FillRectangle(New SolidBrush(Color.DarkRed), e.Bounds)
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, New Font(Me.Font, Nothing), New Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.White)
        Else
            e.DrawDefault = True
        End If
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        If ComboBox1.Text = "[ SELECT ]" Or ComboBox1.Text = "ADMIN" Or ComboBox1.Text = "MANAGER" Or ComboBox1.Text = "STAFF" Or ComboBox1.Text = "CASHIER" Or ComboBox1.Text = "USERS" Then
            search_usertype()
        Else
            ComboBox1.Text = "[ SELECT ]"
            reload_users()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        search_users()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        search_datereg()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Label9.Text = "CONFIRMED" Then
            MsgBox("Sorry! This account was already CONFIRMED.", vbCritical, "Invalid Action")
            Label9.Text = "CONFIRM"
        Else
            Dim ask As MsgBoxResult = MsgBox("Are you sure that you want to confirm that account?", vbYesNo, "Asking To Confirm")
            If ask = MsgBoxResult.Yes Then
                update_to_confirm()
                MsgBox("A new account confirmed. Please inform the user that his/her account is now allowed to use in the system. Thank You!", vbInformation, "Account Confirmed")
            Else
                MsgBox("A new account confirmation is now cancelled.", vbInformation, "Cancelled Successfully")
            End If
        End If
        reload_users()
        Button5.Enabled = False
        Button5.BackColor = Color.Silver
    End Sub


    Private Sub Button5_MouseEnter(sender As Object, e As EventArgs) Handles Button5.MouseEnter
        Button5.BackColor = Color.DarkRed
    End Sub

    Private Sub Button5_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Button5.BackColor = Color.Black
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class