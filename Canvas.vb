Public Class Canvas

Dim Lines  As New  Generic.List(Of Line ) 
Dim Runners As New Generic.List(Of Runner)

Dim current As new Line 
dim lastMousePos as new Drawing.Point 

Event created (sender as Canvas, baby As Line)

Class Line

  Shared  dim ctr As Integer = 0 
  public Property Name As String = "Line "
  public Property Points As new Generic.List (Of Drawing.Point ) 
  Public m_PointControls As List(Of PointInteractions ) 

  Sub new 
    ctr += 1 
    Name = String.Format("{0}{1:00}",Name,ctr)
  End Sub

  public Sub asdd(p As Drawing.Point )
    Points.Add (p) 
  End Sub 
 
  Public Sub draw (g As Graphics ) 
      If Points.Count > 1
        g.DrawString (Name, SystemFonts.MessageBoxFont  ,Brushes.AliceBlue,new PointF( Points(0).X ,Points(0).Y )  ) 
        g.DrawLines (Pens.AliceBlue , Points.ToArray ) 
      End If
  End Sub


  Public ReadOnly Property length As Double 
    Get
      If Points.Count < 2
        Return 0 
      End If
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


Class Runner 
  
  Public Property line As Line
  Public Property duration As Double 'in ms

  Public sw As new Stopwatch
  Dim t As Double =  0

  Public Event Finished(sender as Runner) 

  Sub calc () 
    t = sw.ElapsedMilliseconds / duration 
    If t > 1
      sw.Reset 
      t= 0
      RaiseEvent Finished (Me) 
    End If
  End Sub

  Sub paint (g As Graphics ) 
    If line is Nothing then Return 

    Dim p As Point = line.getPoint (t) 
    g.FillEllipse  (Brushes.BlanchedAlmond ,New Rectangle(p.X -16 , p.Y - 16 ,31,31 )) 
  End Sub
End Class


Public sub addRunner ( l As Line )
  Dim r As new Runner 
  r.duration = 5000
  r.line = l
  r.sw.Start
  AddHandler r.Finished, AddressOf removeRunner
  Runners.Add (r) 
End Sub


Public Sub removeRunner ( r As Runner ) 
 Runners.Remove (r ) 
End Sub


Private Sub Canvas_MouseClick( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseClick
  Select (e.Button ) 
  Case Windows.Forms.MouseButtons.Left :
    current.asdd (e.Location ) 
  Case Windows.Forms.MouseButtons.Right :
    Lines.Add (current )
    RaiseEvent created (Me,current ) 
    Me.Controls.AddRange (current.PointControls.ToArray ) 
    current.showPoints 
    current = New Line 
  End Select
  Refresh 
End Sub

Protected Overrides Sub OnPaint(e As PaintEventArgs)
MyBase.OnPaint(e)



  If current.Points.Count > 0 
    current.draw (e.Graphics ) 
    Dim lp As Drawing.Point = current.Points(current.Points.Count -1 )
    e.Graphics.DrawLine ( Pens.AliceBlue, lp, lastMousePos)
    e.Graphics.DrawString (String.Format ("L:{0:0.00}",current.length), SystemFonts.MessageBoxFont  ,Brushes.AliceBlue,new PointF( lp.X ,lp.Y )  ) 
    Dim deltaLength As Double = current.length + Math.Sqrt ( Math.Pow (lp.X - lastMousePos.X,2) + Math.Pow (lp.Y - lastMousePos.Y,2) )
    e.Graphics.DrawString (String.Format ("L:{0:0.00}",deltaLength), SystemFonts.MessageBoxFont  ,Brushes.AliceBlue,new PointF( lastMousePos.X ,lastMousePos.Y )  ) 
  End If

  For Each r As Runner In Runners 
    r.paint (e.Graphics) 
  Next

  For Each Line As Line In Lines 
    Line.draw ( e.Graphics ) 
  Next


End Sub

Private Sub Canvas_MouseMove( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseMove
  lastMousePos = e.Location 
   
End Sub

'calculate and paint objecet
Private Sub TimerRefresh_Tick( sender As Object,  e As EventArgs) Handles TimerRefresh.Tick

  For i As Integer = Runners.Count to 1 Step -1 
    runners(i-1).calc 
  Next
  Refresh
End Sub
End Class
