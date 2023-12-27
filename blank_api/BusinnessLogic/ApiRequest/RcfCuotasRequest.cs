using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiRequest
{
    public class RcfCuotasRequest
    {

      public virtual long IdPlanDeCuotas { get; set; }
        public virtual string Nombre { get; set; }  
        public virtual string Apellido { get; set; }  
        public virtual string RazonSocial { get; set; }  
        public virtual long NroDoc { get; set; }
        public virtual string CuitMinisterio  { get; set;}
        public virtual string DescripcionTasa { get; set; }

    }
}
