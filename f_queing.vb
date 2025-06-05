Imports System.Speech.Synthesis
Public Class f_queing

    Private Sub f_queing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        opencon()
        lv2_lto()
        lv4_motorcycle()
        lv3_lightvehicle()
        lv4_pendings()
        lv5_pendings()
        lv6_pendings()
        WindowState = FormWindowState.Maximized
        WebBrowser1.Navigate("C:\loop\clipunmuted.htm")
        Label13.Text = 1
        Timer1.Start()

    End Sub

    Sub lv2_lto()
        ListView1.Items.Clear()
        ListView1.BackColor = Color.Black
        ListView1.View = View.Details
        ListView1.GridLines = False
        ListView1.FullRowSelect = False
        ListView1.HeaderStyle = ColumnHeaderStyle.None
        ListView1.Columns.Clear()
        ListView1.Columns.Add("#", 0)
        ListView1.Columns.Add("Vehicle Type", 0)
        ListView1.Columns.Add("Ticket No.", 260, HorizontalAlignment.Center)
        ListView1.Columns.Add("Date", 0)
        ListView1.Columns.Add("Time", 0)
        ListView1.Columns.Add("Cashier No", 0, HorizontalAlignment.Center)
        ListView1.Columns.Add("Processed By", 0)
        ListView1.Columns.Add(" ", 0)
        ListView1.Scrollable = False
    End Sub

    Sub lv3_lightvehicle()
        ListView2.Items.Clear()
        ListView2.BackColor = Color.Black
        ListView2.View = View.Details
        ListView2.GridLines = False
        ListView2.FullRowSelect = False
        ListView2.HeaderStyle = ColumnHeaderStyle.None
        ListView2.Scrollable = False
        ListView2.Columns.Clear()
        ListView2.Columns.Add("#", 0)
        ListView2.Columns.Add("Vehicle Type", 0)
        ListView2.Columns.Add("Ticket No.", 260, HorizontalAlignment.Center)
        ListView2.Columns.Add("Date", 0)
        ListView2.Columns.Add("Time", 0)
        ListView2.Columns.Add("Cashier No", 0, HorizontalAlignment.Center)
        ListView2.Columns.Add("Processed By", 0)
        ListView2.Columns.Add(" ", 0)
    End Sub

    Sub lv4_motorcycle()
        ListView3.Items.Clear()
        ListView3.BackColor = Color.Black
        ListView3.View = View.Details
        ListView3.GridLines = False
        ListView3.FullRowSelect = False
        ListView3.HeaderStyle = ColumnHeaderStyle.None
        ListView3.Scrollable = False
        ListView3.Columns.Clear()
        ListView3.Columns.Add("#", 0)
        ListView3.Columns.Add("Vehicle Type", 0)
        ListView3.Columns.Add("Ticket No.", 260, HorizontalAlignment.Center)
        ListView3.Columns.Add("Date", 0)
        ListView3.Columns.Add("Time", 0)
        ListView3.Columns.Add("Cashier No", 0, HorizontalAlignment.Center)
        ListView3.Columns.Add("Processed By", 0)
        ListView3.Columns.Add(" ", 0)
    End Sub

    Sub lv4_pendings()
        ListView4.Items.Clear()
        ListView4.BackColor = Color.Black
        ListView4.View = View.Details
        ListView4.GridLines = False
        ListView4.FullRowSelect = False
        ListView4.HeaderStyle = ColumnHeaderStyle.None
        ListView4.Columns.Clear()
        ListView4.Columns.Add("#", 0)
        ListView4.Columns.Add("Ticket No.", 230, HorizontalAlignment.Center)
    End Sub

    Sub lv5_pendings()
        ListView5.Items.Clear()
        ListView5.BackColor = Color.Black
        ListView5.View = View.Details
        ListView5.GridLines = False
        ListView5.FullRowSelect = False
        ListView5.HeaderStyle = ColumnHeaderStyle.None
        ListView5.Columns.Clear()
        ListView5.Columns.Add("#", 0)
        ListView5.Columns.Add("Ticket No.", 230, HorizontalAlignment.Center)
    End Sub

    Sub lv6_pendings()
        ListView6.Items.Clear()
        ListView6.BackColor = Color.Black
        ListView6.View = View.Details
        ListView6.HeaderStyle = ColumnHeaderStyle.None
        ListView6.GridLines = False
        ListView6.FullRowSelect = False
        ListView6.Columns.Clear()
        ListView6.Columns.Add("#", 0)
        ListView6.Columns.Add("Ticket No.", 230, HorizontalAlignment.Center)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        WebBrowser1.Navigate("C:\loop\clipmuted.htm")
        'Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = Today
        Label4.Text = TimeOfDay
    End Sub

    Private Sub Button4_TextChanged(sender As Object, e As EventArgs) Handles Button4.TextChanged
        Label6.Text = f_cashier.ComboBox1.Text
        If Button4.Text = "0" Then

        Else
            Dim speaker As New SpeechSynthesizer()
            speaker.Speak(Button1.Text & ", Number, " & Button4.Text & ", Named,  " & f_cashier.Label23.Text & ", Please go to," & f_cashier.ComboBox1.Text)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub Button5_TextChanged(sender As Object, e As EventArgs) Handles Button5.TextChanged
        Label7.Text = f_cashier.ComboBox1.Text
        If Button5.Text = "0" Then

        Else
            Dim speaker As New SpeechSynthesizer()
            speaker.Speak(Button2.Text & ", Number, " & Button5.Text & ", Named ,  " & f_cashier.Label23.Text & " , Please go to," & f_cashier.ComboBox1.Text)

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub

    Private Sub Button6_TextChanged(sender As Object, e As EventArgs) Handles Button6.TextChanged
        Label8.Text = f_cashier.ComboBox1.Text
        If Button6.Text = "0" Then

        Else
            Dim speaker As New SpeechSynthesizer()
            speaker.Speak(Button3.Text & ", Number, " & Button6.Text & ", Named,  " & f_cashier.Label23.Text & ",  Please go to," & f_cashier.ComboBox1.Text)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        reload_tb_tickets()
        reload_tb_lightvehicle_tickets()
        reload_tb_lto_tickets()
        reload_tb_motorcyle_tickets()
        reload_users()
        reload_users_CONFIRMED()
        reload_users_NOTCONFIRMED()
        WebBrowser1.Navigate("C:\loop\clipmuted.htm")
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button7_MouseEnter(sender As Object, e As EventArgs) Handles Button7.MouseEnter
        Button7.BackColor = Color.DarkRed
    End Sub

    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles Button7.MouseLeave
        Button7.BackColor = Color.Black
    End Sub

    Private Sub Label4_TextChanged(sender As Object, e As EventArgs) Handles Label4.TextChanged
        Try
            Dim n1 As Integer
            n1 = Label13.Text
            n1 = n1 + 1
            Label13.Text = n1
            Try
                If Label13.Text > 3 Then
                    reload_tb_lto_tickets_que()
                    reload_tb_lightvehicle_tickets_que()
                    reload_tb_motorcyle_tickets_que()
                    queuing_reload_tb_lto_tickets()
                    queuing_reload_tb_lightvehicle_tickets()
                    queuing_reload_tb_motorcyle_tickets()
                    Label13.Text = 0
                End If
            Catch

            End Try
        Catch
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub ListView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView3.SelectedIndexChanged

    End Sub
End Class