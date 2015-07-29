Public Class State 
Implements Drawable, Positionable 


  

#region  "Positionable Implementations"
Dim m_pos As New  Drawing.Point (10,10) 
  Public Property Offset As Drawing.Point Implements Positionable.Offset
  Public Property Pos As Drawing.Point Implements Positionable.Pos 
  Get
    Return m_pos 
  End Get
  Set(value As Drawing.Point)
    m_pos = value 
    locator.Pos =  value 
    connector.Pos = value

  For Each l As Line In outs 
    l.Points(0).Pos = value 
  Next

  For Each l As Line In ins
    l.Points(l.Points.Count - 1).Pos = value 
  Next


  End Set
  End Property

#End Region '"Positionable Implementations"
  Public Property Name = "1"

  Dim locator As new InteractiveLocation (Me ) 
  Dim connector As New InteractiveConnect (Me)

  Public outs As new List(Of Line)
  Public ins As New List(Of Line) 


  Public Sub new
    locator.BackColor = Color.AliceBlue 
    locator.Width = 10
    locator.Height = 10
    locator.Offset = New Drawing.Point (20/2 - locator.Width /2, _ 
                                20/2 - locator.Height /2) 'center of state circle - center of locator

    connector.BackColor = Color.Aqua 
    connector.Width = 10
    connector.Height = 10
  End Sub


  Public Function getInteractiveLocation() As InteractiveLocation 
    Return locator 
  End Function

  Public function getInteractiveConenct() As InteractiveConnect 
    Return connector 
  End Function

  Public Sub draw(g As Graphics) Implements Drawable.draw
    g.DrawEllipse (Pens.Black  , New Rectangle (Pos,New Size (20,20)))

    For Each l As Line In outs 
      l.draw (g) 
    Next

   ' outs.ForEach (Function (l As Line ) l.draw (g) )
  End Sub



End Class
