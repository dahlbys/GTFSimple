using System;
using GTFSimple.Core.Feed;
using GTFSimple.Tests.Core.Csv;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Feed
{
    [TestFixture]
    public class RouteTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<Route>(
                "route_id,agency_id,route_short_name,route_long_name,route_desc,route_type,route_url,route_color,route_text_color");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entities = new[]
            {
                new Route
                {
                    Id = "R01",
                    AgencyId = "cr_transit",
                    ShortName = "1",
                    LongName = "Northwest Cedar Rapids",
                    Description = "Awesomeness",
                    Type = RouteType.Bus,
                    Url = new Uri("http://www.cedar-rapids.org/resident-resources/transit/routes/pages/route1.aspx"),
                    Color = "FFFFFF",
                    TextColor = "000000",
                },
                new Route
                {
                    Id = "R02",
                    AgencyId = "cr_transit",
                    ShortName = "2",
                    LongName = "Southeast Cedar Rapids",
                    Description = "",
                    Type = RouteType.CableCar,
                    Url = new Uri("http://www.cedar-rapids.org/resident-resources/transit/routes/pages/route2.aspx"),
                },
                new Route
                {
                    Id = "R03",
                    AgencyId = "cr_transit",
                    ShortName = "3",
                    LongName = "North-Central Cedar Rapids",
                    Description = "",
                    Type = RouteType.Ferry,
                    Url = new Uri("http://www.cedar-rapids.org/resident-resources/transit/routes/pages/route3.aspx"),
                },
            };

            AssertCsvRows(entities,
                          "R01,cr_transit,1,Northwest Cedar Rapids,Awesomeness,3,http://www.cedar-rapids.org/resident-resources/transit/routes/pages/route1.aspx,FFFFFF,000000",
                          "R02,cr_transit,2,Southeast Cedar Rapids,,5,http://www.cedar-rapids.org/resident-resources/transit/routes/pages/route2.aspx,,",
                          "R03,cr_transit,3,North-Central Cedar Rapids,,4,http://www.cedar-rapids.org/resident-resources/transit/routes/pages/route3.aspx,,");
        }
    }
}