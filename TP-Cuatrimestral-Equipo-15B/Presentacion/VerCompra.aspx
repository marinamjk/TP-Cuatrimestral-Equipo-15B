<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerCompra.aspx.cs" Inherits="Presentacion.VerCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="m-3">
            <h1 class="fs-4">Mi Compra
            </h1>
        </div>

        <div class="col-6">
            <div class="m-3">
                <h1 class="fs-4">Datos de la compra
                </h1>
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
                <asp:Label ID="lblEstado" runat="server" class="form-label" Text="Estado de la compra: "></asp:Label>
            </div>
            <div class="m-3">
                <div class="progress" role="progressbar" aria-label="Example with label" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
                    <div class="progress-bar" style="width: 20%">Pedido realizado</div>
                </div>
            </div>
        </div>

        <div class="col-6">
            <div class="m-3">
                <h1 class="fs-4">Datos del vendedor
                </h1>
            </div>

            <div class="m-3">
                <asp:Label ID="lblNombre" runat="server" class="form-label" Text="Nombre del comercio: "></asp:Label>
            </div>

            <div class="m-3">
                <asp:Label ID="lblTelefono" runat="server" class="form-label" Text="Telefono: "></asp:Label>
            </div>

            <div class="m-3">
                <asp:Label ID="lblDireccion" runat="server" class="form-label" Text="Direccion: "></asp:Label>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="m-3">
                        <asp:Button ID="btnCancelarCompra" runat="server" Text="Cancelar compra" CssClass="btn btn-danger" OnClick="btnCancelarCompra_Click" />
                    </div>
                    <%if (ConfirmarCancelacion)
                        { %>
                    <div class="m-3">
                        <asp:CheckBox ID="chkConfirmarCancelacion" Text="Confirmar cancelación de compra" runat="server" />
                        <asp:Button ID="btnConfirmanCancelacion" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnConfirmanCancelacion_Click" />
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
