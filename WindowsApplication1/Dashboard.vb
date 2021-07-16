Imports System.Data.SqlClient

Public Class Dashboard
    Dim Con = New SqlConnection("Data Source=DESKTOP-AJ4AVKP;Initial Catalog=CollageDb;Integrated Security=True")
    Private Sub CountStud()
        Dim StNum As Integer
        Con.Open()
        Dim sql = "select COUNT(*) from StudentTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, Con)
        StNum = cmd.ExecuteScalar
        StdLbl.Text = StNum
        Con.Close()
    End Sub
    Private Sub CountTeachers()
        Dim TNum As Integer
        Con.Open()
        Dim sql = "select COUNT(*) from TeacherTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, Con)
        TNum = cmd.ExecuteScalar
        TeacherLbl.Text = TNum
        Con.Close()
    End Sub
    Private Sub CountDep()
        Dim DepNum As Integer
        Con.Open()
        Dim sql = "select COUNT(*) from DepartmentTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, Con)
        DepNum = cmd.ExecuteScalar
        DepLbl.Text = DepNum
        Con.Close()
    End Sub
    Private Sub SumFees()
        Dim FeesAmount As Integer
        Con.Open()
        Dim sql = "select Sum(Amount) from PaymentTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, Con)
        FeesAmount = cmd.ExecuteScalar
        Dim Am As String
        Am = Convert.ToString(FeesAmount)
        FeesLbl.Text = "Rs" + Am
        Con.Close()
    End Sub
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CountStud()
        CountTeachers()
        CountDep()
        SumFees()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
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
        Dim Obj = New student()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim Obj = New Fees()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Dim Obj = New Departments()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub StdLbl_Click(sender As Object, e As EventArgs) Handles StdLbl.Click

    End Sub
End Class