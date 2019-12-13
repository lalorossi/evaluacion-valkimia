<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Facturas.aspx.cs" Inherits="UI.Web.WebForm1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" Runat="Server">
	<link rel="stylesheet" href="bootstrap/projection/assets/css/main.css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">
    <asp:Panel ID="formPanel" runat="server">
        
        <asp:Label ID="IdLabel" runat="server" Text="ID de factura: "></asp:Label>
        <asp:TextBox ID="idTextBox" runat="server" type="number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvId" runat="server" controlToValidate="idTextBox" ErrorMessage="Campo requerido (ID)" Text="*"></asp:RequiredFieldValidator>
        <%-- No lo pude hacer andar sin queu la ID se ingrese a mano --%>
        <br/>
        
        <asp:Label ID="clienteLabel" runat="server" Text="Cliente: "></asp:Label>
        <asp:DropDownList ID="dropClientes" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvCliente" runat="server" controlToValidate="dropClientes" ErrorMessage="Campor requerido (cliente)">*</asp:RequiredFieldValidator>
        
        <br/>
        
        <asp:Label ID="fechaLabel" runat="server" Text="Fecha: "></asp:Label>
        <asp:TextBox ID="fechaTextBox" runat="server" type="date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFecha" runat="server" controlToValidate="fechaTextBox" ErrorMessage="Campo requerido (fecha)" Text="*"></asp:RequiredFieldValidator>
        
        <br/>
        
        <asp:Label ID="importeLabel" runat="server" Text="Importe: "></asp:Label>
        <asp:TextBox ID="importeTextBox" runat="server" type="number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvImporte" runat="server" controlToValidate="importeTextBox" ErrorMessage="Campo requerido (cupo)">*</asp:RequiredFieldValidator>
        
        <br/>
        
        <asp:Label ID="detalleLabel" runat="server" Text="Detalle: "></asp:Label>
        <asp:TextBox ID="DetalleTextBox" runat="server" TextMode="MultiLine" type="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDetalle" runat="server" controlToValidate="DetalleTextBox" ErrorMessage="Campo requerido (detalle)">*</asp:RequiredFieldValidator>
        
        <br/>
        <br />
        <br />
        
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <br />
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsumUsuario" runat="server" HeaderText="Corrija los siguientes campos" />
</asp:Content>