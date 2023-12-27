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
        private static SqlBuilder instance;

        public new static SqlBuilder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SqlBuilder();
                }
                return instance;
            }
        }


        public string GetAllQuery<T>(T instance)
        {

            string query = SelectAll() + AddParaMeters<T>(instance) + FromTableAndSchema<T>(instance);


            return query;
        }


        public string GetBySearchQuery<T>(Search search, T instance)
        {

            string query = SelectAll() + AddParaMeters<T>(instance) + FromTableAndSchema<T>(instance) + WhereMethod(search);

            return query;
        }


        public string GetByIdQuery<T>(long Id, T instance)
        {

            string query = SelectAll() + AddParaMeters<T>(instance) + FromTableAndSchema<T>(instance) + IdMethod<T>(Id, instance);

            return query;
        }

        public string InsertQuery<T>(T model)
        {
            KeyValuePair<string, string> data = ColumnsAndValues<T>(model);

            string query = $" {InsertMethod<T>(model)}  ({data.Key}) VALUES ({data.Value}) ";
            return query;
        }
        public string DeleteQuery<T>(long id, T instance)
        {

            string query = $" {DeleteMethod<T>(id, instance)}";
            return query;
        }


        public string UpdateQuery<T>(T model)
        {
            object id = null;

            //PropertyInfo[] properties = typeof(T).GetProperties();
            //foreach (PropertyInfo property in properties)
            //{
            //    if ((IdModel)Attribute.GetCustomAttribute(property, typeof(IdModel)) != null)
            //    {
            //       id = property.GetValue(model, null);



            //    }

            //}
            string query = $"{UpdateMethod<T>(model)} {IdMethod<T>(id, model)}";

            return query;

        }


        public string CurrentDateTimeQuery()
        {

            string query = "SELECT CURRENT_TIMESTAMP FROM DUAL";

            return query;

        }


    }
}
