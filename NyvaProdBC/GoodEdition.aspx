<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GoodEdition.aspx.cs" Inherits="NyvaProdBC.GoodEdition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="lblMsg" style="float:left" />
    <br />
    <asp:Panel runat="server" ID="pnlEditionUI" CssClass="container" Style="width: 20%; float:left">
        <br />
        <br />
        <asp:TextBox runat="server" ID="tbGoodName" placeholder="Назва товару" Style="width:100%" />
        <br />
        <asp:TextBox runat="server" ID="tbOrderPrice" placeholder="Ціна замовлення" Style="width:100%" />
        <br />
        <asp:TextBox runat="server" ID="tbSellPrice" placeholder="Ціна продажу" Style="width:100%" />
        <br />
        <asp:TextBox runat="server" ID="tbWeightKg" placeholder="Вага продукту" Style="width:100%" />
        <br />
        <asp:TextBox runat="server" ID="tbInWare" placeholder="На складі" Style="width:100%" />
        <br />
        <asp:TextBox runat="server" ID="tbImageUrls" placeholder="Url зображення продукту" Style="width:100%" />
        <br />
        <asp:TextBox runat="server" ID="tbDescription" placeholder="Опис продукту" Style="width:100%" />
        <br />
        <asp:TextBox runat="server" ID="tbProductionDate" placeholder="Дата виробництва" Style="width:100%" />
        <br />
        <asp:TextBox runat="server" ID="tbConsumedUntil" placeholder="Придатний до" Style="width:100%" />
        <br />
        <asp:TextBox runat="server" ID="tbControlDigit" placeholder="Контрольна цифра штрихкоду" Style="width:100%" />
        <br />
        <asp:TextBox runat="server" ID="tbGoodCode" placeholder="Код товару" Style="width:100%" />
        <br />
        <asp:TextBox runat="server" ID="tbProducerCode" placeholder="Код виробника" Style="width:100%" />
        <br />
        <asp:TextBox runat="server" ID="tbRegionCode" placeholder="Код регіону" Style="width:100%" />
        <br />
        <br />
        <asp:Button runat="server" ID="btnRedeemEdit" OnClick="btnRedeemEdit_Click" Text="Redeem" Style="float:right" />
    </asp:Panel>
</asp:Content>
