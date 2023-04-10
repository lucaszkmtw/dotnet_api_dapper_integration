using DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{


    public class SqlBuilder : QueryConstructor
    {
       

        public SqlBuilder() { }

        
        public string GetAllQuery<T>() {

         string query = SelectAll() +  AddParaMeters<T>() + FromTableAndSchema<T>();


            return query;
        }


        public string GetBySearchQuery<T>(Search search)
        {

            string query = SelectAll() + AddParaMeters<T>() + FromTableAndSchema<T>() + WhereMethod(search);

            return query;
        }


        public string GetByIdQuery<T>(long Id)
        {

            string query = SelectAll() + AddParaMeters<T>() + FromTableAndSchema<T>() + IdMethod<T>(Id);

            return query;
        }

        public string InsertQuery<T>(T model)
        {
            KeyValuePair<string, string> data = ColumnsAndValues<T>(model);

            string query =$" {InsertMethod<T>()}  ({data.Key}) VALUES ({data.Value})";
            return query;
        }


        public string UpdateQuery<T>(T model)
        {
            object id = null;

            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if ((IdModel)Attribute.GetCustomAttribute(property, typeof(IdModel)) != null)
                {
                   id = property.GetValue(model, null);



                }

            }
            string query = $"{UpdateMethod<T>(model)} {IdMethod<T>(id)}";

            return query;
            
        }


        public string CurrentDateTimeQuery()
        {

            string query = "SELECT CURRENT_TIMESTAMP AS Fecha FROM dual;";

            return query;

        }


    }
}
