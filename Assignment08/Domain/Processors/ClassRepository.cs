using Assignment08.Domain.Entities;
using Assignment08.Domain.Exceptions;
using Assignment08.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Assignment08.Domain.Processors
{
    public class ClassRepository : IClassRepository
    {
        private readonly string ConnectionString;

        public ClassRepository(IConfigOption options)
        {
            this.ConnectionString = options.ConnectionStringProjectContext;
        }

        public IEnumerable<IClass> GetClasses()
        {
            // TODO need to fix issue in stored procedure only returning classes that have at least one student registered

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM vClasses", connection))
            {
                command.CommandType = System.Data.CommandType.Text;

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    var items = new List<IClass>();

                    while (reader.Read())
                    {
                        var classId = int.Parse(reader["ClassId"].ToString());

                        IClass item = new Class()
                        {
                            Id = classId,
                            Name = reader["ClassName"].ToString(),
                            Description = reader["ClassDescription"].ToString(),
                            Date = DateTime.Parse(reader["ClassDate"].ToString())
                        };

                        items.Add(item);
                    }

                    return items;
                }
                catch (SqlException e)
                {
                    throw new GeneralException($"Something went wrong - {e.Message}");
                }

            }
        }

        public IClass ClassDetails(int classId)
        {

            #region View Select Query to include Empty Classes
            string sqlQuery = @"SELECT
 C.ClassId,
 C.ClassName,
 C.ClassDate,
 C.ClassDescription,
 S.StudentId,
 S.StudentName,
 S.StudentEmail

FROM vClasses C
LEFT JOIN vClassesByStudents S ON C.ClassId = S.ClassId
WHERE C.ClassId = @ClassId";
            #endregion

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = System.Data.CommandType.Text;

                try
                {
                    command.Parameters.AddWithValue("@ClassId", classId);

                    connection.Open();
                    var reader = command.ExecuteReader();

                    IClass item = null;

                    while (reader.Read())
                    {
                        var studentId = reader["StudentId"];

                        if (item is null)
                        {
                            item = new Class()
                            {
                                Id = classId,
                                Name = reader["ClassName"].ToString(),
                                Description = reader["ClassDescription"].ToString(),
                                Date = DateTime.Parse(reader["ClassDate"].ToString())
                            };

                            item.Students = new List<IStudent>();
                        }

                        if (studentId is int)
                        {
                            var student = new Student()
                            {
                                Id = int.Parse(studentId.ToString()),
                                Name = reader["StudentName"].ToString(),
                                Email = reader["StudentEmail"].ToString()
                            };
                            ((List<IStudent>)item.Students).Add(student);
                        }
                    }

                    return item;
                }
                catch (SqlException e)
                {
                    throw new GeneralException($"Something went wrong - {e.Message}");
                }

            }
        }

        public IEnumerable<IClass> GetClasses(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("pSelClassesByStudentId", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@StudentId", studentId);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    var items = new List<IClass>();

                    while (reader.Read())
                    {
                        var item = new Class()
                        {
                            Id = int.Parse(reader["ClassId"].ToString()),
                            Name = reader["ClassName"].ToString(),
                            Description = reader["ClassDescription"].ToString(),
                            Date = DateTime.Parse(reader["ClassDate"].ToString())
                        };

                        items.Add(item);
                    }

                    return items;
                }
                catch (SqlException e)
                {
                    throw new GeneralException($"Something went wrong - {e.Message}");
                }

            }

        }

        public void RegisterForClass(int classId, int studentId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("pInsClassStudents", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var RetVal = command.Parameters.Add("RetVal", SqlDbType.Int);
                RetVal.Direction = ParameterDirection.ReturnValue;

                command.Parameters.AddWithValue("@ClassId", classId);
                command.Parameters.AddWithValue("@StudentId", studentId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw new UpdateException($"Failed to register student id {studentId} for class id {classId} - {e.Message}");
                }

            }
        }

        public void DeRegisterFromClass(int classId, int studentId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("pDelClassStudents", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var RetVal = command.Parameters.Add("RetVal", SqlDbType.Int);
                RetVal.Direction = ParameterDirection.ReturnValue;

                command.Parameters.AddWithValue("@ClassId", classId);
                command.Parameters.AddWithValue("@StudentId", studentId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw new UpdateException($"Failed to deregister student id {studentId} from class id {classId} - {e.Message}");
                }

            }
        }
    }
}