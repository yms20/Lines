Imports System.Drawing.Drawing2D

Public Class PointInteractions

  Public Property Opacity As Integer = 125
  Dim lastMousePos As Point = Point.Empty 
  Dim dragging As Boolean = False  
  Dim Sizee As Integer = 10  
  Dim index As Integer = 0 
  Dim line As Canvas.Line = Nothing 

  Public Sub new 
' Dieser Aufruf ist für den Designer erforderlich.

' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

  End Sub

  'Public Sub new (ByRef  p_middle As Point, ) 
    Public Sub new (line As Canvas.Line , index As Integer ) 
    InitializeComponent()
    Me.line = line 
    Me.index = index 
    Dim p As Point = line.Points(index)

    Me.Width = 10 
    Me.Height = 10 
    Me.Location = New Point (p.X - sizee/2,p.Y - sizee/2 ) 
    Me.BackColor = Color.Green 
  End Sub

Protected Overrides Sub OnPaint(e As PaintEventArgs)
  MyBase.OnPaint(e)
  Dim br As Brush = New SolidBrush(Color.FromArgb(Opacity, BackColor))

End Sub

Private Sub PointInteractions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
  Dim path As New GraphicsPath
  path.AddEllipse (New Rectangle(0, 0, Width, Height))
  Me.Region =  New Region (path ) 


End Sub

Private Sub PointInteractions_MouseDown( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseDown
  dragging = True 
  lastMousePos = e.Location 
End Sub

Private Sub PointInteractions_MouseMove( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseMove
  If dragging
    Dim deltaX As Integer = ( e.X - lastMousePos.X ) 
    Dim deltaY As Integer = ( e.Y - lastMousePos.Y ) 
    Location = New Point ( Location.X + deltaX , Location.Y + deltaY )  
    Dim p As Point = line.Points(index)
    p.X = p.X + deltaX 
    p.Y = p.Y + deltaY
    line.Points(index) = p 

  End If

End Sub

Private Sub PointInteractions_MouseUp( sender As Object,  e As MouseEventArgs) Handles MyBase.MouseUp
  dragging = False  
End Sub
End Class
