<%@ Page Language="C#" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Greeting</title>
    <script runat="server">
        void Page_Load()
        {
            serverTime.Text = DateTime.Now.ToString();
        }
    </script>
    <script type="text/javascript">
        function greet(objForm)
        {
            var userName = objForm.txtUserName.value;
            var target = document.getElementById("displayName");
            target.innerText = userName;
            document.getElementById("askName").style.display = "none";
            document.getElementById("greetName").style.display = "block";
        }
    </script>
</head>
<body>
    <h1>Hello World</h1>
    <div>
        <Span>Server Time: </span><asp:Label ID="serverTime" runat="server" />
    </div>
    <br>
    <div id="askName" >
        <form>
            <span>What is your name? </span><input type="text" name="txtUserName" />
            <input type="button" value="Submit" onClick="greet(this.form)" />
        </form>    
    </div>
    <div id="greetName" style="display: none">
        <span>Hello, </span><span id="displayName"></span>
    </div>
</body>
</html>