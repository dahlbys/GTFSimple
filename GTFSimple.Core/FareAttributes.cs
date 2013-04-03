using System;

namespace GTFSimple.Core
{
    public class FareAttributes
    {
        public string FareId { get; set; }
        public decimal Price { get; set; }
        public string CurrencyType { get; set; }
        public bool PaymentMethod { get; set; }
        public bool Transfers { get; set; } //create enum
        public decimal TransferDuration { get; set; }

    }
}

