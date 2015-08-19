Imports System.Runtime.Serialization
 
<DataContractAttribute (IsReference := True ) > _
Public Class Rule
Implements Drawable, Controllable,IDisposable


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
  Public Property deletor As InteractiveRemove 

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

  deletor = New InteractiveRemove (Me)
  deletor.Pos = Line.getPoint(0.2)
  deletor.Height = 10 
  deletor.Width = 10
  deletor.BackColor = Color.Red 
  RaiseEvent ControlAdded (deletor) 
  
End Sub

Private Sub handlePointChanged(p As Point)

  rulator.Offset = Line.getPoint(0.15) - Line.Points(0).pt
  rulator.Pos = source.Pos

  deletor.Offset = Line.getPoint(0.2) - Line.Points(0).pt
  deletor.Pos = source.Pos

End Sub

Public Sub draw(g As Graphics) Implements Drawable.draw
  rulator.Offset = Line.getPoint(0.15) - Line.Points(0).pt
  deletor.Offset = Line.getPoint(0.2) - Line.Points(0).pt
  If Not IsNothing(Line) Then Line.draw(g)
End Sub



#Region "IDisposable Support"
Private disposedValue As Boolean' So ermitteln Sie überflüssige Aufrufe

' IDisposable
Protected Overridable Sub Dispose(disposing As Boolean)
If Not Me.disposedValue Then
If disposing Then
' TODO: Verwalteten Zustand löschen (verwaltete Objekte).
  rulator.Dispose
  deletor.Dispose 
  Dim middlePoint As Point = Line.Points(1)
  middlePoint.mover.Dispose 
  Me.source.rules.Remove (Me) 
End If
  
' TODO: Nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalize() unten überschreiben.
' TODO: Große Felder auf NULL festlegen.
End If
Me.disposedValue = True
End Sub

' TODO: Finalize() nur überschreiben, wenn Dispose(ByVal disposing As Boolean) oben über Code zum Freigeben von nicht verwalteten Ressourcen verfügt.
'Protected Overrides Sub Finalize()
'    ' Ändern Sie diesen Code nicht. Fügen Sie oben in Dispose(ByVal disposing As Boolean) Bereinigungscode ein.
'    Dispose(False)
'    MyBase.Finalize()
'End Sub

' Dieser Code wird von Visual Basic hinzugefügt, um das Dispose-Muster richtig zu implementieren.
Public Sub Dispose() Implements IDisposable.Dispose
' Ändern Sie diesen Code nicht. Fügen Sie oben in Dispose(disposing As Boolean) Bereinigungscode ein.
Dispose(True)
GC.SuppressFinalize(Me)
End Sub
#End Region

End Class
