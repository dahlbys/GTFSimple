using System;

namespace GTFSimple.Core.Feed
{
    public class CalendarDate
    {
        public string ServiceId { get; set; }
        public DateTime Date { get; set; }
        public bool ExceptionType { get; set; }
    }

    public enum ExceptionType
    {
        Added = 1,
        Removed = 2,
    }
}
