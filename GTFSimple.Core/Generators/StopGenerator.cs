using System.Collections.Generic;
using System.Linq;
using GTFSimple.Core.Feed;
using GTFSimple.Core.Input;
using GTFSimple.Core.Util;

namespace GTFSimple.Core.Generators
{
    public class StopGenerator
    {
        private readonly double proximityThreshold;
        private readonly IStopIdGenerator stopIdGenerator;

        public StopGenerator(double proximityThreshold, IStopIdGenerator stopIdGenerator)
        {
            this.proximityThreshold = proximityThreshold;
            this.stopIdGenerator = stopIdGenerator;
        }

        public IDictionary<RouteStop, Stop> Generate(IEnumerable<RouteStop> routeStops)
        {
            var stops =
                from g in routeStops.GroupByCluster(Geo.Distance, proximityThreshold)
                let rsKey = g.Key
                let s = new Stop
                {
                    Id = stopIdGenerator.Generate(rsKey),
                    Code = rsKey.Code,
                    Name = rsKey.Name,
                    Description = rsKey.Description,
                    Latitude = rsKey.Latitude,
                    Longitude = rsKey.Longitude,
                    ZoneId = rsKey.ZoneId,
                    Url = rsKey.Url,
                    LocationType = rsKey.LocationType,
                    ParentStation = rsKey.ParentStation,
                    TimeZone = rsKey.TimeZone,
                    WheelchairBoarding = rsKey.WheelchairBoarding,
                }
                from rs in g
                select new
                {
                    RouteStop = rs,
                    Stop = s,
                };

            return stops.ToDictionary(x => x.RouteStop, x => x.Stop);
        }
    }
}