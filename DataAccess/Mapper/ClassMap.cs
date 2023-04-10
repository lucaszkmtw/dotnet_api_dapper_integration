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
    public class ClassMap<T>
    {

        private T class_element;
        public string Table(string tableName)
        {

            return tableName;

        }

        public string[] Map(string memberExpression, string parameters)
        {
            string[] dataRetrieve = { memberExpression, parameters };
            return dataRetrieve;
          
        }
    }
}
