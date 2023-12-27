
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping {

    public class DocumentoLiquidacionCuenta : ClassMap<DocumentoLiquidacionCuenta>
    {
        public virtual long Id { get; set; }
        public virtual long IdDocumentoLiquidacion { get; set; }
        public virtual long IdCuenta { get; set; }
        public virtual long Monto { get; set; }

        public virtual DateTime FechaAlta { get; set; }
        public virtual string Usuario { get; set; }

        public virtual DateTime FechaActualizacion { get; set; }






        public DocumentoLiquidacionCuenta()
        {
            Table("RCF_DOCUMENTO_LIQ_CUENTA");
            Schema("RCF");
            Id(x => x.Id, "C_ID");
            Map(x => x.IdDocumentoLiquidacion, "C_ID_DOCUMENTO_LIQUIDACION");
            Map(x => x.IdCuenta, "C_CUENTA");
            Map(x => x.Monto, "N_MONTO");
            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
            

        }
    }
}