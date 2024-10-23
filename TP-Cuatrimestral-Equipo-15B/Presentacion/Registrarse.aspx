<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Presentacion.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <form>
  <div class="col-md-4 mb-3">
    <div class="form-group col-md-6">
      <label for="inputEmail4">Nombre</label>
      <asp:TextBox ID="TbNombre" runat="server" CssClass="form-control" placeholder="Nombre" type="text"></asp:TextBox>
    </div>
    <div class="form-group col-md-6">
      <label for="inputEmail4">Apellido</label>
      <asp:TextBox ID="TbApellido" runat="server" CssClass="form-control" placeholder="Apellido" type="text"></asp:TextBox>
    </div>
    <div class="form-group col-md-6">
      <label for="inputEmail4">Apellido</label>
      <asp:TextBox ID="TbDNI" runat="server" CssClass="form-control" placeholder="44444444" type="text"></asp:TextBox>
    </div>
    <div class="form-group col-md-6">
      <label for="inputEmail4">Email</label>
      <asp:TextBox ID="TbMail" runat="server" CssClass="form-control" placeholder="Email" type="email"></asp:TextBox>
    </div>
    <div class="form-group col-md-6">
      <label for="inputPassword4">Password</label>
      <asp:TextBox ID="TbContraseña" runat="server" CssClass="form-control" placeholder="Contraseña" type="password"></asp:TextBox>
    </div>
    <div class="form-group col-md-6">
      <label for="inputPassword4">Password</label>
      <asp:TextBox ID="TbConfirmaContraseña" runat="server" CssClass="form-control" placeholder="Repita contraseña" type="password"></asp:TextBox>
    </div>
  </div>
  <div class="col-md-4 mb-3">
    <label for="inputAddress">Address</label>
    <input type="text" class="form-control" id="inputAddress" placeholder="1234 Main St">
  </div>
  <div class="col-md-4 mb-3">
    <div class="form-group col-md-6">
      <label for="inputCity">City</label>
      <input type="text" class="form-control" id="inputCity">
    </div>
    <div class="col-md-4 mb-3">
      <label for="inputState">State</label>
      <select id="inputState" class="form-control">
        <option selected>Choose...</option>
        <option>...</option>
      </select>
    </div>
    <div class="col-md-4 mb-3">
      <label for="inputZip">Zip</label>
      <input type="text" class="form-control" id="inputZip">
    </div>
  </div>
  <div class="col-md-4 mb-3">
    <div class="form-check">
      <input class="form-check-input" type="checkbox" id="gridCheck">
      <label class="form-check-label" for="gridCheck">
        Check me out
      </label>
    </div>
  </div>
  <button type="submit" class="btn btn-primary">Sign in</button>
</form>
</asp:Content>
