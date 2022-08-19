<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogoutPage.aspx.cs" Inherits="NyvaProdBC.LogoutPage" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--https://stackoverflow.com/questions/25910272/master-page-public-property-not-available-in-content-page-->
    <div class="container">
        <asp:Label runat="server" ID="lblMsg" />
        <asp:Panel runat="server" ID="pnlLogoutUI" Visible="false">
            <h4>Упевнені у виході з акаунту?</h4>
            <br />
            <asp:Button runat="server" ID="btnLogout" OnClick="btnLogout_Click" Text="Вийти" CssClass="btn-secondary" />
        </asp:Panel>
    </div>
</asp:Content>
