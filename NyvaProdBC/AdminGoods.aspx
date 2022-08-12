<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminGoods.aspx.cs" Inherits="NyvaProdBC.AdminGoods" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:GridView runat="server" ID="gdGoods" />--%>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <html>
            <head>
                <link rel="stylesheet" type="text/css" href="Styles/WarehouseStyles.css" />
            </head>
            <body>
                <asp:Label runat="server" ID="lblMsg" />
                <asp:Panel runat="server" ID="pnlAdminGoodsUI" Visible="false">
                    <asp:Table runat="server" ID="tblGoods" CssClass="goodTable table table-dark">
                        <asp:TableHeaderRow>
                            <asp:TableCell Text="ID" />
                            <asp:TableCell Text="Назва" />
                            <asp:TableCell Text="Опис" />
                            <asp:TableCell Text="Ціна замовлення" />
                            <asp:TableCell Text="Частка прибутку" />
                            <asp:TableCell Text="Частка податку" />
                            <asp:TableCell Text="Загальна кількість" />
                            <asp:TableCell Text="Продано" />
                            <asp:TableCell Text="Вага (КГ)" />
                            <asp:TableCell Text="Дата прибуття" />
                            <asp:TableCell Text="Зображення" />
                            <asp:TableCell Text="Код товару" />
                            <asp:TableCell Text="Код виробника" />
                            <asp:TableCell Text="Код регіону" />
                            <asp:TableCell Text="Контрольна цифра" />
                            <asp:TableCell Text="Оглянути" />
                            <asp:TableCell Text="Редагувати" />
                            <asp:TableCell Text="Видалити" />
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <asp:Button runat="server" ID="btnGoToCreate" OnClick="btnGoToCreate_Click" Text="Новий товар" />
                </asp:Panel>
            </body>
            </html>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
