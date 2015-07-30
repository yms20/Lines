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


 ' Public outs As New List(Of Line)

  <Description("Guut")> _
  Public Property rules As New List(Of Rule)
  Dim runners As New List(Of Runner)
  
  Dim runnersToDelete As New List(Of Runner)
  

  'returns all controls
  Public Function getControls As list (of Control ) 
    getControls = New List(Of Control )
    getControls.AddRange (   rules.SelectMany (Of Control ) (Function (r as rule) r.getControls ))  
    getControls.Add(connector)
    getControls.Add(rulator )
    getControls.Add(locator )

    getControls = getControls.Distinct.ToList 

  End Function

#Region "Rule Implementation"


  Public Sub applyWork(input As Generic.Queue(Of String))
    If input.Count = 0 Then Return
    Console.WriteLine(String.Format("State: {0} Verarbeitet Token: {1} ", Name, input(0)))
    For Each r As Rule In rules
      If r.token = input(0) Then
        input.Dequeue()
        Dim ru As New Runner With {.line = r.Line , .Tag = input, .duration = 2000}
        runners.Add(ru)
        AddHandler ru.Finished, AddressOf runnerArrived
        ru.sw.Start()
        Exit For
      End If
    Next
  End Sub

  Private Sub runnerArrived(r As Runner)

    Dim mvbl As Positionable = r.line.Points(r.line.Points.Count - 1).mover.children(0)
    Dim s As State = mvbl
    s.applyWork(r.Tag)
    RemoveHandler r.Finished , AddressOf runnerArrived 
    runnersToDelete.add (r) 
  End Sub

  Sub addRule(target As State)
    rules.Add(New Rule (Me,target ) )
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

    For Each r As Rule In rules 
      r.draw (g) 
    Next

    For i As Integer = runners.Count To 1 Step -1
      'clear the arrived runners
      Dim r As Runner = runners(i - 1)
      If runnersToDelete.Contains (r)
        runners.Remove (r)
        runnersToDelete.Remove  (r)
        Continue For 
      End If

      r.calc(0)
      r.paint(g)
    Next

  End Sub




End Class
