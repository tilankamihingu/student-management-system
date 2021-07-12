Public Class login

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        UnameTb.Text = ""
        PasswordTb.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If UnameTb.Text = "" Or PasswordTb.Text = "" Then
            MsgBox("Enter Username and Password")

        ElseIf UnameTb.Text = "Admin" And PasswordTb.Text = "Password" Then
            Dim Obj = New student
            Obj.Show()
            Me.Hide()
        Else
            MsgBox("Wrong Username or Password")
            UnameTb.Text = ""
            PasswordTb.Text = ""
        End If
    End Sub
End Class