<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormVehiculo.aspx.vb" Inherits="ControlVehiculos.FormVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="editando" runat="server"/> 

    <div class="container d-flex flex-column mb-3 gap-2">
        <asp:DropDownList ID="ddlPropietario" runat="server"><asp:ListItem Text ="Seleccione un propietario" Value="" ></asp:ListItem></asp:DropDownList>

    <asp:TextBox ID="txtIdPropietario" CssClass="form-control" placeholder="Propietario" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtPlaca" CssClass="form-control" placeholder="Placa del Vehiculo" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtMarca" CssClass="form-control" placeholder="Marca" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtModelo" CssClass="form-control" placeholder="Modelo" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtAnio" CssClass="form-control" placeholder="Fecha de Fabricacion" TextMode="date" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtColor" CssClass="form-control" placeholder="Color" runat="server"></asp:TextBox>
    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary btn-hover-move" Text="Guardar" OnClick="btnGuardar_Click" />
    <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary btn-hover-move" visible="false" Text="Actualizar" OnClick="btnActualizar_Click" />
    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger btn-hover-move" visible="false" Text="Cancelar" OnClick="btnCancelar_Click" />  

    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

</div>
    <asp:GridView ID="gvVehiculo" CssClass="table table-striped table-hover table-success" runat="server" AutoGenerateColumns="False"
    DataSourceID="SqlDataSource2" DataKeyNames="idVehiculo"
    OnRowDeleting="gvVehiculo_RowDeleting" 
    OnRowEditing="gvVehiculo_RowEditing" 
    OnRowCancelingEdit="gvVehiculo_RowCancelingEdit" 
    OnRowUpdating="gvVehiculo_RowUpdating" 
    OnSelectedIndexChanged="gvVehiculo_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary" />
        <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-secondary" />
        <asp:BoundField DataField="IdVehiculo" HeaderText="IdVehiculo" ReadOnly="True" Visible="false" SortExpression="IdVehiculo" InsertVisible="False" />
        <asp:BoundField DataField="IdPropietario" HeaderText="Propietario" SortExpression="Propietario" />
        <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa" />
        <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
        <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" />
        <asp:BoundField DataField="Anio" HeaderText="Fabricación" SortExpression="Fabricación" />
        <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color" />
        <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
    </Columns>
</asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" ProviderName="<%$ ConnectionStrings:II-46ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Vehiculo]"></asp:SqlDataSource>
</asp:Content>
