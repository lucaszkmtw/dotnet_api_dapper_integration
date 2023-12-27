
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping {

    public class PlanDecuotas : ClassMap<PlanDecuotas>
    {
        public virtual long Id { get; set; }

        public virtual long NumeroCantidadTotal  { get; set; }
        public virtual long NumeroCantidadRestantes { get; set; }
        public virtual DateTime FechaAlta { get; set; }
        public virtual string Usuario { get; set; }
        public virtual DateTime? FechaActualizacion { get; set; }
        public virtual long? IdEstadoPlanDeCuotas { get; set; }
        public virtual string IdDocumentoLiquidacion { get; set; }


        public PlanDecuotas()
        {
            Table("RCF_PLAN_DE_CUOTAS");
            Schema("RCF");
            Id(x => x.Id, "C_ID", "RCF_PLAN_DE_CUOTAS_SQ");
            Map(x => x.NumeroCantidadTotal, "N_CANT_TOTAL");
            Map(x => x.NumeroCantidadRestantes, "N_CANT_RESTANTES");
            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.IdEstadoPlanDeCuotas, "C_ID_ESTADO_PLAN_DE_CUOTAS");
            Map(x => x.IdDocumentoLiquidacion, "C_ID_DOCUMENTO_LIQUIDACION");
            
         

        }
    }
}