Imports System.ComponentModel

Public Class State
Implements Drawable, Positionable




#Region "Positionable Implementations"
Dim m_pos As New Drawing.Point(10, 10)


  Public Property Offset As New Drawing.Point(-13, -13) Implements Positionable.Offset
  Public Property Pos As Drawing.Point Implements Positionable.Pos
  Get
    Return m_pos
  End Get
  Set(value As Drawing.Point)
    m_pos = value
  End Set
  End Property

#End Region '"Positionable Implementations"
  Public Property Name = "Test"

  Public locator As New InteractiveLocation(Me)
  Public connector As New InteractiveConnect(Me)
  Public rulator As New InteractiveRuleEdit(Me)


  Public outs As New List(Of Line)

  <Description("Guut")> _
  Public Property rules As New List(Of Rule)
  Dim runners As New List(Of Runner)

#Region "Rule Implementation"


  Public Sub applyWork(input As Generic.Queue(Of String))
    If input.Count = 0 Then Return
    Console.WriteLine(String.Format("State: {0} Verarbeitet Token: {1} ", Name, input(0)))
    For Each r As Rule In rules
      If r.token = input(0) Then
        input.Dequeue()
        Dim ru As New Runner With {.line = findLineByTarget(r.target), .Tag = input, .duration = 2000}
        runners.Add(ru)
        AddHandler ru.Finished, AddressOf runnerArrived
        ru.sw.Start()
'        r.target.applyWork (input)
        Exit For
      End If
    Next
  End Sub

Function findLineByTarget(state As State)
  'look through lines 
  For Each l As Line In outs
    'get first moveable from last point
    Dim mvbl As Positionable = l.Points(l.Points.Count - 1).mover.children(0)
    'is it the wanted state?
    If mvbl Is state Then
      Return l
    End If
  Next
End Function
Private Sub runnerArrived(r As Runner)

  Dim mvbl As Positionable = r.line.Points(r.line.Points.Count - 1).mover.children(0)
  Dim s As State = mvbl
  s.applyWork(r.Tag)

  'runners.Remove (r) 
End Sub

#End Region '"Rule Implementation"


  Public Sub New()
    locator.BackColor = Color.AliceBlue
    locator.Width = 20
    locator.Height = 20
    locator.Offset = New Drawing.Point(-locator.Width / 2, _
                                         -locator.Height / 2) 'center of state circle - center of locator

    connector.BackColor = Color.Aqua
    connector.Width = 10
    connector.Height = 10

    locator.children.Add(connector)
    locator.children.Add(rulator)
  End Sub





  Public Sub draw(g As Graphics) Implements Drawable.draw
    g.DrawEllipse(Pens.Black, New Rectangle(Pos + Offset, New Size(26, 26)))

    For Each l As Line In outs
      l.draw(g)
    Next

  Dim rcpy As List(Of Runner) = runners.ToList

SyncLock (runners)
  For i As Integer = runners.Count To 1 Step -1
    runners(i - 1).calc(0)
    runners(i - 1).paint(g)
  Next
End SyncLock

   ' outs.ForEach (Function (l As Line ) l.draw (g) )
  End Sub

Sub addRule(state As State)


    Dim line As New Line
    line.Points.Add(New Point(Pos, locator))
    line.Points.Add(New Point(state.Pos, state.locator))

    outs.Add(line)

    rules.Add(New Rule With {.target = state, .token = Name})

 End Sub



End Class
