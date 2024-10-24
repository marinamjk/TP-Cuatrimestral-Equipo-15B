<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Presentacion.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Favoritos</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Mis favoritos</h2>
        <div class="row">
            <%--Aca van a ir los articulos que elijan como favoritos--%>
           
            <div class="col-md-12 mb-3">
                <div class="card">
                    <div class="row no-gutters">
                        <div class="col-md-3">
                            <img src="https://http2.mlstatic.com/D_NQ_NP_989360-MLU77374831741_072024-O.webp" class="card-img" alt="teclado dragon">
                        </div>
                        <div class="col-md-9">
                            <div class="card-body">
                                <h5 class="card-title">Teclado mecanico dragon</h5>
                                <p class="card-text font-weight-bold">$465.025</p>
                                <p class="card-text">Mismo precio en 9 cuotas de $51.669</p>
                                <p class="card-text text-success">Envío gratis</p>
                                <a href="#" class="btn btn-primary">Agregar a lista</a>
                                <a href="#" class="btn btn-danger">Eliminar</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

         
            <div class="col-md-12 mb-3">
                <div class="card">
                    <div class="row no-gutters">
                        <div class="col-md-3">
                            <img src="https://images.fravega.com/f300/e7e45984e7583eb55e55b10d69b9c187.jpg" class="card-img" alt="Netbook super pro">
                        </div>
                        <div class="col-md-9">
                            <div class="card-body">
                                <h5 class="card-title">Netbook marca pajarito </h5>
                                <p class="card-text"><del>2.000.000</del> $193.205.000 <span class="text-success">5% OFF</span></p>
                                <p class="card-text">En 6 cuotas de $32.300.000 anda a sabr</p>
                                <a href="#" class="btn btn-primary">Agregar a lista</a>
                                <a href="#" class="btn btn-danger">Eliminar</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>