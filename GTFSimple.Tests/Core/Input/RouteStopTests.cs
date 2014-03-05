using System;
using GTFSimple.Core.Feed;
using GTFSimple.Core.Input;
using GTFSimple.Tests.Core.Csv;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Input
{
    [TestFixture]
    public class RouteStopTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<RouteStop>(
                "agency_id,route_id,shape_id,stop_sequence,stop_code,stop_name,stop_desc,stop_lat,stop_lon,zone_id,stop_url,location_type,parent_station,stop_timezone,wheelchair_boarding,arrival_offset,departure_offset,stop_headsign,pickup_type,drop_off_type,shape_dist_traveled");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entities = new[]
            {
                new RouteStop
                {
                    AgencyId = "A1",
                    RouteId = "R1",
                    ShapeId = "S1",
                    StopSequence = 1,
                    Name = "Mission St. & 15th St.",
                    Description = "The stop is located 10 feet north of Mission St.",
                    Latitude = 37.766629,
                    Longitude = -122.419782,
                    ArrivalOffset = TimeSpan.Zero,
                    DepartureOffset = TimeSpan.Zero,
                },
                new RouteStop
                {
                    AgencyId = "A1",
                    RouteId = "R1",
                    ShapeId = "S1",
                    StopSequence = 2,
                    Code = "24th&Mission",
                    Name = "24th St. Mission Station",
                    Latitude = 37.752240,
                    Longitude = -122.418450,
                    ParentStation = "S8",
                    TimeZone = "UTC-06",
                    WheelchairBoarding = WheelchairAccessibility.Accessible,
                },
                new RouteStop
                {
                    AgencyId = "A1",
                    RouteId = "R1",
                    ShapeId = "S1",
                    StopSequence = 3,
                    Code = "24SMS",
                    Name = "24th St. Mission Station",
                    Description = "Awesome",
                    Latitude = 37.752240,
                    Longitude = -122.418450,
                    ZoneId = "F1",
                    Url = new Uri("http://www.bart.gov/stations/stationguide/stationoverview_24st.asp"),
                    LocationType = LocationType.Station,
                    ParentStation = "parent",
                    TimeZone = "CST",
                    WheelchairBoarding = WheelchairAccessibility.NotAccessible,
                    ArrivalOffset = new TimeSpan(0, 12, 0),
                    DepartureOffset = new TimeSpan(0, 15, 0),
                    StopHeadsign = "24 St Mission",
                    PickupType = StopPickupType.Scheduled,
                    DropOffType = StopDropOffType.Scheduled,
                    ShapeDistanceTraveled = 3.14,
                },
            };

            AssertCsvRows(entities,
                          "A1,R1,S1,1,,Mission St. & 15th St.,The stop is located 10 feet north of Mission St.,37.766629,-122.419782,,,,,,,00:00:00,00:00:00,,,,",
                          "A1,R1,S1,2,24th&Mission,24th St. Mission Station,,37.752240,-122.418450,,,,S8,UTC-06,1,,,,,,",
                          "A1,R1,S1,3,24SMS,24th St. Mission Station,Awesome,37.752240,-122.418450,F1,http://www.bart.gov/stations/stationguide/stationoverview_24st.asp,1,parent,CST,2,00:12:00,00:15:00,24 St Mission,0,0,3.14");
        }
    }
}