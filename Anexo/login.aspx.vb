Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class login
    Inherits System.Web.UI.Page

    Protected Sub BotonIngresar_Click(sender As Object, e As EventArgs) Handles BotonIngresar.Click
        'RESCATAR DATOS DE TEXTBOX
        Dim usuario As String = TextUsuario.Text.ToString
        Dim contraseña As String = TextContraseña.Text.ToString

        'CONEXION A LA BASE DE DATOS Y VALIDACIÓN DE DATOS
        Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
            con.Open()
            Dim query As String = "SELECT nombre_usuario, contraseña_usuario FROM usuario WHERE nombre_usuario=@nombre_usuario AND contraseña_usuario=@contraseña_usuario "

            Dim cmd As SqlCommand = New SqlCommand(query, con)

            cmd.Parameters.AddWithValue("@nombre_usuario", usuario)
            cmd.Parameters.AddWithValue("@contraseña_usuario", contraseña)

            'Ejecutar query
            Try
                Dim dr As SqlDataReader = cmd.ExecuteReader
                If dr.Read Then
                    'ENVIAR DATOS A LA PAGINA PRINCIPAL
                    Session("nombre_usuario") = usuario
                    Session("contraseña_usuario") = contraseña
                    Response.Redirect("default.aspx")

                Else
                    ScriptManager.RegisterStartupScript(BotonIngresar, [GetType], "ingresofallo", "ingresofallo();", True)
                End If
            Catch ex As System.Data.SqlClient.SqlException
            End Try
            con.Close()
        End Using
    End Sub
End Class