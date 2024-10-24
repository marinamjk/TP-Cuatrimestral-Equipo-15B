<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" CodeBehind="Historial.aspx.cs" Inherits="Presentacion.Historial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Historial</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Mi Historial</h2>
        <div class="row">
            <%--Aca van a ir los articulos de mi historial de compra--%>
           
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
                                <a href="VerCompra.aspx" class="btn btn-primary">Ver Compra</a>
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
                                <a href="VerCompra.aspx" class="btn btn-primary">Ver Compra</a>
                                <a href="#" class="btn btn-danger">Eliminar</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>