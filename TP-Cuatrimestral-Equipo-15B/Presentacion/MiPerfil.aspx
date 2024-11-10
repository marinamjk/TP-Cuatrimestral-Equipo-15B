<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Miperfil.aspx.cs" Inherits="Presentacion.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-4">
            <div class="card">
                <img src="https://via.placeholder.com/150" class="card-img-top rounded-circle" alt="Foto de perfil" />
                <div class="card-body">
                    <h5 class="card-title"><%=titulo%></h5>
                </div>
            </div>
        </div>

        <div class="col-6">
            <h4>Información Personal</h4>

            <div class="form-group">
                <div class="m-3">
                    <asp:TextBox ID="TbNombre" runat="server" CssClass="form-control" placeholder="Nombre" type="text"></asp:TextBox>
                </div>
                <div class="m-3">
                    <asp:TextBox ID="TbApellido" runat="server" CssClass="form-control" placeholder="Apellido" type="text"></asp:TextBox>
                </div>
                <div class="m-3">
                    <asp:TextBox ID="TbDocumento" runat="server" CssClass="form-control" placeholder="Documento" type="text"></asp:TextBox>
                </div>
                <div class="m-3">
                    <asp:TextBox ID="TbTelefono" runat="server" CssClass="form-control" placeholder="Teléfono" type="text"></asp:TextBox>
                </div>
                <div class="m-3">
                    <asp:Button ID="btnAgregarDireccion" runat="server" Text="Agregar Direccion" OnClick="btnAgregarDireccion_Click" />
                </div>
            </div>

            <container id="cDireccion">

                <div class="m-3">
                    <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control form-control-lg" placeholder="Calle" />
                </div>
                <div class="m-3">
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control form-control-lg" placeholder="Número" />
                </div>

                <div class="m-3">
                    <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control  form-control-lg" placeholder="Código Postal" OnTextChanged="txtCodigoPostal_TextChanged" AutoPostBack="true" />
                    <asp:Label ID="lblCPValidacion" runat="server" CssClass="alert alert-dange mt-3"></asp:Label>
                </div>
                <div class="m-3">
                    <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control form-control-lg" placeholder="Localidad" />
                </div>

                <div class="m-3">
                    <asp:DropDownList ID="DropDownListProvincia" runat="server" CssClass="form-select form-select-lg" placeholder="Provincia" OnSelectedIndexChanged="DropDownListProvincia_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>

                <div class="row">
                    <div class="m-3">
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary form-group col-md-2" Text="Guardar" />
                    </div>
                </div>
            </container>
        </div>
    <div class="row">
        <div class="d-flex justify-content-end m-3">
            <asp:Button ID="BtAceptar" runat="server" CssClass="btn btn-primary form-group col-md-2" Text="Aceptar" />
        </div>
    </div>
    </div>
</asp:Content>
