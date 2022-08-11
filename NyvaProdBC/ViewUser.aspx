<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="NyvaProdBC.ViewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" HorizontalAlign="Left">
        <asp:Label runat="server" ID="lblMsg" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbFirstName" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbLastName" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbFatherName" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbEmail" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbPhone" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbPassword" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbUserRole" />
        <br />
        <asp:CheckBox runat="server" ReadOnly="true" ID="chkIsBanned" Text="Banned" TextAlign="Left" onclick="return false;" />
    </asp:Panel>
</asp:Content>
