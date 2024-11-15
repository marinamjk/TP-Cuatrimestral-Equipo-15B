<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Presentacion.Detalle" %>

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

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblCategoria" runat="server"></asp:Label>
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
                <h1><strong><%= nombreArt %></strong></h1>
            </div>
            <div class="mb-3">
                <h1 class="fs-4"><%= marcaArt %></h1>
            </div>
            <div class="mb-3">
                <p class="fs-4 lh-sm"><%= descripcionArt %></p>
            </div>
        </div>


        <div class="col-6">
            <br />
            <br />
            <div class="mb-3">
                <asp:Label ID="lblPuntaje" CssClass="fs-1" runat="server"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblPrecio" CssClass="fs-1" runat="server"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblStockDisponible" CssClass="fs-6 fw-light" runat="server"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad: "></asp:Label>
                <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" Text="1" Min="1" Max="100"></asp:TextBox>
                <asp:Button ID="btnAgregarAlCarrito" runat="server" Text="Agregar al carrito" OnClick="btnAgregarAlCarrito_Click" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblConfirmacion" runat="server" Text=""></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnIrAlCarrito" class="ms-auto" runat="server" Text="Ir al carrito" OnClick="btnIrAlCarrito_Click" />
            </div>

            <hr />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button ID="btnFavorito" runat="server" Text="Añadir a Favoritos" OnClick="btnFavorito_Click" />
                        <i id="icon" class="bi <%= esFavorito ? "bi-heart-fill" : "bi-heart" %>"></i>
                    </div>


                    <% if (Negocio.Seguridad.esAdministrador(Session["usuario"]))
                        { %>

                    <div>
                        <asp:Button ID="Modificar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="Modificar_Click" />
                        <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar" CssClass="btn btn-warning" OnClick="btnDeshabilitar_Click" />
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>

</asp:Content>
