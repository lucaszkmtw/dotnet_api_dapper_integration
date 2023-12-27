
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping {

    public class SiepDocumentoLiquidacion : ClassMap<SiepDocumentoLiquidacion>
    {
        public virtual long Id { get; set; }
        public virtual long IdDocumento { get; set; }
        public virtual string ComprobanteHash { get; set; }
        public virtual string CodigoPagoElectronico { get; set; }
        public virtual string CodBarra { get; set; }
        public virtual DateTime FechaAlta { get; set; }
        public virtual string Usuario { get; set; }
        public virtual DateTime FechaActualizacion { get; set; }
        
        
        public virtual DateTime FechaVencimiento { get; set; }



        public SiepDocumentoLiquidacion()
        {
            Table("RCF_SIEP_DOCUMENTO_LIQUIDACION");
            Schema("RCF");
            Id(x => x.Id, "C_ID");
            Map(x => x.IdDocumento, "C_ID_DOCUMENTO");
            Map(x => x.ComprobanteHash, "C_COMPROBANTE_HASH");

            Map(x => x.CodigoPagoElectronico, "C_CODIGO_PAGO_ELECTRONICO");
            Map(x => x.CodBarra, "C_COD_BARRA");
            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
            
            Map(x => x.FechaVencimiento, "FH_VENCIMIENTO");

        }
    }
}