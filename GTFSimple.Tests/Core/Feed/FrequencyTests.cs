using System;
using GTFSimple.Core.Feed;
using GTFSimple.Tests.Core.Csv;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Feed
{
    [TestFixture]
    public class FrequencyTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<Frequency>("trip_id,start_time,end_time,headway_secs,exact_times");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entities = new[]
            {
                new Frequency
                {
                    TripId = "Route01",
                    StartTime = new TimeSpan(5, 0, 0),
                    EndTime = new TimeSpan(6, 0, 0),
                    Headway = new TimeSpan(0, 0, 300),
                },
                new Frequency
                {
                    TripId = "Route01",
                    StartTime = new TimeSpan(6, 0, 0),
                    EndTime = new TimeSpan(22, 0, 0),
                    Headway = new TimeSpan(0, 0, 180),
                },
                new Frequency
                {
                    TripId = "Route02",
                    StartTime = new TimeSpan(6, 0, 0),
                    EndTime = new TimeSpan(22, 0, 0),
                    Headway = new TimeSpan(0, 0, 180),
                    ExactTimes = true,
                },
            };

            AssertCsvRows(entities,
                          "Route01,05:00:00,06:00:00,300,",
                          "Route01,06:00:00,22:00:00,180,",
                          "Route02,06:00:00,22:00:00,180,1");
        }
    }
}