using System;

namespace GTFSimple.Core.Feed
{
    public class Agency
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Uri Url { get; set; }
        public TimeZoneInfo TimeZone { get; set; }
        public string Language { get; set; } //or string?
        public string Phone { get; set; }
        public Uri FareUrl { get; set; }
    }
}
