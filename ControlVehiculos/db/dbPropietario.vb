Imports System.Data.SqlClient

Public Class dbPropietario
    Public ReadOnly ConectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString
    Private ReadOnly dbhelper As New DbHelper() 'clase para mejorar conexion y manejo de errores

    Public Function create(Persona As Persona) As String
        Try
            Dim sql As String = "INSERT INTO Propietario (IdPersona) VALUES (@IdPersona)"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@IdPersona", Persona.IdPersona)
        }

            dbhelper.ExecuteNonQuery(sql, Parametros)
        Catch ex As Exception
            Return "Error al guardar la persona: " & ex.Message
        End Try

        Return True
    End Function

    Public Function Consulta() As DataTable
        Dim sql As String = "SELECT P.IdPropietario, PR.IdPersona, " &
                        "PR.Nombre + ' ' + PR.Apellido1 + ' ' + PR.Apellido2 AS NombreCompleto " &
                        "FROM Propietario P " &
                        "INNER JOIN Personas PR ON P.IdPersona = PR.IdPersona"
        Return dbhelper.ExecuteQuery(sql, Nothing)
    End Function
End Class
