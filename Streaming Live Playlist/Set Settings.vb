Imports System.Windows.Forms

Public Class Set_Settings

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        My.Settings.TxtLoc = TextBox1.Text
        My.Settings.saveLoc = TextBox2.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fd.Title = "Select Source TXT"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|.TXT (*.txt*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = fd.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Set_Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OK_Button.Enabled = False
        TextBox1.Text = My.Settings.TxtLoc
        TextBox2.Text = My.Settings.saveLoc
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            OK_Button.Enabled = True
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Timer1.Enabled = True
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Timer1.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    End Sub
End Class
