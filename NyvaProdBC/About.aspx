<%@ Page Title="Про фірму" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NyvaProdBC.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <storyboard x:key="animate">
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
    </storyboard>--%>
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

                    #animation1 {
                        -webkit-animation: fadeIn 1s 4 ease;
                        -webkit-animation-iteration-count: infinite;
                        -webkit-animation-direction: alternate;
                    }

                    #animation2 {
                        -webkit-animation: scaling 1s 4 ease;
                        -webkit-animation-iteration-count: infinite;
                        -webkit-animation-direction: alternate;
                        width: 100%;
                    }

                    @keyframes fadeIn {
                        0% {
                            opacity: 1;
                            animation-play-state: running;
                        }

                        100% {
                            opacity: 0;
                            animation-play-state: paused;
                        }
                    }

                    @-webkit-keyframes scaling {

                        from {
                            -webkit-transform: scale(0.2);
                        }

                        to {
                            -webkit-transform: scale(1);
                        }
                    }

                    /*https://www.neerajcodesolutions.com/2017/04/animation-image-using-css-in-mvc.html*/
                    .fader {
                        background: whitesmoke;
                        width: 100%;
                        height: 100%;
                        border-radius: 10px;
                        animation: fadeIn;
                        animation-duration: 1s;
                        animation-delay: 1000ms;
                        animation-fill-mode: forwards;
                        animation-timing-function: ease-in-out;
                    }

                    .raver {
                        background: orange;
                        width: 250px;
                        height: 250px;
                        border-radius: 10px;
                        animation: moveToLeft;
                        animation-duration: 1s;
                        animation-delay: 1000ms;
                        animation-fill-mode: forwards;
                        animation-timing-function: ease-in-out;
                    }

                    @keyframes moveToLeft {
                        0% {
                            transform: translateX(0px);
                            background: linear-gradient( to right, #ff8177 0%, #ff867a 0%, #ff8c7f 21%, #f99185 52%, #cf556c 78%, #b12a5b 100% );
                        }

                        25% {
                            transform: translateX(400px);
                            background: linear-gradient(120deg, #84fab0 0%, #8fd3f4 100%);
                        }

                        50% {
                            transform: translateY(200px) translateX(400px);
                            background: linear-gradient(to top, #30cfd0 0%, #330867 100%);
                        }

                        75% {
                            transform: translateX(0px) translateY(200px);
                            background: linear-gradient(120deg, #f6d365 0%, #fda085 100%);
                        }

                        100% {
                            transform: translateY(0px);
                        }
                    }
                    /*https://www.neerajcodesolutions.com/2017/04/animation-image-using-css-in-mvc.html*/
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
                    <%--                   
                        <img id="animation2" src="https://upload.wikimedia.org/wikipedia/commons/thumb/7/70/Izidor_Papo%2C_family_photo.jpg/400px-Izidor_Papo%2C_family_photo.jpg" />
                        <img class="raver" src="https://upload.wikimedia.org/wikipedia/commons/thumb/7/70/Izidor_Papo%2C_family_photo.jpg/400px-Izidor_Papo%2C_family_photo.jpg" />
                    --%>
                    <asp:Timer ID="tmrSwitchCarousel" runat="server" OnTick="tmrSwitchCarousel_Tick" />
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
                                                        <asp:Image runat="server" ID="imgCarousel" CssClass="image fader" Style="height: 400px;" />
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
