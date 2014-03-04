using GTFSimple.Core.Csv;

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

        [FieldName("direction_id", Format = "{0:D}")]
        public TripDirection? DirectionId { get; set; }

        [FieldName("block_id")]
        public string BlockId { get; set; }

        [FieldName("shape_id")]
        public string ShapeId { get; set; }

        [FieldName("wheelchair_accessible", Format = "{0:D}")]
        public WheelchairAccessibility? WheelchairAccessible { get; set; }

        [FieldName("bikes_allowed", Format = "{0:D}")]
        public BikesAllowed? BikesAllowed { get; set; }
    }

    public enum TripDirection
    {
        Outbound = 0,
        Inbound = 1,
    }

    public enum BikesAllowed
    {
        Unspecified = 0,
        Allowed = 1,
        NotAllowed = 2,
    }
}