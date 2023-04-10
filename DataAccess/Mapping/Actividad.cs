
using DataAccess.CustomAttributes;



namespace DataAccess.Mapping {


    [Schema("WF")]
    [Table("WF_ACTIVIDAD")]
    public class Actividad
    {

    [IdModel("C_ID", sequence ="WF_ACTIVIDAD_SQ")]
       [Column("C_ID")]
        public virtual long Id { get; set; }

    [Column("D_DESCRIPCION")]
    public virtual string Descripcion { get; set; }


        [Column("URL_PANTALLA")]
        public virtual string Url { get; set; }

        [Column("FH_ALTA")]
        public virtual DateTime FechaAlta { get; set; }


        [Column("C_USUARIO")]
        public virtual string Usuario { get; set; }

        [Column("FHU_ACTUALIZ")]
        public virtual DateTime FechaActualizacion { get; set; }





    }
}