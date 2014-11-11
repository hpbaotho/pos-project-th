using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Core.Standards.Attributes
{
    public static class AttributeUtility
    {
        public static TAttribute GetCustomAttribute<TAttribute>(this Type type, bool inherit)
        {
            return (TAttribute)type.GetCustomAttributes(inherit).Where(obj => obj.GetType() == typeof(TAttribute)).FirstOrDefault();
        }

        public static TAttribute GetFieldCustomAttribute<TAttribute>(this Type type, string fieldName, bool inherit)
        {
            return (TAttribute)type.GetField(fieldName).GetCustomAttributes(inherit).Where(obj => obj.GetType() == typeof(TAttribute)).FirstOrDefault();
        }

        public static TAttribute GetPropertyCustomAttribute<TAttribute>(this Type type, string propertyName, bool inherit)
        {
            return (TAttribute)type.GetProperty(propertyName).GetCustomAttributes(inherit).Where(obj => obj.GetType() == typeof(TAttribute)).FirstOrDefault();
        }

        public static bool IsTaggedWithAttribute<TAttribute>(this Type type, bool inherit)
        {
            TAttribute attribute = GetCustomAttribute<TAttribute>(type, inherit);
            return attribute != null;
        }

        public static bool IsFieldTaggedWithAttribute<TAttribute>(this Type type, string fieldName, bool inherit)
        {
            TAttribute attribute = GetFieldCustomAttribute<TAttribute>(type, fieldName, inherit);
            return attribute != null;
        }

        public static bool IsPropertyTaggedWithAttribute<TAttribute>(this Type type, string propertyName, bool inherit)
        {
            TAttribute attribute = GetPropertyCustomAttribute<TAttribute>(type, propertyName, inherit);
            return attribute != null;
        }
        public static bool IsPropertyTaggedWithAttribute<TAttribute>(this Type type, PropertyInfo property, string attributePropertyName, object attributePropertyValue, bool inherit)
        {
            TAttribute attribute = type.GetPropertyCustomAttribute<TAttribute>(property.Name, inherit);
            if (attribute == null) return false;

            PropertyInfo attributeInfo = attribute.GetType().GetProperty(attributePropertyName);
            if (attributeInfo == null) return false;

            return attributeInfo.GetValue(attribute, null).Equals(attributePropertyValue);
        }

        public static IList<PropertyInfo> GetTaggedPropertyInfos<TAttribute>(this Type type, bool inherit)
        {
            IList<PropertyInfo> results = new List<PropertyInfo>();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (type.IsPropertyTaggedWithAttribute<TAttribute>(propertyInfo.Name, inherit))
                {
                    results.Add(propertyInfo);
                }
            }

            return results;
        }

        public static IList<PropertyInfo> GetTaggedPropertyInfos<TAttribute>(this Type type, string attributePropertyName, object attributePropertyValue, bool inherit)
        {
            IList<PropertyInfo> results = new List<PropertyInfo>();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (type.IsPropertyTaggedWithAttribute<TAttribute>(propertyInfo.Name, inherit))
                {
                    TAttribute attribute = type.GetPropertyCustomAttribute<TAttribute>(propertyInfo.Name, true);
                    PropertyInfo attributeInfo = attribute.GetType().GetProperty(attributePropertyName);
                    if ((attributeInfo != null) && (attributeInfo.GetValue(attribute, null).Equals(attributePropertyValue)))
                    {
                        results.Add(propertyInfo);
                    }
                }
            }

            return results;
        }
    }
}
