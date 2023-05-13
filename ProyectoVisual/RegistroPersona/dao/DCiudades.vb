Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing

Public Class DCiudades
    Dim strConexion = My.Settings.StrConnection.ToString()
    Public Function MostrarRegistros() As DataSet
        Dim ds As New DataSet
        Try
            Dim conn As New SqlConnection(strConexion)
            Dim tsql As String = "select id as N'Codigo', nombre as N'Ciudad', estado as N'Estado' from ciudad"
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)
        Catch ex As Exception
            MsgBox("Ocurrio un error al obtener los registros", MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function

    Public Function GuardarRegistro(ByVal ciudad As TblCiudad) As Boolean
        Dim resultado As Boolean = False
        Try
            Dim conn As New SqlConnection(strConexion)
            Dim cmd As New SqlCommand()
            Dim tsql As String = "insert into Ciudad (nombre, estado) values (@nombre,@estado)"
            cmd.Parameters.AddWithValue("@nombre", ciudad.Nombre)
            cmd.Parameters.AddWithValue("@estado", ciudad.Estado)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = tsql
            cmd.Connection = conn
            cmd.Connection.Open()
            If (cmd.ExecuteNonQuery <> 0) Then
                resultado = True
            End If
        Catch ex As Exception
            MsgBox("Ocurrio un error al guardar el registros", MsgBoxStyle.Critical, "Error")
        End Try



        Return resultado

    End Function

    Public Function eliminarRegistro(ByVal ciudad As TblCiudad)
        Dim resultado As Boolean = False
        Try
            Dim conn As New SqlConnection(strConexion)
            Dim cmd As New SqlCommand()
            Dim tsql As String = "delete from Ciudad where id = (@id) "
            cmd.Parameters.AddWithValue("@id", ciudad.Id)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = tsql
            cmd.Connection = conn
            cmd.Connection.Open()
            If (cmd.ExecuteNonQuery <> 0) Then
                resultado = True
            End If
        Catch ex As Exception
            MsgBox("Ocurrio un error al eliminar el registros", MsgBoxStyle.Critical, "Error")
        End Try
        Return resultado


    End Function


    Public Function editarRegistro(ByVal ciudad As TblCiudad)
        Dim resultado As Boolean = False
        Try
            Dim conn As New SqlConnection(strConexion)
            Dim cmd As New SqlCommand()
            Dim tsql As String = "UPDATE Ciudad set nombre =@nombre, estado = @estado  where id = @id"

            cmd.Parameters.AddWithValue("@id", ciudad.Id)
            cmd.Parameters.AddWithValue("@nombre", ciudad.Nombre)
            cmd.Parameters.AddWithValue("@estado", ciudad.Estado)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = tsql
            cmd.Connection = conn
            cmd.Connection.Open()
            If (cmd.ExecuteNonQuery <> 0) Then
                resultado = True
            End If
        Catch ex As Exception
            MsgBox("Ocurrio un error al editar el registros", MsgBoxStyle.Critical, "Error")
        End Try
        Return resultado


    End Function

    Public Function comprobarCiudad(ByVal ciudad As TblCiudad) As Boolean
        Dim b = False
        Try
            Dim ds As New DataTable
            Dim conn As New SqlConnection(strConexion)
            Dim tsql As String = "select * from Ciudad where nombre = @nombre"
            Dim da As New SqlDataAdapter(tsql, conn)
            da.SelectCommand.Parameters.AddWithValue("@nombre", ciudad.Nombre)
            da.Fill(ds)
            If ds.Rows.Count > 0 Then Return True

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return b
    End Function
End Class
