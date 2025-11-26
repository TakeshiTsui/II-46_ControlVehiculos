Public Class Propietario
    Inherits Persona
    Private _idPropietario As Integer
    Private _idPersona As Integer

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(idPropietario As Integer, idPersona As Integer, persona As Persona)
        MyBase.New(persona.IdPersona, persona.Nombre,
                   persona.Apellido1, persona.Apellido2,
                   persona.Nacionalidad,
                   persona.FechaNacimiento, persona.Telefono)
        Me.IdPropietario = idPropietario
        Me.IdPersona = idPersona
    End Sub
    Public Sub New(idPropietario As Integer, idPersona As Integer)
        Me.IdPropietario = idPropietario
        Me.IdPersona = idPersona
    End Sub

    Public Property IdPropietario As Integer
        Get
            Return _idPropietario
        End Get
        Set(value As Integer)
            _idPropietario = value
        End Set
    End Property

    Public Property IdPersona As Integer
        Get
            Return _idPersona
        End Get
        Set(value As Integer)
            _idPersona = value
        End Set
    End Property
End Class
