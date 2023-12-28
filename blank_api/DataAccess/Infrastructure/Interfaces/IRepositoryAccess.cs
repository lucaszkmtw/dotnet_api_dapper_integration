using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Interfaces
{
    public interface IRepositoryAccess
    {

        IDbTransaction BeginTransacction();
        SqlConnection GetConnection();
        void CloseConnection(SqlConnection conn);
        string GetConnectionString();

    }
}
