Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Runtime.Serialization

<DataContractAttribute> _ 
Public Class State
Implements Drawable, Positionable, Controllable, Connectable 

  Event Disposed (sender As Controllable  ) Implements Controllable.Disposed 

'State machine Node Types
  Enum NodeTypes
    Start
    Node
    Final
  End Enum

<DataMemberAttribute> _
  Shared ctr As Integer = 0
<DataMemberAttribute> _
  Public Property NodeType As NodeTypes = NodeTypes.Node

#Region "Controllable Implementations"

Public Event ControlAdded(c As Control) Implements Controllable.ControlAdded

  Sub forwardEventRuleControlAdded(c As Control)
    RaiseEvent ControlAdded(c)
  End Sub

#End Region ' "Controllable Implementations"

#Region "Positionable Implementations"

  Event detatch (client As Positionable )  Implements Positionable.detatch 

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

  <XmlIgnore()> _
  Public remover As InteractiveRemove

<DataMemberAttribute> _
  Public Property rules As new List(Of Rule)

  Private runners As List(Of Runner)
  Private runnersToDelete As List(Of Runner)


#Region "Rule Implementation"


  Public Sub applyWork(input As Generic.Queue(Of String))
    If input.Count = 0 Then Return
    Console.WriteLine(String.Format("State: {0} Verarbeitet Token: {1} ", Name, input(0)))

    Dim currentToken = input.Dequeue()

    For Each r As Rule In rules
      If r.token = currentToken Then

        Dim ru As New Runner With {.line = r.Line, .Tag = New Queue(Of String)( input) , .duration = 2000}
        runners.Add(ru)
        AddHandler ru.Finished, AddressOf runnerArrived
        ru.sw.Start()
        'Exit For
      End If
    Next
  End Sub

  Private Sub runnerArrived(r As Runner)
    'get the first Positionable of the lines last point (that's the target state)
    Dim mvbl As Positionable = r.line.Points(r.line.Points.Count - 1).mover.children(0)
    Dim s As State = mvbl
    s.applyWork(r.Tag)
    RemoveHandler r.Finished, AddressOf runnerArrived
    runnersToDelete.Add(r)
  End Sub

Public Sub Connect(partner As Connectable ) Implements Connectable.Connect
 If partner.GetType is GetType (State) 
    Dim state As State = partner 
    addRule(state) 
 End If
End Sub

  Sub addRule(target As State)
    Dim r As New Rule(Me, target)
    AddHandler r.ControlAdded, AddressOf forwardEventRuleControlAdded
    AddHandler r.Disposed, AddressOf removeRule
    r.initLine()
    
    locator.AddClient(r.rulator)
    locator.AddClient(r.remover) 
    rules.Add(r)
  End Sub

  Sub removeRule (rule As Controllable) 
    rules.Remove (rule) 
  End Sub

#End Region '"Rule Implementation"

#Region "Serialization Deserialization"

<OnDeserialized > _ 
sub OnDeserialized(c As StreamingContext )
  init
  initController 
End Sub


#End Region


  Sub init()
    runners  = New List(Of Runner)
    runnersToDelete = New List(Of Runner ) 
  End Sub

'call this after connection Handler to ControlerAdded Event to get Controllers

  Sub initController()

   locator = New InteractiveLocation(Me)
   connector = New InteractiveConnect(Me)
    remover = New InteractiveRemove (Me) 

    locator.BackColor = Color.AliceBlue
    locator.Width = 20
    locator.Height = 20
    locator.Offset = New Drawing.Point(-locator.Width / 2, _
                                         -locator.Height / 2) 'center of state circle - center of locator

    locator.AddClient(connector)
    locator.AddClient(remover ) 

  RaiseEvent ControlAdded(locator)
  RaiseEvent ControlAdded(connector)
  RaiseEvent ControlAdded(remover)



End Sub

  Public Sub New()
    Me.Name = "State " & ctr
    ctr += 1
    init 

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

#Region "IDisposable Support"
Private disposedValue As Boolean' So ermitteln Sie überflüssige Aufrufe

' IDisposable
Protected Overridable Sub Dispose(disposing As Boolean)
If Not Me.disposedValue Then
If disposing Then
' TODO: Verwalteten Zustand löschen (verwaltete Objekte).

  For Each r As Rule In rules.ToArray 
    r.Dispose 
  Next
  rules.Clear 

  connector.Dispose 
  locator.Dispose 
  remover.Dispose 

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
RaiseEvent Disposed (Me) 
End Sub
#End Region


End Class
