Imports System.Runtime.Serialization

Public Interface Drawable
  Sub draw(g As Graphics)
End Interface

Public Interface Calculateable
 Sub calc(t As Double) ' t = 0..1
End Interface

'State and Point are Positionable
Public Interface Positionable

  'raise to to detach from Interactive Location
  Event detatch(client As Positionable)

  Property Pos As Drawing.Point
  Property Offset As Drawing.Point

End Interface

Public Interface Animateable
Inherits Drawable, Calculateable, Positionable

End Interface

'for elements that want to use interactive connect 
Public Interface Connectable
  'drag target calls connect to (me) on sender
  Sub Connect(target As Connectable)
End Interface

Public Interface Controllable
Inherits IDisposable

  Event ControlAdded(c As Control)
  Event Disposed(c As Controllable)

End Interface