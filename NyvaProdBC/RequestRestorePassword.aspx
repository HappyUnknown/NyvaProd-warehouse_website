<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestRestorePassword.aspx.cs" Inherits="NyvaProdBC.RequestRestorePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%if (!Submited)
        {
    %>
    <asp:TextBox runat="server" ID="tbUserEmail" placeholder="E-mail" />
    <asp:Button runat="server" ID="btnRequestRestore" Text="Запит на відновлення" OnClick="btnRequestRestore_Click" CssClass="btn-dark"/>
    <%
        }
        else
        {
    %>
    <asp:Label runat="server" Text="Check your email inbox to change password." />
    <%
        }
    %>
</asp:Content>
