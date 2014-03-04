using System.Linq;
using GTFSimple.Core.Generators;
using GTFSimple.Core.Input;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Generators
{
    [TestFixture]
    public class StopGeneratorTests
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
                    RouteId = "R02",
                    StopSequence = 1,
                    Name = "Ground Transportation Center",
                    Latitude = 37.752245,
                    Longitude = -122.418445,
                },
            };

            var generator = new StopGenerator(0.000001, new SequentialStopIdGenerator(2));

            var result = generator.Generate(routeStops);

            Assert.AreSame(result[routeStops[0]], result[routeStops[2]]);

            var stops = result.Values.Distinct().ToList();
            Assert.AreEqual("00", stops[0].Id);
            Assert.AreEqual("GTC", stops[0].Name);
            Assert.AreEqual("01", stops[1].Id);
            Assert.AreEqual("A Street", stops[1].Name);
        }
    }
}