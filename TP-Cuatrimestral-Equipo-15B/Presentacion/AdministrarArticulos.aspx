<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarArticulos.aspx.cs" Inherits="Presentacion.AdministrarArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div col="col-10">
            <div class="m-3">
                <asp:GridView CssClass="table table-light" ID="dgvArticulos" DataKeyNames="IdArticulo" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca" />
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="${0:0.00}" HtmlEncode="false" />
                        <asp:BoundField HeaderText="Stock" DataField="Stock" />
                        <asp:CheckBoxField HeaderText="Habilitado" DataField="Estado" />
                        <asp:CommandField ShowSelectButton="true" SelectText="&#x270d" HeaderText="Administrar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
