using System;
using GTFSimple.Core.Feed;
using GTFSimple.Tests.Core.Csv;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Feed
{
    [TestFixture]
    public class CalendarDateTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<CalendarDate>("service_id,date,exception_type");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entities = new[]
            {
                new CalendarDate
                {
                    ServiceId = "WD",
                    Date = new DateTime(2007, 09, 08),
                    ExceptionType = ExceptionType.Added,
                },
                new CalendarDate
                {
                    ServiceId = "WE",
                    Date = new DateTime(2011, 07, 10),
                    ExceptionType = ExceptionType.Removed,
                },
            };

            AssertCsvRows(entities,
                          "WD,20070908,1",
                          "WE,20110710,2");
        }
    }
}