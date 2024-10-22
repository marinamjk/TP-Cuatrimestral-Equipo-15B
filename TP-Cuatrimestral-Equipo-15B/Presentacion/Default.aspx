﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .icon-button {
            background-color: aquamarine; /* Color de fondo */
            color: red; /* Color del texto */
            border: none; /* Sin borde */
            padding: 10px 15px; /* Relleno */
            position: relative;
            background-image: url('data:image/svg+xml;utf8,<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x-lg" viewBox="0 0 16 16"><path d="M2.146 2.854a.5.5 0 1 1 .708-.708L8 7.293l5.146-5.147a.5.5 0 0 1 .708.708L8.707 8l5.147 5.146a.5.5 0 0 1-.708.708L8 8.707l-5.146 5.147a.5.5 0 0 1-.708-.708L7.293 8z"/></svg>'); /* SVG como fondo */
            background-repeat: no-repeat;
            background-position: left center; /* Posiciona el SVG a la izquierda */
            padding-left: 30px; /* Espacio para el ícono */
            text-align: left; /* Alinea el texto */
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
                        <img src="<%# ((List<dominio.Imagen>)Eval("Imagenes"))[0].UrlImagen %>>" class="card-img-top" alt="..." style="height: 400px; object-fit: contain;">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("IDMarca") %></p>
                            <h4 class="card-title" style="color: blue; text-align: right;">$<%# Eval("Precio", "{0:F2}") %></h4>
                            <a href="Detalle.aspx?id=<%# Eval("IDArticulo") %>" class="btn btn-primary">Ver Detalle</a>
                        </div>
                    </div>
                </div>

            </ItemTemplate>

        </asp:Repeater>
    </div>
</asp:Content>
