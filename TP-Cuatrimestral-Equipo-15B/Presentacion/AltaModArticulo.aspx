<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaModArticulo.aspx.cs" Inherits="Presentacion.AltaModArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validator {
            font-size: 12px;
            color: red;
        }

        .icon-buttonAgregar {
            display: inline-flex;
            background-color: transparent; /* Color de fondo */
            border: none; /* Sin borde */
            padding: 5px 10px; /* Relleno */
            position: relative;
            background-image: url('data:image/svg+xml,%3Csvg xmlns=%27http://www.w3.org/2000/svg%27 width=%2732%27 height=%2732%27 fill=%27blue%27 class=%27bi bi-plus-circle-fill%27 viewBox=%270 0 16 16%27%3E%3Cpath d=%27M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0M8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3z%27/%3E%3C/svg%3E');
            background-repeat: no-repeat;
            background-position: center; /* Posiciona el SVG a la izquierda */
            padding-left: 30px; /* Espacio para el ícono */
            text-align: left; /* Alinea el texto */
        }

        .icon-buttonQuitar {
            display: inline-flex;
            background-color: transparent; /* Color de fondo */
            border: none; /* Sin borde */
            padding: 5px 10px; /* Relleno */
            position: relative;
            background-image: url('data:image/svg+xml,%3Csvg xmlns=%27http://www.w3.org/2000/svg%27 width=%2732%27 height=%2732%27 fill=%27blue%27 class=%27bi bi-x-circle-fill%27 viewBox=%270 0 16 16%27%3E%3Cpath d=%27M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0M5.354 4.646a.5.5 0 1 0-.708.708L7.293 8l-2.647 2.646a.5.5 0 0 0 .708.708L8 8.707l2.646 2.647a.5.5 0 0 0 .708-.708L8.707 8l2.647-2.646a.5.5 0 0 0-.708-.708L8 7.293z%27/%3E%3C/svg%3E');
            background-repeat: no-repeat;
            background-position: center; /* Posiciona el SVG a la izquierda */
            padding-left: 30px; /* Espacio para el ícono */
            text-align: left; /* Alinea el texto */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="fs-4 m-3">Agregar o modificar Artículo
    </h1>
    <div class="row">
        <div class="col-6">
            <div class="m-3">
                <asp:Label ID="lblCategoria" runat="server" CssClass="form-label" Text="Categoria/Subcategoria:"></asp:Label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>

            </div>
            <div class="m-3">
                <asp:Label ID="lblCodigo" runat="server" CssClass="form-label" Width="100px" Text="Código:"></asp:Label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" CssClass="validator" maxLength="50" ControlToValidate="txtCodigo" ErrorMessage="Este campo es requerido."></asp:RequiredFieldValidator>
            </div>
            <div class="m-3">
                <asp:Label ID="lblNombre" runat="server" CssClass="form-label" Text="Nombre de Artículo: "></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" CssClass="validator" maxLength="100" ControlToValidate="txtNombre" ErrorMessage="Este campo es requerido."></asp:RequiredFieldValidator>
            </div>
            <div class="m-3">
                <asp:Label ID="lblMarca" runat="server" CssClass="form-label" Text="Marca"></asp:Label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="m-3">
                <asp:Label ID="lblDescripcion" runat="server" CssClass="form-label" Text="Descripción"></asp:Label>
                <asp:TextBox ID="txtDescripción" TextMode="MultiLine" CssClass="form-control" MaxLength="3000" height="400px" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="col-6">

            <div class="m-3">
                <asp:Label ID="lblPrecio" runat="server" CssClass="form-label" Text="Precio: "></asp:Label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" CssClass="validator" ControlToValidate="txtPrecio" ErrorMessage="Este campo es requerido."></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvPrecio" runat="server" CssClass="validator" ErrorMessage="Ingrese un rango válldo. Utilice coma para decimales." ControlToValidate="txtPrecio" Type="Currency" MinimumValue="1,00" MaximumValue="10000000,00"></asp:RangeValidator>
            </div>
            <div class="m-3">
                <asp:Label ID="lblStock" runat="server" CssClass="form-label" Text="Stock: "></asp:Label>
                <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" TextMode="Number" Min="1" Max="100" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvStock" runat="server" CssClass="validator" ControlToValidate="txtStock" ErrorMessage="Este campo es requerido. "></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvStock" runat="server" CssClass="validator" ErrorMessage="Ingrese sólo números." ControlToValidate="txtStock" Type="Integer" MinimumValue="1" MaximumValue="10000000"></asp:RangeValidator>
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div class="m-3">
                        <asp:Label ID="lblUrlImagen" runat="server" CssClass="form-label" Text="Url Imagen: "></asp:Label>
                        <div class="row">
                            <div class="col-10">

                                <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" CausesValidation="false" ></asp:TextBox>

                                <%--<asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control"></asp:TextBox>--%>

                                <asp:RegularExpressionValidator ID="revUrlImagen" runat="server" CssClass="validator" ErrorMessage="Ingrese una dirección válida." ControlToValidate="txtUrlImagen" ValidationExpression="^(https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.(jpg|jpeg|png|gif|bmp|svg|webp|tiff|ico|[a-zA-Z0-9-]+)(\/[-a-zA-Z0-9@:%_\+.~#?&=]*)?|data:image\/(jpg|jpeg|png|gif|bmp|svg|webp|tiff|ico);base64,[a-zA-Z0-9+/=]+)$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-2">
                                <asp:Button ID="btnAgregar" runat="server" CssClass="icon-buttonAgregar" Text="" OnClick="btnAgregar_Click" />

                            </div>
                        </div>
                    </div>
                    <div class="m-3">
                        <asp:Image ImageUrl="data:image/png;base64,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" ID="imgArticulo" runat="server" Width="100%" />
                    </div>



                    <div class="m-3">

                        <asp:Repeater ID="RepeaterImages" runat="server">
                            <ItemTemplate>
                                <div style="margin-bottom: 10px;">
<<<<<<< HEAD
                                    <img src='<%# Eval("UrlImagen") %>' style="width: 40%; height: auto;" />
=======
                                    <img src='<%# Eval("Url") %>' style="width: 100px; height: 100px;" />
>>>>>>> 050be676d77b0fd6725bb7c87c30403399f68e8c
                                    <asp:Button ID="btnQuitar" runat="server" CssClass="icon-buttonQuitar" Text="" CommandArgument='<%# Container.ItemIndex %>' OnClick="btnQuitar_Click" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <hr />
           
            <div class="m-3">
                <asp:Button ID="btnPublicar" runat="server" CssClass="btn btn-primary" Text="Publicar" OnClick="btnPublicar_Click" />
                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary" Text="Cancelar" />
            </div>
    
        </div>
    </div>

</asp:Content>
