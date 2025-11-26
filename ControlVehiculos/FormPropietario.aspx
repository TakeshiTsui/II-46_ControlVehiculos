<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPropietario.aspx.vb" Inherits="ControlVehiculos.FormPropietario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex flex-column mb-3 gap-2">
    <asp:DropDownList ID="ddlPersona" cssclass="form-control" runat="server"> 
        <asp:ListItem Text ="Seleccione una persona" Value="" ></asp:ListItem>
    </asp:DropDownList>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPropietario" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="IdPropietario" HeaderText="IdPropietario" InsertVisible="False" ReadOnly="True" SortExpression="IdPropietario" />
                <asp:BoundField DataField="IdPersona" HeaderText="IdPersona" SortExpression="IdPersona" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" SelectCommand="SELECT * FROM [Propietario]"></asp:SqlDataSource>

    <asp:Button ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" runat="server" />
    

</div>

</asp:Content>
