Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControlBox = False
        Timer1.Start()
        opencon()
        'alter_tb_lightvehicle_tickets()
        'alter_tb_lto_tickets()
        'alter_tb_motorcycle_tickets()
        'alter_tb_tickets()
        'create_db_tqm_queing()
        ' create_tb_tickets()
        ' create_tb_processed_tickets()
        ' create_tb_users()
        ' create_tb_lto_tickets()
        ' create_tb_motorcycle_tickets()
        ' create_tb_lightvehicle_tickets()
        reload_tb_tickets()
        '  reload_tb_processed_tickets()
        reload_users()
        reload_users_CONFIRMED()
        reload_users_NOTCONFIRMED()
        Try
            'insert_into_tb_users()
            'insert_into_tb_users2()
            ' insert_into_tb_users3()
            'insert_into_tb_users4()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ToolStripStatusLabel2.Text = "ADMIN" Then
            IsMdiContainer = True
            For Each ChildForm As Form In Me.MdiChildren
                ChildForm.Close()
            Next
            GroupBox1.Visible = False
            f_users.MdiParent = Me
            f_users.Show()
        Else
            MsgBox("Sorry! Please ask permission the admin first", vbExclamation, "Invalid Action")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '   Me.Hide()
        f_queing.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        reload_tb_tickets()
        'reload_tb_processed_tickets()
        reload_tb_lightvehicle_tickets()
        reload_tb_lto_tickets()
        reload_tb_motorcyle_tickets()
        reload_users()
        reload_users_CONFIRMED()
        reload_users_NOTCONFIRMED()
        IsMdiContainer = True
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
        GroupBox1.Visible = False
        f_cashier.MdiParent = Me
        f_cashier.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        f_ticketing.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox1.Visible = True
        IsMdiContainer = False
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

 

    Private Sub Button4_MouseEnter(sender As Object, e As EventArgs) Handles Button4.MouseEnter
        Button4.BackColor = Color.DarkRed
    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.BackColor = Color.Black
    End Sub

    Private Sub Button3_MouseEnter(sender As Object, e As EventArgs) Handles Button3.MouseEnter
        Button3.BackColor = Color.DarkRed
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackColor = Color.Black
    End Sub

    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
        Button2.BackColor = Color.DarkRed
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.Black
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.BackColor = Color.DarkRed
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.Black
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        End
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        WindowState = FormWindowState.Minimized
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

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        IsMdiContainer = False
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
        GroupBox1.Visible = True
        Me.Close()
        f_login.Show()
    End Sub

    Private Sub Button8_MouseEnter(sender As Object, e As EventArgs) Handles Button8.MouseEnter
        Button8.BackColor = Color.DarkRed
    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles Button8.MouseLeave
        Button8.BackColor = Color.Black
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel7.Text = Today
        ToolStripStatusLabel8.Text = TimeOfDay
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click

    End Sub

    Private Sub Button9_MouseEnter(sender As Object, e As EventArgs) Handles Button9.MouseEnter
        Button9.BackColor = Color.DarkRed
    End Sub

    Private Sub Button9_MouseLeave(sender As Object, e As EventArgs) Handles Button9.MouseLeave
        Button9.BackColor = Color.Black
    End Sub

    Private Sub Button10_MouseEnter(sender As Object, e As EventArgs) Handles Button10.MouseEnter
        Button10.BackColor = Color.DarkRed
    End Sub

    Private Sub Button10_MouseLeave(sender As Object, e As EventArgs) Handles Button10.MouseLeave
        Button10.BackColor = Color.Black
    End Sub

    Private Sub Button11_MouseEnter(sender As Object, e As EventArgs) Handles Button11.MouseEnter
        Button11.BackColor = Color.DarkRed
    End Sub

    Private Sub Button11_MouseLeave(sender As Object, e As EventArgs) Handles Button11.MouseLeave
        Button11.BackColor = Color.Black
    End Sub

    Private Sub Button12_MouseEnter(sender As Object, e As EventArgs) Handles Button12.MouseEnter
        Button12.BackColor = Color.DarkRed
    End Sub

    Private Sub Button12_MouseLeave(sender As Object, e As EventArgs) Handles Button12.MouseLeave
        Button12.BackColor = Color.Black
    End Sub

    Private Sub Button13_MouseEnter(sender As Object, e As EventArgs) Handles Button13.MouseEnter
        Button13.BackColor = Color.DarkRed
    End Sub

    Private Sub Button13_MouseLeave(sender As Object, e As EventArgs) Handles Button13.MouseLeave
        Button13.BackColor = Color.Black
    End Sub
End Class
