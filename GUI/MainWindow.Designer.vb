<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
    Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
    Me.ToolStripButton3Play = New System.Windows.Forms.ToolStripButton()
    Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
    Me.ToolStripButton1Save = New System.Windows.Forms.ToolStripButton()
    Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
    Me.ToolStripButton4Select = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripButton2StartState = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripButton2State = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripButton1Line = New System.Windows.Forms.ToolStripButton()
    Me.Canvas1 = New Canvas()
    Me.Starter1 = New Starter()
    Me.ToolStripButton1Load = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripContainer1.ContentPanel.SuspendLayout
    Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout
    Me.ToolStripContainer1.SuspendLayout
    Me.ToolStrip1.SuspendLayout
    Me.ToolStrip3.SuspendLayout
    Me.ToolStrip2.SuspendLayout
    Me.SuspendLayout
    '
    'ToolStripContainer1
    '
    '
    'ToolStripContainer1.ContentPanel
    '
    Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Canvas1)
    Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(856, 479)
    Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ToolStripContainer1.Location = New System.Drawing.Point(166, 0)
    Me.ToolStripContainer1.Name = "ToolStripContainer1"
    Me.ToolStripContainer1.RightToolStripPanelVisible = false
    Me.ToolStripContainer1.Size = New System.Drawing.Size(856, 504)
    Me.ToolStripContainer1.TabIndex = 2
    Me.ToolStripContainer1.Text = "ToolStripContainer1"
    '
    'ToolStripContainer1.TopToolStripPanel
    '
    Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip2)
    Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip3)
    Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolStripComboBox1, Me.ToolStripButton3Play})
    Me.ToolStrip1.Location = New System.Drawing.Point(311, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.Size = New System.Drawing.Size(162, 25)
    Me.ToolStrip1.TabIndex = 0
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripComboBox1
    '
    Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
    Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 25)
    Me.ToolStripComboBox1.ToolTipText = "Input for StateMachin. Is read char by char left to right by statemachine"
    '
    'ToolStripButton3Play
    '
    Me.ToolStripButton3Play.CheckOnClick = true
    Me.ToolStripButton3Play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton3Play.Image = Global.My.Resources.Resources.Start
    Me.ToolStripButton3Play.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton3Play.Name = "ToolStripButton3Play"
    Me.ToolStripButton3Play.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton3Play.Text = "ToolStripButton3"
    '
    'ToolStrip3
    '
    Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.None
    Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1Save, Me.ToolStripButton1Load})
    Me.ToolStrip3.Location = New System.Drawing.Point(133, 0)
    Me.ToolStrip3.Name = "ToolStrip3"
    Me.ToolStrip3.Size = New System.Drawing.Size(87, 25)
    Me.ToolStrip3.TabIndex = 2
    '
    'ToolStripButton1Save
    '
    Me.ToolStripButton1Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton1Save.Image = CType(resources.GetObject("ToolStripButton1Save.Image"),System.Drawing.Image)
    Me.ToolStripButton1Save.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton1Save.Name = "ToolStripButton1Save"
    Me.ToolStripButton1Save.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton1Save.Text = "Save"
    '
    'ToolStrip2
    '
    Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
    Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4Select, Me.ToolStripButton2StartState, Me.ToolStripButton2State, Me.ToolStripButton1Line})
    Me.ToolStrip2.Location = New System.Drawing.Point(8, 0)
    Me.ToolStrip2.Name = "ToolStrip2"
    Me.ToolStrip2.Size = New System.Drawing.Size(102, 25)
    Me.ToolStrip2.TabIndex = 1
    '
    'ToolStripButton4Select
    '
    Me.ToolStripButton4Select.Checked = true
    Me.ToolStripButton4Select.CheckOnClick = true
    Me.ToolStripButton4Select.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ToolStripButton4Select.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton4Select.Image = CType(resources.GetObject("ToolStripButton4Select.Image"),System.Drawing.Image)
    Me.ToolStripButton4Select.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton4Select.Name = "ToolStripButton4Select"
    Me.ToolStripButton4Select.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton4Select.Text = "Select"
    '
    'ToolStripButton2StartState
    '
    Me.ToolStripButton2StartState.CheckOnClick = true
    Me.ToolStripButton2StartState.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton2StartState.Image = Global.My.Resources.Resources.StartState
    Me.ToolStripButton2StartState.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton2StartState.Name = "ToolStripButton2StartState"
    Me.ToolStripButton2StartState.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton2StartState.Text = "Start State"
    '
    'ToolStripButton2State
    '
    Me.ToolStripButton2State.CheckOnClick = true
    Me.ToolStripButton2State.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton2State.Image = Global.My.Resources.Resources.State
    Me.ToolStripButton2State.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton2State.Name = "ToolStripButton2State"
    Me.ToolStripButton2State.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton2State.Text = "State"
    '
    'ToolStripButton1Line
    '
    Me.ToolStripButton1Line.CheckOnClick = true
    Me.ToolStripButton1Line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton1Line.Image = Global.My.Resources.Resources.Line
    Me.ToolStripButton1Line.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton1Line.Name = "ToolStripButton1Line"
    Me.ToolStripButton1Line.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton1Line.Text = "ToolStripButton1"
    '
    'Canvas1
    '
    Me.Canvas1.BackColor = System.Drawing.SystemColors.ActiveBorder
    Me.Canvas1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Canvas1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Canvas1.Location = New System.Drawing.Point(0, 0)
    Me.Canvas1.Mode = Canvas.Modes.AddLine
    Me.Canvas1.Name = "Canvas1"
    Me.Canvas1.Size = New System.Drawing.Size(856, 479)
    Me.Canvas1.TabIndex = 0
    '
    'Starter1
    '
    Me.Starter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Starter1.Client = Me.Canvas1
    Me.Starter1.Dock = System.Windows.Forms.DockStyle.Left
    Me.Starter1.Location = New System.Drawing.Point(0, 0)
    Me.Starter1.Name = "Starter1"
    Me.Starter1.Size = New System.Drawing.Size(166, 504)
    Me.Starter1.TabIndex = 1
    '
    'ToolStripButton1Load
    '
    Me.ToolStripButton1Load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton1Load.Image = CType(resources.GetObject("ToolStripButton1Load.Image"),System.Drawing.Image)
    Me.ToolStripButton1Load.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton1Load.Name = "ToolStripButton1Load"
    Me.ToolStripButton1Load.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton1Load.Text = "Load"
    '
    'MainWindow
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1022, 504)
    Me.Controls.Add(Me.ToolStripContainer1)
    Me.Controls.Add(Me.Starter1)
    Me.Name = "MainWindow"
    Me.Text = "None Deterministice Statemachine Builder"
    Me.ToolStripContainer1.ContentPanel.ResumeLayout(false)
    Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false)
    Me.ToolStripContainer1.TopToolStripPanel.PerformLayout
    Me.ToolStripContainer1.ResumeLayout(false)
    Me.ToolStripContainer1.PerformLayout
    Me.ToolStrip1.ResumeLayout(false)
    Me.ToolStrip1.PerformLayout
    Me.ToolStrip3.ResumeLayout(false)
    Me.ToolStrip3.PerformLayout
    Me.ToolStrip2.ResumeLayout(false)
    Me.ToolStrip2.PerformLayout
    Me.ResumeLayout(false)

End Sub
    Friend WithEvents Canvas1 As Canvas
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1Line As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2State As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3Play As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Starter1 As Starter
    Friend WithEvents ToolStripButton4Select As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2StartState As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1Load As System.Windows.Forms.ToolStripButton

End Class
