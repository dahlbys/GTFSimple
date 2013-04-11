using System;

namespace GTFSimple.Core.Feed
{
    public class Frequency
    {
        public string TripId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan HeadwaySecs { get; set; }
        public bool? ExactTimes { get; set; }
    }
}
