<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Presentacion.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Carrito de Compras</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1 class="mb-4">Carrito de Compras</h1>
        
        <asp:Panel ID="panelCarrito" runat="server">

            <!-- Si no hay datos muestra lo siguiente -->
            <asp:Label ID="lblCarritoVacio" runat="server" Text="Aún no se ha agregado ningún artículo a su carrito."  Visible="False"  CssClass="alert alert-warning"></asp:Label>

            <!-- GridView aca se cargaran los articulosque se vayan agregando al carrito -->
            <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="False" CssClass="table table-striped mt-4" Visible="False">
                <Columns>
                    <asp:BoundField DataField="IdArticulo" HeaderText ="Id" />
                    <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Precio" HeaderText="Subtotal" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnVerDetalles" runat="server" Text="Ver Detalles" CommandArgument='<%# Eval("IdArticulo") %>' OnClick="btnVerDetalles_Click" />
                            <!-- Se va a buscar recuperar el id del articulo en el GridView con Eval, para eliminar si es necesario -->
                            <asp:Button ID="btnEliminar" runat="server" Text="🗑" CommandArgument='<%# Eval("IdArticulo") %>' OnClick="btnEliminar_Click" CssClass="btn btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
           

            <!-- Le suma un monto de acuerdo a lo que cueste el envio -->
           <%-- <div id="envio" class="mt-3" runat="server">
                <div class="row mt-3">
                    <div class="col-md-6 mt-3">
                        <asp:TextBox ID="txtCodPostal" runat="server" CssClass="form-control" Text="Código Postal" placeholder="Ingrese Código Postal"></asp:TextBox>
                    </div>
                    <div class="col-md-2 mt-3">
                        <asp:Button ID="btnCalcularEnvio" runat="server" Text="Calcular Envío" CssClass="btn btn-secondary" OnClick="btnCalcularEnvio_Click" />
                    </div>
                </div>
            </div>--%>
            
            
            <div id="total" class="mt-4 text-end" runat="server" visible="false">
                <span><strong>Total:</strong></span> <asp:Label ID="lblTotal" runat="server" Text="$0.00"></asp:Label>
            </div>

            <div id="btn" class="botones mt-4 text-end" runat="server" visible="false">
                <asp:Button ID="btnIniciarCompra" runat="server" Text="Iniciar Compra" CssClass="btn btn-primary" OnClick="btnIniciarCompra_Click" />
                <asp:Button ID="btnSeguirComprando" runat="server" Text="Seguir Comprando" CssClass="btn btn-secondary" PostBackUrl="Default.aspx" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>