Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Public Class ModificarDatos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'VALIDAR DATOS DEL USUARIO
        If Not IsPostBack Then
            If Session("nombre_usuario") IsNot Nothing And Session("contraseña_usuario") IsNot Nothing Then
                Dim usuario As String = Session("nombre_usuario").ToString
                Dim contraseña As String = Session("contraseña_usuario").ToString
                label1.Text = usuario
                'RESCATAR VARIABLE DE URL
                'MOSTRAR DATOS DEL REGISTRO EN LOS TEXTBOX
                Dim anexo As String = Request.QueryString("Anexo").ToString
                Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
                    con.Open()
                    Dim query As String = "SELECT id_departamento, anexo, nombre, cargo, mail FROM Anexos  WHERE anexo=@anexo"
                    Dim cmd As SqlCommand = New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@anexo", anexo)
                    Dim Reader As SqlDataReader = cmd.ExecuteReader()
                    If Reader.Read() Then
                        ddldepto.SelectedValue = Reader.GetValue(0)
                        TextAnexo.Text = Reader.GetValue(1).ToString
                        TextNombre.Text = Reader.GetValue(2).ToString
                        TextCargo.Text = Reader.GetValue(3).ToString
                        TextCorreo.Text = Reader.GetValue(4).ToString
                    End If
                End Using
            Else
                Response.Redirect("login.aspx")
            End If
        End If
    End Sub

    Protected Sub BotonModificarOfe_Click(sender As Object, e As EventArgs) Handles BotonModificarOfe.Click
        'RESCATAR DATOS DEL REGISTRO EN LOS TEXTBOX
        Dim reqanexo As String = Request.QueryString("Anexo").ToString
        Dim anexo As String = TextAnexo.Text
        Dim nombre As String = TextNombre.Text
        Dim correo As String = TextCorreo.Text
        Dim departamento As Int32 = ddldepto.SelectedValue
        Dim cargo As String = TextCargo.Text
        Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
            con.Open()
            'ACTUALIZAR DATOS DEL REGISTRO
            Dim query As String = "UPDATE Anexos SET id_departamento=@departamento, anexo=@anexo, nombre=@nombre, cargo=@cargo, mail=@correo WHERE anexo=@reqanexo"
            Dim cmd As SqlCommand = New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@anexo", anexo)
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@correo", correo)
            cmd.Parameters.AddWithValue("@departamento", departamento)
            cmd.Parameters.AddWithValue("@reqanexo", reqanexo)
            cmd.Parameters.AddWithValue("@cargo", cargo)
            'Ejecutar query
            Try
                cmd.ExecuteNonQuery()
                ScriptManager.RegisterStartupScript(BotonModificarOfe, [GetType], "modificarexito", "modificarexito();", True)
                TextAnexo.Text = ""
                TextNombre.Text = ""
                TextCorreo.Text = ""
                TextCargo.Text = ""
            Catch ex As System.Data.SqlClient.SqlException
                ScriptManager.RegisterStartupScript(BotonModificarOfe, [GetType], "modificarfallo", "modificarfallo();", True)
            End Try
            con.Close()

        End Using
    End Sub

    Protected Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click
        'VOLVER AL LOGIN
        Session.Clear()
        Session.Abandon()
        Session.RemoveAll()
        Response.Redirect("login.aspx")
    End Sub
End Class