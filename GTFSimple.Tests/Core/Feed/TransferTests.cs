using System;
using GTFSimple.Core.Feed;
using GTFSimple.Tests.Core.Csv;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Feed
{
    [TestFixture]
    public class TransferTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<Transfer>("from_stop_id,to_stop_id,transfer_type,min_transfer_time");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entities = new[]
            {
                new Transfer
                {
                    FromStopId = "S6",
                    ToStopId = "S7",
                    TransferType = TranferType.MinimumTransferTime,
                    MinimumTransferTime = new TimeSpan(0, 0, 300),
                },
                new Transfer
                {
                    FromStopId = "S7",
                    ToStopId = "S6",
                    TransferType = TranferType.NoTransfers,
                },
                new Transfer
                {
                    FromStopId = "S23",
                    ToStopId = "S7",
                    TransferType = TranferType.TimedTransferPoint,
                },
                new Transfer
                {
                    FromStopId = "S6",
                    ToStopId = "S8",
                    TransferType = TranferType.RecommendedTransferPoint,
                    MinimumTransferTime = new TimeSpan(0, 0, 360),
                }
            };

            AssertCsvRows(entities,
                          "S6,S7,2,300",
                          "S7,S6,3,",
                          "S23,S7,1,",
                          "S6,S8,0,360");
        }
    }
}