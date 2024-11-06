<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DatosContacto.aspx.cs" Inherits="Presentacion.DatosContacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Datos de contacto</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <%--Se crea la fila que contiene las dos coluimnas que quiero mostrar--%>
        <div class="row">
            <!-- Columna para detalles de la compra -->
            <div class="col-md-8">
                <h4 class="mb-4 text-center">Datos de contacto</h4>

                <!-- Se pide el mail de contacto -->
                <div class="form-group">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control  form-control-lg" placeholder="Ingrese su correo" />
                </div>

                <div class="form-group  ">              
                    <!-- Datos para realizar la Facturación -->
                    <h4 class="mt-4 text-center">Entrega</h4>
                    <div class="form-control mt-3">
                        <label class="d-flex align-items-center">
                            <asp:RadioButton ID="rbEnvio" runat="server" GroupName="RadioButton" CssClass="me-2" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
                            <span class="card-text text-primary">Envio (Solo Argentina)</span>
                        </label>
                        <div class="card-body">
                            <p class="card-title">A coordinar con nuestros representantes</p>
                            <%--<p class="card-text font-weight-bold">$465.025</p>--%>                           
                        </div>
                    </div>
                                    
                    <div class="form-control mt-3">
                        <label class="d-flex align-items-center">
                            <asp:RadioButton ID="rbRetiro" runat="server" GroupName="RadioButton" CssClass="me-2" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
                            <span class="card-text text-primary">Retiro</span>
                        </label>
                        <div class="card-body">
                            <p class="card-title">Retirar por nuestras sucursales</p>
                            <%--<p class="card-text font-weight-bold">$465.025</p>--%>                           
                        </div>
                    </div>
                </div>

                <%--Si se elige retiro pide los datos de facturacion--%>
                <div id="DatosDestinatario" runat="server" visible="false">
                    <h4 class="mt-4 text-center">Datos Destinatario</h4>
                     <!-- Se piden los datos de la persona que va a pagar el pedido -->
                                              
                    <div class="form-group mt-3">                        
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control form-control-lg" placeholder="Nombre" />
                    </div>
                    <div class="form-group mt-3">
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control form-control-lg" placeholder="Apellido" />
                    </div>
                    <div class="form-group  mt-3">
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control form-control-lg" placeholder="Teléfono" />
                    </div>
                         
                     <div class="row">
                        <div class="form-group col-md-6  mt-3">
                            <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control form-control-lg" placeholder="Calle" />
                        </div>
                        <div class="form-group col-md-6 mt-3">
                            <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control form-control-lg" placeholder="Número" />
                        </div>                        
                     </div>

                    <div class="form-group mt-3">
                        <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control  form-control-lg" placeholder="Código Postal" OnTextChanged="txtCodigoPostal_TextChanged" AutoPostBack="true" />
                        <asp:Label ID="lblCPValidacion" runat="server" CssClass="alert alert-dange mt-3"></asp:Label>
                     </div>
                    <div class="form-group mt-3">
                        <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control form-control-lg" placeholder="Localidad" />
                    </div>
                    <%--Va a sacar las provincias de la base de datos--%>
                    <div class="form-group mt-3">
                        <asp:DropDownList ID="DropDownListProvincia" runat="server" CssClass="form-select form-select-lg" placeholder="Provincia" OnSelectedIndexChanged="DropDownListProvincia_SelectedIndexChanged" AutoPostBack="true">
                                                
                        </asp:DropDownList>
                     </div>
                     
                                             
                </div>

                <div id="DatosFacturacion" runat="server" visible="false">
                    <!-- Se piden los datos de la persona que va a retirar el pedido -->
                    <h4 class="mt-4 text-center">Datos de facturación</h4>
      
                    <div class="form-group mt-3 ">                              
                        <asp:TextBox ID="TextBox14" runat="server" CssClass="form-control form-control-lg" placeholder="DNI o CUIT" />
                    </div>

                    <h5 class="mt-4 fw-bold">Persona que pagara el Pedido</h5>

                     <div class="form-group mt-3">                        
                         <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control form-control-lg" placeholder="Nombre" />
                     </div>
                     <div class="form-group mt-3">
                         <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control form-control-lg" placeholder="Apellido" />
                     </div>
                     <div class="form-group  mt-3">
                         <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control form-control-lg" placeholder="Teléfono" />
                     </div>

                </div>
                
                <!-- Botón para redirigir a los medios de pago -->
                <div class="text-end mt-4">
                    <asp:Button ID="btnMediosDePago" runat="server" Text="Medios de Pago" CssClass="btn btn-primary btn-lg px-4 py-2" OnClick="btnMediosDePago_Click" />
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
                            <asp:Label ID="lblTotal" runat="server"></asp:Label> <!-- Cambiar a cálculo dinámico -->
                        </div>

                       
                        <a href="#" class="btn btn-primary mt-3 w-100">Agregar cupón de descuento</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>