Imports System.Drawing.Drawing2D

Public Class InteractiveLocation
Implements Positionable

  Shared inst_ctr As Integer = 0

  Dim lastMousePos As Drawing.Point = Drawing.Point.Empty
  Dim dragging As Boolean = False

  Public  children As new List (Of  Positionable) 

Sub New()
  InitializeComponent()
  inst_ctr += 1 
  Console.WriteLine ("InteractiveLocation Instances: " & inst_ctr ) 
End Sub

Sub New(child As Positionable)
  Me.New 
  Me.children.Add (child) 
End Sub

Private Sub handleDetach (p As Positionable )
  RemoveHandler p.detatch , AddressOf handleDetach 
  Me.children.Remove (p) 
End Sub

Public Sub AddClient(p As Positionable )
  AddHandler p.detatch , AddressOf handleDetach 
  children.Add (p) 
  p.Pos = Me.Pos 
End Sub

Private Sub InteractiveLocation_Load(sender As Object, e As EventArgs) Handles Me.Load
  'make the order round
  Dim path As New GraphicsPath
  path.AddEllipse(New Rectangle(0, 0, Width, Height))
  Me.Region = New Region(path)
End Sub

Private Sub PointInteractions_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
  dragging = True
  lastMousePos = e.Location
End Sub

Private Sub PointInteractions_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
  If dragging Then
    Dim delta As New Drawing.Point(e.X - lastMousePos.X, e.Y - lastMousePos.Y)

    'Location = New Point ( Location.X + deltaX , Location.Y + deltaY )  
    'children.ForEach ( Function ( p As Positionable ) p .Pos = Pos + delta)  

      Pos = Pos + delta 
  End If

End Sub

Private Sub PointInteractions_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
  dragging = False
End Sub


#Region "Positionable Implementaion"

Event detatch (client As Positionable )  Implements Positionable.detatch 

Public Property Offset As Drawing.Point = New Drawing.Point(-5 ,-5 ) Implements Positionable.Offset

Public Property Pos As Drawing.Point Implements Positionable.Pos
Get
  Return Location - Offset
End Get
Set(value As Drawing.Point)

    For Each p As Positionable in children 
      p.Pos = value 
    Next

  Location = value + Offset
End Set
End Property


#End Region


End Class

