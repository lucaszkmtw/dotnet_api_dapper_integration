using DataAccess.CustomAttributes;
using DataAccess.Mapper;
using DataAccess.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class Entidad : ClassMap<Entidad>
    {
        public virtual long Id { get; set; }
        public virtual string Nombre { get; set; }

        public virtual string Apellido { get; set; }
        public virtual string RazonSocial { get; set; }
        public virtual long? Cuit { get; set; }
        public virtual long? Dni { get; set; }
        public virtual DateTime? FechaDesde { get; set; }
        public virtual DateTime? FechaHasta { get; set; }
        public virtual DateTime FechaAlta { get; set; }
        public virtual string Usuario { get; set; }

        public virtual DateTime? FechaActualizacion { get; set; }

        //public virtual TipoEntidad TipoEntidad { get; set; }
        //public virtual long? IdTipoEntidad { get; set; }
        //public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual long? IdTipoDocumento { get; set; }
        public virtual long? MarcaOrganismo { get; set; }
        //public virtual Entidad EntidadPadre { get; set; }
        public virtual long? IdEntidadPadre { get; set; }
        public virtual long? EsDelEstado { get; set; }
        public Entidad()
        {
            Table("RCF_ENTIDAD");
            Schema("RCF");
            Id(x => x.Id, "C_ID", "RCF_ENTIDAD_SQ");

            Map(x => x.Nombre, "D_NOMBRE");
            Map(x => x.Apellido, "D_APELLIDO");
            Map(x => x.RazonSocial, "D_RAZON_SOCIAL");
            Map(x => x.Cuit, "N_CUIT");
            Map(x => x.Dni, "N_DOCUMENTO");
            Map(x => x.FechaDesde, "F_VIGENCIA_DESDE");
            Map(x => x.FechaHasta, "F_VIGENCIA_HASTA");
            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
            Map(x => x.MarcaOrganismo, "M_ORGANISMO");
            Map(x => x.EsDelEstado, "M_PERTENECE_AL_ESTADO");
            //Map(x => x.IdEntidadPadre, "N_ID_ENTIDAD_PADRE");

            //Version(x => x.Version).Column("N_VERSION_HIBERNATE").UnsavedValue("0").Access.Property();

            //References(x => x.TipoEntidad, "C_ID_TIPO_ENTIDAD").Class(typeof(TipoEntidad)).Cascade.None(); //HACE REFERENCIA A LA FOREINKEY
            //References(x => x.EntidadPadre, "N_ID_ENTIDAD_PADRE").Class(typeof(Entidad)).Cascade.None(); //HACE REFERENCIA A LA FOREINKEY

            ////Map(x => x.IdTipoEntidad, "C_ID_TIPO_ENTIDAD");

            ////References(x => x.TipoEntidad, "C_ID_TIPO_ENTIDAD").Class(typeof(TipoEntidad)).Cascade.None(); //HACE REFERENCIA A LA FOREINKEY

            //References(x => x.TipoDocumento, "C_ID_TIPO_DOCUMENTO").Class(typeof(TipoDocumento)).Cascade.None(); //HACE REFERENCIA A LA FOREINKEY
            //Map(x => x.IdTipoDocumento, "C_ID_TIPO_DOCUMENTO");

        }
    }


}
