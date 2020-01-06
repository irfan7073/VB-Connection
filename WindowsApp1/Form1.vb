Imports System.Data.SqlClient

Public Class Form1
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Dim i As Integer




    Private Sub Insert_Click(sender As Object, e As EventArgs) Handles Button1.Click

        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Insert into table1 values('" + TextBox1.Text + "','" + TextBox2.Text + "')"
        cmd.ExecuteNonQuery()

        dis_data()

        TextBox1.Text = ""
        TextBox2.Text = ""


        MessageBox.Show("Record Inserted Successfully")

    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\vbconnection\WindowsApp1\WindowsApp1\vbdatabase.mdf;Integrated Security=True"
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        dis_data()
    End Sub



    Public Sub dis_data()

        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from table1"
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
        cmd.CommandText = "select * from table1 where id=" & i & ""
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

        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Update table1 set name='" + TextBox1.Text + "',city='" + TextBox2.Text + "' where id=" & i & ""
        cmd.ExecuteNonQuery()

        dis_data()

        MessageBox.Show("Record Updated Successfully")

    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()

        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Delete from table1 where name='" + TextBox1.Text + "'"
        cmd.ExecuteNonQuery()

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
