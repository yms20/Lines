Public Class InteractiveConnect
Implements Positionable


  Dim state As State

  Dim lastMousePos As Drawing.Point = Drawing.Point.Empty 
  Dim dragging As Boolean = False

  Public Sub new (state As State)
    InitializeComponent 
    Me.state = state 
  End Sub

  Private Sub InterActiveConnect_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
    Dim s As InteractiveConnect = e.Data.GetData("InteractiveConnect") 

    s.state.addRule (state)


    'Dim line As New Line 
    'line.Points.Add (New Point (s.state.Pos,s.state.locator ))    
    'line.Points.Add (New Point (state.Pos,state.locator ))
    
    's.state.outs.Add(line ) 

    'MsgBox (s.Location.ToString   ) 
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
