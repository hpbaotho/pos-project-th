using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Data;
using System.Reflection;
using System.Drawing;
using System.ComponentModel;

namespace Core.Standards.Converters
{
    public static class Converts
    {
        public static readonly CultureInfo ENGLISH_CULTURE_INFO = new CultureInfo("en-US");

        /// <summary>
        /// This function for convert number string to short type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static short ParseShort(string strNumber)
        {
            short returnShort;
            short.TryParse(strNumber, out returnShort);

            return returnShort;
        }

        /// <summary>
        /// This function for convert number string to integer type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static int ParseInt(string strNumber)
        {
            int returnInt;
            int.TryParse(strNumber, out returnInt);

            return returnInt;
        }
        public static int? ParseIntNullable(string strNumber)
        {
            int returnInt;
            if (!string.IsNullOrEmpty(strNumber))
            {
                if (int.TryParse(strNumber.Replace(",", ""), out returnInt)) return returnInt;
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// This function for convert number string to float type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static float ParseFloat(string strNumber)
        {
            float returnShort;
            float.TryParse(strNumber, out returnShort);

            return returnShort;
        }
        public static float? ParseFloatNullable(string strNumber)
        {
            float returnShort;

            return float.TryParse(strNumber, out returnShort) ? (float?)returnShort : null; ;
        }
        /// <summary>
        /// This function for convert number string to long type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static long ParseLong(string strNumber)
        {
            long returnLong;
            long.TryParse(strNumber, out returnLong);

            return returnLong;
        }
        public static long? ParseLongNullable(string strNumber)
        {
            long returnlong;
            if (!string.IsNullOrEmpty(strNumber))
            {
                if (long.TryParse(strNumber.Replace(",", ""), out returnlong)) return returnlong;
                else return null;
            }
            else return null;
        }
        /// <summary>
        /// This function for check decimal type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static bool isDecimal(string strNumber)
        {
            decimal returnDecimal;

            return decimal.TryParse(strNumber, out returnDecimal);
        }

        /// <summary>
        /// This function for convert number string to decimal type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static decimal ParseDecimal(string strNumber)
        {
            decimal returnDecimal;
            decimal.TryParse(strNumber, out returnDecimal);

            return returnDecimal;
        }

        /// <summary>
        /// This function for convert number string to decimal type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static decimal? ParseDecimalNullable(string strNumber)
        {
            decimal returnDecimal;

            return decimal.TryParse(strNumber, out returnDecimal) ? (decimal?)returnDecimal : null;
        }

        /// <summary>
        /// This function for convert number string to decimal type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static Single ParseSingle(string strNumber)
        {
            Single returnSingle;
            Single.TryParse(strNumber, out returnSingle);

            return returnSingle;
        }

        /// <summary>
        /// This function for convert number string to double type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static double ParseDouble(string strNumber)
        {
            double returnDouble;
            double.TryParse(strNumber, out returnDouble);

            return returnDouble;
        }
        public static double? ParseDoubleNullable(string strNumber)
        {
            double returnDouble;
            if (double.TryParse(strNumber, out returnDouble)) return returnDouble;
            else return null;
        }

        /// <summary>
        /// This function for convert number string to bool type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static bool? ParseBoolNullable(string strNumber)
        {
            bool returnBool;
            if (bool.TryParse(strNumber, out returnBool)) return returnBool;
            else return null;
        }

        /// <summary>
        /// This function for convert number string to bool type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static bool ParseBool(string strNumber)
        {
            bool returnBool;
            bool.TryParse(strNumber, out returnBool);

            return returnBool;
        }

        /// <summary>
        /// This function for convert string value to enum type.
        /// </summary>
        /// <param name="enumValue">Enum value to convert</param>
        /// <returns></returns>
        public static T ParseEnum<T>(string enumValue) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            if (string.IsNullOrEmpty(enumValue))
            {
                throw new InvalidCastException("No current mode set");
            }

            return (T)Enum.Parse(typeof(T), enumValue);
        }

        /// <summary>
        /// This function for convert date string to DateTime value.
        /// </summary>
        /// <param name="strDate">Input date string</param>
        /// <param name="format">Format of input date string</param>
        /// <returns></returns>
        public static DateTime? ParseDate(string strDate, string format)
        {
            DateTime? returnDate = null;
            if (!string.IsNullOrEmpty(strDate))
            {
                DateTime date = DateTime.MinValue;
                if (DateTime.TryParseExact(strDate, format, ENGLISH_CULTURE_INFO, DateTimeStyles.None, out date))
                    returnDate = date;
            }
            return returnDate;
        }

        /// <summary>
        /// This function for convert date string to DateTime value. (no format)
        /// </summary>
        /// <param name="strDate">Input date string</param>
        /// <param name="format">Format of input date string</param>
        /// <returns></returns>
        public static DateTime? ParseDate(string strDate)
        {
            DateTime? returnDate = null;
            if (!string.IsNullOrEmpty(strDate))
            {
                DateTime date = DateTime.MinValue;
                if (DateTime.TryParse(strDate, out date))
                    returnDate = date;
            }
            return returnDate;
        }

        /// <summary>
        /// This function for convert number string to decimal type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static decimal ToDecimal(this object decimalValue)
        {
            if (decimalValue == DBNull.Value) return 0;
            if (decimalValue == null) return 0;

            decimal returnDecimal;
            decimal.TryParse(decimalValue.ToString(), out returnDecimal);

            return returnDecimal;
        }

        /// <summary>
        /// This function for convert number string to double type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static double ToDouble(this object doubleValue)
        {
            if (doubleValue == DBNull.Value) return 0;
            if (doubleValue == null) return 0;

            double returnDouble;
            double.TryParse(doubleValue.ToString(), out returnDouble);

            return returnDouble;
        }

        /// <summary>
        /// This function for convert number string to long type.
        /// </summary>
        /// <param name="strNumber">Input string number</param>
        /// <returns></returns>
        public static long ToLong(this object longValue)
        {
            if (longValue == DBNull.Value) return 0;
            if (longValue == null) return 0;

            long returnLong;
            long.TryParse(longValue.ToString(), out returnLong);

            return returnLong;
        }

        /// <summary>
        /// This function for convert number string to int type.
        /// </summary>
        /// <param name="strNumber">Input int number</param>
        /// <returns></returns>
        public static int ToInt(this object intValue)
        {
            if (intValue == DBNull.Value) return 0;
            if (intValue == null) return 0;

            int returnInt;
            int.TryParse(intValue.ToString(), out returnInt);

            return returnInt;
        }

        /// <summary>
        /// This function for set format to number string.
        /// </summary>
        /// <param name="strNumber">Number string to set format</param>
        /// <param name="format">Output format of number string</param>
        /// <returns></returns>
        public static string ToDecimalString(object strNumber, string format)
        {
            if (strNumber == null)
            {
                return null;
            }
            return string.Format(format, ParseDecimal(strNumber.ToString()));
        }

        /// <summary>
        /// This function of convert date value to string in specific format.
        /// </summary>
        /// <param name="date">Input date</param>
        /// <param name="format">Format of output date string</param>
        /// <returns></returns>
        public static string ToDateString(object date, string format)
        {
            string result = null;
            DateTime? dateValue = date as DateTime?;
            if (dateValue.HasValue)
            {
                result = dateValue.Value.ToString(format, ENGLISH_CULTURE_INFO);
            }
            return result;
        }

        /// <summary>
        /// This function for convert Stream to Byte[].
        /// </summary>
        /// <param name="stream">Stream to convert</param>
        /// <returns>byte[]</returns>
        public static byte[] ToByteArray(this Stream stream)
        {
            //BinaryReader br = new BinaryReader(stream);
            //return br.ReadBytes(Utility.ParseInt(stream.Length.ToString()));

            long originalPosition = stream.Position;
            stream.Position = 0;

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }
                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                stream.Position = originalPosition;
            }
        }

        /// <summary>
        /// Convert boolean object into boolean value.
        /// </summary>
        /// <param name="boolean">Boolean object to be convert</param>
        /// <returns>
        ///		- Boolean value while input boolean object can be convert to boolean value.
        ///		- Null while input boolean object cannot convert to boolean value.
        ///	</returns>
        public static bool? ToBoolean(this object boolean)
        {
            if (boolean == null) return null;

            bool returnBool = false;
            if (bool.TryParse(boolean.ToString(), out returnBool))
            {
                return returnBool;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Convert number object into string with specific date format.
        /// </summary>
        /// <param name="date">Date object to be convert</param>
        /// <param name="format">Preferred date format for result string</param>
        /// <returns>
        ///		- Number string in specfic number format while value can be convert to number string.
        ///		- Null while number is invalid number value.
        /// </returns>
        public static string ToNumberString(this object number, string format)
        {
            if (number == null) return null;

            return string.Format(format, number.ToDecimal());
        }

        public static string SelectTextBySplit(string str, char splitChar, int index = 0)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(splitChar.ToString()) && str.Contains(splitChar))
            {
                string[] splitArray = str.Split(splitChar);
                if (splitArray.Length > 0 && splitArray.Length - 1 >= index)
                {
                    result = splitArray[index];
                }
            }
            return result;
        }
        public static List<string> SplitText(string str, char splitChar)
        {
            List<string> result = new List<string>();
            if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(splitChar.ToString()) && str.Contains(splitChar))
            {
                if (str.First() == splitChar)
                {
                    str = str.Substring(1, str.Length - 1);
                }
                if (str.Last() == splitChar)
                {
                    str = str.Substring(0, str.Length - 1);
                }

                if (!string.IsNullOrEmpty(str) && str.Contains(splitChar))
                {
                    result = str.Split(splitChar).ToList();
                }
                else if (!string.IsNullOrEmpty(str))
                {
                    result.Add(str);
                }
            }
            else if (!string.IsNullOrEmpty(str))
            {
                result.Add(str);
            }
            return result;
        }

        public static string ToStringNullable(this object stringValue)
        {
            if (stringValue == DBNull.Value) return string.Empty;
            if (stringValue == null) return string.Empty;

            return stringValue.ToString();
        }

        #region Converting ObjectArray to Datatable
        public static DataTable ConvertToDataTable(Object[] array)
        {
            PropertyInfo[] properties = array.GetType().GetElementType().GetProperties();
            DataSet ds = new DataSet();
            DataTable dt = CreateDataTable(properties);
            if (array.Length != 0)
            {
                foreach (object o in array)
                    FillData(properties, dt, o);
            }
            ds.Tables.Add(dt);
            return ds.Tables[0];
        }

        private static DataTable CreateDataTable(PropertyInfo[] properties)
        {
            DataTable dt = new DataTable();
            DataColumn dc = null;
            foreach (PropertyInfo pi in properties)
            {
                dc = new DataColumn();
                dc.ColumnName = pi.Name;
                dc.DataType = pi.PropertyType;
                dt.Columns.Add(dc);
            }
            return dt;
        }

        private static void FillData(PropertyInfo[] properties, DataTable dt, Object o)
        {
            DataRow dr = dt.NewRow();
            foreach (PropertyInfo pi in properties)
            {
                dr[pi.Name] = pi.GetValue(o, null);
            }
            dt.Rows.Add(dr);
        }

        #endregion
        public static Font ConvertStringToFont(string fontStr)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            Font font = (Font)converter.ConvertFromString(fontStr);
            return font;

        }
        
    }
}
