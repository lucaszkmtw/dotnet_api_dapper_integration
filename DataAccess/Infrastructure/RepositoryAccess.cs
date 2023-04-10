using Dapper;
using DataAccess.Infrastructure.Interfaces;
using DataAccess.Mapping;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace DataAccess.Infrastructure
{


    public class RepositoryAccess : IRepositoryAccess
    {
        public RepositoryAccess(string connectionString)
        {
            _connectionString = connectionString;

        }

        public OracleConnection _session  = new OracleConnection();
        private string _connectionString;


        //private static RepositoryAccess instance;

        //public new static RepositoryAccess Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new RepositoryAccess();
        //        }
        //        return instance;
        //    }
        //}


        public  OracleConnection GetConnection()
        {
           
            if (_session != null && _session.State == ConnectionState.Open)
            {
                return _session;
            }
            else
            {
                 var conn = new OracleConnection(_connectionString);
                _session = conn;
                _session.Open();
                return _session;
            }
          
        }



        public  void CloseConnection(OracleConnection conn)
        {
            if (conn.State == ConnectionState.Open || conn.State == ConnectionState.Broken)
            {
                conn.Close();
            }

        }

      
    }

}


