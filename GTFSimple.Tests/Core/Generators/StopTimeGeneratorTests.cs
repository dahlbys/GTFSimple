using System;
using System.Linq;
using GTFSimple.Core.Feed;
using GTFSimple.Core.Generators;
using GTFSimple.Core.Input;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Generators
{
    [TestFixture]
    public class StopTimeGeneratorTests
    {
        [Test]
        public void Duplicate_stops_are_combined()
        {
            var routeStops = new[]
            {
                new RouteStop
                {
                    AgencyId = "Bus",
                    RouteId = "R01",
                    StopSequence = 1,
                    Name = "GTC",
                    Latitude = 37.752240,
                    Longitude = -122.418450,
                    ArrivalOffset = TimeSpan.Zero,
                    DepartureOffset = TimeSpan.Zero,
                },
                new RouteStop
                {
                    AgencyId = "Bus",
                    RouteId = "R01",
                    Name = "A Street",
                    StopSequence = 2,
                    Latitude = 37.752340,
                    Longitude = -122.418350,
                },
                new RouteStop
                {
                    AgencyId = "Bus",
                    RouteId = "R01",
                    Name = "B Street",
                    StopSequence = 3,
                    Latitude = 37.752440,
                    Longitude = -122.418250,
                    ArrivalOffset = new TimeSpan(0, 4, 30),
                    DepartureOffset = new TimeSpan(0, 5, 00),
                },
                new RouteStop
                {
                    AgencyId = "Bus",
                    RouteId = "R02",
                    ShapeId = "S02",
                    StopSequence = 1,
                    Name = "Ground Transportation Center",
                    Latitude = 37.752245,
                    Longitude = -122.418445,
                    ArrivalOffset = TimeSpan.Zero,
                    DepartureOffset = TimeSpan.Zero,
                },
            };

            var tripTimes = new[]
            {
                new TripTime
                {
                    RouteId = "R01",
                    ServiceId = "WE",
                    StartTime = new TimeSpan(8, 0, 0),
                    Headsign = "Downtown",
                    BlockId = "1",
                },
                new TripTime
                {
                    RouteId = "R01",
                    ServiceId = "WE",
                    StartTime = new TimeSpan(11, 20, 0),
                    Headsign = "Downtown",
                    BlockId = "2",
                },
                new TripTime
                {
                    RouteId = "R02",
                    ServiceId = "WD",
                    StartTime = new TimeSpan(14, 40, 0),
                    DirectionId = TripDirection.Outbound,
                    ShapeId = "S02",
                    WheelchairAccessible = WheelchairAccessibility.Accessible,
                    BikesAllowed = BikesAllowed.NotAllowed,
                },
                new TripTime
                {
                    RouteId = "R02",
                    ServiceId = "WD",
                    StartTime = new TimeSpan(08, 0, 0),
                    DirectionId = TripDirection.Inbound,
                    ShapeId = "S02",
                    WheelchairAccessible = WheelchairAccessibility.NotAccessible,
                    BikesAllowed = BikesAllowed.Allowed,
                },
            };


            var stopGenerator = new StopGenerator(0.000001, new SequentialStopIdGenerator(2));

            var stopLookup = stopGenerator.Generate(routeStops);

            Assert.AreSame(stopLookup[routeStops[0]], stopLookup[routeStops[3]]);

            var stops = stopLookup.Values.Distinct().ToList();
            Assert.AreEqual("00", stops[0].Id);
            Assert.AreEqual("GTC", stops[0].Name);
            Assert.AreEqual("01", stops[1].Id);
            Assert.AreEqual("A Street", stops[1].Name);


            var tripGenerator = new TripGenerator();

            var tripLookup = tripGenerator.Generate(tripTimes, "{0}-{1}-{2:00}");

            Assert.AreEqual("R01-WE-01", tripLookup[tripTimes[0]].Id);
            Assert.AreEqual("R01-WE-02", tripLookup[tripTimes[1]].Id);
            Assert.AreEqual("R02-WD-02", tripLookup[tripTimes[2]].Id);
            Assert.AreEqual("R02-WD-01", tripLookup[tripTimes[3]].Id);

            var stopTimeGenerator = new StopTimeGenerator();

            var stopTimes = stopTimeGenerator.Generate(stopLookup, tripLookup).ToList();


            foreach(var st in stopTimes)
                Console.WriteLine(st);
        }
    }
}