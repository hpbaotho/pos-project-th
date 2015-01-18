using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.DTO;
using System.Windows.Forms;
using System.Data;
using POS.BL.Entities;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;

namespace POS.BL.Utilities
{
    public static class ExtensionMethod
    {
        public static void SetPleaseSelect(this List<ComboBoxDTO> lstDTO)
        {
            lstDTO.Insert(0,new ComboBoxDTO() { Value = string.Empty, Display = GeneralMessage.PleaseSelect });
        }

        public static string ConvertDateToDisplay(this DateTime dt)
        {
            return dt.ToString(Format.DateFormat);
        }

        public static T ToDTO<T>(this DataRow dataRow) where T : new()
        {
            T DTO = new T();

            PropertyInfo[] properties = DTO.GetType().GetProperties();
            DataColumnCollection columns = dataRow.Table.Columns;

            foreach (PropertyInfo prop in properties)
            {
                foreach (DataColumn column in columns)
                {
                    if (prop.Name == column.ColumnName)
                    {
                        //Type dataRowType = dataRow[column.ColumnName]
                        if (dataRow[column.ColumnName] == null || dataRow[column.ColumnName] == DBNull.Value)
                        {
                            prop.SetValue(DTO, null, null);
                        }
                        else
                        {
                            object data = ChangeType(dataRow[column.ColumnName], prop.PropertyType);
                            prop.SetValue(DTO, data, null);
                        }
                        break;
                    }
                }
            }

            return DTO;
        }

        private static object ChangeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }

        public static void ToDataRow(this EntityBase entity, ref DataRow dataRow)
        {
            PropertyInfo[] properties = entity.GetType().GetProperties();
            DataColumnCollection columns = dataRow.Table.Columns;

            foreach (DataColumn column in columns)
            {
                foreach (PropertyInfo prop in properties)
                {
                    if (column.ColumnName == prop.Name)
                    {
                        dataRow[column.ColumnName] = prop.GetValue(entity, null);
                        break;
                    }
                }
            }
        }
    }


}
