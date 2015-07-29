'Wrapper Klasse für Point
Public Class   Point
Implements Positionable

public Dim mover As InteractiveLocation

#Region "Wrapper Methods"

  Public pt As Drawing.Point 'it's a structure!


  Public Sub new (il As InteractiveLocation)
    mover = il 
    mover.children.Add (Me) 
  End Sub


  Public Sub new ()
    Me.New (new InteractiveLocation () ) 
  End Sub

  Public sub new (x As Integer , y As Integer )
    Me.New 
    pt.x = x
    pt.y = y 
    mover.Pos = pt 
  End Sub

  Public sub new (x As Integer , y As Integer,il As InteractiveLocation )
    Me.New (il)
    pt.x = x
    pt.y = y 
    mover.Pos = pt 
  End Sub


  Public sub new (point As Drawing.Point  )
    Me.New (point.X ,point.Y )  
  End Sub
  Public sub new (point As Drawing.Point,il As InteractiveLocation )
    Me.New (point.X ,point.Y,il )  
  End Sub


  Public Property X As Integer 
  Get
    Return pt.X
  End Get
  Set(value As Integer)
    pt.X = value 
  End Set
  End Property
  Public Property Y As Integer 
  Get
    Return pt.Y
  End Get
  Set(value As Integer)
    pt.Y = value 
  End Set
  End Property

  Public Shared ReadOnly Property  Empty As Point 
    Get
      Return New Point (0,0)
    End Get
  End Property 
 
   Public Shared Operator +(ByVal Value As Point, ByVal Add As Point) As Drawing.Point 
      Return Value.pt + Add.pt
    End Operator

   Public Shared Operator -(ByVal Value As Point, ByVal Add As Point) As Drawing.Point 
      Return Value.pt - Add.pt
    End Operator

   Public Shared Operator -(ByVal Value As Point, ByVal Add As Drawing.Point) As Drawing.Point 
      Return Value.pt - Add
    End Operator

   Public Shared Operator -(ByVal Value As Drawing.Point, ByVal Add As Point) As Drawing.Point 
      Return Value - Add.pt 
    End Operator

#End Region '"Wrapper Methods"

Public Property Offset As New  Drawing.Point Implements Positionable.Offset

Public Property Pos As Drawing.Point Implements Positionable.Pos
Get
  return me.pt  
End Get
Set(value As Drawing.Point)
 pt= value 
  'mover.Pos = pt 
End Set
End Property
End class

 