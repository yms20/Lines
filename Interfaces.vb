
Public Interface Drawable
 sub draw(g As Graphics )

End Interface

Public Interface Calculateable
 Sub calc (t As Double ) ' t = 0..1
End Interface

Public Interface Animateable 
Inherits Drawable, Calculateable, Positionable  

End Interface

Public Interface Positionable

Property Pos As Drawing.Point 
Property Offset As Drawing.Point 

End Interface
