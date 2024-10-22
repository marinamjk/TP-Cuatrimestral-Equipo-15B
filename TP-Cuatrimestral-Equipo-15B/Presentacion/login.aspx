<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Presentacion.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="row">
        <div class ="col-3">
            <label>User</label>
            <asp:TextBox ID="TxtUser" runat="server" placeholder="User name" CssClass="form-control"></asp:TextBox>

        </div>
    </div>
</asp:Content>
