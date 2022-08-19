﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="NyvaProdBC.LoginPage" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--https://stackoverflow.com/questions/25910272/master-page-public-property-not-available-in-content-page-->
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title></title>
    </head>
    <body runat="server">
        <div class="container">
            <h1>Вхід</h1>
            <%--<asp:TextBox runat="server" ID="tbId" placeholder="Id" />
            <br />--%>
            <asp:TextBox runat="server" ID="tbEmail" placeholder="Поштова скринька" />
            <br />
            <asp:TextBox runat="server" TextMode="Password" ID="tbPassword" placeholder="Пароль" />
            <br />
            <br />
            <asp:Button runat="server" ID="btnLogin" Text="Увійти" OnClick="btnLogin_Click" CssClass="btn-dark" />
            <br />
            <asp:CheckBox runat="server" ID="chkSeePassword" Text="Показати пароль" CssClass="custom-checkbox" Style="display: flex; align-content: center;" OnCheckedChanged="chkSeePassword_CheckedChanged" AutoPostBack="true" />
            <br />
            <br />
            <asp:Button runat="server" ID="btnRestore" Text="Відновити пароль" OnClick="btnRestore_Click" CssClass="btn-dark" />
        </div>
    </body>
    </html>
</asp:Content>
