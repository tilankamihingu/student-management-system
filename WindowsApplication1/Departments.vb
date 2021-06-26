Imports System.Data
Imports System.Data.SqlClient

Public Class Departments
    Private Sub Savebtn_Click(sender As Object, e As EventArgs) Handles Savebtn.Click
        If DepNameTb.Text = "" Or DescTb.Text = "" Or DurationTb.Text = "" Then

            MsgBox("Missing Informatin")

        Else

            Try
                Dim Con As SqlConnection = New SqlConnection("Data Source=DESKTOP-AJ4AVKP;Initial Catalog=CollageDb;Integrated Security=True")
                Dim cmd As SqlCommand = New SqlCommand("INSERT INTO [dbo].[DepartmentTbl]([DepName],[DepDesc],[DepDur]) VALUES('" + DepNameTb.Text + "','" + DescTb.Text + "','" + DurationTb.Text + "')", Con)
                Con.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Department Saved")
                Con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub
End Class