<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Presentacion.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Carrito de Compras</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="modal fade" id="carritoModal" tabindex="-1" role="dialog" aria-labelledby="carritoModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                
                <div class="modal-header">
                    <h5 class="modal-title" id="carritoModalLabel">Carrito de Compras</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="cerrarCarrito()">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <%--Si no hay datos Muestra lo siguiente--%>
                    <asp:Label ID="lblCarrito" runat="server" Text="Aun no se a agregado ningún Articulo a su Carrito"></asp:Label>
                       
                    <%--GridView aca se cargaran los articulos que se vayan agregando al carrito --%>
                    <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                        <Columns>
                            <asp:BoundField DataField="NombreArticulo" HeaderText="Producto" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="Precio" HeaderText="Subtotal" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%--Se va a buscar recuperar el id del articulo en el gridview con eval, para eliminar si es necesario--%>
                                    <asp:Button ID="btnEliminar" runat="server" Text="🗑" CommandArgument='<%# Eval("ID") %>' OnClick="btnEliminar_Click" CssClass="btn btn-sm" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <div class="subtotal mt-3">
                        <span><strong>Subtotal:</strong></span> <asp:Label ID="lblSubtotal" runat="server" Text="$0.00"></asp:Label>
                    </div>
                     <div class="subtotal mt-3">
                            <svg class="svg-inline--fa m-right-quarter  svg-text-fill" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512"  style="width: 30px; height: 30px;"><path d="M624 352h-16V243.9c0-12.7-5.1-24.9-14.1-33.9L494 110.1c-9-9-21.2-14.1-33.9-14.1H416V48c0-26.5-21.5-48-48-48H48C21.5 0 0 21.5 0 48v320c0 26.5 21.5 48 48 48h16c0 53 43 96 96 96s96-43 96-96h128c0 53 43 96 96 96s96-43 96-96h48c8.8 0 16-7.2 16-16v-32c0-8.8-7.2-16-16-16zM160 464c-26.5 0-48-21.5-48-48s21.5-48 48-48 48 21.5 48 48-21.5 48-48 48zm320 0c-26.5 0-48-21.5-48-48s21.5-48 48-48 48 21.5 48 48-21.5 48-48 48zm80-208H416V144h44.1l99.9 99.9V256z"></path></svg>
                            <span class="font-medium">Medios de envío</span>   
                     </div>
                    <%--Le suma un monto deacuerdo a lo que cueste el envio--%>
                     <div class="row mt-3">   
                         <div class="col-md-6">  
                              <asp:TextBox ID="lblCodPostal" runat="server" CssClass="form-control" Text="Codigo Postal"></asp:TextBox> 
                         </div>
                         <div class="col-md-6">  
                             <asp:Button ID="lblCalcular" runat="server" Text="Calcular" CssClass="btn btn-success" />
                         </div>
                          
                     </div>
                 </div>
                <div class="modal-footer">
                    <asp:Button ID="btnIniciarCompra" runat="server" Text="Iniciar Compra" CssClass="btn btn-success" OnClick="btnIniciarCompra_Click"/>
                </div>
            </div>
        </div>
    </div>

    <script>
        //Scrip para mostrar el modal.. ver como ponerlo en carpeta scripts o js
        $(document).ready(function () {
            $('#carritoModal').modal('show');
        });

        function cerrarCarrito() {
            $('#carritoModal').modal('hide');
        }
    </script>
</asp:Content>
