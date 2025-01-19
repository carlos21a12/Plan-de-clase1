Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports CRUDGA3.TiendaComputo
Imports CRUDINCRIPCIONES.EjemploCRUD
Imports CRUDINCRIPCIONES.EjemploCRUD.Conexion
Public Class TablaEmpleado

    Public Enum Acciones
        Create
        Read
        Update
        Delete
    End Enum

    ' Inicializa la variable para la acción actual
    Dim AccionActual As Acciones = Acciones.Create

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Formulario1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Get_Data()
    End Sub

    Private Sub Get_Data()
        GrdEmpleado.Columns.Clear()
        GrdEmpleado.DataSource = Conexion.GetData("SELECT * FROM Empleados")

        ' Crear columnas de acción
        Dim read As New DataGridViewImageColumn()
        read.Image = pbxRead.Image
        GrdEmpleado.Columns.Add(read)
        GrdEmpleado.Columns(GrdEmpleado.Columns.Count - 1).Width = 25

        Dim update As New DataGridViewImageColumn()
        update.Image = pbxUpdate.Image
        GrdEmpleado.Columns.Add(update)
        GrdEmpleado.Columns(GrdEmpleado.Columns.Count - 1).Width = 25

        Dim delete As New DataGridViewImageColumn()
        delete.Image = pbxDelete.Image
        GrdEmpleado.Columns.Add(delete)
        GrdEmpleado.Columns(GrdEmpleado.Columns.Count - 1).Width = 25
    End Sub

    Private Sub Clear_Fields()
        TxtIdEmpleado.Text = String.Empty
        TxtNombreUsuario.Text = String.Empty
        TxtContrasena.Text = String.Empty
        TxtNombreCompleto.Text = String.Empty
        TxtRol.Text = String.Empty
        TxtCorreoElectronico.Text = String.Empty
        TxtDireccion.Text = String.Empty
    End Sub

    Private Function Check_Fields() As Boolean
        If String.IsNullOrWhiteSpace(TxtNombreUsuario.Text) Then
            MessageBox.Show("Ingrese un nombre de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtNombreUsuario.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(TxtContrasena.Text) Then
            MessageBox.Show("Ingrese una contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtContrasena.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(TxtNombreCompleto.Text) Then
            MessageBox.Show("Ingrese el nombre completo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtNombreCompleto.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(TxtRol.Text) Then
            MessageBox.Show("Ingrese un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtRol.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(TxtCorreoElectronico.Text) Then
            MessageBox.Show("Ingrese un correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtCorreoElectronico.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function GetInsert() As String
        Return $"INSERT INTO Empleados (nombre_usuario, contraseña, nombre_completo, rol, correo_electronico, direccion) VALUES ('{TxtNombreUsuario.Text}', '{TxtContrasena.Text}', '{TxtNombreCompleto.Text}', '{TxtRol.Text}', '{TxtCorreoElectronico.Text}', '{TxtDireccion.Text}')"
    End Function

    Private Function GetUpdate() As String
        Return $"UPDATE Empleados SET nombre_usuario = '{TxtNombreUsuario.Text}', contraseña = '{TxtContrasena.Text}', nombre_completo = '{TxtNombreCompleto.Text}', rol = '{TxtRol.Text}', correo_electronico = '{TxtCorreoElectronico.Text}', direccion = '{TxtDireccion.Text}' WHERE id_empleado = {TxtIdEmpleado.Text}"
    End Function

    Private Function GetDelete() As String
        Return $"DELETE FROM Empleados WHERE id_empleado = {TxtIdEmpleado.Text}"
    End Function

    Private Sub pctOk_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub read_record(id As String)
        Dim Query As String = $"SELECT * FROM Empleados WHERE id_empleado={id}"
        Dim reg As DataTable = Conexion.GetData(Query)
        If reg.Rows.Count > 0 Then
            Dim dr As DataRow = reg.Rows(0)
            TxtIdEmpleado.Text = dr("id_empleado").ToString()
            TxtNombreUsuario.Text = dr("nombre_usuario").ToString()
            TxtContrasena.Text = dr("contraseña").ToString()
            TxtNombreCompleto.Text = dr("nombre_completo").ToString()
            TxtRol.Text = dr("rol").ToString()
            TxtCorreoElectronico.Text = dr("correo_electronico").ToString()
            TxtDireccion.Text = dr("direccion").ToString()
        End If
    End Sub

    Private Sub GrdEmpleado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrdEmpleado.CellContentClick
        Dim ID_Index As String = GrdEmpleado.Rows(e.RowIndex).Cells(0).Value.ToString()
        Select Case e.ColumnIndex
            Case 5 ' VER
                AccionActual = Acciones.Read
                Clear_Fields()
                pnlCampos.Visible = True
                read_record(ID_Index)
                pnlCampos.Enabled = False
            Case 6 ' MODIFICAR
                AccionActual = Acciones.Update
                Clear_Fields()
                pnlCampos.Visible = True
                read_record(ID_Index)
                pnlCampos.Enabled = True
                TxtIdEmpleado.ReadOnly = True
            Case 7 ' ELIMINAR
                AccionActual = Acciones.Delete
                If MessageBox.Show("¿Está seguro de eliminar el registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Conexion.Execute(GetDelete())
                    Get_Data()
                End If
        End Select
    End Sub

    Private Sub pcbExit_Click(sender As Object, e As EventArgs)

    End Sub


End Class