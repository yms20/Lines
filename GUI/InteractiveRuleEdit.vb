﻿Public Class InteractiveRuleEdit
Implements Positionable


Dim rule As Rule

Public Sub new ( r As Rule )
  InitializeComponent 
  rule = r 
  TextBox1.Text = rule.token 
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



Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
  If Not IsNothing (rule) then rule.token = TextBox1.Text 
End Sub
End Class
