Imports System.Data.SqlClient

Public Class Teachers
    Dim Con = New SqlConnection("Data Source=DESKTOP-AJ4AVKP;Initial Catalog=CollageDb;Integrated Security=True")
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
        Dim query = "select * from TeacherTbl"
        Dim adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, Con)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        TeacherDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Clear()
        TnameTb.Text = ""
        GenCb.SelectedIndex = 0
        AddTb.Text = ""
        PhoneTb.Text = ""
        DepCb.SelectedIndex = 0
    End Sub
    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If TnameTb.Text = "" Or AddTb.Text = "" Or PhoneTb.Text = "" Or GenCb.SelectedIndex = -1 Or DepCb.SelectedIndex = -1 Then

            MsgBox("Missing Informatin")

        Else

            Try
                Con.Open()
                Dim query = "insert into TeacherTbl values('" & TnameTb.Text & "', '" & GenCb.SelectedItem.ToString() & "', '" & TDOB.Value.Date & "','" & PhoneTb.Text & "','" & DepCb.SelectedValue.ToString() & "','" & AddTb.Text & "')"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Teacher Saved")
                Con.Close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub Teachers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
        FillDepartment()
    End Sub

    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        Clear()
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If key = 0 Then

            MsgBox("Select the Teacher")

        Else

            Try
                Con.Open()
                Dim query = "delete from TeacherTbl where TId = " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Teacher Deleted")
                Con.Close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub
    Dim key = 0
    Private Sub TeacherDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles TeacherDGV.CellMouseClick
        Dim row As DataGridViewRow = TeacherDGV.Rows(e.RowIndex)
        TnameTb.Text = row.Cells(1).Value.ToString
        GenCb.SelectedItem = row.Cells(2).Value.ToString
        TDOB.Text = row.Cells(3).Value.ToString
        PhoneTb.Text = row.Cells(4).Value.ToString
        DepCb.SelectedValue = row.Cells(5).Value.ToString
        AddTb.Text = row.Cells(6).Value.ToString
        If TnameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        If TnameTb.Text = "" Or AddTb.Text = "" Or PhoneTb.Text = "" Or GenCb.SelectedIndex = -1 Or DepCb.SelectedIndex = -1 Then

            MsgBox("Missing Informatin")

        Else

            Try
                Con.Open()
                Dim query = "update TeacherTbl set TName='" & TnameTb.Text & "',TGender='" & GenCb.SelectedItem.ToString() & "',TDOB='" & TDOB.Text & "',TPhone='" & PhoneTb.Text & "',TDep='" & DepCb.SelectedValue.ToString() & "',TAdd='" & AddTb.Text & "' where TId= " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Teacher Updated")
                Con.Close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim Obj = New login()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Dim Obj = New Dashboard()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim Obj = New Fees()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Dim Obj = New Departments()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim Obj = New student()
        Obj.Show()
        Me.Hide()
    End Sub
End Class