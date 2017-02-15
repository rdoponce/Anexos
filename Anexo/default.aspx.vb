Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class _default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'VALIDAR DATOS DE USUARIO
        If Session("nombre_usuario") IsNot Nothing And Session("contraseña_usuario") IsNot Nothing Then
            Dim usuario As String = Session("nombre_usuario").ToString
            Dim contraseña As String = Session("contraseña_usuario").ToString
            label1.Text = usuario
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub BotonBuscarGrupo_Click(sender As Object, e As EventArgs) Handles BotonBuscarGrupo.Click
        If ddlDepto.SelectedIndex <> 0 Then
            'RESCATAR DATO DE DEPARTAMENTO EN  DROPDOWNLIST Y BUSCAR EL REGISTRO SELECCIONADO PARA MOSTRARLO EN EL GRIDVIEW
            Dim depto As String = ddlDepto.SelectedItem.ToString
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
                con.Open()
                Dim query As String = "SELECT Departamentos.departamento, anexo, nombre, cargo, mail from Anexos INNER JOIN Departamentos ON Anexos.id_departamento = Departamentos.id_departamento Where Departamentos.departamento=@departamento"
                Dim cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@departamento", depto)
                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable()
                da.Fill(dt)
                gvanexo.DataSource = dt
                gvanexo.DataBind()
                con.Close()
                lblvalidar.Visible = False
                gvanexo.Visible = True
            End Using
        Else
            gvanexo.Visible = False
        End If

    End Sub

    Protected Sub BotonBuscarNombre_Click(sender As Object, e As EventArgs) Handles BotonBuscarNombre.Click
        If TextNombre.Text <> "" Then
            'RESCATAR DATO NOMBRE EN EL TEXTBOX Y BUSCAR REGISTRO PARA MOSTRARLO EN EL GRIDVIEW
            Dim nombre As String = TextNombre.Text
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
                con.Open()
                Dim query As String = "SELECT Departamentos.departamento, anexo, nombre, cargo, mail from Anexos INNER JOIN Departamentos ON Anexos.id_departamento = Departamentos.id_departamento WHERE nombre LIKE '%'+@nombre+'%'"
                Dim cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@nombre", nombre)
                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable()
                da.Fill(dt)
                gvanexo.DataSource = dt
                gvanexo.DataBind()
                con.Close()
                lblvalidar.Visible = False
                gvanexo.Visible = True
            End Using
        Else
            lblvalidar.Visible = True
            lblvalidar.Text = "Debe Ingresar Un Nombre."
            gvanexo.Visible = False
        End If

    End Sub


    Protected Sub gvanexo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvanexo.SelectedIndexChanged
        'ENVIAR DATO POR URL DEL ANEXO QUE SE QUIERE MODIFICAR
        Dim anexo As String = gvanexo.SelectedRow().Cells(2).Text
        Response.Redirect(HttpUtility.HtmlDecode("ModificarDatos.aspx?Anexo=" & anexo))
    End Sub

    Protected Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click
        'VOLVER AL LOGIN
        Session.Clear()
        Session.Abandon()
        Session.RemoveAll()
        Response.Redirect("login.aspx")
    End Sub
End Class