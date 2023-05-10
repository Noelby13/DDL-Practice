Imports System.Runtime.InteropServices
Imports System.Windows.Interop

Public Class FrmCiudad
    Private Sub FrmCiudad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarRegistros()
    End Sub

    Sub llenarRegistros()
        Dim dCiudad As New DCiudades
        DgvRegistros.DataSource = dCiudad.MostrarRegistros.Tables(0)
        DgvRegistros.Refresh()
        GbRegistro.Text = "Registros almacenados: " & DgvRegistros.RowCount

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim ciudad As New TblCiudad()
            ciudad.Nombre = TxtNombre.Text.Trim
            Dim dCiudad As New DCiudades

            If (dCiudad.GuardarRegistro(ciudad)) Then
                MsgBox("Registro guardado satisfactoriamente ", MsgBoxStyle.Information, "Ciudad")
                TxtId.Clear()
                TxtNombre.Clear()
            End If

        Catch ex As Exception
            MsgBox("No se pudo guardar el registro...", MsgBoxStyle.Information, "Ciudades")
        End Try
        llenarRegistros()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            Dim ciudad As New TblCiudad()
            ciudad.Id = TxtId.Text
            Dim dCiudad As New DCiudades
            If (dCiudad.eliminarRegistro(ciudad)) Then
                MsgBox("Registro eliminado satisfactoriamente ")
                TxtId.Clear()
                TxtNombre.Clear()
            End If
        Catch ex As Exception
            MsgBox("No se pudo eliminar el registro...", MsgBoxStyle.Information, "Ciudades")
        End Try
        llenarRegistros()


    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        Try
            Dim ciudad As New TblCiudad
            Dim dCiudad As New DCiudades
            ciudad.Id = TxtId.Text
            ciudad.Nombre = TxtNombre.Text
            ciudad.Estado = True
            If (dCiudad.editarRegistro(ciudad)) Then
                MsgBox("Registro editado satisfactoriamente ")
                TxtId.Clear()
                TxtNombre.Clear()
            End If


        Catch ex As Exception
            MsgBox("No se pudo editar el registro...", MsgBoxStyle.Information, "Ciudades")
        End Try
        llenarRegistros()
    End Sub

    Private Sub DgvRegistros_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRegistros.CellDoubleClick
        Dim fila As Integer = DgvRegistros.CurrentRow.Index
        TxtId.Text = DgvRegistros.Rows(fila).Cells(0).Value
        TxtNombre.Text = DgvRegistros.Rows(fila).Cells(1).Value

    End Sub
End Class