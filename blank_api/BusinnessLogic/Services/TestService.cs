
using BusinessLogic.ApiRequest;
using BusinessLogic.DTO;
using BussinessLogic.API_Pagos.Data.Encrypt;
using DataAccess.Helpers;
using DataAccess.Infrastructure;
using DataAccess.Infrastructure.Interfaces;
using DataAccess.Mapping;
using Mapster;
using Microsoft.Extensions.Configuration;

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

        //public async Task<bool> VerifyPassword(RequestUsuario usuario)
        //{

        //    string pass = _config.GetSection("KeyEncript:Key").Value;
        //    if (pass == usuario.Password )
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
       


        //}

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
        public void UpdateActividad(long id)

        {
            service.Delete<Actividad>(id, repo);

        }
    }
}
