using System;
using System.Collections.Generic;
using CsvHelper.TypeConversion;
using GTFSimple.Core.Csv;
using GTFSimple.Core.Files;

namespace GTFSimple.Core.Feed
{
    [FeedFile("calendar")]
    public class Calendar
    {
        [FieldName("service_id")]
        public string ServiceId { get; set; }

        [FieldName("monday"), TypeConverter(typeof(BooleanOneZeroConverter))]
        public bool Monday { get; set; }

        [FieldName("tuesday"), TypeConverter(typeof(BooleanOneZeroConverter))]
        public bool Tuesday { get; set; }

        [FieldName("wednesday"), TypeConverter(typeof(BooleanOneZeroConverter))]
        public bool Wednesday { get; set; }

        [FieldName("thursday"), TypeConverter(typeof(BooleanOneZeroConverter))]
        public bool Thursday { get; set; }

        [FieldName("friday"), TypeConverter(typeof(BooleanOneZeroConverter))]
        public bool Friday { get; set; }

        [FieldName("saturday"), TypeConverter(typeof(BooleanOneZeroConverter))]
        public bool Saturday { get; set; }

        [FieldName("sunday"), TypeConverter(typeof(BooleanOneZeroConverter))]
        public bool Sunday { get; set; }

        [FieldName("start_date"), TypeConverter(typeof(DateConverter))]
        public DateTime StartDate { get; set; }

        [FieldName("end_date"), TypeConverter(typeof(DateConverter))]
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