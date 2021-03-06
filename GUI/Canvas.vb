﻿Imports System.Runtime.Serialization

<Serializable> _
Public Class Canvas


Public Enum Modes
AddLine
AddStartState
AddState
[Select]
End Enum

Event createdStartable(sender As Canvas, baby As Line)

Public Drawables As New Items
Dim Runners As New Generic.List(Of Calculateable)
Dim WithEvents current As New Line
Dim lastMousePos As New Drawing.Point
Public Property Mode As Modes = Modes.Select


Public Sub addRunner(l As Line)
  Dim r As New Runner
  r.duration = 5000
  r.line = l
  r.sw.Start()
  AddHandler r.Finished, AddressOf removeRunner
  Runners.Add(r)
End Sub

Public Sub removeRunner(r As Runner)
 Runners.Remove(r)
End Sub

Sub addLine(e As MouseEventArgs)
  Select Case (e.Button)
    Case Windows.Forms.MouseButtons.Left
      current.Points.Add(New Point(e.Location))
    Case Windows.Forms.MouseButtons.Right
      Drawables.Add(current)
      RaiseEvent createdStartable(Me, current)
      'Me.Controls.AddRange (current.PointControls.ToArray ) 
      'current.showPoints 
      AddHandler current.detatch, AddressOf handleLineControllDetached
      current = New Line
  End Select
End Sub

Sub handleLineCotroleAdded(Control As Control) Handles current.ControlAdded
  Me.Controls.Add(Control)
End Sub
Sub handleLineControllDetached(control As Control) Handles current.detatch
Me.Controls.Remove(control)
End Sub


Private Sub Canvas_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick

  Select Case Me.Mode
    Case Modes.AddLine
      addLine(e)
    Case Modes.AddState, Modes.AddStartState
      Dim s As New State
      If Mode = Modes.AddStartState Then s.NodeType = State.NodeTypes.Start

      AddHandler s.ControlAdded, AddressOf addControl
      AddHandler s.Disposed, AddressOf removeState

      s.initController()
      s.locator.Pos = e.Location
      Drawables.Add(s)
  End Select
End Sub

Sub addControl(c As Control)
  Me.Controls.Add(c)
End Sub


Public Sub startStateMachine(instruction As Queue(Of String))

  For Each d As Drawable In Drawables
    If d.GetType Is GetType(State) Then
      Dim s As State = d
      If s.NodeType = State.NodeTypes.Start Then
        s.applyWork(New Queue(Of String)(instruction))

      End If
      'Return s 
      'Exit For 
    End If
  Next

End Sub



Protected Overrides Sub OnPaint(e As PaintEventArgs)
MyBase.OnPaint(e)


Select Case Me.Mode
Case Modes.AddLine
  If current.Points.Count > 0 Then
    current.draw(e.Graphics)
    Dim lp As Drawing.Point = current.Points(current.Points.Count - 1).pt
    e.Graphics.DrawLine(Pens.AliceBlue, lp, lastMousePos)
    e.Graphics.DrawString(String.Format("L:{0:0.00}", current.length), SystemFonts.MessageBoxFont, Brushes.AliceBlue, New PointF(lp.X, lp.Y))
    Dim deltaLength As Double = current.length + Math.Sqrt(Math.Pow(lp.X - lastMousePos.X, 2) + Math.Pow(lp.Y - lastMousePos.Y, 2))
    e.Graphics.DrawString(String.Format("L:{0:0.00}", deltaLength), SystemFonts.MessageBoxFont, Brushes.AliceBlue, New PointF(lastMousePos.X, lastMousePos.Y))
  End If
End Select

  For Each r As Runner In Runners
    r.paint(e.Graphics)
  Next

  For Each Line As Drawable In Drawables
    Line.draw(e.Graphics)
  Next


End Sub

Private Sub Canvas_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
  lastMousePos = e.Location

End Sub

'calculate and paint objecet
Private Sub TimerRefresh_Tick(sender As Object, e As EventArgs) Handles TimerRefresh.Tick

  For i As Integer = Runners.Count To 1 Step -1
    Runners(i - 1).calc(0)
  Next
  Refresh()
End Sub

Private Sub removeState(sender As State)
    Drawables.Remove(sender)
 End Sub

End Class


''' <summary>
''' WrapperKlasse for Serializing and deserializing of Drawables
''' </summary>
''' <remarks></remarks>
<KnownType(gettype(Line))> _
<KnownType(gettype(State))> _
<CollectionDataContract(Name := "Items", ItemName := "Drawable", Namespace := "")> _ 
Public Class Items 
Inherits Generic.List(Of Drawable )

End Class