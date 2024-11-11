<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Presentacion.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Favoritos</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Mis favoritos</h2>
        <div class="row">
            <asp:Repeater ID="repFavoritos" runat="server" OnItemDataBound="repFavoritos_ItemDataBound">
                <ItemTemplate>

                    <div class="col-md-12 mb-3">
                        <div class="card">
                            <div class="row no-gutters">
                                <div class="col-md-3">
                                    <asp:Image ID="imgArticulo" runat="server" Cssclass="card-img"/>                     
                                </div>
                                <div class="col-md-9">
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                        <p class="card-text font-weight-bold"><%# Eval("Precio", "{0:F2}") %></p>
                                        <p class="card-text"><%# Eval("Coleccion") %></p>
                                        <p class="card-text text-success"><%# Eval("Puntaje") %></p>
                                        <asp:Button ID="btnAgregarAlCarrito" CssClass="btn btn-primary" runat="server" Text="Agregar al carrito"  CommandName="AgregarAlCarrito" CommandArgument='<%# Eval("IDArticulo") %>' OnCommand="btnAgregarAlCarrito_Command"/>
                                        <asp:Button ID="btnEliminarDeFavoritos" CssClass="btn btn-danger" runat="server" Text="Eliminar"  CommandName="Eliminar" CommandArgument='<%# Eval("IDArticulo") %>' OnCommand="btnEliminarDeFavoritos_Command"/>                                     
                                
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                </ItemTemplate>
            </asp:Repeater>
            <asp:Label ID="lblConfirmacion" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
