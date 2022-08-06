<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="NyvaProdBC.RegisterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title></title>
    </head>
    <body runat="server">
        <div class="container">
            <h1>Реєстрація</h1>
            <br />
            <%--<asp:TextBox runat="server" ID="tbId" placeholder="Id" />
            <br />--%>
            <asp:TextBox runat="server" ID="tbFirstName" placeholder="Ім'я" />
            <br />
            <asp:TextBox runat="server" ID="tbLastName" placeholder="Прізвище" />
            <br />
            <asp:TextBox runat="server" ID="tbFatherName" placeholder="По-Батькові" />
            <br />
            <asp:TextBox runat="server" ID="tbEmail" placeholder="Поштова скринька" />
            <br />
            <asp:TextBox runat="server" ID="tbPhone" placeholder="Номер телефону" />
            <br />
            <asp:TextBox runat="server" TextMode="Password" ID="tbPassword" placeholder="Пароль" />
            <br />
            <asp:TextBox runat="server" TextMode="Password" ID="tbPasswordVerifiy" placeholder="Підтвердження паролю" />
            <br />
            <br />
            <asp:Button runat="server" ID="btnRegister" Text="Зареєструватися" OnClick="btnRegister_Click" />
        </div>
    </body>
    </html>
</asp:Content>
