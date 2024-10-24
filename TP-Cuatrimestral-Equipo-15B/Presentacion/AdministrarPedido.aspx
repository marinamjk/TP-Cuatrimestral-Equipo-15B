<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarPedido.aspx.cs" Inherits="Presentacion.AdministrarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        window.onload = function () {
            // Selecciona todos los checkboxes dentro de la CheckBoxList
            var checkboxes = document.querySelectorAll('#<%= cblEstadoPedido.ClientID %> input[type="checkbox"]');

            checkboxes.forEach(function (checkbox) {
                // Añadir clase 'form-check-input me-1' al checkbox
                checkbox.classList.add('form-check-input', 'me-1');

                // Encuentra el label asociado al checkbox usando su 'id'
                var label = document.querySelector('label[for="' + checkbox.id + '"]');

                if (label) {
                    // Añadir clase 'form-check-label' al label asociado
                    label.classList.add('form-check-label');
                }
            });
        };


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h1 class="fs-4">Pedido
        </h1>
        <div class="col-6">
            <div class="m-3">
                <h1 class="fs-4">Datos de la compra
                </h1>
            </div>
            <div class="m-3">
                <asp:Label ID="lblIDPedido" runat="server" Text="ID de Pedido: "></asp:Label>
            </div>
            <div class="m-3">
                <asp:Label ID="lblFecha" runat="server" Text="Fecha de Pedido: "></asp:Label>
            </div>
            <div class="m-3">
                <asp:Label ID="lblItems" runat="server" Text="Items: "></asp:Label>
            </div>
            <div class="m-3">
                <asp:GridView ID="gvItemsComprados" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-success table-striped">
                    <Columns>
                        <asp:BoundField HeaderText="Item" DataField="Nombre" />
                        <asp:BoundField HeaderText="Cantidad" DataField="Stock" />
                        <asp:BoundField HeaderText="PU" DataField="Precio" DataFormatString="{0:F2}" HtmlEncode="false" />
                        <asp:BoundField HeaderText="Importe" DataField="Precio" DataFormatString="{0:F2}" HtmlEncode="false" />
                    </Columns>
                </asp:GridView>
            </div>

            <div class="m-3">
                <asp:Label ID="lblTotalCompra" runat="server" class="form-label" Text="Total: "></asp:Label>
            </div>

            <div class="m-3">
                <h1 class="fs-4">Datos del comprador
                </h1>
            </div>

            <div class="m-3">
                <asp:Label ID="lblNombre" runat="server" class="form-label" Text="Nombre: "></asp:Label>
            </div>

            <div class="m-3">
                <asp:Label ID="lblTelefono" runat="server" class="form-label" Text="Telefono: "></asp:Label>
            </div>

            <div class="m-3">
                <asp:Label ID="lblDireccion" runat="server" class="form-label" Text="Direccion: "></asp:Label>
            </div>

        </div>
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="m-3">

                        <asp:CheckBoxList ID="cblEstadoPedido" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cblEstadoPedido_SelectedIndexChanged" CssClass="list-group"></asp:CheckBoxList>

                    </div>
                    <div class="m-3">
                        <asp:Button ID="btnCancelarVenta" runat="server" Text="Cancelar Venta" CssClass="btn btn-danger" OnClick="btnCancelarVenta_Click" />
                    </div>
                    <%if (ConfirmaCancelacion)
                        { %>
                    <div class="m-3">
                        <asp:CheckBox ID="chkConfirmarCancelacion" Text="Confirmar cancelación de venta" runat="server" />
                        <asp:Button ID="btnConfirmanCancelacion" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnConfirmanCancelacion_Click" />
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
