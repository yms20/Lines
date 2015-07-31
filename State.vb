Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Runtime.Serialization

<DataContractAttribute> _ 
Public Class State
Implements Drawable, Positionable, Controllable

'State machine Node Types
  Enum NodeTypes
    Start
    Node
    Final
  End Enum


  Shared ctr As Integer = 0
  Public Property NodeType As NodeTypes = NodeTypes.Node

#Region "Controllable Implementations"

Public Event ControlAdded(c As Control) Implements Controllable.ControlAdded


  'returns all controls
  Public Function getControls() As List(Of Control) Implements Controllable.getControls
    getControls = New List(Of Control)
    getControls.AddRange(rules.SelectMany(Of Control)(Function(r As Rule) r.getControls))
    getControls.Add(connector)
   ' getControls.Add(rulator )
    getControls.Add(locator)

    getControls = getControls.Distinct.ToList

  End Function

  Sub forwardEventRuleControlAdded(c As Control)
    RaiseEvent ControlAdded(c)
  End Sub

#End Region ' "Controllable Implementations"

#Region "Positionable Implementations"
  private m_pos As New Drawing.Point(10, 10)

<datamemberAttribute> _
  Public Property Offset As New Drawing.Point(-13, -13) Implements Positionable.Offset

<datamemberAttribute> _
  Public Property Pos As Drawing.Point Implements Positionable.Pos
  Get
    Return m_pos
  End Get
  Set(value As Drawing.Point)
    m_pos = value
  End Set
  End Property

#End Region '"Positionable Implementations"

<DataMemberAttribute> _
  Public Property Name As String = "Test"
  <XmlIgnore()> _
  Public locator As InteractiveLocation
  <XmlIgnore()> _
  Public connector As InteractiveConnect
<DataMemberAttribute> _
  Public Property rules As New List(Of Rule)

  Private runners As New List(Of Runner)
  Private runnersToDelete As New List(Of Runner)


#Region "Rule Implementation"


  Public Sub applyWork(input As Generic.Queue(Of String))
    If input.Count = 0 Then Return
    Console.WriteLine(String.Format("State: {0} Verarbeitet Token: {1} ", Name, input(0)))
    For Each r As Rule In rules
      If r.token = input(0) Then
        input.Dequeue()
        Dim ru As New Runner With {.line = r.Line, .Tag = input, .duration = 2000}
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
    RemoveHandler r.Finished, AddressOf runnerArrived
    runnersToDelete.Add(r)
  End Sub

  Sub addRule(target As State)
    Dim r As New Rule(Me, target)
    AddHandler r.ControlAdded, AddressOf forwardEventRuleControlAdded
    r.initLine()
    locator.children.Add(r.rulator)
    rules.Add(r)
  End Sub

#End Region '"Rule Implementation"

'call this after connection Handler to ControlerAdded Event to get Controllers
  Sub initController()

   locator = New InteractiveLocation(Me)
   connector = New InteractiveConnect(Me)

    locator.BackColor = Color.AliceBlue
    locator.Width = 20
    locator.Height = 20
    locator.Offset = New Drawing.Point(-locator.Width / 2, _
                                         -locator.Height / 2) 'center of state circle - center of locator

    connector.BackColor = Color.Aqua
    connector.Width = 10
    connector.Height = 10

    locator.children.Add(connector)

  RaiseEvent ControlAdded(locator)
  RaiseEvent ControlAdded(connector)

End Sub

  Public Sub New()


  Me.Name = "State " & ctr
  'First Node is StartNode
  If ctr = 0 Then
    NodeType = NodeTypes.Start
  End If

  ctr += 1
  End Sub

  Public Sub draw(g As Graphics) Implements Drawable.draw

       Dim rect As New Rectangle(Pos + Offset, New Size(26, 26))

    'Draw the State depending if its Type
    Select Case NodeType
      Case NodeTypes.Start
        g.FillEllipse(Brushes.Black, rect)
      Case NodeTypes.Node
        g.DrawEllipse(Pens.Black, rect)
      Case NodeTypes.Final
        g.FillEllipse(Brushes.Red, rect)
    End Select

    For Each r As Rule In rules
      r.draw(g)
    Next

    For i As Integer = runners.Count To 1 Step -1
      'clear the arrived runners
      Dim r As Runner = runners(i - 1)
      If runnersToDelete.Contains(r) Then
        runners.Remove(r)
        runnersToDelete.Remove(r)
        Continue For
      End If

      r.calc(0)
      r.paint(g)
    Next

    g.DrawString(Name, SystemFonts.CaptionFont, Brushes.Black, Pos + New Drawing.Point(-20, -28))

  End Sub

End Class
