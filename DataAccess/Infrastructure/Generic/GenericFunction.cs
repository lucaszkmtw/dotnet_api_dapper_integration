using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Generic
{
    public class GenericFunction
    {
        public object GetAttributeValue<T>(T instance, string attributeName)
        {
            Type type = instance.GetType();
            PropertyInfo propertyInfo = type.GetProperty(attributeName);
            if (propertyInfo != null)
            {
                var value = propertyInfo.GetValue(instance);
                return value;
            }
            else
            {
                FieldInfo fieldInfo = type.GetField(attributeName);
                if (fieldInfo != null)
                {
                   object value = fieldInfo.GetValue(instance);
                    return value;
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
