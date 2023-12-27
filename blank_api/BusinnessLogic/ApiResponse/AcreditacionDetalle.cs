using BussinessLogic.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiResponse
{
    public class AcreditacionDetalle: ResponseAPI
    {

     public IList<InfoAcreditacion> infoAcreditacion { get; set; }



    }


    public class InfoAcreditacion
    {
        public string modoPagoId { get; set; }
        public string fAcreditacion { get; set; }
        public string fPago { get; set; }
    }




}
