<%@ Page Title="Hidden Input" Language="C#" MasterPageFile="~/Assignment06.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script runat="server">

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["FooBar"] = uxInputValue.Text;
            Response.Redirect("SessionGet.aspx");
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <h2>Demonestration of Sessions</h2>
    <p>
        This pages demonstrates how the information can be tracked between pages using Sessions.
    </p>
    <p>
        It works by taking information from a form and storing it on the server in a Session. Another page is then loaded
        which reads the information from the session and displays it.
    </p>
    <form runat="server">
        <asp:Label ID="Label1" runat="server" Text="Value to Store: "></asp:Label>
        <asp:TextBox ID="uxInputValue" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Store Data" AutoPostBack="false" OnClick="Button1_Click" />
    </form>
</asp:Content>
