using System;

namespace GTFSimple.Core
{
    public class Trip
    {
        public string RouteId { get; set; }
        public string ServiceId { get; set; }
        public string Id { get; set; }
        public string Headsign { get; set; }
        public string ShortName { get; set; }
        public bool? DirectionId { get; set; }
        public string BlockId { get; set; }
        public string ShapeId { get; set; }
        public WheelchairAccessibility? WheelchairAccessible { get; set; }
    }

    public enum TripDirection
    {
        Outbound = 0,
        Inbound = 1,
    }
}

