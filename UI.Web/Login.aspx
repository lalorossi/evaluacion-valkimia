<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" Runat="Server">
	<link rel="stylesheet" href="bootstrap/projection/assets/css/main.css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:TextBox ID="txtCliente" runat="server" placeholder="Email de cliente" TabIndex="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCliente" runat="server" ErrorMessage="Campo requerido (cliente)" ControlToValidate="txtCliente">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" placeholder="Contraseña" TabIndex="2" type="password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Campo requerido (contraseña)" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Ingresar" style="float:right" OnClick="btnLogin_Click"/>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vsumLogIn" runat="server" />
    <asp:ListBox ID="lbRegistro" runat="server" Visible="False">
        <asp:ListItem Text="Envíe un mail a algún admin con sus datos para crear la cuenta" />
    </asp:ListBox>
</asp:Content>
