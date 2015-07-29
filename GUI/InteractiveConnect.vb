Public Class InterActiveConnect
Implements Positionable




  Dim lastMousePos As Point = Point.Empty 
  Dim dragging As Boolean = False

  Private Sub InterActiveConnect_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
    Dim s As InterActiveConnect = sender 
    MsgBox (s.Location.ToString   ) 
  End Sub  

  Private Sub InterActiveConnect_MouseDown( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseDown
    dragging = True 
    lastMousePos.pt = e.Location 
  End Sub


  Private Sub InterActiveConnect_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
    If dragging 
      DoDragDrop (Location ,DragDropEffects.Move  )
      dragging = False 
    End If
  End Sub

Private Sub InterActiveConnect_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
  dragging = False 
End Sub

Private Sub InterActiveConnect_DragEnter( sender As Object,  e As DragEventArgs) Handles MyBase.DragEnter
  e.Effect =DragDropEffects.Move 
End Sub

Public Property Offset As Point  = New Point (20, 20 )  Implements Positionable.Offset 

Public Property Pos As Point Implements Positionable.Pos
Get
  Return New Point (Location - Offset )
End Get
Set(value As Point)
 Location = value + Offset 
End Set
End Property
End Class
