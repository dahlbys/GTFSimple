using System;
using GTFSimple.Core.Feed;
using GTFSimple.Tests.Core.Csv;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Feed
{
    [TestFixture]
    public class StopTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<Stop>(
                "stop_id,stop_code,stop_name,stop_desc,stop_lat,stop_lon,zone_id,stop_url,location_type,parent_station,stop_timezone,wheelchair_boarding");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entities = new[]
            {
                new Stop
                {
                    Id = "S1",
                    Name = "Mission St. & 15th St.",
                    Description = "The stop is located 10 feet north of Mission St.",
                    Latitude = 37.766629,
                    Longitude = -122.419782,
                },
                new Stop
                {
                    Id = "S2",
                    Code = "24th&Mission",
                    Name = "24th St. Mission Station",
                    Latitude = 37.752240,
                    Longitude = -122.418450,
                    ParentStation = "S8",
                    TimeZone = "UTC-06",
                    WheelchairBoarding = WheelchairAccessibility.Accessible,
                },
                new Stop
                {
                    Id = "S3",
                    Name = "24th St. Mission Station",
                    Latitude = 37.752240,
                    Longitude = -122.418450,
                    ZoneId = "F1",
                    Url = new Uri("http://www.bart.gov/stations/stationguide/stationoverview_24st.asp"),
                    LocationType = LocationType.Station,
                    WheelchairBoarding = WheelchairAccessibility.NotAccessible,
                },
            };

            AssertCsvRows(entities,
                          "S1,,Mission St. & 15th St.,The stop is located 10 feet north of Mission St.,37.766629,-122.419782,,,,,,",
                          "S2,24th&Mission,24th St. Mission Station,,37.752240,-122.418450,,,,S8,UTC-06,1",
                          "S3,,24th St. Mission Station,,37.752240,-122.418450,F1,http://www.bart.gov/stations/stationguide/stationoverview_24st.asp,1,,,2");
        }
    }
}