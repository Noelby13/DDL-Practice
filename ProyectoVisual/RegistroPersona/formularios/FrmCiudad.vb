﻿Public Class FrmCiudad
    Private Sub FrmCiudad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarRegistros()
    End Sub

    Sub llenarRegistros()
        Dim dCiudad As New DCiudades
        DgvRegistros.DataSource = dCiudad.MostrarRegistros.Tables(0)
        DgvRegistros.Refresh()
        GbRegistro.Text = "Registros almacenados: " & DgvRegistros.RowCount

    End Sub
End Class