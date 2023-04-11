using Dapper;
using DataAccess.Infrastructure;
using DataAccess.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.ActiveDirectory;

namespace DataAccess.Services
{
    public class RcfService : GenericDataAccessService
    {

        public RcfService() { } 
        private static RcfService instance;

        public new static RcfService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RcfService();
                }
                return instance;
            }
        }


        public List<Entidad> GetAllEntidades()
        {
            //Dictionary<string, string> numbernames = new Dictionary<string, string>() { { "c_id", "c_id" } };

            ////GetClassModels<Entidad>();
            //Entidad entidad = GetById<Entidad>(430);
            //entidad.tipoEntidad = GetById<TipoEntidad>(entidad.IdTipoEntidad);

            //Actividad actividad = GetById<Actividad>(34);
            //actividad.Url = "PUDE INGRESARLO";
            ////Insert<Actividad>(actividad);


            //actividad.Descripcion = "otra cosita";
            ////InsertQuery<Entidad>(entidad);
            //Update<Actividad>(actividad);
            //Search search = new Search(typeof(Entidad));
            //search.AddAlias(new KeyValuePair<string, object>("FH_ALTA", entidad.FechaAlta ));

            //IEnumerable<Entidad> getdata = GetBySearch<Entidad>(search);

            ////Insert<Entidad>(entidad);
            ///
            IEnumerable<Actividad> actividad = GetAll<Actividad>();
            IEnumerable<Entidad> entidades = GetAll<Entidad>();
            Entidad entida1des = GetById<Entidad>(546);
            //IEnumerable<Entidad> entidade1s = GetAll<Entidad>();
            List<long> listado_cuits = new List<long>();
            List<long> cuits_repetidos = new List<long>();



            foreach (Entidad entidad in entidades)
            {

                if (!listado_cuits.Contains(entidad.cuit)){
                    listado_cuits.Add(entidad.cuit);

                }
                else
                {
                    cuits_repetidos.Add(entidad.cuit);
                }
                

            }

            //int cuantos = entidades.Count();

            return entidades.ToList();
        }



    }
}
