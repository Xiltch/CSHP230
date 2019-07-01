<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Request Page</title>
    <style type="text/css">
        
        .form {
            width: 400px;
        }

        .fieldRow {
            float: left;
            margin: 5px 0px 5px 0px;
        }

        .formFields {
            float: left;
            clear: both;
        }

        .formActions {
            float: left;
            clear: both;
        }

        .formFeedback {
            float: left;
            clear: both;
        }

        .formLabel {
            width: 150px;
            float: left;
            clear: left;
        }

        .formInputField {
            width: 200px;
            float: left;
        }

        .formInputFieldArea {
            width: 100% !important;
            float: left;
            clear: both;
        }

    </style>
</head>
<body>
    <form class="form" id="uxLoginForm" runat="server">
        <div class="formFields">
            <div class="fieldRow">
                <asp:Label class="formLabel " ID="Label1" runat="server" Text="Name"></asp:Label><asp:TextBox class="formInputField" ID="uxName" runat="server"></asp:TextBox>
            </div>
            <div class="fieldRow">
                <asp:Label class="formLabel" ID="Label2" runat="server" Text="Email Address"></asp:Label><asp:TextBox class="formInputField" ID="uxEmailAddress" runat="server"></asp:TextBox>
            </div>
            <div class="fieldRow">
                <asp:Label class="formLabel" ID="Label3" runat="server" Text="Login Name"></asp:Label><asp:TextBox class="formInputField" ID="uxLoginName" runat="server"></asp:TextBox>
            </div>
            <div class="fieldRow">
                <asp:Label class="formLabel" ID="Label4" runat="server" Text="Reason for access?"></asp:Label>
            </div>
            <div class="fieldRow">
                <asp:TextBox class="formInputFieldArea" ID="TextBox1" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
            </div>
        </div>
        <div class="formActions">
            <asp:Button class="formSubmitButton" ID="uxSubmit" runat="server" Text="Button" />
        </div>
        <div class="formFeedback" id="uxFormFeedback">
            A Password will be sent to you once a staff member has manually gone over your request
        </div>
    </form>
</body>
</html>
