Public Class f_motocycle

    Private Sub f_motocycle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Dim space As Integer
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        '  Dim blackPen As New Pen(Color.Black, 3)
        '  Dim rect As New Rectangle(15, 10, 300, 250)
        '  e.Graphics.DrawRectangle(blackPen, rect)
        space = 10
        If TextBox1.Text > 99 Then
            e.Graphics.DrawString(TextBox1.Text, New Font("Times New Roman", 45, FontStyle.Bold), Brushes.Black, 105, space)
        ElseIf TextBox1.Text > 9 Then
            e.Graphics.DrawString("0" & TextBox1.Text, New Font("Times New Roman", 45, FontStyle.Bold), Brushes.Black, 105, space)

        ElseIf TextBox1.Text > 0 Then
            e.Graphics.DrawString("00" & TextBox1.Text, New Font("Times New Roman", 45, FontStyle.Bold), Brushes.Black, 105, space)
        End If
        space = 75
        e.Graphics.DrawString("- PLEASE PROCEED IMMEDIATELY TO", New Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, 40, space)
        space = 87
        e.Graphics.DrawString("THE COUNTER ONCE NUMBER CALLED. -", New Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, 30, space)
        space = 110
        e.Graphics.DrawString(Label3.Text, New Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 73, space)
        space = 150
        e.Graphics.DrawString("(M.C.)", New Font("Times New Roman", 30, FontStyle.Bold), Brushes.Black, 100, space)
        space = 205
        e.Graphics.DrawString("MOTORCYCLE", New Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, 60, space)
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = Today & "   " & TimeOfDay
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.BackColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.White
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Visible = False

        Button2.Visible = True
        f_ticketing.Button3.Enabled = True
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class