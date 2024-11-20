<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerCompra.aspx.cs" Inherits="Presentacion.VerCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .progress - bar {
            transition: width 1s ease-in-out;
        }
    </style>
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
                <asp:Label ID="lblFecha" runat="server"></asp:Label>
            </div>
            <div class="m-3">
                <asp:Label ID="lblItems" runat="server" Text="Items: "></asp:Label>
            </div>
            <div class="m-3">
                <asp:GridView ID="gvItemsComprados" runat="server" DataKeyNames="idArticulo" AutoGenerateColumns="false" CssClass="table table-bordered table-success table-striped" OnRowCommand="gvItemsComprados_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Item" DataField="articulo" />
                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                        <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUnitario" />
                        <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" />
                        <asp:ButtonField ButtonType="Button" Text="Calificar" HeaderText="Calificacion" CommandName="Calificar" />
                    </Columns>
                </asp:GridView>
            </div>

            <div class="m-3">
                <asp:Label ID="lblTotalCompra" runat="server" class="form-label"></asp:Label>
            </div>
            <div class="m-3">
                <asp:Label ID="lblEstado" runat="server" class="form-label" Text="Estado de la compra: "></asp:Label>
            </div>
            <div class="m-3">
                <div class="progress" role="progressbar" aria-label="Estado del pedido" aria-valuenow="<%= valorEstado * 100 / 5 %>" aria-valuemin="0" aria-valuemax="100" style="height: 50px; background-color: #f0f0f0; border-radius: 10px; box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);">
                    <div class="progress-bar" style="width: <%= valorEstado * 100 / 5 %>%; font-size: 18px; line-height: 50px; background-color: #28a745;">
                        <%= descripcionEstado %>
                    </div>
                </div>
            </div>
        </div>

   

                <div class="col-6">
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
                    <%if (calificar)
                        {

                            if (calificado)
                            {%>
                    <div class="m-3">
                        <asp:Label ID="lblCalificado" runat="server" class="form-label" Text="Este Producto ya ha sido calificado"></asp:Label>
                    </div>
                    <%}
                        else
                        { %>
                    <div class="m-3">
                        <asp:TextBox ID="txtCalificacion" runat="server" TextMode="Number" Text="1" Min="1" Max="10"></asp:TextBox>
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    </div>
                    <% }

                        }
                        else
                        {  %>
                          <div class="m-3">
                         <asp:Label ID = "lblCalificar" runat="server" class="form-label"></asp:Label>
                         </div>
                         <%} %>


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
                </div>

             
            </ContentTemplate>
        </asp:UpdatePanel>
                    </div>
</asp:Content>
