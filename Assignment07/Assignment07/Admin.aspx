<%@ Page Title="Adminstration" Language="C#" MasterPageFile="~/Assignment07.Master" AutoEventWireup="true" %>

<%@ Import Namespace="Assignment07" %>
<%@ Import Namespace="Assignment07.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script runat="server">

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StudentID"] == null) //if no session variable...
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                var StudentId = (int)Session["StudentID"];

                if (StudentId != 0) // Working on the assumption that Student ID "0" is the admin, would rather use a call to confirm admin rights by the server
                    Response.Redirect("AccessDenied.aspx");
            }

            var context = new SchoolRepository();

            // TODO check if admin logged in, if not access denied

            var classes = context.GetClasses();
            var students = context.GetStudents();
            var requests = context.GetLoginRequests();

            context.MapClassesStudent(classes, students);

            renderClassesTable(classes);
            renderClasssesStudentsTable(classes);
            renderStudentsTable(students);
            renderLoginRequestsTable(requests);

        }

        private void renderClassesTable(IEnumerable<Class> classes)
        {
            var headerRow = new TableRow();
            headerRow.TableSection = TableRowSection.TableHeader;
            headerRow.CssClass = "thead-light";

            headerRow.Cells.Add(new TableHeaderCell() { Text = "ClassID" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "ClassName" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "ClassDate" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "ClassDescription" });

            uxClasses.Rows.Add(headerRow);

            foreach (var value in classes)
            {
                var newRow = new TableRow();
                newRow.TableSection = TableRowSection.TableBody;

                newRow.Cells.Add(new TableCell() { Text = value.ID.ToString() });
                newRow.Cells.Add(new TableCell() { Text = value.Name });
                newRow.Cells.Add(new TableCell() { Text = value.Date.ToString() });
                newRow.Cells.Add(new TableCell() { Text = value.Description.ToString() });

                uxClasses.Rows.Add(newRow);
            }
        }

        private void renderStudentsTable(IEnumerable<Student> students)
        {
            var headerRow = new TableRow();
            headerRow.TableSection = TableRowSection.TableHeader;
            headerRow.CssClass = "thead-light";

            headerRow.Cells.Add(new TableHeaderCell() { Text = "StudentId" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "StudentName" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "StudentEmail" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "StudentLogin" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "StudentPassword" });

            uxStudents.Rows.Add(headerRow);

            foreach (var value in students)
            {
                var newRow = new TableRow();
                newRow.TableSection = TableRowSection.TableBody;

                newRow.Cells.Add(new TableCell() { Text = value.ID.ToString() });
                newRow.Cells.Add(new TableCell() { Text = value.Name });
                newRow.Cells.Add(new TableCell() { Text = value.Email });
                newRow.Cells.Add(new TableCell() { Text = value.Login });
                newRow.Cells.Add(new TableCell() { Text = value.Password });

                uxStudents.Rows.Add(newRow);
            }
        }

        private void renderClasssesStudentsTable(IEnumerable<Class> classes)
        {
            var headerRow = new TableRow();
            headerRow.TableSection = TableRowSection.TableHeader;
            headerRow.CssClass = "thead-light";

            headerRow.Cells.Add(new TableHeaderCell() { Text = "ClassId" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "StudentId" });

            uxClassesStudents.Rows.Add(headerRow);

            foreach (var vClass in classes)
            {
                foreach (var vStudent in vClass.Students)
                {
                    var newRow = new TableRow();
                    newRow.TableSection = TableRowSection.TableBody;

                    newRow.Cells.Add(new TableCell() { Text = vClass.ID.ToString() });
                    newRow.Cells.Add(new TableCell() { Text = vStudent.ID.ToString() });

                    uxClassesStudents.Rows.Add(newRow);
                }
            }
        }


        private void renderLoginRequestsTable(IEnumerable<Request> requests)
        {
            var headerRow = new TableRow();
            headerRow.TableSection = TableRowSection.TableHeader;
            headerRow.CssClass = "thead-light";

            headerRow.Cells.Add(new TableHeaderCell() { Text = "LogId" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "Name" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "EmailAddress" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "LoginName" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "NewOrReactive" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "ReasonForAccess" });
            headerRow.Cells.Add(new TableHeaderCell() { Text = "DateRequiredBy" });

            uxLoginRequests.Rows.Add(headerRow);

            foreach (var value in requests)
            {
                var newRow = new TableRow();
                newRow.TableSection = TableRowSection.TableBody;

                newRow.Cells.Add(new TableCell() { Text = value.ID.ToString() });
                newRow.Cells.Add(new TableCell() { Text = value.Name });
                newRow.Cells.Add(new TableCell() { Text = value.Email });
                newRow.Cells.Add(new TableCell() { Text = value.Login });
                newRow.Cells.Add(new TableCell() { Text = value.Type });
                newRow.Cells.Add(new TableCell() { Text = value.Reason });
                newRow.Cells.Add(new TableCell() { Text = value.RequiredBy.ToString() });

                uxLoginRequests.Rows.Add(newRow);
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <h3>Use this page to review the contents of the database:</h3>
    <form id="form1" runat="server">
        <p>Classes Table</p>
        <asp:Table CssClass="table table-striped" ID="uxClasses" runat="server">
        </asp:Table>

        <p>Class Students Table</p>
        <asp:Table CssClass="table table-striped" ID="uxClassesStudents" runat="server">
        </asp:Table>

        <p>Students Table</p>
        <asp:Table CssClass="table table-striped" ID="uxStudents" runat="server">
        </asp:Table>

        <p>Login Request Table</p>
        <asp:Table CssClass="table table-striped" ID="uxLoginRequests" runat="server">
        </asp:Table>
    </form>

</asp:Content>
