Public Class Persona
    Private _idPersona As Integer
    Private _nombre As String
    Private _apellido As String
    Private _nacionalidad As String
    Private _fechaNacimiento As Date
    Private _telefono As String

    Public Sub New()
        ' Constructor por defecto
    End Sub

    Public Sub New(idPersona As Integer, nombre As String, apellido As String, nacionalidad As String, fechaNacimiento As Date, telefono As String)
        Me.IdPersona = idPersona
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Nacionalidad = nacionalidad
        Me.FechaNacimiento = fechaNacimiento
        Me.Telefono = telefono
    End Sub

    Public Property IdPersona As Integer
        Get
            Return _idPersona
        End Get
        Set(value As Integer)
            _idPersona = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Apellido As String
        Get
            Return _apellido
        End Get
        Set(value As String)
            _apellido = value
        End Set
    End Property

    Public Property Nacionalidad As String
        Get
            Return _nacionalidad
        End Get
        Set(value As String)
            _nacionalidad = value
        End Set
    End Property

    Public Property FechaNacimiento As Date
        Get
            Return _fechaNacimiento
        End Get
        Set(value As Date)
            _fechaNacimiento = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property
End Class
