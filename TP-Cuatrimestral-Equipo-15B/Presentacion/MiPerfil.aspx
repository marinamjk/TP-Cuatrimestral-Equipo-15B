<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mi perfil.aspx.cs" Inherits="Presentacion.Mi_perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mt-5">
            <h2>Mi Perfil</h2>
            <div class="row">
                <div class="col-md-4">
                    <div class="card">
                        <img src="https://via.placeholder.com/150" class="card-img-top rounded-circle" alt="Foto de perfil" />
                        <div class="card-body">
                            <h5 class="card-title"><%=((dominio.Usuario)(Session["usuario"])).Nombre%> <%=((dominio.Usuario)(Session["usuario"])).Apellido%></h5>
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <h4>Información Personal</h4>
                </div>
                <div class="form-group">
                </div>
        </div>
</asp:Content>
