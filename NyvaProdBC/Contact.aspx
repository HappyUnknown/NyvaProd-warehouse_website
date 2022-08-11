<%@ Page Title="Зв'язок" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="NyvaProdBC.Contact" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title><%: Title %></title>
        <link rel="stylesheet" type="text/css" href="Styles/ContactStyles.css" />
    </head>
    <body>
        <h2><%: Title %>.</h2>
        <br />
        <div class="container">
            <h3>Контактні номери
            </h3>
            <p>
                Директор, Данченков Олександр Якович: <a href="”tel:+380673640488”">+38-(067)-364-04-88</a>
            </p>
        </div>
        <br />
        <div class="container">
            <h3>Лист електронною поштою</h3>
            <p>Наша адреса: <strong><a href="mailto:novaprod@gmail.com">novaprod@gmail.com</a></strong></p>
            <address>
                <table style="background-color: aliceblue">
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblUserEmail" CssClass="gridItem" Text="Ваш E-Mail" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbUserEmail" CssClass="gridItem entryNeutral" placeholder="приклад@пошти.ua" />
                        </td>
                    </tr>
                    <tr>
                        <td class="wraper">
                            <asp:Label runat="server" ID="lblMailText" CssClass="gridItem gridLableDiv" Text="Повідомлення" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbMailText" CssClass="gridItem entryNeutral" placeholder="Текст, що буде надіслано керівнику..." TextMode="multiline" />
                        </td>
                    </tr>
                    <tr>
                        <td />
                        <td style="background-color: whitesmoke">
                            <%if (!MailSent)
                                {
                            %>
                            <asp:Button runat="server" ID="btnSubmitMail" CssClass="gridItem button" Text="Надіслати" OnClick="btnSubmitMail_Click" />
                            <%
                                }
                                else
                                {
                            %>
                            <asp:Label runat="server" ID="lblMsg" Visible="false" />
                            <%
                                }
                            %>
                        </td>
                    </tr>
                </table>
            </address>
        </div>
        <br />
        <div class="container">
            <h3>Наш офіс</h3>
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1571.8339942944756!2d26.25358313182976!3d50.61925582730251!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x472f13526adf0e1d%3A0x5da79950d4f88f9e!2z0J_QsNC80Y_RgtC90LjQuiDQotCw0YDQsNGB0YMg0KjQtdCy0YfQtdC90LrQvg!5e0!3m2!1sru!2sua!4v1659204381319!5m2!1sru!2sua" width="600" height="450" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        </div>
    </body>
    </html>
</asp:Content>
