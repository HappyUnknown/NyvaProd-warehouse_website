<%@ Page Title="Товари на складі" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Warehouse.aspx.cs" Inherits="NyvaProdBC.Warehouse" %>
<%@ Register TagPrefix="mp" TagName="MyMP" Src="~/Site.Master" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html>
    <head>
        <!--HOW DO WE CALL FOR LAYOUT MANUALY-->
        <link rel="stylesheet" type="text/css" href="Styles/WarehouseStyles.css" />
    </head>
    <body>
        <h1><%:Title %></h1>
        <br />
        <asp:Table runat="server" CssClass="goodTable" ID="tblGoods">
            <%--            
                <asp:TableRow>
                <asp:TableCell CssClass="colorDiv1"></asp:TableCell>
                <asp:TableCell CssClass="colorDiv2"></asp:TableCell>
            </asp:TableRow>--%>
        </asp:Table>
    </body>
    </html>
</asp:Content>
