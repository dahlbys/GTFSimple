using GTFSimple.Core.Feed;
using GTFSimple.Tests.Core.Csv;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Feed
{
    [TestFixture]
    public class ShapeTests : FeedEntityTestBase
    {
        [Test]
        public void HeaderHasExpectedFields()
        {
            AssertHeader<Shape>("shape_id,shape_pt_lat,shape_pt_lon,shape_pt_sequence,shape_dist_traveled");
        }

        [Test]
        public void PopulatedEntityHasExpectedValues()
        {
            var entities = new[]
            {
                new Shape
                {
                    Id = "A_shp",
                    PointLatitude = 37.61956,
                    PointLongitude = -122.48161,
                    PointSequence = 1,
                },
                new Shape
                {
                    Id = "A_shp",
                    PointLatitude = 37.64430,
                    PointLongitude = -122.41070,
                    PointSequence = 2,
                    DistanceTraveled = 6.8310,
                },
                new Shape
                {
                    Id = "A_shp",
                    PointLatitude = 37.65863,
                    PointLongitude = -122.30839,
                    PointSequence = 3,
                    DistanceTraveled = 15.8765,
                },
            };

            AssertCsvRows(entities,
                          "A_shp,37.61956,-122.48161,1,",
                          "A_shp,37.64430,-122.41070,2,6.8310",
                          "A_shp,37.65863,-122.30839,3,15.8765");
        }
    }
}