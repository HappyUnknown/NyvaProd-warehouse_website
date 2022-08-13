<%@ Page Title="Товари на складі" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Warehouse.aspx.cs" Inherits="NyvaProdBC.Warehouse" %>

<%@ Register TagPrefix="mp" TagName="MyMP" Src="~/Site.Master" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <script lang="ja">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
    <% if (User != null)
        {
    %>
    <h1><%:Title %></h1>
    <asp:Panel runat="server" ID="pnlWareUI">
        <br />
<%--        <asp:UpdatePanel runat="server">
            <ContentTemplate>--%>
                <asp:Table runat="server" CssClass="goodTable table table-dark" ID="tblGoods">
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
                        <asp:TableCell Text="Зменшити" />
                        <asp:TableCell Text="Кількість" />
                        <asp:TableCell Text="Збільшити" />
                    </asp:TableHeaderRow>
                    <%--            
                <asp:TableRow>
                <asp:TableCell CssClass="colorDiv1"></asp:TableCell>
                <asp:TableCell CssClass="colorDiv2"></asp:TableCell>
            </asp:TableRow>--%>
                </asp:Table>
<%--            </ContentTemplate>
        </asp:UpdatePanel>--%>
    </asp:Panel>
    <%
        }
        else
        {
    %>
    <asp:Label runat="server" ID="lblMsg" Text="Ви не можете переглянути товари, поки не увійшли до акаунту." />
    <%
        }
    %>
</asp:Content>
