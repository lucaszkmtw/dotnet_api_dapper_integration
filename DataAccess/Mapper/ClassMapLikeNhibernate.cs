using DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public  class ClassMap<T>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Dictionary<string, string> _mappings = new Dictionary<string, string>();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public KeyValuePair<string, KeyValuePair<string, string>> _id = new  KeyValuePair<string, KeyValuePair<string, string>>();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public  string _schema = "";
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
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
            _id = new KeyValuePair<string, KeyValuePair<string, string>>(columnName, new KeyValuePair<string, string>(propertyName, sequence));

        }
        public void Schema(string columnName)
        {


            _schema = columnName;

        }
        public void Table(string columnName)
        {


            _table = columnName;

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


    

}
 