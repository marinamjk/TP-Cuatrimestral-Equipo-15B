<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mi perfil.aspx.cs" Inherits="Presentacion.Mi_perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mt-5">
            <h2>Mi Perfil</h2>
            <div class="row">
                <div class="col-md-4">
                    <div class="card">
                        <img src="https://via.placeholder.com/150" class="card-img-top" alt="Foto de perfil" />
                        <div class="card-body">
                            <h5 class="card-title">Nombre de Usuario</h5>
                            <p class="card-text">Descripción breve sobre ti.</p>
                            <a href="#" class="btn btn-primary">Editar Perfil</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <h4>Información Personal</h4>
                </div>
                <div class="form-group">
                            <label for="nombre">Nombre</label>
                            <input type="text" class="form-control" id="nombre" placeholder="Tu nombre" />
                        </div>
                        <div class="form-group">
                            <label for="email">Correo Electrónico</label>
                            <input type="email" class="form-control" id="email" placeholder="Tu correo electrónico" />
                        </div>
                        <div class="form-group">
                            <label for="telefono">Teléfono</label>
                            <input type="text" class="form-control" id="telefono" placeholder="Tu teléfono" />
                        </div>
                        <button type="submit" class="btn btn-success">Guardar Cambios</button>
                </div>
        </div>
</asp:Content>
