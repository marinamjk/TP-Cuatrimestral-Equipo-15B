<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarMarca.aspx.cs" Inherits="Presentacion.AdministrarMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Administrar Marca</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="m-3">
                        <asp:GridView ID="dgvMarcas" runat="server" AutoGenerateColumns="false" DataKeyNames="IdMarca"
                            AllowPaging="True" PageSize="4"
                            OnPageIndexChanging="dgvMarcas_PageIndexChanging"                         
                            OnRowCommand="dgvMarcas_RowCommand">

                            <Columns>
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:ButtonField  ButtonType="Link" Text="&#x270d" HeaderText="Modificar" CommandName="Modificar" />
                                <asp:ButtonField  ButtonType="Link" Text="&#x274c" HeaderText="Eliminar" CommandName="Eliminar" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-6">
                    <div class="m-3">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                    </div>
                    <div class="m-3">
                        <asp:TextBox ID="txtNombre" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" maxLength="100" ControlToValidate="txtNombre" ErrorMessage="Este campo es requerido."></asp:RequiredFieldValidator>
                    </div>
                    <div class="m-3">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"  OnClick="btnCancelar_Click"/>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
