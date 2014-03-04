using System;
using GTFSimple.Core.Feed;
using GTFSimple.Tests.Core.Csv;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Feed
{
    [TestFixture]
    public class FareAttributesTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<FareAttributes>("fare_id,price,currency_type,payment_method,transfers,transfer_duration");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entities = new[]
            {
                new FareAttributes(),
                new FareAttributes
                {
                    FareId = "cash_adult",
                    Price = 1.25m,
                    CurrencyType = "USD",
                    PaymentMethod = PaymentMethod.OnBoard,
                    Transfers = FareTransferType.NoTransfers,
                },
                new FareAttributes
                {
                    FareId = "10_pass_elderly",
                    Price = 5,
                    CurrencyType = "USD",
                    PaymentMethod = PaymentMethod.PreBoard,
                    Transfers = FareTransferType.OneTransfer,
                    TransferDuration = new TimeSpan(0, 30, 0),
                },
                new FareAttributes
                {
                    FareId = "day_pass",
                    Price = 3,
                    CurrencyType = "USD",
                    PaymentMethod = PaymentMethod.PreBoard,
                    Transfers = FareTransferType.TwoTranfers,
                    TransferDuration = new TimeSpan(1, 0, 0),
                },
            };

            AssertCsvRows(entities,
                          ",0,,0,,",
                          "cash_adult,1.25,USD,0,0,",
                          "10_pass_elderly,5,USD,1,1,1800",
                          "day_pass,3,USD,1,2,3600");
        }
    }
}