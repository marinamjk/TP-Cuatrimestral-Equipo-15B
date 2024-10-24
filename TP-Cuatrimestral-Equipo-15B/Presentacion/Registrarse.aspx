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
        <div class="form-group col-md-3">
          <label for="inputEmail4">Apellido</label>
          <asp:TextBox ID="TbApellido" runat="server" CssClass="form-control" placeholder="Apellido" type="text"></asp:TextBox>
        </div>
      </div>
    </div>
  <div class="container mt-7">
      <div class="form-group col-md-6">
        <label for="inputAddress">direccion</label>
        <asp:TextBox ID="TbDireccion" runat="server" CssClass="form-control" placeholder="Direccion" type="text"></asp:TextBox>
      </div>
  </div>
  <div class="col-md-4 mb-3">
    <div class="form-group col-md-6">
      <label for="inputCity">City</label>
      <input type="text" class="form-control" id="inputCity">
    </div>
    <div class="form-group col-md-6">
      <label for="inputState">State</label>
      <select id="inputState" class="form-control">
        <option selected>Choose...</option>
        <option>...</option>
      </select>
    </div>
    <div class="form-group col-md-6">
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
