Public Class Form1

Private Sub ToolStripButton2_Click( sender As Object,  e As EventArgs) Handles ToolStripButton2.Click
  Canvas1.Mode = Canvas.Modes.AddState 
End Sub

Private Sub ToolStripButton1_Click( sender As Object,  e As EventArgs) Handles ToolStripButton1.Click
  Canvas1.Mode = Canvas.Modes.AddLine 
End Sub
End Class
