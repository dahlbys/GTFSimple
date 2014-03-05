using System.Collections.Generic;
using System.Linq;
using GTFSimple.Core.Feed;
using GTFSimple.Core.Input;
using GTFSimple.Core.Util;

namespace GTFSimple.Core.Generators
{
    public class StopTimeGenerator
    {
        public IEnumerable<StopTime> Generate(IDictionary<RouteStop, Stop> routeStops,
                                              IDictionary<TripTime, Trip> tripTimes)
        {
            return from x in tripTimes
                   let tt = x.Key
                   let trip = x.Value
                   orderby tt.RouteId, tt.ServiceId, tt.ShapeId, tt.StartTime
                   join y in routeStops on
                       new { tt.RouteId, tt.ShapeId } equals
                       new { y.Key.RouteId, y.Key.ShapeId }
                       into tripStops
                   from st in
                       (
                           from z in tripStops
                           let rs = z.Key
                           let stop = z.Value
                           orderby rs.StopSequence
                           from i in z.GetIndex()
                           select new StopTime
                           {
                               TripId = trip.Id,
                               ArrivalTime = tt.StartTime + rs.ArrivalOffset,
                               DepartureTime = tt.StartTime + rs.DepartureOffset,
                               StopId = stop.Id,
                               StopSequence = (uint)i,
                               StopHeadsign = rs.StopHeadsign,
                               PickupType = rs.PickupType,
                               DropOffType = rs.DropOffType,
                               ShapeDistanceTraveled = rs.ShapeDistanceTraveled,
                           }
                       )
                   select st;
        }
    }
}