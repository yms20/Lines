Public Class Form1

Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
ToolStripComboBox1.Text = "11001010"
End Sub




  Public Sub startStateMachine
    Dim instruction  As new Queue(Of String ) 

    Dim inputString As String = ToolStripComboBox1.Text 
    Dim seet as new HashSet(Of Char ) 

    For i As Integer = 0 to inputString.Length - 1 
      seet.Add (inputString.Chars(i)) 
      instruction.Enqueue (inputString.Chars(i)) 
    Next

    Canvas1.startStateMachine (instruction) 
  End Sub

'Toolstrip2 - Canvas Mode Select 

Private Sub ToolStripButton2_Click( sender As Object,  e As EventArgs) Handles ToolStripButton2State.Click
  Canvas1.Mode = Canvas.Modes.AddState 
End Sub

Private Sub ToolStripButton1_Click( sender As Object,  e As EventArgs) Handles ToolStripButton1Line.Click
  Canvas1.Mode = Canvas.Modes.AddLine 
End Sub


Private Sub ToolStripButton4Select_Click( sender As Object,  e As EventArgs) Handles ToolStripButton4Select.Click
  Canvas1.Mode = Canvas.Modes.Select 
End Sub

Private Sub ToolStrip2UncheckOthers( sender As Object,  e As ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked
  For Each t As ToolStripButton In ToolStrip2.Items
    If t is sender
      Continue For
    End If
    t.Checked = False 
  Next
End Sub

'Toolstrip 1 - Input and start
Private Sub ToolStripButton3_Click( sender As Object,  e As EventArgs) Handles ToolStripButton3Play.Click
  startStateMachine 
End Sub

Private Sub ToolStripComboBox1_KeyDown( sender As Object,  e As KeyEventArgs) Handles ToolStripComboBox1.KeyDown
  Select e.KeyCode 
    Case Keys.Enter
      If Not ToolStripComboBox1.Items.Contains (ToolStripComboBox1.Text ) 
        ToolStripComboBox1.Items.Add(ToolStripComboBox1.Text )   
      End If
      startStateMachine
  End Select
End Sub





End Class
