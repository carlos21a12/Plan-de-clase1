Imports System.Data.SqlClient
Imports CRUDGA3.TiendaComputo
' Asegúrate de que este es tu espacio de nombres

Public Class LOGIN
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim usuario As String = txtUsuario.Text.Trim()
        Dim contrasena As String = txtContraseña.Text.Trim()
        Dim esEmpleado As Boolean = rbtnEmpleado.Checked ' RadioButton para seleccionar empleado
        Dim esCliente As Boolean = rbtnCliente.Checked ' RadioButton para seleccionar cliente

        ' Validación de campos vacíos
        If String.IsNullOrWhiteSpace(usuario) Or String.IsNullOrWhiteSpace(contrasena) Then
            MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Consultas parametrizadas
        Dim queryEmpleado As String = "SELECT COUNT(*) FROM Empleados WHERE nombre_usuario = @usuario AND contraseña = @contrasena"
        Dim queryCliente As String = "SELECT COUNT(*) FROM Clientes WHERE nombre_completo = @usuario AND contrasenia = @contrasena"

        Try
            ' Probar la conexión a la base de datos
            Using conn As SqlConnection = Conexion.GetConnection()
                Dim parameters As New List(Of SqlParameter) From {
                    New SqlParameter("@usuario", usuario),
                    New SqlParameter("@contrasena", contrasena)
                }

                If esEmpleado Then
                    ' Comprobar si el usuario es un empleado
                    Dim empleadoCount As Integer = CInt(Conexion.GetData(queryEmpleado, parameters).Rows(0)(0))
                    If empleadoCount > 0 Then
                        ' Redirigir a la interfaz de empleado
                        Dim empleadoForm As New FormEmpleado() ' Asegúrate de tener este formulario creado
                        empleadoForm.Show()
                        Me.Hide()
                        Return
                    End If
                ElseIf esCliente Then
                    ' Comprobar si el usuario es un cliente
                    Dim clienteCount As Integer = CInt(Conexion.GetData(queryCliente, parameters).Rows(0)(0))
                    If clienteCount > 0 Then
                        ' Redirigir a la interfaz de cliente
                        Dim clienteForm As New FormCliente() ' Asegúrate de tener este formulario creado
                        clienteForm.Show()
                        Me.Hide()
                        Return
                    End If
                End If

                ' Si no se encontró el usuario en ninguna tabla
                lblError.Text = "Usuario o contraseña incorrectos."
                lblError.Visible = True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al conectar a la base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Evento para limpiar el mensaje de error al escribir
    Private Sub txtUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtUsuario.TextChanged, txtContraseña.TextChanged
        lblError.Visible = False
    End Sub

    Private Sub LOGIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

