Imports System.Data.SqlClient

Public Class Form1
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Dim i As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Insert_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim para(1) As SqlParameter
        para(0) = New SqlParameter("@name", SqlDbType.VarChar)
        para(0).Value = TextBox1.Text

        para(1) = New SqlParameter("@city", SqlDbType.VarChar)
        para(1).Value = TextBox2.Text

        Dim com As New SqlCommand()
        com.Connection = con
        com.CommandType = CommandType.StoredProcedure
        com.CommandText = "mamu"
        com.Parameters.AddRange(para)
        'con.Open()

        com.ExecuteNonQuery()

        'con.Close()






        'cmd = con.CreateCommand()
        'cmd.CommandType = CommandType.StoredProcedure
        'cmd.CommandText = "Insert into table1 values('" + TextBox1.Text + "','" + TextBox2.Text + "')"
        'cmd.ExecuteNonQuery()

        'dis_data()

        'TextBox1.Text = ""
        'TextBox2.Text = ""



        'Dim aa As New SqlDataAdapter("Insert", con)
        'aa.SelectCommand.CommandType = CommandType.StoredProcedure
        'aa.SelectCommand.Parameters.Add("").va


        MessageBox.Show("Record Inserted Successfully")

    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.ConnectionString = "Server = DESKTOP-EES6UNB\SMSQLSERVER; Database = StdData; Integrated Security = True"
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        dis_data()
    End Sub



    Public Sub dis_data()

        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from Student"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub




    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()

        i = Convert.ToInt32(DataGridView1.SelectedCells.Item(0).Value.ToString())

        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from Student where id=" & i & ""
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        Dim dr As SqlClient.SqlDataReader
        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        While dr.Read
            TextBox1.Text = dr.GetString(1).ToString()
            TextBox2.Text = dr.GetString(2).ToString()
        End While



    End Sub

    Private Sub Update_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()

        'cmd = con.CreateCommand()
        'cmd.CommandType = CommandType.Text
        'cmd.CommandText = "Update table1 set name='" + TextBox1.Text + "',city='" + TextBox2.Text + "' where id=" & i & ""
        'cmd.ExecuteNonQuery()

        Dim para(2) As SqlParameter
        para(0) = New SqlParameter("@id", SqlDbType.VarChar)
        para(0).Value = i

        para(1) = New SqlParameter("@name", SqlDbType.VarChar)
        para(1).Value = TextBox1.Text

        para(2) = New SqlParameter("@city", SqlDbType.VarChar)
        para(2).Value = TextBox2.Text

        Dim com As New SqlCommand()
        com.Connection = con
        com.CommandType = CommandType.StoredProcedure
        com.CommandText = "update"
        com.Parameters.AddRange(para)
        'con.Open()

        com.ExecuteNonQuery()

        dis_data()

        MessageBox.Show("Record Updated Successfully")

    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()

        'cmd = con.CreateCommand()
        'cmd.CommandType = CommandType.Text
        'cmd.CommandText = "Delete from table1 where name='" + TextBox1.Text + "'"
        'cmd.ExecuteNonQuery()

        Dim para(0) As SqlParameter

        para(0) = New SqlParameter("@name", SqlDbType.VarChar)
        para(0).Value = TextBox1.Text



        Dim com As New SqlCommand()
        com.Connection = con
        com.CommandType = CommandType.StoredProcedure
        com.CommandText = "delete"
        com.Parameters.AddRange(para)
        'con.Open()

        com.ExecuteNonQuery()

        dis_data()

    End Sub

    Private Sub Display_Click(sender As Object, e As EventArgs) Handles Button4.Click
        dis_data()

    End Sub

    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Button5.Click

        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from table1 where id='" + TextBox1.Text + "'"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub
End Class
