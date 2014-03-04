using System;
using System.Collections.Generic;
using CsvHelper.TypeConversion;
using GTFSimple.Core.Csv;

namespace GTFSimple.Core.Feed
{
    public class Calendar
    {
        [FieldName("service_id")]
        public string ServiceId { get; set; }

        [FieldName("monday"), TypeConverter(typeof(OneZeroConverter))]
        public bool Monday { get; set; }

        [FieldName("tuesday"), TypeConverter(typeof(OneZeroConverter))]
        public bool Tuesday { get; set; }

        [FieldName("wednesday"), TypeConverter(typeof(OneZeroConverter))]
        public bool Wednesday { get; set; }

        [FieldName("thursday"), TypeConverter(typeof(OneZeroConverter))]
        public bool Thursday { get; set; }

        [FieldName("friday"), TypeConverter(typeof(OneZeroConverter))]
        public bool Friday { get; set; }

        [FieldName("saturday"), TypeConverter(typeof(OneZeroConverter))]
        public bool Saturday { get; set; }

        [FieldName("sunday"), TypeConverter(typeof(OneZeroConverter))]
        public bool Sunday { get; set; }

        [FieldName("start_date", Format = "{0:yyyyMMdd}")]
        public DateTime StartDate { get; set; }

        [FieldName("end_date", Format = "{0:yyyyMMdd}")]
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return string.Format("{0} for {1:yyyy-MM-dd} to {2:yyyy-MM-dd}: {3}",
                                 ServiceId, StartDate, EndDate, string.Join("", Days));
        }

        private IEnumerable<string> Days
        {
            get
            {
                if (Monday)
                    yield return "M";
                if (Tuesday)
                    yield return "T";
                if (Wednesday)
                    yield return "W";
                if (Thursday)
                    yield return "H";
                if (Friday)
                    yield return "F";
                if (Saturday)
                    yield return "S";
                if (Sunday)
                    yield return "U";
            }
        }
    }
}