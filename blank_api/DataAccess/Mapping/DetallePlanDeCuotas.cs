
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping
{

    public class DetallePlanDeCuotas : ClassMap<DetallePlanDeCuotas>
    {
        public virtual long Id { get; set; }
        public virtual long IdDocumentoLiquidacion { get; set; }

        public virtual long NumeroCuota { get; set; }
        public virtual DateTime FechaVencimiento { get; set; }
        public virtual decimal Importe { get; set; }
        public virtual decimal ImporteCuotas { get; set; }
        public virtual string CodigoDeBarras { get; set; }
        public virtual DateTime FechaAlta { get; set; }
        public virtual string Usuario { get; set; }
        public virtual DateTime? FechaActualizacion { get; set; }
        public virtual string Estado { get; set; }
        public virtual string ComprobanteHash { get; set; }
        public virtual string CodigoDePagoElectronico { get; set; }
        public virtual long IdPlanDeCuotas { get; set; }


        public DetallePlanDeCuotas()
        {
            Table("RCF_DETALLE_PLAN_DE_CUOTAS");
            Schema("RCF");
            Id(x => x.Id, "C_ID", "RCF_DETALLE_PLAN_DE_CUOTAS_SQ");
            Map(x => x.IdDocumentoLiquidacion, "C_ID_DOCUMENTO_LIQUIDACION");
            Map(x => x.NumeroCuota, "N_NUMERO_CUOTA");
            Map(x => x.FechaVencimiento, "FH_VENCIMIENTO");
            Map(x => x.Importe, "N_IMPORTE");
            Map(x => x.CodigoDeBarras, "C_COD_BARRA");
            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
            Map(x => x.Estado, "D_ESTADO");
            Map(x => x.ComprobanteHash, "C_COMPROBANTE_HASH");
            Map(x => x.CodigoDePagoElectronico, "C_CODIGO_PAGO_ELECTRONICO");
            Map(x => x.IdPlanDeCuotas, "C_ID_PLAN_DE_CUOTAS");
            Map(x => x.ImporteCuotas, "N_IMPORTE_TASAS");



        }
    }
}