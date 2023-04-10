using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Interfaces
{
    public interface IRepositoryAccess
    {

        OracleConnection GetConnection();
        void CloseConnection(OracleConnection conn);

    }
}
