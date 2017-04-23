Public Class Output_Settings
    Private Sub Output_Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.saveFormat
        If TextBox1.Text.Contains("%song") Or TextBox1.Text.Contains("%Song") Then
            Button1.Enabled = True
            Button1.Text = "Save"
        Else
            Button1.Enabled = False
            Button1.Text = "%song is required"
        End If
    End Sub

    Function preview()
        Dim format As String
        If Form1.readText = "" Then
            format = TextBox1.Text.Replace("%song", "(Song Name Here)")
        Else
            format = TextBox1.Text.Replace("%song", Form1.readText)
        End If

        Label1.Text = format

    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        preview()
        If TextBox1.Text.Contains("%song") Or TextBox1.Text.Contains("%Song") Then
            Button1.Enabled = True
            Button1.Text = "Save"
        Else
            Button1.Enabled = False
            Button1.Text = "%song is required"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.saveFormat = TextBox1.Text
        Me.Close()
    End Sub
End Class