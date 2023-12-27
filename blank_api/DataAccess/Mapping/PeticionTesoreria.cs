
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping {

    public class PeticionTesoreria: ClassMap<PeticionTesoreria>
    {
        public virtual long Id { get; set; }
        public virtual long? IdDocumentoLiquidacion { get; set; }
        
        public virtual string Requerimiento { get; set; }
        public virtual string Respuesta { get; set; }
        public virtual string Resultado { get; set; }
        public virtual DateTime FechaAlta { get; set; }
        public virtual DateTime? FechaActualizacion { get; set; }
        public virtual string Usuario { get; set; }     
        public virtual string NombreMetodo { get; set; }     


     

        public PeticionTesoreria()
        {
            Table("RCF_PETICION_TESORERIA");
            Schema("RCF");
            Id(x => x.Id, "C_ID", "RCF_PETICION_TESORERIA_SQ");
            Map(x => x.IdDocumentoLiquidacion, "C_ID_DOCUMENTO_LIQUIDACION");
            Map(x => x.Requerimiento, "D_REQUERIMIENTO");
            Map(x => x.Respuesta, "D_RESPUESTA_RCF");
            Map(x => x.Resultado, "D_RESULTADO");
            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.NombreMetodo, "D_METODO");
         

        }
    }
}