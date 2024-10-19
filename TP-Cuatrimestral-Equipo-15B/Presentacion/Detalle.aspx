<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Presentacion.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        const myCarouselElement = document.querySelector('#caruselArticulo')
        const carousel = new bootstrap.Carousel(myCarouselElement, {
            keyboard: true;
            touch: false
        })
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class=" col-6">
            <div id="caruselArticulo" class="carousel slide">
                <div class="carousel-indicators">
                    <button type="button" data-bs-target="#caruselArticulo" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                    <button type="button" data-bs-target="#caruselArticulo" data-bs-slide-to="1" aria-label="Slide 2"></button>
                    <button type="button" data-bs-target="#caruselArticulo" data-bs-slide-to="2" aria-label="Slide 3"></button>
                </div>
                <div class="carousel-inner">
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
    </div>



</asp:Content>
