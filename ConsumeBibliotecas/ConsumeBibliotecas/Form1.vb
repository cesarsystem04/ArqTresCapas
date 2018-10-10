
Imports cNegocio.cNegocio

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim strRuta As String
        Dim strContenido As String
        Dim objNegocio As New cNegocio.cNegocio
        Dim bolResultado As Boolean

        lblResultado.Text = ""
        strRuta = txbRuta.Text
        strContenido = txbContenido.Text
        bolResultado = objNegocio.CrearArchivo(strContenido, strRuta, False)

        If (bolResultado) Then

            lblResultado.Text = "Exito"
        Else
            lblResultado.Text = "Error"

        End If





    End Sub
End Class
