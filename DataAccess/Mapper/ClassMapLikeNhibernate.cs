using DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public  class ClassMap<T>
    {
        public Dictionary<string, string> _mappings = new Dictionary<string, string>();
        public KeyValuePair<string, KeyValuePair<string, string>> _id { get; set; }

        public string _schema = "";
        public string _table = "";
        public ClassMap()
        {
            _mappings = new Dictionary<string, string>();
            _id = new KeyValuePair<string, KeyValuePair<string, string>>();
        }



      


        public void Map<TProperty>(Expression<Func<T, TProperty>> propertyExpression, string columnName)
        {
            var memberExpression = propertyExpression.Body as MemberExpression;

            if (memberExpression == null)
            {
                throw new ArgumentException("Property expression should be a member expression");
            }

            var propertyName = memberExpression.Member.Name;

            switch (memberExpression.Member)
            {
                case PropertyInfo pi when pi.PropertyType == typeof(DateTime):
                    _mappings[propertyName] = $"{columnName}";
                    break;
                case PropertyInfo pi when pi.PropertyType == typeof(long):
                    _mappings[propertyName] = $"{columnName}";
                    break;
                default:
                    _mappings[propertyName] = columnName;
                    break;
            }
        }



        public void Id<TProperty>(Expression<Func<T, TProperty>> propertyExpression, string columnName, string sequence = null)
        {
            var memberExpression = propertyExpression.Body as MemberExpression;

            if (memberExpression == null)
            {
                throw new ArgumentException("Property expression should be a member expression");
            }

            var propertyName = memberExpression.Member.Name;
            _id = new KeyValuePair<string, KeyValuePair<string, string>>(propertyName, new KeyValuePair<string, string>(columnName, sequence));

        }
        public void Schema(string columnName)
        {


            _schema = columnName;

        }
        public void Table(string columnName)
        {


            _schema = columnName;

        }



        public Dictionary<string, string> GetColumnMappings()
        {
            return _mappings;
        }
        public KeyValuePair<string, KeyValuePair<string, string>> GetIdColums()
        {
            return _id;
        }
    }


    public class Actividad1 : ClassMap<Actividad1>
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

        public Actividad1()
        {
            Table("WF_ACTIVIDAD");
            Schema("RCF");
            Id(x => x.Id, "C_ID", "SQ_ACTIVIDAD");
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
    //public class ActividadMap : ClassMapT<Actividad1>
    //{
    //    public ActividadMap()
    //    {
    //        Id(x => x.Id, "C_ID");
    //        Map(x => x.DDescripcion, "D_DESCRIPCION");
    //        Map(x => x.FechaAlta, "FH_ALTA");
    //        Map(x => x.Usuario, "C_USUARIO");
    //        Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
    //        Map(x => x.Url, "URL_PANTALLA");
    //        Map(x => x.DDestinoGdeba, "D_DESTINO_GDEBA");
    //        Map(x => x.mPaseGdeba, "M_PASE_GDEBA");
    //        Map(x => x.idWorkflow, "C_ID_WORKFLOW");
    //        Map(x => x.mActivo, "M_ACTIVO");
    //    }
    //}




//ejemplo de mapping
//public class ActividadMap : ClassMap<Actividad>
//{
//    public ActividadMap()
//    {
//        Map(x => x.Id, "C_ID");
//        Map(x => x.DDescripcion, "D_DESCRIPCION");
//        Map(x => x.FechaAlta, "FH_ALTA");
//        Map(x => x.Usuario, "C_USUARIO");
//        Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
//        Map(x => x.Url, "URL_PANTALLA");
//        Map(x => x.DDestinoGdeba, "D_DESTINO_GDEBA");
//        Map(x => x.mPaseGdeba, "M_PASE_GDEBA");
//        Map(x => x.idWorkflow, "C_ID_WORKFLOW");
//        Map(x => x.mActivo, "M_ACTIVO");
//    }
//}

//OBTENER LAS COLUMNAS 
//    var columnMappings = new ActividadMap().GetColumnMappings();

