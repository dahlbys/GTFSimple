using System;
using CsvHelper.TypeConversion;
using GTFSimple.Core.Csv;
using GTFSimple.Core.Files;

namespace GTFSimple.Core.Feed
{
    [FeedFile("calendar_dates")]
    public class CalendarDate
    {
        [FieldName("service_id")]
        public string ServiceId { get; set; }

        [FieldName("date"), TypeConverter(typeof(DateConverter))]
        public DateTime Date { get; set; }

        [FieldName("exception_type", Format = "{0:D}")]
        public ExceptionType ExceptionType { get; set; }

        public override string ToString()
        {
            return string.Format("{0} on {1:yyyy-MM-dd}: {2}",
                                 ServiceId, Date, ExceptionType);
        }
    }

    public enum ExceptionType
    {
        Added = 1,
        Removed = 2,
    }
}