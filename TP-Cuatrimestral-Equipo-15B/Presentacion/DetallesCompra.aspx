<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetallesCompra.aspx.cs" Inherits="Presentacion.DetallesCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Detalles de mis Compras</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <%--Se crea la fila que contiene las dos coluimnas que quiero mostrar--%>
        <div class="row">
            <!-- Columna para detalles de la compra -->
            <div class="col-md-8">
                <h2 class="mb-4">Detalles de mi Compra</h2>

                <!-- Se pide el mail de contacto -->
                <div class="form-group">
                    <label for="txtEmail">Correo Electrónico:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Ingrese su correo" />
                </div>

                <!-- Datos para realizar la Facturación -->
                <h3 class="mt-4">Datos de Facturación</h3>
                <div class="form-group">
                    <label for="txtDniCuit">DNI o CUIT:</label>
                    <asp:TextBox ID="txtDniCuit" runat="server" CssClass="form-control" placeholder="Ingrese su DNI o CUIT" />
                </div>

                <!-- Se piden los datos de la persona que va a pagar el pedido -->
                <h3 class="mt-4">Persona que pagará el pedido</h3>
                <div class="row">
                    <div class="form-group col-md-6">
                        <label for="txtNombrePagador">Nombre:</label>
                        <asp:TextBox ID="txtNombrePagador" runat="server" CssClass="form-control" placeholder="Ingrese nombre" />
                    </div>
                    <div class="form-group col-md-6">
                        <label for="txtApellidoPagador">Apellido:</label>
                        <asp:TextBox ID="txtApellidoPagador" runat="server" CssClass="form-control" placeholder="Ingrese apellido" />
                    </div>
                    <div class="form-group col-md-6">
                        <label for="txtTelefonoPagador">Teléfono:</label>
                        <asp:TextBox ID="txtTelefonoPagador" runat="server" CssClass="form-control" placeholder="Ingrese teléfono" />
                    </div>
                </div>

                <!-- Se piden los datos de la persona que va a retirar el pedido -->
                <h3 class="mt-4">Persona que retira el pedido</h3>
                <div class="row">
                    <div class="form-group col-md-6">
                        <label for="txtNombreRetira">Nombre:</label>
                        <asp:TextBox ID="txtNombreRetira" runat="server" CssClass="form-control" placeholder="Ingrese nombre" />
                    </div>
                    <div class="form-group col-md-6">
                        <label for="txtApellidoRetira">Apellido:</label>
                        <asp:TextBox ID="txtApellidoRetira" runat="server" CssClass="form-control" placeholder="Ingrese apellido" />
                    </div>
                </div>

                <!-- Opción de cupón de descuento -->
                <div class="form-group">
                    <label for="txtCupon">Cupón de Descuento (opcional):</label>
                    <asp:TextBox ID="txtCupon" runat="server" CssClass="form-control" placeholder="Ingrese cupón de descuento si tiene" />
                </div>

                <!-- Botón para redirigir a los medios de pago -->
                <div class="text-center mt-4">
                    <asp:Button ID="btnMediosDePago" runat="server" Text="Medios de Pago" CssClass="btn btn-primary" OnClick="btnMediosDePago_Click" />
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
