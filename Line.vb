Imports System.Runtime.Serialization

<DataContractAttribute(IsReference:=False)> _
Public Class Line
Implements Drawable, Positionable

  

  Shared ctr As Integer = 0
<DataMemberAttribute> _
  Public Property Name As String = "Line "
<DataMemberAttribute> _
  Public Property Points As New Generic.List(Of Point)


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


  Sub New()
    ctr += 1
    Name = String.Format("{0}{1:00}", Name, ctr)
  End Sub

  Public Sub draw(g As Graphics) Implements Drawable.draw
      If Points.Count > 1 Then
        g.DrawString(Name, SystemFonts.MessageBoxFont, Brushes.AliceBlue, New PointF(Points(0).X, Points(0).Y))
        Dim pts As Drawing.Point() = Points.Select(Of Drawing.Point)(Function(p As Point) p.pt).ToArray
        g.DrawLines(Pens.AliceBlue, pts)
      End If
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
    Points.ForEach(Function(x As Point) x.mover.Visible = True)
  End Sub


End Class 'Line

