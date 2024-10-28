<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .icon-button {
            background-color: transparent; 
            color: red;
            border: none; 
            padding: 10px 15px;
            position: relative;
            background-image: url('data:image/svg+xml;utf8,<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x-lg" viewBox="0 0 16 16"><path d="M2.146 2.854a.5.5 0 1 1 .708-.708L8 7.293l5.146-5.147a.5.5 0 0 1 .708.708L8.707 8l5.147 5.146a.5.5 0 0 1-.708.708L8 8.707l-5.146 5.147a.5.5 0 0 1-.708-.708L7.293 8z"/></svg>'); /* SVG como fondo */
            background-repeat: no-repeat;
            background-position: left center; 
            padding-left: 30px;
            text-align: left;
        }

        body {
            overflow-x: hidden;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="m-6">
                <asp:TextBox ID="txtBusqueda" CssClass="form-control me-2" runat="server" PlaceHolder="Búsqueda por nombre o descripción"></asp:TextBox>
            </div>
        </div>
        <div class="col-12">
            <div class="m-3">
                <asp:Label ID="lblCategorias" runat="server" Text="Categorias: "></asp:Label>
                <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="ddlSubCategoria" runat="server"></asp:DropDownList>
                <%--  <asp:Button ID="btnQuitarFiltroCategorias" runat="server" CssClass="icon-button" Text="Quitar filtro" OnClick="btnQuitarFiltroCategorias_Click" />--%>
            </div>
            <div class="col-12">
                <div class="text-end">
                    <asp:Label ID="lblOrdenamiento" runat="server" Text="Ordenar Por:"></asp:Label>
                    <asp:DropDownList ID="ddlOrdenamiento" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repArticulos" runat="server">
            <ItemTemplate>

                <div class="col">
                    <div class="card  border-dark mb-3" style="max-width: 20rem;">
                        <img src="<%# ((List<dominio.Imagen>)Eval("Imagenes")) != null && ((List<dominio.Imagen>)Eval("Imagenes")).Count > 0 ? ((List<dominio.Imagen>)Eval("Imagenes"))[0].UrlImagen : "data:image/png;base64,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"  %>>" class="card-img-top" alt="..." style="height: 400px; object-fit: contain;">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Marca") %></p>
                            <h4 class="card-title" style="color: blue; text-align: right;">$<%# Eval("Precio", "{0:F2}") %></h4>
                            <a href="Detalle.aspx?id=<%# Eval("IDArticulo") %>" class="btn btn-primary">Ver Detalle</a>
                        </div>
                    </div>
                </div>

            </ItemTemplate>

        </asp:Repeater>
    </div>
</asp:Content>
