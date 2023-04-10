using DataAccess.CustomAttributes;
using DataAccess.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    [Schema("RCF")]
    [Table("RCF_ENTIDAD")]
    public class Entidad
    {

        [IdModel("C_ID")]
        [Column("C_ID")]
        public virtual long Id { get; set; }
        [Column("C_ID_TIPO_ENTIDAD")]
        public virtual long IdTipoEntidad { get; set; }

        [Column("C_ID_TIPO_DOCUMENTO")]
        public virtual long IdTipoDocumento { get; set; }

        [Column("D_NOMBRE")]
        public virtual string Nombre { get; set; }

        [Column("D_APELLIDO")]
        public virtual string Apellido { get; set; }

       
        [Column("D_RAZON_SOCIAL")]
        public virtual string razonSocial { get; set; }
        [Column("F_VIGENCIA_DESDE")]
        public virtual DateTime VigenciaDesde { get; set; }
        [Column("F_VIGENCIA_HASTA")]
        public virtual DateTime VigenciaHasta { get; set; }
        [Column("FH_ALTA")]
        public virtual DateTime FechaAlta { get; set; }
        [Column("C_USUARIO")]
        public virtual string Usuario { get; set; }
        [Column("M_ORGANISMO")]
        public virtual long MarcaOrganismo { get; set; }
        [Column("N_CUIT")]
        public virtual long cuit { get; set; }
        //public virtual TipoEntidad tipoEntidad { get; set; }

        [ClassModel("C_ID_TIPO_ENTIDAD")]
        public virtual TipoEntidad tipoEntidad { get; set; }

    }
}
