<%@ Page Language="C#" AutoEventWireup="true" %>
<!DOCTYPE html>
<script runat="server">

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Response.Write(String.Format($"{txtUserName.Text} {txtPass.Text}"));
        Response.Write(String.Format($"<hr>"));
    }
</script>

<html>
<head>
    <meta charset="utf-8" />
    <title>Lab01</title>
    <style type="text/css">

        .formBox {
            margin-left: 50px;
            padding: 5px;
            width: 400px;
            border: solid;
            border-width: 1px;
            border-radius: 10px;
            background-color: grey;
        }

        .formHeader {
            margin: 5px;
            text-align: center;
        }

        .formLabel {
            width: 90px;
            display: inline-block;
        } 

        .formInput {
            width: 200px;
            margin: 5px;
        }

        #btnSubmit {
            margin: 5px;
            width: 90%;
        }

    </style>
</head>
<body>
    <form runat="server" class="formBox">
        <div class="formHeader">Please login using your name and password</div>
        <asp:Label ID="Label1" runat="server" Text="Name" CssClass="formLabel" ></asp:Label>&nbsp;<asp:TextBox ID="txtUserName" runat="server" CssClass="formInput"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Pass" CssClass="formLabel"></asp:Label>&nbsp;<asp:TextBox ID="txtPass" runat="server" CssClass="formInput"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Button" OnClick="btnSubmit_Click" />
    </form>
</body>
</html>