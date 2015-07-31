<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InteractiveRuleEdit
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
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.SuspendLayout
    '
    'TextBox1
    '
    Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    Me.TextBox1.BackColor = System.Drawing.Color.WhiteSmoke
    Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TextBox1.Location = New System.Drawing.Point(0, 0)
    Me.TextBox1.Margin = New System.Windows.Forms.Padding(0)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(14, 11)
    Me.TextBox1.TabIndex = 0
    Me.TextBox1.Text = "0"
    Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'InteractiveRuleEdit
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.AutoSize = true
    Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.BackColor = System.Drawing.Color.Black
    Me.Controls.Add(Me.TextBox1)
    Me.Margin = New System.Windows.Forms.Padding(0)
    Me.Name = "InteractiveRuleEdit"
    Me.Size = New System.Drawing.Size(14, 11)
    Me.ResumeLayout(false)
    Me.PerformLayout

End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
