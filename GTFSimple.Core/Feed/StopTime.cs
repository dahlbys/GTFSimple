using System;

namespace GTFSimple.Core.Feed
{
    public class StopTime
    {
        [FieldName("trip_id")]
        public string TripId { get; set; }
        [FieldName("arrival_time")]
        public TimeSpan ArrivalTime { get; set; }
        [FieldName("departure_time")]
        public TimeSpan DepartureTime { get; set; }
        [FieldName("stop_id")]
        public string StopId { get; set; }
        [FieldName("stop_sequence")]
        public uint StopSequence { get; set; }
        [FieldName("stop_headsign")]
        public string StopHeadsign { get; set; }
        [FieldName("pickup_type")]
        public StopPickupType? PickupType { get; set; } //better option?
        [FieldName("drop_off_type")]
        public StopDropOffType? DropOffType { get; set; } //better option?
        [FieldName("shape_dist_traveled")]
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

