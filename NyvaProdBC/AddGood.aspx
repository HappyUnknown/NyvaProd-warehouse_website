﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGood.aspx.cs" Inherits="NyvaProdBC.AddGood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" Text="Good creation" />
        <br />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbGoodName" placeholder="Назва товару" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbDescription" placeholder="Опис продукту" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbOrderPrice" placeholder="Ціна замовлення" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbAPF" placeholder="Податок на додану вартість" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbProfit" placeholder="Прибуток" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbTotalAmount" placeholder="Загальна кількість" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbAmountSold" placeholder="Продана кількість" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbWeightKg" placeholder="Вага продукту" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbImageUrls" placeholder="Url зображення продукту" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbControlDigit" placeholder="Контрольна цифра штрихкоду" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbGoodCode" placeholder="Код товару" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbProducerCode" placeholder="Код виробника" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ID="tbRegionCode" placeholder="Код регіону" Style="width: 100%" />
        <br />
        <br />
    <asp:Button runat="server" ID="btnCreateGood" OnClick="btnCreateGood_Click" />
</asp:Content>
