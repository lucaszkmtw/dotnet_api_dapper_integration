using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ApiResponse
{
    public class PagoTesoreria
    {
        public virtual long IdLiquidacion { get; set; }
        public virtual long IdDocumentoLiquidacion { get; set; }
        public virtual decimal Monto { get; set; }
        public virtual string Estado { get; set; }
        public virtual DateTime FechaPago { get; set; }
        public virtual string IdentificacionDePago { get; set; }
        public virtual string ReferenciaDePago { get; set; }
        public virtual string ComrpobanteTesoreria { get; set; }
        public virtual string Usuario { get; set; }

        public string KeyEncrypt { get; set; }
    }
}
