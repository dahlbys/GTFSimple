using GTFSimple.Core.Feed;
using GTFSimple.Tests.Core.Csv;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Feed
{
    [TestFixture]
    public class TripTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<Trip>(
                "route_id,service_id,trip_id,trip_headsign,trip_short_name,direction_id,block_id,shape_id,wheelchair_accessible,bikes_allowed");
        }


        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entities = new[]
            {
                new Trip
                {
                    RouteId = "A",
                    ServiceId = "WE",
                    Id = "AWE1",
                    Headsign = "Downtown",
                    BlockId = "1",
                },
                new Trip
                {
                    RouteId = "A",
                    ServiceId = "WE",
                    Id = "AWE2",
                    Headsign = "Downtown",
                    BlockId = "2",
                },
                new Trip
                {
                    RouteId = "B",
                    ServiceId = "WD",
                    Id = "BWD1",
                    DirectionId = TripDirection.Outbound,
                    ShapeId = "S12",
                    WheelchairAccessible = WheelchairAccessibility.Accessible,
                    BikesAllowed = BikesAllowed.NotAllowed,
                },
                new Trip
                {
                    RouteId = "B",
                    ServiceId = "WD",
                    Id = "BWD2",
                    DirectionId = TripDirection.Inbound,
                    ShapeId = "S13",
                    WheelchairAccessible = WheelchairAccessibility.NotAccessible,
                    BikesAllowed = BikesAllowed.Allowed,
                },
            };

            AssertCsvRows(entities,
                          "A,WE,AWE1,Downtown,,,1,,,",
                          "A,WE,AWE2,Downtown,,,2,,,",
                          "B,WD,BWD1,,,0,,S12,1,2",
                          "B,WD,BWD2,,,1,,S13,2,1");
        }
    }
}