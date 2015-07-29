Public Class State 
Implements Drawable, Positionable 


  Dim m_pos As New  Point (10,10) 
  Public Property pos As Point Implements Positionable.pos 
  Get
    Return m_pos 
  End Get
  Set(value As Point)
    m_pos = value 
    locator.Pos =  value 
    connector.Pos = value
  End Set
  End Property
  Public Property Name = "1"
  
  Dim locator As new InteractiveLocation (AddressOf setLocation ) 
  Dim connector As New InterActiveConnect ()
  Public Sub new
    locator.BackColor = Color.AliceBlue 
    locator.Width = 10
    locator.Height = 10
    locator.Offset = New Point (20/2 - locator.Width /2, _ 
                                20/2 - locator.Height /2) 'center of state circle - center of locator

    connector.BackColor = Color.Aqua 
    connector.Width = 10
    connector.Height = 10

  End Sub

  Public Function getInteractiveLocation() As InteractiveLocation 
    Return locator 
  End Function

  Public function getInteractiveConenct() As InterActiveConnect 
    Return connector 
  End Function
  

  Function setLocation(loc As Point )  As InteractiveLocation.setLocation 
    m_pos = loc 
    connector.Pos = loc 
    locator.Pos = loc
Return Nothing 
  End Function

  Public Sub draw(g As Graphics) Implements Drawable.draw
    g.DrawEllipse (Pens.Black  , New Rectangle (pos,New Size (20,20)))
  End Sub

Public Property Offset As Point Implements Positionable.Offset

Public Property Pos1 As Point 
End Class
