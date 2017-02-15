<%@ Page Language="vb" MasterPageFile="~/master.Master" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="Anexo.login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="center-block">
	    	<div class="container">
				<div class="row">
				<div class="col-sm-5">
						<h2>Login</h2><br />
                    <p>Ingrese su nombre de usuario y contraseña para acceder al sitio.</p>
                        <br /><br />
                   Nombre Usuario:<br /> <asp:TextBox ID="TextUsuario"  runat="server"  CssClass="form-control"></asp:TextBox><br />
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ErrorMessage="*Ingrese su Usuario." ForeColor="#0099ff" ControltoValidate="TextUsuario"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
                    <br />
						Contraseña:<br />  <asp:TextBox ID="TextContraseña" runat="server"  CssClass="form-control"  TextMode="Password"  ></asp:TextBox><br />
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ErrorMessage="*Ingrese su Contraseña." ForeColor="#0099ff" ControltoValidate="TextContraseña"  Font-Italic="true" >
                   </asp:RequiredFieldValidator>
                        <br />
                   <asp:Button ID="BotonIngresar" runat="server" Text="Ingresar" class="btn btn-blue "/>
                    <script type ="text/javascript">
                        function ingresofallo() {
                            alert("ERROR! USUARIO O CONTRASEÑA INCORRECTA!");
                        }
                  </script>
					</div>
				</div>
			</div>
		</div>
  </asp:Content>
