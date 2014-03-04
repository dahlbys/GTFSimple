using System;
using GTFSimple.Core.Feed;
using GTFSimple.Tests.Core.Csv;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Feed
{
    [TestFixture]
    public class FeedInfoTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<FeedInfo>(
                "feed_publisher_name,feed_publisher_url,feed_lang,feed_start_date,feed_end_date,feed_version");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entity = new FeedInfo
            {
                FeedPublisherName = "Linn County",
                FeedPublisherUrl = new Uri("http://www.linncounty.org/"),
                FeedLanguage = "en",
                FeedStartDate = new DateTime(2007, 09, 08),
                FeedEndDate = new DateTime(2011, 07, 10),
                FeedVersion = "1.0",
            };

            AssertCsvRow(entity, "Linn County,http://www.linncounty.org/,en,20070908,20110710,1.0");
        }
    }
}