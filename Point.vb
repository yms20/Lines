Imports System.Runtime.Serialization

'Wrapper Klasse für Point
<DataContractAttribute ( Namespace := "" ) > _
Public Class Point
Implements Positionable

Public mover As InteractiveLocation
Public Event PosChanged(sender As Point)


  Public Sub New(il As InteractiveLocation)
    mover = il
    mover.AddClient(Me)
  End Sub


  Public Sub New()
    Me.New(New InteractiveLocation())
  End Sub

#Region "Wrapper Methods"
'<DataMemberattribute (Name := "punkt" ) > _ 
  Public pt As Drawing.Point 'it's a structure!

  Public Sub New(x As Integer, y As Integer)
    Me.New() 'creats new Interactive Location
    pt.X = x
    pt.Y = y
    mover.Pos = pt
  End Sub

  Public Sub New(x As Integer, y As Integer, il As InteractiveLocation)
    Me.New(il)
    pt.X = x
    pt.Y = y
    mover.Pos = pt
  End Sub

  Public Sub New(point As Drawing.Point)
    Me.New(point.X, point.Y)
  End Sub

  Public Sub New(point As Drawing.Point, il As InteractiveLocation)
    Me.New(point.X, point.Y, il)
  End Sub

  <DataMemberattribute> _
  Public Property X As Integer
  Get
    Return pt.X
  End Get
  Set(value As Integer)
    pt.X = value
  End Set
  End Property
  <DataMemberattribute> _
  Public Property Y As Integer
  Get
    Return pt.Y
  End Get
  Set(value As Integer)
    pt.Y = value
  End Set
  End Property

  Public Shared ReadOnly Property Empty As Point
    Get
      Return New Point(0, 0)
    End Get
  End Property

   'Public Shared Operator +(ByVal Value As Point, ByVal Add As Point) As Drawing.Point 
   '   Return Value.pt + Add.pt
   ' End Operator

   'Public Shared Operator -(ByVal Value As Point, ByVal Add As Point) As Drawing.Point 
   '   Return Value.pt - Add.pt
   ' End Operator

   'Public Shared Operator -(ByVal Value As Point, ByVal Add As Drawing.Point) As Drawing.Point 
   '   Return Value.pt - Add
   ' End Operator

   'Public Shared Operator -(ByVal Value As Drawing.Point, ByVal Add As Point) As Drawing.Point 
   '   Return Value - Add.pt 
   ' End Operator

#End Region '"Wrapper Methods"

#Region "Positionable Implementaion"

Event detatch (client As Positionable )  Implements Positionable.detatch 

Public Property Offset As New Drawing.Point Implements Positionable.Offset

Public Property Pos As Drawing.Point Implements Positionable.Pos
Get
  Return Me.pt
End Get
Set(value As Drawing.Point)
 pt = value
  RaiseEvent PosChanged(Me)
  'mover.Pos = pt 
End Set
End Property

#End Region '#Region "Positionable Implementaion"
End Class

