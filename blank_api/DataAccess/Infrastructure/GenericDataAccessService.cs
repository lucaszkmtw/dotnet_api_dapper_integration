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

namespace DataAccess.Infrastructure
{


    public class GenericDataAccessService


    {
        protected SqlBuilder Querybuilder = SqlBuilder.Instance;

        private IDbTransaction transaction; // Transaction object



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


        public void BeginTransaction(RepositoryAccess repository)
        {
            var connection = repository.GetConnection();
            connection.Open();
            transaction = connection.BeginTransaction();
        }

        public void CommitTransaction(RepositoryAccess repository)
        {
            transaction?.Commit();
            transaction?.Connection?.Close();
            transaction = null;
        }

        public void RollbackTransaction(RepositoryAccess repository)
        {
            transaction?.Rollback();
            transaction?.Connection?.Close();
            transaction = null;
        }


        public IEnumerable<T> GetAll<T>(IRepositoryAccess repository) where T : class
        {
            IDbConnection con = repository.GetConnection();
            T instance = Activator.CreateInstance<T>();
            IEnumerable<T> dataEntity = con.Query<T>(Querybuilder.GetAllQuery<T>(instance));
            //repository.CloseConnection(con);
            return dataEntity.ToList();

        }



        public IEnumerable<T> GetBySearch<T>(Search search, RepositoryAccess repository)
        {
            T instance = Activator.CreateInstance<T>();
            IDbConnection con = repository.GetConnection();
            IEnumerable<T> dataEntity = con.Query<T>(Querybuilder.GetBySearchQuery<T>(search, instance));
            //repository.CloseConnection(con);
            return dataEntity.ToList();
        }

        public T GetById<T>(long Id, RepositoryAccess repository)
        {
            T instance = Activator.CreateInstance<T>();
            IDbConnection con = repository.GetConnection();
            IEnumerable<T> dataEntity = con.Query<T>(Querybuilder.GetByIdQuery<T>(Id, instance));
            //repository.CloseConnection(con);

            return dataEntity.FirstOrDefault();
        }



        public void Insert<T>(T Model, RepositoryAccess repository)
        {
            IDbConnection con = repository.GetConnection();
            if (transaction != null)
            {
                con.Execute(Querybuilder.InsertQuery<T>(Model), transaction);
            }
            else
            {
                con.Execute(Querybuilder.InsertQuery<T>(Model));

            }
            //repository.CloseConnection(con);
        }


        public void Update<T>(T Model, RepositoryAccess repository)
        {
            IDbConnection con = repository.GetConnection();
            T instance = Activator.CreateInstance<T>();
            if (transaction != null)
            {
                con.Execute(Querybuilder.UpdateQuery<T>(Model), transaction);

            }
            else
            {
                con.Execute(Querybuilder.UpdateQuery<T>(Model));
            }
            //repository.CloseConnection(con);
        }
        public void Delete<T>(long id, RepositoryAccess repository)
        {
            IDbConnection con = repository.GetConnection();
            T instance = Activator.CreateInstance<T>();
            con.Execute(Querybuilder.DeleteQuery<T>(id, instance));
            if (transaction != null)
            {
                con.Execute(Querybuilder.DeleteQuery<T>(id, instance), transaction);
            }
            else
            {
                con.Execute(Querybuilder.DeleteQuery<T>(id, instance), transaction);
            }

            //repository.CloseConnection(con);
        }

        public DateTime GetCurrentDate(RepositoryAccess repository)
        {
            IDbConnection con = repository.GetConnection();
            DateTime date = con.QuerySingle<DateTime>(Querybuilder.CurrentDateTimeQuery());
            //repository.CloseConnection(con);

            return date;
        }

        public IEnumerable<T> CustomQuery<T>(string query, RepositoryAccess repository)
        {
            IDbConnection con = repository.GetConnection();
            IEnumerable<T> data = con.Query<T>(query);
            //repository.CloseConnection(con);

            return data;
        }
        public object FunctionSql(string query, RepositoryAccess repository)
        {
            IDbConnection con = repository.GetConnection();
            var data = con.QuerySingle<string>(query);
            //repository.CloseConnection(con);

            return data;
        }
        public void sqlProdcedure(string query,string parametro, RepositoryAccess repository)
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
