
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping {

    public class EntidadBancaria : ClassMap<EntidadBancaria>
    {
        public virtual long IdEntidadBancaria { get; set; }
        public virtual string Descripcion { get; set; }
      
        public virtual DateTime FechaAlta { get; set; }
        public virtual string Usuario { get; set; }
        public virtual string UsuarioActualizacion { get; set; }

        public virtual DateTime FechaActualizacion { get; set; }
        public virtual long CodBanco { get; set; }






        public EntidadBancaria()
        {
            Table("RCF_ENTIDAD_BANCARIA");
            Schema("RCF");
            Id(x => x.IdEntidadBancaria, "C_ID_ENTIDAD_BANCARIA");
            Map(x => x.Descripcion, "D_DESCRIPCION");
           
            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
            Map(x => x.UsuarioActualizacion, "C_USUARIO_ACTUALIZ");
            Map(x => x.CodBanco, "C_COD_BANCO");



        }
    }
}