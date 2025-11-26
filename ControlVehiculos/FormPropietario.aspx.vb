Imports ControlVehiculos.Utils.SwalUtils
Public Class FormPropietario
    Inherits System.Web.UI.Page
    Protected dbPersona As New dbPersona()
    Protected dbPropietario As New dbPropietario()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPersonas()
        End If
    End Sub

    Public Sub CargarPersonas()
        ddlPersona.DataSource = dbPersona.Consulta()
        ddlPersona.DataTextField = "NombreCompleto"
        ddlPersona.DataValueField = "IdPersona"
        ddlPersona.DataBind()
        ddlPersona.Items.Insert(0, New ListItem("-- Seleccione una persona --", "0"))
    End Sub
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Try
            Dim IdPersona = ddlPersona.SelectedValue
            Dim mensaje = dbPropietario.create(New Persona With {.IdPersona = IdPersona})
            If mensaje.Contains("Error") Then
                ShowErrorMessage(Me, "Error...", mensaje)
            Else
                ShowSuccessMessage(Me, "Éxito", "Persona creada exitosamente")
            End If
        Catch ex As Exception
            ShowErrorMessage(Me, "Error...", "Ocurrió un error al guardar el propietario")
        End Try
    End Sub
End Class