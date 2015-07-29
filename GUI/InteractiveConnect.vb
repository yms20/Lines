Public Class InterActiveConnect
Implements Positionable




  Dim lastMousePos As Drawing.Point = Drawing.Point.Empty 
  Dim dragging As Boolean = False

  Private Sub InterActiveConnect_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
    Dim s As InterActiveConnect = sender 
    MsgBox (s.Location.ToString   ) 
  End Sub  

  Private Sub InterActiveConnect_MouseDown( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseDown
    dragging = True 
    lastMousePos = e.Location 
  End Sub


  Private Sub InterActiveConnect_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
    If dragging and Math.Abs (e.Location.X - lastMousePos.X ) > 10
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



Public Property Offset As Drawing.Point  = New Drawing.Point (20, 20 )  Implements Positionable.Offset 

Public Property Pos As Drawing.Point Implements Positionable.Pos
Get
  Return  Location - Offset 
End Get
Set(value As Drawing.Point)
 Location = value + Offset 
End Set
End Property

Private Sub InterActiveConnect_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave

End Sub
End Class
