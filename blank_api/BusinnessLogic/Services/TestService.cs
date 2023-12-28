
using BusinessLogic.ApiRequest;
using BusinessLogic.DTO;
using BussinessLogic.API_Pagos.Data.Encrypt;
using Dapper;
using DataAccess.Helpers;
using DataAccess.Infrastructure;
using DataAccess.Infrastructure.Interfaces;
using DataAccess.Mapping;
using Mapster;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.SqlClient;

namespace BussinessLogic.API_Pagos.Services
{
    public class TestService
    {
        private readonly IConfiguration _config;
        private readonly IRepositoryAccess repo;
        protected API_SIEP.ORM.DataAccess service = API_SIEP.ORM.DataAccess.Instance;
        public TestService(IConfiguration config, IRepositoryAccess _repo) {
            _config = config;
            repo = _repo;

        }


        public List<ActividadDTO> GetAllActividades()
        {
            return service.GetAll<Actividad>(repo).Adapt<List<ActividadDTO>>();
        }

        public ActividadDTO GetById(long id)
        {
            return service.GetById<Actividad>(id, repo).Adapt<ActividadDTO>();
        }
        public List<ActividadDTO> GetByElement(string element)
        {
            Search search = new Search(typeof(Actividad));
            search.AddAlias(new KeyValuePair<string, object>("C_USUARIO", element));

           return service.GetBySearch<Actividad>(search, repo).Adapt<List<ActividadDTO>>(); 
        }

        public void InsertActividad(Actividad actividad)

        {
            service.Insert<Actividad>(actividad, repo);

        }
        public void UpdateActividad(Actividad actividad)

        {
            service.Update<Actividad>(actividad, repo);
            
        }
        public void DeleteActividad(long id)

        {
            service.Delete<Actividad>(id, repo);

        }

        public IEnumerable<ActividadServer> ActividadSqlServer()
        {
          return  service.GetAll<ActividadServer>(repo);
        }
        public ActividadDTO GetByIdSqlServer(long id)
        {
            return service.GetById<Actividad>(id, repo).Adapt<ActividadDTO>();
        }
        public List<ActividadDTO> GetByElementSqlServer(string element)
        {
            Search search = new Search(typeof(Actividad));
            search.AddAlias(new KeyValuePair<string, object>("C_USUARIO", element));

            return service.GetBySearch<Actividad>(search, repo).Adapt<List<ActividadDTO>>();
        }

        public void InsertSqlServer(ActividadServer actividad)
        {

            using (var connection = repo.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        service.Insert<ActividadServer>(actividad, repo,transaction);
                        actividad.DDescripcion = "askdskadKAKAKAKAK PUDED";
                        actividad.DDestinoGdeba = "GDEBA NUEVO";
                        service.Insert<ActividadServer>(actividad, repo,transaction);   
                        transaction.Commit();

                        // ... más operaciones ...

                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }


        }
        public void UpdateSqlServer(ActividadServer actividad)
        {


            service.Update<ActividadServer>(actividad, repo);
        }

        public void DeleteActividadServer(long id)

        {
            service.Delete<ActividadServer>(id, repo);

        }
    }
}
