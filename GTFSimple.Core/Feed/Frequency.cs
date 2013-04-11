using System;

namespace GTFSimple.Core.Feed
{
    public class Frequency
    {
        [FieldName("trip_id")]
        public string TripId { get; set; }
        [FieldName("start_time")]
        public TimeSpan StartTime { get; set; }
        [FieldName("end_time")]
        public TimeSpan EndTime { get; set; }
        [FieldName("headway_secs")]
        public TimeSpan HeadwaySecs { get; set; }
        [FieldName("exact_times")]
        public bool? ExactTimes { get; set; }
    }
}

