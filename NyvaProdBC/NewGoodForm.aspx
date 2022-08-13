<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewGoodForm.aspx.cs" Inherits="NyvaProdBC.NewGoodForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="tbCategory" placeholder="Ключ категорії" />
            <asp:TextBox runat="server" ID="tbProductName" placeholder="Назва продукту" />
            <asp:TextBox runat="server" ID="tbBrand" placeholder="Бренд" />
            <asp:TextBox runat="server" ID="tbSupplier" placeholder="Постачальник" />
            <asp:TextBox runat="server" ID="tbERDPOU" placeholder="ЄРДПОУ" />
            <asp:TextBox runat="server" ID="tbPrice" placeholder="Ціна" />
            <asp:TextBox runat="server" ID="tbMaxPrice" placeholder="Максимальна ціна за одиницю" />
            <asp:TextBox runat="server" ID="tbMinOrder" placeholder="Мінімальна ціна замовлення" />
            <asp:TextBox runat="server" ID="tbDeliveryDistrict" placeholder="Область доставки" />
            <asp:TextBox runat="server" ID="tbDeliveryCity" placeholder="Місто доставки" />
            <asp:Button runat="server" ID="btnSubmitNew" OnClick="btnSubmitNew_Click" />
        </div>
    </form>
</body>
</html>
