Imports System.Drawing.Printing
Public Class f_ticketing

    Private Sub f_ticketing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        f_lto_ticket.Button2.Enabled = False
        Me.WindowState = FormWindowState.Maximized
        Timer1.Start()
        f_lto_ticket.TopLevel = False
        f_lto_ticket.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f_lto_ticket.Visible = True
        Panel1.Controls.Add(f_lto_ticket)

        f_light_vehiclevb.Button2.Enabled = False
        f_light_vehiclevb.TopLevel = False
        f_light_vehiclevb.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f_light_vehiclevb.Visible = True
        Panel2.Controls.Add(f_light_vehiclevb)

        f_motocycle.Button2.Enabled = False
        f_motocycle.TopLevel = False
        f_motocycle.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f_motocycle.Visible = True
        Panel3.Controls.Add(f_motocycle)
        opencon()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        find_existed()
        If f_lto_ticket.Label6.Text = f_lto_ticket.TextBox1.Text And f_lto_ticket.Label4.Text = f_lto_ticket.Label7.Text Then
            MsgBox("The ticket number is already taken today. Please ask the cashier is what's that last number and enter the number in ticket number.", vbExclamation, "Already Taken")
            f_lto_ticket.Button2.Enabled = False
        ElseIf f_lto_ticket.TextBox1.Text > 500 Then
            MsgBox("Sorry! Please come back again tomorrow. We don't have remaining ticket for you today. Thank you!", vbExclamation, "No More Ticket For Today")
        Else
            insert_into_tb_tickets_lto()
            f_lto_ticket.Focus()
            f_lto_ticket.PrintDialog1.Document = f_lto_ticket.PrintDocument1
            If f_lto_ticket.PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                f_lto_ticket.PrintDocument1.Print()
            End If
            f_lto_ticket.txtBox_cust_name.Text = "[Name]"
        End If
        Try
            Dim n1, n2 As Integer
            n1 = f_lto_ticket.TextBox1.Text
            n2 = n1 + 1
            f_lto_ticket.TextBox1.Text = n2
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        find_existed2()
        If f_light_vehiclevb.Label6.Text = f_light_vehiclevb.TextBox1.Text And f_light_vehiclevb.Label4.Text = f_light_vehiclevb.Label7.Text Then
            MsgBox("The ticket number is already taken today. Please ask the cashier is what's that last number and enter the number in ticket number.", vbExclamation, "Already Taken")
        ElseIf f_light_vehiclevb.TextBox1.Text > 500 Then
            MsgBox("Sorry! Please come back again tomorrow. We don't have remaining ticket for you today. Thank you!", vbExclamation, "No More Ticket For Today")
        Else
            insert_into_tb_tickets_light_vehicle()
            f_light_vehiclevb.Focus()
            f_light_vehiclevb.PrintDialog1.Document = f_light_vehiclevb.PrintDocument1
            If f_light_vehiclevb.PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                f_light_vehiclevb.PrintDocument1.Print()
            End If
            f_light_vehiclevb.txtBox_cust_name.Text = "[Name]"
        End If
        Try
            Dim n1, n2 As Integer
            n1 = f_light_vehiclevb.TextBox1.Text
            n2 = n1 + 1
            f_light_vehiclevb.TextBox1.Text = n2
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        find_existed3()
        If f_motocycle.Label6.Text = f_motocycle.TextBox1.Text And f_motocycle.Label4.Text = f_motocycle.Label7.Text Then
            MsgBox("The ticket number is already taken today. Please ask the cashier is what's that last number and enter the number in ticket number.", vbExclamation, "Already Taken")
        ElseIf f_motocycle.TextBox1.Text > 500 Then
            MsgBox("Sorry! Please come back again tomorrow. We don't have remaining ticket for you today. Thank you!", vbExclamation, "No More Ticket For Today")
        Else
            insert_into_tb_tickets_motorcycle()
            f_motocycle.Focus()
            f_motocycle.PrintDialog1.Document = f_motocycle.PrintDocument1
            If f_motocycle.PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                f_motocycle.PrintDocument1.Print()
            End If
            f_motocycle.txtBox_cust_name.Text = "[Name]"
        End If
        Try
            Dim n1, n2 As Integer
            n1 = f_motocycle.TextBox1.Text
            n2 = n1 + 1
            f_motocycle.TextBox1.Text = n2
        Catch ex As Exception

        End Try
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

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = Today
        Label4.Text = TimeOfDay
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        reload_tb_tickets()
        reload_tb_lightvehicle_tickets()
        reload_tb_lto_tickets()
        reload_tb_motorcyle_tickets()
        reload_users()
        reload_users_CONFIRMED()
        reload_users_NOTCONFIRMED()
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button6_MouseEnter(sender As Object, e As EventArgs) Handles Button6.MouseEnter
        Button6.BackColor = Color.DarkRed
    End Sub

    Private Sub Button6_MouseLeave(sender As Object, e As EventArgs) Handles Button6.MouseLeave
        Button6.BackColor = Color.Black
    End Sub
End Class