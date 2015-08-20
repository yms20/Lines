Imports System.Runtime.Serialization

<DataContractAttribute(IsReference:=False)> _
Public Class Line
Implements Drawable, Positionable, Controllable, Connectable


  Shared ctr As Integer = 0
<DataMemberAttribute> _
  Public Property Name As String = "Line "
<DataMemberAttribute> _
  Public WithEvents Points As New ObjectModel.ObservableCollection(of Point) 
' Generic.List(Of Point)


  Public startConnector As InteractiveConnect 
  Public endConnector As New  InteractiveConnect (Me) With {.Visible = True }


#Region "Positionable Implementaion"

  Event detatch (client As Positionable )  Implements Positionable.detatch 

  Public Property Offset As Drawing.Point Implements Positionable.Offset

  Public Property Pos As Drawing.Point Implements Positionable.Pos
    Get
      If Points.Count > 1 Then
        Return Points(0).pt
      End If
      Return Drawing.Point.Empty
    End Get
    Set(value As Drawing.Point)
      Points(0).pt = value
    End Set
  End Property

#End Region '#Region "Positionable Implementaion"

  Sub New()
    ctr += 1
    Name = String.Format("{0}{1:00}", Name, ctr)
  End Sub

  Sub onPointsChanged(sender As Object, e As System.Collections.Specialized.NotifyCollectionChangedEventArgs) Handles Points.CollectionChanged
    If IsNothing (startConnector ) and Points.Count > 1 
      startConnector = New  InteractiveConnect (Me) With {.Visible = True }
      'add to interactive locator of start and end point
      Points(0).mover.AddClient (startConnector )
      Points(Points.Count -1).mover.AddClient (endConnector ) 

      RaiseEvent ControlAdded (startConnector )
      RaiseEvent ControlAdded (endConnector )
    End If
    
    For Each p As Point In e.NewItems
      RaiseEvent ControlAdded (p.mover ) 
    Next

    'update locationer for endconnector
    endConnector.detachFromInteractiveLocation 
    Points(Points.Count -1).mover.AddClient (endConnector ) 

  End Sub

  Public Sub draw(g As Graphics) Implements Drawable.draw
      If Points.Count < 2 Then Return


      g.DrawString(Name, SystemFonts.MessageBoxFont, Brushes.AliceBlue, New PointF(Points(0).X, Points(0).Y))
      Dim pts As Drawing.Point() = Points.Select(Of Drawing.Point)(Function(p As Point) p.pt).ToArray
      g.DrawLines(Pens.AliceBlue, pts)
  End Sub

  Public ReadOnly Property length As Double
    Get
      length = 0
      If Points.Count < 2 Then Return 0
      For i As Int16 = 0 To Points.Count - 2
        length += Math.Sqrt(Math.Pow(Points(i).X - Points(i + 1).X, 2) + Math.Pow(Points(i).Y - Points(i + 1).Y, 2))
      Next
    End Get
  End Property

  Public Function getPoint(t As Double) As Drawing.Point

    Dim total As Double = Me.length
    Dim tar As Double = length * t
    Dim currentLength As Double = 0


    If Points.Count = 0 Then Return Nothing
    If Points.Count = 1 Then Return Points(0).pt

    Dim currentPoint As Integer = 0

    ''Punkt für Punkt ablaufen und strecke addieren, abbrechen eins bevor summer größer Zieldistanz
    For i As Int16 = 0 To Points.Count - 2
      currentPoint = i
      Dim dist = Math.Sqrt(Math.Pow(Points(i).X - Points(i + 1).X, 2) + Math.Pow(Points(i).Y - Points(i + 1).Y, 2))

      If currentLength + dist > tar Then Exit For
      currentLength += dist
    Next
    'distanz in pixeln die auf dem nächsten abschnitt gelaufen werden muss
    Dim restDistance As Double = tar - currentLength

    'die zwei punkte definieren den abschnit auf dem die restDistanc interpoliert werden muss
    Dim pN As Point = Points(currentPoint)
    Dim pN1 As Point = Points(currentPoint + 1)

    Dim distToCurrentPlusOne As Double = Math.Sqrt(Math.Pow(pN.X - pN1.X, 2) + Math.Pow(pN.Y - pN1.Y, 2))

    If distToCurrentPlusOne = 0 Then
      Return pN.pt
    End If
    'prozent in t (0..1)
    Dim quantT = restDistance / distToCurrentPlusOne

    Dim tX = pN.X * (1 - quantT) + pN1.X * quantT
    Dim tY = pN.Y * (1 - quantT) + pN1.Y * quantT

    Return New Drawing.Point(tX, tY)
  End Function

  Public ReadOnly Property PointControls As List(Of InteractiveLocation)
    Get
      PointControls = Points.Select(Of InteractiveLocation)(Function(x As Point) x.mover).ToList
    End Get
  End Property

  Public Sub showPoints()
    Points.ToList.ForEach(Function(x As Point) x.mover.Visible = True)
  End Sub

  Public sub combine (line As Line ) 
    line.startConnector.detachFromInteractiveLocation 
    line.endConnector.detachFromInteractiveLocation 

    RaiseEvent detatch (line.startConnector)
    RaiseEvent detatch (line.endConnector )


    line.Points.ToList.ForEach (Sub (p As Point ) Me.Points.Add (p) )

    Points(Points.Count -1).mover.AddClient (endConnector ) 

  End Sub

Public Sub Connect(target As Connectable) Implements Connectable.Connect
 If target.GetType is GetType (Line) 
    combine (target) 
 End If
End Sub

Public Event ControlAdded(c As Control) Implements Controllable.ControlAdded

Public Event Disposed(c As Controllable) Implements Controllable.Disposed

#Region "IDisposable Support"
Private disposedValue As Boolean' So ermitteln Sie überflüssige Aufrufe

' IDisposable
Protected Overridable Sub Dispose(disposing As Boolean)
If Not Me.disposedValue Then
If disposing Then
' TODO: Verwalteten Zustand löschen (verwaltete Objekte).
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

End Class 'Line

