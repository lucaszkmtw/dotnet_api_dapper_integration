
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping {

    public class Liquidacion : ClassMap<Liquidacion>
    {
        public virtual long Id { get; set; }
        public virtual decimal MontoTotalInteres { get; set; }
        public virtual decimal MontoTotalAdeudado { get; set; }
        public virtual decimal MontoTotalTasas { get; set; }
        public virtual decimal MontoTotal { get; set; }
        public virtual long IdEstadoLiquidacion { get; set; }
        public virtual DateTime FechaActualizacion { get; set; }
        public virtual DateTime FechaLiquidacion { get; set; }
        public virtual string Observaciones { get; set; }
        public virtual long? IdLiquidacionIGB { get; set; }
        public virtual long? IdLiquidacionOrigen { get; set; }
        public virtual string OrigenLiquidacion { get; set; }

       






        public Liquidacion()
        {
            Table("RCF_LIQUIDACION");
            Schema("RCF");
            Id(x => x.Id, "C_ID");
            Map(x => x.MontoTotalInteres, "N_MONTO_TOTAL_INTERES");
            Map(x => x.MontoTotalAdeudado, "N_MONTO_TOTAL_ADEUDADO");
            Map(x => x.MontoTotalTasas, "N_MONTO_TOTAL_TASAS");
            Map(x => x.MontoTotal, "N_MONTO_TOTAL");
            Map(x => x.IdEstadoLiquidacion, "C_ID_ESTADO_LIQUIDACION");
            Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
            Map(x => x.Observaciones, "D_OBSERVACIONES");
            Map(x => x.FechaLiquidacion, "FH_LIQUIDACION");
            Map(x => x.IdLiquidacionIGB, "C_ID_LIQUIDACION_IGB");
            Map(x => x.IdLiquidacionOrigen, "C_ID_LIQUIDACION_ORIGEN");
            Map(x => x.OrigenLiquidacion, "C_ORIGEN_LIQUIDACION");
            

         



        }
    }
}