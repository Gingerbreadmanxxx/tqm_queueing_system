Imports System.Media

Public Class f_export_tickets

    Private Sub f_export_tickets_Load(sender As Object, e As EventArgs)

        opencon()
        lv_list()
        LoadMotorcycleTickets()

    End Sub

    Sub lv_list()
        LightVehicleList.BackColor = Color.Black
        LightVehicleList.Columns.Clear()
        LightVehicleList.Columns.Add("Vehicle Type", 200)
        LightVehicleList.Columns.Add("Ticket Number", 200)
        LightVehicleList.Columns.Add("Date", 100)
        LightVehicleList.Columns.Add("Processed By", 200)
        LightVehicleList.Columns.Add("Customer Name", 200)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LightVehicleList_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles LightVehicleList.DrawColumnHeader
        e.DrawDefault = True
    End Sub

    Private Sub LightVehicleList_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles LightVehicleList.DrawItem
        If e.Item.Selected = False Then
            e.DrawDefault = True
        End If
    End Sub

    Private Sub LightVehicleList_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles LightVehicleList.DrawSubItem
        If e.Item.Selected = True Then
            e.Graphics.FillRectangle(New SolidBrush(Color.DarkRed), e.Bounds)
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, New Font(Me.Font, Nothing), New Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.White)
        Else
            e.DrawDefault = True
        End If
    End Sub

    Private Sub Export_LV_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim exlFile As Microsoft.Office.Interop.Excel.Application = Nothing

        Try
            exlFile = New Microsoft.Office.Interop.Excel.Application()

            Dim row As Integer = 5

            With exlFile
                .Workbooks.Open("C:\QueuingSystem\QueuingTickets_LV.xlsx")
                .Cells(4, 2).Value = "As of " & FormatDateTime(Now(), DateFormat.LongDate)

                'For ctremp = 0 To 

                .Visible = True
            End With

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Do not set exlFile = Nothing immediately if you want the Excel file to remain open
        End Try
    End Sub

    Private Sub Export_MC_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim exlFile As Microsoft.Office.Interop.Excel.Application = Nothing

        Try
            exlFile = New Microsoft.Office.Interop.Excel.Application()

            Dim row As Integer = 5

            With exlFile
                .Workbooks.Open("C:\QueuingSystem\QueuingTickets_MC.xlsx")
                .Cells(4, 2).Value = "As of " & FormatDateTime(Now(), DateFormat.LongDate)

                'For ctremp = 0 To 

                .Visible = True
            End With

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Do not set exlFile = Nothing immediately if you want the Excel file to remain open
        End Try
    End Sub


    Private Sub f_export_tickets_Load_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub LV_Refresh_Click(sender As Object, e As EventArgs) Handles LV_Refresh.Click

    End Sub

    Private Sub MC_Refresh_Click(sender As Object, e As EventArgs) Handles MC_Refresh.Click

    End Sub
End Class

