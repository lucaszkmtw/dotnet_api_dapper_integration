using Dapper;
using DataAccess.Helpers;
using DataAccess.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Infrastructure.Transactions;
using System.Transactions;
using DataAccess.Infrastructure.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;

namespace DataAccess.Infrastructure
{


    public class GenericDataAccessService


    {
        protected SqlBuilder Querybuilder = SqlBuilder.Instance;




        private static GenericDataAccessService instance;

        public new static GenericDataAccessService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GenericDataAccessService();
                }
                return instance;
            }
        }


        public IDbTransaction BeginTransaction(IRepositoryAccess repository)
        {

            return repository.BeginTransacction();
        }

        public void CommitTransaction(IRepositoryAccess repository)
        {
            //transaction?.Commit();
            //transaction?.Connection?.Close();
            //transaction = null;
        }

        public void RollbackTransaction(IRepositoryAccess repository)
        {
            ////transaction?.Rollback();
            ////transaction?.Connection?.Close();
            ////transaction = null;
        }


        public IEnumerable<T> GetAll<T>(IRepositoryAccess repository) where T : class
        {
            IDbConnection con = repository.GetConnection();
            T instance = Activator.CreateInstance<T>();
            IEnumerable<T> dataEntity = con.Query<T>(Querybuilder.GetAllQuery<T>(instance));
            //repository.CloseConnection(con);
            return dataEntity.ToList();

        }



        public IEnumerable<T> GetBySearch<T>(Search search, IRepositoryAccess repository)
        {
            T instance = Activator.CreateInstance<T>();
            IDbConnection con = repository.GetConnection();
            IEnumerable<T> dataEntity = con.Query<T>(Querybuilder.GetBySearchQuery<T>(search, instance));
            //repository.CloseConnection(con);
            return dataEntity.ToList();
        }

        public T GetById<T>(long Id, IRepositoryAccess repository)
        {
            T instance = Activator.CreateInstance<T>();
            IDbConnection con = repository.GetConnection();
            IEnumerable<T> dataEntity = con.Query<T>(Querybuilder.GetByIdQuery<T>(Id, instance));
            //repository.CloseConnection(con);

            return dataEntity.FirstOrDefault();
        }



        public void Insert<T>(T Model, IRepositoryAccess repository, IDbTransaction transaction = null)
        {
            IDbConnection con = repository.GetConnection();
            if (transaction != null)
            {
                con.Execute(Querybuilder.InsertQuery<T>(Model), transaction: transaction);
            }
            else
            {
                con.Execute(Querybuilder.InsertQuery<T>(Model));

            }
            //repository.CloseConnection(con);
        }


        public void Update<T>(T Model, IRepositoryAccess repository, IDbTransaction transactions = null)
        {
            IDbConnection con = repository.GetConnection();
            T instance = Activator.CreateInstance<T>();
            if (transactions != null)
            {
                con.Execute(Querybuilder.UpdateQuery<T>(Model), transactions);

            }
            else
            {
                con.Execute(Querybuilder.UpdateQuery<T>(Model));
            }
            //repository.CloseConnection(con);
        }
        public void Delete<T>(long id, IRepositoryAccess repository, IDbTransaction transactions = null)
        {
            IDbConnection con = repository.GetConnection();
            T instance = Activator.CreateInstance<T>();
            con.Execute(Querybuilder.DeleteQuery<T>(id, instance));
            if (transactions != null)
            {
                con.Execute(Querybuilder.DeleteQuery<T>(id, instance), transactions);
            }
            else
            {
                con.Execute(Querybuilder.DeleteQuery<T>(id, instance));
            }

            //repository.CloseConnection(con);
        }

        public DateTime GetCurrentDate(IRepositoryAccess repository)
        {
            IDbConnection con = repository.GetConnection();
            DateTime date = con.QuerySingle<DateTime>(Querybuilder.CurrentDateTimeQuery());
            //repository.CloseConnection(con);

            return date;
        }

        public IEnumerable<T> CustomQuery<T>(string query, IRepositoryAccess repository)
        {
            IDbConnection con = repository.GetConnection();
            IEnumerable<T> data = con.Query<T>(query);
            //repository.CloseConnection(con);

            return data;
        }
        public object FunctionSql(string query, IRepositoryAccess repository)
        {
            IDbConnection con = repository.GetConnection();
            var data = con.QuerySingle<string>(query);
            //repository.CloseConnection(con);

            return data;
        }
        public void sqlProdcedure(string query,string parametro, IRepositoryAccess repository)
        {
            using (var connection = new OracleConnection(repository.GetConnectionString())) 
            {
                connection.Open();

                using (var command = new OracleCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar el parámetro de entrada
                    command.Parameters.Add("p_id_liquidacion", OracleDbType.Int64).Value = Convert.ToInt64(parametro);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
