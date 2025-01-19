<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LOGIN
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.lblError = New System.Windows.Forms.Label()
        Me.rbtnEmpleado = New System.Windows.Forms.RadioButton()
        Me.rbtnCliente = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(467, 129)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(100, 20)
        Me.txtUsuario.TabIndex = 0
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(492, 242)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 1
        Me.btnLogin.Text = "Button1"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(467, 166)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.Size = New System.Drawing.Size(100, 20)
        Me.txtContraseña.TabIndex = 2
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Location = New System.Drawing.Point(337, 74)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(39, 13)
        Me.lblError.TabIndex = 3
        Me.lblError.Text = "Label1"
        '
        'rbtnEmpleado
        '
        Me.rbtnEmpleado.AutoSize = True
        Me.rbtnEmpleado.Location = New System.Drawing.Point(265, 224)
        Me.rbtnEmpleado.Name = "rbtnEmpleado"
        Me.rbtnEmpleado.Size = New System.Drawing.Size(90, 17)
        Me.rbtnEmpleado.TabIndex = 4
        Me.rbtnEmpleado.TabStop = True
        Me.rbtnEmpleado.Text = "rbtnEmpleado"
        Me.rbtnEmpleado.UseVisualStyleBackColor = True
        '
        'rbtnCliente
        '
        Me.rbtnCliente.AutoSize = True
        Me.rbtnCliente.Location = New System.Drawing.Point(265, 264)
        Me.rbtnCliente.Name = "rbtnCliente"
        Me.rbtnCliente.Size = New System.Drawing.Size(75, 17)
        Me.rbtnCliente.TabIndex = 5
        Me.rbtnCliente.TabStop = True
        Me.rbtnCliente.Text = "rbtnCliente"
        Me.rbtnCliente.UseVisualStyleBackColor = True
        '
        'LOGIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.rbtnCliente)
        Me.Controls.Add(Me.rbtnEmpleado)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtUsuario)
        Me.Name = "LOGIN"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtContraseña As TextBox
    Friend WithEvents lblError As Label
    Friend WithEvents rbtnEmpleado As RadioButton
    Friend WithEvents rbtnCliente As RadioButton
End Class
