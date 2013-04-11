using System;

namespace GTFSimple.Core.Feed
{
    public class Stop
    {
        [FieldName("stop_id")]
        public string Id { get; set; }
        [FieldName("stop_code")]
        public string Code { get; set; }
        [FieldName("stop_name")]
		public string Name { get; set; }
        [FieldName("stop_desc")]
        public string Description { get; set; }
        [FieldName("stop_lat")]
        public decimal Latitude { get; set; }
        [FieldName("stop_lon")]
        public decimal Longitude { get; set; }
        [FieldName("zone_id")]
        public string ZoneId { get; set; }
        [FieldName("stop_url")]
        public Uri Url { get; set; }
        [FieldName("location_type")]
        public LocationType? LocationType { get; set; }
        [FieldName("parent_station")]
        public string ParentStation { get; set; }
        [FieldName("stop_timezone")]
        public TimeZoneInfo TimeZone { get; set; }
        [FieldName("wheelchair_boarding")]
        public WheelchairAccessibility? WheelchairBoarding { get; set; }
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

