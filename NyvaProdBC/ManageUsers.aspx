<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="NyvaProdBC.ManageUsers1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="lblMsg" />
    <asp:Panel runat="server" ID="pnlUserManageUI">
        <asp:Table runat="server" ID="tblUsers" CssClass="table table-dark">
            <asp:TableHeaderRow>
                <asp:TableCell Text="ID" />
                <asp:TableCell Text="Ім'я" />
                <asp:TableCell Text="Прізвище" />
                <asp:TableCell Text="По-батькові" />
                <asp:TableCell Text="E-Mail" />
                <asp:TableCell Text="Телефон" />
                <asp:TableCell Text="Пароль" />
                <asp:TableCell Text="Роль" />
                <asp:TableCell Text="Забанено" />
                <asp:TableCell Text="Оглянути" />
                <asp:TableCell Text="Змінити" />
                <asp:TableCell Text="Забанити" />
                <asp:TableCell Text="Видалити" />
            </asp:TableHeaderRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
