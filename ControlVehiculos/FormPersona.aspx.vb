Imports ControlVehiculos.Utils.SwalUtils
Public Class FormPersona
    Inherits System.Web.UI.Page
    Public persona As New Persona()
    Protected dbHelper As New dbPersona()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnActualizar.Visible = False
    End Sub
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Try
            If txtNombre.Text = "" Or txtApellido1.Text = "" Or txtApellido2.Text = "" Or txtNacionalidad.Text = "" Or txtTelefono.Text = "" Then
                ShowErrorMessage(Me, "Error...", "Debes completar los campos")
                Return
            End If
            persona.Nombre = txtNombre.Text
            persona.Apellido1 = txtApellido1.Text
            persona.Apellido2 = txtApellido2.Text
            persona.Nacionalidad = txtNacionalidad.Text
            persona.FechaNacimiento = txtFechaNacimiento.Text
            persona.Telefono = txtTelefono.Text
            If dbHelper.create(persona) Then
                ShowSuccessMessage(Me, "Éxito", "Persona creada exitosamente")
                lblMensaje.Text = "Persona creada"
                limpiarFormulario()
            Else
                lblMensaje.Text = "Ocurrio un error"
            End If

            gvPersonas.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub gvPersonas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        Try
            Dim id As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
            dbHelper.delete(id)
            e.Cancel = True
            ShowDeleteMessage(Me, "Eliminado", "Persona eliminada correctamente")
            gvPersonas.DataBind()
        Catch ex As Exception
            ShowErrorMessage(Me, "Error...", "No se pudo eliminar la persona")
        End Try

    End Sub

    Protected Sub gvPersonas_RowEditing(sender As Object, e As GridViewEditEventArgs)



    End Sub

    Protected Sub gvPersonas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvPersonas.EditIndex = -1
        gvPersonas.DataBind()
    End Sub

    Protected Sub gvPersonas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)


        Dim id As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
        Dim persona As Persona = New Persona With {
            .Nombre = e.NewValues("Nombre"),
            .Apellido1 = e.NewValues("Apellido1"),
            .Apellido2 = e.NewValues("Apellido2"),
            .Nacionalidad = e.NewValues("Nacionalidad"),
            .FechaNacimiento = e.NewValues("FechaNacimiento"),
            .Telefono = e.NewValues("Telefono"),
            .IdPersona = id
        }
        ShowUpdateMessage(Me, "Actualizado", "Persona actualizada correctamente")
        dbHelper.update(persona)
        gvPersonas.DataBind()
        e.Cancel = True
        gvPersonas.EditIndex = -1

    End Sub

    Protected Sub gvPersonas_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim row As GridViewRow = gvPersonas.SelectedRow()
        Dim id As Integer = Convert.ToInt32(row.Cells(2).Text)
        Dim persona As Persona = New Persona()

        txtNombre.Text = row.Cells(3).Text
        txtApellido1.Text = row.Cells(4).Text
        txtApellido2.Text = row.Cells(5).Text
        txtNacionalidad.Text = row.Cells(6).Text
        txtFechaNacimiento.Text = row.Cells(7).Text
        txtTelefono.Text = row.Cells(8).Text
        editando.Value = id
        btnActualizar.Visible = True
        btnCancelar.Visible = True
        btnGuardar.Visible = False

    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Dim persona As Persona = New Persona With {
            .Nombre = txtNombre.Text(),
            .Apellido1 = txtApellido1.Text(),
            .Apellido2 = txtApellido2.Text(),
            .Nacionalidad = txtNacionalidad.Text(),
            .FechaNacimiento = txtFechaNacimiento.Text(),
            .Telefono = txtTelefono.Text(),
            .IdPersona = editando.Value()
        }
        ShowUpdateMessage(Me, "Actualizado", "Persona actualizada correctamente")
        dbHelper.update(persona)
        gvPersonas.DataBind()
        gvPersonas.EditIndex = -1
    End Sub
    Protected Sub limpiarFormulario()
        btnActualizar.Visible = False
        btnGuardar.Visible = True
        btnCancelar.Visible = False
        txtNombre.Text = ""
        txtApellido1.Text = ""
        txtApellido2.Text = ""
        txtNacionalidad.Text = ""
        txtFechaNacimiento.Text = ""
        txtTelefono.Text = ""
    End Sub
    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        limpiarFormulario()
    End Sub
End Class
