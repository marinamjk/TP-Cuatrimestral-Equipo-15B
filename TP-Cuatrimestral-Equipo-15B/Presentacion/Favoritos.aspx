<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Presentacion.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Favoritos</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Mis favoritos</h2>
        <div class="row">
            <asp:Repeater ID="repArticulos" runat="server" OnItemDataBound="repArticulos_ItemDataBound">
                <ItemTemplate>

                    <div class="col-md-12 mb-3">
                        <div class="card">
                            <div class="row no-gutters">
                                <div class="col-md-3">
                                    <asp:Image ID="imgArticulo" runat="server" Cssclass="card-img"/>                     
                                </div>
                                <div class="col-md-9">
                                    <div class="card-body">
                                        <h5 class="card-title">Teclado mecanico dragon</h5>
                                        <p class="card-text font-weight-bold">$465.025</p>
                                        <p class="card-text">Mismo precio en 9 cuotas de $51.669</p>
                                        <p class="card-text text-success">Envío gratis</p>
                                        <a href="#" class="btn btn-primary">Agregar a lista</a>
                                        <a href="#" class="btn btn-danger">Eliminar</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
