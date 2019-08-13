﻿using Assignment08.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Blueprints;

namespace Assignment08.DAL
{
    public class ProjectRepository : IUnitOfWork, IDisposable
    {
        private readonly string ConnectionString;

        public ProjectRepository(ConfigOption options)
        {
            this.ConnectionString = options.ConnectionStringProjectContext;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        internal int Authenticate(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("pSelLoginIdByLoginAndPassword", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var RetVal = command.Parameters.Add("RetVal", SqlDbType.Int);
                RetVal.Direction = ParameterDirection.ReturnValue;

                command.Parameters.AddWithValue("@StudentLogin", login);
                command.Parameters.AddWithValue("@StudentPassword", password);

                command.Parameters.Add("@StudentId",SqlDbType.Int);

                command.Parameters["@StudentId"].Direction = ParameterDirection.Output;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                } catch (SqlException e)
                {
                    throw new AuthenticationException($"Login Failed for {login} - {e.Message}");
                }

                var result = (int)RetVal.Value;

                if ((int)result == 100)
                {
                    return (int)command.Parameters["@StudentId"].Value;
                }
            }

            throw new AuthenticationException($"Login Failed for {login}");
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ProjectRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}