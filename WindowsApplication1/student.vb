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
    Private Sub NoDueList()
        Con.Open()
        Dim query = "select * from StudentTbl where StFees >= 100000"
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
    Private Sub Clear()
        StnameTb.Text = ""
        FeesTb.Text = ""
        PhoneTb.Text = ""
        GenCb.SelectedIndex = 0
        DepCb.SelectedIndex = 0
    End Sub
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
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub

    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        Clear()
    End Sub
    Dim key = 0
    Private Sub StudentDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles StudentDGV.CellMouseClick
        Dim row As DataGridViewRow = StudentDGV.Rows(e.RowIndex)
        StnameTb.Text = row.Cells(1).Value.ToString
        GenCb.SelectedItem = row.Cells(2).Value.ToString
        STDOB.Text = row.Cells(3).Value.ToString
        PhoneTb.Text = row.Cells(4).Value.ToString
        DepCb.SelectedValue = row.Cells(5).Value.ToString
        FeesTb.Text = row.Cells(6).Value.ToString
        If StnameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If key = 0 Then

            MsgBox("Select the Student")

        Else

            Try
                Con.Open()
                Dim query = "delete from StudentTbl where StId = " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Student Deleted")
                Con.Close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        If StnameTb.Text = "" Or FeesTb.Text = "" Or PhoneTb.Text = "" Or GenCb.SelectedIndex = -1 Or DepCb.SelectedIndex = -1 Then

            MsgBox("Missing Informatin")

        Else

            Try
                Con.Open()
                Dim query = "update StudentTbl set StName='" & StnameTb.Text & "',StGender='" & GenCb.SelectedItem.ToString() & "',StDOB='" & STDOB.Text & "',StPhone='" & PhoneTb.Text & "',StDep='" & DepCb.SelectedValue.ToString() & "',StFees=" & FeesTb.Text & " where Stid= " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Student Updated")
                Con.Close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        NoDueList()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Display()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim Obj = New controls()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim Obj = New Teachers()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Dim Obj = New Departments()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim Obj = New Fees()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Dim Obj = New Dashboard()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub StudentDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles StudentDGV.CellContentClick

    End Sub
End Class