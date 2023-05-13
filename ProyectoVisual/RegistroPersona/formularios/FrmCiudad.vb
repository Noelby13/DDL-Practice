Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Interop

Public Class FrmCiudad
    Private Sub FrmCiudad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarRegistros()
        TxtNombre.Select()
    End Sub

    Private Function validarCampos(ByVal opcion As Integer) As Boolean
        Dim B = False
        '1 Opcion Guardar
        If opcion = 1 Then
            If TxtNombre.Text <> "" Then
                B = True
            End If
        End If
        '2 Opcion editar
        If opcion = 2 Then
            If (TxtId.Text <> "" And TxtNombre.Text <> "") Then
                B = True
            End If
        End If
        '3 Opcion eliminar
        If opcion = 3 Then
            If TxtId.Text <> "" Then
                B = True
            End If
        End If
        Return B
    End Function


    Sub llenarRegistros()
        Dim dCiudad As New DCiudades
        DgvRegistros.DataSource = dCiudad.MostrarRegistros.Tables(0)
        DgvRegistros.Refresh()
        GbRegistro.Text = "Registros almacenados: " & DgvRegistros.RowCount

    End Sub


    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If Not validarCampos(1) Then
                MsgBox("La información esta incompleta", MsgBoxStyle.Information, "Ciudad")
                Return

            End If
            Dim ciudad As New TblCiudad()
            ciudad.Nombre = TxtNombre.Text.Trim
            Dim dCiudad As New DCiudades

            If dCiudad.comprobarCiudad(ciudad) Then
                lbl_advertencia.Text = "Ese nombre ya existe"
                Exit Sub
            End If

            If (dCiudad.GuardarRegistro(ciudad)) Then
                MsgBox("Registro guardado satisfactoriamente ", MsgBoxStyle.Information, "Ciudad")
                BtnNuevo.PerformClick()
            End If


        Catch ex As Exception
            MsgBox("No se pudo guardar el registro...", MsgBoxStyle.Information, "Ciudades")
        End Try
        llenarRegistros()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            If Not validarCampos(3) Then
                MsgBox("La información esta incompleta", MsgBoxStyle.Information, "Ciudad")
                Return
            End If

            Dim ciudad As New TblCiudad()
            ciudad.Id = TxtId.Text
            Dim dCiudad As New DCiudades

            If (dCiudad.eliminarRegistro(ciudad)) Then
                MsgBox("Registro eliminado satisfactoriamente ")
                BtnNuevo.PerformClick()
            End If

        Catch ex As Exception
            MsgBox("No se pudo eliminar el registro...", MsgBoxStyle.Information, "Ciudades")
        End Try
        llenarRegistros()

    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        Try
            If Not validarCampos(2) Then
                MsgBox("La información esta incompleta", MsgBoxStyle.Information, "Ciudad")
                Return
            End If

            Dim ciudad As New TblCiudad
            Dim dCiudad As New DCiudades
            ciudad.Id = Convert.ToInt32(TxtId.Text)
            ciudad.Nombre = TxtNombre.Text
            ciudad.Estado = Convert.ToBoolean(chkEstado.Checked)

            If (dCiudad.editarRegistro(ciudad)) Then
                MsgBox("Registro editado satisfactoriamente ")
                BtnNuevo.PerformClick()
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
        Dim estado = DgvRegistros.Rows(fila).Cells(2).Value

        If estado Then
            chkEstado.Checked = True
        Else
            chkEstado.Checked = False
        End If

    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        TxtId.Clear()
        TxtNombre.Clear()
        TxtNombre.Select()

    End Sub

    Private Sub TxtNombre_TextChanged(sender As Object, e As EventArgs) Handles TxtNombre.TextChanged
        lbl_advertencia.Text = ""

    End Sub


End Class