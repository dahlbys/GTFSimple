using System;

namespace GTFSimple.Core
{
    public class Agency
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Uri Url { get; set; }
        public string Timezone { get; set; }
        public string Language { get; set; }
		public string Phone { get; set; }
        public Uri FareUrl { get; set; }
    }
}

