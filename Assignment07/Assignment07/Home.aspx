<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Assignment07.Master" AutoEventWireup="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StudentID"] != null)
            {
                var StudentId = (int)Session["StudentID"];

                uxLogin.Text = $"You have been logged in with Student Id {StudentId}";
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <h1>Course Portal</h1>
    <form id="form1" runat="server">
        <asp:Label runat="server" ID="uxLogin"></asp:Label>
    </form>
</asp:Content>
