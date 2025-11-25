
Imports ControlVehiculos.Utils.SwalUtils
Public Class FormVehiculo
    Inherits System.Web.UI.Page
    Public vehiculo As New Vehiculo()
    Protected dbhelper As New dbVehiculo()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Try
            If txtPlaca.Text = "" Or txtMarca.Text = "" Or txtModelo.Text = "" Or txtAnio.Text = "" Or txtColor.Text = "" Then
                ShowErrorMessage(Me, "Error...", "Debes completar los campos")
                Return
            End If
            vehiculo.IdPropietario = Convert.ToInt32(txtIdPropietario.Text)
            vehiculo.Placa = txtPlaca.Text
            vehiculo.Marca = txtMarca.Text
            vehiculo.Modelo = txtModelo.Text
            vehiculo.Anio = txtAnio.Text
            vehiculo.Color = txtColor.Text
            If dbhelper.create(vehiculo) Then
                ShowSuccessMessage(Me, "Éxito", "Vehículo registrado exitosamente")
                limpiarFormulario()
            Else
                ShowErrorMessage(Me, "Error...", "Ocurrió un error al registrar el vehículo")
            End If

            gvVehiculo.DataBind()
        Catch ex As Exception
            ShowErrorMessage(Me, "Error...", ex.Message)
        End Try
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            Dim vehiculo = New Vehiculo With {
                .IdVehiculo = editando.Value(),
                .IdPropietario = Convert.ToInt32(txtIdPropietario.Text),
                .Marca = txtMarca.Text,
                .Modelo = txtModelo.Text,
                .Anio = txtAnio.Text,
                .Color = txtColor.Text,
                .Placa = txtPlaca.Text
            }

            Dim mensaje = dbhelper.update(vehiculo)
            If mensaje.Contains("Error") Then
                ShowErrorMessage(Me, "Error...", mensaje)
            Else
                ShowUpdateMessage(Me, "Actualizado", "Vehículo actualizado correctamente")
            End If
            gvVehiculo.DataBind()
            gvVehiculo.EditIndex = -1
            limpiarFormulario()
        Catch ex As Exception
            ShowErrorMessage(Me, "Error...", ex.Message)
        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        limpiarFormulario()
    End Sub

    Protected Sub gvVehiculo_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(gvVehiculo.DataKeys(e.RowIndex).Value)
            dbhelper.delete(id)
            e.Cancel = True
            ShowDeleteMessage(Me, "Eliminado", "Vehículo eliminado correctamente")
            gvVehiculo.DataBind()
        Catch ex As Exception
            ShowErrorMessage(Me, "Error...", "No se pudo eliminar el vehículo")
        End Try
    End Sub

    Protected Sub gvVehiculo_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Protected Sub gvVehiculo_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvVehiculo.EditIndex = -1
        gvVehiculo.DataBind()
    End Sub

    Protected Sub gvVehiculo_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(gvVehiculo.DataKeys(e.RowIndex).Value)

            Dim vehiculo As Vehiculo = New Vehiculo With {
                .IdPropietario = Convert.ToInt32(e.NewValues("IdPropietario")),
                .Placa = e.NewValues("Placa"),
                .Marca = e.NewValues("Marca"),
                .Modelo = e.NewValues("Modelo"),
                .Anio = e.NewValues("Anio"),
                .Color = e.NewValues("Color"),
                .IdVehiculo = id
            }
            dbhelper.update(vehiculo)
            ShowUpdateMessage(Me, "Actualizado", "Vehículo actualizado correctamente")
            gvVehiculo.EditIndex = -1
            gvVehiculo.DataBind()
            e.Cancel = True

        Catch ex As Exception
            ShowErrorMessage(Me, "Error...", ex.Message)
        End Try
    End Sub
    Protected Sub gvVehiculo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = gvVehiculo.SelectedRow()
        Dim idVehiculo As Integer
        Integer.TryParse(gvVehiculo.DataKeys(row.RowIndex).Value.ToString(), idVehiculo)
        txtIdPropietario.Text = row.Cells(3).Text
        txtPlaca.Text = row.Cells(4).Text
        txtMarca.Text = row.Cells(5).Text
        txtModelo.Text = row.Cells(6).Text
        txtAnio.Text = CDate(row.Cells(7).Text).ToString("yyyy-MM-dd")
        txtColor.Text = row.Cells(8).Text
        editando.Value = idVehiculo
        btnActualizar.Visible = True
        btnCancelar.Visible = True
        btnGuardar.Visible = False
    End Sub
    Protected Sub limpiarFormulario()
        btnActualizar.Visible = False
        btnGuardar.Visible = True
        btnCancelar.Visible = False
        txtIdPropietario.Text = ""
        txtPlaca.Text = ""
        txtMarca.Text = ""
        txtModelo.Text = ""
        txtAnio.Text = ""
        txtColor.Text = ""
    End Sub
End Class