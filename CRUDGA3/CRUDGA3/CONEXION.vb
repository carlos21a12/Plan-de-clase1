Imports System.Data.SqlClient

Namespace TiendaComputo ' O el nombre que prefieras
    Friend NotInheritable Class Conexion
        ' Cadena de conexión a la base de datos
        Private Shared ReadOnly connectionString As String = "Data Source=LAB2-PC15;Initial Catalog=TiendaEquiposComputo;User ID=PE;Password=123"

        ' Método para obtener una conexión a la base de datos
        Public Shared Function GetConnection() As SqlConnection
            Dim conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Return conn
            Catch ex As Exception
                ' Manejo de errores de conexión
                Throw New Exception("Error al conectar a la base de datos: " & ex.Message)
            End Try
        End Function

        ' Método para ejecutar consultas que devuelven un DataTable
        Public Shared Function GetData(query As String, Optional parameters As List(Of SqlParameter) = Nothing) As DataTable
            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)
                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters.ToArray())
                    End If

                    Using adap As New SqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adap.Fill(dt)
                        Return dt
                    End Using
                End Using
            End Using
        End Function

        ' Método para ejecutar comandos sin resultados (INSERT, UPDATE, DELETE)
        Public Shared Function Execute(query As String, Optional parameters As List(Of SqlParameter) = Nothing) As Boolean
            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)
                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters.ToArray())
                    End If
                    cmd.ExecuteNonQuery()
                    Return True
                End Using
            End Using
        End Function
    End Class
End Namespace
