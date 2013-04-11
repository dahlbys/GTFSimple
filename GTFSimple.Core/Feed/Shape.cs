using System;

namespace GTFSimple.Core.Feed
{
    public class Shape
    {
        [FieldName("shape_id")]
        public string Id { get; set; }
        [FieldName("shape_pt_lat")]
        public decimal PointLatitude { get; set; }
        [FieldName("shape_pt_lon")]
        public decimal PointLongitude { get; set; }
        [FieldName("shape_pt_sequence")]
        public uint PointSequence { get; set; }
        [FieldName("shape_dist_traveled")]
        public decimal? DistanceTraveled { get; set; }
    }
}

