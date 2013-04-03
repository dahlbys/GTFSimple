using System;

namespace GTFSimple.Core
{
    public class StopTime
    {
        public string TripId { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public string StopId { get; set; }
        public int StopSequence { get; set; }
        public string StopHeadsign { get; set; }
        public bool? PickupType { get; set; } //better option?
        public bool? DropOffType { get; set; } //better option?
        public decimal ShapeDistanceTraveled { get; set; } //better option?
    }
}

