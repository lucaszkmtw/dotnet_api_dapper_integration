using BussinessLogic.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;        
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiResponse
{
    public class TramiteResponse 
    {

        public virtual string descripcion { get;set; }
        public virtual string abrev { get;set; }
        public virtual int mrioid { get;set; }
        public virtual string descripMrio { get;set; }
        public virtual int dependeId { get;set; }
        public virtual string descripDepende { get;set; }
        public virtual int cut { get;set; }
        public virtual string descriptasa { get;set; }
        public virtual int cup { get;set; }
        public virtual string importe { get;set; }

    }


    public class TramitesResponse : ResponseAPI
    {
        public List<TramiteResponse> tramites { get; set; }
    }
}   
