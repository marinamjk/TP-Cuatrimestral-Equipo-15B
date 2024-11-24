<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Presentacion.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
        <script>
            document.addEventListener('DOMContentLoaded', function () {
                document.getElementById('btnShowPassword').addEventListener('click', function () {
                    var passwordField = document.getElementById('<%= TbContraseña.ClientID %>');
                if (passwordField.type === 'password') {
                    passwordField.type = 'text';
                    this.innerText = 'Ocultar'; // Cambia el texto del botón
                } else {
                    passwordField.type = 'password';
                    this.innerText = 'Mostrar';
                }
            });
        });
    </script>

    <style>
    #btnShowPassword {
        margin-top: 10px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">
        <div class="col-4">
        <div class="mb-3">
            <label for="inputMail">Email</label>
            <asp:TextBox ID="TbMail" runat="server" CssClass="form-control" placeholder="ejemplo@gmail.com" type="Email"></asp:TextBox>
        </div>
        
 
        <div class="mb-3">
            <label for="inputContraseña">Contraseña</label>
            <asp:TextBox ID="TbContraseña" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
            <div class="input-group-append">
                <button class="btn btn-outline-secondary" type="button" id="btnShowPassword">Mostrar</button>
            </div>
        </div>
  
        <div class="input-group-append mt-3">
            <asp:Button ID="BtAceptar" runat="server" CssClass="btn btn-outline-primary" Text="Aceptar" OnClick="BtAceptar_Click" />            
            <a href="Default.aspx">Cancelar</a>
        </div>
    </div>
        </div>
</asp:Content>
