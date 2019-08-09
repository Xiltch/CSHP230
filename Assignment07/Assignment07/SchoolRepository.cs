using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Assignment07.Models;

namespace Assignment07
{
    public class SchoolRepository
    {

        public IEnumerable<Class> GetClasses()
        {

            System.Data.OleDb.OleDbConnection sqlConnection = new System.Data.OleDb.OleDbConnection();
            System.Data.OleDb.OleDbCommand sqlCommand = null;

            try
            {   //1. Make a Connection

                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ischool"].ConnectionString; ;
                sqlConnection.Open();

                string query = "SELECT [ClassId] , [ClassName], [ClassDate], [ClassDescription] FROM [WebDevAssignment07].[dbo].[vClasses];";

                //2. Issue a Command
                sqlCommand = new System.Data.OleDb.OleDbCommand(query, sqlConnection);

                sqlCommand.CommandType = System.Data.CommandType.Text;

                var reader = sqlCommand.ExecuteReader();

                List<Class> classes = new List<Class>();

                while (reader.Read() == true)
                {
                    classes.Add(new Class()
                    {
                        ID = int.Parse(reader["ClassId"].ToString()),
                        Name = reader["ClassName"].ToString(),
                        Description = reader["ClassDescription"].ToString(),
                        Date = DateTime.Parse(reader["ClassDate"].ToString())
                    });
                }

                return classes;

            }
            catch (Exception ex)
            {
                // Should log error through logging framework
                return null;
            }
            finally { sqlConnection.Close(); } //4. Run clean up code

        }

        public IEnumerable<Student> GetStudents()
        {

            System.Data.OleDb.OleDbConnection sqlConnection = new System.Data.OleDb.OleDbConnection();
            System.Data.OleDb.OleDbCommand sqlCommand = null;

            try
            {   //1. Make a Connection

                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ischool"].ConnectionString;
                sqlConnection.Open();

                string query = "SELECT [StudentId], [StudentName], [StudentEmail], [StudentLogin], [StudentPassword] FROM [WebDevAssignment07].[dbo].[vStudents];";

                //2. Issue a Command
                sqlCommand = new System.Data.OleDb.OleDbCommand(query, sqlConnection);

                sqlCommand.CommandType = System.Data.CommandType.Text;

                var reader = sqlCommand.ExecuteReader();

                List<Student> students = new List<Student>();

                while (reader.Read() == true)
                {
                    students.Add(new Student()
                    {
                        ID = int.Parse(reader["StudentId"].ToString()),
                        Name = reader["StudentName"].ToString(),
                        Email = reader["StudentEmail"].ToString(),
                        Login = reader["StudentLogin"].ToString(),
                        Password = reader["StudentPassword"].ToString()
                    });
                }

                return students;

            }
            catch (Exception ex)
            {
                // Should log error through logging framework
                return null;
            }
            finally { sqlConnection.Close(); } //4. Run clean up code

        }


        public IEnumerable<Request> GetLoginRequests()
        {

            System.Data.OleDb.OleDbConnection sqlConnection = new System.Data.OleDb.OleDbConnection();
            System.Data.OleDb.OleDbCommand sqlCommand = null;

            try
            {   //1. Make a Connection

                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ischool"].ConnectionString;
                sqlConnection.Open();

                string query = "SELECT [LoginId], [Name], [EmailAddress], [LoginName], [NewOrReactivate], [ReasonForAccess], [DateRequiredBy] FROM [WebDevAssignment07].[dbo].[vLoginRequests];";

                //2. Issue a Command
                sqlCommand = new System.Data.OleDb.OleDbCommand(query, sqlConnection);

                sqlCommand.CommandType = System.Data.CommandType.Text;

                var reader = sqlCommand.ExecuteReader();

                List<Request> requests = new List<Request>();

                while (reader.Read() == true)
                {
                    requests.Add(new Request()
                    {
                        ID = int.Parse(reader["LoginId"].ToString()),
                        Name = reader["Name"].ToString(),
                        Email = reader["EmailAddress"].ToString(),
                        Login = reader["LoginName"].ToString(),
                        Type = reader["NewOrReactivate"].ToString(),
                        Reason = reader["ReasonForAccess"].ToString(),
                        RequiredBy = DateTime.Parse(reader["DateRequiredBy"].ToString())
                    });
                }

                return requests;

            }
            catch (Exception ex)
            {
                // Should log error through logging framework
                return null;
            }
            finally { sqlConnection.Close(); } //4. Run clean up code

        }

        public int MapClassesStudent(IEnumerable<Class> classes, IEnumerable<Student> students)
        {

            System.Data.OleDb.OleDbConnection sqlConnection = new System.Data.OleDb.OleDbConnection();
            System.Data.OleDb.OleDbCommand sqlCommand = null;

            try
            {   //1. Make a Connection

                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ischool"].ConnectionString;
                sqlConnection.Open();

                string query = "SELECT [ClassId], [StudentId] FROM [WebDevAssignment07].[dbo].[vClassStudents];";


                //2. Issue a Command
                sqlCommand = new System.Data.OleDb.OleDbCommand(query, sqlConnection);

                sqlCommand.CommandType = System.Data.CommandType.Text;

                var reader = sqlCommand.ExecuteReader();

                int mapped = 0;

                while (reader.Read() == true)
                {
                    var vClass = classes.Where(x => x.ID == int.Parse(reader["ClassID"].ToString())).FirstOrDefault();
                    var vStudent = students.Where(x => x.ID == int.Parse(reader["StudentId"].ToString())).FirstOrDefault();

                    vClass.Students.Add(vStudent);
                    vStudent.Classes.Add(vClass);

                }

                return mapped;

            }
            catch (Exception ex)
            {
                // Should log error through logging framework
                return -1;
            }
            finally { sqlConnection.Close(); } //4. Run clean up code
        }

    }
}