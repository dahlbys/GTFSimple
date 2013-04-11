using System;

namespace GTFSimple.Core.Feed
{
    public class Trip
    {
        [FieldName("route_id")]
        public string RouteId { get; set; }
        [FieldName("service_id")]
        public string ServiceId { get; set; }
        [FieldName("trip_id")]
        public string Id { get; set; }
        [FieldName("trip_headsign")]
        public string Headsign { get; set; }
        [FieldName("trip_short_name")]
        public string ShortName { get; set; }
        [FieldName("direction_id")]
        public bool? DirectionId { get; set; }
        [FieldName("block_id")]
        public string BlockId { get; set; }
        [FieldName("shape_id")]
        public string ShapeId { get; set; }
        [FieldName("wheelchair_accessible")]
        public WheelchairAccessibility? WheelchairAccessible { get; set; }
    }

    public enum TripDirection
    {
        Outbound = 0,
        Inbound = 1,
    }
}

