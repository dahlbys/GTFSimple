using System;
using GTFSimple.Core.Csv;
using GTFSimple.Core.Files;

namespace GTFSimple.Core.Feed
{
    [FeedFile("routes")]
    public class Route
    {
        [FieldName("route_id")]
        public string Id { get; set; }

        [FieldName("agency_id")]
        public string AgencyId { get; set; }

        [FieldName("route_short_name")]
        public string ShortName { get; set; }

        [FieldName("route_long_name")]
        public string LongName { get; set; }

        [FieldName("route_desc")]
        public string Description { get; set; }

        [FieldName("route_type", Format = "{0:D}")]
        public RouteType Type { get; set; }

        [FieldName("route_url")]
        public Uri Url { get; set; }

        [FieldName("route_color")]
        public string Color { get; set; }

        [FieldName("route_text_color")]
        public string TextColor { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1} {2}",
                                 Id, ShortName, LongName);
        }
    }

    public enum RouteType
    {
        Tram = 0,
        Subway = 1,
        Rail = 2,
        Bus = 3,
        Ferry = 4,
        CableCar = 5,
        Gondola = 6,
        Funicular = 7,
    }
}