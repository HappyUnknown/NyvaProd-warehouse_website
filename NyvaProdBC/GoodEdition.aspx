<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GoodEdition.aspx.cs" Inherits="NyvaProdBC.GoodEdition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="lblMsg" Style="float: left" />
    <br />
    <asp:Panel runat="server" ID="pnlEditionUI" CssClass="container" Style="width: 20%; float: left">
        <br />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbGoodName" placeholder="Назва товару" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbDescription" placeholder="Опис продукту" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbOrderPrice" placeholder="Ціна замовлення" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbAPF" placeholder="Податок на додану вартість" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbProfit" placeholder="Прибуток" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbTotalAmount" placeholder="Загальна кількість" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbAmountSold" placeholder="Продана кількість" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbWeightKg" placeholder="Вага продукту" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbImageUrls" placeholder="Url зображення продукту" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbDeliveryDate" placeholder="Дата доставки" TextMode="Date" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbControlDigit" placeholder="Контрольна цифра штрихкоду" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbGoodCode" placeholder="Код товару" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ReadOnly="false" ID="tbProducerCode" placeholder="Код виробника" Style="width: 100%" />
        <br />
        <asp:TextBox runat="server" ID="tbRegionCode" placeholder="Код регіону" Style="width: 100%" />
        <br />
        <br />
        <asp:Button runat="server" ID="btnRedeemEdit" OnClick="btnRedeemEdit_Click" Text="Redeem" Style="float: right" />
    </asp:Panel>
</asp:Content>
