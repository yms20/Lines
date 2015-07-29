Public Class State 
Implements Drawable, Positionable 


  

#region  "Positionable Implementations"
Dim m_pos As New  Drawing.Point (10,10) 


  Public Property Offset As new Drawing.Point ( -13 , -13 ) Implements Positionable.Offset
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

  Public locator As new InteractiveLocation (Me ) 
  Public connector As New InteractiveConnect (Me)

  Public outs As new List(Of Line)

  Public rules As New List(Of Rule )

  Public Sub applyWork(input As Generic.Queue(Of String)  ) 
    If input.Count = 0 then Return 
    Console.WriteLine (input(0))
    For Each r As Rule In rules 
      If r.token = input (0) 
        Console.WriteLine (String. Format ("State {0} Verarbeite Token  {1} ", Name , input.Dequeue ))
        r.target.applyWork (input)
        Exit For 
      End If
    Next
  End Sub


  Public Sub new
    locator.BackColor = Color.AliceBlue 
    locator.Width = 20
    locator.Height = 20
    locator.Offset = New Drawing.Point (- locator.Width /2, _ 
                                         - locator.Height /2) 'center of state circle - center of locator

    connector.BackColor = Color.Aqua 
    connector.Width = 10
    connector.Height = 10

    locator.children.Add (connector ) 
  End Sub
 

  Public Sub draw(g As Graphics) Implements Drawable.draw
    g.DrawEllipse (Pens.Black  , New Rectangle (Pos + Offset ,New Size (26,26)))

    For Each l As Line In outs 
      l.draw (g) 
    Next

   ' outs.ForEach (Function (l As Line ) l.draw (g) )
  End Sub

Sub addRule(state As State)
  

    Dim line As New Line 
    line.Points.Add (New Point ( Pos, locator ))    
    line.Points.Add (New Point (state.Pos,state.locator ))

    outs.Add (line) 

    rules.Add (New Rule With {.target = state, .token = Name })

 End Sub 



End Class
