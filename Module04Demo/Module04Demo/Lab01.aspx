<%@ Page Title="Lab01" Language="C#" MasterPageFile="~/Module04WebSite.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script runat="server">
        protected void ServerCodeButton_Click(object sender, EventArgs e)
        {
            System.Data.OleDb.OleDbConnection objOleCon = new System.Data.OleDb.OleDbConnection();
            System.Data.OleDb.OleDbCommand objCmd = new System.Data.OleDb.OleDbCommand();
            try
            {   //1. Make a Connection
                string strOledbConnection = @"Provider=SQLOLEDB;
                                    Data Source=.\SQLExpress;
                                    Integrated Security=SSPI;
                                    Initial Catalog=ASPNetLab04Demos";
                objOleCon.ConnectionString = strOledbConnection;
                objOleCon.Open();

                //2. Issue a Command
                objCmd.Connection = objOleCon;
                objCmd.CommandText = "Select Count([LoginId]) From [SimpleLoginRequests];";
                // BAD => objCmd.CommandText = uxSQLInjectionAttack.Text; // "Select Count([LoginId]) From [SimpleLoginRequests];";
                int intLoginCount = (int)objCmd.ExecuteScalar();

                //3. Process the Results
                Label1.Text += "<b>" + intLoginCount.ToString() + "</b>";
            }
            catch (Exception ex) { Label1.Text += "<b>" + ex.ToString() + "</b>"; }
            finally { objOleCon.Close(); } //4. Run clean up code
        }
    </script>
    <script type="text/javascript">
        function ValidateTextBox() {
	     debugger;
            var objLabel1 = null;
            var objTextBox1 = "";
            var blnReturn = true;

            objLabel1 = document.getElementById("ContentPlaceHolder1_Label1");
            objLabel1.innerHTML = "";
            strText = document.getElementById("ContentPlaceHolder1_uxSQLInjectionAttack").value;

            try {
                if (strText == "") throw "The textbox cannot be Empty";
               }
            catch (ex) {
                objLabel1.innerHTML = "Input Error: " + ex.toString();
                blnReturn = false;// This will stop the Submit to the server
            }
            return blnReturn;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="ServerCodeButton" runat="server" Text="Server Code" OnClick="ServerCodeButton_Click" OnClientClick=" return ValidateTextBox()"/>
        &nbsp;<asp:Label ID="Label1" runat="server" Text="The current number of login requests is: " Style="font-size: large"></asp:Label>
        <br /><br />
        <asp:TextBox ID="uxSQLInjectionAttack" runat="server"></asp:TextBox>
    </div>
</asp:Content>