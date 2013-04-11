using System;

namespace GTFSimple.Core.Feed
{
    public class FareAttributes
    {
        [FieldName("fare_id")]
        public string FareId { get; set; }
        [FieldName("price")]
        public decimal Price { get; set; }
        [FieldName("currency_type")]
        public string CurrencyType { get; set; }
        [FieldName("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }
        [FieldName("transfers")]
        public FareTransferType? Transfers { get; set; }
        [FieldName("transfer_duration")]
        public TimeSpan? TransferDuration { get; set; }
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

