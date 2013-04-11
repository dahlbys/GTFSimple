using System;

namespace GTFSimple.Core.Feed
{
    public class Transfer
    {
        public string FromStopId { get; set; }
        public string ToStopId { get; set; }
        public TranferType TransferType { get; set; } //use enum
        public TimeSpan? MinimumTransferTime { get; set; } //int instead?
    }

    public enum TranferType
    {
        RecommendedTransferPoint = 0,
        TimedTransferPoint = 1,
        MinimumTransferTime = 2,
        NoTransfers = 3,
    }
}
