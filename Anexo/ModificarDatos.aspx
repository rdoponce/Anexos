<%@ Page Language="vb" MasterPageFile="~/master.Master" AutoEventWireup="false" CodeBehind="ModificarDatos.aspx.vb" Inherits="Anexo.ModificarDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-8">
                <h2>Modificar Anexo</h2>
                <br />
                <div class="col-sm-8">
                    <strong>Anexo: </strong><br />
                    <asp:TextBox ID="TextAnexo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ErrorMessage="*Debe completar todos los campos." ForeColor="#0099ff" ControltoValidate="TextAnexo"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server"  ErrorMessage="*Ingrese Valores Numericos"  ForeColor="#0099ff" Font-Italic="true" ControlToValidate="TextAnexo" ValidationExpression="^[0-9]*"> 
                         </asp:RegularExpressionValidator>
                    <br />
                </div>
                 <div class="col-sm-8">
                    <strong>Nombre: </strong><br />
                    <asp:TextBox ID="TextNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ErrorMessage="*Debe completar todos los campos." ForeColor="#0099ff" ControltoValidate="TextNombre"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div class="col-sm-8">
                    <strong>Correo: </strong><br />
                    <asp:TextBox ID="TextCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" ErrorMessage="*Debe completar todos los campos." ForeColor="#0099ff" ControltoValidate="TextCorreo"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator   runat="server" ErrorMessage="*Correo Inválido."  ForeColor="#0099ff" Font-Italic="true" ControlToValidate="TextCorreo" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$">
                    </asp:RegularExpressionValidator>
                    <br />
                </div>
                <div class="col-sm-8">
                    <strong>Departamento: </strong><br />
                    <asp:DropDownList runat="server" ID="ddldepto" DataSourceID="SqlDataSource1" DataTextField="departamento" DataValueField="id_departamento" >
                        <asp:ListItem>Seleccione Departamento</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DesarrolloConnectionString %>" SelectCommand="SELECT [id_departamento], [departamento] FROM [Departamentos] ORDER BY [departamento]"></asp:SqlDataSource>
                    <br /> <br />
                </div>
                <div class="col-sm-8">
                    <strong>Cargo: </strong><br />
                    <asp:TextBox ID="TextCargo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator5" ErrorMessage="*Debe completar todos los campos." ForeColor="#0099ff" ControltoValidate="TextCargo"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
                    <br />
                </div> <br />
                <div class="col-sm-8">
                    <asp:Button ID="BotonModificarOfe" runat="server" Text="Modificar" class="btn btn-blue "  />
                </div>
                <script type ="text/javascript">
                           function modificarexito() {
                               alert("EL REGISTRO SE HA MODIFICADO CON EXITO!");
                               location.href = 'default.aspx';
                        }
                           function modificarfallo() {
                               alert("ERROR! EL REGISTRO NO SE HA MODIFICADO");
                           }
                  </script>
                </div>
            <div class="col-sm-4">
                        <br /><br />
                        <div class="text-right">
                            <a href="#" style="color:#0099ff"  class="dropdown-toggle" data-toggle="dropdown" >Bienvenido <asp:Label runat="server" ID="label1"  ></asp:Label></a>
                          <asp:Button ID="Salir" runat="server" Text="Salir" class="btn btn-blue "  Width="90" OnClick="Salir_Click"  OnClientClick="return confirm('Está seguro que quiere Salir?');"/>
                            </div>
                    </div>
        </div>
    </div>
</asp:Content>
