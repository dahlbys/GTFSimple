using System;

namespace GTFSimple.Core.Feed
{
    public class Agency
    {
        [FieldName("agency_id")]
        public string Id { get; set; }

        [FieldName("agency_name")]
        public string Name { get; set; }

        [FieldName("agency_url")]
        public Uri Url { get; set; }

        [FieldName("agency_timezone")]
        public string TimeZone { get; set; }

        [FieldName("agency_lang")]
        public string Language { get; set; }

        [FieldName("agency_phone")]
        public string Phone { get; set; }

        [FieldName("agency_fare_url")]
        public Uri FareUrl { get; set; }
    }
}