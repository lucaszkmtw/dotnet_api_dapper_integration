
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping
{

    public class CuentaDocumentoLiquidacion : ClassMap<CuentaDocumentoLiquidacion>
    {
        public virtual long Id { get; set; }

        public virtual long IdDocumentoLiquidacion { get; set; }
        public virtual long IdCuenta { get; set; }
        public virtual decimal Monto { get; set; }
        public virtual string CuentaDescripcion { get; set; }
        public virtual string Cbu { get; set; }
        public virtual long EsAcreedor { get; set; }







        public CuentaDocumentoLiquidacion()
        {
            Table("RCF_VI_CUENTAS_DOC_LIQUIDACION");
            Schema("RCF");

            Id(x => x.Id, "C_ID");

            Map(x => x.IdDocumentoLiquidacion, "C_ID_DOCUMENTO_LIQUIDACION");
            Map(x => x.IdCuenta, "C_ID_CUENTA");
            Map(x => x.CuentaDescripcion, "D_CUENTA_DESCRIPCION");
            Map(x => x.Cbu, "C_CBU");
            Map(x => x.Monto, "N_MONTO");
            Map(x => x.EsAcreedor, "D_ES_ACREEDOR");




        }
    }
}