using Dapper;
using DataAccess.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Infrastructure
{
    public class RepositoryAccess : IRepositoryAccess
    {
        private readonly IConfiguration _configuration;
        private Lazy<NpgsqlConnection> _connection;

        public RepositoryAccess(IConfiguration config)
        {
            _configuration = config;
            _connection = new Lazy<NpgsqlConnection>(CreateConnection);
        }

        private NpgsqlConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("PostgresConnection");
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public NpgsqlConnection GetConnection()
        {
            return _connection.Value;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("PostgresConnection");
        }
        public void CloseConnection(NpgsqlConnection connection)
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public NpgsqlConnection GetActiveSession()
        {
            return _connection.Value;
        }
        public IDbTransaction BeginTransacction()
        {
            return _connection.Value.BeginTransaction();
        }
    }
}