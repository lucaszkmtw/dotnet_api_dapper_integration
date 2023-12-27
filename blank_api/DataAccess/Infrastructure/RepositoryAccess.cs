using Dapper;
using DataAccess.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace DataAccess.Infrastructure
{
    public class RepositoryAccess : IRepositoryAccess
    {
        private readonly IConfiguration _configuration;
        private Lazy<OracleConnection> _connection;

        public RepositoryAccess(IConfiguration config)
        {
            _configuration = config;
            _connection = new Lazy<OracleConnection>(CreateConnection);
        }

        private OracleConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("OracleConnection");
            var connection = new OracleConnection(connectionString);
            connection.Open();
            return connection;
        }

        public OracleConnection GetConnection()
        {
            return _connection.Value;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("OracleConnection");
        }
        public void CloseConnection(OracleConnection connection)
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public OracleConnection GetActiveSession()
        {
            return _connection.Value;
        }
    }
}