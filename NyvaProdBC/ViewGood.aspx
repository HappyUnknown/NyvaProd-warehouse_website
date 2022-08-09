<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewGood.aspx.cs" Inherits="NyvaProdBC.ViewGood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="lblMsg" Style="float: left" />
    <br />
    <asp:Panel runat="server" ID="pnlViewUI" CssClass="container" Style="width: 20%; float: left">
        <br />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbGoodName" placeholder="Назва товару" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbOrderPrice" placeholder="Ціна замовлення" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbSellPrice" placeholder="Ціна продажу" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbWeightKg" placeholder="Вага продукту" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbInWare" placeholder="На складі" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbImageUrls" placeholder="Url зображення продукту" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbDescription" placeholder="Опис продукту" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbProductionDate" placeholder="Дата виробництва" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="true" ID="tbConsumedUntil" placeholder="Придатний до" Style="width: 100%" />
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
    </asp:Panel>
</asp:Content>
