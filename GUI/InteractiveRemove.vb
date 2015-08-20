Public Class InteractiveRemove
Implements Positionable 
  Dim child As IDisposable 

  Public Sub new (s As IDisposable ) 
    InitializeComponent 
    Me.child = s 
  End Sub


Private Sub InteractiveStateRemove_MouseDoubleClick( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseDoubleClick
 child.Dispose
End Sub

#Region "Positionable Implementaion"

Event detatch (client As Positionable )  Implements Positionable.detatch 


Public Property Offset As Drawing.Point  = New Drawing.Point (15, -15 )  Implements Positionable.Offset 

Public Property Pos As Drawing.Point Implements Positionable.Pos
Get
  Return  Location - Offset 
End Get
Set(value As Drawing.Point)
 Location = value + Offset 
End Set
End Property

#End Region '#Region "Positionable Implementaion"

End Class
