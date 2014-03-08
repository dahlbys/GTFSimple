using System;
using GTFSimple.Core.Feed;
using GTFSimple.Tests.Core.Csv;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Feed
{
    [TestFixture]
    public class StopTimeTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<StopTime>(
                "trip_id,arrival_time,departure_time,stop_id,stop_sequence,stop_headsign,pickup_type,drop_off_type,shape_dist_traveled");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entities = new[]
            {
                new StopTime
                {
                    TripId = "AWE1",
                    ArrivalTime = new TimeSpan(6, 10, 0),
                    DepartureTime = new TimeSpan(6, 10, 0),
                    StopId = "S1",
                    StopSequence = 1,
                    StopHeadsign = "Round & Round",
                    PickupType = StopPickupType.Scheduled,
                },
                new StopTime
                {
                    TripId = "AWE1",
                    StopId = "S2",
                    StopSequence = 2,
                    PickupType = StopPickupType.ArrangeByPhone,
                    DropOffType = StopDropOffType.ArrangeByDriver,
                    ShapeDistanceTraveled = 6.1123,
                },
                new StopTime
                {
                    TripId = "101WD-1",
                    ArrivalTime = new TimeSpan(5, 20, 0),
                    DepartureTime = new TimeSpan(5, 22, 30),
                    StopId = "2",
                    StopSequence = 2,
                    DropOffType = StopDropOffType.NotAvailable,
                },
            };

            AssertCsvRows(entities,
                          "AWE1,06:10:00,06:10:00,S1,1,Round & Round,0,,",
                          "AWE1,,,S2,2,,2,3,6.1123",
                          "101WD-1,05:20:00,05:22:30,2,2,,,1,");
        }
    }
}