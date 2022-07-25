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
        <address>
            <table style="background-color:aliceblue">
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
                    <td style="background-color:whitesmoke">
                        <asp:Button runat="server" ID="btnSubmitMail" CssClass="gridItem button" Text="Надіслати" OnClick="btnSubmitMail_Click" />
                    </td>
                </tr>
            </table>
        </address>
    </body>
    </html>
</asp:Content>
