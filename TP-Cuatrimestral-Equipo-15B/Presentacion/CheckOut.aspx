<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="Presentacion.CheckOut" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Medios de Pago</title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
         <%--Se crea la fila que contiene las dos coluimnas que quiero mostrar--%>
        <div class="row">
            <!-- Columna para medios de pago -->
            <div class="col-md-8">
                <h2 class="mb-4">Medio de pago</h2>
                <div class="list-group">
                    
                    <a href="#" class="list-group-item list-group-item-action d-flex justify-content-between align-items-center">
                        <div>
                            <i class="bi bi-cash me-2"></i> Efectivo
                        </div>
                    </a>
                   
                    <a href="#" class="list-group-item list-group-item-action d-flex justify-content-between align-items-center">
                        <div>
                            <i class="bi bi-wallet2 me-2"></i> Mercado Pago
                        </div>
                        <span class="badge bg-primary rounded-pill">Hasta 6 cuotas sin interés</span>
                    </a>
                    
                </div>
                <div class="text-center mt-4">
                    <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn btn-primary" OnClick="btnFinalizarCompra_Click" />
                </div>
            </div>

            <!-- Columna para el resumen de la compra -->
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Resumen de la compra</h5>
                        <div class="d-flex justify-content-between">
                            <span>Aca se deberia mostrar lo que se tiene en el carro para comprar</span>
                            <span>$32,500.00</span>
                        </div>
                        <hr>
                        <div class="d-flex justify-content-between">
                            <span>Subtotal</span>
                            <span>$32,500.00</span>
                        </div>
                        <div class="d-flex justify-content-between">
                            <span>Costo de envío</span>
                            <span>$9,817.18</span>
                        </div>
                        <hr>
                        <div class="d-flex justify-content-between">
                            <strong>Total</strong>
                            <strong>$42,317.18</strong>
                        </div>
                        <a href="#" class="btn btn-primary mt-3 w-100">Agregar cupón de descuento</a>
                    </div>
                </div>
            </div>      
        </div>
    </div>
</asp:Content>
