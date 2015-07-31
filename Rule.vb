Imports System.Runtime.Serialization
 
<DataContractAttribute (IsReference := True ) > _
Public Class Rule
Implements Drawable, Controllable

Public Event ControlAdded(c As Control) Implements Controllable.ControlAdded

  'returns all controls
  Public Function getControls() As List(Of Control) Implements Controllable.getControls
    Return Line.Points.Select(Of Control)(Function(p As Point) p.mover).ToList
  End Function


  <DataMember> _ 
  Public Property source As State
  <DataMember> _ 
  Public Property target As State
<DataMemberAttribute> _
  Public Property token As String = "1"
  <DataMember> _ 
  Public Property Line As New Line

  Public Property rulator As InteractiveRuleEdit


Public Sub New(source As State, target As State)
  Me.source = source
  Me.target = target
End Sub

'call this method after creating object and connecting Listener to it
Public Sub initLine()

  Line.Points.Add(New Point(source.Pos, source.locator))
  Dim middlePoint As Point = New Point(source.Pos.X / 2 + target.Pos.X / 2, source.Pos.Y / 2 + target.Pos.Y / 2)
  Line.Points.Add(middlePoint)
  AddHandler middlePoint.PosChanged, AddressOf handlePointChanged
  RaiseEvent ControlAdded(middlePoint.mover)
  Line.Points.Add(New Point(target.Pos, target.locator))

  rulator = New InteractiveRuleEdit(Me)
  rulator.Pos = Line.getPoint(0.15)
  rulator.Visible = True
  RaiseEvent ControlAdded(rulator)
End Sub

Private Sub handlePointChanged(p As Point)
  rulator.Offset = Line.getPoint(0.15) - Line.Points(0).pt
  rulator.Pos = source.Pos
End Sub

Public Sub draw(g As Graphics) Implements Drawable.draw
  rulator.Offset = Line.getPoint(0.15) - Line.Points(0).pt
  If Not IsNothing(Line) Then Line.draw(g)
End Sub



End Class
