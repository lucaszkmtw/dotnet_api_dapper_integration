
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping {

    public class ActividadServer: ClassMap<ActividadServer>
    {
        public virtual long Id { get; set; }
        public virtual string DDescripcion { get; set; }
        public virtual DateTime FechaAlta { get; set; }
        public virtual string Usuario { get; set; }
        public virtual DateTime FechaActualizacion { get; set; }
        public virtual string Url { get; set; }
        public virtual string DDestinoGdeba { get; set; }
        public virtual bool mPaseGdeba { get; set; }
        public virtual int idWorkflow { get; set; }
        public virtual bool mActivo { get; set; }

        public ActividadServer()
        {
            Table("WF_ACTIVIDAD");
            //Schema("WF");
            Id(x => x.Id, "C_ID", "");
            Map(x => x.DDescripcion, "D_DESCRIPCION");
            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
            Map(x => x.Url, "URL_PANTALLA");
            Map(x => x.DDestinoGdeba, "D_DESTINO_GDEBA");
            Map(x => x.mPaseGdeba, "M_PASE_GDEBA");
            Map(x => x.idWorkflow, "C_ID_WORKFLOW");
            Map(x => x.mActivo, "M_ACTIVO");

        }
    }
}