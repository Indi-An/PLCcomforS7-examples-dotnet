using PLCcom.Core.S7Plus.DataTypes;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace PLCCom_Full_Test_App
{
    class Utilities
    {
         [DebuggerStepThrough()]
        internal static sValues_to_Write CheckValues(String ValueString, PLCcom.eDataType ValueType)
        {
            sValues_to_Write Result = new sValues_to_Write();
            try
            {

                //convert PLCcomModbus.Core.eDataType to .Net type
                Type T = PLCComDataTypeToNetType(ValueType);

                if ((string.IsNullOrEmpty(ValueString) && ValueType != PLCcom.eDataType.S7_STRING && ValueType != PLCcom.eDataType.S7_WSTRING) || T == null)
                {
                    Result.ParseError = true;
                    return Result;
                }

                if (ValueType.Equals(PLCcom.eDataType.TIME_OF_DAY))
                {
                    Result.values.Add(TimeSpan.FromMilliseconds(Convert.ToDouble(ValueString)));
                }

                else if (ValueType.Equals(PLCcom.eDataType.LTIME_OF_DAY))
                {
                    Result.values.Add(TimeSpan64.Parse(ValueString));
                }

                else if (ValueType.Equals(PLCcom.eDataType.TIME))
                {
                    Result.values.Add(TimeSpan.FromMilliseconds(Convert.ToDouble(ValueString)));
                }

                else if (ValueType.Equals(PLCcom.eDataType.LTIME))
                {
                    Result.values.Add(TimeSpan64.FromNanoSeconds((Convert.ToInt64(ValueString))));
                }


                else if (ValueType.Equals(PLCcom.eDataType.DTL))
                {
                    string mainPart = ValueString.Substring(0, 19);

                    string nanoPart = "0";
                    if (ValueString.Length > 19)
                        nanoPart = ValueString.Substring(20);

                    if (DateTime.TryParse(mainPart, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                    {
                        int nanoseconds = int.Parse(nanoPart, CultureInfo.InvariantCulture);

                        Result.values.Add( new DateTime64(dt.Year,dt.Month, dt.Day, dt.Hour, dt.Minute,dt.Second, nanoseconds / 1_000_000, (nanoseconds / 1_000) % 1_000, nanoseconds % 1_000));
                    }
                    else
                    {
                        throw new ArgumentException("The specified format could not be recognized as date/time.");
                    }

                }

                else
                {
                    TypeConverter tc = TypeDescriptor.GetConverter(T);
                    //split and parse string
                    char[] Separator = "\n".ToCharArray();
                    ValueString = ValueString.Replace("\r\n", "\n").TrimEnd(Separator);
                    string[] rawValues = ValueString.Split(Separator);
                    foreach (string ValuePart in rawValues)
                    {
                        try
                        {
                            Result.values.Add(tc.ConvertFromString(ValuePart));
                        }
                        catch (FormatException)
                        {
                            Result.ParseError = true;
                            return Result;
                        }
                    }
                }
                return Result;
            }
            catch (Exception)
            {
                Result.ParseError = true;
                return Result;
            }
        }

        [DebuggerStepThrough()]
        internal static sValues_to_Write CheckValues(String ValueString, Type ValueType)
        {
            sValues_to_Write Result = new sValues_to_Write();
            try
            {
                if (string.IsNullOrEmpty(ValueString) || ValueType == null)
                {
                    Result.ParseError = true;
                    return Result;
                }

                TypeConverter tc = TypeDescriptor.GetConverter(ValueType);
                char[] Separator = { ';' };
                ValueString = ValueString.TrimEnd(Separator);
                string[] rawValues = ValueString.Split(Separator);
                foreach (string ValuePart in rawValues)
                {
                    try
                    {
                        Result.values.Add(tc.ConvertFromString(ValuePart));
                    }
                    catch (FormatException)
                    {
                        Result.ParseError = true;
                        return Result;
                    }
                }
                return Result;
            }
            catch (Exception)
            {
                Result.ParseError = true;
                return Result;
            }
        }

        internal class sValues_to_Write
        {
            //internal List<object> values = new List<object>();
            internal System.Collections.ArrayList values = new System.Collections.ArrayList();
            internal bool ParseError;
        }

        /// <summary>
        /// convert PLCcom.eDataType to .Net type
        /// </summary>
        /// <param name="ValueType">a PLCcom.eDataType member</param>
        /// <returns>System.Type</returns>
        internal static Type PLCComDataTypeToNetType(PLCcom.eDataType ValueType)
        {
            switch (ValueType)
            {
                case PLCcom.eDataType.BIT:
                    return typeof(bool);
                case PLCcom.eDataType.BYTE:
                    return typeof(byte);
                case PLCcom.eDataType.INT:
                    return typeof(short);
                case PLCcom.eDataType.DINT:
                    return typeof(int);
                case PLCcom.eDataType.LINT:
                    return typeof(long);
                case PLCcom.eDataType.WORD:
                    return typeof(ushort);
                case PLCcom.eDataType.DWORD:
                    return typeof(uint);
                case PLCcom.eDataType.LWORD:
                    return typeof(ulong);
                case PLCcom.eDataType.REAL:
                    return typeof(float);
                case PLCcom.eDataType.LREAL:
                    return typeof(double);
                case PLCcom.eDataType.RAWDATA:
                    return typeof(byte);
                case PLCcom.eDataType.BCD8:
                    return typeof(byte);
                case PLCcom.eDataType.BCD16:
                    return typeof(short);
                case PLCcom.eDataType.BCD32:
                    return typeof(int);
                case PLCcom.eDataType.BCD64:
                    return typeof(long);
                case PLCcom.eDataType.DATETIME:
                case PLCcom.eDataType.DATE_AND_TIME:
                    return typeof(DateTime);
                case PLCcom.eDataType.DTL:
                    return typeof(DateTime64);
                case PLCcom.eDataType.LDATE_AND_TIME:
                    return typeof(DateTime64);
                case PLCcom.eDataType.S5TIME:
                    return typeof(TimeSpan);
                case PLCcom.eDataType.STRING:
                case PLCcom.eDataType.S7_STRING:
                case PLCcom.eDataType.S7_WSTRING:
                    return typeof(string);
                case PLCcom.eDataType.TIME_OF_DAY:
                    return typeof(TimeSpan);
                case PLCcom.eDataType.LTIME_OF_DAY:
                    return typeof(TimeSpan64);
                case PLCcom.eDataType.TIME:
                    return typeof(TimeSpan);
                case PLCcom.eDataType.LTIME:
                    return typeof(TimeSpan64);
                case PLCcom.eDataType.DATE:
                    return typeof(DateTime);
                default:
                    return null;
            }
        }
    }
}
