<Serializable > _
Public Class Canvas

Public Drawables  As New  Generic.List(Of Drawable  ) 

Dim Runners As New Generic.List(Of Calculateable )

Dim current As new Line 
dim lastMousePos as new Drawing.Point 

Public Property Mode As Modes 
Event createdStartable (sender as Canvas, baby As Line)


Public Enum Modes
AddLine
AddState
[Select]
End Enum

Public sub addRunner ( l As Line )
  Dim r As new Runner 
  r.duration = 5000
  r.line = l
  r.sw.Start
  AddHandler r.Finished, AddressOf removeRunner
  Runners.Add (r) 
End Sub


Public Sub removeRunner ( r As Runner ) 
 Runners.Remove (r ) 
End Sub

Sub addLine(e As MouseEventArgs)
  Select (e.Button ) 
    Case Windows.Forms.MouseButtons.Left :
      current.Points.Add( New Point ( e.Location ) ) 
    Case Windows.Forms.MouseButtons.Right :
      Drawables.Add (current )
      RaiseEvent createdStartable (Me,current ) 
      Me.Controls.AddRange (current.PointControls.ToArray ) 
      current.showPoints 
      current = New Line 
  End Select
End Sub


Private Sub Canvas_MouseClick( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseClick

  Select Me.Mode 
    Case Modes.AddLine 
      addLine(e)
    Case Modes.AddState 
      Dim s As New State 
      AddHandler s.ControlAdded , AddressOf addControl 
      s.initController 
      s.locator.Pos  = e.Location 
      Drawables.Add (s) 
  End Select
End Sub

Sub addControl (c As Control )
  Me.Controls.Add (c) 
End Sub


Public Function  startStateMachine (instruction As queue(Of String ) ) As State 
  
  For Each d As Drawable In Drawables
    If d.GetType is GetType (State)
      Dim s As State = d
      s.applyWork (instruction ) 
      Return s 
      Exit For 
    End If
  Next

End Function 

Protected Overrides Sub OnPaint(e As PaintEventArgs)
MyBase.OnPaint(e)


Select Me.Mode 
Case Modes.AddLine
  If current.Points.Count > 0 
    current.draw (e.Graphics ) 
    Dim lp As Drawing.Point = current.Points(current.Points.Count -1 ).pt
    e.Graphics.DrawLine ( Pens.AliceBlue, lp, lastMousePos)
    e.Graphics.DrawString (String.Format ("L:{0:0.00}",current.length), SystemFonts.MessageBoxFont  ,Brushes.AliceBlue,new PointF( lp.X ,lp.Y )  ) 
    Dim deltaLength As Double = current.length + Math.Sqrt ( Math.Pow (lp.X - lastMousePos.X,2) + Math.Pow (lp.Y - lastMousePos.Y,2) )
    e.Graphics.DrawString (String.Format ("L:{0:0.00}",deltaLength), SystemFonts.MessageBoxFont  ,Brushes.AliceBlue,new PointF( lastMousePos.X ,lastMousePos.Y )  ) 
  End If
End Select




  For Each r As Runner In Runners 
    r.paint (e.Graphics) 
  Next

  For Each Line As Drawable  In Drawables 
    Line.draw ( e.Graphics ) 
  Next


End Sub

Private Sub Canvas_MouseMove( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseMove
  lastMousePos = e.Location 
   
End Sub

'calculate and paint objecet
Private Sub TimerRefresh_Tick( sender As Object,  e As EventArgs) Handles TimerRefresh.Tick

  For i As Integer = Runners.Count to 1 Step -1 
    runners(i-1).calc (0)
  Next
  Refresh
End Sub

 
End Class
