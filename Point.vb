'Wrapper Klasse für Point
Public Class   Point

  Public pt As Drawing.Point 'it's a structure!

  Public sub new (x As Integer , y As Integer )
    pt.x = x
    pt.y = y 
  End Sub

  Public sub new (point As Drawing.Point )
    Me.New (point.X ,point.Y )  
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

End class

 