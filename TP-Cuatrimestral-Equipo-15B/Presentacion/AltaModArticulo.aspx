<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaModArticulo.aspx.cs" Inherits="Presentacion.AltaModArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="m-3">
                  <asp:Label ID="lblCategoria" runat="server" Text="Categoria:"></asp:Label>
                  <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
            </div>
            <div class="m-3">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre de Artículo: "></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </div>
            <div class="m-3">
                <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
                <asp:DropDownList ID="ddlMarca" runat="server"></asp:DropDownList>
            </div>
            <div class="m-3">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>
                <asp:TextBox ID="txtDescripción" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
