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
        public int Type { get; set; } //Change to enum?
        public Uri? Url { get; set; }
        public string Color { get; set; } //better way to store hex?
        public string TextColor { get; set; } //better way to store hex?
    }
}

