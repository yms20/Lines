<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Canvas
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
    Me.components = New System.ComponentModel.Container()
    Me.TimerRefresh = New System.Windows.Forms.Timer(Me.components)
    Me.SuspendLayout
    '
    'TimerRefresh
    '
    Me.TimerRefresh.Enabled = true
    Me.TimerRefresh.Interval = 20
    '
    'Canvas
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.ActiveBorder
    Me.DoubleBuffered = true
    Me.Name = "Canvas"
    Me.Size = New System.Drawing.Size(883, 463)
    Me.ResumeLayout(false)

End Sub
    Friend WithEvents TimerRefresh As System.Windows.Forms.Timer
End Class
