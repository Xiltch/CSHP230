<%@ Page Title="" Language="C#" MasterPageFile="~/Assignment06.Master" AutoEventWireup="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script runat="server">

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FooBar"] == null) //if no session variable...
            { Response.Redirect("SessionSet.aspx"); } //..go back to the first page!
            else
            {
                this.Label1.Text = Session["FooBar"].ToString();
                Session.Clear();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();//This deletes the session variable from the server
            Response.Redirect("SessionSet.aspx");
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <h2>Demonstration of Sessions</h2>
    <p>Showing the session value set on the other page:</p>
    <form runat="server">
        <asp:Label ID="Label1" runat="server" Text="No Value"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Try Again" AutoPostBack="false" OnClick="Button1_Click" />
    </form>
</asp:Content>
