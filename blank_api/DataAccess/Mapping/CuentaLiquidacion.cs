
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping {

    public class CuentaLiquidacion : ClassMap<CuentaLiquidacion>
    {
        public virtual long Id { get; set; }
        
        public virtual long IdLiquidacion { get; set; }
        public virtual long IdCuenta { get; set; }
        public virtual string CuentaDescripcion { get; set; }
        public virtual string Cbu { get; set; }
        public virtual string TipoCuenta { get; set; }
        


       
        public virtual decimal Monto { get; set; }






        public CuentaLiquidacion()
        {
            Table("RCF_VI_CUENTAS_LIQUIDACION");
            Schema("RCF");
            Id(x => x.Id, "C_ID");
           
            Map(x => x.IdLiquidacion, "C_ID_LIQUIDACION");            
            Map(x => x.IdCuenta, "C_ID_CUENTA");
            Map(x => x.CuentaDescripcion, "D_CUENTA_DESCRIPCION");
            Map(x => x.Cbu, "C_CBU");
            Map(x => x.TipoCuenta, "D_TIPO_CUENTA");


            Map(x => x.Monto, "N_MONTO");
            



        }
    }
}