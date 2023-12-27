
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping {

    public class DocumentoLiquidacion : ClassMap<DocumentoLiquidacion>
    {
        public virtual long Id { get; set; }
        public virtual long IdLiquidacion { get; set; }
        public virtual long IdDetalleLiquidacionCuenta { get; set; }
        public virtual long IdTipoLiquidacion { get; set; }
        public virtual string CodBarra { get; set; }

        public virtual DateTime FechaAlta { get; set; }
        public virtual string Usuario { get; set; }

        public virtual DateTime FechaActualizacion { get; set; }
        public virtual string NumDocumento { get; set; }
        public virtual string Json { get; set; }

        public virtual DateTime FechaVencimiento { get; set; }



        public DocumentoLiquidacion()
        {
            Table("RCF_DOCUMENTO_LIQUIDACION");
            Schema("RCF");
            Id(x => x.Id, "C_ID");
            Map(x => x.IdLiquidacion, "C_ID_LIQUIDACION");
            Map(x => x.IdDetalleLiquidacionCuenta, "C_ID_DETALLE_LIQ_CTA");
            Map(x => x.IdTipoLiquidacion, "C_ID_TIPO_LIQUIDACION");
            Map(x => x.CodBarra, "C_COD_BARRA");
            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
            Map(x => x.NumDocumento, "N_NUMERO_DOCUMENTO");
            Map(x => x.Json, "D_JSON");
            
            Map(x => x.FechaVencimiento, "FH_VENCIMIENTO");

        }
    }
}