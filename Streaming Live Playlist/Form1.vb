Imports System.IO



Public Class Form1

    Public readText As String = ""

    Private Sub form1_shown() Handles MyBase.Shown

        If String.IsNullOrEmpty(My.Settings.TxtLoc) Then
            MsgBox(My.Settings.TxtLoc)
            Hide()
            Visible = False
            Set_Settings.Show()
        End If
        If String.IsNullOrEmpty(My.Settings.saveLoc) Then
            Hide()
            Visible = False
            Set_Settings.Show()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Off"
        Button1.Text = "Start"

        ListBox1.SelectedItem = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Timer1.Enabled = True Then
            Timer1.Enabled = False
            Me.Text = "Off"
            Button1.Text = "Start"
        ElseIf Timer1.Enabled = False Then
            Timer1.Enabled = True
            Me.Text = "Running"
            Button1.Text = "Stop"
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ListBox1.Items.Count = 25 Then
            ListBox1.Items.RemoveAt(0)
        End If
        Try
            If File.ReadAllText(Streaming_Live_Playlist.My.Settings.TxtLoc) <> readText Then
                readText = File.ReadAllText(Streaming_Live_Playlist.My.Settings.TxtLoc)
                ListBox1.Items.Add(readText)
                ListBox1.SelectedItem = readText

                Using outputFile As New StreamWriter(Streaming_Live_Playlist.My.Settings.saveLoc + ("\SongLog.txt"), True)
                    outputFile.WriteLine(My.Settings.saveFormat.Replace("%song", readText))
                End Using
            End If
        Catch ex As IOException
        End Try
    End Sub

    Private Sub FilepathsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilepathsToolStripMenuItem.Click
        Set_Settings.Show()
    End Sub

    Private Sub OutputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutputToolStripMenuItem.Click
        Output_Settings.Show()
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub
End Class