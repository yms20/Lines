Public Class Rule
Implements Drawable , Controllable

Public Event ControlAdded(c As Control) Implements Controllable.ControlAdded

  'returns all controls
  Public Function getControls As list (of Control ) Implements Controllable.getControls
    Return Line.Points.Select (Of Control ) (Function (p As Point ) p.mover ).ToList 
  End Function

  
  Public Property source As State
  Public Property target As State

  Public Property token As String = "Empty"

  Public Property Line As new Line 
  Public Property rulator As InteractiveRuleEdit


Public Sub new (source As State , target As State )
  Me.source = source 
  Me.target = target 
End Sub

'call this method after creating object and connecting Listener to it
Public Sub initLine

  Line.Points.Add (New Point (source.Pos , source.locator ))
  Dim middlePoint As Point = New Point (source.pos.X / 2 + target.Pos.X /2 ,  source.pos.Y/ 2 + target.Pos.Y/2  )
  Line.Points.Add (middlePoint )
  RaiseEvent ControlAdded (middlePoint.mover ) 
  Line.Points.Add (New Point (target.Pos , target.locator ))

  rulator = New InteractiveRuleEdit (Me) 
  rulator.Pos = Line.getPoint (0.15) 
  rulator.Visible = True 
  RaiseEvent ControlAdded (rulator )
End Sub


Public Sub draw(g As Graphics) Implements Drawable.draw
  rulator.Offset = Line.getPoint (0.15) - Line.Points (0).pt  
  If Not IsNothing (Line) then Line.draw (g) 
End Sub


 
End Class
