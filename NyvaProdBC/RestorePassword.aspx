<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RestorePassword.aspx.cs" Inherits="NyvaProdBC.RestorePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (KeyValid)
        {
    %>
    <asp:TextBox runat="server" ID="tbNewPassword" />
    <asp:TextBox runat="server" ID="tbNewConfirmation" />
    <asp:Button runat="server" ID="btnRedeemRestore" OnClick="btnRedeemRestore_Click" Text="Save new password" />
    <%
        }
        else
        {
    %>
        <asp:Label runat="server" ID="lblRestoreRequestFailed" Text="Where did you get that body? The one you're in right now." />
    <%
        }
    %>
</asp:Content>
