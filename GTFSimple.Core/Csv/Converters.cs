using System;
using System.Globalization;
using CsvHelper.TypeConversion;

namespace GTFSimple.Core.Csv
{
    internal class DateConverter : GenericTypeConverter<DateTime>
    {
        protected override string Format(CultureInfo culture, DateTime value)
        {
            return value.ToString("yyyyMMdd");
        }

        protected override DateTime Parse(CultureInfo culture, string text)
        {
            return DateTime.ParseExact(text, "yyyyMMdd", culture, DateTimeStyles.None);
        }
    }

    internal class BooleanOneZeroConverter : GenericTypeConverter<bool?>
    {
        protected override string Format(CultureInfo culture, bool? value)
        {
            return value == null ? "" : value.Value ? "1" : "0";
        }

        protected override bool? Parse(CultureInfo culture, string text)
        {
            switch (text)
            {
                case "1":
                    return true;
                case "0":
                    return false;
                case null:
                    return null;
                default:
                    throw new NotSupportedException("The conversion cannot be performed.");
            }
        }
    }

    internal class TimeSpanSecondsConverter : GenericTypeConverter<TimeSpan?>
    {
        protected override string Format(CultureInfo culture, TimeSpan? value)
        {
            return value == null ? "" : value.Value.TotalSeconds.ToString(culture);
        }

        protected override TimeSpan? Parse(CultureInfo culture, string text)
        {
            return new TimeSpan(0, 0, int.Parse(text, culture));
        }
    }

    internal class TimeSpanHourMinuteSecondConverter : GenericTypeConverter<TimeSpan?>
    {
        protected override string Format(CultureInfo culture, TimeSpan? value)
        {
            return value == null ? "" : value.Value.ToString("c");
        }

        protected override TimeSpan? Parse(CultureInfo culture, string text)
        {
            return TimeSpan.Parse(text, culture);
        }
    }

    internal class UriConverter : GenericTypeConverter<Uri>
    {
        protected override string Format(CultureInfo culture, Uri value)
        {
            return value == null ? "" : value.ToString();
        }

        protected override Uri Parse(CultureInfo culture, string text)
        {
            return new Uri(text);
        }
    }

    internal abstract class GenericTypeConverter<T> : DefaultTypeConverter
    {
        protected abstract string Format(CultureInfo culture, T value);

        protected abstract T Parse(CultureInfo culture, string text);

        public override bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public override bool CanConvertTo(Type type)
        {
            return type == typeof(string);
        }

        public override object ConvertFromString(CultureInfo culture, string text)
        {
            return string.IsNullOrEmpty(text) ? default(T) : Parse(culture, text);
        }

        public override object ConvertFromString(string text)
        {
            return ConvertFromString(CultureInfo.InvariantCulture, text);
        }

        public override string ConvertToString(CultureInfo culture, object value)
        {
            return Format(culture, (T)value);
        }
    }
}