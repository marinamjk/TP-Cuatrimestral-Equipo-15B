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
                    <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control  form-control-lg" placeholder="Ingrese su correo"  OnTextChanged="TextEmail_TextChanged" />
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
                        <asp:TextBox ID="TextNombre" runat="server" CssClass="form-control form-control-lg" placeholder="Nombre" />
                    </div>
                    <div class="form-group mt-3">
                        <asp:TextBox ID="TextApellido" runat="server" CssClass="form-control form-control-lg" placeholder="Apellido" />
                    </div>
                    <div class="form-group  mt-3">
                        <asp:TextBox ID="TextTelefono" runat="server" CssClass="form-control form-control-lg" placeholder="Teléfono" />
                    </div>                   
                                             
                </div><%--fin datos contacto--%>
                
                <div id="DireccionContacto" runat="server" visible="false">
                    <div class="row">
                        <div class="form-group col-md-6  mt-3">
                            <asp:TextBox ID="TextCalle" runat="server" CssClass="form-control form-control-lg" placeholder="Calle" />
                        </div>
                        <div class="form-group col-md-6 mt-3">
                            <asp:TextBox ID="TextNumero" runat="server" CssClass="form-control form-control-lg" placeholder="Número" />
                        </div>                        
                    </div>

                    <div class="form-group mt-3">
                        <asp:TextBox ID="TextCodigoPostal" runat="server" CssClass="form-control  form-control-lg" placeholder="Código Postal" OnTextChanged="txtCodigoPostal_TextChanged" AutoPostBack="true" />
                        <asp:Label ID="lblCPValidacion" runat="server" CssClass="alert alert-dange mt-3"></asp:Label>    
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TextLocalidad" runat="server" CssClass="form-control form-control-lg" placeholder="Localidad" />
                    </div>
                    <%--Va a sacar las provincias de la base de datos--%>
                    <div id="Provincias" class="form-group mt-3" runat="server">
                        <asp:DropDownList ID="DropDownListProvincia" runat="server" CssClass="form-select form-select-lg" placeholder="Provincia" OnSelectedIndexChanged="DropDownListProvincia_SelectedIndexChanged" AutoPostBack="true">
                                                
                        </asp:DropDownList>
                    </div>
                </div><%--fin direccion contacto--%>

                <%--Se piden los datos para la facturacion--%>
                <div id="DatosFacturacion" runat="server" visible="false">
                    <h4 class="mt-4 text-center">Datos de facturación</h4>
      
                    <div class="form-group mt-3 ">                              
                        <asp:TextBox ID="TextDNI" runat="server" CssClass="form-control form-control-lg" placeholder="DNI o CUIT" />
                    </div>
                </div>

                <%-- <!-- Se piden los datos de la persona que va a retirar el pedido -->
                <div id="ResponsableDePago" runat="server" visible="false" >
                     <h5 class="mt-4 fw-bold">Persona que pagara el Pedido</h5>

                     <div class="form-group mt-3">                        
                         <asp:TextBox ID="TextNombreRetiraPedido" runat="server" CssClass="form-control form-control-lg" placeholder="Nombre" />
                     </div>
                     <div class="form-group mt-3">
                         <asp:TextBox ID="TextApellidoRetiraPedido" runat="server" CssClass="form-control form-control-lg" placeholder="Apellido" />
                     </div>
                     <div class="form-group  mt-3">
                         <asp:TextBox ID="TextTelefonoRetiraPedido" runat="server" CssClass="form-control form-control-lg" placeholder="Teléfono" />
                     </div>

                </div>--%>
                
                <!-- Botón para redirigir a los medios de pago -->
                <div class="text-end mt-4">
                    <asp:Button ID="btnMediosDePago" runat="server" Text="Medios de Pago" CssClass="btn btn-primary btn-lg px-4 py-2" OnClick="btnMediosDePago_Click" />
                </div>
                 <div class ="mt-3">
                     <asp:Label ID="lblAdvertencia" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
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