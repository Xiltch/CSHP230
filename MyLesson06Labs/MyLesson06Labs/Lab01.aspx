<%@ Page Title="" Language="C#" MasterPageFile="~/LabSite.Master" AutoEventWireup="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script runat="server">

        class Person
        {
            public string FirstName;
            public string LastName;

            public Person(string FirstName, string LastName)
            {
                this.FirstName = FirstName;
                this.LastName = LastName;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Person bob = new Person("Bob", "Smith");

            Response.Write(string.Format("{0}, {1}", bob.FirstName, bob.LastName) + "<hr/>");

            //ASP.NET way of sending text data    
            Label1.Text = string.Format("{0}, {1}", bob.FirstName, bob.LastName);
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

</asp:Content>
