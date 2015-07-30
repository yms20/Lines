Public Class InteractiveRuleEdit
Implements Positionable


Dim state As State 

Public Sub new ( s As State )
  InitializeComponent 
  state = s
End Sub


Private Sub InteractiveRuleEdit_Click( sender As Object,  e As EventArgs) Handles MyBase.Click
 Form1.PropertyGrid1.SelectedObject = state

End Sub

Public Property Offset As Drawing.Point  = New Drawing.Point (15,0) Implements Positionable.Offset 

Public Property Pos As Drawing.Point Implements Positionable.Pos
Get
  Return Location - Offset 
End Get
Set(value As Drawing.Point)
 Location = value + Offset 
End Set
End Property
End Class
