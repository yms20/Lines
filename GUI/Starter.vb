Public Class Starter

WithEvents m_client As Canvas

Public  Property Client As Canvas 
  Set
    m_client = Value 
    'AddHandler m_client.created , AddressOf OnClientGetBaby 
  End Set
  Get
    Return m_client 
  End Get
End Property


Public Sub OnClientGetBaby (sender As Canvas , baby As Line ) Handles m_client.createdStartable 

  Dim startButton = New Button  () With {.Text = baby.Name & " L: " & baby.length , .Tag = baby , .Size = New Size (FlowLayoutPanel1.Width ,20) } 
  AddHandler startButton.Click , AddressOf start 

  FlowLayoutPanel1.Controls.Add (startButton  )
End Sub

Sub start ( sender As Object , e As EventArgs ) 
    Client.addRunner(ctype (ctype(sender,Button).Tag, Line) ) 
End Sub

End Class
