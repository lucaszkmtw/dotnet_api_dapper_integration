
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping {

    public class Cuenta : ClassMap<Cuenta>
    {
        public virtual long Id { get; set; }
        public virtual string NroCuenta { get; set; }
        public virtual long Sucursal { get; set; }
        public virtual string CBU { get; set; }
        public virtual long IdTipoCuenta { get; set; }
        public virtual long IdEntidadBancaria { get; set; }

        public virtual DateTime FechaAlta { get; set; }
        public virtual string Usuario { get; set; }

        public virtual DateTime FechaActualizacion { get; set; }
        public virtual string UsuarioActualizacion { get; set; }






        public Cuenta()
        {
            Table("RCF_CUENTA");
            Schema("RCF");
            Id(x => x.Id, "C_ID");
            Map(x => x.NroCuenta, "C_NRO_CUENTA");
            Map(x => x.Sucursal, "C_SUCURSAL");
            Map(x => x.CBU, "C_CBU");
            Map(x => x.IdTipoCuenta, "C_ID_TIPO_CUENTA");            
            Map(x => x.IdEntidadBancaria, "C_ID_ENTIDAD_BANCARIA");

            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
            Map(x => x.UsuarioActualizacion, "C_USUARIO_ACTUALIZ");



        }
    }
}