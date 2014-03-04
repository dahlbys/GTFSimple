using System;
using GTFSimple.Core.Feed;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Feed
{
    [TestFixture]
    public class AgencyTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<Agency>(
                "agency_id,agency_name,agency_url,agency_timezone,agency_lang,agency_phone,agency_fare_url");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entity = new Agency
            {
                Id = "cr_transit",
                Name = "CR Transit",
                Url = new Uri("http://www.cedar-rapids.org/resident-resources/Transit/Pages/default.aspx"),
                TimeZone = "UTC-06",
                Language = "en",
                Phone = "319-286-5573",
                FareUrl = new Uri("http://www.cedar-rapids.org/resident-resources/Transit/fares/Pages/default.aspx"),
            };

            AssertCsvRow(entity,
                         "cr_transit,CR Transit,http://www.cedar-rapids.org/resident-resources/Transit/Pages/default.aspx,UTC-06,en,319-286-5573,http://www.cedar-rapids.org/resident-resources/Transit/fares/Pages/default.aspx");
        }
    }
}