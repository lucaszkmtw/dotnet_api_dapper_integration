
using DataAccess.Mapper;

namespace DataAccess.Mapping {

    public class LiquidacionEstado : ClassMap<LiquidacionEstado>
    {
        public virtual long Id { get; set; }
        public virtual long IdLiquidacion { get; set; }
        public virtual long IdEstadoLiquidacion { get; set; }
        public virtual long Fecha { get; set; }
        public virtual long Observacion { get; set; }
        public virtual long FechaAlta { get; set; }
        public virtual string Usuario { get; set; }
        public virtual DateTime FechaActualizacion { get; set; }
        public virtual long VersionNhibernate { get; set; }

     
       






        public LiquidacionEstado()
        {
            Table("RCF_LIQUIDACION_ESTADO");
            Schema("RCF");
            Id(x => x.Id, "C_ID");
            Map(x => x.IdLiquidacion, "C_ID_LIQUIDACION");
            Map(x => x.IdEstadoLiquidacion, "C_ID_ESTADO_LIQUIDACION");
            Map(x => x.Fecha, "FH_ALTA");
            Map(x => x.Observacion, "D_OBSERVACION");
            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
            Map(x => x.VersionNhibernate, "N_VERSION_HIBERNATE");
            

         
         
         



        }
    }
}