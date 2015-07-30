Public Class Rule
Implements Drawable 

  Public Property target As State

  Public Property token As String = "Empty"

  Public Property Line As new Line 

Public Sub new (source As State , target As State )
  Line.Points.Add (New Point (source.Pos , source.locator ))
  Line.Points.Add (New Point (source.pos.X / 2 + target.Pos.X /2 ,  source.pos.Y/ 2 + target.Pos.Y/2  ))
  Line.Points.Add (New Point (target.Pos , target.locator ))

End Sub

  'returns all controls
  Public Function getControls As list (of Control ) 
    Return Line.Points.Select (Of Control ) (Function (p As Point ) p.mover ).ToList 
  End Function


Public Sub draw(g As Graphics) Implements Drawable.draw
  If Not IsNothing (Line) then Line.draw (g) 
End Sub

End Class
