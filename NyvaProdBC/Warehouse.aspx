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
        <h1><%:Title %></h1>
        <br />
        <asp:Table runat="server" CssClass="goodTable table table-dark" ID="tblGoods">
            <%--            
                <asp:TableRow>
                <asp:TableCell CssClass="colorDiv1"></asp:TableCell>
                <asp:TableCell CssClass="colorDiv2"></asp:TableCell>
            </asp:TableRow>--%>
        </asp:Table>
</asp:Content>
