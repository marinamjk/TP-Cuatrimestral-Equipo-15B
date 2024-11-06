<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ValidarUsuario.aspx.cs" Inherits="Presentacion.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form>
      <div class="container mt-6">
        <div class="row justify-content-center">
            <label>Codigo</label>
            <asp:TextBox ID="TbCodigo" runat="server" CssClass="form-control" placeholder="********" type="Text"></asp:TextBox>
        </div>
      </div>
    <asp:Button ID="BtAceptar" runat="server" CssClass="btn btn-primary form-group col-md-2" Text="Aceptar" OnClick="BtAceptar_Click" />
</form>
</asp:Content>
