namespace GTFSimple.Core.Feed
{
    public class Shape
    {
        public string Id { get; set; }
        public decimal PointLatitude { get; set; }
        public decimal PointLongitude { get; set; }
        public uint PointSequence { get; set; }
        public decimal? DistanceTraveled { get; set; }
    }
}
