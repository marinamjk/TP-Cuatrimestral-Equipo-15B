<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MetodosPago.aspx.cs" Inherits="Presentacion.MetodosPago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    <title> Metodos de Pago </title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container mt-5">
         <%--Se crea la fila que contiene las dos coluimnas que quiero mostrar--%>
        <div class="row">
            <!-- Columna para medios de pago -->
            <div class="col-md-8">
                <h2 class="mb-4">Medio de pago</h2>
                <div class="btn-group-vertical" role="group" aria-label="Medios de pago">
                    <asp:Button ID="btnPagoEfectivo" runat="server" Text="Pago en Efectivo" CssClass="btn btn-outline-primary" OnClick="btnPagoEfectivo_Click" />
                    <asp:Button ID="btnPagoMercadoPago" runat="server" Text="Pago con Mercado Pago" CssClass="btn btn-outline-primary" OnClick="btnPagoMercadoPago_Click" />
                   
                </div>
                <div>
                    <asp:CheckBox ID="chkRegistrarse" runat="server" Text="Guardar datos y registrame." OnCheckedChanged="chkRegistrarse_CheckedChanged" />
                </div>
                <div class="text-center mt-4">
                    <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn btn-primary" OnClick="btnFinalizarCompra_Click" />
                </div>
                <div class="mt-4">
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                </div>

            </div>

            <!-- Columna para el resumen de la compra -->
            <div class="col-md-4">

                <div class="card">
                
                    <div class="card-body">
                        <h5 class="card-title">Resumen de la compra</h5>
                    
                          <asp:Repeater ID="rptResumenCarrito" runat="server">
                              <ItemTemplate>
                                  <div class="d-flex justify-content-between">
                                      <span><%# Eval("Articulo.Nombre") %></span>                                    
                                  </div>
                                  <hr>
                                  <div class="d-flex justify-content-between">
                                      <span>Subtotal</span>
                                      <span>$<%# Eval("Subtotal","{0:N2}") %></span>
                                  </div>
                                  <hr>
                              </ItemTemplate>
                          </asp:Repeater>
  
                          <div class="d-flex justify-content-between">
                              <strong>Total</strong>
                              <asp:Label ID="lblTotal" runat="server"></asp:Label> 
                          </div>                       

                        <a href="#" class="btn btn-primary mt-3 w-100">Agregar cupón de descuento</a>
                    </div>
                </div>
            </div>      
        </div>
    </div>


</asp:Content>