<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogoutPage.aspx.cs" Inherits="NyvaProdBC.LogoutPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Вихід</h1>
        <h4>Упевнені у виході з акаунту?</h4>
        <br />
        <asp:Button runat="server" ID="btnLogout" OnClick="btnLogout_Click" Text="Вийти" CssClass="btn-secondary" />
    </div>
</asp:Content>
