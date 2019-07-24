<%@ Page Title="Request Login" Language="C#" MasterPageFile="~/Assignment05.Master" %>

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
                                    Initial Catalog=Master";

                connectionString = @"Provider=SQLOLEDB;
                                    Data Source=twinkies\SQLExpress;
                                    Persist Security Info=True;
                                    User ID=cshp230;
                                    Password=1303393";

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
    <script type="text/javascript">
        $(document).ready(function () {

            var hasName = false;
            var hasEmail = false;
            var hasLogin = false;
            var hasReason = false;

            $("#<%=uxName.ClientID%>").on("change paste keyup", function () {
                hasName = $(this).val() !== "";
                toggleSubmitButton();
            });

            $("#<%=uxEmailAddress.ClientID%>").on("change paste keyup", function () {
                hasEmail = $(this).val() !== "";
                toggleSubmitButton();
            });

            $("#<%=uxLoginName.ClientID%>").on("change paste keyup", function () {
                hasLogin = $(this).val() !== "";
                toggleSubmitButton();
            });

            $("#<%=uxReason.ClientID%>").on("change paste keyup", function () {
                hasReason = $(this).val() !== "";
                toggleSubmitButton();
            });

            function toggleSubmitButton() {
                var isEnabled = hasName && hasEmail && hasLogin && hasReason;
                $("#<%=uxSubmit.ClientID%>").prop('disabled', !isEnabled);
            }
        });

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <h1>Request new login</h1>
    <form style="width: 400px; margin: 10px;" id="uxLoginForm" runat="server">
        <div class="form-group">
            <label for="<%=uxName%>">Name</label>
            <asp:TextBox CssClass="form-control" ID="uxName" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="<%=uxEmailAddress%>">Email Address</label>
            <asp:TextBox CssClass="form-control" ID="uxEmailAddress" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="<%=uxLoginName%>">Login Name</label>
            <asp:TextBox CssClass="form-control" ID="uxLoginName" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="<%=uxReason%>">Reason for access?</label>
            <asp:TextBox CssClass="form-control" ID="uxReason" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button CssClass="btn btn-primary" ID="uxSubmit" runat="server" Text="Submit" OnClick="uxSubmit_Click" Enabled="False" />
        </div>

        <div class="formFeedback">
            <asp:Label ID="uxFormFeedback" runat="server" Text="" Visible="False"></asp:Label>
        </div>
    </form>
</asp:Content>
