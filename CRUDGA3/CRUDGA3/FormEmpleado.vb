Public Class FormEmpleado


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim detalleForm As New TablaEmpleado() ' Asegúrate de que este formulario está creado
        detalleForm.Show() ' Mostrar el nuevo formulario
        Me.Hide() '
    End Sub
End Class