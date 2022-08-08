<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGood.aspx.cs" Inherits="NyvaProdBC.AddGood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" Text="Good creation" />
    <br />
    <br />
    <asp:TextBox runat="server" ID="tbGoodName" placeholder="Назва товару" />
    <br />
    <asp:TextBox runat="server" ID="tbOrderPrice" placeholder="Ціна замовлення" />
    <br />
    <asp:TextBox runat="server" ID="tbSellPrice" placeholder="Ціна продажу" />
    <br />
    <asp:TextBox runat="server" ID="tbWeightKg" placeholder="Вага продукту" />
    <br />
    <asp:TextBox runat="server" ID="tbInWare" placeholder="На складі" />
    <br />
    <asp:TextBox runat="server" ID="tbImageUrls" placeholder="Url зображення продукту" />
    <br />
    <asp:TextBox runat="server" ID="tbDescription" placeholder="Опис продукту" />
    <br />
    <asp:TextBox runat="server" ID="tbProductionDate" placeholder="Дата виробництва" />
    <br />
    <asp:TextBox runat="server" ID="tbConsumedUntil" placeholder="Придатний до" />
    <br />
    <asp:TextBox runat="server" ID="tbControlDigit" placeholder="Контрольна цифра штрихкоду" />
    <br />
    <asp:TextBox runat="server" ID="tbGoodCode" placeholder="Код товару" />
    <br />
    <asp:TextBox runat="server" ID="tbProducerCode" placeholder="Код виробника" />
    <br />
    <asp:TextBox runat="server" ID="tbRegionCode" placeholder="Код регіону" />
    <br />
    <br />
    <asp:Button runat="server" ID="btnCreateGood" OnClick="btnCreateGood_Click" />
</asp:Content>
