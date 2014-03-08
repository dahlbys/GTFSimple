using System;
using CsvHelper.TypeConversion;
using GTFSimple.Core.Csv;
using GTFSimple.Core.Files;

namespace GTFSimple.Core.Feed
{
    [FeedFile("stop_times")]
    public class StopTime
    {
        [FieldName("trip_id")]
        public string TripId { get; set; }

        [FieldName("arrival_time"), TypeConverter(typeof(TimeSpanHourMinuteSecondConverter))]
        public TimeSpan? ArrivalTime { get; set; }

        [FieldName("departure_time"), TypeConverter(typeof(TimeSpanHourMinuteSecondConverter))]
        public TimeSpan? DepartureTime { get; set; }

        [FieldName("stop_id")]
        public string StopId { get; set; }

        [FieldName("stop_sequence")]
        public uint StopSequence { get; set; }

        [FieldName("stop_headsign")]
        public string StopHeadsign { get; set; }

        [FieldName("pickup_type", Format = "{0:D}")]
        public StopPickupType? PickupType { get; set; }

        [FieldName("drop_off_type", Format = "{0:D}")]
        public StopDropOffType? DropOffType { get; set; }

        [FieldName("shape_dist_traveled")]
        public double? ShapeDistanceTraveled { get; set; }

        public override string ToString()
        {
            return string.Format("{0} #{1}: {2}{3}{4}",
                                 TripId, StopSequence, StopId,
                                 ArrivalTime == null ? "" : " @ " + ArrivalTime,
                                 ArrivalTime == DepartureTime ? "" : " \u2013 " + DepartureTime);
        }
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