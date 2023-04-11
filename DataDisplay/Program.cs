
using DataAccess.Infrastructure;
using DataAccess.Mapper;
using DataAccess.Mapping;
using DataAccess.Services;
using System.Collections.Generic;
using System.ComponentModel;

namespace Program
{


    public class Program
    {

        
        static void Main()
        {

            var data = new Data();
            data.GetData();


           



        }


    }

    public class Data{

       
       
        protected RcfService servicioDataAcess = RcfService.Instance;

        public void GetData()
    {
            //SqlBuilder sqlBuilder = new SqlBuilder();
            // string sql = sqlBuilder.GetAllSql<Entidad>();
            // Console.WriteLine(sql);
            IEnumerable<Entidad> data = servicioDataAcess.GetAllEntidades();

            var columnMappings = new Actividad().GetColumnMappings();
            var idcolumn = new Actividad().GetIdColums();
            foreach (Entidad entidad in data)
            {
                
               
            }




        }
}


}