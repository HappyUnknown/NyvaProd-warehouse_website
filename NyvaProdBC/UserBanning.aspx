<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserBanning.aspx.cs" Inherits="NyvaProdBC.UserBanning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="lblMsg" />
    <asp:Panel runat="server" ID="pnlBanning" Visible="false">
        <asp:TextBox runat="server" ReadOnly="false" ID="tbFirstName" placeholder="First name" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbLastName" placeholder="Last name" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbFatherName" placeholder="Father name" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbEmail" placeholder="Email" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbPhone" placeholder="Phone" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbPassword" placeholder="Password" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbUserRole" placeholder="User role" />
        <br />
        <asp:CheckBox runat="server" ReadOnly="false" ID="chkIsBanned" Text="Banned" TextAlign="Left" onclick="return false;" />
        <br />
        <br />
        <asp:Button runat="server" ID="btnRedeemBan" OnClick="btnRedeemBan_Click" />
    </asp:Panel>
</asp:Content>
