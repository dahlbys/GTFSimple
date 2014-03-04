using System;
using CsvHelper.TypeConversion;

namespace GTFSimple.Core.Csv
{
    internal class OneZeroConverter : DefaultTypeConverter
    {
        public override bool CanConvertFrom(Type type)
        {
            return type == typeof(bool);
        }

        public override string ConvertToString(object value)
        {
            if (value is bool)
                return (bool)value ? "1" : "0";

            return base.ConvertToString(value);
        }
    }

    internal class TimeSpanConverter : DefaultTypeConverter
    {
        public override bool CanConvertFrom(Type type)
        {
            return type == typeof(TimeSpan);
        }

        public override string ConvertToString(object value)
        {
            if (value is TimeSpan)
                return ((TimeSpan)value).TotalSeconds.ToString();

            return base.ConvertToString(value);
        }
    }
}