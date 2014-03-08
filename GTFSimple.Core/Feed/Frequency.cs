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

        [FieldName("start_time"), TypeConverter(typeof(TimeSpanHourMinuteSecondConverter))]
        public TimeSpan StartTime { get; set; }

        [FieldName("end_time"), TypeConverter(typeof(TimeSpanHourMinuteSecondConverter))]
        public TimeSpan EndTime { get; set; }

        [FieldName("headway_secs"), TypeConverter(typeof(TimeSpanSecondsConverter))]
        public TimeSpan Headway { get; set; }

        [FieldName("exact_times"), TypeConverter(typeof(BooleanOneZeroConverter))]
        public bool? ExactTimes { get; set; }
    }
}