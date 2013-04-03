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
        public bool? LocationType { get; set; }
        public bool? ParentStation { get; set; }
        public string Timezone { get; set; }
        public bool? WheelchairBoarding { get; set; }
    }
}

