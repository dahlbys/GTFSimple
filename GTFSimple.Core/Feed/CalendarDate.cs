using System;

namespace GTFSimple.Core.Feed
{
    public class CalendarDate
    {
        [FieldName("service_id")]
        public string ServiceId { get; set; }
        [FieldName("date")]
        public DateTime Date { get; set; }
        [FieldName("exception_type")]
        public bool ExceptionType { get; set; }
    }

    public enum ExceptionType
    {
        Added = 1,
        Removed = 2,
    }
}

