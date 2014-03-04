using GTFSimple.Core.Csv;

namespace GTFSimple.Core.Feed
{
    public class Shape
    {
        [FieldName("shape_id")]
        public string Id { get; set; }

        [FieldName("shape_pt_lat", Format = "{0:0.000000}")]
        public double PointLatitude { get; set; }

        [FieldName("shape_pt_lon", Format = "{0:0.000000}")]
        public double PointLongitude { get; set; }

        [FieldName("shape_pt_sequence")]
        public uint PointSequence { get; set; }

        [FieldName("shape_dist_traveled", Format = "{0:0.0000}")]
        public double? DistanceTraveled { get; set; }

        public override string ToString()
        {
            return string.Format("{0} #{1} @ {2:0.000000}, {3:0.000000}",
                                 Id, PointSequence, PointLatitude, PointLongitude);
        }
    }
}