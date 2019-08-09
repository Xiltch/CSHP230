<%@ Page Title="" Language="C#" MasterPageFile="~/Demolab.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script runat="server">

        public class FooEntry
        {
            public string Name { get; set; }
            public string Age { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<FooEntry> entries = new List<FooEntry>();

            entries.Add(new FooEntry() { Name = "Tom Jones", Age = "54" });
            entries.Add(new FooEntry() { Name = "Bobby Brown", Age = "34" });
            entries.Add(new FooEntry() { Name = "Bett Boo", Age = "46" });

            renderFoobarTable(entries);
        }

        private void renderFoobarTable(List<FooEntry> values)
        {
            var headerRow = new TableRow();
            headerRow.TableSection = TableRowSection.TableHeader;
            headerRow.CssClass = "thead-light";

            headerRow.Cells.Add(new TableHeaderCell() { Text = "Name" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "Age" });

            uxFoobar.Rows.Add(headerRow);



            foreach (var value in values)
            {
                var newRow = new TableRow();
                newRow.TableSection = TableRowSection.TableBody;

                newRow.Cells.Add(new TableCell() { Text = value.Name });
                newRow.Cells.Add(new TableCell() { Text = value.Age });

                uxFoobar.Rows.Add(newRow);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <form id="form1" runat="server">
        <p>Dynamic Bootstrap Table</p>
        <asp:Table CssClass="table table-striped" ID="uxFoobar" runat="server">
        </asp:Table>
    </form>
</asp:Content>
