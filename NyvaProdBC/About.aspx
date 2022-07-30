<%@ Page Title="Про фірму" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NyvaProdBC.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <h2><%: Title %>.</h2>
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse sed cursus ligula. Integer bibendum erat at nisl eleifend fringilla. Mauris auctor quam ut velit lacinia, ut consectetur nunc suscipit. Integer molestie varius justo, id porta enim dapibus ut. Praesent vulputate tortor vitae enim efficitur tristique. Duis ac neque in est ornare aliquam. Mauris ac porta leo. Aenean ligula est, sollicitudin quis ligula vel, rutrum mollis quam. Quisque et est leo. Donec in posuere ex.
            </p>
            <br />
            <table style="height: 400px; width: 100%">
                <tr style="height: 100%">
                    <td style="width: 10%">
                        <asp:Button runat="server" ID="btnPrev" OnClick="btnPrevMedia_Click" />
                    </td>
                    <td style="width: 80%">
                        <table style="width: 100%">
                            <tr style="background-color: aquamarine">
                                <td style="text-align: center">
                                    <br />
                                    <asp:Label runat="server" Text="HELLO" />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr style="background-color: aqua; height: 50%">
                                <td>
                                    <asp:Image runat="server" ID="imgCarousel" Height="400" />
                                </td>
                            </tr>
                            <tr style="background-color: aquamarine">
                                <td style="text-align: center">
                                    <br />
                                    <asp:Label runat="server" Text="HELLO" />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 10%">
                        <asp:Button runat="server" ID="btnNext" OnClick="btnNextMedia_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
