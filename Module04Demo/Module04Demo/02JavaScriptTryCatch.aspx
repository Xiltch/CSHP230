<%@ Page Title="02JavaScriptTryCatch" Language="C#" MasterPageFile="~/Module04WebSite.Master" %>

<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Msg = @"Server Side Changes overwrite any Client Side Changes!
                     So all you see is a flash and this message.
                    <p><b> 
                    Note: Use the Browser's debugging tools to test the page!
                    As we will see in the next section!<b></p>";
        Label2.Text = Msg;
    }

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ClientCodeButton_Click() {
            debugger; //This works like a breakpoint in the browser's development tools!
            try {
                //NOTE: ASP.NET dynamically creates a client side name for ASP.NET controls.
                document.getElementById("Label2").innerHTML = "test"; //But, this ain't it!
            }
            catch (e) {
                //Here is what the proper name will be.
                document.getElementById("ContentPlaceHolder1_Label2").innerHTML = e.message;
            }
            alert("Pause before trip to the server!\n(Note how the label changes back after the PostBack)");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button"
            OnClientClick="ClientCodeButton_Click()" OnClick="Button1_Click"></asp:Button>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

    </div>
</asp:Content>
