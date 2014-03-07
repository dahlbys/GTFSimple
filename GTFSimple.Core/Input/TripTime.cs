using System;
using GTFSimple.Core.Csv;
using GTFSimple.Core.Feed;
using GTFSimple.Core.Files;

namespace GTFSimple.Core.Input
{
    [FeedFile("trip_times")]
    public class TripTime
    {
        [FieldName("route_id")]
        public string RouteId { get; set; }

        [FieldName("shape_id")]
        public string ShapeId { get; set; }

        [FieldName("service_id")]
        public string ServiceId { get; set; }

        [FieldName("start_time")]
        public TimeSpan StartTime { get; set; }

        [FieldName("trip_headsign")]
        public string Headsign { get; set; }

        [FieldName("trip_short_name")]
        public string ShortName { get; set; }

        [FieldName("direction_id", Format = "{0:D}")]
        public TripDirection? DirectionId { get; set; }

        [FieldName("block_id")]
        public string BlockId { get; set; }

        [FieldName("wheelchair_accessible", Format = "{0:D}")]
        public WheelchairAccessibility? WheelchairAccessible { get; set; }

        [FieldName("bikes_allowed", Format = "{0:D}")]
        public BikesAllowed? BikesAllowed { get; set; }

        public override string ToString()
        {
            return string.Format("{0}/{1} {2} @ {3}",
                                 RouteId, ShapeId, ServiceId, StartTime);
        }
    }
}