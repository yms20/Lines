Public Class Form1

Public Shared instance As PropertyGrid 



Private Sub ToolStripButton3_Click( sender As Object,  e As EventArgs) Handles ToolStripButton3.Click
  
  Dim instruction  As new Queue(Of String ) 

  Dim inputString As String = ToolStripComboBox1.Text 
  Dim seet as new HashSet(Of Char ) 

  For i As Integer = 0 to inputString.Length - 1 
    seet.Add (inputString.Chars(i)) 
    instruction.Enqueue (inputString.Chars(i)) 
  Next


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

Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
 instance = PropertyGrid1 
End Sub


Private Sub ToolStripComboBox1_KeyDown( sender As Object,  e As KeyEventArgs) Handles ToolStripComboBox1.KeyDown
  Select e.KeyCode 
    Case Keys.Enter
      If Not ToolStripComboBox1.Items.Contains (ToolStripComboBox1.Text ) 
        ToolStripComboBox1.Items.Add(ToolStripComboBox1.Text ) 
      End If
  End Select
End Sub
End Class
