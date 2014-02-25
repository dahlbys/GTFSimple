using GTFSimple.Core.Feed;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Feed
{
    [TestFixture]
    public class FareRulesTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<FareRules>("fare_id,route_id,origin_id,destination_id,contains_id");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entities = new[]
            {
                new FareRules
                {
                    FareId = "different_pricing",
                    RouteId = "Route_1",
                },
                new FareRules
                {
                    FareId = "station_pairs",
                    OriginId = "S1",
                    DestinationId = "S2",
                },
                new FareRules
                {
                    FareId = "zone_pass",
                    ContainsId = "2",
                },
            };

            AssertCsvRows(entities,
                          "different_pricing,Route_1,,,",
                          "station_pairs,,S1,S2,",
                          "zone_pass,,,,2");
        }
    }
}