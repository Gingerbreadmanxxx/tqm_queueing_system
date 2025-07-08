<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class f_export_tickets
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso Components IsNot Nothing Then
                Components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer


    Private Sub InitializeComponent()
        Me.Ticket_Export_Label = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LV_Refresh = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MC_Refresh = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.LVList = New System.Windows.Forms.DataGridView()
        Me.MCList = New System.Windows.Forms.DataGridView()
        Me.LightVehicleList = New System.Windows.Forms.ListView()
        CType(Me.LVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MCList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ticket_Export_Label
        '
        Me.Ticket_Export_Label.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ticket_Export_Label.BackColor = System.Drawing.Color.Black
        Me.Ticket_Export_Label.Font = New System.Drawing.Font("Yu Gothic UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ticket_Export_Label.ForeColor = System.Drawing.Color.White
        Me.Ticket_Export_Label.Location = New System.Drawing.Point(0, 0)
        Me.Ticket_Export_Label.Name = "Ticket_Export_Label"
        Me.Ticket_Export_Label.Size = New System.Drawing.Size(1036, 50)
        Me.Ticket_Export_Label.TabIndex = 4
        Me.Ticket_Export_Label.Text = "Ticket List"
        Me.Ticket_Export_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.Location = New System.Drawing.Point(-1, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(1037, 36)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "- LIGHT VEHICLE -"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ListView3
        '
        Me.ListView3.HideSelection = False
        Me.ListView3.Location = New System.Drawing.Point(-1, 86)
        Me.ListView3.Name = "ListView3"
        Me.ListView3.OwnerDraw = True
        Me.ListView3.Size = New System.Drawing.Size(1037, 258)
        Me.ListView3.TabIndex = 9
        Me.ListView3.UseCompatibleStateImageBehavior = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(5, 342)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1037, 33)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "- MOTORCYCLE -"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LV_Refresh
        '
        Me.LV_Refresh.BackColor = System.Drawing.Color.Black
        Me.LV_Refresh.FlatAppearance.BorderSize = 0
        Me.LV_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LV_Refresh.Font = New System.Drawing.Font("Yu Gothic UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Refresh.ForeColor = System.Drawing.Color.White
        Me.LV_Refresh.Location = New System.Drawing.Point(875, 111)
        Me.LV_Refresh.Name = "LV_Refresh"
        Me.LV_Refresh.Size = New System.Drawing.Size(146, 86)
        Me.LV_Refresh.TabIndex = 13
        Me.LV_Refresh.Text = "REFRESH"
        Me.LV_Refresh.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Yu Gothic UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(875, 231)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(146, 86)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "EXPORT"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Black
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Yu Gothic UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(875, 516)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(146, 99)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "EXPORT"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'MC_Refresh
        '
        Me.MC_Refresh.BackColor = System.Drawing.Color.Black
        Me.MC_Refresh.FlatAppearance.BorderSize = 0
        Me.MC_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MC_Refresh.Font = New System.Drawing.Font("Yu Gothic UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_Refresh.ForeColor = System.Drawing.Color.White
        Me.MC_Refresh.Location = New System.Drawing.Point(875, 396)
        Me.MC_Refresh.Name = "MC_Refresh"
        Me.MC_Refresh.Size = New System.Drawing.Size(146, 99)
        Me.MC_Refresh.TabIndex = 16
        Me.MC_Refresh.Text = "REFRESH"
        Me.MC_Refresh.UseVisualStyleBackColor = False
        '
        'ListView1
        '
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(-1, 374)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.OwnerDraw = True
        Me.ListView1.Size = New System.Drawing.Size(1037, 258)
        Me.ListView1.TabIndex = 15
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'LVList
        '
        Me.LVList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.LVList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LVList.Location = New System.Drawing.Point(-1, 86)
        Me.LVList.Name = "LVList"
        Me.LVList.Size = New System.Drawing.Size(854, 258)
        Me.LVList.TabIndex = 20
        '
        'MCList
        '
        Me.MCList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.MCList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MCList.Location = New System.Drawing.Point(-1, 374)
        Me.MCList.Name = "MCList"
        Me.MCList.Size = New System.Drawing.Size(854, 271)
        Me.MCList.TabIndex = 21
        '
        'LightVehicleList
        '
        Me.LightVehicleList.HideSelection = False
        Me.LightVehicleList.Location = New System.Drawing.Point(9, 99)
        Me.LightVehicleList.Name = "LightVehicleList"
        Me.LightVehicleList.OwnerDraw = True
        Me.LightVehicleList.Size = New System.Drawing.Size(832, 231)
        Me.LightVehicleList.TabIndex = 22
        Me.LightVehicleList.UseCompatibleStateImageBehavior = False
        '
        'f_export_tickets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1033, 679)
        Me.Controls.Add(Me.LightVehicleList)
        Me.Controls.Add(Me.MCList)
        Me.Controls.Add(Me.LVList)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.MC_Refresh)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LV_Refresh)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ListView3)
        Me.Controls.Add(Me.Ticket_Export_Label)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Yu Gothic UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "f_export_tickets"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "f_export_tickets"
        CType(Me.LVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MCList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label15 As Label
    Friend WithEvents ListView3 As Windows.Forms.ListView
    Friend WithEvents Label2 As Label
    Friend WithEvents LV_Refresh As Windows.Forms.Button
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents MC_Refresh As Windows.Forms.Button
    Friend WithEvents ListView1 As Windows.Forms.ListView
    Friend WithEvents LVList As DataGridView
    Friend WithEvents MCList As DataGridView
    Friend WithEvents Ticket_Export_Label As Label
    Friend WithEvents LightVehicleList As ListView
End Class
