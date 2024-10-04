using System;

namespace VietNamNet.Framework.Common
{
    public class Nulls
    {
        public static DateTime DateTime = new DateTime(0x76c, 1, 1);
        public static decimal Decimal = Decimal.MinValue;
        public static double Double = double.NaN;
        public static float Float = float.NaN;
        public static Guid Guid = Guid.Empty;
        public static int Int = -2147483648;
        public static string String = null;

        public static bool IsNullOrEmpty(object value)
        {
            bool flag = false;
            if (value == null)
            {
                return true;
            }
            if (value.GetType() == typeof (string))
            {
                string str = (string) value;
                if (str == "")
                {
                    return true;
                }
                if (str.Equals(String))
                {
                    flag = true;
                }
                return flag;
            }
            if (value.GetType() == typeof (Guid))
            {
                Guid guid = (Guid) value;
                if (guid.Equals(Guid))
                {
                    flag = true;
                }
                return flag;
            }
            if (value.GetType() == typeof (DateTime))
            {
                DateTime time = (DateTime) value;
                if (time.Equals(DateTime))
                {
                    flag = true;
                }
                return flag;
            }
            if (value.GetType() == typeof (int))
            {
                int num = (int) value;
                if (num.Equals(Int))
                {
                    flag = true;
                }
                return flag;
            }
            if (value.GetType() == typeof (decimal))
            {
                decimal num2 = (decimal) value;
                if (num2.Equals(Decimal))
                {
                    flag = true;
                }
                return flag;
            }
            if (value.GetType() == typeof (double))
            {
                double num3 = (double) value;
                if (num3.Equals(Double))
                {
                    flag = true;
                }
                return flag;
            }
            if (value.GetType() == typeof (float))
            {
                float num4 = (float) value;
                if (num4.Equals(Float))
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}