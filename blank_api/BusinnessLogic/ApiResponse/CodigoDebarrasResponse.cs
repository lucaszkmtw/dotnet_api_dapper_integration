using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiResponse
{
    public class CodigoDeBarrasResponse
    {
        public virtual string CodigoDebaras { get; set; }
        public virtual decimal MontoTotalAdeudado { get; set; }
        public virtual decimal MontoTotalTasas { get; set; }
        public virtual decimal MontoTotal { get; set; }
    }
}
