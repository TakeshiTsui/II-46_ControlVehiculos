Public Class SiteMaster
    Inherits MasterPage
    Protected Autenticado As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim Usuario As Usuario = Session("Usuario")
        Autenticado = Usuario IsNot Nothing ' Verifica si el usuario está autenticado
        Dim esAdmin As Boolean = Usuario?.Rol = "2" ' Verifica si el usuario es administrador
        liAdmin.Visible = esAdmin ' Muestra u oculta el enlace de administración según el rol
    End Sub

    Protected Sub btnLogOut_Click(sender As Object, e As EventArgs)
        Session.Clear()
        Session.Abandon()
        Response.Redirect("Login.aspx")
    End Sub
End Class