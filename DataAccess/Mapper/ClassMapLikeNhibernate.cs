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
    public abstract class ClassMapT<T>
    {
        private Dictionary<string, string> _mappings = new Dictionary<string, string>();
        public KeyValuePair<string, string> _id {get; set;}
        protected ClassMapT()
        {
            _mappings = new Dictionary<string, string>();
            _id= new KeyValuePair<string, string>();    
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
        public void Id<TProperty>(Expression<Func<T, TProperty>> propertyExpression, string columnName)
        {
            var memberExpression = propertyExpression.Body as MemberExpression;

            if (memberExpression == null)
            {
                throw new ArgumentException("Property expression should be a member expression");
            }

            var propertyName = memberExpression.Member.Name;
            _id = new KeyValuePair<string, string>(propertyName, columnName);

        }

        public Dictionary<string, string> GetColumnMappings()
        {
            return _mappings;
        }
        public KeyValuePair<string,string> GetIdColums()
        {
            return _id;
        }
    }


    public class Actividad1
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
    }

    public class ActividadMap : ClassMapT<Actividad1>
    {
        public ActividadMap()
        {
            Id(x => x.Id, "C_ID");
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

