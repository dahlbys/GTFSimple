namespace GTFSimple.Core.Feed
{
    public class FareRules
    {
        [FieldName("fare_id")]
        public string FareId { get; set; }

        [FieldName("route_id")]
        public string RouteId { get; set; }

        [FieldName("origin_id")]
        public string OriginId { get; set; }

        [FieldName("destination_id")]
        public string DestinationId { get; set; }

        [FieldName("contains_id")]
        public string ContainsId { get; set; }
    }
}