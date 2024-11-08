<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarColeccion.aspx.cs" Inherits="Presentacion.AdministrarMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Administrar Marca</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="m-3">
                        <asp:GridView ID="dgvColecciones" runat="server" AutoGenerateColumns="false" DataKeyNames="IdColeccion"
                            AllowPaging="True" PageSize="4"
                            OnPageIndexChanging="dgvColecciones_PageIndexChanging"
                            OnRowCommand="dgvColecciones_RowCommand">

                            <Columns>
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:ButtonField ButtonType="Link" Text="&#x270d" HeaderText="Modificar" CommandName="Modificar" />
                                <asp:TemplateField HeaderText="Activo">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkEstado" runat="server" Checked='<%# Eval("Estado") %>' OnCheckedChanged="chkEstado_CheckedChanged" AutoPostBack="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-6">
                    <div class="m-3">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                    </div>
                    <div class="m-3">
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" maxLength="100" ControlToValidate="txtNombre" ErrorMessage="Este campo es requerido."></asp:RequiredFieldValidator>
                    </div>
                    <div class="m-3">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
