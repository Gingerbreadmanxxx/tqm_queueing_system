Imports System.Media

Public Class f_cashier

    Private Sub f_cashier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbox1_cashier()
        lv1_pendings()
        lv2_lto()
        lv3_lightvehicle()
        lv4_motorcycle()
        ListView1.Enabled = False
        opencon()
        reload_tb_tickets()
        reload_tb_lightvehicle_tickets()
        reload_tb_lto_tickets()
        reload_tb_motorcyle_tickets()
        Try
            Dim n1, n2, n3, r1 As Integer
            n1 = Label5.Text
            n2 = Label17.Text
            n3 = Label19.Text
            r1 = n1 + n2 + n3
            Label21.Text = r1
        Catch ex As Exception

        End Try
    End Sub


    'ComboBox1.Items.Add("CASHIER ")
    ' ComboBox1.Items.Add("CASHIER 3")
    ' ComboBox1.Items.Add("COUNTER 2")

    Sub cbox1_cashier()
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("[ SELECT ]")
        ComboBox1.Items.Add("CASHIER")
        ComboBox1.Items.Add("COUNTER")
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
        ListView1.Columns.Add("Vehicle Type", 200)
        ListView1.Columns.Add("Ticket No.", 100)
        ListView1.Columns.Add("Date", 100)
        ListView1.Columns.Add("Time", 100)
        ListView1.Columns.Add("Cx Name", 100)
        ListView1.Columns.Add(" ", 40)

    End Sub

    Private Sub Button6_MouseEnter(sender As Object, e As EventArgs) Handles Button6.MouseEnter
        Button6.BackColor = Color.DarkRed
    End Sub

    Private Sub Button6_MouseLeave(sender As Object, e As EventArgs) Handles Button6.MouseLeave
        Button6.BackColor = Color.Black
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        reload_tb_tickets()
        ' reload_tb_processed_tickets()
        reload_users()
        reload_users_CONFIRMED()
        reload_users_NOTCONFIRMED()
        Form1.IsMdiContainer = False
        For Each ChildForm As Form In Form1.MdiChildren
            ChildForm.Close()
        Next
        Form1.GroupBox1.Visible = True
    End Sub


    Sub lv2_lto()
        ListView2.Items.Clear()
        ListView2.BackColor = Color.Black
        ListView2.View = View.Details
        ListView2.GridLines = False
        ListView2.FullRowSelect = True
        ListView2.Columns.Clear()
        ListView2.Columns.Add("#", 0)
        ListView2.Columns.Add("Vehicle Type", 200)
        ListView2.Columns.Add("Ticket No.", 100)
        ListView2.Columns.Add("Date", 100)
        ListView2.Columns.Add("Time", 100)
        ListView2.Columns.Add("Cashier No", 100)
        ListView2.Columns.Add("Processed By", 200)
        ListView2.Columns.Add("Cx Name", 100)
        ListView2.Columns.Add(" ", 40)
    End Sub


    Sub lv3_lightvehicle()
        ListView3.Items.Clear()
        ListView3.BackColor = Color.Black
        ListView3.View = View.Details
        ListView3.GridLines = False
        ListView3.FullRowSelect = True
        ListView3.Columns.Clear()
        ListView3.Columns.Add("#", 0)
        ListView3.Columns.Add("Vehicle Type", 200)
        ListView3.Columns.Add("Ticket No.", 100)
        ListView3.Columns.Add("Date", 100)
        ListView3.Columns.Add("Time", 100)
        ListView3.Columns.Add("Cashier No", 100)
        ListView3.Columns.Add("Processed By", 200)
        ListView3.Columns.Add("Cx Name", 100)
        ListView3.Columns.Add(" ", 40)
    End Sub

    Sub lv4_motorcycle()
        ListView4.Items.Clear()
        ListView4.BackColor = Color.Black
        ListView4.View = View.Details
        ListView4.GridLines = False
        ListView4.FullRowSelect = True
        ListView4.Columns.Clear()
        ListView4.Columns.Add("#", 0)
        ListView4.Columns.Add("Vehicle Type", 200)
        ListView4.Columns.Add("Ticket No.", 100)
        ListView4.Columns.Add("Date", 100)
        ListView4.Columns.Add("Time", 100)
        ListView4.Columns.Add("Cashier No", 100)
        ListView4.Columns.Add("Processed By", 200)
        ListView4.Columns.Add("Cx Name", 100)
        ListView4.Columns.Add(" ", 40)
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        ' f_queing.Timer2.Start()
        selected_ticket()
        If Label6.Text = "(L.T.O)" Then
            insert_into_tb_lto_tickets()
        ElseIf Label6.Text = "(L.V.) LIGHT VEHICLE" Then
            insert_into_tb_lightvehicle_tickets()
        ElseIf Label6.Text = "(M.C.) MOTORCYCLE" Then
            insert_into_tb_motorcycle_tickets()
        End If
        delete_from_tb_tickets()
        reload_tb_tickets()
        reload_tb_lightvehicle_tickets()
        reload_tb_lto_tickets()
        reload_tb_motorcyle_tickets()
        f_queing.Button6.Text = Label12.Text
        f_queing.Button5.Text = Label11.Text
        f_queing.Button4.Text = Label10.Text
        Try
            Dim n1, n2, n3, r1 As Integer
            n1 = Label5.Text
            n2 = Label17.Text
            n3 = Label19.Text
            r1 = n1 + n2 + n3
            Label21.Text = r1
        Catch ex As Exception

        End Try
        reload_tb_lto_tickets_que()
        reload_tb_lightvehicle_tickets_que()
        reload_tb_motorcyle_tickets_que()
        f_queing.Refresh()
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        If ComboBox1.Text = "[ SELECT ]" Then
            ListView1.Enabled = False
        Else
            ListView1.Enabled = True
        End If
        reload_tb_lto_tickets_que()
        reload_tb_lightvehicle_tickets_que()
        reload_tb_motorcyle_tickets_que()
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

    Private Sub ListView2_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles ListView2.DrawColumnHeader
        e.DrawDefault = True
    End Sub

    Private Sub ListView2_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListView2.DrawItem
        If e.Item.Selected = False Then
            e.DrawDefault = True
        End If
    End Sub

    Private Sub ListView2_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles ListView2.DrawSubItem
        If e.Item.Selected = True Then
            e.Graphics.FillRectangle(New SolidBrush(Color.DarkRed), e.Bounds)
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, New Font(Me.Font, Nothing), New Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.White)
        Else
            e.DrawDefault = True
        End If
    End Sub

    Private Sub ListView3_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles ListView3.DrawColumnHeader
        e.DrawDefault = True
    End Sub

    Private Sub ListView3_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListView3.DrawItem
        If e.Item.Selected = False Then
            e.DrawDefault = True
        End If
    End Sub

    Private Sub ListView3_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles ListView3.DrawSubItem
        If e.Item.Selected = True Then
            e.Graphics.FillRectangle(New SolidBrush(Color.DarkRed), e.Bounds)
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, New Font(Me.Font, Nothing), New Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.White)
        Else
            e.DrawDefault = True
        End If
    End Sub

    Private Sub ListView4_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles ListView4.DrawColumnHeader
        e.DrawDefault = True
    End Sub

    Private Sub ListView4_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListView4.DrawItem
        If e.Item.Selected = False Then
            e.DrawDefault = True
        End If
    End Sub

    Private Sub ListView4_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles ListView4.DrawSubItem
        If e.Item.Selected = True Then
            e.Graphics.FillRectangle(New SolidBrush(Color.DarkRed), e.Bounds)
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, New Font(Me.Font, Nothing), New Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.White)
        Else
            e.DrawDefault = True
        End If
    End Sub


    Private Sub Label10_TextChanged(sender As Object, e As EventArgs) Handles Label10.TextChanged
        If Label10.Text = 0 Then

        Else
            Label10.Text = f_queing.Button4.Text
        End If

    End Sub


    Private Sub Label11_TextChanged(sender As Object, e As EventArgs) Handles Label11.TextChanged
        If Label11.Text = 0 Then

        Else
            Label11.Text = f_queing.Button5.Text
        End If

    End Sub


    Private Sub Label12_TextChanged(sender As Object, e As EventArgs) Handles Label12.TextChanged
        If Label12.Text = 0 Then

        Else
            Label12.Text = f_queing.Button6.Text
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        reload_tb_tickets()
        reload_tb_lto_tickets()
        reload_tb_lightvehicle_tickets()
        reload_tb_motorcyle_tickets()
    End Sub

    Private Sub Button5_MouseEnter(sender As Object, e As EventArgs) Handles Button5.MouseEnter
        Button5.BackColor = Color.DarkRed
    End Sub

    Private Sub Button5_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Button5.BackColor = Color.Black
    End Sub
End Class