<%@ Page Title="Hidden Input" Language="C#" MasterPageFile="~/Assignment06.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script runat="server">
        protected void Page_Load()
        {
            int count = 0;

            if (IsPostBack)
            {
                count = int.Parse(HiddenFieldCounter.Value);
                Label1.Text = $"Times Clicked: {count}";
            }
            else
            {
                HiddenFieldCounter.Value = "0";
                Label1.Text = $"Waiting to send data";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int count = int.Parse(HiddenFieldCounter.Value);

            Label1.Text = $"Times Clicked: {count}";
        }

    </script>
    <script type="text/javascript">

        function IncreaseCounter_Click() {

            var obj = document.getElementById("<%=HiddenFieldCounter.ClientID%>");

            if (obj != "") {
                var strData = obj.value;
                strData++;
                obj.value = strData;
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <h2>Demonestration of Hidden Input</h2>
    <p>
        This pages demonstrates how the number of clicks can be tracked on the client and sent to the server using hidden input fields.
    </p>
    <p>
        The client button updates a hidden input field which temporarily holds a value that the server can
        read when the page is posted to it. This information can then be acted on, in this case a label is
        updated to show how many times the client button has been clicked.
    </p>
    <form runat="server">
        <asp:HiddenField ID="HiddenFieldCounter" runat="server" />
        <asp:Button ID="Button2" runat="server" Text="(Client) Click Count"
            OnClientClick="IncreaseCounter_Click(); return false;" UseSubmitBehavior="False" />
        <asp:Button ID="Button1" runat="server" Text="(Server) Send Data" AutoPostBack="false" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Nothing Yet"></asp:Label>

    </form>
</asp:Content>
