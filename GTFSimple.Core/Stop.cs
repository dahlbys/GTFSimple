using System;

namespace GTFSimple.Core
{
    public class Stop
    {
        public string Id { get; set; }
        public string Code { get; set; }
		public string Name { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string ZoneId { get; set; }
        public Uri Url { get; set; }
        public LocationType? LocationType { get; set; }
        public string ParentStation { get; set; }
        public TimeZoneInfo TimeZone { get; set; }
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

