<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShopGood.aspx.cs" Inherits="NyvaProdBC.ShopGood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <asp:Table runat="server" Style="width: 100%">
            <asp:TableRow>
                <asp:TableCell Style="display: flex; justify-content: center;">
                    <asp:Label runat="server" ID="lblMsg" Style="font-weight: bold; font-size: 15pt" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Panel runat="server" ID="pnlGoodPage" Visible="false">
            <br />
            <br />
            <%--<asp:Table runat="server" ID="tblGoodInfo" Style="width: 100%; background-color: darkgray">
                <asp:TableRow>
                    <asp:TableCell Style="display: flex; justify-content: center; background-color: darkseagreen">
                        <asp:Label runat="server" ID="lblGoodName" Style="display: flex; align-items: center; justify-content: center" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Table runat="server" ID="tblGoodText">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Image runat="server" ID="imgGoodPreview" />
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label runat="server" ID="lblGoodDescription" CssClass="col-11" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>--%>
            <div class="card" style="width: 100%; padding: 40px; text-align: center">
                <asp:Image runat="server" ID="imgGoodPreview" CssClass="card-img-top" Style="object-fit: contain" alt="Card image" />
                <div class="card-body" style="text-align: left">
                    <asp:Label runat="server" ID="lblGoodName" class="card-title" Style="font-weight: bold; font-size: 25pt" />
                    <br />
                    <asp:Label runat="server" ID="lblPrice" class="card-subtitle" Style="font-weight: 400; font-size: 10pt" />
                    <br />
                    <br />
                    <asp:Label runat="server" ID="lblGoodDescription" class="card-text" Style="font-weight: 400; font-size: 15pt" />
                    <br />
                    <br />
                    <asp:Button runat="server" ID="btnBackToWare" class="btn btn-primary" OnClick="btnBackToWare_Click" Text="Back to order" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
