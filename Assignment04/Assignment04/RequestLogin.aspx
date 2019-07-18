<%@ Page Title="Request Login" Language="C#" MasterPageFile="~/Assignment04.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script runat="server">

        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            string userName = uxName.Text;
            string email = uxEmailAddress.Text;
            string login = uxLoginName.Text;
            string reason = uxReason.Text;

            switch (saveRequest(userName, email, login, reason))
            {
                case 0:
                    showFeedback("There was problem completing the request, please check your details and try again");
                    break;

                case 1:
                    showFeedback("A Password will be sent to you once a staff member has manually gone over your request");
                    resetForm();
                    break;

                case -1:
                    // something went wrong
                    break;

            }
        }

        private int saveRequest(string userName, string email, string login, string reason)
        {
            System.Data.OleDb.OleDbConnection sqlConnection = new System.Data.OleDb.OleDbConnection();
            System.Data.OleDb.OleDbCommand sqlCommand = null;
            try
            {   //1. Make a Connection
                string connectionString = @"Provider=SQLOLEDB;
                                    Data Source=.\SQLExpress;
                                    Integrated Security=SSPI;
                                    Initial Catalog=ASPNetHomework";

                sqlConnection.ConnectionString = connectionString;
                sqlConnection.Open();

                //2. Issue a Command
                sqlCommand = new System.Data.OleDb.OleDbCommand("dbo.pInsLogins", sqlConnection);

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Name", userName);
                sqlCommand.Parameters.AddWithValue("@EmailAddress", email);
                sqlCommand.Parameters.AddWithValue("@LoginName", login);
                sqlCommand.Parameters.AddWithValue("@ReasonForAccess", reason);

                var result = sqlCommand.ExecuteNonQuery();

                return result;

            }
            catch (Exception ex)
            {
                showFeedback(ex.Message);
                return -1;
            }
            finally { sqlConnection.Close(); } //4. Run clean up code

        }

        private void resetForm()
        {
            uxName.Text = "";
            uxEmailAddress.Text = "";
            uxLoginName.Text = "";
            uxReason.Text = "";
        }

        private void showFeedback(string message)
        {
            uxFormFeedback.Text = message;
            uxFormFeedback.Visible = true;
        }

    </script>

    <style type="text/css">
        .form {
            width: 580px;
        }

        .fieldRow {
            float: left;
            clear: both;
            margin: 5px 0px 5px 0px;
        }

        .formFields {
            float: left;
        }

        .formActions {
            margin: 8px 0 8px 0;
            float: left;
            clear: both;
        }

        .formSubmitButton {
            width: 100px;
            border-radius: 8px;
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
            width: 380px;
            float: left;
        }

        .formInputFieldArea {
            width: 530px;
            float: left;
            clear: both;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <h1>Request new login</h1>
    <form class="form" id="uxLoginForm" runat="server">
        <div class="formFields">
            <div class="fieldRow">
                <asp:Label class="formLabel " ID="Label1" runat="server" Text="Name"></asp:Label>
                <asp:TextBox class="formInputField" ID="uxName" runat="server"></asp:TextBox>
            </div>
            <div class="fieldRow">
                <asp:Label class="formLabel" ID="Label2" runat="server" Text="Email Address"></asp:Label>
                <asp:TextBox class="formInputField" ID="uxEmailAddress" runat="server"></asp:TextBox>
            </div>
            <div class="fieldRow">
                <asp:Label class="formLabel" ID="Label3" runat="server" Text="Login Name"></asp:Label>
                <asp:TextBox class="formInputField" ID="uxLoginName" runat="server"></asp:TextBox>
            </div>
            <div class="fieldRow">
                <asp:Label class="formLabel" ID="Label4" runat="server" Text="Reason for access?"></asp:Label>
            </div>
            <div class="fieldRow">
                <asp:TextBox class="formInputFieldArea" ID="uxReason" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
            </div>
        </div>
        <div class="formActions">
            <asp:Button class="formSubmitButton" ID="uxSubmit" runat="server" Text="Submit" OnClick="uxSubmit_Click" />
        </div>
        <div class="formFeedback">
            <asp:Label ID="uxFormFeedback" runat="server" Text="" Visible="False"></asp:Label>
        </div>
    </form>
</asp:Content>
