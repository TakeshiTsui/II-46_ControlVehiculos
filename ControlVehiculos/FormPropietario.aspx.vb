
Public Class FormPropietario
    Inherits System.Web.UI.Page
    Protected dbHelper As New dbPersona()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPersonas()
        End If
    End Sub

    Public Sub CargarPersonas()
        ddlPersona.DataSource = dbHelper.Consulta()
        ddlPersona.DataTextField = "NombreCompleto"
        ddlPersona.DataValueField = "IdPersona"
        ddlPersona.DataBind()
        ddlPersona.Items.Insert(0, New ListItem("-- Seleccione una persona --", "0"))
    End Sub
    Public Sub LimpiarCampos()
        txtNombre.Text = ""
        txtApellido1.Text = ""
        txtApellido2.Text = ""
        txtNacionalidad.Text = ""
        txtFechaNacimiento.Text = ""
        txtTelefono.Text = ""
    End Sub
End Class