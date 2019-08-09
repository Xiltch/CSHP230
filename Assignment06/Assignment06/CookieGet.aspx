<%@ Page Title="" Language="C#" MasterPageFile="~/Assignment06.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script runat="server">

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["Assignment06"];
            if (myCookie != null)
            {
                //Cookie variables are stored as strings.
                HttpCookie arrOfCookieData = Request.Cookies["Assignment06"];
                Label1.Text = arrOfCookieData["CookieTest"];
            }
            else
            {
                Label1.Text = "<p/>" + "No Cookie found!";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cookieset.aspx");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <h2>Demonstration of Cookies</h2>
    <p>Showing the cookies value set on the other page, value expires after 10 seconds:</p>
    <form runat="server">
        <asp:Label ID="Label1" runat="server" Text="No Value"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Try Again" AutoPostBack="false" OnClick="Button1_Click" />
    </form>
</asp:Content>
