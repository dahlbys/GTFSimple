using System;
using GTFSimple.Core.Feed;
using GTFSimple.Core.Generators;
using GTFSimple.Core.Input;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Generators
{
    [TestFixture]
    public class TripGeneratorTests
    {
        [Test]
        public void Trips_get_Id()
        {
            var tripTimes = new[]
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
                    ServiceId = "WD",
                    StartTime = new TimeSpan(14, 40, 0),
                    DirectionId = TripDirection.Outbound,
                    ShapeId = "S12",
                    WheelchairAccessible = WheelchairAccessibility.Accessible,
                    BikesAllowed = BikesAllowed.NotAllowed,
                },
                new TripTime
                {
                    RouteId = "B",
                    ServiceId = "WD",
                    StartTime = new TimeSpan(08, 0, 0),
                    DirectionId = TripDirection.Inbound,
                    ShapeId = "S13",
                    WheelchairAccessible = WheelchairAccessibility.NotAccessible,
                    BikesAllowed = BikesAllowed.Allowed,
                },
            };

            var generator = new TripGenerator();

            var result = generator.Generate(tripTimes, "{0}-{1}-{2:00}");

            Assert.AreEqual("A-WE-01", result[tripTimes[0]].Id);
            Assert.AreEqual("A-WE-02", result[tripTimes[1]].Id);
            Assert.AreEqual("B-WD-02", result[tripTimes[2]].Id);
            Assert.AreEqual("B-WD-01", result[tripTimes[3]].Id);
        }
    }
}