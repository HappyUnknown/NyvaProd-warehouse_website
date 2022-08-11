<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="NyvaProdBC.ViewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" HorizontalAlign="Left">
        <asp:Label runat="server" ID="lblMsg" />
        <br />
        <asp:TextBox runat="server" ID="tbFirstName" />
        <br />
        <asp:TextBox runat="server" ID="tbLastName" />
        <br />
        <asp:TextBox runat="server" ID="tbFatherName" />
        <br />
        <asp:TextBox runat="server" ID="tbEmail" />
        <br />
        <asp:TextBox runat="server" ID="tbPhone" />
        <br />
        <asp:TextBox runat="server" ID="tbPassword" />
        <br />
        <asp:TextBox runat="server" ID="tbUserRole" />
        <br />
        <asp:CheckBox runat="server" ID="chkIsBanned" Text="Banned" TextAlign="Left" OnCheckedChanged="chkIsBanned_CheckedChanged" />
    </asp:Panel>
</asp:Content>
