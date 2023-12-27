
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping {

    public class EstadoLiquidacion : ClassMap<EstadoLiquidacion>
    {
        public virtual long Id { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual  DateTime FechaAlta { get; set; }    
        public virtual  DateTime FechaActualizacion { get; set; }    
        public virtual  string Usuario { get; set; }    
        public virtual  string Codigo { get; set; }    







        public EstadoLiquidacion()
        {
            Table("RCF_ESTADO_LIQUIDACION");
            Schema("RCF");
            Id(x => x.Id, "C_ID");
            Map(x => x.Descripcion, "D_DESCRIPCION");
            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.Codigo, "D_CODIGO");
         



        }
    }
}