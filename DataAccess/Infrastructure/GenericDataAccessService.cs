using Dapper;
using DataAccess.Helpers;
using DataAccess.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
  
    public class GenericDataAccessService
         

    {
        protected SqlBuilder Querybuilder = SqlBuilder.Instance;

        private RepositoryAccess repository = new RepositoryAccess("Data Source=10.50.90.117:1521/DESA2; User Id=rcf; Password=rcfteso2; Min Pool Size=10; Connection Lifetime = 120; Connection Timeout = 5; Incr Pool Size=5; Decr Pool Size=2;");
        private IDbTransaction transaction; // Transaction object



        public void BeginTransaction()
        {
            var connection = repository.GetConnection();
            connection.Open();
            transaction = connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            transaction?.Commit();
            transaction?.Connection?.Close();
            transaction = null;
        }

        public void RollbackTransaction()
        {
            transaction?.Rollback();
            transaction?.Connection?.Close();
            transaction = null;
        }


        public IEnumerable<T> GetAll<T>() where T : class {
           IDbConnection con = repository.GetConnection();
            T instance = Activator.CreateInstance<T>();
            IEnumerable<T> dataEntity = con.Query<T>(Querybuilder.GetAllQuery<T>(instance));
            //repository.CloseConnection(con);
            return dataEntity.ToList();

        }



        public IEnumerable<T> GetBySearch<T>(Search search)
        {
            T instance = Activator.CreateInstance<T>();
            IDbConnection con = repository.GetConnection();
            IEnumerable<T> dataEntity = con.Query<T>(Querybuilder.GetBySearchQuery<T>(search, instance));
            //repository.CloseConnection(con);
            return dataEntity.ToList();
        }

        public T GetById<T>(long Id)
        {
            T instance = Activator.CreateInstance<T>();
            IDbConnection con = repository.GetConnection();
            IEnumerable<T> dataEntity = con.Query<T>(Querybuilder.GetByIdQuery<T>(Id, instance));
            //repository.CloseConnection(con);

            return dataEntity.FirstOrDefault();
        }



        public void Insert<T>(T Model)
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


        public void Update<T>(T Model)
        {
            IDbConnection con = repository.GetConnection();
            T instance = Activator.CreateInstance<T>();
            if(transaction!= null)
            { 
            con.Execute(Querybuilder.UpdateQuery<T>(Model),transaction);

            }
            else
            {
                con.Execute(Querybuilder.UpdateQuery<T>(Model));
            }
            //repository.CloseConnection(con);
        }
        public void Delete<T>(long id)
        {
            IDbConnection con = repository.GetConnection();
            T instance = Activator.CreateInstance<T>();
            con.Execute(Querybuilder.DeleteQuery<T>(id, instance));
            if (transaction != null)
            {
                con.Execute(Querybuilder.DeleteQuery<T>(id,instance),transaction);
            }
            else
            {
                con.Execute(Querybuilder.DeleteQuery<T>(id,instance),transaction);
            }

            //repository.CloseConnection(con);
        }

        public T GetCurrentDate<T>()
        {
            IDbConnection con = repository.GetConnection();
            T date = con.QueryFirst<T>(Querybuilder.CurrentDateTimeQuery());
            //repository.CloseConnection(con);

            return date;
        }

        public IEnumerable<T> CustomQuery<T>(string query)
        {
            IDbConnection con = repository.GetConnection();
            IEnumerable<T> data = con.Query<T>(query);
            //repository.CloseConnection(con);

            return data;
        }


    }
}
