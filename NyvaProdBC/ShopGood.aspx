<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShopGood.aspx.cs" Inherits="NyvaProdBC.ShopGood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table runat="server" ID="tblGoodPage">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Image runat="server" ID="imgGoodPreview" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Table runat="server" ID="tblGoodText">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server" ID="lblGoodName" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server" ID="lblGoodDescription" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
