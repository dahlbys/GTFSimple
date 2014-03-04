using System;
using GTFSimple.Core.Feed;
using GTFSimple.Tests.Core.Csv;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Feed
{
    [TestFixture]
    public class CalendarTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<Calendar>(
                "service_id,monday,tuesday,wednesday,thursday,friday,saturday,sunday,start_date,end_date");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entities = new[]
            {
                new Calendar
                {
                    ServiceId = "xx"
                },
                new Calendar
                {
                    ServiceId = "WD",
                    Monday = true,
                    Tuesday = false,
                    Wednesday = true,
                    Thursday = false,
                    Friday = true,
                    Saturday = false,
                    Sunday = false,
                    StartDate = new DateTime(2007, 9, 8),
                    EndDate = new DateTime(2011, 7, 10),
                },
            };

            AssertCsvRows(entities,
                          "xx,0,0,0,0,0,0,0,00010101,00010101",
                          "WD,1,0,1,0,1,0,0,20070908,20110710");
        }
    }
}