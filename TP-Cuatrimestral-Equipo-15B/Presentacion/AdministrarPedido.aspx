<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarPedido.aspx.cs" Inherits="Presentacion.AdministrarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="fs-4 m-3">
        Agregar o modificar Artículo
    </h1>
<div class="row">
    <div class="col-4">
   <ul class="list-group">
  <li class="list-group-item">
    <input class="form-check-input me-1" type="checkbox" value="" id="firstCheckboxStretched">
    <label class="form-check-label stretched-link" for="firstCheckboxStretched">First checkbox</label>
  </li>
  <li class="list-group-item">
    <input class="form-check-input me-1" type="checkbox" value="" id="secondCheckboxStretched">
    <label class="form-check-label stretched-link" for="secondCheckboxStretched">Second checkbox</label>
  </li>
  <li class="list-group-item">
    <input class="form-check-input me-1" type="checkbox" value="" id="thirdCheckboxStretched">
    <label class="form-check-label stretched-link" for="thirdCheckboxStretched">Third checkbox</label>
  </li>
</ul>
    </div>
</div>

</asp:Content>
