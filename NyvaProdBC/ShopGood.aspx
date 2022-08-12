<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShopGood.aspx.cs" Inherits="NyvaProdBC.ShopGood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Table runat="server" Style="width: 100%">
            <asp:TableRow>
                <asp:TableCell Style="display: flex; justify-content: center">
                    <asp:Label runat="server" ID="lblMsg" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Panel runat="server" ID="pnlGoodPage" Visible="false">
            <br />
            <br />
            <asp:Table runat="server" ID="tblGoodInfo" Style="width: 100%; background-color: darkgray">
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
            </asp:Table>
        </asp:Panel>
    </div>
</asp:Content>
