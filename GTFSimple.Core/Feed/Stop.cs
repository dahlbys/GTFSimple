using System;
using GTFSimple.Core.Csv;
using GTFSimple.Core.Util;

namespace GTFSimple.Core.Feed
{
    public class Stop : ILocation
    {
        [FieldName("stop_id")]
        public string Id { get; set; }

        [FieldName("stop_code")]
        public string Code { get; set; }

        [FieldName("stop_name")]
        public string Name { get; set; }

        [FieldName("stop_desc")]
        public string Description { get; set; }

        [FieldName("stop_lat", Format = "{0:0.000000}")]
        public double Latitude { get; set; }

        [FieldName("stop_lon", Format = "{0:0.000000}")]
        public double Longitude { get; set; }

        [FieldName("zone_id")]
        public string ZoneId { get; set; }

        [FieldName("stop_url")]
        public Uri Url { get; set; }

        [FieldName("location_type", Format = "{0:D}")]
        public LocationType? LocationType { get; set; }

        [FieldName("parent_station")]
        public string ParentStation { get; set; }

        [FieldName("stop_timezone")]
        public string TimeZone { get; set; }

        [FieldName("wheelchair_boarding", Format = "{0:D}")]
        public WheelchairAccessibility? WheelchairBoarding { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: '{1}' @ {2:0.000000}, {3:0.000000}",
                                 Id, Name, Latitude, Longitude);
        }
    }

    public enum LocationType
    {
        Stop = 0,
        Station = 1,
    }

    public enum WheelchairAccessibility
    {
        Unspecified = 0,
        Accessible = 1,
        NotAccessible = 2,
    }
}