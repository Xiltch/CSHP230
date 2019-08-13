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
            throw new NotImplementedException();
        }

        public IEnumerable<IClass> RegisterForClass(int classId, int studentId)
        {
            throw new NotImplementedException();
        }
    }
}