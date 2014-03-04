using System.Collections.Generic;
using System.Linq;
using GTFSimple.Core.Feed;
using GTFSimple.Core.Input;
using GTFSimple.Core.Util;

namespace GTFSimple.Core.Generators
{
    public class TripGenerator
    {
        public IDictionary<TripTime, Trip> Generate(IEnumerable<TripTime> tripTimes, string idFormat)
        {
            var trips =
                from t in tripTimes
                group t by new { t.RouteId, t.ServiceId }
                into g
                from t in
                    (
                        from tt in g
                        orderby tt.StartTime
                        from i in tt.GetIndex()
                        select new
                        {
                            TripTime = tt,
                            Trip = new Trip
                            {
                                RouteId = tt.RouteId,
                                ServiceId = tt.ServiceId,
                                Id = string.Format(idFormat, tt.RouteId, tt.ServiceId, i + 1),
                                Headsign = tt.Headsign,
                                ShortName = tt.ShortName,
                                DirectionId = tt.DirectionId,
                                BlockId = tt.BlockId,
                                ShapeId = tt.ShapeId,
                                WheelchairAccessible = tt.WheelchairAccessible,
                                BikesAllowed = tt.BikesAllowed,
                            },
                        }
                    )
                select t;

            return trips.ToDictionary(x => x.TripTime, x => x.Trip);
        }
    }
}