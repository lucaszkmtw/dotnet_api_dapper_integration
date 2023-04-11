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
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
    public class QueryConstructor : GenericFunction
    {
     
        public string[] TypeList = { "String", "Int64", "Int32", "DateTime" };
        public string SelectAll()
        {
            string select = "SELECT ";

            return select;
        }
        public string AddParaMeters<T>()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            string attributtes = "";
            T instance = Activator.CreateInstance<T>();
            Dictionary<string, string> mapping = GetAttributeMapping<T>(instance, "_mappings");
            KeyValuePair<string,KeyValuePair<string,string>> IdMapping = GetAttributeId<T>(instance, "_id");
            attributtes = attributtes + IdMapping.Value.Key + " AS " + IdMapping.Key + ",";

            foreach (KeyValuePair<string,string> property in mapping)
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
        public string FromTableAndSchema<T>()
        {
            T instance = Activator.CreateInstance<T>();

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


        public string IdMethod<T>(object id)
        {
            T instance = Activator.CreateInstance<T>();
            PropertyInfo[] properties = typeof(T).GetProperties();
            //properties.Where()
            string idEntity = "";
            foreach (PropertyInfo property in properties)
            {

                KeyValuePair<string, KeyValuePair<string, string>> IdMapping = GetAttributeId<T>(instance, "_id");
                {
                    idEntity = IdMapping.Value.Key;
                }

            }
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

        public string InsertMethod<T>()
        {

            //Type attributesModel = model.GetType();
            SchemaAttribute Schema = (SchemaAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(SchemaAttribute));
            TableAttribute table = (TableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute));
            string query = $"INSERT INTO {Schema.name}.{table.name} ";

            return query;

        }




        public KeyValuePair<string, string> ColumnsAndValues<T>(T model)
        {
            SchemaAttribute Schema = (SchemaAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(SchemaAttribute));
            TableAttribute table = (TableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute));
            string values = "";
            string columns = "";
            PropertyInfo[] props = model.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if ((IdModel)Attribute.GetCustomAttribute(prop, typeof(IdModel)) != null)
                {
                    IdModel propAttribute = (IdModel)Attribute.GetCustomAttribute(prop, typeof(IdModel));

                    columns += $"{propAttribute.Id} ,";
                    values += $"{Schema.name}.{propAttribute.sequence}.nextval ,";
                    //if(propAttribute.sequence= "")
                    //{


                    //}
                }
                else
                {
                    if (prop.GetValue(model, null) != null)
                    {
                        if (prop.PropertyType == typeof(string))
                        {
                            ColumnAttribute propAttribute = (ColumnAttribute)Attribute.GetCustomAttribute(prop, typeof(ColumnAttribute));
                            columns += $"{propAttribute.name} ,";
                            values += $"'{prop.GetValue(model, null)}' ,";
                        }
                        if (prop.PropertyType == typeof(long) || prop.PropertyType == typeof(int))
                        {
                            ColumnAttribute propAttribute = (ColumnAttribute)Attribute.GetCustomAttribute(prop, typeof(ColumnAttribute));
                            columns += $"{propAttribute.name} ,";
                            values += $"{prop.GetValue(model, null)} ,";
                        }
                        if (prop.PropertyType == typeof(DateTime))
                        {
                            ColumnAttribute propAttribute = (ColumnAttribute)Attribute.GetCustomAttribute(prop, typeof(ColumnAttribute));
                            columns += $"{propAttribute.name} ,";
                            DateTime date = Convert.ToDateTime(prop.GetValue(model, null));
                            values += $"TO_DATE('{date.Year}/{date.Month}/{date.Day} {date.Hour}:{date.Minute}', 'yyyy/mm/dd hh24:mi'),";
                        }

                    }

                }
            }
            KeyValuePair<string, string> data = new KeyValuePair<string, string>(columns.Remove(columns.Length - 1), values.Remove(values.Length - 1));

            return data;
        }



        public string UpdateMethod<T>(T model)
        {
            SchemaAttribute Schema = (SchemaAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(SchemaAttribute));
            TableAttribute table = (TableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute));
            string query = $"UPDATE {Schema.name}.{table.name} SET ";


            string values = "";
           
            PropertyInfo[] props = model.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if ((IdModel)Attribute.GetCustomAttribute(prop, typeof(IdModel)) != null){}
                else
                {
                    if (prop.GetValue(model, null) != null)
                    {
                        if (prop.PropertyType == typeof(string))
                        {
                            ColumnAttribute propAttribute = (ColumnAttribute)Attribute.GetCustomAttribute(prop, typeof(ColumnAttribute));
                            values += $"{propAttribute.name} = '{prop.GetValue(model, null)}' ,";
                        }
                        if (prop.PropertyType == typeof(long) || prop.PropertyType == typeof(int))
                        {
                            ColumnAttribute propAttribute = (ColumnAttribute)Attribute.GetCustomAttribute(prop, typeof(ColumnAttribute));

                            values += $"{propAttribute.name} = {prop.GetValue(model, null)} ,";
                        }
                        if (prop.PropertyType == typeof(DateTime))
                        {
                            ColumnAttribute propAttribute = (ColumnAttribute)Attribute.GetCustomAttribute(prop, typeof(ColumnAttribute));
                            DateTime date = Convert.ToDateTime(prop.GetValue(model, null));
                            values += $"{propAttribute.name} = TO_DATE('{date.Year}/{date.Month}/{date.Day} {date.Hour}:{date.Minute}', 'yyyy/mm/dd hh24:mi') ,";
                        }

                    }

                }
            }




            return $"{query}{values.Remove(values.Length - 1)}";
        }
    }
}