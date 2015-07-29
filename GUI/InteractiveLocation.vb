Public Class InteractiveLocation
Implements Positionable

  Dim lastMousePos As Point = Point.Empty 
  Dim dragging As Boolean = False  

  Dim child As Positionable 

Sub new 
InitializeComponent()
End Sub

Sub new (child As Positionable)
  InitializeComponent 
  Me.child = child 
End Sub

Private Sub PointInteractions_MouseDown( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseDown
  dragging = True 
  lastMousePos.pt = e.Location 
End Sub

Private Sub PointInteractions_MouseMove( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseMove
  If dragging 
    Dim delta As New Point ( e.X - lastMousePos.X, e.Y - lastMousePos.Y ) 
    
    'Location = New Point ( Location.X + deltaX , Location.Y + deltaY )  
    If Not isnothing (child ) then child.Pos  =  New Point (Pos + delta) 
  End If

End Sub

Private Sub PointInteractions_MouseUp( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseUp
  dragging = False  
End Sub

Public Property Offset As Point = new Point ( 2, 2)   Implements Positionable.offset 

Public Property Pos As Point  Implements Positionable.pos
Get
  Return New Point (Location - Offset ) 
End Get
Set(value As Point)
  Location = value + Offset 
End Set
End Property

End Class
