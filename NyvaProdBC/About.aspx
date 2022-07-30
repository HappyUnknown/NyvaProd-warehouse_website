<%@ Page Title="Про фірму" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NyvaProdBC.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <!DOCTYPE html>
            <html xmlns="http://www.w3.org/1999/xhtml">
            <head>
                <title><%: Title %></title>
                <link rel="stylesheet" type="text/css" href="Styles/AboutStyles.css" />
            </head>
            <body>
                <div class="container">
                    <h2><%: Title %>.</h2>
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse sed cursus ligula. Integer bibendum erat at nisl eleifend fringilla. Mauris auctor quam ut velit lacinia, ut consectetur nunc suscipit. Integer molestie varius justo, id porta enim dapibus ut. Praesent vulputate tortor vitae enim efficitur tristique. Duis ac neque in est ornare aliquam. Mauris ac porta leo. Aenean ligula est, sollicitudin quis ligula vel, rutrum mollis quam. Quisque et est leo. Donec in posuere ex.
                    </p>
                </div>
                <br />
                <div class="container">
                    <asp:Table runat="server" Style="height: 400px; width: 100%">
                        <asp:TableRow Style="height: 100%">
                            <asp:TableCell Style="width: 10%">
                                <asp:Button runat="server" ID="btnPrev" OnClick="btnPrevMedia_Click" CssClass="button" />
                            </asp:TableCell>
                            <asp:TableCell Style="width: 80%">
                                <asp:Table Style="width: 100%" runat="server">
                                    <asp:TableRow Style="background-color: aquamarine">
                                        <asp:TableCell Style="text-align: center">
                                            <br />
                                            <asp:Label runat="server" ID="lblUpTitle" Text="HELLO" />
                                            <br />
                                            <br />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow Style="height: 50%">
                                        <asp:TableCell Style="background-color: red;">
                                            <asp:Image runat="server" ID="imgCarousel" CssClass="image" Height="400" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow Style="background-color: aquamarine">
                                        <asp:TableCell Style="text-align: center">
                                            <br />
                                            <asp:Label runat="server" ID="lblDownTitle" Text="HELLO" />
                                            <br />
                                            <br />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 10%">
                                <asp:Button runat="server" ID="btnNext" OnClick="btnNextMedia_Click" CssClass="button" Style="width: 100%; height: 400px;" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <br />
                <div class="container">
                    <h2><%: Title %>.</h2>
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse sed cursus ligula. Integer bibendum erat at nisl eleifend fringilla. Mauris auctor quam ut velit lacinia, ut consectetur nunc suscipit. Integer molestie varius justo, id porta enim dapibus ut. Praesent vulputate tortor vitae enim efficitur tristique. Duis ac neque in est ornare aliquam. Mauris ac porta leo. Aenean ligula est, sollicitudin quis ligula vel, rutrum mollis quam. Quisque et est leo. Donec in posuere ex.
                    </p>
                </div>
            </body>
            </html>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
