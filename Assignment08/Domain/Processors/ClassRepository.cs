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
            throw new NotImplementedException();
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

        public IEnumerable<IClass> RegisterForClass(int classId, int studentId)
        {
            throw new NotImplementedException();
        }
    }
}