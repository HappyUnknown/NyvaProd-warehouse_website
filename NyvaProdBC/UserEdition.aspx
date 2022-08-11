<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserEdition.aspx.cs" Inherits="NyvaProdBC.UserEdition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="lblMsg" />
    <asp:Panel runat="server" ID="pnlEditionUI">
        <br />
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
        <asp:CheckBox runat="server" ReadOnly="false" ID="chkIsBanned" Text="Banned" TextAlign="Left" OnCheckedChanged="chkIsBanned_CheckedChanged" />
        <br />
        <br />
        <asp:Button runat="server" ID="btnRedeemEdit" OnClick="btnRedeemEdit_Click" AutoPostBack="True" Text="Redeem" />
    </asp:Panel>
</asp:Content>
