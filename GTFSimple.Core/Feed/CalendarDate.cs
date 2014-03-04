using System;
using GTFSimple.Core.Csv;

namespace GTFSimple.Core.Feed
{
    public class CalendarDate
    {
        [FieldName("service_id")]
        public string ServiceId { get; set; }

        [FieldName("date", Format = "{0:yyyyMMdd}")]
        public DateTime Date { get; set; }

        [FieldName("exception_type", Format = "{0:D}")]
        public ExceptionType ExceptionType { get; set; }
    }

    public enum ExceptionType
    {
        Added = 1,
        Removed = 2,
    }
}