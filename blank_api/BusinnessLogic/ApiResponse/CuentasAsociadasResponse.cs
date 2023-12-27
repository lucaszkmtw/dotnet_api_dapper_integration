using BussinessLogic.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiResponse
{
    public class CuentasAsociadasResponse : ResponseAPI
    {
        public virtual long IdTransaccion { get; set; }

        public virtual List<Cuentas> Cuentas { get; set; }  


    }


    public class Cuentas
    {
        public virtual string CuentaDescripcion { get; set;}
        public virtual string Cbu { get; set; }
        public virtual decimal Monto { get; set; }
    }
}
