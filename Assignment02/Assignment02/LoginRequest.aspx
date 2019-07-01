<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Request Page</title>
    <style type="text/css">

    </style>
</head>
<body>
    <form id="uxLoginForm" runat="server">
        <div>
            <asp:Label class="formLabel " ID="Label1" runat="server" Text="Name"></asp:Label><asp:TextBox class="formInputField" ID="uxName" runat="server"></asp:TextBox>
            <asp:Label class="formLabel" ID="Label2" runat="server" Text="Email Address"></asp:Label><asp:TextBox class="formInputField" ID="uxEmailAddress" runat="server"></asp:TextBox>
            <asp:Label class="formLabel" ID="Label3" runat="server" Text="Login Name"></asp:Label><asp:TextBox class="formInputField" ID="uxLoginName" runat="server"></asp:TextBox>
            <asp:Label class="formLabel" ID="Label4" runat="server" Text="Reason for access?"></asp:Label>
            <asp:TextBox class="formInputFieldArea" ID="TextBox1" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
            <asp:Button class="formSubmitButton" ID="uxSubmit" runat="server" Text="Button" />
        </div>
    </form>
</body>
</html>
