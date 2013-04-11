using System;

namespace GTFSimple.Core.Feed
{
    public class StopTime
    {
        public string TripId { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public string StopId { get; set; }
        public uint StopSequence { get; set; }
        public string StopHeadsign { get; set; }
        public StopPickupType? PickupType { get; set; } //better option?
        public StopDropOffType? DropOffType { get; set; } //better option?
        public decimal ShapeDistanceTraveled { get; set; } //better option?
    }

    public enum StopPickupType
    {
        Scheduled = 0,
        NotAvailable = 1,
        ArrangeByPhone = 2,
        ArrangeByDriver = 3,
    }

    public enum StopDropOffType
    {
        Scheduled = 0,
        NotAvailable = 1,
        ArrangeByPhone = 2,
        ArrangeByDriver = 3,
    }
}
