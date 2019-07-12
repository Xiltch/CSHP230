<%@ Page Title="01TryCatch" Language="C#" MasterPageFile="~/Module04WebSite.Master" %>
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
                                    Initial Catalog=Master";
                objOleCon.ConnectionString = strOledbConnection;
                objOleCon.Open();

                //2. Issue a Command
                objCmd.Connection = objOleCon;
                objCmd.CommandText = "Select Count(*) From Sys.Databases";
                int intOrderCount = (int)objCmd.ExecuteScalar();

                //3. Process the Results
                Label1.Text += "<b>" + intOrderCount.ToString() + "</b>";
            }
            catch (Exception ex) { Label1.Text += "<b>" + ex.ToString() + "</b>"; }
            finally { objOleCon.Close(); } //4. Run clean up code
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="ServerCodeButton" runat="server" Text="Server Code" OnClick="ServerCodeButton_Click" />
        &nbsp;<asp:Label ID="Label1" runat="server" Text="The Number of Databases is: " Style="font-size: large"></asp:Label>
    </div>
</asp:Content>