using System;
using CsvHelper.TypeConversion;
using GTFSimple.Core.Csv;
using GTFSimple.Core.Files;

namespace GTFSimple.Core.Feed
{
    [FeedFile("frequencies")]
    public class Frequency
    {
        [FieldName("trip_id")]
        public string TripId { get; set; }

        [FieldName("start_time")]
        public TimeSpan StartTime { get; set; }

        [FieldName("end_time")]
        public TimeSpan EndTime { get; set; }

        [FieldName("headway_secs"), TypeConverter(typeof(TimeSpanConverter))]
        public TimeSpan Headway { get; set; }

        [FieldName("exact_times"), TypeConverter(typeof(OneZeroConverter))]
        public bool? ExactTimes { get; set; }
    }
}