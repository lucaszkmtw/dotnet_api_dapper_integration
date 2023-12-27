
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping
{

    public class EstadoPlanDeCuotas : ClassMap<EstadoPlanDeCuotas>
    {
        public virtual long Id { get; set; }
        public virtual long Descripcion { get; set; }
        public virtual DateTime FechaAlta { get; set; }
        public virtual string Usuario { get; set; }
        public virtual DateTime FechaAcualizacion { get; set; }
        public virtual string Codigo { get; set; }

     


        public EstadoPlanDeCuotas()
        {
            Table("RCF_DETALLE_PLAN_DE_CUOTAS");
            Schema("RCF");
            Id(x => x.Id, "C_ID", "RCF_ESTADO_PLAN_DE_CUOTAS_SQ");
            Map(x => x.Descripcion, "D_DESCRIPCION");
            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.FechaAcualizacion, "FH_ACTUALIZ");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.Codigo, "D_CODIGO");
   


        }
    }
}