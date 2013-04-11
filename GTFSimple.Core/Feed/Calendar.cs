using System;

namespace GTFSimple.Core.Feed
{
    public class Calendar
    {
        [FieldName("service_id")]
        public string ServiceId { get; set; }
        [FieldName("monday")]
        public bool Monday { get; set; }
        [FieldName("tuesday")]
        public bool Tuesday { get; set; }
        [FieldName("wednesday")]
        public bool Wednesday { get; set; }
        [FieldName("thursday")]
        public bool Thursday { get; set; }
        [FieldName("friday")]
        public bool Friday { get; set; }
        [FieldName("saturday")]
        public bool Saturday { get; set; }
        [FieldName("sunday")]
        public bool Sunday { get; set; }
        [FieldName("start_date")]
        public DateTime StartDate { get; set; }
        [FieldName("end_date")]
        public DateTime EndDate { get; set; }
    }
}

