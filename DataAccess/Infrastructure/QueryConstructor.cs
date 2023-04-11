using DataAccess.CustomAttributes;
using DataAccess.Helpers;
using DataAccess.Infrastructure.Generic;
using DataAccess.Mapper;
using DataAccess.Mapping;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
    public class QueryConstructor : GenericFunction
    {

        public QueryConstructor()
        {

        }
        public string[] TypeList = { "String", "Int64", "Int32", "DateTime" };
        public string SelectAll()
        {
            string select = "SELECT ";

            return select;
        }

        public string AddParaMeters<T>(T instance)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            string attributtes = "";

            Dictionary<string, string> mapping = GetAttributeMapping<T>(instance, "_mappings");
            KeyValuePair<string, KeyValuePair<string, string>> IdMapping = GetAttributeId<T>(instance, "_id");
            attributtes = attributtes + IdMapping.Key + " AS " + IdMapping.Value.Key + ",";

            foreach (KeyValuePair<string, string> property in mapping)
            {

                //var id = GetAttributeValue(instance, "_id");
                //ColumnAttribute attribute = (ColumnAttribute)Attribute.GetCustomAttribute(property, typeof(ColumnAttribute));
                attributtes = attributtes + property.Value + " AS " + property.Key + ",";

                //var propertyType = property.PropertyType.Name;
                //if (Array.Exists(TypeList, element => element == propertyType))
                //{
                //    attributtes = attributtes + attribute.name + " AS " + property.Name + ",";
                //}
            }

            return attributtes.Remove(attributtes.Length - 1); ;


        }
        public string FromTableAndSchema<T>(T instance)
        {


            string schema = GetStringAttribute<T>(instance, "_schema");
            string table = GetStringAttribute<T>(instance, "_table");
            //SchemaAttribute Schema = (SchemaAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(SchemaAttribute));
            //TableAttribute table = (TableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute));


            string fromtable = $" FROM {schema}.{table}";

            return fromtable;
        }

        public string WhereMethod(Search search)
        {
            string parameters = "";
            string where = " WHERE ";
            foreach (KeyValuePair<string, object> data in search.Alias)

            {
                //parameters = parameters + data.Key + "=";


                if (data.Value is string)
                {
                    parameters += $"{data.Key} ='{data.Value}' AND";
                }
                if (data.Value is int || data.Value is long)
                {
                    parameters += $"{data.Key} ={data.Value} AND";
                }
                if (data.Value is DateTime)
                {
                    DateTime date = Convert.ToDateTime(data.Value);
                    parameters += $"TO_CHAR({data.Key},'dd/mm/yyyy')= '{date.Day}/{date.Month}/{date.Year}' AND";
                }


            }

            string whereQuery = where + parameters;

            return whereQuery.Remove(whereQuery.Length - 3);
        }


        public string IdMethod<T>(object id, T instance)
        {
          
            //properties.Where()
            string idEntity = "";
            KeyValuePair<string, KeyValuePair<string, string>> IdMapping = GetAttributeId<T>(instance, "_id");
            {
                idEntity = IdMapping.Key;
            }
            PropertyInfo prop = typeof(T).GetProperty(IdMapping.Value.Key);
            if (prop.GetValue(instance, null) != null) { id = prop.GetValue(instance, null); }
            string WhereQuery = $" WHERE {idEntity}={id}";
           
            return WhereQuery;
        }


        public void GetClassModels<T>()
        {
            List<ClassModelAttribute> attributes = new List<ClassModelAttribute>();
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {

                ClassModelAttribute attribute = (ClassModelAttribute)Attribute.GetCustomAttribute(property, typeof(ClassModelAttribute));
                if (attribute != null) { attributes.Add(attribute); }


            }

        }

        public string InsertMethod<T>(T model)
        {

            //Type attributesModel = model.GetType();
            string schema = GetStringAttribute<T>(model, "_schema");
            string table = GetStringAttribute<T>(model, "_table");
            string query = $"INSERT INTO {schema}.{table} ";

            return query;

        }




        public KeyValuePair<string, string> ColumnsAndValues<T>(T model)
        {
            Dictionary<string, string> mapping = GetAttributeMapping<T>(model, "_mappings");
            KeyValuePair<string, KeyValuePair<string, string>> IdMapping = GetAttributeId<T>(model, "_id");
            string schema = GetStringAttribute<T>(model, "_schema");
            string table = GetStringAttribute<T>(model, "_table");
            //SchemaAttribute Schema = (SchemaAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(SchemaAttribute));
            string values = "";
            string columns = "";



            PropertyInfo[] props = model.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {

                if (IdMapping.Value.Key != prop.Name)
                {




                    if (prop.GetValue(model, null) != null)
                    {
                        if (prop.PropertyType == typeof(string))
                        {
                            columns += $"{mapping[prop.Name]} ,";
                            values += $"'{prop.GetValue(model, null)}' ,";
                        }
                        if (prop.PropertyType == typeof(bool) && prop.GetValue(model, null) is bool value)
                        {
                            columns += $"{mapping[prop.Name]} ,";
                            if (value is true) { values += $"{1} ,"; }
                            if (value is false) { values += $"{0} ,"; }
                            if (value == null) { values += $"'{null}' ,"; }
                        }
                        if (prop.PropertyType == typeof(long) || prop.PropertyType == typeof(int))
                        {
                            columns += $"{mapping[prop.Name]} ,";
                            values += $"{prop.GetValue(model, null)} ,";
                        }
                        if (prop.PropertyType == typeof(DateTime))
                        {
                            columns += $"{mapping[prop.Name]} ,";
                            DateTime date = Convert.ToDateTime(prop.GetValue(model, null));
                            values += $"TO_DATE('{date.Year}/{date.Month}/{date.Day} {date.Hour}:{date.Minute}', 'yyyy/mm/dd hh24:mi'),";
                        }

                    }

                }
                else
                {
                    if (IdMapping.Key != null)
                    {
                        columns += $"{IdMapping.Key} ,";
                        values += $"{schema}.{IdMapping.Value.Value}.nextval ,";
                    }
                }
            }



            KeyValuePair<string, string> data = new KeyValuePair<string, string>(columns.Remove(columns.Length - 1), values.Remove(values.Length - 1));

            return data;
        }



        public string UpdateMethod<T>(T model)
        {
            //SchemaAttribute Schema = (SchemaAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(SchemaAttribute));
            //TableAttribute table = (TableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute));
            Dictionary<string, string> mapping = GetAttributeMapping<T>(model, "_mappings");
            KeyValuePair<string, KeyValuePair<string, string>> IdMapping = GetAttributeId<T>(model, "_id");
            string schema = GetStringAttribute<T>(model, "_schema");
            string table = GetStringAttribute<T>(model, "_table");
            string query = $"UPDATE {schema}.{table} SET ";


            string values = "";

            PropertyInfo[] props = model.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {

                if (IdMapping.Value.Key != prop.Name)
                {




                    if (prop.GetValue(model, null) != null)
                    {
                        if (prop.PropertyType == typeof(bool) && prop.GetValue(model, null) is bool value)
                        {
                            if (value is true) { values += $"{mapping[prop.Name]} ={1} ,"; }
                            if (value is false) { values += $"{mapping[prop.Name]} ={0} ,"; }
                            if (value == null) { values += $"{mapping[prop.Name]} ='{null}' ,"; }
                        }
                        if (prop.PropertyType == typeof(string))
                        {
                            //columns += $"{mapping[prop.Name]} ,";
                            values += $"{mapping[prop.Name]} = '{prop.GetValue(model, null)}' ,";
                        }
                        if (prop.PropertyType == typeof(long) || prop.PropertyType == typeof(int))
                        {
                            //columns += $"{mapping[prop.Name]} ,";
                            values += $"{mapping[prop.Name]} = {prop.GetValue(model, null)} ,";
                        }
                        if (prop.PropertyType == typeof(DateTime))
                        {
                            //columns += $"{mapping[prop.Name]} ,";
                            DateTime date = Convert.ToDateTime(prop.GetValue(model, null));
                            values += $"{mapping[prop.Name]} = TO_DATE('{date.Year}/{date.Month}/{date.Day} {date.Hour}:{date.Minute}', 'yyyy/mm/dd hh24:mi') ,";
                        }

                    }

                }
               
            }



            return $"{query}{values.Remove(values.Length - 1)}";
        }
    }
}