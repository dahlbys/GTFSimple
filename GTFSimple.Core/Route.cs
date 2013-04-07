using System;

namespace GTFSimple.Core
{
    public class Route
    {
        public string Id { get; set; }
        public string AgencyId { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Description { get; set; }
        public RouteType Type { get; set; } 
        public Uri Url { get; set; }
        public string Color { get; set; } //better way to store hex?
        public string TextColor { get; set; } //better way to store hex?
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

