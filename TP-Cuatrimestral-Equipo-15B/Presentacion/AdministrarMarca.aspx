<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarMarca.aspx.cs" Inherits="Presentacion.AdministrarMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Administrar Marca</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="m-3">
                <asp:GridView ID="dgvMarcas" runat="server" AutoGenerateColumns="false" DataKeyNames="IdMarca"
                    AllowPaging="True" PageSize="4"
                    OnPageIndexChanged="dgvArticulos_PageIndexChanged"
                    OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:CommandField ShowSelectButton="true" SelectText="&#x270d" HeaderText="Administrar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
