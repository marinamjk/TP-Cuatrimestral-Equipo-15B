﻿<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Presentacion.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <asp:TextBox ID="TbContraseña" runat="server" CssClass="form-control" placeholder="Contraseña" type="Password"></asp:TextBox>
            <div class="input-group-append">
                <button class="btn btn-outline-secondary" type="button" id="togglePassword">Mostrar</button>
            </div>
        </div>
  
        <div class="input-group-append mt-3">
            <asp:Button ID="BtAceptar" runat="server" CssClass="btn btn-outline-primary" Text="Aceptar" OnClick="BtAceptar_Click" />            
            <a href="Default.aspx">Cancelar</a>
        </div>
    </div>
        </div>
</asp:Content>
