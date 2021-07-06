Imports System.Data.SqlClient

Public Class Fees
    Dim Con = New SqlConnection("Data Source=DESKTOP-AJ4AVKP;Initial Catalog=CollageDb;Integrated Security=True")
    Private Sub FillStudent()
        Con.Open()
        Dim query = "select * from StudentTbl"
        Dim cmd As New SqlCommand(query, Con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        StIdCb.DataSource = Tbl
        StIdCb.DisplayMember = "StId"
        StIdCb.ValueMember = "StId"
        Con.Close()
    End Sub
    Private Sub Display()
        Con.Open()
        Dim query = "select * from PaymentTbl"
        Dim adapter As SqlDataAdapter
        Dim cmd = New SqlCommand(query, Con)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        FeesDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Clear()
        AmountTb.Text = ""
        StNameTb.Text = ""
        StIdCb.SelectedIndex = -1
    End Sub
    Private Sub UpdateStudent()
        Try
            Con.Open()
            Dim query = "update StudentTbl set StFees=" & AmountTb.Text & " where Stid= " & StIdCb.SelectedValue.ToString() & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Student Updated")
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PayBtn_Click(sender As Object, e As EventArgs) Handles PayBtn.Click
        If StNameTb.Text = "" Or AmountTb.Text = "" Then

            MsgBox("Missing Informatin")
        ElseIf Convert.ToInt32(AmountTb.Text) > 100000 Or Convert.ToInt32(AmountTb.Text) < 1 Then
            MsgBox("Wrong Amount")
        Else

            Try
                Con.Open()
                Dim query = "insert into PaymentTbl values(" & StIdCb.SelectedValue.ToString() & ",'" & StNameTb.Text & "', '" & Period.Value.Date & "', " & AmountTb.Text & ")"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Payment Successfull")
                Con.Close()
                Display()
                UpdateStudent()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub
    Private Sub GetStName()
        Con.Open()
        Dim query = "select * from StudentTbl where StId=" & StIdCb.SelectedValue.ToString() & ""
        Dim cmd As New SqlCommand(query, Con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            StNameTb.Text = reader(1).ToString()
        End While
        Con.Close()
    End Sub
    Private Sub Fees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
        FillStudent()
    End Sub

    Private Sub StIdCb_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles StIdCb.SelectionChangeCommitted
        GetStName()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim Obj = New login()
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
        Dim Obj = New student()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Dim Obj = New Dashboard()
        Obj.Show()
        Me.Hide()
    End Sub
End Class