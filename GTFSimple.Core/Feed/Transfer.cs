using System;
using CsvHelper.TypeConversion;
using GTFSimple.Core.Csv;
using GTFSimple.Core.Files;

namespace GTFSimple.Core.Feed
{
    [FeedFile("transfers")]
    public class Transfer
    {
        [FieldName("from_stop_id")]
        public string FromStopId { get; set; }

        [FieldName("to_stop_id")]
        public string ToStopId { get; set; }

        [FieldName("transfer_type", Format = "{0:D}")]
        public TranferType TransferType { get; set; }

        [FieldName("min_transfer_time"), TypeConverter(typeof(TimeSpanConverter))]
        public TimeSpan? MinimumTransferTime { get; set; }
    }

    public enum TranferType
    {
        RecommendedTransferPoint = 0,
        TimedTransferPoint = 1,
        MinimumTransferTime = 2,
        NoTransfers = 3,
    }
}