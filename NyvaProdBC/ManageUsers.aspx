<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="NyvaProdBC.ManageUsers1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="lblMsg" />
    <asp:Panel runat="server" ID="pnlUserManageUI">
        <asp:Table runat="server" ID="tblUsers" CssClass="table table-dark" />
    </asp:Panel>
</asp:Content>
