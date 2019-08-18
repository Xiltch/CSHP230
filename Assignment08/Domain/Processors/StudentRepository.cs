using Assignment08.Domain.Entities;
using Assignment08.Domain.Exceptions;
using Assignment08.Domain.Interfaces;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment08.Domain.Processors
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string ConnectionString;

        public StudentRepository(IConfigOption options)
        {
            this.ConnectionString = options.ConnectionStringProjectContext;
        }

        public IEnumerable<IStudent> AllStudents()
        {
            throw new NotImplementedException();
        }

        public IStudent Authenticate(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("pSelLoginIdByLoginAndPassword", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var RetVal = command.Parameters.Add("RetVal", SqlDbType.Int);
                RetVal.Direction = ParameterDirection.ReturnValue;

                command.Parameters.AddWithValue("@StudentLogin", login);
                command.Parameters.AddWithValue("@StudentPassword", password);

                command.Parameters.Add("@StudentId", SqlDbType.Int);

                command.Parameters["@StudentId"].Direction = ParameterDirection.Output;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw new AuthenticationException($"Login Failed for {login} - {e.Message}");
                }

                var result = (int)RetVal.Value;

                if ((int)result == 100)
                {
                    return GetStudent((int)command.Parameters["@StudentId"].Value);
                }
            }

            throw new AuthenticationException($"Login Failed for {login}");
        }

        public IStudent GetStudent(int StudentId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("SELECT [StudentId], [StudentName], [StudentEmail], [StudentLogin] FROM vStudents WHERE [StudentId] = @StudentId", connection))
            {
                command.CommandType = System.Data.CommandType.Text;

                command.Parameters.AddWithValue("@StudentId", StudentId);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student student = new Student()
                        {
                            Id = int.Parse(reader["StudentId"].ToString()),
                            Login = reader["StudentLogin"].ToString(),
                            Name = reader["StudentName"].ToString(),
                            Email = reader["StudentEmail"].ToString()
                        };

                        return student;
                    }

                }
                catch (SqlException e)
                {
                    throw new DataReadException($"Failed to read data from the server - {e.Message}");
                }

            }

            throw new StudentNotFoundException($"Did not find a record for the student id {StudentId}");
        }

        public int NewLogin(ILoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
