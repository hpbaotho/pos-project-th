﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
namespace Core.Standards.Extensions
{
    public static class TypeExtension
    {
        public static bool IsNullable(this Type type)
        {
            return ((type.IsGenericType) && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
        }

        public static IEnumerable<string> AppendAll(this IEnumerable<string> text, string prefix, string suffix)
        {
            foreach (string s in text)
            {
                yield return string.Format("{0}{1}{2}", prefix, s, suffix);
            }
        }

        public static void ApplyAll(this IEnumerable items, string propertyName, object data)
        {
            foreach (var item in items)
            {
                PropertyInfo property = item.GetType().GetProperty(propertyName);
                if (property == null) throw new NullReferenceException();
                if (!property.CanWrite) throw new InvalidOperationException(string.Format("Property or indexer '{0}' cannot be assign to, it is read only.", property.Name));

                property.SetValue(item, TypeExtension.ChangeType(data, property.PropertyType), null);
                //yield return item;
            }
        }
        public static IEnumerable<TResult> ConvertAll<TResult>(this IEnumerable items)
        {
            foreach (var item in items)
            {
                yield return (TResult)TypeExtension.ChangeType(item, typeof(TResult));
            }
        }
        public static object ChangeType(object value, Type conversionType)
        {
            // Note: This if block was taken from Convert.ChangeType as is, and is needed here since we're
            // checking properties on conversionType below.
            if (conversionType == null)
            {
                throw new ArgumentNullException("conversionType");
            }
            // end if

            if (conversionType.IsEnum)
            {
                return ConvertToEnumType(value, conversionType);
            }

            // If it's not a nullable type, just pass through the parameters to Convert.ChangeType
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                // It's a nullable type, so instead of calling Convert.ChangeType directly which would throw a
                // InvalidCastException (per http://weblogs.asp.net/pjohnson/archive/2006/02/07/437631.aspx),
                // determine what the underlying type is
                // If it's null, it won't convert to the underlying type, but that's fine since nulls don't really
                // have a type--so just return null
                // Note: We only do this check if we're converting to a nullable type, since doing it outside
                // would diverge from Convert.ChangeType's behavior, which throws an InvalidCastException if
                // value is null and conversionType is a value type.
                if (value == null)
                {
                    return null;
                } // end if

                // It's a nullable type, and not null, so that means it can be converted to its underlying type,
                // so overwrite the passed-in conversion type with this underlying type
                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            } // end if

            // Now that we've guaranteed conversionType is something Convert.ChangeType can handle (i.e. not a
            // nullable type), pass the call on to Convert.ChangeType
            return Convert.ChangeType(value, conversionType);
        }

        private static object ConvertToEnumType(object value, Type type)
        {
            if (value is string)
            {
                return Enum.Parse(type, value as string);
            }
            else
            {
                if (!Enum.IsDefined(type, value))
                {
                    throw new FormatException("Undefined value for enum type");
                }

                return Enum.ToObject(type, value);
            }
        }
    }
}
