using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Generic
{
    public class GenericFunction
    {
        public Dictionary<string, string> GetAttributeMapping<T>(T instance, string attributeName)
        {
            Dictionary<string, string> attributeDictionary = new Dictionary<string, string>();

            Type type = instance.GetType();
            PropertyInfo propertyInfo = type.GetProperty(attributeName);
            if (propertyInfo != null)
            {
                var value = propertyInfo.GetValue(instance);
                return attributeDictionary;
            }
            else
            {
                FieldInfo fieldInfo = type.GetField(attributeName);
                if (fieldInfo != null)
                {
                    object value = fieldInfo.GetValue(instance);
                    if (value is Dictionary<string,string> dictionary)
                    {
                        attributeDictionary = dictionary;
                    }
                   
                    return attributeDictionary;
                }
            }
            return null;
        }
        public KeyValuePair<string, KeyValuePair<string,string>> GetAttributeId<T>(T instance, string attributeName)
        {
            KeyValuePair<string, KeyValuePair<string, string>> attributeDictionary = new KeyValuePair<string, KeyValuePair<string, string>>();
            Type type = instance.GetType();
            PropertyInfo propertyInfo = type.GetProperty(attributeName);
            if (propertyInfo != null)
            {
                var value = propertyInfo.GetValue(instance);
                if (value is KeyValuePair<string, KeyValuePair<string, string>> dictionary) {
                    attributeDictionary = dictionary;
                }
                    
                return attributeDictionary;
            }
            else
            {
                FieldInfo fieldInfo = type.GetField(attributeName);
                if (fieldInfo != null)
                {
                    object value = fieldInfo.GetValue(instance);
                    if (value is KeyValuePair<string, KeyValuePair<string, string>> dictionary)
                    {
                        attributeDictionary = dictionary;
                    }

                    return attributeDictionary;
                }
            }
            return attributeDictionary;
        }

        public string GetStringAttribute<T>(T instance, string attributeName)
        {
            Type type = typeof(T);
            FieldInfo fieldInfo = type.GetField(attributeName);
            if (fieldInfo != null)
            {
                object value = fieldInfo.GetValue(instance);
                if (value != null)
                {
                    return value.ToString();
                }
            }
            return null;
        }


        public static T CreateInstance<T>(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }
    }
}
