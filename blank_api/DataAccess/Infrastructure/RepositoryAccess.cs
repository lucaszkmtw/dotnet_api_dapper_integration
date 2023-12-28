using Dapper;
using DataAccess.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Infrastructure
{
    public class RepositoryAccess : IRepositoryAccess
    {
        private readonly IConfiguration _configuration;
        private Lazy<SqlConnection> _connection;

        public RepositoryAccess(IConfiguration config)
        {
            _configuration = config;
            _connection = new Lazy<SqlConnection>(CreateConnection);
        }

        private SqlConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("SQLserverConnection");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public SqlConnection GetConnection()
        {
            return _connection.Value;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("OracleConnection");
        }
        public void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public SqlConnection GetActiveSession()
        {
            return _connection.Value;
        }
    }
}