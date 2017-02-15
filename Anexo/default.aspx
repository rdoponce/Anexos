<%@ Page Language="vb" MasterPageFile="~/master.Master" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Anexo._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="center-block">
        <div class="section">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4">
                        <p>Busqueda Por Nombre</p>
                        <asp:TextBox runat="server" ID="TextNombre" Placeholder="Nombre" CssClass="form-control"></asp:TextBox><br />
                        <asp:Button ID="BotonBuscarNombre" runat="server" Text="Buscar" class="btn btn-blue " />
                        <asp:Label runat="server" ID="lblvalidar" Visible="false"  ForeColor="#0099ff" Font-Italic="true"></asp:Label>
                        <br />
                    </div>
                    <div class="col-sm-4">
                        <p>Busqueda Por Grupo</p>
                        <asp:DropDownList runat="server" ID="ddlDepto" DataSourceID="SqlDataSource2" DataTextField="departamento" DataValueField="departamento" CssClass="form-control"  AppendDataBoundItems="true">
                            <asp:ListItem>Seleccione Departamento</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Button ID="BotonBuscarGrupo" runat="server" Text="Buscar" class="btn btn-blue " />
                        <br />
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DesarrolloConnectionString %>" SelectCommand="SELECT [id_departamento], [departamento] FROM [Departamentos] ORDER BY [departamento]"></asp:SqlDataSource>
                         </div> 
                    <div class="col-sm-4">
                        <br /><br />
                        <div class="text-right">
                            <a href="#" style="color:#0099ff"  class="dropdown-toggle" data-toggle="dropdown"  >Bienvenido <asp:Label runat="server" ID="label1" ></asp:Label></a>
                          <asp:Button ID="Salir" runat="server" Text="Salir" class="btn btn-blue "  Width="90" OnClick="Salir_Click"  OnClientClick="return confirm('Está seguro que quiere Salir?');"/>
                            </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="col-sm-12"> 
            <asp:GridView runat="server" ID="gvanexo" CssClass="table table-bordered" Width="1000px" HeaderStyle-BackColor="White" HeaderStyle-ForeColor="#0099ff" >
                <Columns>
                    <asp:TemplateField HeaderText="modificar" >
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="modificar"   ></asp:LinkButton>
                        </ItemTemplate>
                        <ControlStyle ForeColor="#0099ff" />
                    </asp:TemplateField>
                </Columns>
            <HeaderStyle BackColor="White" ForeColor="#0099ff"></HeaderStyle>
            </asp:GridView>
            <br />
        </div>
    </div>
</asp:Content>
