using System;

namespace GTFSimple.Core
{
    public class Transfer
    {
        public string FromStopId { get; set; }
        public string ToStopId { get; set; }
        public bool TransferType { get; set; } //use enum
        public decimal MinimumTransferTime { get; set; } //int instead?

    }
}

