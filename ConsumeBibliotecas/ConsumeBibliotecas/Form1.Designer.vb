<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txbContenido = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txbRuta = New System.Windows.Forms.TextBox()
        Me.lblContenido = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txbContenido
        '
        Me.txbContenido.Location = New System.Drawing.Point(73, 132)
        Me.txbContenido.Name = "txbContenido"
        Me.txbContenido.Size = New System.Drawing.Size(173, 20)
        Me.txbContenido.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(73, 168)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Pulsa aqui"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txbRuta
        '
        Me.txbRuta.Location = New System.Drawing.Point(73, 57)
        Me.txbRuta.Name = "txbRuta"
        Me.txbRuta.Size = New System.Drawing.Size(173, 20)
        Me.txbRuta.TabIndex = 2
        '
        'lblContenido
        '
        Me.lblContenido.AutoSize = True
        Me.lblContenido.Location = New System.Drawing.Point(70, 107)
        Me.lblContenido.Name = "lblContenido"
        Me.lblContenido.Size = New System.Drawing.Size(55, 13)
        Me.lblContenido.TabIndex = 3
        Me.lblContenido.Text = "Contenido"
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(70, 31)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(86, 13)
        Me.lblRuta.TabIndex = 4
        Me.lblRuta.Text = "Ruta del Archivo"
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.lblResultado.Location = New System.Drawing.Point(70, 229)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(0, 13)
        Me.lblResultado.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 323)
        Me.Controls.Add(Me.lblResultado)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.lblContenido)
        Me.Controls.Add(Me.txbRuta)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txbContenido)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txbContenido As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txbRuta As TextBox
    Friend WithEvents lblContenido As Label
    Friend WithEvents lblRuta As Label
    Friend WithEvents lblResultado As Label
End Class
