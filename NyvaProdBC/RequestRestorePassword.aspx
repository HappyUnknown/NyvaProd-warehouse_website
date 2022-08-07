<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestRestorePassword.aspx.cs" Inherits="NyvaProdBC.RequestRestorePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox runat="server" ID="tbUserEmail" />
    <asp:Button runat="server" ID="btnRequestRestore" Text="Request restoration" OnClick="btnRequestRestore_Click" />
</asp:Content>
