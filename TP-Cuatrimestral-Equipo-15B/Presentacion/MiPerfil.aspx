<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Miperfil.aspx.cs" Inherits="Presentacion.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row justify-content-center mt-4">
        <div class="col-12">
            <div class="m-3">
                <h2>Mi Perfil</h2>
            </div>
        </div>
    </div>

    <fieldset id="fieldsetDatos" disabled>
        <div class="row justify-content-center">
            <div class="col-6">
                <div class="card">
                    <asp:Image ID="ImagePerfil" class="card-img-top rounded-circle" alt="Foto de perfil" runat="server" ImageUrl="https://via.placeholder.com/150"
                        Style="width: 75%; height: auto;" />
                    <div class="card-body">
                        <h5 class="card-title"><%=titulo%></h5>
                    </div>

                </div>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-6">
                <div class="form-group">
                    <div class="m-3">
                        <h4>Información Personal</h4>
                    </div>
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
                </div>
            </div>
        </div>
    </fieldset>


    <div class="row justify-content-center">

        <div class="col-6">
            <div class="d-flex justify-content-end m-3">
                <%if (!ModificarDatos)
                    { %>
                <asp:Button ID="btnModificarDatos" runat="server" Text="Modificar" CssClass="btn btn-danger" OnClick="btnModificarDatos_Click" />


                <% }
                    else
                    { %>

                <asp:Button ID="btnGuardarDatos" runat="server" Text="Guardar" CssClass="btn btn-primary form-group col-md-2" OnClick="btnGuardarDatos_Click" />

                <% }%>
            </div>
        </div>
    </div>

    <div class="row justify-content-center">

        <div class="col-6">

            <fieldset id="fieldsetDireccion" disabled>
                <h4>Dirección</h4>
                <div class="m-3">
                    <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control form-control-lg" placeholder="Calle" type="text" />
                </div>
                <div class="m-3">
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control form-control-lg" placeholder="Número" type="text" />
                </div>
                <div class="m-3">
                    <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control  form-control-lg" placeholder="Código Postal" OnTextChanged="txtCodigoPostal_TextChanged" AutoPostBack="true" type="text" />
                    <asp:Label ID="lblCPValidacion" runat="server" CssClass="alert alert-dange mt-3"></asp:Label>
                </div>
                <div class="m-3">
                    <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control form-control-lg" placeholder="Localidad" type="text" />
                </div>
                <div class="m-3">
                    <asp:DropDownList ID="DropDownListProvincia" runat="server" CssClass="form-select form-select-lg" placeholder="Provincia" OnSelectedIndexChanged="DropDownListProvincia_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </fieldset>

        </div>

        <div class="row justify-content-center">
            <div class="col-6">
                <div class="d-flex justify-content-end m-3">
                    <%if (!ModificarDireccion)
                        { %>
                    <asp:Button ID="btnModificarDireccion" runat="server" Text="Modificar" CssClass="btn btn-danger" OnClick="btnModificarDireccion_Click" />


                    <% }
                        else
                        { %>

                    <asp:Button ID="btnGuardarDireccion" runat="server" Text="Guardar" CssClass="btn btn-primary form-group col-md-2" OnClick="btnGuardarDireccion_Click" />

                    <% }%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
