using System;
using GTFSimple.Core.Feed;
using GTFSimple.Core.Input;
using GTFSimple.Tests.Core.Csv;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Input
{
    [TestFixture]
    public class TripTimeTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<TripTime>(
                "route_id,shape_id,service_id,start_time,trip_headsign,trip_short_name,direction_id,block_id,wheelchair_accessible,bikes_allowed");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entities = new[]
            {
                new TripTime
                {
                    RouteId = "A",
                    ServiceId = "WE",
                    StartTime = new TimeSpan(8, 0, 0),
                    Headsign = "Downtown",
                    BlockId = "1",
                },
                new TripTime
                {
                    RouteId = "A",
                    ServiceId = "WE",
                    StartTime = new TimeSpan(11, 20, 0),
                    Headsign = "Downtown",
                    BlockId = "2",
                },
                new TripTime
                {
                    RouteId = "B",
                    ShapeId = "S12",
                    ServiceId = "WD",
                    StartTime = new TimeSpan(14, 40, 0),
                    DirectionId = TripDirection.Outbound,
                    WheelchairAccessible = WheelchairAccessibility.Accessible,
                    BikesAllowed = BikesAllowed.NotAllowed,
                },
                new TripTime
                {
                    RouteId = "B",
                    ShapeId = "S13",
                    ServiceId = "WD",
                    StartTime = new TimeSpan(18, 0, 0),
                    DirectionId = TripDirection.Inbound,
                    WheelchairAccessible = WheelchairAccessibility.NotAccessible,
                    BikesAllowed = BikesAllowed.Allowed,
                },
            };

            AssertCsvRows(entities,
                          "A,,WE,08:00:00,Downtown,,,1,,",
                          "A,,WE,11:20:00,Downtown,,,2,,",
                          "B,S12,WD,14:40:00,,,0,,1,2",
                          "B,S13,WD,18:00:00,,,1,,2,1");
        }
    }
}