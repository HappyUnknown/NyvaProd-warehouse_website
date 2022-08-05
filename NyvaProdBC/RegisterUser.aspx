﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="NyvaProdBC.RegisterUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="tbId" placeholder="Id" />
            <br />
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
            <asp:TextBox runat="server" ID="tbPassword" placeholder="Пароль" />
            <br />
            <asp:TextBox runat="server" ID="tbPasswordVerifiy" placeholder="Підтвердження паролю" />
            <br />
            <asp:Button runat="server" ID="btnRegisterUser" OnClick="btnRegisterUser_Click" Text="Зареєструватись" />
            <br />
            <asp:Button runat="server" ID="btnCheckRegistration" OnClick="btnCheckRegistration_Click" Text="Перевірити" />
        </div>
    </form>
</body>
</html>
