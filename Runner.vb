Public Class Runner 
  Implements Animateable 


  Public Property line As Line
  Public Property duration As Double 'in ms

  Public Property Offset As Drawing.Point Implements Positionable.Offset
  Public Property Pos As Drawing.Point Implements Animateable.Pos 
  Get
    Return line.getPoint (t)
  End Get
  Set(value  As Drawing.Point )
    
  End Set
  End Property

  Public sw As new Stopwatch
  Dim t As Double =  0

  Public Event Finished(sender as Runner) 

  Sub calc (time As Double ) Implements Calculateable.calc
    t = sw.ElapsedMilliseconds / duration 
    If t > 1
      sw.Reset 
      t= 0
      RaiseEvent Finished (Me) 
    End If
  End Sub

  Sub paint (g As Graphics ) Implements Drawable.draw
    If line is Nothing then Return 

    Dim p As Drawing.Point = line.getPoint (t) 
    g.FillEllipse  (Brushes.BlanchedAlmond ,New Rectangle(p.X -16 , p.Y - 16 ,32,32 )) 
  End Sub

End Class
