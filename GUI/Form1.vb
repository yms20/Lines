Public Class Form1

Private Sub ToolStripButton3_Click( sender As Object,  e As EventArgs) Handles ToolStripButton3.Click
  
  Dim instruction  As new Queue(Of String ) 
  instruction.Enqueue ("Test")
  instruction.Enqueue ("Test")
  instruction.Enqueue ("Test")



  For Each d As Drawable In Canvas1.Drawables
    If d.GetType is GetType (State)
      Dim s As State = d
      s.applyWork (instruction ) 
      Exit For 
    End If
  Next

End Sub

Private Sub ToolStripButton2_Click( sender As Object,  e As EventArgs) Handles ToolStripButton2.Click
  Canvas1.Mode = Canvas.Modes.AddState 
End Sub

Private Sub ToolStripButton1_Click( sender As Object,  e As EventArgs) Handles ToolStripButton1.Click
  Canvas1.Mode = Canvas.Modes.AddLine 
End Sub
End Class
