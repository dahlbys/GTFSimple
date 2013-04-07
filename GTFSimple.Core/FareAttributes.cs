using System;

namespace GTFSimple.Core
{
    public class FareAttributes
    {
        public string FareId { get; set; }
        public decimal Price { get; set; }
        public string CurrencyType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public FareTransferType? Transfers { get; set; }
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

