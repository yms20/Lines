<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    Me.Canvas1 = New Line.Canvas()
    Me.Starter1 = New Line.Starter()
    Me.SuspendLayout
    '
    'Canvas1
    '
    Me.Canvas1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Canvas1.Location = New System.Drawing.Point(0, 0)
    Me.Canvas1.Name = "Canvas1"
    Me.Canvas1.Size = New System.Drawing.Size(1022, 504)
    Me.Canvas1.TabIndex = 0
    '
    'Starter1
    '
    Me.Starter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Starter1.Client = Me.Canvas1
    Me.Starter1.Dock = System.Windows.Forms.DockStyle.Left
    Me.Starter1.Location = New System.Drawing.Point(0, 0)
    Me.Starter1.Name = "Starter1"
    Me.Starter1.Size = New System.Drawing.Size(106, 504)
    Me.Starter1.TabIndex = 1
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1022, 504)
    Me.Controls.Add(Me.Starter1)
    Me.Controls.Add(Me.Canvas1)
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(false)

End Sub
    Friend WithEvents Canvas1 As Line.Canvas
    Friend WithEvents Starter1 As Line.Starter

End Class
