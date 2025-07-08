Imports System.Runtime.Remoting.Channels
Imports MySql.Data.MySqlClient
Module system_queing_mod
    'Dim con As New MySqlConnection("server=" & Form1.hidden.Text & ";port=3306;userid=tqm_queuing;password=@tqm_queuing;database=tqm_queuing;connection timeout=10000000;pooling=true;old guids=true;")
    'Dim con As New MySqlConnection("server=172.0.0.22;port=32775;userid=dev;password=root;database=tqm_queuing;connection timeout=10000000;")
    Dim con As New MySqlConnection("server=localhost;port=3306;userid=root;password=@ngelo123;database=tqm_queuing;connection timeout=10000000;")
    Dim com As New MySqlCommand
    Dim dr As MySqlDataReader

    Sub opencon()
        con.Close()
        con.Open()
        com.Connection = con
    End Sub

    Sub closereader()
        dr = com.ExecuteReader
        dr.Close()
    End Sub

    Sub create_db_tqm_queing()
        com.CommandText = "create database if not exists " & Form1.Label3.Text & ";"
        closereader()
    End Sub

    Sub create_tb_tickets()
        com.CommandText = "create table if not exists " & Form1.Label3.Text & ".tb_tickets(id int(100) auto_increment primary key, vehicletype varchar(100), tickernumber varchar(100), datenow varchar(100), timenow varchar(100), cust_name varchar(100));"
        closereader()
    End Sub

    Sub create_tb_processed_tickets()
        com.CommandText = "create table if not exists " & Form1.Label3.Text & ".tb_processed_tickets(id int(100) auto_increment primary key, vehicletype varchar(100), tickernumber varchar(100), datenow varchar(100), timenow varchar(100), processedby varchar(100), cust_name varchar(100));"
        closereader()
    End Sub

    Sub create_tb_lto_tickets()
        com.CommandText = "create table if not exists " & Form1.Label3.Text & ".tb_lto_tickets(id int(100) auto_increment primary key, vehicletype varchar(100), tickernumber varchar(100), datenow varchar(100), timenow varchar(100), cashierno longtext, processedby varchar(100), cust_name varchar(100));"
        closereader()
    End Sub

    Sub create_tb_lightvehicle_tickets()
        com.CommandText = "create table if not exists " & Form1.Label3.Text & ".tb_lightvehicle_tickets(id int(100) auto_increment primary key, vehicletype varchar(100), tickernumber varchar(100), datenow varchar(100), timenow varchar(100), cashierno longtext, processedby varchar(100), cust_name varchar(100));"
        closereader()
    End Sub

    Sub create_tb_motorcycle_tickets()
        com.CommandText = "create table if not exists " & Form1.Label3.Text & ".tb_motorcycle_tickets(id int(100) auto_increment primary key, vehicletype varchar(100), tickernumber varchar(100), datenow varchar(100), timenow varchar(100), cashierno longtext, processedby varchar(100), cust_name varchar(100));"
        closereader()
    End Sub

    Sub insert_into_tb_tickets_lto()
        com.CommandText = "insert into " & Form1.Label3.Text & ".tb_tickets(vehicletype,tickernumber,datenow,timenow,cust_name,plate_no)values('" & "(L.T.O)" & "', '" & f_lto_ticket.TextBox1.Text & "', '" & f_ticketing.Label3.Text & "', '" & f_ticketing.Label4.Text & "' , '" & f_lto_ticket.txtBox_cust_name.Text & "' , '" & f_lto_ticket.txtBox_plate_no.Text & "');"
        closereader()
    End Sub

    Sub insert_into_tb_tickets_light_vehicle()
        com.CommandText = "insert into " & Form1.Label3.Text & ".tb_tickets(vehicletype,tickernumber,datenow,timenow,cust_name,plate_no)values('" & "(L.V.) LIGHT VEHICLE" & "', '" & f_light_vehiclevb.TextBox1.Text & "', '" & f_ticketing.Label3.Text & "', '" & f_ticketing.Label4.Text & "', '" & f_light_vehiclevb.txtBox_cust_name.Text & "', '" & f_light_vehiclevb.txtBox_plate_no.Text & "');"
        closereader()
    End Sub

    Sub insert_into_tb_tickets_motorcycle()
        com.CommandText = "insert into " & Form1.Label3.Text & ".tb_tickets(vehicletype,tickernumber,datenow,timenow,cust_name,plate_no)values('" & "(M.C.) MOTORCYCLE" & "', '" & f_motocycle.TextBox1.Text & "', '" & f_ticketing.Label3.Text & "', '" & f_ticketing.Label4.Text & "', '" & f_motocycle.txtBox_cust_name.Text & "', '" & f_motocycle.txtBox_plate_no.Text & "');"
        closereader()
    End Sub
    Sub alter_tb_lto_tickets()
        com.CommandText = "ALTER TABLE " & Form1.Label3.Text & ".`tb_lto_tickets` ADD COLUMN `cust_name` VARCHAR(100) NULL DEFAULT NULL AFTER `processedby`;"
        closereader()
    End Sub
    Sub alter_tb_motorcycle_tickets()
        com.CommandText = "ALTER TABLE " & Form1.Label3.Text & ".`tb_motorcycle_tickets` ADD COLUMN `cust_name` VARCHAR(100) NULL DEFAULT NULL AFTER `processedby`;"
        closereader()
    End Sub
    Sub alter_tb_lightvehicle_tickets()
        com.CommandText = "ALTER TABLE " & Form1.Label3.Text & ".`tb_lightvehicle_tickets` ADD COLUMN `cust_name` VARCHAR(100) NULL DEFAULT NULL AFTER `processedby`;"
        closereader()
    End Sub
    Sub alter_tb_tickets()
        com.CommandText = "ALTER TABLE " & Form1.Label3.Text & ".`tb_tickets` ADD COLUMN `cust_name` VARCHAR(100) NULL DEFAULT NULL AFTER `timenow`;"
        closereader()
    End Sub

    Sub reload_tb_tickets()
        f_cashier.ListView1.Items.Clear()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_tickets order by id asc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim ticket As New ListViewItem(dr.Item(0).ToString)
            Dim ticket_c As Integer
            For ticket_c = 1 To 5 Step 1
                ticket.SubItems.Add(dr.Item(ticket_c).ToString).BackColor = Color.White
            Next
            f_cashier.ListView1.Items.AddRange(New ListViewItem() {ticket})
            ticket.UseItemStyleForSubItems = False
        End While
        f_cashier.Label4.Text = f_cashier.ListView1.Items.Count
        Form1.Button9.Text = "PENDING TICKETS" & vbNewLine & "( " & f_cashier.ListView1.Items.Count & " )"
        dr.Close()
    End Sub

    Sub auto_select()
        f_cashier.ListView1.Items.Clear()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_processed_tickets order by id desc limit 1;"
        dr = com.ExecuteReader
        While dr.Read
            f_cashier.Label13.Text = dr.Item(1).ToString
            If f_cashier.Label13.Text = "(L.T.O.)" Then
                f_queing.Button4.Text = dr.Item(2).ToString
            ElseIf f_cashier.Label13.Text = "(L.V.) LIGHT VEHICLE" Then
                f_queing.Button5.Text = dr.Item(2).ToString
            ElseIf f_cashier.Label13.Text = "(M.C.) MOTORCYCLE" Then
                f_queing.Button6.Text = dr.Item(2).ToString
            End If
        End While

        dr.Close()
    End Sub

    Sub find_existed()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_tickets where datenow = '" & f_ticketing.Label3.Text & "' and tickernumber ='" & f_lto_ticket.TextBox1.Text & "' and vehicletype ='" & f_lto_ticket.Label4.Text & "';"
        dr = com.ExecuteReader
        While dr.Read
            f_lto_ticket.Label7.Text = dr.Item(1).ToString
            f_lto_ticket.Label5.Text = dr.Item(3).ToString
            f_lto_ticket.Label6.Text = dr.Item(2).ToString
        End While
        dr.Close()
    End Sub

    Sub find_existed2()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_tickets where datenow = '" & f_ticketing.Label3.Text & "' and tickernumber ='" & f_light_vehiclevb.TextBox1.Text & "' and vehicletype ='" & f_light_vehiclevb.Label4.Text & "';"
        dr = com.ExecuteReader
        While dr.Read
            f_light_vehiclevb.Label7.Text = dr.Item(1).ToString
            f_light_vehiclevb.Label5.Text = dr.Item(3).ToString
            f_light_vehiclevb.Label6.Text = dr.Item(2).ToString
        End While
        dr.Close()
    End Sub

    Sub find_existed3()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_tickets where datenow = '" & f_ticketing.Label3.Text & "' and tickernumber ='" & f_motocycle.TextBox1.Text & "' and vehicletype ='" & f_motocycle.Label4.Text & "';"
        dr = com.ExecuteReader
        While dr.Read
            f_motocycle.Label7.Text = dr.Item(1).ToString
            f_motocycle.Label5.Text = dr.Item(3).ToString
            f_motocycle.Label6.Text = dr.Item(2).ToString
        End While
        dr.Close()
    End Sub

    Sub selected_ticket()
        ' f_cashier.ListView1.Items.Clear()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_tickets where id='" & f_cashier.ListView1.FocusedItem.Text & "';"
        dr = com.ExecuteReader
        While dr.Read
            f_cashier.Label6.Text = dr.Item(1).ToString
            f_cashier.Label7.Text = dr.Item(2).ToString
            f_cashier.Label23.Text = dr.Item(5).ToString
            If f_cashier.Label6.Text = "(L.T.O)" Then
                f_queing.Button4.Text = dr.Item(2).ToString
            ElseIf f_cashier.Label6.Text = "(L.V.) LIGHT VEHICLE" Then
                f_queing.Button5.Text = dr.Item(2).ToString
            ElseIf f_cashier.Label6.Text = "(M.C.) MOTORCYCLE" Then
                f_queing.Button6.Text = dr.Item(2).ToString
            End If
        End While
        dr.Close()
    End Sub

    Sub insert_into_tb_processed_tickets()
        com.CommandText = "insert into " & Form1.Label3.Text & ".tb_processed_tickets(vehicletype,tickernumber,datenow,timenow,processedby,cust_name)values('" & f_cashier.Label6.Text & "','" & f_cashier.Label7.Text & "','" & Form1.ToolStripStatusLabel7.Text & "','" & Form1.ToolStripStatusLabel8.Text & "','" & Form1.ToolStripStatusLabel6.Text & "','" & f_cashier.Label23.Text & "');"
        closereader()
    End Sub

    Sub insert_into_tb_lto_tickets()
        com.CommandText = "insert into " & Form1.Label3.Text & ".tb_lto_tickets(vehicletype,tickernumber,datenow,timenow,cashierno,processedby,cust_name)values('" & f_cashier.Label6.Text & "','" & f_cashier.Label7.Text & "','" & Form1.ToolStripStatusLabel7.Text & "','" & Form1.ToolStripStatusLabel8.Text & "','" & f_cashier.ComboBox1.Text & "','" & Form1.ToolStripStatusLabel6.Text & "','" & f_cashier.Label23.Text & "');"
        closereader()
    End Sub

    Sub insert_into_tb_lightvehicle_tickets()
        com.CommandText = "insert into " & Form1.Label3.Text & ".tb_lightvehicle_tickets(vehicletype,tickernumber,datenow,timenow,cashierno,processedby,cust_name)values('" & f_cashier.Label6.Text & "','" & f_cashier.Label7.Text & "','" & Form1.ToolStripStatusLabel7.Text & "','" & Form1.ToolStripStatusLabel8.Text & "','" & f_cashier.ComboBox1.Text & "','" & Form1.ToolStripStatusLabel6.Text & "','" & f_cashier.Label23.Text & "');"
        closereader()
    End Sub

    Sub insert_into_tb_motorcycle_tickets()
        com.CommandText = "insert into " & Form1.Label3.Text & ".tb_motorcycle_tickets(vehicletype,tickernumber,datenow,timenow,cashierno,processedby,cust_name)values('" & f_cashier.Label6.Text & "','" & f_cashier.Label7.Text & "','" & Form1.ToolStripStatusLabel7.Text & "','" & Form1.ToolStripStatusLabel8.Text & "','" & f_cashier.ComboBox1.Text & "','" & Form1.ToolStripStatusLabel6.Text & "','" & f_cashier.Label23.Text & "');"
        closereader()
    End Sub

    Sub delete_from_tb_tickets()
        com.CommandText = "delete from " & Form1.Label3.Text & ".tb_tickets where id ='" & f_cashier.ListView1.FocusedItem.Text & "'"
        closereader()
    End Sub

    Sub reload_tb_lto_tickets()
        f_cashier.ListView2.Items.Clear()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_lto_tickets order by id desc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim ticket As New ListViewItem(dr.Item(0).ToString)
            Dim ticket_c As Integer
            For ticket_c = 1 To 7 Step 1
                ticket.SubItems.Add(dr.Item(ticket_c).ToString).BackColor = Color.White
            Next
            f_cashier.ListView2.Items.AddRange(New ListViewItem() {ticket})
            ticket.UseItemStyleForSubItems = False
        End While
        f_cashier.Label5.Text = f_cashier.ListView2.Items.Count
        'Form1.Button10.Text = "LTO TICKETS" & vbNewLine & "( " & f_cashier.ListView2.Items.Count & " )"
        dr.Close()
    End Sub

    Sub reload_tb_lto_tickets_que()
        f_queing.ListView1.Items.Clear()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_lto_tickets order by id desc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim ticket As New ListViewItem(dr.Item(0).ToString)
            Dim ticket_c As Integer
            For ticket_c = 1 To 6 Step 1
                ticket.SubItems.Add(dr.Item(ticket_c).ToString).ForeColor = Color.White
            Next
            f_queing.ListView1.Items.AddRange(New ListViewItem() {ticket})
            ticket.UseItemStyleForSubItems = False
        End While
        ' f_cashier.Label5.Text = f_cashier.ListView2.Items.Count
        'Form1.Button10.Text = "LTO TICKETS" & vbNewLine & "( " & f_cashier.ListView2.Items.Count & " )"
        dr.Close()
    End Sub

    Sub reload_tb_lightvehicle_tickets()
        f_cashier.ListView3.Items.Clear()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_lightvehicle_tickets order by id desc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim ticket As New ListViewItem(dr.Item(0).ToString)
            Dim ticket_c As Integer
            For ticket_c = 1 To 7 Step 1
                ticket.SubItems.Add(dr.Item(ticket_c).ToString).BackColor = Color.White
            Next
            f_cashier.ListView3.Items.AddRange(New ListViewItem() {ticket})
            ticket.UseItemStyleForSubItems = False
        End While
        f_cashier.Label17.Text = f_cashier.ListView3.Items.Count
        'Form1.Button10.Text = "LTO TICKETS" & vbNewLine & "( " & f_cashier.ListView3.Items.Count & " )"
        dr.Close()
    End Sub

    Sub reload_tb_lightvehicle_tickets_que()
        f_queing.ListView2.Items.Clear()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_lightvehicle_tickets order by id desc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim ticket As New ListViewItem(dr.Item(0).ToString)
            Dim ticket_c As Integer
            For ticket_c = 1 To 6 Step 1
                ticket.SubItems.Add(dr.Item(ticket_c).ToString).ForeColor = Color.White
            Next
            f_queing.ListView2.Items.AddRange(New ListViewItem() {ticket})
            ticket.UseItemStyleForSubItems = False
        End While
        ' f_cashier.Label17.Text = f_cashier.ListView3.Items.Count
        'Form1.Button10.Text = "LTO TICKETS" & vbNewLine & "( " & f_cashier.ListView3.Items.Count & " )"
        dr.Close()
    End Sub

    Sub reload_tb_motorcyle_tickets()
        f_cashier.ListView4.Items.Clear()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_motorcycle_tickets order by id desc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim ticket As New ListViewItem(dr.Item(0).ToString)
            Dim ticket_c As Integer
            For ticket_c = 1 To 7 Step 1
                ticket.SubItems.Add(dr.Item(ticket_c).ToString).BackColor = Color.White
            Next
            f_cashier.ListView4.Items.AddRange(New ListViewItem() {ticket})
            ticket.UseItemStyleForSubItems = False
        End While
        f_cashier.Label19.Text = f_cashier.ListView4.Items.Count
        'Form1.Button10.Text = "LTO TICKETS" & vbNewLine & "( " & f_cashier.ListView3.Items.Count & " )"
        dr.Close()
    End Sub


    Sub reload_tb_motorcyle_tickets_que()
        f_queing.ListView3.Items.Clear()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_motorcycle_tickets order by id desc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim ticket As New ListViewItem(dr.Item(0).ToString)
            Dim ticket_c As Integer
            For ticket_c = 1 To 6 Step 1
                ticket.SubItems.Add(dr.Item(ticket_c).ToString).ForeColor = Color.White
            Next
            f_queing.ListView3.Items.AddRange(New ListViewItem() {ticket})
            ticket.UseItemStyleForSubItems = False
        End While
        dr.Close()
    End Sub


    Sub queuing_reload_tb_lto_tickets()
        f_queing.ListView4.Items.Clear()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_lto_tickets order by id desc LIMIT 2 OFFSET 1 ;"
        dr = com.ExecuteReader
        While dr.Read
            Dim ticket As New ListViewItem(dr.Item(0).ToString)
            ticket.SubItems.Add(dr.Item(2).ToString).ForeColor = Color.White
            f_queing.ListView4.Items.AddRange(New ListViewItem() {ticket})
            ticket.UseItemStyleForSubItems = False
        End While

        dr.Close()
    End Sub

    Sub queuing_reload_tb_lightvehicle_tickets()
        f_queing.ListView5.Items.Clear()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_lightvehicle_tickets order by id desc LIMIT 2 OFFSET 1;"
        dr = com.ExecuteReader
        While dr.Read
            Dim ticket As New ListViewItem(dr.Item(0).ToString)
            ticket.SubItems.Add(dr.Item(2).ToString).ForeColor = Color.White
            f_queing.ListView5.Items.AddRange(New ListViewItem() {ticket})
            ticket.UseItemStyleForSubItems = False
        End While
        dr.Close()
    End Sub

    Sub queuing_reload_tb_motorcyle_tickets()
        f_queing.ListView6.Items.Clear()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_motorcycle_tickets order by id desc LIMIT 2 OFFSET 1;"
        dr = com.ExecuteReader
        While dr.Read
            Dim ticket As New ListViewItem(dr.Item(0).ToString)
            ticket.SubItems.Add(dr.Item(2).ToString).ForeColor = Color.White
            f_queing.ListView6.Items.AddRange(New ListViewItem() {ticket})
            ticket.UseItemStyleForSubItems = False
        End While
        dr.Close()
    End Sub


    '----- ACCOUNTS  -----'

    Sub create_tb_users()
        com.CommandText = "create table if not exists " & Form1.Label3.Text & ".tb_users (id int(100) auto_increment primary key, fullname char(200), address varchar(250), sex varchar(6), contactno varchar(11), emailaddress varchar(100),  designation varchar(100), usertype varchar(50), username varchar(100), password varchar(100), datereg varchar(100), status varchar(100), confirmedby varchar(100));"
        closereader()
    End Sub

    Sub insert_into_tb_users()
        com.CommandText = "insert into " & Form1.Label3.Text & ".tb_users (fullname,address,sex,contactno,emailaddress,designation,usertype,username,password,datereg,status,confirmedby)values('" & "ADMIN JOSHUA" & "','" & "BAGUIO" & "', '" & "MALE" & "','" & "09091234567" & "','" & "myemail@gmail.com" & "','" & "ADMIN" & "','" & "ADMIN" & "','" & "admin_josh" & "','" & "admin" & "','" & "2023-03-21" & "','" & "CONFIRMED" & "','" & "--" & "');"
        closereader()
    End Sub

    Sub insert_into_tb_users2()
        com.CommandText = "insert into " & Form1.Label3.Text & ".tb_users (fullname,address,sex,contactno,emailaddress,designation,usertype,username,password,datereg,status,confirmedby)values('" & "ED" & "','" & "BAGUIO" & "', '" & "MALE" & "','" & "09091234567" & "','" & "myemail@gmail.com" & "','" & "ADMIN 2" & "','" & "ADMIN" & "','" & "admin001" & "','" & "admin" & "','" & "2023-03-21" & "','" & "CONFIRMED" & "','" & "--" & "');"
        closereader()
    End Sub

    Sub insert_into_tb_users3()
        com.CommandText = "insert into " & Form1.Label3.Text & ".tb_users (fullname,address,sex,contactno,emailaddress,designation,usertype,username,password,datereg,status,confirmedby)values('" & "ED NEW" & "','" & "BAGUIO" & "', '" & "MALE" & "','" & "09091234567" & "','" & "myemail@gmail.com" & "','" & "CASHIER" & "','" & "CASHIER" & "','" & "admin" & "','" & "password" & "','" & "2023-03-21" & "','" & "NOT CONFIRMED" & "','" & "--" & "');"
        closereader()
    End Sub

    Sub insert_into_tb_users4()
        com.CommandText = "insert into " & Form1.Label3.Text & ".tb_users (fullname,address,sex,contactno,emailaddress,designation,usertype,username,password,datereg,status,confirmedby)values('" & "ED NEW" & "','" & "BAGUIO" & "', '" & "MALE" & "','" & "09091234567" & "','" & "myemail@gmail.com" & "','" & "CASHIER" & "','" & "CASHIER" & "','" & "user001" & "','" & "password" & "','" & "2023-03-21" & "','" & "CONFIRMED" & "','" & "--" & "');"
        closereader()
    End Sub

    Sub insert_into_tb_users_new()
        com.CommandText = "insert into " & Form1.Label3.Text & ".tb_users (fullname,address,sex,contactno,emailaddress,designation,usertype,username,password,datereg,status,confirmedby)values('" & f_login.TextBox3.Text & "','" & f_login.TextBox4.Text & "', '" & f_login.ComboBox1.Text & "','" & f_login.TextBox5.Text & "','" & f_login.TextBox6.Text & "','" & f_login.TextBox7.Text & "','" & f_login.ComboBox2.Text & "','" & f_login.TextBox8.Text & "','" & f_login.TextBox9.Text & "','" & f_login.Label20.Text & "','" & "NOT CONFIRMED" & "','" & "--" & "');"
        closereader()
    End Sub

    Sub reload_users()
        f_users.ListView1.Items.Clear()
        f_users.ListView1.BackColor = Color.Black
        com.CommandText = "select * from   " & Form1.Label3.Text & ".tb_users order by id desc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim user As New ListViewItem(dr.Item(0).ToString)
            Dim user_c As Integer
            For user_c = 1 To 12 Step 1
                If dr.Item(11).ToString = "NOT CONFIRMED" Then
                    user.SubItems.Add(dr.Item(user_c).ToString).BackColor = Color.Red
                Else
                    user.SubItems.Add(dr.Item(user_c).ToString).BackColor = Color.White
                End If
            Next
            f_users.ListView1.Items.AddRange(New ListViewItem() {user})
            user.UseItemStyleForSubItems = False
        End While
        f_users.Label5.Text = "ALL USERS: " & f_users.ListView1.Items.Count
        Form1.Button11.Text = "ALL USERS" & vbNewLine & "( " & f_users.ListView1.Items.Count & " )"
        dr.Close()
    End Sub

    Sub reload_users_NOTCONFIRMED()
        f_users.ListView1.Items.Clear()
        f_users.ListView1.BackColor = Color.Black
        com.CommandText = "select * from   " & Form1.Label3.Text & ".tb_users where status ='" & "NOT CONFIRMED" & "' order by id desc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim user As New ListViewItem(dr.Item(0).ToString)
            Dim user_c As Integer
            For user_c = 1 To 12 Step 1
                user.SubItems.Add(dr.Item(user_c).ToString).BackColor = Color.White
            Next
            f_users.ListView1.Items.AddRange(New ListViewItem() {user})
            user.UseItemStyleForSubItems = False
        End While
        f_users.Label6.Text = "PENDING USERS: " & f_users.ListView1.Items.Count
        Form1.Button12.Text = "NOT CONFIRMED" & vbNewLine & "( " & f_users.ListView1.Items.Count & " )"
        dr.Close()
    End Sub

    Sub reload_users_CONFIRMED()
        f_users.ListView1.Items.Clear()
        f_users.ListView1.BackColor = Color.Black
        com.CommandText = "select * from   " & Form1.Label3.Text & ".tb_users where status ='" & "CONFIRMED" & "' order by id desc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim user As New ListViewItem(dr.Item(0).ToString)
            Dim user_c As Integer
            For user_c = 1 To 12 Step 1
                user.SubItems.Add(dr.Item(user_c).ToString).BackColor = Color.White
            Next
            f_users.ListView1.Items.AddRange(New ListViewItem() {user})
            user.UseItemStyleForSubItems = False
        End While
        f_users.Label7.Text = "CONFIRMED USERS: " & f_users.ListView1.Items.Count
        Form1.Button13.Text = "CONFIRMED" & vbNewLine & "( " & f_users.ListView1.Items.Count & " )"
        dr.Close()
    End Sub

    Sub search_users()
        f_users.ListView1.Items.Clear()
        f_users.ListView1.BackColor = Color.Black
        com.CommandText = "select * from   " & Form1.Label3.Text & ".tb_users where fullname like '%" & f_users.TextBox1.Text & "%' or username like '%" & f_users.TextBox1.Text & "%' order by id desc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim user As New ListViewItem(dr.Item(0).ToString)
            Dim user_c As Integer
            For user_c = 1 To 12 Step 1
                user.SubItems.Add(dr.Item(user_c).ToString).BackColor = Color.White
            Next
            f_users.ListView1.Items.AddRange(New ListViewItem() {user})
            user.UseItemStyleForSubItems = False
        End While
        f_users.Label5.Text = "ALL USERS: " & f_users.ListView1.Items.Count
        dr.Close()
    End Sub

    Sub search_usertype()
        f_users.ListView1.Items.Clear()
        f_users.ListView1.BackColor = Color.Black
        com.CommandText = "select * from   " & Form1.Label3.Text & ".tb_users where usertype='" & f_users.ComboBox1.Text & "' order by id desc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim user As New ListViewItem(dr.Item(0).ToString)
            Dim user_c As Integer
            For user_c = 1 To 12 Step 1
                user.SubItems.Add(dr.Item(user_c).ToString).BackColor = Color.White
            Next
            f_users.ListView1.Items.AddRange(New ListViewItem() {user})
            user.UseItemStyleForSubItems = False
        End While
        f_users.Label5.Text = "ALL USERS: " & f_users.ListView1.Items.Count
        dr.Close()
    End Sub

    Sub search_datereg()
        f_users.ListView1.Items.Clear()
        f_users.ListView1.BackColor = Color.Black
        com.CommandText = "select * from   " & Form1.Label3.Text & ".tb_users where datereg='" & f_users.DateTimePicker1.Text & "' order by id desc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim user As New ListViewItem(dr.Item(0).ToString)
            Dim user_c As Integer
            For user_c = 1 To 12 Step 1
                user.SubItems.Add(dr.Item(user_c).ToString).BackColor = Color.White
            Next
            f_users.ListView1.Items.AddRange(New ListViewItem() {user})
            user.UseItemStyleForSubItems = False
        End While
        f_users.Label5.Text = "ALL USERS: " & f_users.ListView1.Items.Count
        dr.Close()
    End Sub

    Sub select_to_confirm()
        com.CommandText = "select * from  " & Form1.Label3.Text & ".tb_users where id='" & f_users.ListView1.FocusedItem.Text & "';"
        dr = com.ExecuteReader
        While dr.Read
            f_users.Label8.Text = dr.Item(0).ToString
            f_users.Label9.Text = dr.Item(11).ToString
            f_users.Label13.Text = dr.Item(8).ToString
        End While
        dr.Close()
    End Sub

    Sub update_to_confirm()
        com.CommandText = "update " & Form1.Label3.Text & ".tb_users set id ='" & f_users.Label8.Text & "', status ='" & "CONFIRMED" & "' where id ='" & f_users.Label8.Text & "';"
        closereader()
    End Sub

    Sub delete_an_accounts()
        com.CommandText = "delete from " & Form1.Label3.Text & ".tb_users where id='" & f_users.ListView1.FocusedItem.Text & "';"
        closereader()
    End Sub

    Sub find_existed_user()
        com.CommandText = "select * from " & Form1.Label3.Text & ".tb_users where username ='" & f_login.TextBox8.Text & "' or username ='" & f_login.TextBox1.Text & "' ;"
        dr = com.ExecuteReader
        While dr.Read
            f_login.Label21.Text = dr.Item(8).ToString
            f_login.Label6.Text = dr.Item(8).ToString
            f_login.Label5.Text = dr.Item(9).ToString
            f_login.Label17.Text = dr.Item(11).ToString
            Form1.ToolStripStatusLabel2.Text = dr.Item(7).ToString
            Form1.ToolStripStatusLabel4.Text = dr.Item(8).ToString
            Form1.ToolStripStatusLabel6.Text = dr.Item(1).ToString
        End While
        dr.Close()
    End Sub


End Module
