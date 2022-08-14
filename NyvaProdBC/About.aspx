<%@ Page Title="Про фірму" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NyvaProdBC.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <storyboard x:key="animate">
        <objectanimationusingkeyframes begintime="0:0:0" storyboard.targetproperty="Visibility">
            <discreteobjectkeyframe keytime="0">
                <discreteobjectkeyframe.value>
                    <visibility>Visible</visibility>
                </discreteobjectkeyframe.value>
            </discreteobjectkeyframe>
        </objectanimationusingkeyframes>
        <doubleanimation begintime="0:0:0.0" storyboard.targetproperty="Opacity" from="0" to="1" duration="0:0:0.2" />
        <doubleanimation begintime="0:0:5.0" storyboard.targetproperty="Opacity" from="1" to="0" duration="0:0:0.5" />
        <objectanimationusingkeyframes begintime="0:0:5.5" storyboard.targetproperty="Visibility">
            <discreteobjectkeyframe keytime="0">
                <discreteobjectkeyframe.value>
                    <visibility>Hidden</visibility>
                </discreteobjectkeyframe.value>
            </discreteobjectkeyframe>
        </objectanimationusingkeyframes>
    </storyboard>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <!DOCTYPE html>
            <html xmlns="http://www.w3.org/1999/xhtml">
            <head>
                <title><%: Title %></title>
                <link rel="stylesheet" type="text/css" href="Styles/AboutStyles.css" />
                <style>
                    .btn-carousel {
                        background-color: transparent;
                    }

                        .btn-carousel:hover {
                            color: whitesmoke;
                            background-color: #343a40;
                        }
                </style>
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
                    <asp:Table ID="tblAboutUI" runat="server" Style="height: 400px; width: 100%; border-radius: 10px 10px">
                        <asp:TableRow Style="height: 100%">
                            <%--
                            <asp:TableCell Style="width: 10%">
                                <asp:Button runat="server" ID="btnPrevMedia" OnClick="btnPrevMedia_Click" CssClass="btn btn-primary btn-carousel" Style="width: 100%; height: 400px;" />
                            </asp:TableCell>--%>
                            <asp:TableCell Style="width: 80%">
                                <asp:Table Style="width: 100%" runat="server">
                                    <asp:TableRow Style="background-color: #343a40">
                                        <asp:TableCell Style="text-align: center">
                                            <br />
                                            <asp:Label runat="server" ID="lblUpTitle" Text="HELLO" Style="color: whitesmoke" />
                                            <br />
                                            <br />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow Style="height: 50%">
                                        <asp:TableCell Style="background-color: red;">
                                            <asp:Table runat="server" ID="tblCarouselUI" Height="400" Width="100%" Style="background-color: whitesmoke; background-repeat: no-repeat; background-size: contain; background-position: center;">
                                                <asp:TableRow>
                                                    <asp:TableCell Style="width: 10%;">
                                                        <asp:Button runat="server" ID="btnPrev" OnClick="btnPrevMedia_Click" CssClass="btn btn-carousel" Style="height: 400px; width: 100%" Text="<" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Style="width: 80%;">
                                                        <asp:Image runat="server" ID="imgCarousel" CssClass="image" Style="height: 400px;" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Style="width: 10%;">
                                                        <asp:Button runat="server" ID="btnNext" OnClick="btnNextMedia_Click" CssClass="btn btn-carousel" Style="height: 400px; width: 100%" Text=">" />
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow Style="background-color: #343a40">
                                        <asp:TableCell Style="text-align: center">
                                            <br />
                                            <asp:Label runat="server" ID="lblDownTitle" Text="HELLO" Style="color: whitesmoke" />
                                            <br />
                                            <br />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                            <%--
                            <asp:TableCell Style="width: 10%">
                                <asp:Button runat="server" ID="btnNextMedia" OnClick="btnNextMedia_Click" CssClass="btn btn-primary btn-carousel" Style="width: 100%; height: 400px;" />
                            </asp:TableCell>
                            --%>
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
