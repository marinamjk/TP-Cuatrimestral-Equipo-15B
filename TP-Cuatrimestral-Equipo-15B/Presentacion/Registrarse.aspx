<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Presentacion.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <form>
    <div class="container mt-6">
      <div class="row justify-content-center">
        <div class="form-group col-md-4">
          <label for="inputEmail4">Nombre</label>
          <asp:TextBox ID="TbNombre" runat="server" CssClass="form-control" placeholder="Nombre" type="text"></asp:TextBox>
        </div>
        <div class="form-group col-md-4">
          <label for="inputEmail4">Apellido</label>
          <asp:TextBox ID="TbApellido" runat="server" CssClass="form-control" placeholder="Apellido" type="text"></asp:TextBox>
        </div>
      </div>
    </div>
  <div class="container mt-7">
      <div class="row justify-content-center">
          <div class="form-group col-md-4">
            <label for="inputAddress">direccion</label>
            <asp:TextBox ID="TbDireccion" runat="server" CssClass="form-control" placeholder="Direccion" type="text"></asp:TextBox>
          </div>
          <div class="form-group col-md-4">
            <label for="inputAddress">Documento</label>
            <asp:TextBox ID="TbDocumento" runat="server" CssClass="form-control" placeholder="Direccion" type="text"></asp:TextBox>
          </div>
      </div>
  </div>
  <div class="container mt-7">
    <div class="row justify-content-center">
        <div class="form-group col-md-4">
      <label for="inputEmail4">Email</label>
      <asp:TextBox ID="TbMail" runat="server" CssClass="form-control" placeholder="Email" type="email"></asp:TextBox>
    </div>
    <div class="form-group col-md-2">
      <label for="inputPassword4">Contraseña</label>
      <asp:TextBox ID="TbContraseña" runat="server" CssClass="form-control" placeholder="Contraseña" type="password"></asp:TextBox>
    </div>
    <div class="form-group col-md-2">
      <label for="inputPassword4">Contraseña</label>
      <asp:TextBox ID="TbConfirmaContraseña" runat="server" CssClass="form-control" placeholder="Repita contraseña" type="password"></asp:TextBox>
    </div>
  <div class="mb-4">
      <div class="row justify-content-center">
        <div class="form-group col-md-4">
            <label for="inputPassword4">Telefono</label>
            <asp:TextBox ID="TbTelefono" runat="server" CssClass="form-control" placeholder="15151516" type="Text"></asp:TextBox>
        </div>
        <div class="form-group col-md-4">
            <label for="inputTarjeta">Numero Tarjeta</label>
            <asp:TextBox ID="TbTarjeta" runat="server" CssClass="form-control" placeholder="45648924182" type="Text"></asp:TextBox>
        </div>
      </div>
  </div>
  <asp:Button ID="BtAceptar" runat="server" cssclass="btn btn-primary form-group col-md-2" Text="Aceptar" />
</form>
</asp:Content>
