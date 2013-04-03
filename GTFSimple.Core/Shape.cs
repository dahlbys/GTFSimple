using System;

namespace GTFSimple.Core
{
    public class Shape
    {
        public string Id { get; set; }
        public decimal PointLatitude { get; set; }
        public decimal PointLongitude { get; set; }
        public decimal PointSequence { get; set; } //int instead?
        public decimal DistanceTraveled { get; set; }

    }
}

