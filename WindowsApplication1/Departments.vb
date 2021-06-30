Imports System.Data
Imports System.Data.SqlClient

Public Class Departments
    Dim Con = New SqlConnection("Data Source=DESKTOP-AJ4AVKP;Initial Catalog=CollageDb;Integrated Security=True")
    Private Sub Display()
        Con.Open()
        Dim query = "select * from DepartmentTbl"
        Dim adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, Con)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DepartmentDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Savebtn_Click(sender As Object, e As EventArgs) Handles Savebtn.Click
        If DepNameTb.Text = "" Or DescTb.Text = "" Or DurationTb.Text = "" Then

            MsgBox("Missing Informatin")

        Else

            Try
                Con.Open()
                Dim query = "insert into DepartmentTbl values('" & DepNameTb.Text & "', '" & DescTb.Text & "', " & DurationTb.Text & ")"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Department Saved")
                Con.Close()
                Display()
                Reset()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub

    Private Sub Departments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub
    Private Sub Reset()
        DepNameTb.Text = ""
        DurationTb.Text = ""
        DescTb.Text = ""
    End Sub
    Private Sub Resetbtn_Click(sender As Object, e As EventArgs) Handles Resetbtn.Click
        Reset()
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If key = 0 Then

            MsgBox("Select the Department")

        Else

            Try
                Con.Open()
                Dim query = "delete from DepartmentTbl where DepId = " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Department Deleted")
                Con.Close()
                Display()
                Reset()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub
    Dim key = 0
    Private Sub DepartmentDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DepartmentDGV.CellMouseClick
        Dim row As DataGridViewRow = DepartmentDGV.Rows(e.RowIndex)
        DepNameTb.Text = row.Cells(1).Value.ToString
        DescTb.Text = row.Cells(2).Value.ToString
        DurationTb.Text = row.Cells(3).Value.ToString
        If DepNameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        If DepNameTb.Text = "" Or DescTb.Text = "" Or DurationTb.Text = "" Then

            MsgBox("Missing Informatin")

        Else

            Try
                Con.Open()
                Dim query = "update departmentTbl set DepName='" & DepNameTb.Text & "',DepDesc='" & DescTb.Text & "',DepDur=" & DurationTb.Text & " where DepId= " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Department Updated")
                Con.Close()
                Display()
                Reset()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub
End Class