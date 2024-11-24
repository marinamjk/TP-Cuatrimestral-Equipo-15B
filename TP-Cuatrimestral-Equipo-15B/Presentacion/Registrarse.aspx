<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Presentacion.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    document.addEventListener('DOMContentLoaded', function () {
        // Seleccionar todos los botones que controlan contraseñas
        document.querySelectorAll('button[data-target]').forEach(function (button) {
            button.addEventListener('click', function () {
                // Obtener el ID del TextBox objetivo desde el atributo data-target
                var targetId = button.getAttribute('data-target');
                var passwordField = document.getElementById(targetId);

                if (passwordField.type === 'password') {
                    passwordField.type = 'text';
                    button.innerText = 'Ocultar'; // Cambiar el texto del botón
                } else {
                    passwordField.type = 'password';
                    button.innerText = 'Mostrar';
                }
            });
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center">
        <div class="col-4">

            <div class="mb-3">
                <label for="inputEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="ejemplo@gmail.com" type="Email"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="inputContraseña">Contraseña</label>
                <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" placeholder="Contraseña" type="Password"></asp:TextBox>
                <button class="btn btn-outline-secondary" type="button" data-target="<%= txtContraseña.ClientID %>">Mostrar</button>
            </div>

            <div>
                <label for="inputContraseña2">Confirmar Contraseña</label>
                <asp:TextBox ID="txtContraseña2" runat="server" CssClass="form-control" placeholder="Contraseña" type="Password"></asp:TextBox>
                <button class="btn btn-outline-secondary" type="button" data-target="<%= txtContraseña2.ClientID %>">Mostrar</button>
           </div>

            <div class="input-group-append mt-3">
                <asp:Button ID="btnRegistrarse" runat="server" CssClass="btn btn-outline-primary" Text="Registrarse" OnClick="btnRegistrarse_Click" />
                <a href="Default.aspx">Cancelar</a>
            </div>

        </div>
    </div>
</asp:Content>
