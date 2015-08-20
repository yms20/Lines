Public Class InteractiveConnect
Implements Positionable


  Dim child As Connectable

  Dim lastMousePos As Drawing.Point = Drawing.Point.Empty 
  Dim dragging As Boolean = False



  Public Sub new (state As Connectable)
    InitializeComponent 
    Me.child = state 
  End Sub

  'is triggered by the target 
  Private Sub InterActiveConnect_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
    'get the sender (dragging from)
    Dim s As InteractiveConnect = e.Data.GetData("InteractiveConnect") 
    s.child.connect (me.child)

  End Sub  

  Private Sub InterActiveConnect_MouseDown( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseDown
    dragging = True 
    lastMousePos = e.Location 
  End Sub


  Private Sub InterActiveConnect_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
    'Drag at least 10 Pixels away befor start drag and drop
    If dragging and Math.Abs (e.Location.X - lastMousePos.X ) > 10
      DoDragDrop (Me ,DragDropEffects.Move  )
      dragging = False 
    End If
  End Sub

  Private Sub InterActiveConnect_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
    dragging = False 
  End Sub

  Private Sub InterActiveConnect_DragEnter( sender As Object,  e As DragEventArgs) Handles MyBase.DragEnter
    e.Effect =DragDropEffects.Move 
  End Sub

#Region "Positionable Implementaion"

Event detatch (client As Positionable )  Implements Positionable.detatch 

Public Sub detachFromInteractiveLocation
  RaiseEvent detatch (Me) 
End Sub

Public Property Offset As Drawing.Point  = New Drawing.Point (5, 15 )  Implements Positionable.Offset 

Public Property Pos As Drawing.Point Implements Positionable.Pos
Get
  Return  Location - Offset 
End Get
Set(value As Drawing.Point)
 Location = value + Offset 
End Set
End Property

#End Region '"Positionable Implementaion"

End Class
