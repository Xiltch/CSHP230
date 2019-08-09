<%@ Page Title="" Language="C#" MasterPageFile="~/Assignment06.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script runat="server">

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Request.Cookies["Assignment06"] == null)
            {
                //Create a cookie object
                HttpCookie arrOfCookieData = new HttpCookie("Assignment06");

                //Configure the cookie
                //Set the Web Browser to delete the cookie in 10 seconds
                arrOfCookieData.Expires = DateTime.Now.AddSeconds(10);
                arrOfCookieData["CookieTest"] = uxInputValue.Text;

                //Send the request for a cookie to the Web Browser
                Response.Cookies.Add(arrOfCookieData);

                Label2.Text = "Cookie Set";

                Response.Redirect("CookieGet.aspx");

            }
            else
            {
                Label2.Text = "Cookie already set";
            }

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <h2>Demonstration of Cookies</h2>
    <p>
        It works by taking information from a form and storing it on the server in a cookie. Another page is then loaded
        which reads the information from the cookie and displays it.
    </p>
    <form runat="server">
        <asp:Label ID="Label1" runat="server" Text="Value to Store: "></asp:Label>
        <asp:TextBox ID="uxInputValue" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Store Data" AutoPostBack="false" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

    </form>
</asp:Content>
