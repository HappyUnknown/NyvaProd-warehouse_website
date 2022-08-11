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
                <asp:Panel runat="server" ID="pnlAdminGoodsUI">
                    <asp:Table runat="server" ID="tblGoods" CssClass="goodTable table table-dark" />
                </asp:Panel>
            </body>
            </html>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
