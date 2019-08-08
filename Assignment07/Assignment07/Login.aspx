<%@ Page Title="" Language="C#" MasterPageFile="~/Assignment07.Master" AutoEventWireup="true" %>

<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script runat="server">

        protected void uxRequestLogin_Click(object sender, EventArgs e)
        {

        }

        protected void uxLogin_Click(object sender, EventArgs e)
        {
            string login = uxLogin.Text;
            string password = uxPassword.Text;

            switch (serverLogin(login, password))
            {
                case 0:
                    showFeedback("There was problem completing the request, please check your details and try again");
                    break;

                case 1:
                    // Success
                    Response.Redirect("Home.aspx");
                    break;

                case -1:
                    // something went wrong
                    break;

            }
        }

        private int serverLogin(string login, string password)
        {

            System.Data.OleDb.OleDbConnection sqlConnection = new System.Data.OleDb.OleDbConnection();
            System.Data.OleDb.OleDbCommand sqlCommand = null;
            try
            {   //1. Make a Connection

                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ischool"].ConnectionString;

                sqlConnection.Open();

                //2. Issue a Command
                sqlCommand = new System.Data.OleDb.OleDbCommand("pSelLoginIdByLoginAndPassword", sqlConnection);

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                OleDbParameter RetVal = sqlCommand.Parameters.Add("RetVal", OleDbType.Integer);
                RetVal.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.AddWithValue("@StudentLogin", login);
                sqlCommand.Parameters.AddWithValue("@StudentPassword", password);

                sqlCommand.Parameters.Add("@StudentId", System.Data.OleDb.OleDbType.Integer);
                sqlCommand.Parameters["@StudentId"].Direction = ParameterDirection.Output;

                sqlCommand.ExecuteNonQuery();

                var result = (int)RetVal.Value;

                if ((int)result == 100)
                {
                    Session["StudentID"] = (int)sqlCommand.Parameters["@StudentId"].Value;
                    return 1;
                }

                return 0;

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
            uxLogin.Text = "";
            uxPassword.Text = "";
        }

        private void showFeedback(string message)
        {
            uxFormFeedback.Text = message;
            uxFormFeedback.Visible = true;
        }

    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            var hasLogin = false;
            var hasPassword = false;

            $("#<%=uxLogin.ClientID%>").on("change paste keyup", function () {
                hasLogin = $(this).val() !== "";
                toggleSubmitButton();
            });

            $("#<%=uxPassword.ClientID%>").on("change paste keyup", function () {
                hasPassword = $(this).val() !== "";
                toggleSubmitButton();
            });

            function toggleSubmitButton() {
                var isEnabled = hasLogin && hasPassword;
                $("#<%=uxSubmit.ClientID%>").prop('disabled', !isEnabled);
            }
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <h2>Please login using the textboxes below:</h2>
    <form style="width: 400px; margin: 10px;" id="uxLoginForm" runat="server">
        <div class="form-group">
            <label for="<%=uxLogin%>">Student login</label>
            <asp:TextBox CssClass="form-control" ID="uxLogin" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="<%=uxPassword%>">Student Password</label>
            <asp:TextBox CssClass="form-control" ID="uxPassword" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button CssClass="btn btn-primary" ID="uxSubmit" runat="server" Text="Login" OnClick="uxLogin_Click" Enabled="False" />
            <asp:Button CssClass="btn btn-primary" ID="uxRequestLogin" runat="server" Text="Request Login" OnClick="uxRequestLogin_Click" Enabled="False" />
        </div>
        <div class="formFeedback">
            <asp:Label ID="uxFormFeedback" runat="server" Text="" Visible="False"></asp:Label>
        </div>
    </form>
</asp:Content>
