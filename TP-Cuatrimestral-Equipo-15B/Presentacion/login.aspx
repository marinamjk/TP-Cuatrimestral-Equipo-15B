<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Presentacion.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">
      <div class="form-group col-md-3">
          <label for="inputMail">Email</label>
          <asp:TextBox ID="TbMail" runat="server" CssClass="form-control" placeholder="ejemplo@gmail.com" type="Email"></asp:TextBox>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="form-group col-md-3 mb-4">
          <label for="inputTarjeta">Contraseña</label>
          <asp:TextBox ID="TbContraseña" runat="server" CssClass="form-control" placeholder="Contraseña" type="Pasword"></asp:TextBox>
      </div>
    </div>
    <div class="row justify-content-center">
        <asp:Button ID="BtAceptar" runat="server" cssclass="btn btn-primary form-group col-md-2" Text="Aceptar" />
    </div>
</asp:Content>
