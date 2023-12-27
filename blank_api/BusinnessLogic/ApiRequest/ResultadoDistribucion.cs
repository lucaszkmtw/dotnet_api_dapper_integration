using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiRequest
{
    public class ResultadoDistribucionRequest
    {
     public virtual long IdTransaccion { get; set; }
        public virtual long CodigoOperacion { get; set; } 
        public virtual string ComrpobanteDistribucion { get; set; }
        public virtual DateTime FechaComprobante { get; set;}   
        public virtual string DetalleOperacion { get; set; }    

    }
}
