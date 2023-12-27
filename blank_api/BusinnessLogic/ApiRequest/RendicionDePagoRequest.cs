using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiRequest
{
    public class RendicionDePagoRequest
    {
        public virtual string CodigoDeBarras { get; set; }    
        public virtual decimal ImporteDepositado { get; set; }    
        public virtual decimal ImporteRetenido { get; set; }    
        public virtual DateTime FechaRendicion { get; set; }    
        public virtual DateTime FechaDePago { get; set; }

    }
}
