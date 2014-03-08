using System;
using CsvHelper.TypeConversion;
using GTFSimple.Core.Csv;
using GTFSimple.Core.Files;

namespace GTFSimple.Core.Feed
{
    [FeedFile("fare_attributes")]
    public class FareAttributes
    {
        [FieldName("fare_id")]
        public string FareId { get; set; }

        [FieldName("price")]
        public decimal Price { get; set; }

        [FieldName("currency_type")]
        public string CurrencyType { get; set; }

        [FieldName("payment_method", Format = "{0:D}")]
        public PaymentMethod PaymentMethod { get; set; }

        [FieldName("transfers", Format = "{0:D}")]
        public FareTransferType? Transfers { get; set; }

        [FieldName("transfer_duration"), TypeConverter(typeof(TimeSpanSecondsConverter))]
        public TimeSpan? TransferDuration { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1:0.00} {2} ({3})",
                                 FareId, Price, CurrencyType, PaymentMethod);
        }
    }

    public enum PaymentMethod
    {
        OnBoard = 0,
        PreBoard = 1,
    }

    public enum FareTransferType
    {
        NoTransfers = 0,
        OneTransfer = 1,
        TwoTranfers = 2,
    }
}