Imports System.Data.SqlClient

Public Class dbVehiculo

    Public ReadOnly ConectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString
    Private ReadOnly dbhelper As New DbHelper() 'clase para mejorar conexion y manejo de errores

    Public Function create(Vehiculo As Vehiculo) As Boolean
        Try
            Dim sql As String = "INSERT INTO Vehiculo (IdPropietario, Placa, Marca, Modelo, Anio, Color) VALUES (@IdPropietario, @Placa, @Marca, @Modelo, @Anio, @Color)"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@IdPropietario", Vehiculo.IdPropietario),
            New SqlParameter("@Placa", Vehiculo.Placa),
            New SqlParameter("@Marca", Vehiculo.Marca),
            New SqlParameter("@Modelo", Vehiculo.Modelo),
            New SqlParameter("@Anio", Vehiculo.Anio),
            New SqlParameter("@Color", Vehiculo.Color)
        }

            dbhelper.ExecuteNonQuery(sql, Parametros)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function delete(ByRef id As Integer) As String
        Try
            Dim sql As String = "DELETE FROM Vehiculo WHERE IdVehiculo = @IdVehiculo"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@IdVehiculo", id)
        }
            dbhelper.ExecuteNonQuery(sql, Parametros)
        Catch ex As Exception
        End Try
        Return "Persona eliminada"
    End Function

    Public Function update(ByRef Vehiculo As Vehiculo) As String
        Try
            Dim sql As String = "UPDATE Vehiculo SET IdPropietario = @IdPropietario, Placa = @Placa, Modelo = @Modelo, Marca = @Marca, Anio = @Anio, Color = @Color WHERE IdVehiculo = @IdVehiculo"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@IdVehiculo", Vehiculo.IdVehiculo),
            New SqlParameter("@IdPropietario", Vehiculo.IdPropietario),
            New SqlParameter("@Placa", Vehiculo.Placa),
            New SqlParameter("@Marca", Vehiculo.Marca),
            New SqlParameter("@Modelo", Vehiculo.Modelo),
            New SqlParameter("@Anio", Vehiculo.Anio),
            New SqlParameter("@Color", Vehiculo.Color)
        }
            Using connetion As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Return "Error al actualizar la persona: " & ex.Message
        End Try
        Return "Persona actualizada"
    End Function

    Public Function Consulta() As DataTable
        Dim sql As String = "SELECT *, CONCAT(Nombre, ' ', Apellido1, ' ', Apellido2, ' ') NombreCompleto FROM Personas"
        Return dbhelper.ExecuteQuery(sql, Nothing)
    End Function

End Class