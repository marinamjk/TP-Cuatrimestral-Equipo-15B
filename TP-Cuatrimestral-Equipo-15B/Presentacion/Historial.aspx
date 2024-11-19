<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" CodeBehind="Historial.aspx.cs" Inherits="Presentacion.Historial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Historial</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Mi Historial de Compras</h2>
        <div class="row">
            <%--Aca van a ir los articulos de mi historial de compra--%>
           <asp:Repeater ID="repHistorial" runat="server">
            <ItemTemplate>

            <div class="col-md-12 mb-3">
                <div class="card">
                    <div class="row no-gutters">                      
                        <div class="col-md-9">
                            <div class="card-body">
                                <h5 class="card-title">Teclado mecanico dragon</h5>
                                <p class="card-text font-weight-bold">$465.025</p>
                                <p class="card-text">Mismo precio en 9 cuotas de $51.669</p>
                                <p class="card-text text-success">Envío gratis</p>
                                <a href="VerCompra.aspx" class="btn btn-primary">Ver Compra</a>
                                
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