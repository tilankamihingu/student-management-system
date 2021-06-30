Imports System.Data.SqlClient

Public Class student
    Dim Con = New SqlConnection("Data Source=DESKTOP-AJ4AVKP;Initial Catalog=CollageDb;Integrated Security=True")
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GenCb.SelectedIndexChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles FeesTb.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles PhoneTb.TextChanged

    End Sub

    Private Sub student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDepartment()
        Display()
    End Sub
    Private Sub FillDepartment()
        Con.Open()
        Dim query = "select * from DepartmentTbl"
        Dim cmd As New SqlCommand(query, Con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        DepCb.DataSource = Tbl
        DepCb.DisplayMember = "DepName"
        DepCb.ValueMember = "DepName"
        Con.Close()
    End Sub
    Private Sub Display()
        Con.Open()
        Dim query = "select * from StudentTbl"
        Dim adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, Con)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        StudentDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub 
    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If StnameTb.Text = "" Or FeesTb.Text = "" Or PhoneTb.Text = "" Or GenCb.SelectedIndex = -1 Or DepCb.SelectedIndex = -1 Then

            MsgBox("Missing Informatin")

        Else

            Try
                Con.Open()
                Dim query = "insert into StudentTbl values('" & StnameTb.Text & "', '" & GenCb.SelectedItem.ToString() & "', '" & STDOB.Value.Date & "','" & PhoneTb.Text & "','" & DepCb.SelectedValue.ToString() & "'," & FeesTb.Text & ")"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Student Saved")
                Con.Close()
                Display()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub
End Class