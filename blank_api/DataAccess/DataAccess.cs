using DataAccess.Helpers;
using DataAccess.Infrastructure;
using DataAccess.Infrastructure.Interfaces;

namespace API_SIEP.ORM
{
    public class DataAccess
    {


        protected GenericDataAccessService service = GenericDataAccessService.Instance;

        //private RepositoryAccess repository;

        //public DataAccess(RepositoryAccess _repo)
        //{
        //    repository = _repo;
        //}


        private static DataAccess instance;

        public new static DataAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccess();
                }
                return instance;
            }
        }


        public void BeginTransaction(RepositoryAccess repository)
        {
            //var connection = repository.GetConnection();
            //connection.Open();
            //transaction = connection.BeginTransaction();
            service.BeginTransaction(repository);   
        }

        public void CommitTransaction(RepositoryAccess repository)
        {
            service.CommitTransaction(repository);
            ////transaction?.Commit();
            ////transaction?.Connection?.Close();
            ////transaction = null;
        }

        public void RollbackTransaction(RepositoryAccess repository)
        {
                service.RollbackTransaction(repository);      
            ////transaction?.Rollback();
            ////transaction?.Connection?.Close();
            ////transaction = null;
        }


        public IEnumerable<T> GetAll<T>(IRepositoryAccess repository) where T : class
        {
            //IDbConnection con = repository.GetConnection();
            //T instance = Activator.CreateInstance<T>();
            IEnumerable<T> dataEntity = service.GetAll<T>(repository);
            //repository.CloseConnection(con);
            return dataEntity.ToList();

        }



        public IEnumerable<T> GetBySearch<T>(Search search, RepositoryAccess repository)
        {
         
            IEnumerable<T> dataEntity = service.GetBySearch<T>(search, repository); 
            //repository.CloseConnection(con);
            return dataEntity.ToList();
        }

        public T GetById<T>(long Id, RepositoryAccess repository)
        {
            ////T instance = Activator.CreateInstance<T>();
            ////IDbConnection con = repository.GetConnection();
            ////IEnumerable<T> dataEntity = con.Query<T>(Querybuilder.GetByIdQuery<T>(Id, instance));
            T dataEntity = service.GetById<T>(Id, repository);
            //repository.CloseConnection(con);

            return dataEntity;
        }



        public void Insert<T>(T Model, RepositoryAccess repository)
        {
            service.Insert<T>(Model, repository);
            //repository.CloseConnection(con);
        }


        public void Update<T>(T Model, RepositoryAccess repository)
        {
          
            service.Update<T>(Model, repository);  
            //repository.CloseConnection(con);
        }
        public void Delete<T>(long id, RepositoryAccess repository)
        {
          service.Delete<T>(id, repository);   

            //repository.CloseConnection(con);
        }

        public DateTime GetCurrentDate(RepositoryAccess repository)
        {


            return service.GetCurrentDate(repository); 
        }

        public IEnumerable<T> CustomQuery<T>(string query, RepositoryAccess repository)
        {
    
            IEnumerable<T> data = service.CustomQuery<T>(query, repository);   
            //repository.CloseConnection(con);

            return data;
        }
        public object SqlFunction(string query, RepositoryAccess repository)
        {

            var data = service.FunctionSql(query, repository);
            //repository.CloseConnection(con);

            return data;
        }
        public void sqlProdcedure(string query,string parametro, RepositoryAccess repository)
        {

                    service.sqlProdcedure(query, parametro, repository);
            //repository.CloseConnection(con);

        }


    }
}
