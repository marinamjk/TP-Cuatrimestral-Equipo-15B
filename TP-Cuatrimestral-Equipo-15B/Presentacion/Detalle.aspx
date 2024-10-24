﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Presentacion.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            overflow-x: hidden;
        }
    </style>
    <script>
        const myCarouselElement = document.querySelector('#caruselArticulo')
        const carousel = new bootstrap.Carousel(myCarouselElement, {
            keyboard: false,
            touch: false
        })

        function toggleIcon(button) {
            var icon = document.getElementById('icon');

            
            if (icon.classList.contains('bi-heart')) {
                icon.classList.remove('bi-heart');
                icon.classList.add('bi-heart-fill');
            } else {
                icon.classList.remove('bi-heart-fill');
                icon.classList.add('bi-heart');
            }
            
            return false;
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">Categoria</li>
                        <li class="breadcrumb-item">Subcategoria</li>
                    </ol>
                </nav>
            </div>
            <div id="caruselArticulo" class="carousel slide">
                <div class="carousel-indicators">
                    <asp:Repeater ID="repeterImagenesInd" runat="server">
                        <ItemTemplate>


                            <button type="button" data-bs-target="#caruselArticulo" data-bs-slide-to="<%# Container.ItemIndex %>"
                                class="<%# Container.ItemIndex == 0 ? " active" : "" %>"
                                aria-current="<%# Container.ItemIndex == 0 ? "true" : "" %>"
                                aria-label="Slide <%# Container.ItemIndex + 1 %>">
                            </button>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="carousel-inner">

                    <asp:Repeater ID="repeterImagenes" runat="server">
                        <ItemTemplate>
                            <div class="carousel-item<%# Container.ItemIndex == 0 ? " active" : "" %>">
                                <asp:Image ImageUrl='<%# Eval("UrlImagen") %>' class="d-block w-100" runat="server" Style="width: 400px; height: 400px; object-fit: contain;" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#caruselArticulo" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#caruselArticulo" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
            <div class="mb-3">
                <h1><strong>Acá va el nombre del articulo
                </strong>
                </h1>
            </div>
            <div class="mb-3">
                <h1 class="fs-4">Acá va la marca
                </h1>
            </div>
            <div class="mb-3">
                <p class="fs-4 lh-sm">
                    Acá va la descripción del producto
                </p>
            </div>
        </div>


        <div class="col-6">
            <br />
            <br />
            <div class="mb-3">
                <asp:Label ID="lblPrecio" CssClass="fs-1" runat="server" Text="$5000.00"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblStockDisponible" CssClass="fs-6 fw-light" runat="server" Text="Stock Disponible: nro"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad: "></asp:Label>
                <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" Min="1" Max="100"></asp:TextBox>
                <asp:Button ID="btnAgregarAlCarrito" runat="server" Text="Agregar al carrito" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblConfirmacion" runat="server" Text="Confirmacion de item agregado"></asp:Label>
                <asp:Button ID="btnIrAlCarrito" class="ms-auto" runat="server" Text="Ir al carrito" />
            </div>
            <hr />
            <div class="mb-3">
                <asp:Button ID="btnFavorito" runat="server" Text="Añadir a Favoritos" OnClientClick="toggleIcon(this); return false" />
                <i id="icon" class="bi bi-heart"></i>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <asp:Button ID="Modificar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="Modificar_Click" />
                        <asp:Button ID="btnEliminarArticulo" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminarArticulo_Click" />
                    
                    </div>
                    <%if (ConfirmarEliminacion)
                        { %>
                    <div class="m-3">
                        <asp:CheckBox ID="chkConfirmarEliminacion" Text="Confirmar eliminación" runat="server" />
                        <asp:Button ID="btnConfirmarEliminacion" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnConfirmarEliminacion_Click" />
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
