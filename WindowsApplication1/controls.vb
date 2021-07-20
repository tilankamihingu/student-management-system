Public Class controls

    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        Dim Obj = New Dashboard()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub CoursesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CoursesToolStripMenuItem.Click
        Dim Obj = New login()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub PaymentsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim Obj = New Fees()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim Obj = New student()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub LectureToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim Obj = New Teachers()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim Obj = New student()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim Obj = New Teachers()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs)
        Dim Obj = New Dashboard()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim Obj = New Departments()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Dim Obj = New Fees()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim Obj = New login()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub controls_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class