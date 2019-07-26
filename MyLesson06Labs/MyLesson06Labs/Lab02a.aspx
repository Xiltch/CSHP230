<%@ Page Title="" Language="C#" MasterPageFile="~/LabSite.Master" AutoEventWireup="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script runat="server">

        protected void Button1_Click(object sender, EventArgs e)
        {
            MyLesson06Labs.App_Code.Person objP;
            objP = new MyLesson06Labs.App_Code.Person(uxFirstName.Text, uxLastName.Text);
            Session["objP"] = objP;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["objP"] != null) //if no session variable...
            {
                MyLesson06Labs.App_Code.Person objP;
                objP = ((MyLesson06Labs.App_Code.Person)Session["objP"]);
                Response.Write(string.Format("{0}, {1}", objP.FirstName, objP.LastName) + "<hr/>");
            }

        }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="FirstName:"></asp:Label>
    <asp:TextBox ID="uxFirstName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="LastName:"></asp:Label>
    <asp:TextBox ID="uxLastName" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>
