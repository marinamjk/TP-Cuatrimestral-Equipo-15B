<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaPedidos.aspx.cs" Inherits="Presentacion.ListaPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Mi Lista de Pedidos</h2>
        <div class="row">

            <asp:Repeater ID="repPedidos" runat="server">
                <ItemTemplate>

                    <div class="col-md-12 mb-3">
                        <div class="card">
                            <div class="row no-gutters">
                                <div class="col-md-9">
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("FechaPedido", "{0:dd/MM/yyyy}") %></h5>
                                        <p class="card-text"><%# Eval("TipoEntrega") %></p>
                                         <p class="card-text"><%# Eval("MetodoPago") %></p>
                                        <p class="card-text font-weight-bold"><%# Eval("Total") %></p>
                                        <p class="card-text <%# Convert.ToInt32(Eval("EstadoPedido")) == 5 ? "text-success" : 
                                                                 Convert.ToInt32(Eval("EstadoPedido")) == 6 ? "text-danger" : "" %>">
                                            <%# Convert.ToInt32(Eval("EstadoPedido")) == 5 ? "Entregado" : 
                                             Convert.ToInt32(Eval("EstadoPedido")) == 6 ? "Cancelado" : "" %>
                                        </p>
                                        <a href="AdministrarPedido.aspx?id=<%# Eval("IdPedido") %>" class="btn btn-primary">Ver Pedido</a>
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
