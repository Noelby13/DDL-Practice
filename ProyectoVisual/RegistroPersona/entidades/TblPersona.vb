Public Class TblPersona
    Dim id As Integer
    Dim primerNombre As String
    Dim segundoNombre As String
    Dim primerApellido As String
    Dim fechaNacimiento As DateTime
    Dim sexo As Boolean
    Dim telefono As String
    Dim email As String
    Dim residencia As String
    Dim idCiudad As Integer
    Dim estado As Boolean

    Public Sub New(id As Integer, primerNombre As String, segundoNombre As String, primerApellido As String, fechaNacimiento As Date, sexo As Boolean, telefono As String, email As String, residencia As String, idCiudad As Integer, estado As Boolean)
        Me.id = id
        Me.primerNombre = primerNombre
        Me.segundoNombre = segundoNombre
        Me.primerApellido = primerApellido
        Me.fechaNacimiento = fechaNacimiento
        Me.sexo = sexo
        Me.telefono = telefono
        Me.email = email
        Me.residencia = residencia
        Me.idCiudad = idCiudad
        Me.estado = estado
    End Sub

    Public Property Id1 As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property

    Public Property PrimerNombre1 As String
        Get
            Return primerNombre
        End Get
        Set(value As String)
            primerNombre = value
        End Set
    End Property

    Public Property SegundoNombre1 As String
        Get
            Return segundoNombre
        End Get
        Set(value As String)
            segundoNombre = value
        End Set
    End Property

    Public Property PrimerApellido1 As String
        Get
            Return primerApellido
        End Get
        Set(value As String)
            primerApellido = value
        End Set
    End Property

    Public Property FechaNacimiento1 As Date
        Get
            Return fechaNacimiento
        End Get
        Set(value As Date)
            fechaNacimiento = value
        End Set
    End Property

    Public Property Sexo1 As Boolean
        Get
            Return sexo
        End Get
        Set(value As Boolean)
            sexo = value
        End Set
    End Property

    Public Property Telefono1 As String
        Get
            Return telefono
        End Get
        Set(value As String)
            telefono = value
        End Set
    End Property

    Public Property Email1 As String
        Get
            Return email
        End Get
        Set(value As String)
            email = value
        End Set
    End Property

    Public Property Residencia1 As String
        Get
            Return residencia
        End Get
        Set(value As String)
            residencia = value
        End Set
    End Property

    Public Property IdCiudad1 As Integer
        Get
            Return idCiudad
        End Get
        Set(value As Integer)
            idCiudad = value
        End Set
    End Property

    Public Property Estado1 As Boolean
        Get
            Return estado
        End Get
        Set(value As Boolean)
            estado = value
        End Set
    End Property
End Class
