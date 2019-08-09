<%@ Page Title="About" Language="C#" MasterPageFile="~/Assignment04.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <h1>About Page</h1>
    <p>Incremental assignment to explore the creation of ASP.Net applications</p>
    <h2>Staff Members</h2>
    <h3>Bob</h3>
    <asp:Image ID="uxBob" runat="server" ImageUrl="~/resources/spongebob.jpeg" Height="200px" />
    <h3>Gary</h3>
    <asp:Image ID="uxGary" runat="server" ImageUrl="~/resources/Gary.png"  Height="200px"/>
</asp:Content>