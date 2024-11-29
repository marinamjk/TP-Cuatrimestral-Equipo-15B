<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarCupon.aspx.cs" Inherits="Presentacion.AgregarCupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">
    <div class="col-4">
    <div class="mb-3">
        <label for="Inputdescuento">Descuento</label>
        <asp:TextBox ID="TbMail" runat="server" CssClass="form-control" placeholder="x%" type="text"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label for="inputcodigo">Codigo</label>
        <asp:TextBox ID="TbContraseña" runat="server" CssClass="form-control" placeholder="Codigo" type="text"></asp:TextBox>
    </div>  
    <div class="input-group-append mt-3">
        <asp:Button ID="BtAceptar" runat="server" CssClass="btn btn-outline-primary" Text="Aceptar" />
        <asp:Button ID="Cancelar" runat="server" Text="Cancelar" CssClass="btn btn-outline-primary"/>
    </div>
</asp:Content>
