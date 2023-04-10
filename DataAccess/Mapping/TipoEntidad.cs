using DataAccess.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{

    [Schema("RCF")]
    [Table("RCF_TIPO_ENTIDAD")]
    public class TipoEntidad
    {
        [IdModel("C_ID", sequence = "RCF_TIPO_ENTIDAD")]
        [Column("C_ID")]
        public virtual long Id { get; set; }

        [Column("C_TIPO_ENTIDAD")]
        public virtual string IdTipoEntidad { get; set; }

        [Column("D_TIPO_ENTIDAD")]
        public virtual string Descripcion  { get; set; }
    }
}
