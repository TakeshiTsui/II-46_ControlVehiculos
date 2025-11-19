<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="ControlVehiculos.FormPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="editando" runat="server"/> 

<div class="container d-flex flex-column mb-3 gap-2">

    <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtApellido1" CssClass="form-control" placeholder="Primer Apellido" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtApellido2" CssClass="form-control" placeholder="Segundo Apellido" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtNacionalidad" CssClass="form-control" placeholder="Nacionalidad" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" placeholder="Fecha de Nacimiento" TextMode="Date" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="Telefono" TextMode="Phone" runat="server"></asp:TextBox>
    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary btn-hover-move" Text="Guardar" OnClick="btnGuardar_Click" />
    <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary btn-hover-move" visible="false" Text="Actualizar" OnClick="btnActualizar_Click" />
    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger btn-hover-move" visible="false" Text="Cancelar" OnClick="btnCancelar_Click" />  

    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

</div>
<asp:GridView ID="gvPersonas" CssClass="table table-striped table-hover table-success" runat="server" AutoGenerateColumns="False"
    DataSourceID="SqlDataSource2" DataKeyNames="idPersona"
    OnRowDeleting="gvPersonas_RowDeleting" 
    OnRowEditing="gvPersonas_RowEditing" 
    OnRowCancelingEdit="gvPersonas_RowCancelingEdit" 
    OnRowUpdating="gvPersonas_RowUpdating" 
    OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary" />
        <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-secondary" />
        <asp:BoundField DataField="idPersona" HeaderText="idPersona" ReadOnly="True" Visible="false" SortExpression="idPersona" InsertVisible="False" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
        <asp:BoundField DataField="Apellido1" HeaderText="Apellido1" SortExpression="Apellido1" />
        <asp:BoundField DataField="Apellido2" HeaderText="Apellido2" SortExpression="Apellido2" />
        <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" SortExpression="Nacionalidad" />
        <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" SortExpression="FechaNacimiento" />
        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
        <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" ProviderName="<%$ ConnectionStrings:II-46ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Personas]"></asp:SqlDataSource>
</asp:Content>
