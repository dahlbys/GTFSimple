using System;

namespace GTFSimple.Core
{
    public class Calendar
    {
        public string ServiceId { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public decimal StartDate { get; set; } //int instead?
        public decimal EndDate { get; set; } //int instead?
    }
}

