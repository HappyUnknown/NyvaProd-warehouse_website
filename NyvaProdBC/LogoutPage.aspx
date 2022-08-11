<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogoutPage.aspx.cs" Inherits="NyvaProdBC.LogoutPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Label runat="server" ID="lblMsg" />
        <asp:Panel runat="server" ID="pnlLogoutUI" Visible="false">
            <h4>Упевнені у виході з акаунту?</h4>
            <br />
            <asp:Button runat="server" ID="btnLogout" OnClick="btnLogout_Click" Text="Вийти" CssClass="btn-secondary" />
        </asp:Panel>
    </div>
</asp:Content>
