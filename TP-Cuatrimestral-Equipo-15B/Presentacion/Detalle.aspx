<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Presentacion.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        const myCarouselElement = document.querySelector('#caruselArticulo')
        const carousel = new bootstrap.Carousel(myCarouselElement, {
            keyboard: false,
            touch: false
        })

        function toggleIcon(button) {
            var icon = document.getElementById('icon');

            // Cambia entre los iconos 'heart' y 'heart-fill'
            if (icon.classList.contains('bi-heart')) {
                icon.classList.remove('bi-heart');
                icon.classList.add('bi-heart-fill');
            } else {
                icon.classList.remove('bi-heart-fill');
                icon.classList.add('bi-heart');
            }
            // Prevenir que el postback del botón ASP.NET ocurra
            return false;
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblCategoria" CssClass="font-monospace fw-light" runat="server" Text="Categoria > Subcategoría"></asp:Label>
            </div>
            <div class="mb-3">
                <div id="caruselArticulo" class="carousel slide">
                    <div class="carousel-indicators">
                        <button type="button" data-bs-target="#caruselArticulo" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                        <button type="button" data-bs-target="#caruselArticulo" data-bs-slide-to="1" aria-label="Slide 2"></button>
                        <button type="button" data-bs-target="#caruselArticulo" data-bs-slide-to="2" aria-label="Slide 3"></button>
                    </div>
                    <div class="carousel-inner">

                        <%--               <asp:Repeater ID="repeterImagenes" runat="server">
              <ItemTemplate>
                  <div class="carousel-item<%# Container.ItemIndex == 0 ? " active" : "" %>">
                      <asp:Image ImageUrl='<%# Eval("imagenUrl") %>' class="d-block w-100" runat="server" Style="width: 400px; height: 400px; object-fit: contain;" />
                  </div>
              </ItemTemplate>
          </asp:Repeater>--%>

                        <div class="carousel-item active">
                            <img src="Recursos/usuario.png" class="d-block w-100" alt="...">
                        </div>
                        <div class="carousel-item">
                            <img src="Recursos/usuario.png" class="d-block w-100" alt="...">
                        </div>
                        <div class="carousel-item">
                            <img src="Recursos/usuario.png" class="d-block w-100" alt="...">
                        </div>
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
            <div class="mb-3">
                <asp:Label ID="lblPrecio" CssClass="fs-1" runat="server" Text="$5000.00"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblStockDisponible" CssClass="fs-6 fw-light" runat="server" Text="Stock Disponible: nro"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad: "></asp:Label>
                <asp:DropDownList ID="ddlStock" runat="server"></asp:DropDownList>
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
        </div>
 </div>

</asp:Content>
