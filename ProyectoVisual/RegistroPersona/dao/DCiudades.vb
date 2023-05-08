Imports System.Data.SqlClient
Public Class DCiudades

    Public Function MostrarRegistros() As DataSet
        Dim ds As New DataSet
        Try
            Dim conn As New SqlConnection(strConexion)
            Dim tsql As String = "select id as N'Codigo', nombre as N'Ciudad' from ciudad"
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)
        Catch ex As Exception
            MsgBox("Ocurrio un error al obtener los registros", MsgBoxStyle.Critical, "Error")
        End Try
        Return ds
    End Function

End Class
