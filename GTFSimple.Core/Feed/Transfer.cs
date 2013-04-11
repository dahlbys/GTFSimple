using System;

namespace GTFSimple.Core.Feed
{
    public class Transfer
    {
        [FieldName("from_stop_id")]
        public string FromStopId { get; set; }
        [FieldName("to_stop_id")]
        public string ToStopId { get; set; }
        [FieldName("transfer_type")]
        public TranferType TransferType { get; set; } //use enum
        [FieldName("min_transfer_time")]
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

