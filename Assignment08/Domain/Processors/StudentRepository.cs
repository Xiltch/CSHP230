using Assignment08.Domain.Entities;
using Assignment08.Domain.Exceptions;
using Assignment08.Domain.Interfaces;
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
                    var student = new Student()
                    {
                        Id = (int)command.Parameters["@StudentId"].Value,
                        Login = login
                    };
                    return student;
                }
            }

            throw new AuthenticationException($"Login Failed for {login}");
        }
    }
}
