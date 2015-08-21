Imports System.Xml.Serialization
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Text
Imports System.Xml


Public Class MainWindow

Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
ToolStripComboBox1.Text = "11001010"
End Sub




  Public Sub startStateMachine()
    Dim instruction As New Queue(Of String)

    Dim inputString As String = ToolStripComboBox1.Text
    Dim seet As New HashSet(Of Char)

    For i As Integer = 0 To inputString.Length - 1
      seet.Add(inputString.Chars(i))
      instruction.Enqueue(inputString.Chars(i))
    Next

    Canvas1.startStateMachine(instruction)

  End Sub

'Toolstrip2 - Canvas Mode Select 

Private Sub ToolStripButton2StartState_Click(sender As Object, e As EventArgs) Handles ToolStripButton2StartState.Click
  Canvas1.Mode = Canvas.Modes.AddStartState
End Sub

Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2State.Click
  Canvas1.Mode = Canvas.Modes.AddState
End Sub

Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1Line.Click
  Canvas1.Mode = Canvas.Modes.AddLine
End Sub


Private Sub ToolStripButton4Select_Click(sender As Object, e As EventArgs) Handles ToolStripButton4Select.Click
  Canvas1.Mode = Canvas.Modes.Select
End Sub

Private Sub ToolStrip2UncheckOthers(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked
  For Each t As ToolStripButton In ToolStrip2.Items
    If t Is sender Then
      Continue For
    End If
    t.Checked = False
  Next
End Sub

'Toolstrip 1 - Input and start
Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3Play.Click
  startStateMachine()
End Sub

Private Sub ToolStripComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripComboBox1.KeyDown
  Select Case e.KeyCode
    Case Keys.Enter
      If Not ToolStripComboBox1.Items.Contains(ToolStripComboBox1.Text) Then
        ToolStripComboBox1.Items.Add(ToolStripComboBox1.Text)
      End If
      startStateMachine()
  End Select
End Sub

Private Sub Canvas1_MouseDown(sender As Object, e As MouseEventArgs) Handles Canvas1.MouseDown
  Select Case e.Button
    'on right cllick
    Case Windows.Forms.MouseButtons.Right
      Select Case Canvas1.Mode
        'in state mode 
        Case Canvas.Modes.AddState
          'go back to selection mode
          ToolStripButton4Select.PerformClick()
      End Select

  End Select
End Sub

Private Sub ToolStripButton1Save_Click(sender As Object, e As EventArgs) Handles ToolStripButton1Save.Click

saveToClipboardAndDefaultFile (Of Items ) (Canvas1.Drawables ) 
End Sub

Private Sub ToolStripButton1Load_Click( sender As Object,  e As EventArgs) Handles ToolStripButton1Load.Click
  readFromDefaultFile (Of Items)
End Sub


Sub readFromDefaultFile (Of T) ()
  Dim serializer As New DataContractSerializer(GetType (T) )
  Dim  fs As new FileStream("machine.xml", FileMode.Open)

  Try

    Dim xmlDictReader  = XmlDictionaryReader.CreateTextReader (fs,New XmlDictionaryReaderQuotas ())

    Dim obj as T = CType ( serializer.ReadObject ( xmlDictReader ) , T) 

    Canvas1.Drawables.AddRange (obj) 
  Catch ex As Exception
    Clipboard.SetText(ex.ToString)
    MsgBox(ex.ToString)  
  Finally 
    fs.Close ()  
  End Try

End Sub
Sub saveToClipboardAndDefaultFile (Of T) (data As T)


  Dim serializer As New DataContractSerializer(data.GetType )
  'streamtarget for xmlWriter (with nice line indent setting)
  Dim writerMemory As New MemoryStream

  'set up to nicen text output
  Dim setting As New XmlWriterSettings() With {.Indent  = True}
  'streamtarget for datacontract serializer
  Dim writerNice As XmlWriter = XmlWriter.Create (writerMemory,setting ) 


  Try
    serializer.WriteObject(writerNice, data)
    'Clipboard.SetText(Encoding.UTF8.GetString(writerMemory.ToArray()))
    writerNice.Flush 

    Clipboard.SetText(Encoding.UTF8.GetString(writerMemory.ToArray()))
    
    'to file 
    Dim objWriter As New System.IO.StreamWriter("machine.xml")
    'objWriter.Write(Encoding.UTF8.GetString(writerMemory.ToArray()))
    objWriter.Write (Encoding.UTF8.GetString(writerMemory.ToArray()))
    objWriter.Flush ()
    objWriter.Close()
  Catch ex As Exception
    Clipboard.SetText(ex.ToString)
    MsgBox(ex.ToString)
  End Try


End Sub

Private Sub Canvas1_MouseUp(sender As Object, e As MouseEventArgs)

End Sub

Private Sub Canvas1_Click(sender As Object, e As EventArgs)

End Sub



End Class
