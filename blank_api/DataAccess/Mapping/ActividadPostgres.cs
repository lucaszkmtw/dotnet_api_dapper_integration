
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping
{

    public class ActividadPostgres : ClassMap<ActividadPostgres>
    {
        public virtual long idafectacion { get; set; }
        public virtual string afectacion { get; set; }


        public ActividadPostgres()
        {
            Table("\"afectacion\"");
            //Schema("WF");
            Id(x => x.idafectacion, "idafectacion", "");
            Map(x => x.afectacion, "afectacion");
          


        }
    }
}