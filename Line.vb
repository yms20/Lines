﻿Public Class Line
Implements Drawable , Positionable 



  Shared  dim ctr As Integer = 0 
  public Property Name As String = "Line "
  public Property Points As new Generic.List (Of Drawing.Point ) 

 
  Public Property Offset As Point Implements Positionable.Offset

  Public Property Pos As Point Implements Positionable.Pos 
    Get
      If Points.Count > 1
        Return Points(0) 
      End If  
      Return Point.Empty 
    End Get
    Set(value  As Point )
      Points(0)  = value 
    End Set
  End Property

  Public m_PointControls As List(Of PointInteractions ) 

  Sub new 
    ctr += 1 
    Name = String.Format("{0}{1:00}",Name,ctr)
  End Sub

  public Sub asdd(p As Drawing.Point )
    Points.Add (p) 
  End Sub 
 
  Public Sub draw (g As Graphics )  Implements Drawable.draw 
      If Points.Count > 1
        g.DrawString (Name, SystemFonts.MessageBoxFont  ,Brushes.AliceBlue,new PointF( Points(0).X ,Points(0).Y )  ) 
        g.DrawLines (Pens.AliceBlue , Points.ToArray ) 
      End If
  End Sub


  Public ReadOnly Property length As Double 
    Get
      length = 0 
      If Points.Count < 2 then Return 0 
      For i As Int16 = 0 to Points.Count  -2 
        length += Math.Sqrt ( Math.Pow (Points(i).X - Points(i+1).X,2) + Math.Pow (Points(i).Y - Points(i+1).Y,2) ) 
      Next
    End Get
  End Property

  Public Function getPoint(t As Double ) As Point

    Dim total as double = Me.length
    Dim tar As Double = length * t 
    Dim currentLength As Double = 0
  

    if Points.Count = 0 then Return nothing 
    If Points.Count = 1 then Return Points (0)

    Dim currentPoint As integer = 0 

    ''Punkt für Punkt ablaufen und strecke addieren, abbrechen eins bevor summer größer Zieldistanz
    For i As Int16 = 0 to Points.Count  -2 
      currentPoint = i
      Dim dist = Math.Sqrt ( Math.Pow (Points(i).X - Points(i+1).X,2) + Math.Pow (Points(i).Y - Points(i+1).Y,2) ) 
    
      If currentLength + dist > tar then  Exit For 
      currentLength += dist 
    Next
    'distanz in pixeln die auf dem nächsten abschnitt gelaufen werden muss
    Dim restDistance as Double = tar - currentLength 

    'die zwei punkte definieren den abschnit auf dem die restDistanc interpoliert werden muss
    Dim pN As Point = Points(currentPoint)
    Dim pN1 As Point = Points(currentPoint + 1)

    Dim distToCurrentPlusOne As Double = Math.Sqrt ( Math.Pow (pN.X - pN1.X,2) + Math.Pow (pN.Y - pN1.Y,2) ) 

    If distToCurrentPlusOne = 0 
      Return pN 
    End If
    'prozent in t (0..1)
    Dim quantT = restDistance / distToCurrentPlusOne 

    Dim tX = pN.X * (1-quantT ) + pN1.X * quantT 
    Dim tY = pN.Y * (1-quantT ) + pN1.Y * quantT 

    Return New Point (tX,tY ) 
  End Function

  Public ReadOnly Property PointControls As List (of PointInteractions ) 
    Get
      If IsNothing ( m_PointControls ) 
        m_PointControls= New List(Of PointInteractions ) 
        For i As Integer = Points.Count to 1 Step -1 
          m_PointControls.Add (new PointInteractions (Me , i-1 ) )
        Next

      End If
      return m_PointControls
    End Get
      
  End Property

  Public Sub showPoints 
    For Each pc As PointInteractions In  m_PointControls
    pc.Visible = True 
    Next

  End Sub


End Class 'Line

