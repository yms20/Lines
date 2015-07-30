
Public Interface Drawable
 sub draw(g As Graphics )

End Interface

Public Interface Calculateable
 Sub calc (t As Double ) ' t = 0..1
End Interface

Public Interface Animateable 
Inherits Drawable, Calculateable, Positionable  

End Interface

'State and Point are Positionable
Public Interface Positionable

Property Pos As Drawing.Point 
Property Offset As Drawing.Point 

End Interface

Public Interface Controllable
  
  Event ControlAdded (c As Control )
  Function getControls As List(Of Control)

End Interface