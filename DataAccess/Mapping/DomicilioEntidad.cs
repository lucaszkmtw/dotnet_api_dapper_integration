using DataAccess.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    [Schema("RCF")]
    [Table("RCF_DOMICILIO_ENTIDAD")]
    public class DomicilioEntidad
    {




        [IdModel("C_ID", sequence = "WF_ACTIVIDAD_SQ")]
        [Column("C_ID")]
        public virtual long Id { get; set; }

        [Column("C_ID_ENTIDAD")]
        public virtual long IdEntidad { get; set; }


        [Column("D_CALLE")]
        public virtual string Calle { get; set; }

        [Column("C_NUMERO")]
        public virtual long Numero { get; set; }


        [Column("D_PISO")]
        public virtual string Piso { get; set; }

        [Column("D_DPTO")]
        public virtual string Depto { get; set; }
        [Column("C_ID_LOCALIDAD")]

        public virtual long IdLocalidad { get; set; }

        [Column("C_ID_PARTIDO")]
        public virtual long IdPartido { get; set; }

        [Column("C_ID_PROVINCIA")]
        public virtual long IdProvincia { get; set; }

        [Column("C_ID_TIPO_DOMICILIO")]
        public virtual long IdTipoDomicilio { get; set; }

        [Column("M_ACTIVO")]
        public virtual long Activo { get; set; }






    }
}
